using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace ChatServer
{
	public partial class ServerForm : Form
	{
		private TcpListener _listener;
		private Thread _listenThread;
		private volatile bool _isServerRunning = false;
		private List<TcpClient> _clients;// = new List<TcpClient>();
		public ServerForm()
		{
			InitializeComponent();
			_clients = new List<TcpClient>();
		}

		private void buttonStartServer_Click(object sender, EventArgs e) 
		{
			if (buttonStartServer.Text == "Start server")
			{
				buttonStartServer.Text = "Stop server";
				_isServerRunning = true;
				_listenThread = new Thread(ListenForClients);
				_listenThread.Start();
				Log($"Server started at {DateTime.Now}");
			}
			else
			{
				_isServerRunning = false;
				StopServer();
				buttonStartServer.Text = "Start server";
			}
		}

		private void StopServer()
		{
			_listener?.Stop();

			lock (_clients)
			{
				foreach (var client in _clients)
				{
					client?.Close();
				}
				_clients.Clear();
			}

			if (_listenThread != null && _listenThread.IsAlive)
				_listenThread.Join(2000); //2000 milliseconds

			Log($"Server stopped at {DateTime.Now}");
		}
		private void ListenForClients()
		{
			try
			{
				_listener = new TcpListener(IPAddress.Any, 10248);
				_listener.Start();

				while (_isServerRunning)
				{
					try
					{
						//TcpClient client = _listener.AcceptTcpClient();
						_listener.Server.ReceiveTimeout = 1000;

						if (_listener.Pending())
						{
							TcpClient client = _listener.AcceptTcpClient();
							lock (_clients)
							{
								_clients.Add(client);
							}

							Log($"Клиент подключен. Всего клиентов {_clients.Count}");

							Thread clientThread = new Thread(HandleClientComm);
							clientThread.IsBackground = true;
							clientThread.Start(client);
						}
						else Thread.Sleep(100);
					}
					catch (SocketException ex) when (ex.SocketErrorCode == SocketError.TimedOut)
					{

						continue;

					}
				}
			}
			catch (Exception ex)
			{
				Log($"ListenForClients error: {ex.Message}");
			}
			finally
			{
				_listener?.Stop();
				Log("ListenForClients thread finished");
			}
		}

		private void HandleClientComm(object clientObj)
		{
			TcpClient tcpClient = (TcpClient)clientObj;
			NetworkStream clientStream = tcpClient.GetStream();
			byte[] message = new byte[4096];
			int bytesRead = 0;
			while (true)
			{
				bytesRead = 0;
				try
				{
					bytesRead = clientStream.Read(message, 0, 4096);
				}
				catch
				{
					break;
				}
				if (bytesRead == 0)
				{
					break;
				}

				string receivedMessage = Encoding.UTF8.GetString(message, 0, bytesRead);
				Log($"Received: {receivedMessage}");

				BroadcastMessage( receivedMessage, tcpClient );
			} //while

			lock (_clients)
			{
				_clients.Remove(tcpClient);
			}
			tcpClient.Close();
			Log($"Client is removed. Now received: {_clients.Count}");
		}

		private void BroadcastMessage( string msg, TcpClient senderClient = null )
		{
			byte[] broadcastBytes = Encoding.UTF8.GetBytes( msg );
			lock (_clients)
			{
				foreach (TcpClient client in _clients)
				{
					try
					{
						NetworkStream stream = client.GetStream();
						stream.Write(broadcastBytes, 0, broadcastBytes.Length);
						stream.Flush();
					}
					catch ( Exception ex)
					{
						Log($"Error sending to client: {ex.Message}");
					}
				}
			}
		}

		private void Log( string msg )
		{
			if (rtbLogs.InvokeRequired)
			{
				rtbLogs.Invoke(new MethodInvoker(() => rtbLogs.AppendText($"{msg}{Environment.NewLine}")));
			}
			else
			{
				rtbLogs.AppendText($"{msg}{Environment.NewLine}");
			}
		}
	}
}
