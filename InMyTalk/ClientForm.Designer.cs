namespace InMyTalk
{
	partial class FormInMyTalk
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
			this.listBoxHistory = new System.Windows.Forms.ListBox();
			this.textBoxInput = new System.Windows.Forms.TextBox();
			this.buttonSend = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBoxHistory
			// 
			this.listBoxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.listBoxHistory.FormattingEnabled = true;
			this.listBoxHistory.ItemHeight = 18;
			this.listBoxHistory.Location = new System.Drawing.Point(11, 52);
			this.listBoxHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.listBoxHistory.Name = "listBoxHistory";
			this.listBoxHistory.Size = new System.Drawing.Size(1017, 364);
			this.listBoxHistory.TabIndex = 2;
			// 
			// textBoxInput
			// 
			this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.textBoxInput.Location = new System.Drawing.Point(11, 420);
			this.textBoxInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.textBoxInput.Multiline = true;
			this.textBoxInput.Name = "textBoxInput";
			this.textBoxInput.Size = new System.Drawing.Size(1017, 62);
			this.textBoxInput.TabIndex = 0;
			// 
			// buttonSend
			// 
			this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.buttonSend.Location = new System.Drawing.Point(932, 487);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.Size = new System.Drawing.Size(96, 34);
			this.buttonSend.TabIndex = 1;
			this.buttonSend.Text = "Send";
			this.buttonSend.UseVisualStyleBackColor = true;
			// 
			// FormInMyTalk
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1039, 528);
			this.Controls.Add(this.buttonSend);
			this.Controls.Add(this.textBoxInput);
			this.Controls.Add(this.listBoxHistory);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FormInMyTalk";
			this.Text = "InMyTalk";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxHistory;
		private System.Windows.Forms.TextBox textBoxInput;
		private System.Windows.Forms.Button buttonSend;
	}
}

