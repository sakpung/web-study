namespace ExternalControlSample
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
         this.buttonLogin = new System.Windows.Forms.Button();
         this.groupBoxBrowser = new System.Windows.Forms.GroupBox();
         this.radioButtonChrome = new System.Windows.Forms.RadioButton();
         this.radioButtonFireFox = new System.Windows.Forms.RadioButton();
         this.radioButtonInteretExplorer = new System.Windows.Forms.RadioButton();
         this.textBoxPassword = new System.Windows.Forms.TextBox();
         this.labelPassword = new System.Windows.Forms.Label();
         this.textBoxUser = new System.Windows.Forms.TextBox();
         this.User = new System.Windows.Forms.Label();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.radioButtonEdge = new System.Windows.Forms.RadioButton();
         this.groupBoxBrowser.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonLogin
         // 
         this.buttonLogin.Location = new System.Drawing.Point(109, 245);
         this.buttonLogin.Name = "buttonLogin";
         this.buttonLogin.Size = new System.Drawing.Size(75, 23);
         this.buttonLogin.TabIndex = 5;
         this.buttonLogin.Text = "Login";
         this.buttonLogin.UseVisualStyleBackColor = false;
         this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
         // 
         // groupBoxBrowser
         // 
         this.groupBoxBrowser.Controls.Add(this.radioButtonEdge);
         this.groupBoxBrowser.Controls.Add(this.radioButtonChrome);
         this.groupBoxBrowser.Controls.Add(this.radioButtonFireFox);
         this.groupBoxBrowser.Controls.Add(this.radioButtonInteretExplorer);
         this.groupBoxBrowser.Location = new System.Drawing.Point(15, 115);
         this.groupBoxBrowser.Name = "groupBoxBrowser";
         this.groupBoxBrowser.Size = new System.Drawing.Size(122, 120);
         this.groupBoxBrowser.TabIndex = 4;
         this.groupBoxBrowser.TabStop = false;
         this.groupBoxBrowser.Text = "Browser";
         // 
         // radioButtonChrome
         // 
         this.radioButtonChrome.AutoSize = true;
         this.radioButtonChrome.Location = new System.Drawing.Point(10, 67);
         this.radioButtonChrome.Name = "radioButtonChrome";
         this.radioButtonChrome.Size = new System.Drawing.Size(61, 17);
         this.radioButtonChrome.TabIndex = 2;
         this.radioButtonChrome.TabStop = true;
         this.radioButtonChrome.Text = "Chrome";
         this.radioButtonChrome.UseVisualStyleBackColor = true;
         // 
         // radioButtonFireFox
         // 
         this.radioButtonFireFox.AutoSize = true;
         this.radioButtonFireFox.Location = new System.Drawing.Point(10, 44);
         this.radioButtonFireFox.Name = "radioButtonFireFox";
         this.radioButtonFireFox.Size = new System.Drawing.Size(56, 17);
         this.radioButtonFireFox.TabIndex = 1;
         this.radioButtonFireFox.TabStop = true;
         this.radioButtonFireFox.Text = "Firefox";
         this.radioButtonFireFox.UseVisualStyleBackColor = true;
         // 
         // radioButtonInteretExplorer
         // 
         this.radioButtonInteretExplorer.AutoSize = true;
         this.radioButtonInteretExplorer.Location = new System.Drawing.Point(10, 20);
         this.radioButtonInteretExplorer.Name = "radioButtonInteretExplorer";
         this.radioButtonInteretExplorer.Size = new System.Drawing.Size(102, 17);
         this.radioButtonInteretExplorer.TabIndex = 0;
         this.radioButtonInteretExplorer.TabStop = true;
         this.radioButtonInteretExplorer.Text = "Internet Explorer";
         this.radioButtonInteretExplorer.UseVisualStyleBackColor = true;
         // 
         // textBoxPassword
         // 
         this.textBoxPassword.Location = new System.Drawing.Point(15, 77);
         this.textBoxPassword.Name = "textBoxPassword";
         this.textBoxPassword.Size = new System.Drawing.Size(250, 20);
         this.textBoxPassword.TabIndex = 4;
         this.textBoxPassword.UseSystemPasswordChar = true;
         // 
         // labelPassword
         // 
         this.labelPassword.AutoSize = true;
         this.labelPassword.Location = new System.Drawing.Point(12, 61);
         this.labelPassword.Name = "labelPassword";
         this.labelPassword.Size = new System.Drawing.Size(56, 13);
         this.labelPassword.TabIndex = 2;
         this.labelPassword.Text = "Password:";
         // 
         // textBoxUser
         // 
         this.textBoxUser.Location = new System.Drawing.Point(15, 37);
         this.textBoxUser.Name = "textBoxUser";
         this.textBoxUser.Size = new System.Drawing.Size(250, 20);
         this.textBoxUser.TabIndex = 1;
         // 
         // User
         // 
         this.User.AutoSize = true;
         this.User.Location = new System.Drawing.Point(12, 20);
         this.User.Name = "User";
         this.User.Size = new System.Drawing.Size(58, 13);
         this.User.TabIndex = 0;
         this.User.Text = "Username:";
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(190, 245);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 6;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // radioButtonEdge
         // 
         this.radioButtonEdge.AutoSize = true;
         this.radioButtonEdge.Location = new System.Drawing.Point(10, 90);
         this.radioButtonEdge.Name = "radioButtonEdge";
         this.radioButtonEdge.Size = new System.Drawing.Size(50, 17);
         this.radioButtonEdge.TabIndex = 3;
         this.radioButtonEdge.TabStop = true;
         this.radioButtonEdge.Text = "Edge";
         this.radioButtonEdge.UseVisualStyleBackColor = true;
         // 
         // LoginDialog
         // 
         this.AcceptButton = this.buttonLogin;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(281, 276);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.textBoxPassword);
         this.Controls.Add(this.labelPassword);
         this.Controls.Add(this.textBoxUser);
         this.Controls.Add(this.User);
         this.Controls.Add(this.buttonLogin);
         this.Controls.Add(this.groupBoxBrowser);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoginDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Login";
         this.Shown += new System.EventHandler(this.LoginDialog_Shown);
         this.groupBoxBrowser.ResumeLayout(false);
         this.groupBoxBrowser.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button buttonLogin;
      private System.Windows.Forms.GroupBox groupBoxBrowser;
      private System.Windows.Forms.RadioButton radioButtonChrome;
      private System.Windows.Forms.RadioButton radioButtonFireFox;
      private System.Windows.Forms.RadioButton radioButtonInteretExplorer;
      private System.Windows.Forms.TextBox textBoxPassword;
      private System.Windows.Forms.Label labelPassword;
      private System.Windows.Forms.TextBox textBoxUser;
      private System.Windows.Forms.Label User;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.RadioButton radioButtonEdge;
   }
}