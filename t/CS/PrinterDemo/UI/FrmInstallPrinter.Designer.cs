namespace PrinterDemo
{
   partial class FrmInstallPrinter
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInstallPrinter));
         this._lblPrinterName = new System.Windows.Forms.Label();
         this._lblPrinterPassword = new System.Windows.Forms.Label();
         this._txtBoxPrinterName = new System.Windows.Forms.TextBox();
         this._txtBoxPrinterPassword = new System.Windows.Forms.TextBox();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lblPrinterName
         // 
         this._lblPrinterName.AutoSize = true;
         this._lblPrinterName.Location = new System.Drawing.Point(12, 20);
         this._lblPrinterName.Name = "_lblPrinterName";
         this._lblPrinterName.Size = new System.Drawing.Size(68, 13);
         this._lblPrinterName.TabIndex = 0;
         this._lblPrinterName.Text = "Printer Name";
         // 
         // _lblPrinterPassword
         // 
         this._lblPrinterPassword.AutoSize = true;
         this._lblPrinterPassword.Location = new System.Drawing.Point(13, 63);
         this._lblPrinterPassword.Name = "_lblPrinterPassword";
         this._lblPrinterPassword.Size = new System.Drawing.Size(86, 13);
         this._lblPrinterPassword.TabIndex = 2;
         this._lblPrinterPassword.Text = "Printer Password";
         // 
         // _txtBoxPrinterName
         // 
         this._txtBoxPrinterName.Location = new System.Drawing.Point(115, 17);
         this._txtBoxPrinterName.Name = "_txtBoxPrinterName";
         this._txtBoxPrinterName.Size = new System.Drawing.Size(215, 20);
         this._txtBoxPrinterName.TabIndex = 1;
         this._txtBoxPrinterName.TextChanged += new System.EventHandler(this._txtBoxPrinterName_TextChanged);
         // 
         // _txtBoxPrinterPassword
         // 
         this._txtBoxPrinterPassword.Location = new System.Drawing.Point(115, 60);
         this._txtBoxPrinterPassword.Name = "_txtBoxPrinterPassword";
         this._txtBoxPrinterPassword.PasswordChar = '*';
         this._txtBoxPrinterPassword.Size = new System.Drawing.Size(215, 20);
         this._txtBoxPrinterPassword.TabIndex = 3;
         this._txtBoxPrinterPassword.UseSystemPasswordChar = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Enabled = false;
         this._btnOk.Location = new System.Drawing.Point(200, 101);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(62, 29);
         this._btnOk.TabIndex = 5;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(268, 101);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(62, 29);
         this._btnCancel.TabIndex = 6;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // FrmInstallPrinter
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(341, 132);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._txtBoxPrinterPassword);
         this.Controls.Add(this._txtBoxPrinterName);
         this.Controls.Add(this._lblPrinterPassword);
         this.Controls.Add(this._lblPrinterName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmInstallPrinter";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Install Printer";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInstallPrinter_FormClosing);
         this.Load += new System.EventHandler(this.FrmInstallPrinter_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblPrinterName;
      private System.Windows.Forms.Label _lblPrinterPassword;
      private System.Windows.Forms.TextBox _txtBoxPrinterName;
      private System.Windows.Forms.TextBox _txtBoxPrinterPassword;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}