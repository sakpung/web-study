namespace PrinterDemo
{
   partial class FrmGetPrinterName
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGetPrinterName));
         this._lblSelectActivePrinter = new System.Windows.Forms.Label();
         this._cmbPrintersList = new System.Windows.Forms.ComboBox();
         this._btnInstallNewPrinter = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lblSelectActivePrinter
         // 
         this._lblSelectActivePrinter.AutoSize = true;
         this._lblSelectActivePrinter.Location = new System.Drawing.Point(19, 9);
         this._lblSelectActivePrinter.Name = "_lblSelectActivePrinter";
         this._lblSelectActivePrinter.Size = new System.Drawing.Size(260, 13);
         this._lblSelectActivePrinter.TabIndex = 0;
         this._lblSelectActivePrinter.Text = "Please choose the active printer, or create a new one";
         // 
         // _cmbPrintersList
         // 
         this._cmbPrintersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbPrintersList.FormattingEnabled = true;
         this._cmbPrintersList.Location = new System.Drawing.Point(22, 37);
         this._cmbPrintersList.Name = "_cmbPrintersList";
         this._cmbPrintersList.Size = new System.Drawing.Size(282, 21);
         this._cmbPrintersList.TabIndex = 1;
         // 
         // _btnInstallNewPrinter
         // 
         this._btnInstallNewPrinter.Location = new System.Drawing.Point(22, 87);
         this._btnInstallNewPrinter.Name = "_btnInstallNewPrinter";
         this._btnInstallNewPrinter.Size = new System.Drawing.Size(282, 40);
         this._btnInstallNewPrinter.TabIndex = 2;
         this._btnInstallNewPrinter.Text = "Install New Printer";
         this._btnInstallNewPrinter.UseVisualStyleBackColor = true;
         this._btnInstallNewPrinter.Click += new System.EventHandler(this._btnInstallNewPrinter_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(242, 149);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(62, 29);
         this._btnCancel.TabIndex = 4;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Location = new System.Drawing.Point(174, 149);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(62, 29);
         this._btnOk.TabIndex = 3;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         // 
         // FrmGetPrinterName
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(326, 181);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnInstallNewPrinter);
         this.Controls.Add(this._cmbPrintersList);
         this.Controls.Add(this._lblSelectActivePrinter);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmGetPrinterName";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Get Printer Name";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGetPrinterName_FormClosed);
         this.Load += new System.EventHandler(this.FrmGetPrinterName_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblSelectActivePrinter;
      private System.Windows.Forms.ComboBox _cmbPrintersList;
      private System.Windows.Forms.Button _btnInstallNewPrinter;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}