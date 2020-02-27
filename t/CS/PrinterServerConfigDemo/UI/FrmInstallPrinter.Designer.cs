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
          this._txtBoxPrinterName = new System.Windows.Forms.TextBox();
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._ckEnableNetwork = new System.Windows.Forms.CheckBox();
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
          // _txtBoxPrinterName
          // 
          this._txtBoxPrinterName.Location = new System.Drawing.Point(115, 17);
          this._txtBoxPrinterName.Name = "_txtBoxPrinterName";
          this._txtBoxPrinterName.Size = new System.Drawing.Size(215, 20);
          this._txtBoxPrinterName.TabIndex = 1;
          this._txtBoxPrinterName.TextChanged += new System.EventHandler(this._txtBoxPrinterName_TextChanged);
          // 
          // _btnOk
          // 
          this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
          this._btnOk.Enabled = false;
          this._btnOk.Location = new System.Drawing.Point(200, 100);
          this._btnOk.Name = "_btnOk";
          this._btnOk.Size = new System.Drawing.Size(62, 29);
          this._btnOk.TabIndex = 5;
          this._btnOk.Text = "Ok";
          this._btnOk.UseVisualStyleBackColor = true;
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnCancel.Location = new System.Drawing.Point(268, 100);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(62, 29);
          this._btnCancel.TabIndex = 6;
          this._btnCancel.Text = "Cancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          // 
          // _ckEnableNetwork
          // 
          this._ckEnableNetwork.AutoSize = true;
          this._ckEnableNetwork.Checked = true;
          this._ckEnableNetwork.CheckState = System.Windows.Forms.CheckState.Checked;
          this._ckEnableNetwork.Enabled = false;
          this._ckEnableNetwork.Location = new System.Drawing.Point(115, 55);
          this._ckEnableNetwork.Name = "_ckEnableNetwork";
          this._ckEnableNetwork.Size = new System.Drawing.Size(140, 17);
          this._ckEnableNetwork.TabIndex = 7;
          this._ckEnableNetwork.Text = "Enable Network Printing";
          this._ckEnableNetwork.UseVisualStyleBackColor = true;
          // 
          // FrmInstallPrinter
          // 
          this.AcceptButton = this._btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.ClientSize = new System.Drawing.Size(341, 134);
          this.Controls.Add(this._ckEnableNetwork);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._txtBoxPrinterName);
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
          this.Load += new System.EventHandler(this.FrmInstallPrinter_Load);
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInstallPrinter_FormClosing);
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblPrinterName;
      private System.Windows.Forms.TextBox _txtBoxPrinterName;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.CheckBox _ckEnableNetwork;
   }
}