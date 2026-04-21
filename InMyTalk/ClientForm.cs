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
		private TcpClient tcpClient;
		private NetworkStream _serverStream;
		private Thread _receiveThread;
		public ClientForm()
		{
			InitializeComponent();

		}
	}
}
