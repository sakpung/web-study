namespace MedicalViewerDemo
{
   partial class AnimationDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimationDialog));
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this._chkForward = new System.Windows.Forms.CheckBox();
          this._chkStop = new System.Windows.Forms.CheckBox();
          this._chkBackward = new System.Windows.Forms.CheckBox();
          this.label2 = new System.Windows.Forms.Label();
          this.label1 = new System.Windows.Forms.Label();
          this._tbSpeed = new System.Windows.Forms.TrackBar();
          this._btnAdvance = new System.Windows.Forms.Button();
          this._grpExtendedParameters = new System.Windows.Forms.GroupBox();
          this._chkShowAnnotation = new System.Windows.Forms.CheckBox();
          this._chkShowRegion = new System.Windows.Forms.CheckBox();
          this._chkAnimateAllSubCells = new System.Windows.Forms.CheckBox();
          this._cmbInterpolation = new System.Windows.Forms.ComboBox();
          this.label4 = new System.Windows.Forms.Label();
          this._radShuffle = new System.Windows.Forms.RadioButton();
          this._radLoop = new System.Windows.Forms.RadioButton();
          this.label3 = new System.Windows.Forms.Label();
          this.groupBox3 = new System.Windows.Forms.GroupBox();
          this._chkToEnd = new System.Windows.Forms.CheckBox();
          this.label8 = new System.Windows.Forms.Label();
          this.label7 = new System.Windows.Forms.Label();
          this.label6 = new System.Windows.Forms.Label();
          this.label5 = new System.Windows.Forms.Label();
          this._cmbFrames = new System.Windows.Forms.ComboBox();
          this._btnHidden = new System.Windows.Forms.Button();
         this._txtTo = new MedicalViewerDemo.NumericTextBox();
         this._txtFrom = new MedicalViewerDemo.NumericTextBox();
         this._txtFrames = new MedicalViewerDemo.NumericTextBox();
          this.groupBox1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbSpeed)).BeginInit();
          this._grpExtendedParameters.SuspendLayout();
          this.groupBox3.SuspendLayout();
          this.SuspendLayout();
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this._chkForward);
          this.groupBox1.Controls.Add(this._chkStop);
          this.groupBox1.Controls.Add(this._chkBackward);
          this.groupBox1.Controls.Add(this.label2);
          this.groupBox1.Controls.Add(this.label1);
          this.groupBox1.Controls.Add(this._tbSpeed);
          this.groupBox1.Location = new System.Drawing.Point(8, 4);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(251, 135);
          this.groupBox1.TabIndex = 0;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "&General";
          // 
          // _chkForward
          // 
          this._chkForward.Appearance = System.Windows.Forms.Appearance.Button;
          this._chkForward.AutoCheck = false;
          this._chkForward.Image = ((System.Drawing.Image)(resources.GetObject("_chkForward.Image")));
          this._chkForward.Location = new System.Drawing.Point(158, 81);
          this._chkForward.Name = "_chkForward";
          this._chkForward.Size = new System.Drawing.Size(51, 37);
          this._chkForward.TabIndex = 5;
          this._chkForward.UseVisualStyleBackColor = true;
          this._chkForward.Click += new System.EventHandler(this._chkForward_Click);
          // 
          // _chkStop
          // 
          this._chkStop.Appearance = System.Windows.Forms.Appearance.Button;
          this._chkStop.AutoCheck = false;
          this._chkStop.Image = ((System.Drawing.Image)(resources.GetObject("_chkStop.Image")));
          this._chkStop.Location = new System.Drawing.Point(102, 81);
          this._chkStop.Name = "_chkStop";
          this._chkStop.Size = new System.Drawing.Size(51, 37);
          this._chkStop.TabIndex = 4;
          this._chkStop.UseVisualStyleBackColor = true;
          this._chkStop.Click += new System.EventHandler(this._chkStop_Click);
          // 
          // _chkBackward
          // 
          this._chkBackward.Appearance = System.Windows.Forms.Appearance.Button;
          this._chkBackward.AutoCheck = false;
          this._chkBackward.Image = ((System.Drawing.Image)(resources.GetObject("_chkBackward.Image")));
          this._chkBackward.Location = new System.Drawing.Point(46, 81);
          this._chkBackward.Name = "_chkBackward";
          this._chkBackward.Size = new System.Drawing.Size(51, 37);
          this._chkBackward.TabIndex = 3;
          this._chkBackward.UseVisualStyleBackColor = true;
          this._chkBackward.Click += new System.EventHandler(this._chkBackward_Click);
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(207, 39);
          this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(27, 13);
          this.label2.TabIndex = 2;
          this.label2.Text = "Fast";
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(16, 40);
          this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(30, 13);
          this.label1.TabIndex = 1;
          this.label1.Text = "Slow";
          // 
          // _tbSpeed
          // 
          this._tbSpeed.AutoSize = false;
          this._tbSpeed.Location = new System.Drawing.Point(49, 25);
          this._tbSpeed.Maximum = 300;
          this._tbSpeed.Minimum = 1;
          this._tbSpeed.Name = "_tbSpeed";
          this._tbSpeed.Size = new System.Drawing.Size(155, 39);
          this._tbSpeed.TabIndex = 0;
          this._tbSpeed.TickFrequency = 0;
          this._tbSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
          this._tbSpeed.Value = 150;
          this._tbSpeed.Scroll += new System.EventHandler(this._tbSpeed_Scroll);
          // 
          // _btnAdvance
          // 
          this._btnAdvance.Location = new System.Drawing.Point(186, 145);
          this._btnAdvance.Name = "_btnAdvance";
          this._btnAdvance.Size = new System.Drawing.Size(73, 29);
          this._btnAdvance.TabIndex = 1;
          this._btnAdvance.Text = "Ad&vance >>";
          this._btnAdvance.UseVisualStyleBackColor = true;
          this._btnAdvance.Click += new System.EventHandler(this._btnAdvance_Click);
          // 
          // _grpExtendedParameters
          // 
          this._grpExtendedParameters.Controls.Add(this._chkShowAnnotation);
          this._grpExtendedParameters.Controls.Add(this._chkShowRegion);
          this._grpExtendedParameters.Controls.Add(this._chkAnimateAllSubCells);
          this._grpExtendedParameters.Controls.Add(this._cmbInterpolation);
          this._grpExtendedParameters.Controls.Add(this.label4);
          this._grpExtendedParameters.Controls.Add(this._radShuffle);
          this._grpExtendedParameters.Controls.Add(this._radLoop);
          this._grpExtendedParameters.Controls.Add(this.label3);
          this._grpExtendedParameters.Location = new System.Drawing.Point(10, 174);
          this._grpExtendedParameters.Name = "_grpExtendedParameters";
          this._grpExtendedParameters.Size = new System.Drawing.Size(248, 143);
          this._grpExtendedParameters.TabIndex = 2;
          this._grpExtendedParameters.TabStop = false;
          this._grpExtendedParameters.Text = "&Extended Parameters";
          // 
          // _chkShowAnnotation
          // 
          this._chkShowAnnotation.AutoSize = true;
          this._chkShowAnnotation.Location = new System.Drawing.Point(27, 122);
          this._chkShowAnnotation.Name = "_chkShowAnnotation";
         this._chkShowAnnotation.Size = new System.Drawing.Size(107, 17);
          this._chkShowAnnotation.TabIndex = 7;
          this._chkShowAnnotation.Text = "Show A&nnotation";
          this._chkShowAnnotation.UseVisualStyleBackColor = true;
          this._chkShowAnnotation.CheckedChanged += new System.EventHandler(this._chkShowAnnotation_CheckedChanged);
          // 
          // _chkShowRegion
          // 
          this._chkShowRegion.AutoSize = true;
          this._chkShowRegion.Location = new System.Drawing.Point(27, 101);
          this._chkShowRegion.Name = "_chkShowRegion";
         this._chkShowRegion.Size = new System.Drawing.Size(90, 17);
          this._chkShowRegion.TabIndex = 6;
          this._chkShowRegion.Text = "&Show Region";
          this._chkShowRegion.UseVisualStyleBackColor = true;
          this._chkShowRegion.CheckedChanged += new System.EventHandler(this._chkShowRegion_CheckedChanged);
          // 
          // _chkAnimateAllSubCells
          // 
          this._chkAnimateAllSubCells.AutoSize = true;
          this._chkAnimateAllSubCells.Location = new System.Drawing.Point(27, 81);
          this._chkAnimateAllSubCells.Name = "_chkAnimateAllSubCells";
         this._chkAnimateAllSubCells.Size = new System.Drawing.Size(122, 17);
          this._chkAnimateAllSubCells.TabIndex = 5;
          this._chkAnimateAllSubCells.Text = "&Animate All sub-cells";
          this._chkAnimateAllSubCells.UseVisualStyleBackColor = true;
          this._chkAnimateAllSubCells.CheckedChanged += new System.EventHandler(this._chkAnimateAllSubCells_CheckedChanged);
          // 
          // _cmbInterpolation
          // 
          this._cmbInterpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbInterpolation.FormattingEnabled = true;
          this._cmbInterpolation.Items.AddRange(new object[] {
            "Normal",
            "Resample",
            "Bicubic"});
          this._cmbInterpolation.Location = new System.Drawing.Point(99, 49);
          this._cmbInterpolation.Name = "_cmbInterpolation";
          this._cmbInterpolation.Size = new System.Drawing.Size(105, 21);
          this._cmbInterpolation.TabIndex = 4;
          this._cmbInterpolation.SelectedIndexChanged += new System.EventHandler(this._cmbInterpolation_SelectedIndexChanged);
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(26, 53);
          this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(65, 13);
          this.label4.TabIndex = 3;
          this.label4.Text = "&Interpolation";
          // 
          // _radShuffle
          // 
          this._radShuffle.AutoSize = true;
          this._radShuffle.Location = new System.Drawing.Point(156, 22);
          this._radShuffle.Name = "_radShuffle";
         this._radShuffle.Size = new System.Drawing.Size(58, 17);
          this._radShuffle.TabIndex = 2;
          this._radShuffle.Text = "&Shuffle";
          this._radShuffle.UseVisualStyleBackColor = true;
          this._radShuffle.CheckedChanged += new System.EventHandler(this._radShuffle_CheckedChanged);
          // 
          // _radLoop
          // 
          this._radLoop.AutoSize = true;
          this._radLoop.Checked = true;
          this._radLoop.Location = new System.Drawing.Point(100, 22);
          this._radLoop.Name = "_radLoop";
         this._radLoop.Size = new System.Drawing.Size(49, 17);
          this._radLoop.TabIndex = 1;
          this._radLoop.TabStop = true;
          this._radLoop.Text = "&Loop";
          this._radLoop.UseVisualStyleBackColor = true;
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(26, 24);
          this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(57, 13);
          this.label3.TabIndex = 0;
          this.label3.Text = "&Play Mode";
          // 
          // groupBox3
          // 
          this.groupBox3.Controls.Add(this._chkToEnd);
          this.groupBox3.Controls.Add(this.label8);
          this.groupBox3.Controls.Add(this.label7);
          this.groupBox3.Controls.Add(this._txtTo);
          this.groupBox3.Controls.Add(this._txtFrom);
          this.groupBox3.Controls.Add(this.label6);
          this.groupBox3.Controls.Add(this._txtFrames);
          this.groupBox3.Controls.Add(this.label5);
          this.groupBox3.Controls.Add(this._cmbFrames);
          this.groupBox3.Location = new System.Drawing.Point(10, 319);
          this.groupBox3.Name = "groupBox3";
          this.groupBox3.Size = new System.Drawing.Size(247, 79);
          this.groupBox3.TabIndex = 3;
          this.groupBox3.TabStop = false;
          this.groupBox3.Text = "&Frames";
          // 
          // _chkToEnd
          // 
          this._chkToEnd.AutoSize = true;
          this._chkToEnd.Checked = true;
          this._chkToEnd.CheckState = System.Windows.Forms.CheckState.Checked;
          this._chkToEnd.Location = new System.Drawing.Point(180, 53);
          this._chkToEnd.Name = "_chkToEnd";
         this._chkToEnd.Size = new System.Drawing.Size(61, 17);
          this._chkToEnd.TabIndex = 8;
          this._chkToEnd.Text = "To &End";
          this._chkToEnd.UseVisualStyleBackColor = true;
          this._chkToEnd.CheckedChanged += new System.EventHandler(this._chkToEnd_CheckedChanged);
          // 
          // label8
          // 
          this.label8.AutoSize = true;
          this.label8.Location = new System.Drawing.Point(96, 53);
          this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(20, 13);
          this.label8.TabIndex = 7;
          this.label8.Text = "&To";
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Location = new System.Drawing.Point(12, 53);
          this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(30, 13);
          this.label7.TabIndex = 6;
          this.label7.Text = "Fr&om";
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(200, 21);
          this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(41, 13);
          this.label6.TabIndex = 3;
          this.label6.Text = "F&rames";
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(10, 21);
          this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(41, 13);
          this.label5.TabIndex = 1;
          this.label5.Text = "&Frames";
          // 
          // _cmbFrames
          // 
          this._cmbFrames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbFrames.FormattingEnabled = true;
          this._cmbFrames.Items.AddRange(new object[] {
            "All Frames",
            "Odd Frames",
            "Even Frames",
            "Jump every"});
          this._cmbFrames.Location = new System.Drawing.Point(57, 18);
          this._cmbFrames.Name = "_cmbFrames";
          this._cmbFrames.Size = new System.Drawing.Size(92, 21);
          this._cmbFrames.TabIndex = 0;
          this._cmbFrames.SelectedIndexChanged += new System.EventHandler(this._cmbFrames_SelectedIndexChanged);
          // 
          // _btnHidden
          // 
          this._btnHidden.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnHidden.Location = new System.Drawing.Point(1000, 391);
          this._btnHidden.Name = "_btnHidden";
          this._btnHidden.Size = new System.Drawing.Size(19, 8);
          this._btnHidden.TabIndex = 4;
          this._btnHidden.UseVisualStyleBackColor = true;
          this._btnHidden.Click += new System.EventHandler(this._btnHidden_Click);
         // 
         // _txtTo
         // 
         this._txtTo.Enabled = false;
         this._txtTo.Location = new System.Drawing.Point(118, 50);
         this._txtTo.MaximumAllowed = 1000;
         this._txtTo.MinimumAllowed = 1;
         this._txtTo.Name = "_txtTo";
         this._txtTo.Size = new System.Drawing.Size(42, 20);
         this._txtTo.TabIndex = 5;
         this._txtTo.Text = "0";
         this._txtTo.Value = 0;
         this._txtTo.TextChanged += new System.EventHandler(this._txtTo_TextChanged);
         // 
         // _txtFrom
         // 
         this._txtFrom.Location = new System.Drawing.Point(43, 50);
         this._txtFrom.MaximumAllowed = 1000;
         this._txtFrom.MinimumAllowed = 1;
         this._txtFrom.Name = "_txtFrom";
         this._txtFrom.Size = new System.Drawing.Size(42, 20);
         this._txtFrom.TabIndex = 4;
         this._txtFrom.Text = "0";
         this._txtFrom.Value = 0;
         this._txtFrom.TextChanged += new System.EventHandler(this._txtFrom_TextChanged);
         // 
         // _txtFrames
         // 
         this._txtFrames.Location = new System.Drawing.Point(155, 18);
         this._txtFrames.MaximumAllowed = 1000;
         this._txtFrames.MinimumAllowed = 1;
         this._txtFrames.Name = "_txtFrames";
         this._txtFrames.Size = new System.Drawing.Size(40, 20);
         this._txtFrames.TabIndex = 2;
         this._txtFrames.Text = "3";
         this._txtFrames.Value = 3;
         this._txtFrames.TextChanged += new System.EventHandler(this._txtFrames_TextChanged);
          // 
          // AnimationDialog
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(266, 406);
          this.Controls.Add(this._btnHidden);
          this.Controls.Add(this.groupBox3);
          this.Controls.Add(this._grpExtendedParameters);
          this.Controls.Add(this._btnAdvance);
          this.Controls.Add(this.groupBox1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "AnimationDialog";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Animation Dialog";
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbSpeed)).EndInit();
          this._grpExtendedParameters.ResumeLayout(false);
          this._grpExtendedParameters.PerformLayout();
          this.groupBox3.ResumeLayout(false);
          this.groupBox3.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button _btnAdvance;
      private System.Windows.Forms.GroupBox _grpExtendedParameters;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TrackBar _tbSpeed;
      private System.Windows.Forms.CheckBox _chkForward;
      private System.Windows.Forms.CheckBox _chkStop;
      private System.Windows.Forms.CheckBox _chkBackward;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ComboBox _cmbInterpolation;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.RadioButton _radShuffle;
      private System.Windows.Forms.RadioButton _radLoop;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.CheckBox _chkAnimateAllSubCells;
      private System.Windows.Forms.CheckBox _chkShowAnnotation;
      private System.Windows.Forms.CheckBox _chkShowRegion;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label7;
      private NumericTextBox _txtTo;
      private NumericTextBox _txtFrom;
      private System.Windows.Forms.Label label6;
      private NumericTextBox _txtFrames;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.ComboBox _cmbFrames;
      private System.Windows.Forms.CheckBox _chkToEnd;
      private System.Windows.Forms.Button _btnHidden;
   }
}