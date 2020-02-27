namespace DicomDemo.Authentication
{
   partial class PasswordDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordDialog));
         this.BottomPanel = new System.Windows.Forms.Panel();
         this.ButtonsGroupBox = new System.Windows.Forms.GroupBox();
         this.CancelDialogButton = new System.Windows.Forms.Button();
         this.OKButton = new System.Windows.Forms.Button();
         this.ContainerPanel = new System.Windows.Forms.Panel();
         this.ConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
         this.passwordTextBox = new System.Windows.Forms.TextBox();
         this.ConfirmPasswordLabel = new System.Windows.Forms.Label();
         this.PasswordLabel = new System.Windows.Forms.Label();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.BottomPanel.SuspendLayout();
         this.ContainerPanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // BottomPanel
         // 
         this.BottomPanel.Controls.Add(this.ButtonsGroupBox);
         this.BottomPanel.Controls.Add(this.CancelDialogButton);
         this.BottomPanel.Controls.Add(this.OKButton);
         this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.BottomPanel.Location = new System.Drawing.Point(0, 72);
         this.BottomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.BottomPanel.Name = "BottomPanel";
         this.BottomPanel.Size = new System.Drawing.Size(412, 37);
         this.BottomPanel.TabIndex = 1;
         // 
         // ButtonsGroupBox
         // 
         this.ButtonsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
         this.ButtonsGroupBox.Location = new System.Drawing.Point(0, 0);
         this.ButtonsGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.ButtonsGroupBox.Name = "ButtonsGroupBox";
         this.ButtonsGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.ButtonsGroupBox.Size = new System.Drawing.Size(412, 10);
         this.ButtonsGroupBox.TabIndex = 0;
         this.ButtonsGroupBox.TabStop = false;
         // 
         // CancelDialogButton
         // 
         this.CancelDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.CancelDialogButton.Location = new System.Drawing.Point(343, 11);
         this.CancelDialogButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.CancelDialogButton.Name = "CancelDialogButton";
         this.CancelDialogButton.Size = new System.Drawing.Size(64, 22);
         this.CancelDialogButton.TabIndex = 2;
         this.CancelDialogButton.Text = "Cancel";
         this.CancelDialogButton.UseVisualStyleBackColor = true;
         // 
         // OKButton
         // 
         this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.OKButton.Location = new System.Drawing.Point(273, 11);
         this.OKButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.OKButton.Name = "OKButton";
         this.OKButton.Size = new System.Drawing.Size(64, 22);
         this.OKButton.TabIndex = 1;
         this.OKButton.Text = "OK";
         this.OKButton.UseVisualStyleBackColor = true;
         // 
         // ContainerPanel
         // 
         this.ContainerPanel.Controls.Add(this.pictureBox1);
         this.ContainerPanel.Controls.Add(this.ConfirmPasswordTextBox);
         this.ContainerPanel.Controls.Add(this.passwordTextBox);
         this.ContainerPanel.Controls.Add(this.ConfirmPasswordLabel);
         this.ContainerPanel.Controls.Add(this.PasswordLabel);
         this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
         this.ContainerPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.ContainerPanel.Name = "ContainerPanel";
         this.ContainerPanel.Size = new System.Drawing.Size(412, 72);
         this.ContainerPanel.TabIndex = 0;
         // 
         // ConfirmPasswordTextBox
         // 
         this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(187, 37);
         this.ConfirmPasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
         this.ConfirmPasswordTextBox.PasswordChar = '*';
         this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(213, 20);
         this.ConfirmPasswordTextBox.TabIndex = 3;
         // 
         // passwordTextBox
         // 
         this.passwordTextBox.Location = new System.Drawing.Point(187, 11);
         this.passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.passwordTextBox.Name = "passwordTextBox";
         this.passwordTextBox.PasswordChar = '*';
         this.passwordTextBox.Size = new System.Drawing.Size(213, 20);
         this.passwordTextBox.TabIndex = 1;
         // 
         // ConfirmPasswordLabel
         // 
         this.ConfirmPasswordLabel.AutoSize = true;
         this.ConfirmPasswordLabel.Location = new System.Drawing.Point(83, 40);
         this.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
         this.ConfirmPasswordLabel.Size = new System.Drawing.Size(94, 13);
         this.ConfirmPasswordLabel.TabIndex = 2;
         this.ConfirmPasswordLabel.Text = "Confirm Password:\r\n";
         // 
         // PasswordLabel
         // 
         this.PasswordLabel.AutoSize = true;
         this.PasswordLabel.Location = new System.Drawing.Point(83, 14);
         this.PasswordLabel.Name = "PasswordLabel";
         this.PasswordLabel.Size = new System.Drawing.Size(56, 13);
         this.PasswordLabel.TabIndex = 0;
         this.PasswordLabel.Text = "Password:";
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
         this.pictureBox1.Location = new System.Drawing.Point(4, 11);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(73, 50);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
         this.pictureBox1.TabIndex = 4;
         this.pictureBox1.TabStop = false;
         // 
         // PasswordDialog
         // 
         this.AcceptButton = this.OKButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.CancelDialogButton;
         this.ClientSize = new System.Drawing.Size(412, 109);
         this.Controls.Add(this.ContainerPanel);
         this.Controls.Add(this.BottomPanel);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PasswordDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "New Password";
         this.BottomPanel.ResumeLayout(false);
         this.ContainerPanel.ResumeLayout(false);
         this.ContainerPanel.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      protected System.Windows.Forms.Panel BottomPanel;
      protected System.Windows.Forms.Button CancelDialogButton;
      protected System.Windows.Forms.Button OKButton;
      protected System.Windows.Forms.GroupBox ButtonsGroupBox;
      protected System.Windows.Forms.Panel ContainerPanel;
      protected System.Windows.Forms.TextBox ConfirmPasswordTextBox;
      protected System.Windows.Forms.TextBox passwordTextBox;
      protected System.Windows.Forms.Label ConfirmPasswordLabel;
      protected System.Windows.Forms.Label PasswordLabel;
      private System.Windows.Forms.PictureBox pictureBox1;



   }
}