namespace PrinterDemo
{
   partial class FrmUninstallPrinter
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUninstallPrinter));
         this._lblPrinterName = new System.Windows.Forms.Label();
         this._cmbPrintersList = new System.Windows.Forms.ComboBox();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lblPrinterName
         // 
         this._lblPrinterName.AutoSize = true;
         this._lblPrinterName.Location = new System.Drawing.Point(3, 29);
         this._lblPrinterName.Name = "_lblPrinterName";
         this._lblPrinterName.Size = new System.Drawing.Size(68, 13);
         this._lblPrinterName.TabIndex = 0;
         this._lblPrinterName.Text = "Printer Name";
         // 
         // _cmbPrintersList
         // 
         this._cmbPrintersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbPrintersList.FormattingEnabled = true;
         this._cmbPrintersList.Location = new System.Drawing.Point(78, 26);
         this._cmbPrintersList.Name = "_cmbPrintersList";
         this._cmbPrintersList.Size = new System.Drawing.Size(202, 21);
         this._cmbPrintersList.TabIndex = 1;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Location = new System.Drawing.Point(150, 78);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(62, 29);
         this._btnOk.TabIndex = 7;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(218, 78);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(62, 29);
         this._btnCancel.TabIndex = 8;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // FrmUninstallPrinter
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(292, 116);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._cmbPrintersList);
         this.Controls.Add(this._lblPrinterName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmUninstallPrinter";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Uninstall Printer";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUninstallPrinter_FormClosing);
         this.Load += new System.EventHandler(this.FrmUninstallPrinter_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblPrinterName;
      private System.Windows.Forms.ComboBox _cmbPrintersList;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}