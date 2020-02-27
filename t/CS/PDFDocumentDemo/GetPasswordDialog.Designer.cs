namespace PDFDocumentDemo
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetPasswordDialog));
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this._passwordGroupBox = new System.Windows.Forms.GroupBox();
         this._showCharactersCheckBox = new System.Windows.Forms.CheckBox();
         this._passwordTextBox = new System.Windows.Forms.TextBox();
         this._passwordGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._okButton, "_okButton");
         this._okButton.Name = "_okButton";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._cancelButton, "_cancelButton");
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _passwordGroupBox
         // 
         this._passwordGroupBox.Controls.Add(this._showCharactersCheckBox);
         this._passwordGroupBox.Controls.Add(this._passwordTextBox);
         resources.ApplyResources(this._passwordGroupBox, "_passwordGroupBox");
         this._passwordGroupBox.Name = "_passwordGroupBox";
         this._passwordGroupBox.TabStop = false;
         // 
         // _showCharactersCheckBox
         // 
         resources.ApplyResources(this._showCharactersCheckBox, "_showCharactersCheckBox");
         this._showCharactersCheckBox.Name = "_showCharactersCheckBox";
         this._showCharactersCheckBox.UseVisualStyleBackColor = true;
         this._showCharactersCheckBox.CheckedChanged += new System.EventHandler(this._showCharactersCheckBox_CheckedChanged);
         // 
         // _passwordTextBox
         // 
         resources.ApplyResources(this._passwordTextBox, "_passwordTextBox");
         this._passwordTextBox.Name = "_passwordTextBox";
         // 
         // GetPasswordDialog
         // 
         this.AcceptButton = this._okButton;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.Controls.Add(this._passwordGroupBox);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "GetPasswordDialog";
         this.ShowInTaskbar = false;
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