namespace OcrDemo
{
   partial class ContrastBrightnessIntensityDialog
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
         if(disposing && (components != null))
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
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this._valuesGroupBox = new System.Windows.Forms.GroupBox();
         this._intensityValueLabel = new System.Windows.Forms.Label();
         this._brightnessValueLabel = new System.Windows.Forms.Label();
         this._contrastValueLabel = new System.Windows.Forms.Label();
         this._intensityLabel = new System.Windows.Forms.Label();
         this._brightnessLabel = new System.Windows.Forms.Label();
         this._intensityTrackBar = new System.Windows.Forms.TrackBar();
         this._brightnessTrackBar = new System.Windows.Forms.TrackBar();
         this._contrastTrackBar = new System.Windows.Forms.TrackBar();
         this._contrastLabel = new System.Windows.Forms.Label();
         this._valuesGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._intensityTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._brightnessTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._contrastTrackBar)).BeginInit();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(340, 200);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 2;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(259, 200);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 1;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _valuesGroupBox
         // 
         this._valuesGroupBox.Controls.Add(this._intensityValueLabel);
         this._valuesGroupBox.Controls.Add(this._brightnessValueLabel);
         this._valuesGroupBox.Controls.Add(this._contrastValueLabel);
         this._valuesGroupBox.Controls.Add(this._intensityLabel);
         this._valuesGroupBox.Controls.Add(this._brightnessLabel);
         this._valuesGroupBox.Controls.Add(this._intensityTrackBar);
         this._valuesGroupBox.Controls.Add(this._brightnessTrackBar);
         this._valuesGroupBox.Controls.Add(this._contrastTrackBar);
         this._valuesGroupBox.Controls.Add(this._contrastLabel);
         this._valuesGroupBox.Location = new System.Drawing.Point(12, 12);
         this._valuesGroupBox.Name = "_valuesGroupBox";
         this._valuesGroupBox.Size = new System.Drawing.Size(403, 182);
         this._valuesGroupBox.TabIndex = 0;
         this._valuesGroupBox.TabStop = false;
         // 
         // _intensityValueLabel
         // 
         this._intensityValueLabel.AutoSize = true;
         this._intensityValueLabel.Location = new System.Drawing.Point(338, 118);
         this._intensityValueLabel.Name = "_intensityValueLabel";
         this._intensityValueLabel.Size = new System.Drawing.Size(46, 13);
         this._intensityValueLabel.TabIndex = 8;
         this._intensityValueLabel.Text = "Intensity";
         // 
         // _brightnessValueLabel
         // 
         this._brightnessValueLabel.AutoSize = true;
         this._brightnessValueLabel.Location = new System.Drawing.Point(338, 67);
         this._brightnessValueLabel.Name = "_brightnessValueLabel";
         this._brightnessValueLabel.Size = new System.Drawing.Size(56, 13);
         this._brightnessValueLabel.TabIndex = 5;
         this._brightnessValueLabel.Text = "Brightness";
         // 
         // _contrastValueLabel
         // 
         this._contrastValueLabel.AutoSize = true;
         this._contrastValueLabel.Location = new System.Drawing.Point(338, 16);
         this._contrastValueLabel.Name = "_contrastValueLabel";
         this._contrastValueLabel.Size = new System.Drawing.Size(46, 13);
         this._contrastValueLabel.TabIndex = 2;
         this._contrastValueLabel.Text = "Contrast";
         // 
         // _intensityLabel
         // 
         this._intensityLabel.AutoSize = true;
         this._intensityLabel.Location = new System.Drawing.Point(6, 118);
         this._intensityLabel.Name = "_intensityLabel";
         this._intensityLabel.Size = new System.Drawing.Size(46, 13);
         this._intensityLabel.TabIndex = 6;
         this._intensityLabel.Text = "&Intensity";
         // 
         // _brightnessLabel
         // 
         this._brightnessLabel.AutoSize = true;
         this._brightnessLabel.Location = new System.Drawing.Point(6, 67);
         this._brightnessLabel.Name = "_brightnessLabel";
         this._brightnessLabel.Size = new System.Drawing.Size(56, 13);
         this._brightnessLabel.TabIndex = 3;
         this._brightnessLabel.Text = "&Brightness";
         // 
         // _intensityTrackBar
         // 
         this._intensityTrackBar.LargeChange = 10;
         this._intensityTrackBar.Location = new System.Drawing.Point(58, 118);
         this._intensityTrackBar.Maximum = 100;
         this._intensityTrackBar.Minimum = -100;
         this._intensityTrackBar.Name = "_intensityTrackBar";
         this._intensityTrackBar.Size = new System.Drawing.Size(274, 45);
         this._intensityTrackBar.TabIndex = 7;
         this._intensityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
         this._intensityTrackBar.ValueChanged += new System.EventHandler(this._intensityTrackBar_ValueChanged);
         // 
         // _brightnessTrackBar
         // 
         this._brightnessTrackBar.LargeChange = 10;
         this._brightnessTrackBar.Location = new System.Drawing.Point(58, 67);
         this._brightnessTrackBar.Maximum = 100;
         this._brightnessTrackBar.Minimum = -100;
         this._brightnessTrackBar.Name = "_brightnessTrackBar";
         this._brightnessTrackBar.Size = new System.Drawing.Size(274, 45);
         this._brightnessTrackBar.TabIndex = 4;
         this._brightnessTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
         this._brightnessTrackBar.ValueChanged += new System.EventHandler(this._brightnessTrackBar_ValueChanged);
         // 
         // _contrastTrackBar
         // 
         this._contrastTrackBar.LargeChange = 10;
         this._contrastTrackBar.Location = new System.Drawing.Point(58, 16);
         this._contrastTrackBar.Maximum = 100;
         this._contrastTrackBar.Minimum = -100;
         this._contrastTrackBar.Name = "_contrastTrackBar";
         this._contrastTrackBar.Size = new System.Drawing.Size(274, 45);
         this._contrastTrackBar.TabIndex = 1;
         this._contrastTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
         this._contrastTrackBar.ValueChanged += new System.EventHandler(this._contrastTrackBar_ValueChanged);
         // 
         // _contrastLabel
         // 
         this._contrastLabel.AutoSize = true;
         this._contrastLabel.Location = new System.Drawing.Point(6, 16);
         this._contrastLabel.Name = "_contrastLabel";
         this._contrastLabel.Size = new System.Drawing.Size(46, 13);
         this._contrastLabel.TabIndex = 0;
         this._contrastLabel.Text = "&Contrast";
         // 
         // ContrastBrightnessIntensityDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(429, 232);
         this.Controls.Add(this._valuesGroupBox);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ContrastBrightnessIntensityDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Contrast Brightness Intensity";
         this._valuesGroupBox.ResumeLayout(false);
         this._valuesGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._intensityTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._brightnessTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._contrastTrackBar)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.GroupBox _valuesGroupBox;
      private System.Windows.Forms.Label _intensityValueLabel;
      private System.Windows.Forms.Label _brightnessValueLabel;
      private System.Windows.Forms.Label _contrastValueLabel;
      private System.Windows.Forms.Label _intensityLabel;
      private System.Windows.Forms.Label _brightnessLabel;
      private System.Windows.Forms.TrackBar _intensityTrackBar;
      private System.Windows.Forms.TrackBar _brightnessTrackBar;
      private System.Windows.Forms.TrackBar _contrastTrackBar;
      private System.Windows.Forms.Label _contrastLabel;
   }
}