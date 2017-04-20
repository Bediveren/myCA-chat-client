namespace ChatClient
{
    partial class FormChatWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChatWindow));
            this.chatTextBox = new System.Windows.Forms.RichTextBox();
            this.chatMessageBox = new System.Windows.Forms.TextBox();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.sendBtn = new System.Windows.Forms.Button();
            this.clientListTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // chatTextBox
            // 
            this.chatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatTextBox.Location = new System.Drawing.Point(160, 10);
            this.chatTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.chatTextBox.Size = new System.Drawing.Size(289, 309);
            this.chatTextBox.TabIndex = 0;
            this.chatTextBox.Text = "";
            this.chatTextBox.TextChanged += new System.EventHandler(this.chatTextBox_TextChanged);
            // 
            // chatMessageBox
            // 
            this.chatMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatMessageBox.Location = new System.Drawing.Point(160, 323);
            this.chatMessageBox.Margin = new System.Windows.Forms.Padding(2);
            this.chatMessageBox.Name = "chatMessageBox";
            this.chatMessageBox.Size = new System.Drawing.Size(289, 20);
            this.chatMessageBox.TabIndex = 1;
            this.chatMessageBox.TextChanged += new System.EventHandler(this.chatMessageBox_TextChanged);
            this.chatMessageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatMessageBox_KeyDown);
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Location = new System.Drawing.Point(9, 10);
            this.disconnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(146, 20);
            this.disconnectBtn.TabIndex = 2;
            this.disconnectBtn.Text = "Disconnect";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            // 
            // sendBtn
            // 
            this.sendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sendBtn.Location = new System.Drawing.Point(9, 323);
            this.sendBtn.Margin = new System.Windows.Forms.Padding(2);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(146, 20);
            this.sendBtn.TabIndex = 3;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // clientListTextBox
            // 
            this.clientListTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clientListTextBox.Location = new System.Drawing.Point(9, 36);
            this.clientListTextBox.Name = "clientListTextBox";
            this.clientListTextBox.ReadOnly = true;
            this.clientListTextBox.Size = new System.Drawing.Size(146, 283);
            this.clientListTextBox.TabIndex = 4;
            this.clientListTextBox.Text = "";
            // 
            // FormChatWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(477, 349);
            this.Controls.Add(this.clientListTextBox);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.chatMessageBox);
            this.Controls.Add(this.chatTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormChatWindow";
            this.Text = "myCA Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChatWindow_FormClosed);
            this.Load += new System.EventHandler(this.FormChatWindow_Load);
            this.Shown += new System.EventHandler(this.FormChatWindow_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox chatTextBox;
        private System.Windows.Forms.TextBox chatMessageBox;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.RichTextBox clientListTextBox;
    }
}