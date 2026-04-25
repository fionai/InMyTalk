using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;

namespace InMyTalk
{
	public partial class ClientForm : Form
	{
		private TcpClient _tcpClient;
		private NetworkStream _serverStream;
		private Thread _receiveThread;
		private bool _isConnected = false;
		private readonly object _sendLock = new object();
		public ClientForm()
		{
			InitializeComponent();
			if (!_isConnected)  ConnectToServer();
		}

		private async void ConnectToServer()
		{
			try
			{
				_tcpClient = new TcpClient();
				await _tcpClient.ConnectAsync("127.0.0.1", 10248);   //такой IP на время теста test
				_serverStream = _tcpClient.GetStream();
				_isConnected = true;

				AppendToChat(">>> Подключено к серверу!");

				_receiveThread = new Thread(ReceiveMessage);
				_receiveThread.IsBackground = true;
				_receiveThread.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка подключения: {ex.Message}");
				_isConnected = false;
			}

		}

		private void DisconnectFromServer()
		{
			_isConnected = false;

			try
			{
				_serverStream?.Close();
				_tcpClient?.Close();
			}
			catch { }
			AppendToChat(">>> Отключено от сервера.");
		}

		private void buttonSend_Click(object sender, EventArgs e)
		{
			if (!_isConnected || _tcpClient == null || !_tcpClient.Connected)
			{
				AppendToChat("No connection to server");
				DisconnectFromServer();
				return;
			}
			if (string.IsNullOrWhiteSpace(textBoxInput.Text)) return;

			try
			{
				string msg = textBoxInput.Text;
				byte[] sendBytes = Encoding.UTF8.GetBytes(msg);

				lock (_sendLock)
				{
					if (_serverStream != null && _tcpClient.Connected)
					{
						_serverStream.Write(sendBytes, 0, sendBytes.Length);
						_serverStream.Flush();
					}
				}

				AppendToChat($"Я: {msg}");
				textBoxInput.Clear();
			}
			catch (IOException ex)
			{
				AppendToChat($"Error: connection is lost. {ex.Message}");
				DisconnectFromServer();
			}
			catch (Exception ex)
			{
				AppendToChat($"Error sending: {ex.Message}");
			}
		}

		private void ReceiveMessage()
		{
			byte[] buffer = new byte[4096];
			int bytesRead = 0;
			while (true)
			{
				try
				{
					bytesRead = _serverStream.Read(buffer, 0, 4096);
					if (bytesRead == 0) break;

					string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
					AppendToChat(receivedMessage);
				}
				catch
				{
					AppendToChat("Ошибка сервера.");
					break;
				}

			}
		}

		private void AppendToChat(string msg)
		{
			if (listBoxChat.InvokeRequired)
			{
				listBoxChat.Invoke(new MethodInvoker(() =>
				{
					listBoxChat.Items.Add(msg);
					listBoxChat.TopIndex = listBoxChat.Items.Count - 1;
				}
				));
			}
			else
			{
				listBoxChat.Items.Add(msg);
				listBoxChat.TopIndex = listBoxChat.Items.Count - 1;
			}
		}
	}
}
