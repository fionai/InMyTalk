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
			try
			{
				_tcpClient = new TcpClient();
				_tcpClient.Connect("127.0.0.1", 10248);   //на время теста test
				_serverStream = _tcpClient.GetStream();

				//AppendToChat("");

				_receiveThread = new Thread(ReceiveMessage);
				_receiveThread.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка подключения: {ex.Message}");
			}
		}

		private void buttonSend_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(textBoxInput.Text))
			{
				string msg = textBoxInput.Text;
				byte[] sendBytes = Encoding.UTF8.GetBytes(msg);
				_serverStream.Write(sendBytes, 0, sendBytes.Length);
				_serverStream.Flush();

				AppendToChat($"Я: {msg}");
				textBoxInput.Clear();
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
