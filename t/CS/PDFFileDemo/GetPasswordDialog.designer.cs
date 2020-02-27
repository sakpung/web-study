namespace PDFFileDemo
{
   partial class GetPasswordDialog
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
         if(disposing && (components != null))
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
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this._passwordGroupBox = new System.Windows.Forms.GroupBox();
         this._passwordTextBox = new System.Windows.Forms.TextBox();
         this._showCharactersCheckBox = new System.Windows.Forms.CheckBox();
         this._passwordGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(326, 27);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 1;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(326, 56);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 2;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _passwordGroupBox
         // 
         this._passwordGroupBox.Controls.Add(this._showCharactersCheckBox);
         this._passwordGroupBox.Controls.Add(this._passwordTextBox);
         this._passwordGroupBox.Location = new System.Drawing.Point(12, 12);
         this._passwordGroupBox.Name = "_passwordGroupBox";
         this._passwordGroupBox.Size = new System.Drawing.Size(300, 86);
         this._passwordGroupBox.TabIndex = 0;
         this._passwordGroupBox.TabStop = false;
         this._passwordGroupBox.Text = "&PDF file is encrypted. Password is required:";
         // 
         // _passwordTextBox
         // 
         this._passwordTextBox.Location = new System.Drawing.Point(27, 30);
         this._passwordTextBox.Name = "_passwordTextBox";
         this._passwordTextBox.PasswordChar = '*';
         this._passwordTextBox.Size = new System.Drawing.Size(241, 20);
         this._passwordTextBox.TabIndex = 0;
         // 
         // _showCharactersCheckBox
         // 
         this._showCharactersCheckBox.AutoSize = true;
         this._showCharactersCheckBox.Location = new System.Drawing.Point(27, 63);
         this._showCharactersCheckBox.Name = "_showCharactersCheckBox";
         this._showCharactersCheckBox.Size = new System.Drawing.Size(106, 17);
         this._showCharactersCheckBox.TabIndex = 1;
         this._showCharactersCheckBox.Text = "&Show characters";
         this._showCharactersCheckBox.UseVisualStyleBackColor = true;
         this._showCharactersCheckBox.CheckedChanged += new System.EventHandler(this._showCharactersCheckBox_CheckedChanged);
         // 
         // GetPasswordDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(413, 115);
         this.Controls.Add(this._passwordGroupBox);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "GetPasswordDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Get Password";
         this._passwordGroupBox.ResumeLayout(false);
         this._passwordGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.GroupBox _passwordGroupBox;
      private System.Windows.Forms.TextBox _passwordTextBox;
      private System.Windows.Forms.CheckBox _showCharactersCheckBox;
   }
}