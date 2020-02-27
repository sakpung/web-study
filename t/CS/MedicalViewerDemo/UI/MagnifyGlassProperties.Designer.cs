namespace MedicalViewerDemo
{
   partial class MagnifyGlassProperties
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
         this._btnApply = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._cmbCrosshair = new System.Windows.Forms.ComboBox();
         this._chk3D = new System.Windows.Forms.CheckBox();
         this._chkElliptical = new System.Windows.Forms.CheckBox();
         this._lblPenColor = new System.Windows.Forms.Label();
         this._btnPenColor = new System.Windows.Forms.Button();
         this._txtBorder = new MedicalViewerDemo.NumericTextBox();
         this._txtZoom = new MedicalViewerDemo.NumericTextBox();
         this._txtHeight = new MedicalViewerDemo.NumericTextBox();
         this._txtWidth = new MedicalViewerDemo.NumericTextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(199, 157);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(69, 29);
         this._btnApply.TabIndex = 17;
         this._btnApply.Text = "App&ly";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(111, 157);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(69, 29);
         this._btnCancel.TabIndex = 16;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(26, 157);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(69, 29);
         this._btnOK.TabIndex = 15;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._cmbCrosshair);
         this.groupBox1.Controls.Add(this._chk3D);
         this.groupBox1.Controls.Add(this._chkElliptical);
         this.groupBox1.Controls.Add(this._lblPenColor);
         this.groupBox1.Controls.Add(this._btnPenColor);
         this.groupBox1.Controls.Add(this._txtBorder);
         this.groupBox1.Controls.Add(this._txtZoom);
         this.groupBox1.Controls.Add(this._txtHeight);
         this.groupBox1.Controls.Add(this._txtWidth);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 5);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(272, 146);
         this.groupBox1.TabIndex = 18;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "P&roperties";
         // 
         // _cmbCrosshair
         // 
         this._cmbCrosshair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbCrosshair.FormattingEnabled = true;
         this._cmbCrosshair.Items.AddRange(new object[] {
            "None",
            "Fine",
            "Invert Pen",
            "Invert Screen"});
         this._cmbCrosshair.Location = new System.Drawing.Point(175, 107);
         this._cmbCrosshair.Name = "_cmbCrosshair";
         this._cmbCrosshair.Size = new System.Drawing.Size(84, 21);
         this._cmbCrosshair.TabIndex = 28;
         // 
         // _chk3D
         // 
         this._chk3D.AutoSize = true;
         this._chk3D.Location = new System.Drawing.Point(119, 86);
         this._chk3D.Name = "_chk3D";
         this._chk3D.Size = new System.Drawing.Size(40, 17);
         this._chk3D.TabIndex = 27;
         this._chk3D.Text = "&3D";
         this._chk3D.UseVisualStyleBackColor = true;
         // 
         // _chkElliptical
         // 
         this._chkElliptical.AutoSize = true;
         this._chkElliptical.Location = new System.Drawing.Point(119, 60);
         this._chkElliptical.Name = "_chkElliptical";
         this._chkElliptical.Size = new System.Drawing.Size(93, 17);
         this._chkElliptical.TabIndex = 26;
         this._chkElliptical.Text = "&Elliptical Glass";
         this._chkElliptical.UseVisualStyleBackColor = true;
         this._chkElliptical.CheckedChanged += new System.EventHandler(this._chkElliptical_CheckedChanged);
         // 
         // _lblPenColor
         // 
         this._lblPenColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblPenColor.Location = new System.Drawing.Point(191, 25);
         this._lblPenColor.Name = "_lblPenColor";
         this._lblPenColor.Size = new System.Drawing.Size(49, 26);
         this._lblPenColor.TabIndex = 25;
         // 
         // _btnPenColor
         // 
         this._btnPenColor.Location = new System.Drawing.Point(119, 25);
         this._btnPenColor.Name = "_btnPenColor";
         this._btnPenColor.Size = new System.Drawing.Size(66, 26);
         this._btnPenColor.TabIndex = 24;
         this._btnPenColor.Text = "&Pen Color";
         this._btnPenColor.UseVisualStyleBackColor = true;
         this._btnPenColor.Click += new System.EventHandler(this._btnPenColor_Click);
         // 
         // _txtBorder
         // 
         this._txtBorder.Location = new System.Drawing.Point(60, 108);
         this._txtBorder.MaximumAllowed = 10;
         this._txtBorder.MinimumAllowed = 1;
         this._txtBorder.Name = "_txtBorder";
         this._txtBorder.Size = new System.Drawing.Size(41, 20);
         this._txtBorder.TabIndex = 23;
         this._txtBorder.Value = 0;
         // 
         // _txtZoom
         // 
         this._txtZoom.Location = new System.Drawing.Point(60, 81);
         this._txtZoom.MaximumAllowed = 1000;
         this._txtZoom.MinimumAllowed = 1;
         this._txtZoom.Name = "_txtZoom";
         this._txtZoom.Size = new System.Drawing.Size(41, 20);
         this._txtZoom.TabIndex = 22;
         this._txtZoom.Value = 0;
         // 
         // _txtHeight
         // 
         this._txtHeight.Location = new System.Drawing.Point(60, 53);
         this._txtHeight.MaximumAllowed = 500;
         this._txtHeight.MinimumAllowed = 1;
         this._txtHeight.Name = "_txtHeight";
         this._txtHeight.Size = new System.Drawing.Size(41, 20);
         this._txtHeight.TabIndex = 21;
         this._txtHeight.Value = 0;
         // 
         // _txtWidth
         // 
         this._txtWidth.Location = new System.Drawing.Point(60, 26);
         this._txtWidth.MaximumAllowed = 500;
         this._txtWidth.MinimumAllowed = 1;
         this._txtWidth.Name = "_txtWidth";
         this._txtWidth.Size = new System.Drawing.Size(41, 20);
         this._txtWidth.TabIndex = 20;
         this._txtWidth.Value = 0;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(116, 110);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(53, 13);
         this.label5.TabIndex = 19;
         this.label5.Text = "Corss &hair";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(11, 111);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(38, 13);
         this.label4.TabIndex = 18;
         this.label4.Text = "&Border";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(11, 84);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(34, 13);
         this.label3.TabIndex = 17;
         this.label3.Text = "&Zoom";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(11, 56);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(38, 13);
         this.label2.TabIndex = 16;
         this.label2.Text = "&Height";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(11, 26);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(35, 13);
         this.label1.TabIndex = 15;
         this.label1.Text = "&Width";
         // 
         // MagnifyGlassProperties
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(294, 195);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MagnifyGlassProperties";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Magnify Glass Properties";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox _cmbCrosshair;
      private System.Windows.Forms.CheckBox _chk3D;
      private System.Windows.Forms.CheckBox _chkElliptical;
      private System.Windows.Forms.Label _lblPenColor;
      private System.Windows.Forms.Button _btnPenColor;
      private NumericTextBox _txtBorder;
      private NumericTextBox _txtZoom;
      private NumericTextBox _txtHeight;
      private NumericTextBox _txtWidth;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
   }
}