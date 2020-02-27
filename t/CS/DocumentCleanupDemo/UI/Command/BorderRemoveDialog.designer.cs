namespace DocumentCleanupDemo
{
   partial class BorderRemoveDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorderRemoveDialog));
          this._gb1 = new System.Windows.Forms.GroupBox();
          this._cbTopBorder = new System.Windows.Forms.CheckBox();
          this._cbBottomBorder = new System.Windows.Forms.CheckBox();
          this._cbRightBorder = new System.Windows.Forms.CheckBox();
          this._cbLeftBorder = new System.Windows.Forms.CheckBox();
          this._btnOK = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._gb2 = new System.Windows.Forms.GroupBox();
          this._lblVariance = new System.Windows.Forms.Label();
          this._lblWhiteNoise = new System.Windows.Forms.Label();
          this._lblBorderPercent = new System.Windows.Forms.Label();
          this._tnVariance = new System.Windows.Forms.TextBox();
          this._tbWhiteNoiseLength = new System.Windows.Forms.TextBox();
          this._bBorderPercent = new System.Windows.Forms.TextBox();
          this._gbFlags = new System.Windows.Forms.GroupBox();
          this._cbUseVariance = new System.Windows.Forms.CheckBox();
          this._cbImageUnchanged = new System.Windows.Forms.CheckBox();
          this._gb1.SuspendLayout();
          this._gb2.SuspendLayout();
          this._gbFlags.SuspendLayout();
          this.SuspendLayout();
          // 
          // _gb1
          // 
          this._gb1.Controls.Add(this._cbTopBorder);
          this._gb1.Controls.Add(this._cbBottomBorder);
          this._gb1.Controls.Add(this._cbRightBorder);
          this._gb1.Controls.Add(this._cbLeftBorder);
          this._gb1.Location = new System.Drawing.Point(140, 12);
          this._gb1.Name = "_gb1";
          this._gb1.Size = new System.Drawing.Size(113, 118);
          this._gb1.TabIndex = 0;
          this._gb1.TabStop = false;
          this._gb1.Text = "Border To Remove";
          // 
          // _cbTopBorder
          // 
          this._cbTopBorder.AutoSize = true;
          this._cbTopBorder.Location = new System.Drawing.Point(11, 66);
          this._cbTopBorder.Name = "_cbTopBorder";
          this._cbTopBorder.Size = new System.Drawing.Size(45, 17);
          this._cbTopBorder.TabIndex = 3;
          this._cbTopBorder.Text = "Top";
          this._cbTopBorder.UseVisualStyleBackColor = true;
          // 
          // _cbBottomBorder
          // 
          this._cbBottomBorder.AutoSize = true;
          this._cbBottomBorder.Location = new System.Drawing.Point(11, 89);
          this._cbBottomBorder.Name = "_cbBottomBorder";
          this._cbBottomBorder.Size = new System.Drawing.Size(59, 17);
          this._cbBottomBorder.TabIndex = 2;
          this._cbBottomBorder.Text = "Bottom";
          this._cbBottomBorder.UseVisualStyleBackColor = true;
          // 
          // _cbRightBorder
          // 
          this._cbRightBorder.AutoSize = true;
          this._cbRightBorder.Location = new System.Drawing.Point(11, 43);
          this._cbRightBorder.Name = "_cbRightBorder";
          this._cbRightBorder.Size = new System.Drawing.Size(51, 17);
          this._cbRightBorder.TabIndex = 1;
          this._cbRightBorder.Text = "Right";
          this._cbRightBorder.UseVisualStyleBackColor = true;
          // 
          // _cbLeftBorder
          // 
          this._cbLeftBorder.AutoSize = true;
          this._cbLeftBorder.Location = new System.Drawing.Point(11, 20);
          this._cbLeftBorder.Name = "_cbLeftBorder";
          this._cbLeftBorder.Size = new System.Drawing.Size(44, 17);
          this._cbLeftBorder.TabIndex = 0;
          this._cbLeftBorder.Text = "Left";
          this._cbLeftBorder.UseVisualStyleBackColor = true;
          // 
          // _btnOK
          // 
          this._btnOK.Location = new System.Drawing.Point(267, 12);
          this._btnOK.Name = "_btnOK";
          this._btnOK.Size = new System.Drawing.Size(75, 23);
          this._btnOK.TabIndex = 1;
          this._btnOK.Text = "OK";
          this._btnOK.UseVisualStyleBackColor = true;
          this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnCancel.Location = new System.Drawing.Point(267, 41);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(75, 23);
          this._btnCancel.TabIndex = 2;
          this._btnCancel.Text = "Cancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _gb2
          // 
          this._gb2.Controls.Add(this._lblVariance);
          this._gb2.Controls.Add(this._lblWhiteNoise);
          this._gb2.Controls.Add(this._lblBorderPercent);
          this._gb2.Controls.Add(this._tnVariance);
          this._gb2.Controls.Add(this._tbWhiteNoiseLength);
          this._gb2.Controls.Add(this._bBorderPercent);
          this._gb2.Location = new System.Drawing.Point(12, 136);
          this._gb2.Name = "_gb2";
          this._gb2.Size = new System.Drawing.Size(241, 106);
          this._gb2.TabIndex = 3;
          this._gb2.TabStop = false;
          // 
          // _lblVariance
          // 
          this._lblVariance.AutoSize = true;
          this._lblVariance.Location = new System.Drawing.Point(22, 78);
          this._lblVariance.Name = "_lblVariance";
          this._lblVariance.Size = new System.Drawing.Size(49, 13);
          this._lblVariance.TabIndex = 5;
          this._lblVariance.Text = "Variance";
          // 
          // _lblWhiteNoise
          // 
          this._lblWhiteNoise.AutoSize = true;
          this._lblWhiteNoise.Location = new System.Drawing.Point(22, 52);
          this._lblWhiteNoise.Name = "_lblWhiteNoise";
          this._lblWhiteNoise.Size = new System.Drawing.Size(101, 13);
          this._lblWhiteNoise.TabIndex = 4;
          this._lblWhiteNoise.Text = "White Noise Length";
          // 
          // _lblBorderPercent
          // 
          this._lblBorderPercent.AutoSize = true;
          this._lblBorderPercent.Location = new System.Drawing.Point(22, 26);
          this._lblBorderPercent.Name = "_lblBorderPercent";
          this._lblBorderPercent.Size = new System.Drawing.Size(78, 13);
          this._lblBorderPercent.TabIndex = 3;
          this._lblBorderPercent.Text = "Border Percent";
          // 
          // _tnVariance
          // 
          this._tnVariance.Location = new System.Drawing.Point(139, 71);
          this._tnVariance.Name = "_tnVariance";
          this._tnVariance.Size = new System.Drawing.Size(68, 20);
          this._tnVariance.TabIndex = 2;
          this._tnVariance.TextChanged += new System.EventHandler(this._tnVariance_TextChanged);
          // 
          // _tbWhiteNoiseLength
          // 
          this._tbWhiteNoiseLength.Location = new System.Drawing.Point(139, 45);
          this._tbWhiteNoiseLength.Name = "_tbWhiteNoiseLength";
          this._tbWhiteNoiseLength.Size = new System.Drawing.Size(68, 20);
          this._tbWhiteNoiseLength.TabIndex = 1;
          this._tbWhiteNoiseLength.TextChanged += new System.EventHandler(this._tbWhiteNoiseLength_TextChanged);
          // 
          // _bBorderPercent
          // 
          this._bBorderPercent.Location = new System.Drawing.Point(139, 19);
          this._bBorderPercent.MaxLength = 3;
          this._bBorderPercent.Name = "_bBorderPercent";
          this._bBorderPercent.Size = new System.Drawing.Size(68, 20);
          this._bBorderPercent.TabIndex = 0;
          this._bBorderPercent.TextChanged += new System.EventHandler(this._bBorderPercent_TextChanged);
          // 
          // _gbFlags
          // 
          this._gbFlags.Controls.Add(this._cbUseVariance);
          this._gbFlags.Controls.Add(this._cbImageUnchanged);
          this._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._gbFlags.Location = new System.Drawing.Point(8, 12);
          this._gbFlags.Name = "_gbFlags";
          this._gbFlags.Size = new System.Drawing.Size(126, 117);
          this._gbFlags.TabIndex = 4;
          this._gbFlags.TabStop = false;
          this._gbFlags.Text = "Flags";
          // 
          // _cbUseVariance
          // 
          this._cbUseVariance.AutoSize = true;
          this._cbUseVariance.Checked = true;
          this._cbUseVariance.CheckState = System.Windows.Forms.CheckState.Checked;
          this._cbUseVariance.Location = new System.Drawing.Point(6, 53);
          this._cbUseVariance.Name = "_cbUseVariance";
          this._cbUseVariance.Size = new System.Drawing.Size(90, 17);
          this._cbUseVariance.TabIndex = 1;
          this._cbUseVariance.Text = "Use Variance";
          this._cbUseVariance.UseVisualStyleBackColor = true;
          this._cbUseVariance.CheckedChanged += new System.EventHandler(this._cbUseVariance_CheckedChanged);
          // 
          // _cbImageUnchanged
          // 
          this._cbImageUnchanged.AutoSize = true;
          this._cbImageUnchanged.Location = new System.Drawing.Point(6, 25);
          this._cbImageUnchanged.Name = "_cbImageUnchanged";
          this._cbImageUnchanged.Size = new System.Drawing.Size(117, 17);
          this._cbImageUnchanged.TabIndex = 0;
          this._cbImageUnchanged.Text = " Image Unchanged";
          this._cbImageUnchanged.UseVisualStyleBackColor = true;
          // 
          // BorderRemoveDialog
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(345, 252);
          this.Controls.Add(this._gbFlags);
          this.Controls.Add(this._gb2);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOK);
          this.Controls.Add(this._gb1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "BorderRemoveDialog";
          this.Text = "Border Removal";
          this._gb1.ResumeLayout(false);
          this._gb1.PerformLayout();
          this._gb2.ResumeLayout(false);
          this._gb2.PerformLayout();
          this._gbFlags.ResumeLayout(false);
          this._gbFlags.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gb1;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _gb2;
      private System.Windows.Forms.Label _lblVariance;
      private System.Windows.Forms.Label _lblWhiteNoise;
      private System.Windows.Forms.Label _lblBorderPercent;
      private System.Windows.Forms.CheckBox _cbTopBorder;
      private System.Windows.Forms.CheckBox _cbBottomBorder;
      private System.Windows.Forms.CheckBox _cbRightBorder;
      private System.Windows.Forms.CheckBox _cbLeftBorder;
      private System.Windows.Forms.TextBox _tnVariance;
      private System.Windows.Forms.TextBox _tbWhiteNoiseLength;
      private System.Windows.Forms.TextBox _bBorderPercent;
       private System.Windows.Forms.GroupBox _gbFlags;
       private System.Windows.Forms.CheckBox _cbUseVariance;
       private System.Windows.Forms.CheckBox _cbImageUnchanged;
   }
}