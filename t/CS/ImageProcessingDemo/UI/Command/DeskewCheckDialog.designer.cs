namespace ImageProcessingDemo
{
   partial class DeskewCheckDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeskewCheckDialog));
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._gb1 = new System.Windows.Forms.GroupBox();
          this._btnColor = new System.Windows.Forms.Button();
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
          this._gbDeskew = new System.Windows.Forms.GroupBox();
          this._rbReturnAngleOnly = new System.Windows.Forms.RadioButton();
          this._rbDeskewImage = new System.Windows.Forms.RadioButton();
          this._gbalgorithm = new System.Windows.Forms.GroupBox();
          this._rbLineDetectionDeskew = new System.Windows.Forms.RadioButton();
          this._rbBankCheckDeskew = new System.Windows.Forms.RadioButton();
          this._rbOrdinaryDeskew = new System.Windows.Forms.RadioButton();
          this._gb1.SuspendLayout();
          this._gb2.SuspendLayout();
          this._gb3.SuspendLayout();
          this._gp4.SuspendLayout();
          this._gb5.SuspendLayout();
          this._gbDeskew.SuspendLayout();
          this._gbalgorithm.SuspendLayout();
          this.SuspendLayout();
          // 
          // _btnOk
          // 
          this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._btnOk.Location = new System.Drawing.Point(387, 12);
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
          this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._btnCancel.Location = new System.Drawing.Point(387, 41);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(75, 23);
          this._btnCancel.TabIndex = 1;
          this._btnCancel.Text = "Cancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _gb1
          // 
          this._gb1.Controls.Add(this._btnColor);
          this._gb1.Controls.Add(this._lblColor);
          this._gb1.Controls.Add(this._cbFillExposedArea);
          this._gb1.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._gb1.Location = new System.Drawing.Point(10, 80);
          this._gb1.Name = "_gb1";
          this._gb1.Size = new System.Drawing.Size(357, 52);
          this._gb1.TabIndex = 2;
          this._gb1.TabStop = false;
          this._gb1.Text = "Fill";
          // 
          // _btnColor
          // 
          this._btnColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._btnColor.Location = new System.Drawing.Point(235, 17);
          this._btnColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          this._btnColor.Name = "_btnColor";
          this._btnColor.Size = new System.Drawing.Size(21, 21);
          this._btnColor.TabIndex = 7;
          this._btnColor.Text = "...";
          this._btnColor.UseVisualStyleBackColor = true;
          this._btnColor.Click += new System.EventHandler(this._btnColor_Click);
          // 
          // _lblColor
          // 
          this._lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this._lblColor.Enabled = false;
          this._lblColor.Location = new System.Drawing.Point(134, 16);
          this._lblColor.Name = "_lblColor";
          this._lblColor.Size = new System.Drawing.Size(101, 23);
          this._lblColor.TabIndex = 1;
          this._lblColor.Paint += new System.Windows.Forms.PaintEventHandler(this._lblColor_Paint);
          // 
          // _cbFillExposedArea
          // 
          this._cbFillExposedArea.AutoSize = true;
          this._cbFillExposedArea.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._cbFillExposedArea.Location = new System.Drawing.Point(13, 16);
          this._cbFillExposedArea.Name = "_cbFillExposedArea";
          this._cbFillExposedArea.Size = new System.Drawing.Size(113, 18);
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
          this._gb2.Location = new System.Drawing.Point(10, 137);
          this._gb2.Name = "_gb2";
          this._gb2.Size = new System.Drawing.Size(357, 58);
          this._gb2.TabIndex = 3;
          this._gb2.TabStop = false;
          this._gb2.Text = "Threshold";
          // 
          // _lblThreshold
          // 
          this._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblThreshold.Location = new System.Drawing.Point(31, 20);
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
          this._cbThreshold.Location = new System.Drawing.Point(13, 19);
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
          this._gb3.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._gb3.Location = new System.Drawing.Point(10, 202);
          this._gb3.Name = "_gb3";
          this._gb3.Size = new System.Drawing.Size(357, 70);
          this._gb3.TabIndex = 3;
          this._gb3.TabStop = false;
          this._gb3.Text = "Quality";
          // 
          // _rbHigh
          // 
          this._rbHigh.AutoSize = true;
          this._rbHigh.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbHigh.Location = new System.Drawing.Point(149, 19);
          this._rbHigh.Name = "_rbHigh";
          this._rbHigh.Size = new System.Drawing.Size(53, 18);
          this._rbHigh.TabIndex = 2;
          this._rbHigh.TabStop = true;
          this._rbHigh.Text = "High";
          this._rbHigh.UseVisualStyleBackColor = true;
          // 
          // _rbMedium
          // 
          this._rbMedium.AutoSize = true;
          this._rbMedium.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbMedium.Location = new System.Drawing.Point(13, 42);
          this._rbMedium.Name = "_rbMedium";
          this._rbMedium.Size = new System.Drawing.Size(68, 18);
          this._rbMedium.TabIndex = 1;
          this._rbMedium.TabStop = true;
          this._rbMedium.Text = "Medium";
          this._rbMedium.UseVisualStyleBackColor = true;
          // 
          // _rbLow
          // 
          this._rbLow.AutoSize = true;
          this._rbLow.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbLow.Location = new System.Drawing.Point(13, 19);
          this._rbLow.Name = "_rbLow";
          this._rbLow.Size = new System.Drawing.Size(51, 18);
          this._rbLow.TabIndex = 0;
          this._rbLow.TabStop = true;
          this._rbLow.Text = "Low";
          this._rbLow.UseVisualStyleBackColor = true;
          // 
          // _gp4
          // 
          this._gp4.Controls.Add(this._rbTextImages);
          this._gp4.Controls.Add(this._rbTextOnly);
          this._gp4.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._gp4.Location = new System.Drawing.Point(10, 277);
          this._gp4.Name = "_gp4";
          this._gp4.Size = new System.Drawing.Size(357, 56);
          this._gp4.TabIndex = 3;
          this._gp4.TabStop = false;
          this._gp4.Text = "Type";
          // 
          // _rbTextImages
          // 
          this._rbTextImages.AutoSize = true;
          this._rbTextImages.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbTextImages.Location = new System.Drawing.Point(149, 19);
          this._rbTextImages.Name = "_rbTextImages";
          this._rbTextImages.Size = new System.Drawing.Size(110, 18);
          this._rbTextImages.TabIndex = 1;
          this._rbTextImages.TabStop = true;
          this._rbTextImages.Text = "Text and Images";
          this._rbTextImages.UseVisualStyleBackColor = true;
          // 
          // _rbTextOnly
          // 
          this._rbTextOnly.AutoSize = true;
          this._rbTextOnly.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbTextOnly.Location = new System.Drawing.Point(13, 19);
          this._rbTextOnly.Name = "_rbTextOnly";
          this._rbTextOnly.Size = new System.Drawing.Size(76, 18);
          this._rbTextOnly.TabIndex = 0;
          this._rbTextOnly.TabStop = true;
          this._rbTextOnly.Text = "Text Only";
          this._rbTextOnly.UseVisualStyleBackColor = true;
          // 
          // _gb5
          // 
          this._gb5.Controls.Add(this._rbFast);
          this._gb5.Controls.Add(this._rbNormal);
          this._gb5.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._gb5.Location = new System.Drawing.Point(10, 340);
          this._gb5.Name = "_gb5";
          this._gb5.Size = new System.Drawing.Size(357, 56);
          this._gb5.TabIndex = 4;
          this._gb5.TabStop = false;
          this._gb5.Text = "Speed";
          // 
          // _rbFast
          // 
          this._rbFast.AutoSize = true;
          this._rbFast.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbFast.Location = new System.Drawing.Point(149, 20);
          this._rbFast.Name = "_rbFast";
          this._rbFast.Size = new System.Drawing.Size(187, 18);
          this._rbFast.TabIndex = 1;
          this._rbFast.TabStop = true;
          this._rbFast.Text = "Fast (Intended for 1 bits per pixel)";
          this._rbFast.UseVisualStyleBackColor = true;
          // 
          // _rbNormal
          // 
          this._rbNormal.AutoSize = true;
          this._rbNormal.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbNormal.Location = new System.Drawing.Point(13, 20);
          this._rbNormal.Name = "_rbNormal";
          this._rbNormal.Size = new System.Drawing.Size(129, 18);
          this._rbNormal.TabIndex = 0;
          this._rbNormal.TabStop = true;
          this._rbNormal.Text = "Normal (Best Quality)";
          this._rbNormal.UseVisualStyleBackColor = true;
          // 
          // _gbDeskew
          // 
          this._gbDeskew.Controls.Add(this._rbReturnAngleOnly);
          this._gbDeskew.Controls.Add(this._rbDeskewImage);
          this._gbDeskew.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._gbDeskew.Location = new System.Drawing.Point(10, 9);
          this._gbDeskew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          this._gbDeskew.Name = "_gbDeskew";
          this._gbDeskew.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
          this._gbDeskew.Size = new System.Drawing.Size(357, 65);
          this._gbDeskew.TabIndex = 5;
          this._gbDeskew.TabStop = false;
          this._gbDeskew.Text = "Deskew Image";
          // 
          // _rbReturnAngleOnly
          // 
          this._rbReturnAngleOnly.AutoSize = true;
          this._rbReturnAngleOnly.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbReturnAngleOnly.Location = new System.Drawing.Point(13, 38);
          this._rbReturnAngleOnly.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          this._rbReturnAngleOnly.Name = "_rbReturnAngleOnly";
          this._rbReturnAngleOnly.Size = new System.Drawing.Size(226, 18);
          this._rbReturnAngleOnly.TabIndex = 1;
          this._rbReturnAngleOnly.TabStop = true;
          this._rbReturnAngleOnly.Text = "Do not deskew (find the angle of rotation)";
          this._rbReturnAngleOnly.UseVisualStyleBackColor = true;
          // 
          // _rbDeskewImage
          // 
          this._rbDeskewImage.AutoSize = true;
          this._rbDeskewImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbDeskewImage.Location = new System.Drawing.Point(13, 19);
          this._rbDeskewImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          this._rbDeskewImage.Name = "_rbDeskewImage";
          this._rbDeskewImage.Size = new System.Drawing.Size(102, 18);
          this._rbDeskewImage.TabIndex = 0;
          this._rbDeskewImage.TabStop = true;
          this._rbDeskewImage.Text = "Deskew Image";
          this._rbDeskewImage.UseVisualStyleBackColor = true;
          // 
          // _gbalgorithm
          // 
          this._gbalgorithm.Controls.Add(this._rbLineDetectionDeskew);
          this._gbalgorithm.Controls.Add(this._rbBankCheckDeskew);
          this._gbalgorithm.Controls.Add(this._rbOrdinaryDeskew);
          this._gbalgorithm.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._gbalgorithm.Location = new System.Drawing.Point(10, 401);
          this._gbalgorithm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          this._gbalgorithm.Name = "_gbalgorithm";
          this._gbalgorithm.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
          this._gbalgorithm.Size = new System.Drawing.Size(357, 76);
          this._gbalgorithm.TabIndex = 6;
          this._gbalgorithm.TabStop = false;
          this._gbalgorithm.Text = "Deskew Algorithm";
          // 
          // _rbLineDetectionDeskew
          // 
          this._rbLineDetectionDeskew.AutoSize = true;
          this._rbLineDetectionDeskew.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbLineDetectionDeskew.Location = new System.Drawing.Point(13, 46);
          this._rbLineDetectionDeskew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          this._rbLineDetectionDeskew.Name = "_rbLineDetectionDeskew";
          this._rbLineDetectionDeskew.Size = new System.Drawing.Size(138, 18);
          this._rbLineDetectionDeskew.TabIndex = 2;
          this._rbLineDetectionDeskew.TabStop = true;
          this._rbLineDetectionDeskew.Text = "Line detection deskew";
          this._rbLineDetectionDeskew.UseVisualStyleBackColor = true;
          // 
          // _rbBankCheckDeskew
          // 
          this._rbBankCheckDeskew.AutoSize = true;
          this._rbBankCheckDeskew.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbBankCheckDeskew.Location = new System.Drawing.Point(149, 19);
          this._rbBankCheckDeskew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          this._rbBankCheckDeskew.Name = "_rbBankCheckDeskew";
          this._rbBankCheckDeskew.Size = new System.Drawing.Size(129, 18);
          this._rbBankCheckDeskew.TabIndex = 1;
          this._rbBankCheckDeskew.TabStop = true;
          this._rbBankCheckDeskew.Text = "Bank check deskew";
          this._rbBankCheckDeskew.UseVisualStyleBackColor = true;
          // 
          // _rbOrdinaryDeskew
          // 
          this._rbOrdinaryDeskew.AutoSize = true;
          this._rbOrdinaryDeskew.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._rbOrdinaryDeskew.Location = new System.Drawing.Point(13, 19);
          this._rbOrdinaryDeskew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          this._rbOrdinaryDeskew.Name = "_rbOrdinaryDeskew";
          this._rbOrdinaryDeskew.Size = new System.Drawing.Size(110, 18);
          this._rbOrdinaryDeskew.TabIndex = 0;
          this._rbOrdinaryDeskew.TabStop = true;
          this._rbOrdinaryDeskew.Text = "Ordinary deskew";
          this._rbOrdinaryDeskew.UseVisualStyleBackColor = true;
          // 
          // DeskewCheckDialog
          // 
          this.AcceptButton = this._btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.ClientSize = new System.Drawing.Size(470, 487);
          this.Controls.Add(this._gbalgorithm);
          this.Controls.Add(this._gbDeskew);
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
          this.Name = "DeskewCheckDialog";
          this.ShowIcon = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Deskew Check";
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
          this._gbDeskew.ResumeLayout(false);
          this._gbDeskew.PerformLayout();
          this._gbalgorithm.ResumeLayout(false);
          this._gbalgorithm.PerformLayout();
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
      private System.Windows.Forms.Button _btnColor;
      private System.Windows.Forms.GroupBox _gbDeskew;
      private System.Windows.Forms.RadioButton _rbReturnAngleOnly;
      private System.Windows.Forms.RadioButton _rbDeskewImage;
      private System.Windows.Forms.GroupBox _gbalgorithm;
      private System.Windows.Forms.RadioButton _rbLineDetectionDeskew;
      private System.Windows.Forms.RadioButton _rbBankCheckDeskew;
      private System.Windows.Forms.RadioButton _rbOrdinaryDeskew;
   }
}