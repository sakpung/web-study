namespace FusionDemo
{
   partial class AdjustFusionImage
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
         this._btnClose = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._orgImagePalettePreview = new System.Windows.Forms.PictureBox();
         this.label9 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this._cmbOrgImagePalette = new System.Windows.Forms.ComboBox();
         this.label8 = new System.Windows.Forms.Label();
         this._txtScaleY = new FusionDemo.FNumericTextBox();
         this._palettePreview = new System.Windows.Forms.PictureBox();
         this._txtRotate = new FusionDemo.FNumericTextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this._cmbFusedIndex = new System.Windows.Forms.ComboBox();
         this._txtOffsetY = new FusionDemo.FNumericTextBox();
         this._txtOffsetX = new FusionDemo.FNumericTextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this._cmbPalette = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this._txtScaleX = new FusionDemo.FNumericTextBox();
         this._chkFit = new System.Windows.Forms.CheckBox();
         this._txtWLCenter = new FusionDemo.NumericTextBox();
         this._txtWLWidth = new FusionDemo.NumericTextBox();
         this.label1 = new System.Windows.Forms.Label();
         this._btnReset = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._orgImagePalettePreview)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._palettePreview)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnClose.Location = new System.Drawing.Point(250, 366);
         this._btnClose.Name = "_btnClose";
         this._btnClose.Size = new System.Drawing.Size(74, 26);
         this._btnClose.TabIndex = 11;
         this._btnClose.Text = "&Close";
         this._btnClose.UseVisualStyleBackColor = true;
         this._btnClose.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._orgImagePalettePreview);
         this.groupBox1.Controls.Add(this.label9);
         this.groupBox1.Controls.Add(this.label10);
         this.groupBox1.Controls.Add(this._cmbOrgImagePalette);
         this.groupBox1.Controls.Add(this.label8);
         this.groupBox1.Controls.Add(this._txtScaleY);
         this.groupBox1.Controls.Add(this._palettePreview);
         this.groupBox1.Controls.Add(this._txtRotate);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this._cmbFusedIndex);
         this.groupBox1.Controls.Add(this._txtOffsetY);
         this.groupBox1.Controls.Add(this._txtOffsetX);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this._cmbPalette);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this._txtScaleX);
         this.groupBox1.Controls.Add(this._chkFit);
         this.groupBox1.Controls.Add(this._txtWLCenter);
         this.groupBox1.Controls.Add(this._txtWLWidth);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(10, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(314, 352);
         this.groupBox1.TabIndex = 20;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&Fusion Parameters";
         // 
         // _orgImagePalettePreview
         // 
         this._orgImagePalettePreview.Location = new System.Drawing.Point(162, 96);
         this._orgImagePalettePreview.Name = "_orgImagePalettePreview";
         this._orgImagePalettePreview.Size = new System.Drawing.Size(128, 19);
         this._orgImagePalettePreview.TabIndex = 26;
         this._orgImagePalettePreview.TabStop = false;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(65, 98);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(82, 13);
         this.label9.TabIndex = 25;
         this.label9.Text = "Palette Preview";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(106, 65);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(41, 13);
         this.label10.TabIndex = 24;
         this.label10.Text = "Palette";
         // 
         // _cmbOrgImagePalette
         // 
         this._cmbOrgImagePalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbOrgImagePalette.FormattingEnabled = true;
         this._cmbOrgImagePalette.Items.AddRange(new object[] {
            "None",
            "Cool",
            "CyanHot",
            "Fire",
            "ICA2",
            "Ice",
            "OrangeHot ",
            "RainbowRGB",
            "RedHot",
            "Spectrum"});
         this._cmbOrgImagePalette.Location = new System.Drawing.Point(162, 63);
         this._cmbOrgImagePalette.Name = "_cmbOrgImagePalette";
         this._cmbOrgImagePalette.Size = new System.Drawing.Size(129, 21);
         this._cmbOrgImagePalette.TabIndex = 23;
         this._cmbOrgImagePalette.SelectedIndexChanged += new System.EventHandler(this._cmbOrgImagePalette_SelectedIndexChanged);
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(106, 219);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(41, 13);
         this.label8.TabIndex = 22;
         this.label8.Text = "Scale Y";
         // 
         // _txtScaleY
         // 
         this._txtScaleY.Location = new System.Drawing.Point(163, 217);
         this._txtScaleY.MaximumAllowed = 1000F;
         this._txtScaleY.MinimumAllowed = 1F;
         this._txtScaleY.Name = "_txtScaleY";
         this._txtScaleY.Size = new System.Drawing.Size(51, 20);
         this._txtScaleY.TabIndex = 4;
         this._txtScaleY.Text = "1";
         this._txtScaleY.Value = 1F;
         this._txtScaleY.TextChanged += new System.EventHandler(this._txtScale_TextChanged);
         // 
         // _palettePreview
         // 
         this._palettePreview.Location = new System.Drawing.Point(162, 161);
         this._palettePreview.Name = "_palettePreview";
         this._palettePreview.Size = new System.Drawing.Size(128, 19);
         this._palettePreview.TabIndex = 20;
         this._palettePreview.TabStop = false;
         // 
         // _txtRotate
         // 
         this._txtRotate.Location = new System.Drawing.Point(162, 286);
         this._txtRotate.MaximumAllowed = 360F;
         this._txtRotate.MinimumAllowed = -360F;
         this._txtRotate.Name = "_txtRotate";
         this._txtRotate.Size = new System.Drawing.Size(51, 20);
         this._txtRotate.TabIndex = 8;
         this._txtRotate.Text = "1";
         this._txtRotate.Value = 1F;
         this._txtRotate.TextChanged += new System.EventHandler(this._txtRotate_TextChanged);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(73, 288);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(75, 13);
         this.label6.TabIndex = 18;
         this.label6.Text = "Rotate Angle°";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(78, 322);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(69, 13);
         this.label4.TabIndex = 17;
         this.label4.Text = "Fused Image";
         // 
         // _cmbFusedIndex
         // 
         this._cmbFusedIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbFusedIndex.FormattingEnabled = true;
         this._cmbFusedIndex.Location = new System.Drawing.Point(162, 319);
         this._cmbFusedIndex.Name = "_cmbFusedIndex";
         this._cmbFusedIndex.Size = new System.Drawing.Size(129, 21);
         this._cmbFusedIndex.TabIndex = 9;
         this._cmbFusedIndex.SelectedIndexChanged += new System.EventHandler(this._cmbFusedIndex_SelectedIndexChanged);
         // 
         // _txtOffsetY
         // 
         this._txtOffsetY.Location = new System.Drawing.Point(240, 252);
         this._txtOffsetY.MaximumAllowed = 1000F;
         this._txtOffsetY.MinimumAllowed = -1000F;
         this._txtOffsetY.Name = "_txtOffsetY";
         this._txtOffsetY.Size = new System.Drawing.Size(51, 20);
         this._txtOffsetY.TabIndex = 7;
         this._txtOffsetY.Text = "1";
         this._txtOffsetY.Value = 1F;
         this._txtOffsetY.TextChanged += new System.EventHandler(this._txtOffsetY_TextChanged);
         // 
         // _txtOffsetX
         // 
         this._txtOffsetX.Location = new System.Drawing.Point(163, 252);
         this._txtOffsetX.MaximumAllowed = 1000F;
         this._txtOffsetX.MinimumAllowed = -1000F;
         this._txtOffsetX.Name = "_txtOffsetX";
         this._txtOffsetX.Size = new System.Drawing.Size(51, 20);
         this._txtOffsetX.TabIndex = 6;
         this._txtOffsetX.Text = "1";
         this._txtOffsetX.Value = 1F;
         this._txtOffsetX.TextChanged += new System.EventHandler(this._txtOffsetX_TextChanged);
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(110, 253);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(38, 13);
         this.label5.TabIndex = 13;
         this.label5.Text = "Offset";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(3, 161);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(147, 13);
         this.label7.TabIndex = 10;
         this.label7.Text = "Fused Image Palette Preview";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(44, 130);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(106, 13);
         this.label3.TabIndex = 10;
         this.label3.Text = "Fused Image Palette";
         // 
         // _cmbPalette
         // 
         this._cmbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbPalette.FormattingEnabled = true;
         this._cmbPalette.Items.AddRange(new object[] {
            "None",
            "Cool",
            "CyanHot",
            "Fire",
            "ICA2",
            "Ice",
            "OrangeHot ",
            "RainbowRGB",
            "RedHot",
            "Spectrum"});
         this._cmbPalette.Location = new System.Drawing.Point(162, 128);
         this._cmbPalette.Name = "_cmbPalette";
         this._cmbPalette.Size = new System.Drawing.Size(129, 21);
         this._cmbPalette.TabIndex = 2;
         this._cmbPalette.SelectedIndexChanged += new System.EventHandler(this._cmbPalette_SelectedIndexChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(106, 193);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(41, 13);
         this.label2.TabIndex = 8;
         this.label2.Text = "Scale X";
         // 
         // _txtScaleX
         // 
         this._txtScaleX.Location = new System.Drawing.Point(163, 191);
         this._txtScaleX.MaximumAllowed = 1000F;
         this._txtScaleX.MinimumAllowed = 1F;
         this._txtScaleX.Name = "_txtScaleX";
         this._txtScaleX.Size = new System.Drawing.Size(51, 20);
         this._txtScaleX.TabIndex = 3;
         this._txtScaleX.Text = "1";
         this._txtScaleX.Value = 1F;
         this._txtScaleX.TextChanged += new System.EventHandler(this._txtScale_TextChanged);
         // 
         // _chkFit
         // 
         this._chkFit.AutoSize = true;
         this._chkFit.Location = new System.Drawing.Point(220, 205);
         this._chkFit.Name = "_chkFit";
         this._chkFit.Size = new System.Drawing.Size(38, 17);
         this._chkFit.TabIndex = 5;
         this._chkFit.Text = "&Fit";
         this._chkFit.UseVisualStyleBackColor = true;
         this._chkFit.CheckedChanged += new System.EventHandler(this._chkFit_CheckedChanged);
         // 
         // _txtWLCenter
         // 
         this._txtWLCenter.Location = new System.Drawing.Point(240, 28);
         this._txtWLCenter.MaximumAllowed = 65535;
         this._txtWLCenter.MinimumAllowed = -65535;
         this._txtWLCenter.Name = "_txtWLCenter";
         this._txtWLCenter.Size = new System.Drawing.Size(51, 20);
         this._txtWLCenter.TabIndex = 1;
         this._txtWLCenter.Text = "1";
         this._txtWLCenter.Value = 1;
         this._txtWLCenter.TextChanged += new System.EventHandler(this._txtWLCenter_TextChanged);
         // 
         // _txtWLWidth
         // 
         this._txtWLWidth.Location = new System.Drawing.Point(163, 28);
         this._txtWLWidth.MaximumAllowed = 65535;
         this._txtWLWidth.MinimumAllowed = 0;
         this._txtWLWidth.Name = "_txtWLWidth";
         this._txtWLWidth.Size = new System.Drawing.Size(51, 20);
         this._txtWLWidth.TabIndex = 0;
         this._txtWLWidth.Text = "1";
         this._txtWLWidth.Value = 1;
         this._txtWLWidth.TextChanged += new System.EventHandler(this._txtWLWidth_TextChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(77, 30);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(73, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Window Level";
         // 
         // _btnReset
         // 
         this._btnReset.Location = new System.Drawing.Point(10, 366);
         this._btnReset.Name = "_btnReset";
         this._btnReset.Size = new System.Drawing.Size(74, 26);
         this._btnReset.TabIndex = 10;
         this._btnReset.Text = "&Reset";
         this._btnReset.UseVisualStyleBackColor = true;
         this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
         // 
         // AdjustFusionImage
         // 
         this.AcceptButton = this._btnClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(336, 404);
         this.Controls.Add(this._btnReset);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnClose);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AdjustFusionImage";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Fusion Properties";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._orgImagePalettePreview)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._palettePreview)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnClose;
      private System.Windows.Forms.GroupBox groupBox1;
      private NumericTextBox _txtWLCenter;
      private NumericTextBox _txtWLWidth;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox _cmbPalette;
      private System.Windows.Forms.CheckBox _chkFit;
      private FNumericTextBox _txtOffsetY;
      private FNumericTextBox _txtOffsetX;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.ComboBox _cmbFusedIndex;
      private FNumericTextBox _txtRotate;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.PictureBox _palettePreview;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private FNumericTextBox _txtScaleY;
      private System.Windows.Forms.Label label2;
      private FNumericTextBox _txtScaleX;
      private System.Windows.Forms.Button _btnReset;
      private System.Windows.Forms.PictureBox _orgImagePalettePreview;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.ComboBox _cmbOrgImagePalette;
   }
}
