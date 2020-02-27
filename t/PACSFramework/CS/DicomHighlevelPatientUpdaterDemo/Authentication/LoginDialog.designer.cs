namespace DicomDemo.Authentication
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDialog));
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.label1 = new System.Windows.Forms.Label();
         this.textBoxUserName = new System.Windows.Forms.TextBox();
         this.textBoxPassword = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.buttonLogin = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
         this.pictureBox1.Location = new System.Drawing.Point(13, 13);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(105, 141);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
         this.pictureBox1.TabIndex = 0;
         this.pictureBox1.TabStop = false;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(125, 40);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(58, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Username:";
         // 
         // textBoxUserName
         // 
         this.textBoxUserName.Location = new System.Drawing.Point(128, 57);
         this.textBoxUserName.Name = "textBoxUserName";
         this.textBoxUserName.Size = new System.Drawing.Size(226, 20);
         this.textBoxUserName.TabIndex = 2;
         this.textBoxUserName.TextChanged += new System.EventHandler(this.Credentials_Changed);
         // 
         // textBoxPassword
         // 
         this.textBoxPassword.Location = new System.Drawing.Point(128, 97);
         this.textBoxPassword.Name = "textBoxPassword";
         this.textBoxPassword.Size = new System.Drawing.Size(226, 20);
         this.textBoxPassword.TabIndex = 4;
         this.textBoxPassword.UseSystemPasswordChar = true;
         this.textBoxPassword.TextChanged += new System.EventHandler(this.Credentials_Changed);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(125, 80);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(56, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Password:";
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button1.Location = new System.Drawing.Point(278, 134);
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
         this.buttonLogin.Location = new System.Drawing.Point(197, 134);
         this.buttonLogin.Name = "buttonLogin";
         this.buttonLogin.Size = new System.Drawing.Size(75, 23);
         this.buttonLogin.TabIndex = 6;
         this.buttonLogin.Text = "Login";
         this.buttonLogin.UseVisualStyleBackColor = true;
         this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
         // 
         // LoginDialog
         // 
         this.AcceptButton = this.buttonLogin;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(380, 169);
         this.Controls.Add(this.buttonLogin);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.textBoxPassword);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.textBoxUserName);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.pictureBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoginDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Login";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox textBoxUserName;
      private System.Windows.Forms.TextBox textBoxPassword;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button buttonLogin;
   }
}