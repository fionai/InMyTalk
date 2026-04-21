namespace InMyTalk
{
	partial class ClientForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBoxChat = new System.Windows.Forms.ListBox();
			this.textBoxInput = new System.Windows.Forms.TextBox();
			this.buttonSend = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBoxChat
			// 
			this.listBoxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.listBoxChat.FormattingEnabled = true;
			this.listBoxChat.ItemHeight = 26;
			this.listBoxChat.Location = new System.Drawing.Point(16, 80);
			this.listBoxChat.Name = "listBoxChat";
			this.listBoxChat.Size = new System.Drawing.Size(1524, 550);
			this.listBoxChat.TabIndex = 2;
			// 
			// textBoxInput
			// 
			this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.textBoxInput.Location = new System.Drawing.Point(16, 646);
			this.textBoxInput.Multiline = true;
			this.textBoxInput.Name = "textBoxInput";
			this.textBoxInput.Size = new System.Drawing.Size(1524, 93);
			this.textBoxInput.TabIndex = 0;
			// 
			// buttonSend
			// 
			this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.buttonSend.Location = new System.Drawing.Point(1398, 749);
			this.buttonSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.Size = new System.Drawing.Size(144, 52);
			this.buttonSend.TabIndex = 1;
			this.buttonSend.Text = "Send";
			this.buttonSend.UseVisualStyleBackColor = true;
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1558, 812);
			this.Controls.Add(this.buttonSend);
			this.Controls.Add(this.textBoxInput);
			this.Controls.Add(this.listBoxChat);
			this.Name = "ClientForm";
			this.Text = "LittleChat";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxChat;
		private System.Windows.Forms.TextBox textBoxInput;
		private System.Windows.Forms.Button buttonSend;
	}
}

