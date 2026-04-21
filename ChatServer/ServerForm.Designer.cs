namespace ChatServer
{
	partial class ServerForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			buttonStartServer = new Button();
			rtbLogs = new RichTextBox();
			SuspendLayout();
			// 
			// buttonStartServer
			// 
			buttonStartServer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			buttonStartServer.BackColor = SystemColors.ActiveCaption;
			buttonStartServer.Font = new Font("Segoe UI", 11F);
			buttonStartServer.Location = new Point(13, 265);
			buttonStartServer.Name = "buttonStartServer";
			buttonStartServer.Size = new Size(199, 54);
			buttonStartServer.TabIndex = 0;
			buttonStartServer.Text = "Start server";
			buttonStartServer.UseVisualStyleBackColor = false;
			buttonStartServer.Click += buttonStartServer_Click;
			// 
			// rtbLogs
			// 
			rtbLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			rtbLogs.Location = new Point(13, 13);
			rtbLogs.Name = "rtbLogs";
			rtbLogs.Size = new Size(198, 246);
			rtbLogs.TabIndex = 1;
			rtbLogs.Text = "";
			// 
			// ServerForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(225, 331);
			Controls.Add(rtbLogs);
			Controls.Add(buttonStartServer);
			Name = "ServerForm";
			Text = "InMyTalk Server";
			ResumeLayout(false);
		}

		#endregion

		private Button buttonStartServer;
		private RichTextBox rtbLogs;
	}
}
