namespace Leadtools.Medical.Winforms
{
   partial class LogInDialog
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
         this.passwordTextBox = new System.Windows.Forms.TextBox();
         this.userNamTextBox = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.panel2 = new System.Windows.Forms.Panel();
         this.lblUserName = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.cancelButton = new System.Windows.Forms.Button();
         this.panel1 = new System.Windows.Forms.Panel();
         this.okButton = new System.Windows.Forms.Button();
         this.panel2.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // passwordTextBox
         // 
         this.passwordTextBox.Location = new System.Drawing.Point(69, 33);
         this.passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.passwordTextBox.Name = "passwordTextBox";
         this.passwordTextBox.PasswordChar = '*';
         this.passwordTextBox.Size = new System.Drawing.Size(213, 20);
         this.passwordTextBox.TabIndex = 3;
         // 
         // userNamTextBox
         // 
         this.userNamTextBox.Location = new System.Drawing.Point(69, 7);
         this.userNamTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.userNamTextBox.Name = "userNamTextBox";
         this.userNamTextBox.Size = new System.Drawing.Size(213, 20);
         this.userNamTextBox.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 36);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(56, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Password:\r\n";
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.passwordTextBox);
         this.panel2.Controls.Add(this.userNamTextBox);
         this.panel2.Controls.Add(this.label2);
         this.panel2.Controls.Add(this.lblUserName);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel2.Location = new System.Drawing.Point(0, 0);
         this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(291, 63);
         this.panel2.TabIndex = 0;
         // 
         // lblUserName
         // 
         this.lblUserName.AutoSize = true;
         this.lblUserName.Location = new System.Drawing.Point(3, 10);
         this.lblUserName.Name = "lblUserName";
         this.lblUserName.Size = new System.Drawing.Size(63, 13);
         this.lblUserName.TabIndex = 0;
         this.lblUserName.Text = "User Name:";
         // 
         // groupBox1
         // 
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox1.Size = new System.Drawing.Size(291, 3);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         // 
         // cancelButton
         // 
         this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cancelButton.Location = new System.Drawing.Point(221, 11);
         this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.cancelButton.Name = "cancelButton";
         this.cancelButton.Size = new System.Drawing.Size(64, 22);
         this.cancelButton.TabIndex = 2;
         this.cancelButton.Text = "Cancel";
         this.cancelButton.UseVisualStyleBackColor = true;
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.groupBox1);
         this.panel1.Controls.Add(this.cancelButton);
         this.panel1.Controls.Add(this.okButton);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 63);
         this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(291, 37);
         this.panel1.TabIndex = 3;
         // 
         // okButton
         // 
         this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.okButton.Location = new System.Drawing.Point(152, 11);
         this.okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.okButton.Name = "okButton";
         this.okButton.Size = new System.Drawing.Size(64, 22);
         this.okButton.TabIndex = 1;
         this.okButton.Text = "OK";
         this.okButton.UseVisualStyleBackColor = true;
         // 
         // LogInDialog
         // 
         this.AcceptButton = this.okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cancelButton;
         this.ClientSize = new System.Drawing.Size(291, 100);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LogInDialog";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Log In";
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TextBox passwordTextBox;
      private System.Windows.Forms.TextBox userNamTextBox;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Label lblUserName;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button cancelButton;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button okButton;
   }
}