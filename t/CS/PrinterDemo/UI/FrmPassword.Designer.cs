namespace PrinterDemo
{
   partial class FrmPassword
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPassword));
         this._lblPassword = new System.Windows.Forms.Label();
         this._txtBoxPassword = new System.Windows.Forms.TextBox();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lblPassword
         // 
         this._lblPassword.AutoSize = true;
         this._lblPassword.Location = new System.Drawing.Point(3, 22);
         this._lblPassword.Name = "_lblPassword";
         this._lblPassword.Size = new System.Drawing.Size(81, 13);
         this._lblPassword.TabIndex = 0;
         this._lblPassword.Text = "Enter Password";
         // 
         // _txtBoxPassword
         // 
         this._txtBoxPassword.Location = new System.Drawing.Point(91, 19);
         this._txtBoxPassword.Name = "_txtBoxPassword";
         this._txtBoxPassword.PasswordChar = '*';
         this._txtBoxPassword.Size = new System.Drawing.Size(205, 20);
         this._txtBoxPassword.TabIndex = 1;
         this._txtBoxPassword.UseSystemPasswordChar = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Location = new System.Drawing.Point(166, 73);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(62, 29);
         this._btnOk.TabIndex = 7;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(234, 73);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(62, 29);
         this._btnCancel.TabIndex = 8;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // FrmPassword
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(308, 105);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._txtBoxPassword);
         this.Controls.Add(this._lblPassword);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmPassword";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Printer Password";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPassword_FormClosing);
         this.Load += new System.EventHandler(this.FrmPassword_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblPassword;
      private System.Windows.Forms.TextBox _txtBoxPassword;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}