namespace OcrMultiEngineDemo
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContrastBrightnessIntensityDialog));
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
          resources.ApplyResources(this._okButton, "_okButton");
          this._okButton.Name = "_okButton";
          this._okButton.UseVisualStyleBackColor = true;
          // 
          // _cancelButton
          // 
          this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._cancelButton, "_cancelButton");
          this._cancelButton.Name = "_cancelButton";
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
          resources.ApplyResources(this._valuesGroupBox, "_valuesGroupBox");
          this._valuesGroupBox.Name = "_valuesGroupBox";
          this._valuesGroupBox.TabStop = false;
          // 
          // _intensityValueLabel
          // 
          resources.ApplyResources(this._intensityValueLabel, "_intensityValueLabel");
          this._intensityValueLabel.Name = "_intensityValueLabel";
          // 
          // _brightnessValueLabel
          // 
          resources.ApplyResources(this._brightnessValueLabel, "_brightnessValueLabel");
          this._brightnessValueLabel.Name = "_brightnessValueLabel";
          // 
          // _contrastValueLabel
          // 
          resources.ApplyResources(this._contrastValueLabel, "_contrastValueLabel");
          this._contrastValueLabel.Name = "_contrastValueLabel";
          // 
          // _intensityLabel
          // 
          resources.ApplyResources(this._intensityLabel, "_intensityLabel");
          this._intensityLabel.Name = "_intensityLabel";
          // 
          // _brightnessLabel
          // 
          resources.ApplyResources(this._brightnessLabel, "_brightnessLabel");
          this._brightnessLabel.Name = "_brightnessLabel";
          // 
          // _intensityTrackBar
          // 
          this._intensityTrackBar.LargeChange = 10;
          resources.ApplyResources(this._intensityTrackBar, "_intensityTrackBar");
          this._intensityTrackBar.Maximum = 100;
          this._intensityTrackBar.Minimum = -100;
          this._intensityTrackBar.Name = "_intensityTrackBar";
          this._intensityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
          this._intensityTrackBar.ValueChanged += new System.EventHandler(this._intensityTrackBar_ValueChanged);
          // 
          // _brightnessTrackBar
          // 
          this._brightnessTrackBar.LargeChange = 10;
          resources.ApplyResources(this._brightnessTrackBar, "_brightnessTrackBar");
          this._brightnessTrackBar.Maximum = 100;
          this._brightnessTrackBar.Minimum = -100;
          this._brightnessTrackBar.Name = "_brightnessTrackBar";
          this._brightnessTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
          this._brightnessTrackBar.ValueChanged += new System.EventHandler(this._brightnessTrackBar_ValueChanged);
          // 
          // _contrastTrackBar
          // 
          this._contrastTrackBar.LargeChange = 10;
          resources.ApplyResources(this._contrastTrackBar, "_contrastTrackBar");
          this._contrastTrackBar.Maximum = 100;
          this._contrastTrackBar.Minimum = -100;
          this._contrastTrackBar.Name = "_contrastTrackBar";
          this._contrastTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
          this._contrastTrackBar.ValueChanged += new System.EventHandler(this._contrastTrackBar_ValueChanged);
          // 
          // _contrastLabel
          // 
          resources.ApplyResources(this._contrastLabel, "_contrastLabel");
          this._contrastLabel.Name = "_contrastLabel";
          // 
          // ContrastBrightnessIntensityDialog
          // 
          this.AcceptButton = this._okButton;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._cancelButton;
          this.Controls.Add(this._valuesGroupBox);
          this.Controls.Add(this._cancelButton);
          this.Controls.Add(this._okButton);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ContrastBrightnessIntensityDialog";
          this.ShowInTaskbar = false;
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