namespace Ocr2SharePointDemo
{
   partial class SharePointServerSettingsControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._domainTextBox = new System.Windows.Forms.TextBox();
         this._proxyGroupBox = new System.Windows.Forms.GroupBox();
         this._portTextBox = new System.Windows.Forms.TextBox();
         this._hostTextBox = new System.Windows.Forms.TextBox();
         this._portLabel = new System.Windows.Forms.Label();
         this._hostLabel = new System.Windows.Forms.Label();
         this._useProxyCheckBox = new System.Windows.Forms.CheckBox();
         this._userNameTextBox = new System.Windows.Forms.TextBox();
         this._passwordTextBox = new System.Windows.Forms.TextBox();
         this._credentialsGroupBox = new System.Windows.Forms.GroupBox();
         this._domainLabel = new System.Windows.Forms.Label();
         this._passwordLabel = new System.Windows.Forms.Label();
         this._userNameLabel = new System.Windows.Forms.Label();
         this._useCredentialsCheckBox = new System.Windows.Forms.CheckBox();
         this._urlGroupBox = new System.Windows.Forms.GroupBox();
         this._urlExampleLabel = new System.Windows.Forms.Label();
         this._urlTextBox = new System.Windows.Forms.TextBox();
         this._descriptionLabel = new System.Windows.Forms.Label();
         this._connectButton = new System.Windows.Forms.Button();
         this._proxyGroupBox.SuspendLayout();
         this._credentialsGroupBox.SuspendLayout();
         this._urlGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _domainTextBox
         // 
         this._domainTextBox.Location = new System.Drawing.Point(128, 103);
         this._domainTextBox.Name = "_domainTextBox";
         this._domainTextBox.Size = new System.Drawing.Size(100, 20);
         this._domainTextBox.TabIndex = 6;
         // 
         // _proxyGroupBox
         // 
         this._proxyGroupBox.Controls.Add(this._portTextBox);
         this._proxyGroupBox.Controls.Add(this._hostTextBox);
         this._proxyGroupBox.Controls.Add(this._portLabel);
         this._proxyGroupBox.Controls.Add(this._hostLabel);
         this._proxyGroupBox.Controls.Add(this._useProxyCheckBox);
         this._proxyGroupBox.Location = new System.Drawing.Point(365, 47);
         this._proxyGroupBox.Name = "_proxyGroupBox";
         this._proxyGroupBox.Size = new System.Drawing.Size(372, 242);
         this._proxyGroupBox.TabIndex = 3;
         this._proxyGroupBox.TabStop = false;
         this._proxyGroupBox.Text = "Proxy settings";
         // 
         // _portTextBox
         // 
         this._portTextBox.Location = new System.Drawing.Point(128, 77);
         this._portTextBox.Name = "_portTextBox";
         this._portTextBox.Size = new System.Drawing.Size(100, 20);
         this._portTextBox.TabIndex = 5;
         // 
         // _hostTextBox
         // 
         this._hostTextBox.Location = new System.Drawing.Point(128, 51);
         this._hostTextBox.Name = "_hostTextBox";
         this._hostTextBox.Size = new System.Drawing.Size(202, 20);
         this._hostTextBox.TabIndex = 4;
         // 
         // _portLabel
         // 
         this._portLabel.AutoSize = true;
         this._portLabel.Location = new System.Drawing.Point(42, 80);
         this._portLabel.Name = "_portLabel";
         this._portLabel.Size = new System.Drawing.Size(29, 13);
         this._portLabel.TabIndex = 2;
         this._portLabel.Text = "Port:";
         // 
         // _hostLabel
         // 
         this._hostLabel.AutoSize = true;
         this._hostLabel.Location = new System.Drawing.Point(42, 54);
         this._hostLabel.Name = "_hostLabel";
         this._hostLabel.Size = new System.Drawing.Size(32, 13);
         this._hostLabel.TabIndex = 1;
         this._hostLabel.Text = "Host:";
         // 
         // _useProxyCheckBox
         // 
         this._useProxyCheckBox.AutoSize = true;
         this._useProxyCheckBox.Location = new System.Drawing.Point(22, 28);
         this._useProxyCheckBox.Name = "_useProxyCheckBox";
         this._useProxyCheckBox.Size = new System.Drawing.Size(321, 17);
         this._useProxyCheckBox.TabIndex = 0;
         this._useProxyCheckBox.Text = "Use the following proxy settings when connecting to the server";
         this._useProxyCheckBox.UseVisualStyleBackColor = true;
         this._useProxyCheckBox.CheckedChanged += new System.EventHandler(this._useProxyCheckBox_CheckedChanged);
         // 
         // _userNameTextBox
         // 
         this._userNameTextBox.Location = new System.Drawing.Point(128, 51);
         this._userNameTextBox.Name = "_userNameTextBox";
         this._userNameTextBox.Size = new System.Drawing.Size(100, 20);
         this._userNameTextBox.TabIndex = 2;
         // 
         // _passwordTextBox
         // 
         this._passwordTextBox.Location = new System.Drawing.Point(128, 77);
         this._passwordTextBox.Name = "_passwordTextBox";
         this._passwordTextBox.PasswordChar = '*';
         this._passwordTextBox.Size = new System.Drawing.Size(100, 20);
         this._passwordTextBox.TabIndex = 4;
         // 
         // _credentialsGroupBox
         // 
         this._credentialsGroupBox.Controls.Add(this._domainTextBox);
         this._credentialsGroupBox.Controls.Add(this._passwordTextBox);
         this._credentialsGroupBox.Controls.Add(this._userNameTextBox);
         this._credentialsGroupBox.Controls.Add(this._domainLabel);
         this._credentialsGroupBox.Controls.Add(this._passwordLabel);
         this._credentialsGroupBox.Controls.Add(this._userNameLabel);
         this._credentialsGroupBox.Controls.Add(this._useCredentialsCheckBox);
         this._credentialsGroupBox.Location = new System.Drawing.Point(6, 148);
         this._credentialsGroupBox.Name = "_credentialsGroupBox";
         this._credentialsGroupBox.Size = new System.Drawing.Size(353, 141);
         this._credentialsGroupBox.TabIndex = 2;
         this._credentialsGroupBox.TabStop = false;
         this._credentialsGroupBox.Text = "Network credentials to use when connecting to the server:";
         // 
         // _domainLabel
         // 
         this._domainLabel.AutoSize = true;
         this._domainLabel.Location = new System.Drawing.Point(42, 106);
         this._domainLabel.Name = "_domainLabel";
         this._domainLabel.Size = new System.Drawing.Size(46, 13);
         this._domainLabel.TabIndex = 5;
         this._domainLabel.Text = "Domain:";
         // 
         // _passwordLabel
         // 
         this._passwordLabel.AutoSize = true;
         this._passwordLabel.Location = new System.Drawing.Point(42, 80);
         this._passwordLabel.Name = "_passwordLabel";
         this._passwordLabel.Size = new System.Drawing.Size(56, 13);
         this._passwordLabel.TabIndex = 3;
         this._passwordLabel.Text = "Password:";
         // 
         // _userNameLabel
         // 
         this._userNameLabel.AutoSize = true;
         this._userNameLabel.Location = new System.Drawing.Point(42, 54);
         this._userNameLabel.Name = "_userNameLabel";
         this._userNameLabel.Size = new System.Drawing.Size(58, 13);
         this._userNameLabel.TabIndex = 1;
         this._userNameLabel.Text = "Username:";
         // 
         // _useCredentialsCheckBox
         // 
         this._useCredentialsCheckBox.AutoSize = true;
         this._useCredentialsCheckBox.Location = new System.Drawing.Point(22, 28);
         this._useCredentialsCheckBox.Name = "_useCredentialsCheckBox";
         this._useCredentialsCheckBox.Size = new System.Drawing.Size(308, 17);
         this._useCredentialsCheckBox.TabIndex = 0;
         this._useCredentialsCheckBox.Text = "Use the following credentials when connecting to the server";
         this._useCredentialsCheckBox.UseVisualStyleBackColor = true;
         this._useCredentialsCheckBox.CheckedChanged += new System.EventHandler(this._useCredentialsCheckBox_CheckedChanged);
         // 
         // _urlGroupBox
         // 
         this._urlGroupBox.Controls.Add(this._urlExampleLabel);
         this._urlGroupBox.Controls.Add(this._urlTextBox);
         this._urlGroupBox.Location = new System.Drawing.Point(6, 47);
         this._urlGroupBox.Name = "_urlGroupBox";
         this._urlGroupBox.Size = new System.Drawing.Size(353, 79);
         this._urlGroupBox.TabIndex = 1;
         this._urlGroupBox.TabStop = false;
         this._urlGroupBox.Text = "SharePoint server address (Root only):";
         // 
         // _urlExampleLabel
         // 
         this._urlExampleLabel.AutoSize = true;
         this._urlExampleLabel.Location = new System.Drawing.Point(132, 53);
         this._urlExampleLabel.Name = "_urlExampleLabel";
         this._urlExampleLabel.Size = new System.Drawing.Size(177, 13);
         this._urlExampleLabel.TabIndex = 1;
         this._urlExampleLabel.Text = "For example: http://myserver/mysite";
         this._urlExampleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _urlTextBox
         // 
         this._urlTextBox.Location = new System.Drawing.Point(22, 30);
         this._urlTextBox.Name = "_urlTextBox";
         this._urlTextBox.Size = new System.Drawing.Size(308, 20);
         this._urlTextBox.TabIndex = 0;
         this._urlTextBox.TextChanged += new System.EventHandler(this._urlTextBox_TextChanged);
         // 
         // _descriptionLabel
         // 
         this._descriptionLabel.AutoSize = true;
         this._descriptionLabel.Location = new System.Drawing.Point(3, 15);
         this._descriptionLabel.Name = "_descriptionLabel";
         this._descriptionLabel.Size = new System.Drawing.Size(584, 13);
         this._descriptionLabel.TabIndex = 0;
         this._descriptionLabel.Text = "Enter the SharePoint server properties and click \'Connect\'. Only SharePoint " +
             "2010 and later is supported by this demo.";
         // 
         // _connectButton
         // 
         this._connectButton.Location = new System.Drawing.Point(6, 296);
         this._connectButton.Name = "_connectButton";
         this._connectButton.Size = new System.Drawing.Size(75, 23);
         this._connectButton.TabIndex = 4;
         this._connectButton.Text = "&Connect";
         this._connectButton.UseVisualStyleBackColor = true;
         this._connectButton.Click += new System.EventHandler(this._connectButton_Click);
         // 
         // SharePointServerSettingsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._connectButton);
         this.Controls.Add(this._proxyGroupBox);
         this.Controls.Add(this._credentialsGroupBox);
         this.Controls.Add(this._urlGroupBox);
         this.Controls.Add(this._descriptionLabel);
         this.Name = "SharePointServerSettingsControl";
         this.Size = new System.Drawing.Size(740, 330);
         this._proxyGroupBox.ResumeLayout(false);
         this._proxyGroupBox.PerformLayout();
         this._credentialsGroupBox.ResumeLayout(false);
         this._credentialsGroupBox.PerformLayout();
         this._urlGroupBox.ResumeLayout(false);
         this._urlGroupBox.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox _domainTextBox;
      private System.Windows.Forms.GroupBox _proxyGroupBox;
      private System.Windows.Forms.TextBox _portTextBox;
      private System.Windows.Forms.TextBox _hostTextBox;
      private System.Windows.Forms.Label _portLabel;
      private System.Windows.Forms.Label _hostLabel;
      private System.Windows.Forms.CheckBox _useProxyCheckBox;
      private System.Windows.Forms.TextBox _userNameTextBox;
      private System.Windows.Forms.TextBox _passwordTextBox;
      private System.Windows.Forms.GroupBox _credentialsGroupBox;
      private System.Windows.Forms.Label _domainLabel;
      private System.Windows.Forms.Label _passwordLabel;
      private System.Windows.Forms.Label _userNameLabel;
      private System.Windows.Forms.CheckBox _useCredentialsCheckBox;
      private System.Windows.Forms.GroupBox _urlGroupBox;
      private System.Windows.Forms.Label _urlExampleLabel;
      private System.Windows.Forms.TextBox _urlTextBox;
      private System.Windows.Forms.Label _descriptionLabel;
      private System.Windows.Forms.Button _connectButton;
   }
}
