namespace ServerPrinterDemo.UI
{
    partial class FrmMain
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
           this._grpNetworkPrinters = new System.Windows.Forms.GroupBox();
           this._lstBoxLog = new System.Windows.Forms.ListBox();
           this._btnCancel = new System.Windows.Forms.Button();
           this._txtPrinterName = new System.Windows.Forms.TextBox();
           this.label1 = new System.Windows.Forms.Label();
           this._btnChange = new System.Windows.Forms.Button();
           this._btnOpen = new System.Windows.Forms.Button();
           this._btnShow = new System.Windows.Forms.Button();
           this._btnClear = new System.Windows.Forms.Button();
           this._btnReadMe = new System.Windows.Forms.Button();
           this._grpNetworkPrinters.SuspendLayout();
           this.SuspendLayout();
           // 
           // _grpNetworkPrinters
           // 
           this._grpNetworkPrinters.Controls.Add(this._lstBoxLog);
           this._grpNetworkPrinters.Location = new System.Drawing.Point(12, 51);
           this._grpNetworkPrinters.Name = "_grpNetworkPrinters";
           this._grpNetworkPrinters.Size = new System.Drawing.Size(460, 374);
           this._grpNetworkPrinters.TabIndex = 6;
           this._grpNetworkPrinters.TabStop = false;
           this._grpNetworkPrinters.Text = "Printer Log";
           // 
           // _lstBoxLog
           // 
           this._lstBoxLog.FormattingEnabled = true;
           this._lstBoxLog.HorizontalScrollbar = true;
           this._lstBoxLog.Location = new System.Drawing.Point(6, 19);
           this._lstBoxLog.Name = "_lstBoxLog";
           this._lstBoxLog.Size = new System.Drawing.Size(448, 342);
           this._lstBoxLog.TabIndex = 9;
           this._lstBoxLog.SelectedIndexChanged += new System.EventHandler(this._lstBoxLog_SelectedIndexChanged);
           // 
           // _btnCancel
           // 
           this._btnCancel.Enabled = false;
           this._btnCancel.Location = new System.Drawing.Point(15, 500);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(457, 23);
           this._btnCancel.TabIndex = 9;
           this._btnCancel.Text = "Cancel Printing";
           this._btnCancel.UseVisualStyleBackColor = true;
           this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
           // 
           // _txtPrinterName
           // 
           this._txtPrinterName.BackColor = System.Drawing.Color.White;
           this._txtPrinterName.Enabled = false;
           this._txtPrinterName.Location = new System.Drawing.Point(91, 12);
           this._txtPrinterName.Name = "_txtPrinterName";
           this._txtPrinterName.Size = new System.Drawing.Size(312, 20);
           this._txtPrinterName.TabIndex = 11;
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(12, 15);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(68, 13);
           this.label1.TabIndex = 10;
           this.label1.Text = "Printer Name";
           // 
           // _btnChange
           // 
           this._btnChange.Location = new System.Drawing.Point(409, 9);
           this._btnChange.Name = "_btnChange";
           this._btnChange.Size = new System.Drawing.Size(63, 23);
           this._btnChange.TabIndex = 12;
           this._btnChange.Text = "Change";
           this._btnChange.UseVisualStyleBackColor = true;
           this._btnChange.Click += new System.EventHandler(this._btnChange_Click);
           // 
           // _btnOpen
           // 
           this._btnOpen.Enabled = false;
           this._btnOpen.Location = new System.Drawing.Point(15, 431);
           this._btnOpen.Name = "_btnOpen";
           this._btnOpen.Size = new System.Drawing.Size(75, 23);
           this._btnOpen.TabIndex = 13;
           this._btnOpen.Text = "Open File";
           this._btnOpen.UseVisualStyleBackColor = true;
           this._btnOpen.Click += new System.EventHandler(this._btnOpen_Click);
           // 
           // _btnShow
           // 
           this._btnShow.Enabled = false;
           this._btnShow.Location = new System.Drawing.Point(96, 431);
           this._btnShow.Name = "_btnShow";
           this._btnShow.Size = new System.Drawing.Size(79, 23);
           this._btnShow.TabIndex = 14;
           this._btnShow.Text = "Show Folder";
           this._btnShow.UseVisualStyleBackColor = true;
           this._btnShow.Click += new System.EventHandler(this._btnShow_Click);
           // 
           // _btnClear
           // 
           this._btnClear.Enabled = false;
           this._btnClear.Location = new System.Drawing.Point(393, 431);
           this._btnClear.Name = "_btnClear";
           this._btnClear.Size = new System.Drawing.Size(79, 23);
           this._btnClear.TabIndex = 15;
           this._btnClear.Text = "Clear Log";
           this._btnClear.UseVisualStyleBackColor = true;
           this._btnClear.Click += new System.EventHandler(this._btnClear_Click);
           // 
           // _btnReadMe
           // 
           this._btnReadMe.Location = new System.Drawing.Point(393, 460);
           this._btnReadMe.Name = "_btnReadMe";
           this._btnReadMe.Size = new System.Drawing.Size(79, 23);
           this._btnReadMe.TabIndex = 16;
           this._btnReadMe.Text = "Read Me";
           this._btnReadMe.UseVisualStyleBackColor = true;
           this._btnReadMe.Click += new System.EventHandler(this._btnReadMe_Click);
           // 
           // FrmMain
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(482, 535);
           this.Controls.Add(this._btnReadMe);
           this.Controls.Add(this._btnClear);
           this.Controls.Add(this._btnShow);
           this.Controls.Add(this._btnOpen);
           this.Controls.Add(this._btnChange);
           this.Controls.Add(this._txtPrinterName);
           this.Controls.Add(this.label1);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this._grpNetworkPrinters);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MaximizeBox = false;
           this.Name = "FrmMain";
           this.Text = "LEADTOOLS Server Printer Demo";
           this.Shown += new System.EventHandler(this.FrmMain_Shown);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
           this._grpNetworkPrinters.ResumeLayout(false);
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _grpNetworkPrinters;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.ListBox _lstBoxLog;
        private System.Windows.Forms.TextBox _txtPrinterName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnChange;
        private System.Windows.Forms.Button _btnOpen;
        private System.Windows.Forms.Button _btnShow;
        private System.Windows.Forms.Button _btnClear;
        private System.Windows.Forms.Button _btnReadMe;
    }
}