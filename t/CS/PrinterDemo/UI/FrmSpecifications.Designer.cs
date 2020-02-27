namespace PrinterDemo
{
   partial class FrmSpecifications
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpecifications));
         this._grpPaperSize = new System.Windows.Forms.GroupBox();
         this._lblpaperInfo = new System.Windows.Forms.Label();
         this._radioCentimeters = new System.Windows.Forms.RadioButton();
         this._radioInches = new System.Windows.Forms.RadioButton();
         this._txtHeight = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this._txtWidth = new System.Windows.Forms.TextBox();
         this._lblPaperSize = new System.Windows.Forms.Label();
         this._cmbPaperSize = new System.Windows.Forms.ComboBox();
         this._grpOrientation = new System.Windows.Forms.GroupBox();
         this._rdLandscape = new System.Windows.Forms.RadioButton();
         this._rdPortrait = new System.Windows.Forms.RadioButton();
         this._grpMargins = new System.Windows.Forms.GroupBox();
         this._cmbEmulatePrinter = new System.Windows.Forms.ComboBox();
         this._lblEmulatePrinter = new System.Windows.Forms.Label();
         this._grpGraphics = new System.Windows.Forms.GroupBox();
         this._txtCustomQuality = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this._cmbPrintQuality = new System.Windows.Forms.ComboBox();
         this._lblResolution = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnRestoreDefault = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this._grpPaperSize.SuspendLayout();
         this._grpOrientation.SuspendLayout();
         this._grpMargins.SuspendLayout();
         this._grpGraphics.SuspendLayout();
         this.SuspendLayout();
         // 
         // _grpPaperSize
         // 
         this._grpPaperSize.Controls.Add(this._lblpaperInfo);
         this._grpPaperSize.Controls.Add(this._radioCentimeters);
         this._grpPaperSize.Controls.Add(this._radioInches);
         this._grpPaperSize.Controls.Add(this._txtHeight);
         this._grpPaperSize.Controls.Add(this.label1);
         this._grpPaperSize.Controls.Add(this._txtWidth);
         this._grpPaperSize.Controls.Add(this._lblPaperSize);
         this._grpPaperSize.Controls.Add(this._cmbPaperSize);
         this._grpPaperSize.Location = new System.Drawing.Point(4, 3);
         this._grpPaperSize.Name = "_grpPaperSize";
         this._grpPaperSize.Size = new System.Drawing.Size(204, 86);
         this._grpPaperSize.TabIndex = 0;
         this._grpPaperSize.TabStop = false;
         this._grpPaperSize.Text = "Paper Si&ze";
         // 
         // _lblpaperInfo
         // 
         this._lblpaperInfo.AutoSize = true;
         this._lblpaperInfo.Location = new System.Drawing.Point(5, 56);
         this._lblpaperInfo.Name = "_lblpaperInfo";
         this._lblpaperInfo.Size = new System.Drawing.Size(0, 13);
         this._lblpaperInfo.TabIndex = 7;
         // 
         // _radioCentimeters
         // 
         this._radioCentimeters.AutoSize = true;
         this._radioCentimeters.Location = new System.Drawing.Point(85, 97);
         this._radioCentimeters.Name = "_radioCentimeters";
         this._radioCentimeters.Size = new System.Drawing.Size(73, 17);
         this._radioCentimeters.TabIndex = 6;
         this._radioCentimeters.TabStop = true;
         this._radioCentimeters.Text = "Millimeters";
         this._radioCentimeters.UseVisualStyleBackColor = true;
         this._radioCentimeters.Visible = false;
         // 
         // _radioInches
         // 
         this._radioInches.AutoSize = true;
         this._radioInches.Location = new System.Drawing.Point(11, 97);
         this._radioInches.Name = "_radioInches";
         this._radioInches.Size = new System.Drawing.Size(57, 17);
         this._radioInches.TabIndex = 5;
         this._radioInches.TabStop = true;
         this._radioInches.Text = "Inches";
         this._radioInches.UseVisualStyleBackColor = true;
         this._radioInches.Visible = false;
         // 
         // _txtHeight
         // 
         this._txtHeight.Location = new System.Drawing.Point(85, 94);
         this._txtHeight.Name = "_txtHeight";
         this._txtHeight.Size = new System.Drawing.Size(100, 20);
         this._txtHeight.TabIndex = 4;
         this._txtHeight.Visible = false;
         this._txtHeight.Leave += new System.EventHandler(this._txtHeight_Leave);
         this._txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtBox_KeyPress);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(5, 97);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(76, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "Custom Height";
         this.label1.Visible = false;
         // 
         // _txtWidth
         // 
         this._txtWidth.Location = new System.Drawing.Point(87, 94);
         this._txtWidth.Name = "_txtWidth";
         this._txtWidth.Size = new System.Drawing.Size(100, 20);
         this._txtWidth.TabIndex = 2;
         this._txtWidth.Visible = false;
         this._txtWidth.Leave += new System.EventHandler(this._txtWidth_Leave);
         this._txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtBox_KeyPress);
         // 
         // _lblPaperSize
         // 
         this._lblPaperSize.AutoSize = true;
         this._lblPaperSize.Location = new System.Drawing.Point(7, 97);
         this._lblPaperSize.Name = "_lblPaperSize";
         this._lblPaperSize.Size = new System.Drawing.Size(73, 13);
         this._lblPaperSize.TabIndex = 1;
         this._lblPaperSize.Text = "Custom Width";
         this._lblPaperSize.Visible = false;
         // 
         // _cmbPaperSize
         // 
         this._cmbPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbPaperSize.FormattingEnabled = true;
         this._cmbPaperSize.Items.AddRange(new object[] {
            "Letter",
            "Legal",
            "A4",
            "C Sheet",
            "D Sheet",
            "E Sheet",
            "Letter Small",
            "Tabloid",
            "Ledger",
            "Statement",
            "Executive",
            "A3 Sheet",
            "A4 Small Sheet",
            "A5 Sheet",
            "B5 Sheet",
            "Folio",
            "Quarto",
            "Note",
            "#9 Envelope",
            "#10 Envelope",
            "#11 Envelope",
            "#12 Envelope",
            "#14 Envelope",
            "DL Envelope",
            "C5 Envelope",
            "C3 Envelope",
            "C4 Envelope",
            "C6 Envelope",
            "C65 Envelope",
            "B4 Envelope",
            "B5 Envelope",
            "B6 Envelope",
            "Italy Envelope",
            "Envelope Monarch",
            "6 3/4 Envelope",
            "US Std Fanfold",
            "German Std Fanfold",
            "German Legal Fanfold"});
         this._cmbPaperSize.Location = new System.Drawing.Point(8, 18);
         this._cmbPaperSize.Name = "_cmbPaperSize";
         this._cmbPaperSize.Size = new System.Drawing.Size(177, 21);
         this._cmbPaperSize.TabIndex = 0;
         this._cmbPaperSize.SelectedIndexChanged += new System.EventHandler(this._cmbPaperSize_SelectedIndexChanged);
         // 
         // _grpOrientation
         // 
         this._grpOrientation.Controls.Add(this._rdLandscape);
         this._grpOrientation.Controls.Add(this._rdPortrait);
         this._grpOrientation.Location = new System.Drawing.Point(214, 3);
         this._grpOrientation.Name = "_grpOrientation";
         this._grpOrientation.Size = new System.Drawing.Size(152, 86);
         this._grpOrientation.TabIndex = 1;
         this._grpOrientation.TabStop = false;
         this._grpOrientation.Text = "&Orientation";
         // 
         // _rdLandscape
         // 
         this._rdLandscape.AutoSize = true;
         this._rdLandscape.Location = new System.Drawing.Point(6, 56);
         this._rdLandscape.Name = "_rdLandscape";
         this._rdLandscape.Size = new System.Drawing.Size(78, 17);
         this._rdLandscape.TabIndex = 2;
         this._rdLandscape.TabStop = true;
         this._rdLandscape.Text = "&Landscape";
         this._rdLandscape.UseVisualStyleBackColor = true;
         // 
         // _rdPortrait
         // 
         this._rdPortrait.AutoSize = true;
         this._rdPortrait.Location = new System.Drawing.Point(6, 22);
         this._rdPortrait.Name = "_rdPortrait";
         this._rdPortrait.Size = new System.Drawing.Size(58, 17);
         this._rdPortrait.TabIndex = 1;
         this._rdPortrait.TabStop = true;
         this._rdPortrait.Text = "&Portrait";
         this._rdPortrait.UseVisualStyleBackColor = true;
         // 
         // _grpMargins
         // 
         this._grpMargins.Controls.Add(this._cmbEmulatePrinter);
         this._grpMargins.Controls.Add(this._lblEmulatePrinter);
         this._grpMargins.Location = new System.Drawing.Point(4, 95);
         this._grpMargins.Name = "_grpMargins";
         this._grpMargins.Size = new System.Drawing.Size(362, 50);
         this._grpMargins.TabIndex = 2;
         this._grpMargins.TabStop = false;
         this._grpMargins.Text = "&Margins";
         // 
         // _cmbEmulatePrinter
         // 
         this._cmbEmulatePrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbEmulatePrinter.FormattingEnabled = true;
         this._cmbEmulatePrinter.Location = new System.Drawing.Point(119, 18);
         this._cmbEmulatePrinter.Name = "_cmbEmulatePrinter";
         this._cmbEmulatePrinter.Size = new System.Drawing.Size(213, 21);
         this._cmbEmulatePrinter.TabIndex = 3;
         // 
         // _lblEmulatePrinter
         // 
         this._lblEmulatePrinter.AutoSize = true;
         this._lblEmulatePrinter.Location = new System.Drawing.Point(8, 21);
         this._lblEmulatePrinter.Name = "_lblEmulatePrinter";
         this._lblEmulatePrinter.Size = new System.Drawing.Size(81, 13);
         this._lblEmulatePrinter.TabIndex = 2;
         this._lblEmulatePrinter.Text = "&Emulate Printer:";
         // 
         // _grpGraphics
         // 
         this._grpGraphics.Controls.Add(this.label2);
         this._grpGraphics.Controls.Add(this._txtCustomQuality);
         this._grpGraphics.Controls.Add(this.label3);
         this._grpGraphics.Controls.Add(this._cmbPrintQuality);
         this._grpGraphics.Controls.Add(this._lblResolution);
         this._grpGraphics.Location = new System.Drawing.Point(4, 151);
         this._grpGraphics.Name = "_grpGraphics";
         this._grpGraphics.Size = new System.Drawing.Size(362, 79);
         this._grpGraphics.TabIndex = 3;
         this._grpGraphics.TabStop = false;
         this._grpGraphics.Text = "&Graphics";
         // 
         // _txtCustomQuality
         // 
         this._txtCustomQuality.Location = new System.Drawing.Point(119, 46);
         this._txtCustomQuality.Name = "_txtCustomQuality";
         this._txtCustomQuality.Size = new System.Drawing.Size(56, 20);
         this._txtCustomQuality.TabIndex = 5;
         this._txtCustomQuality.Leave += new System.EventHandler(this._txtCustomQuality_Leave);
         this._txtCustomQuality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtBox_KeyPress);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(8, 49);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(95, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Custom Resolution";
         // 
         // _cmbPrintQuality
         // 
         this._cmbPrintQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbPrintQuality.FormattingEnabled = true;
         this._cmbPrintQuality.Items.AddRange(new object[] {
            "Draft (96 DPI)",
            "Low (150 DPI)",
            "Medium (300 DPI)",
            "High (600 DPI)",
            "Custom"});
         this._cmbPrintQuality.Location = new System.Drawing.Point(119, 19);
         this._cmbPrintQuality.Name = "_cmbPrintQuality";
         this._cmbPrintQuality.Size = new System.Drawing.Size(213, 21);
         this._cmbPrintQuality.TabIndex = 4;
         this._cmbPrintQuality.SelectedIndexChanged += new System.EventHandler(this._cmbPrintQuality_SelectedIndexChanged);
         // 
         // _lblResolution
         // 
         this._lblResolution.AutoSize = true;
         this._lblResolution.Location = new System.Drawing.Point(8, 23);
         this._lblResolution.Name = "_lblResolution";
         this._lblResolution.Size = new System.Drawing.Size(63, 13);
         this._lblResolution.TabIndex = 0;
         this._lblResolution.Text = "Print Quality";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(291, 236);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 8;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(210, 236);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 7;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnRestoreDefault
         // 
         this._btnRestoreDefault.Location = new System.Drawing.Point(4, 236);
         this._btnRestoreDefault.Name = "_btnRestoreDefault";
         this._btnRestoreDefault.Size = new System.Drawing.Size(106, 23);
         this._btnRestoreDefault.TabIndex = 6;
         this._btnRestoreDefault.Text = "&Restore Default";
         this._btnRestoreDefault.UseVisualStyleBackColor = true;
         this._btnRestoreDefault.Click += new System.EventHandler(this._btnRestoreDefault_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(178, 50);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(79, 13);
         this.label2.TabIndex = 6;
         this.label2.Text = "(50 - 1600) DPI";
         // 
         // FrmSpecifications
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(371, 266);
         this.Controls.Add(this._btnRestoreDefault);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._grpGraphics);
         this.Controls.Add(this._grpMargins);
         this.Controls.Add(this._grpOrientation);
         this.Controls.Add(this._grpPaperSize);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmSpecifications";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Printer Options";
         this._grpPaperSize.ResumeLayout(false);
         this._grpPaperSize.PerformLayout();
         this._grpOrientation.ResumeLayout(false);
         this._grpOrientation.PerformLayout();
         this._grpMargins.ResumeLayout(false);
         this._grpMargins.PerformLayout();
         this._grpGraphics.ResumeLayout(false);
         this._grpGraphics.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _grpPaperSize;
      private System.Windows.Forms.GroupBox _grpOrientation;
      private System.Windows.Forms.GroupBox _grpMargins;
      private System.Windows.Forms.GroupBox _grpGraphics;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.ComboBox _cmbEmulatePrinter;
      private System.Windows.Forms.Label _lblEmulatePrinter;
      private System.Windows.Forms.ComboBox _cmbPrintQuality;
      private System.Windows.Forms.Label _lblResolution;
      private System.Windows.Forms.Button _btnRestoreDefault;
      private System.Windows.Forms.Label _lblPaperSize;
      private System.Windows.Forms.ComboBox _cmbPaperSize;
      private System.Windows.Forms.RadioButton _rdLandscape;
      private System.Windows.Forms.RadioButton _rdPortrait;
      private System.Windows.Forms.RadioButton _radioCentimeters;
      private System.Windows.Forms.RadioButton _radioInches;
      private System.Windows.Forms.TextBox _txtHeight;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox _txtWidth;
      private System.Windows.Forms.TextBox _txtCustomQuality;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label _lblpaperInfo;
      private System.Windows.Forms.Label label2;
   }
}