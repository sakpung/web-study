namespace ImageProcessingDemo
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
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _gb1
          // 
          this._gb1.Controls.Add(this._lblColor);
          this._gb1.Controls.Add(this._cbFillExposedArea);
          this._gb1.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gb1, "_gb1");
          this._gb1.Name = "_gb1";
          this._gb1.TabStop = false;
          // 
          // _lblColor
          // 
          this._lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          resources.ApplyResources(this._lblColor, "_lblColor");
          this._lblColor.Name = "_lblColor";
          this._lblColor.Click += new System.EventHandler(this.lblColor_Click);
          // 
          // _cbFillExposedArea
          // 
          resources.ApplyResources(this._cbFillExposedArea, "_cbFillExposedArea");
          this._cbFillExposedArea.Name = "_cbFillExposedArea";
          this._cbFillExposedArea.UseVisualStyleBackColor = true;
          this._cbFillExposedArea.CheckedChanged += new System.EventHandler(this._cbFillExposedArea_CheckedChanged);
          // 
          // _gb2
          // 
          this._gb2.Controls.Add(this._lblThreshold);
          this._gb2.Controls.Add(this._label1);
          this._gb2.Controls.Add(this._cbThreshold);
          this._gb2.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gb2, "_gb2");
          this._gb2.Name = "_gb2";
          this._gb2.TabStop = false;
          // 
          // _lblThreshold
          // 
          this._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblThreshold, "_lblThreshold");
          this._lblThreshold.Name = "_lblThreshold";
          // 
          // _label1
          // 
          resources.ApplyResources(this._label1, "_label1");
          this._label1.MaximumSize = new System.Drawing.Size(0, 50);
          this._label1.Name = "_label1";
          // 
          // _cbThreshold
          // 
          resources.ApplyResources(this._cbThreshold, "_cbThreshold");
          this._cbThreshold.Name = "_cbThreshold";
          this._cbThreshold.UseVisualStyleBackColor = true;
          // 
          // _gb3
          // 
          this._gb3.Controls.Add(this._rbHigh);
          this._gb3.Controls.Add(this._rbMedium);
          this._gb3.Controls.Add(this._rbLow);
          this._gb3.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gb3, "_gb3");
          this._gb3.Name = "_gb3";
          this._gb3.TabStop = false;
          // 
          // _rbHigh
          // 
          resources.ApplyResources(this._rbHigh, "_rbHigh");
          this._rbHigh.Name = "_rbHigh";
          this._rbHigh.TabStop = true;
          this._rbHigh.UseVisualStyleBackColor = true;
          // 
          // _rbMedium
          // 
          resources.ApplyResources(this._rbMedium, "_rbMedium");
          this._rbMedium.Name = "_rbMedium";
          this._rbMedium.TabStop = true;
          this._rbMedium.UseVisualStyleBackColor = true;
          // 
          // _rbLow
          // 
          resources.ApplyResources(this._rbLow, "_rbLow");
          this._rbLow.Name = "_rbLow";
          this._rbLow.TabStop = true;
          this._rbLow.UseVisualStyleBackColor = true;
          // 
          // _gp4
          // 
          this._gp4.Controls.Add(this._rbTextImages);
          this._gp4.Controls.Add(this._rbTextOnly);
          this._gp4.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gp4, "_gp4");
          this._gp4.Name = "_gp4";
          this._gp4.TabStop = false;
          // 
          // _rbTextImages
          // 
          resources.ApplyResources(this._rbTextImages, "_rbTextImages");
          this._rbTextImages.Name = "_rbTextImages";
          this._rbTextImages.TabStop = true;
          this._rbTextImages.UseVisualStyleBackColor = true;
          // 
          // _rbTextOnly
          // 
          resources.ApplyResources(this._rbTextOnly, "_rbTextOnly");
          this._rbTextOnly.Name = "_rbTextOnly";
          this._rbTextOnly.TabStop = true;
          this._rbTextOnly.UseVisualStyleBackColor = true;
          // 
          // _gb5
          // 
          this._gb5.Controls.Add(this._rbFast);
          this._gb5.Controls.Add(this._rbNormal);
          this._gb5.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gb5, "_gb5");
          this._gb5.Name = "_gb5";
          this._gb5.TabStop = false;
          // 
          // _rbFast
          // 
          resources.ApplyResources(this._rbFast, "_rbFast");
          this._rbFast.Name = "_rbFast";
          this._rbFast.TabStop = true;
          this._rbFast.UseVisualStyleBackColor = true;
          // 
          // _rbNormal
          // 
          resources.ApplyResources(this._rbNormal, "_rbNormal");
          this._rbNormal.Name = "_rbNormal";
          this._rbNormal.TabStop = true;
          this._rbNormal.UseVisualStyleBackColor = true;
          // 
          // DeskewDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._gb5);
          this.Controls.Add(this._gb2);
          this.Controls.Add(this._gb3);
          this.Controls.Add(this._gp4);
          this.Controls.Add(this._gb1);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "DeskewDialog";
          this.ShowIcon = false;
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