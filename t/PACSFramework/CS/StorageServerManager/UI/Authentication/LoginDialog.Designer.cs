namespace Leadtools.Demos.StorageServer.UI.Authentication
{
   partial class LoginDialog
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
         this.pictureBoxLock = new System.Windows.Forms.PictureBox();
         this.button1 = new System.Windows.Forms.Button();
         this.buttonLogin = new System.Windows.Forms.Button();
         this.labelInfo = new System.Windows.Forms.Label();
         this.panelUsernamePassword = new System.Windows.Forms.Panel();
         this.textBoxPassword = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.textBoxUserName = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.panelCacCard = new System.Windows.Forms.Panel();
         this.buttonRefresh = new System.Windows.Forms.Button();
         this.comboBoxCacCard = new System.Windows.Forms.ComboBox();
         this.textBoxCacPin = new System.Windows.Forms.TextBox();
         this.labelPinNumber = new System.Windows.Forms.Label();
         this.labelSelectCard = new System.Windows.Forms.Label();
         this.checkBoxCardReader = new System.Windows.Forms.CheckBox();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLock)).BeginInit();
         this.panelUsernamePassword.SuspendLayout();
         this.panelCacCard.SuspendLayout();
         this.SuspendLayout();
         // 
         // pictureBoxLock
         // 
         this.pictureBoxLock.Image = global::Leadtools.Demos.StorageServer.Properties.Resources.Login;
         this.pictureBoxLock.Location = new System.Drawing.Point(13, 13);
         this.pictureBoxLock.Name = "pictureBoxLock";
         this.pictureBoxLock.Size = new System.Drawing.Size(105, 141);
         this.pictureBoxLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
         this.pictureBoxLock.TabIndex = 0;
         this.pictureBoxLock.TabStop = false;
         this.pictureBoxLock.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button1.Location = new System.Drawing.Point(310, 137);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 5;
         this.button1.Text = "Cancel";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // buttonLogin
         // 
         this.buttonLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonLogin.Enabled = false;
         this.buttonLogin.Location = new System.Drawing.Point(229, 137);
         this.buttonLogin.Name = "buttonLogin";
         this.buttonLogin.Size = new System.Drawing.Size(75, 23);
         this.buttonLogin.TabIndex = 4;
         this.buttonLogin.Text = "Login";
         this.buttonLogin.UseVisualStyleBackColor = true;
         this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
         // 
         // labelInfo
         // 
         this.labelInfo.ForeColor = System.Drawing.Color.Red;
         this.labelInfo.Location = new System.Drawing.Point(125, 13);
         this.labelInfo.Name = "labelInfo";
         this.labelInfo.Size = new System.Drawing.Size(229, 23);
         this.labelInfo.TabIndex = 1;
         this.labelInfo.Text = "labelInfo";
         this.labelInfo.Visible = false;
         // 
         // panelUsernamePassword
         // 
         this.panelUsernamePassword.Controls.Add(this.textBoxPassword);
         this.panelUsernamePassword.Controls.Add(this.label2);
         this.panelUsernamePassword.Controls.Add(this.textBoxUserName);
         this.panelUsernamePassword.Controls.Add(this.label1);
         this.panelUsernamePassword.Location = new System.Drawing.Point(118, 33);
         this.panelUsernamePassword.Name = "panelUsernamePassword";
         this.panelUsernamePassword.Size = new System.Drawing.Size(276, 102);
         this.panelUsernamePassword.TabIndex = 2;
         // 
         // textBoxPassword
         // 
         this.textBoxPassword.Location = new System.Drawing.Point(9, 67);
         this.textBoxPassword.Name = "textBoxPassword";
         this.textBoxPassword.Size = new System.Drawing.Size(257, 20);
         this.textBoxPassword.TabIndex = 8;
         this.textBoxPassword.UseSystemPasswordChar = true;
         this.textBoxPassword.TextChanged += new System.EventHandler(this.Credentials_Changed);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(6, 48);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(56, 13);
         this.label2.TabIndex = 7;
         this.label2.Text = "Password:";
         // 
         // textBoxUserName
         // 
         this.textBoxUserName.Location = new System.Drawing.Point(9, 22);
         this.textBoxUserName.Name = "textBoxUserName";
         this.textBoxUserName.Size = new System.Drawing.Size(257, 20);
         this.textBoxUserName.TabIndex = 6;
         this.textBoxUserName.TextChanged += new System.EventHandler(this.Credentials_Changed);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 3);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(58, 13);
         this.label1.TabIndex = 5;
         this.label1.Text = "Username:";
         // 
         // panelCacCard
         // 
         this.panelCacCard.Controls.Add(this.buttonRefresh);
         this.panelCacCard.Controls.Add(this.comboBoxCacCard);
         this.panelCacCard.Controls.Add(this.textBoxCacPin);
         this.panelCacCard.Controls.Add(this.labelPinNumber);
         this.panelCacCard.Controls.Add(this.labelSelectCard);
         this.panelCacCard.Location = new System.Drawing.Point(118, 33);
         this.panelCacCard.Name = "panelCacCard";
         this.panelCacCard.Size = new System.Drawing.Size(276, 102);
         this.panelCacCard.TabIndex = 3;
         // 
         // buttonRefresh
         // 
         this.buttonRefresh.Image = global::Leadtools.Demos.StorageServer.Properties.Resources.reload_icon;
         this.buttonRefresh.Location = new System.Drawing.Point(245, 21);
         this.buttonRefresh.Name = "buttonRefresh";
         this.buttonRefresh.Size = new System.Drawing.Size(22, 22);
         this.buttonRefresh.TabIndex = 2;
         this.buttonRefresh.UseVisualStyleBackColor = true;
         this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
         // 
         // comboBoxCacCard
         // 
         this.comboBoxCacCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxCacCard.FormattingEnabled = true;
         this.comboBoxCacCard.Location = new System.Drawing.Point(9, 22);
         this.comboBoxCacCard.Name = "comboBoxCacCard";
         this.comboBoxCacCard.Size = new System.Drawing.Size(230, 21);
         this.comboBoxCacCard.TabIndex = 1;
         this.comboBoxCacCard.TextChanged += new System.EventHandler(this.Credentials_Changed);
         // 
         // textBoxCacPin
         // 
         this.textBoxCacPin.Location = new System.Drawing.Point(9, 67);
         this.textBoxCacPin.Name = "textBoxCacPin";
         this.textBoxCacPin.Size = new System.Drawing.Size(257, 20);
         this.textBoxCacPin.TabIndex = 4;
         this.textBoxCacPin.UseSystemPasswordChar = true;
         this.textBoxCacPin.TextChanged += new System.EventHandler(this.Credentials_Changed);
         // 
         // labelPinNumber
         // 
         this.labelPinNumber.AutoSize = true;
         this.labelPinNumber.Location = new System.Drawing.Point(6, 48);
         this.labelPinNumber.Name = "labelPinNumber";
         this.labelPinNumber.Size = new System.Drawing.Size(65, 13);
         this.labelPinNumber.TabIndex = 3;
         this.labelPinNumber.Text = "Pin Number:";
         this.labelPinNumber.DoubleClick += new System.EventHandler(this.labelPinNumber_DoubleClick);
         // 
         // labelSelectCard
         // 
         this.labelSelectCard.AutoSize = true;
         this.labelSelectCard.Location = new System.Drawing.Point(6, 4);
         this.labelSelectCard.Name = "labelSelectCard";
         this.labelSelectCard.Size = new System.Drawing.Size(74, 13);
         this.labelSelectCard.TabIndex = 0;
         this.labelSelectCard.Text = "Select a Card:";
         this.labelSelectCard.DoubleClick += new System.EventHandler(this.labelSelectCard_DoubleClick);
         // 
         // checkBoxCardReader
         // 
         this.checkBoxCardReader.AutoSize = true;
         this.checkBoxCardReader.Location = new System.Drawing.Point(33, 143);
         this.checkBoxCardReader.Name = "checkBoxCardReader";
         this.checkBoxCardReader.Size = new System.Drawing.Size(108, 17);
         this.checkBoxCardReader.TabIndex = 0;
         this.checkBoxCardReader.Text = "Use Card Reader";
         this.checkBoxCardReader.UseVisualStyleBackColor = true;
         this.checkBoxCardReader.CheckedChanged += new System.EventHandler(this.checkBoxCardReader_CheckedChanged);
         // 
         // LoginDialog
         // 
         this.AcceptButton = this.buttonLogin;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(396, 171);
         this.Controls.Add(this.checkBoxCardReader);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.panelCacCard);
         this.Controls.Add(this.buttonLogin);
         this.Controls.Add(this.panelUsernamePassword);
         this.Controls.Add(this.labelInfo);
         this.Controls.Add(this.pictureBoxLock);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoginDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Login";
         this.Shown += new System.EventHandler(this.LoginDialog_Shown);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLock)).EndInit();
         this.panelUsernamePassword.ResumeLayout(false);
         this.panelUsernamePassword.PerformLayout();
         this.panelCacCard.ResumeLayout(false);
         this.panelCacCard.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox pictureBoxLock;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button buttonLogin;
      private System.Windows.Forms.Label labelInfo;
      private System.Windows.Forms.Panel panelUsernamePassword;
      private System.Windows.Forms.TextBox textBoxPassword;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textBoxUserName;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel panelCacCard;
      private System.Windows.Forms.TextBox textBoxCacPin;
      private System.Windows.Forms.Label labelPinNumber;
      private System.Windows.Forms.Label labelSelectCard;
      private System.Windows.Forms.ComboBox comboBoxCacCard;
      private System.Windows.Forms.CheckBox checkBoxCardReader;
      private System.Windows.Forms.Button buttonRefresh;
   }
}