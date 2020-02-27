namespace DocumentCleanupDemo
{
   partial class DeskewDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeskewDialog));
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gb1 = new System.Windows.Forms.GroupBox();
         this._lblColor = new System.Windows.Forms.Label();
         this._cbFillExposedArea = new System.Windows.Forms.CheckBox();
         this._gb2 = new System.Windows.Forms.GroupBox();
         this._lblThreshold = new System.Windows.Forms.Label();
         this._label1 = new System.Windows.Forms.Label();
         this._cbThreshold = new System.Windows.Forms.CheckBox();
         this._gb3 = new System.Windows.Forms.GroupBox();
         this._rbHigh = new System.Windows.Forms.RadioButton();
         this._rbMedium = new System.Windows.Forms.RadioButton();
         this._rbLow = new System.Windows.Forms.RadioButton();
         this._gp4 = new System.Windows.Forms.GroupBox();
         this._rbTextImages = new System.Windows.Forms.RadioButton();
         this._rbTextOnly = new System.Windows.Forms.RadioButton();
         this._gb5 = new System.Windows.Forms.GroupBox();
         this._rbFast = new System.Windows.Forms.RadioButton();
         this._rbNormal = new System.Windows.Forms.RadioButton();
         this._gb1.SuspendLayout();
         this._gb2.SuspendLayout();
         this._gb3.SuspendLayout();
         this._gp4.SuspendLayout();
         this._gb5.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(356, 12);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 0;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(356, 41);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 1;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _gb1
         // 
         this._gb1.Controls.Add(this._lblColor);
         this._gb1.Controls.Add(this._cbFillExposedArea);
         this._gb1.Location = new System.Drawing.Point(12, 12);
         this._gb1.Name = "_gb1";
         this._gb1.Size = new System.Drawing.Size(338, 52);
         this._gb1.TabIndex = 2;
         this._gb1.TabStop = false;
         this._gb1.Text = "Fill";
         // 
         // _lblColor
         // 
         this._lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblColor.Enabled = false;
         this._lblColor.Location = new System.Drawing.Point(134, 16);
         this._lblColor.Name = "_lblColor";
         this._lblColor.Size = new System.Drawing.Size(100, 23);
         this._lblColor.TabIndex = 1;
         this._lblColor.Click += new System.EventHandler(this.lblColor_Click);
         // 
         // _cbFillExposedArea
         // 
         this._cbFillExposedArea.AutoSize = true;
         this._cbFillExposedArea.Location = new System.Drawing.Point(21, 19);
         this._cbFillExposedArea.Name = "_cbFillExposedArea";
         this._cbFillExposedArea.Size = new System.Drawing.Size(107, 17);
         this._cbFillExposedArea.TabIndex = 0;
         this._cbFillExposedArea.Text = "Fill Exposed Area";
         this._cbFillExposedArea.UseVisualStyleBackColor = true;
         this._cbFillExposedArea.CheckedChanged += new System.EventHandler(this._cbFillExposedArea_CheckedChanged);
         // 
         // _gb2
         // 
         this._gb2.Controls.Add(this._lblThreshold);
         this._gb2.Controls.Add(this._label1);
         this._gb2.Controls.Add(this._cbThreshold);
         this._gb2.Location = new System.Drawing.Point(12, 70);
         this._gb2.Name = "_gb2";
         this._gb2.Size = new System.Drawing.Size(338, 58);
         this._gb2.TabIndex = 3;
         this._gb2.TabStop = false;
         this._gb2.Text = "Threshold";
         // 
         // _lblThreshold
         // 
         this._lblThreshold.Location = new System.Drawing.Point(42, 20);
         this._lblThreshold.Name = "_lblThreshold";
         this._lblThreshold.Size = new System.Drawing.Size(288, 35);
         this._lblThreshold.TabIndex = 2;
         this._lblThreshold.Text = "Do not deskew the image if the deskew angle is very small (less than 0.5 degrees)" +
             ". ";
         // 
         // _label1
         // 
         this._label1.Location = new System.Drawing.Point(42, 19);
         this._label1.MaximumSize = new System.Drawing.Size(0, 50);
         this._label1.Name = "_label1";
         this._label1.Size = new System.Drawing.Size(0, 36);
         this._label1.TabIndex = 1;
         this._label1.Text = "Do not deskew the image if the deskew angle is very small (less than 0.5 degrees)" +
             ". ";
         // 
         // _cbThreshold
         // 
         this._cbThreshold.AutoSize = true;
         this._cbThreshold.Location = new System.Drawing.Point(21, 19);
         this._cbThreshold.Name = "_cbThreshold";
         this._cbThreshold.Size = new System.Drawing.Size(15, 14);
         this._cbThreshold.TabIndex = 0;
         this._cbThreshold.UseVisualStyleBackColor = true;
         // 
         // _gb3
         // 
         this._gb3.Controls.Add(this._rbHigh);
         this._gb3.Controls.Add(this._rbMedium);
         this._gb3.Controls.Add(this._rbLow);
         this._gb3.Location = new System.Drawing.Point(12, 134);
         this._gb3.Name = "_gb3";
         this._gb3.Size = new System.Drawing.Size(338, 70);
         this._gb3.TabIndex = 3;
         this._gb3.TabStop = false;
         this._gb3.Text = "Quality";
         // 
         // _rbHigh
         // 
         this._rbHigh.AutoSize = true;
         this._rbHigh.Location = new System.Drawing.Point(149, 19);
         this._rbHigh.Name = "_rbHigh";
         this._rbHigh.Size = new System.Drawing.Size(47, 17);
         this._rbHigh.TabIndex = 2;
         this._rbHigh.TabStop = true;
         this._rbHigh.Text = "High";
         this._rbHigh.UseVisualStyleBackColor = true;
         // 
         // _rbMedium
         // 
         this._rbMedium.AutoSize = true;
         this._rbMedium.Location = new System.Drawing.Point(21, 42);
         this._rbMedium.Name = "_rbMedium";
         this._rbMedium.Size = new System.Drawing.Size(62, 17);
         this._rbMedium.TabIndex = 1;
         this._rbMedium.TabStop = true;
         this._rbMedium.Text = "Medium";
         this._rbMedium.UseVisualStyleBackColor = true;
         // 
         // _rbLow
         // 
         this._rbLow.AutoSize = true;
         this._rbLow.Location = new System.Drawing.Point(21, 19);
         this._rbLow.Name = "_rbLow";
         this._rbLow.Size = new System.Drawing.Size(45, 17);
         this._rbLow.TabIndex = 0;
         this._rbLow.TabStop = true;
         this._rbLow.Text = "Low";
         this._rbLow.UseVisualStyleBackColor = true;
         // 
         // _gp4
         // 
         this._gp4.Controls.Add(this._rbTextImages);
         this._gp4.Controls.Add(this._rbTextOnly);
         this._gp4.Location = new System.Drawing.Point(12, 210);
         this._gp4.Name = "_gp4";
         this._gp4.Size = new System.Drawing.Size(338, 56);
         this._gp4.TabIndex = 3;
         this._gp4.TabStop = false;
         this._gp4.Text = "Type";
         // 
         // _rbTextImages
         // 
         this._rbTextImages.AutoSize = true;
         this._rbTextImages.Location = new System.Drawing.Point(149, 19);
         this._rbTextImages.Name = "_rbTextImages";
         this._rbTextImages.Size = new System.Drawing.Size(104, 17);
         this._rbTextImages.TabIndex = 1;
         this._rbTextImages.TabStop = true;
         this._rbTextImages.Text = "Text and Images";
         this._rbTextImages.UseVisualStyleBackColor = true;
         // 
         // _rbTextOnly
         // 
         this._rbTextOnly.AutoSize = true;
         this._rbTextOnly.Location = new System.Drawing.Point(21, 19);
         this._rbTextOnly.Name = "_rbTextOnly";
         this._rbTextOnly.Size = new System.Drawing.Size(70, 17);
         this._rbTextOnly.TabIndex = 0;
         this._rbTextOnly.TabStop = true;
         this._rbTextOnly.Text = "Text Only";
         this._rbTextOnly.UseVisualStyleBackColor = true;
         // 
         // _gb5
         // 
         this._gb5.Controls.Add(this._rbFast);
         this._gb5.Controls.Add(this._rbNormal);
         this._gb5.Location = new System.Drawing.Point(12, 272);
         this._gb5.Name = "_gb5";
         this._gb5.Size = new System.Drawing.Size(338, 56);
         this._gb5.TabIndex = 4;
         this._gb5.TabStop = false;
         this._gb5.Text = "Speed";
         // 
         // _rbFast
         // 
         this._rbFast.AutoSize = true;
         this._rbFast.Location = new System.Drawing.Point(149, 19);
         this._rbFast.Name = "_rbFast";
         this._rbFast.Size = new System.Drawing.Size(181, 17);
         this._rbFast.TabIndex = 1;
         this._rbFast.TabStop = true;
         this._rbFast.Text = "Fast (Intended for 1 bits per pixel)";
         this._rbFast.UseVisualStyleBackColor = true;
         // 
         // _rbNormal
         // 
         this._rbNormal.AutoSize = true;
         this._rbNormal.Location = new System.Drawing.Point(21, 19);
         this._rbNormal.Name = "_rbNormal";
         this._rbNormal.Size = new System.Drawing.Size(123, 17);
         this._rbNormal.TabIndex = 0;
         this._rbNormal.TabStop = true;
         this._rbNormal.Text = "Normal (Best Quality)";
         this._rbNormal.UseVisualStyleBackColor = true;
         // 
         // DeskewDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(440, 346);
         this.Controls.Add(this._gb5);
         this.Controls.Add(this._gb2);
         this.Controls.Add(this._gb3);
         this.Controls.Add(this._gp4);
         this.Controls.Add(this._gb1);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DeskewDialog";
         this.Text = "Deskew";
         this._gb1.ResumeLayout(false);
         this._gb1.PerformLayout();
         this._gb2.ResumeLayout(false);
         this._gb2.PerformLayout();
         this._gb3.ResumeLayout(false);
         this._gb3.PerformLayout();
         this._gp4.ResumeLayout(false);
         this._gp4.PerformLayout();
         this._gb5.ResumeLayout(false);
         this._gb5.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _gb1;
      private System.Windows.Forms.CheckBox _cbFillExposedArea;
      private System.Windows.Forms.GroupBox _gb2;
      private System.Windows.Forms.GroupBox _gb3;
      private System.Windows.Forms.GroupBox _gp4;
      private System.Windows.Forms.Label _lblColor;
      private System.Windows.Forms.Label _label1;
      private System.Windows.Forms.CheckBox _cbThreshold;
      private System.Windows.Forms.RadioButton _rbHigh;
      private System.Windows.Forms.RadioButton _rbMedium;
      private System.Windows.Forms.RadioButton _rbLow;
      private System.Windows.Forms.RadioButton _rbTextImages;
      private System.Windows.Forms.RadioButton _rbTextOnly;
      private System.Windows.Forms.GroupBox _gb5;
      private System.Windows.Forms.RadioButton _rbFast;
      private System.Windows.Forms.RadioButton _rbNormal;
      private System.Windows.Forms.Label _lblThreshold;
   }
}