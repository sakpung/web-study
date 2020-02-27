namespace ImageProcessingDemo
{
   partial class RotateDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RotateDialog));
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._lblInterpolation = new System.Windows.Forms.Label();
         this._gbOptionsInterpolation = new System.Windows.Forms.GroupBox();
         this._cbResize = new System.Windows.Forms.CheckBox();
         this._btnFillColor = new System.Windows.Forms.Button();
         this._pnlFillColor = new System.Windows.Forms.Panel();
         this._lblFillColor = new System.Windows.Forms.Label();
         this._numAngle = new System.Windows.Forms.NumericUpDown();
         this._lblAngle = new System.Windows.Forms.Label();
         this._rbButtonBicubic = new System.Windows.Forms.RadioButton();
         this._rbButtonNormal = new System.Windows.Forms.RadioButton();
         this._rbButtonResample = new System.Windows.Forms.RadioButton();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numAngle)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._lblInterpolation);
         this._gbOptions.Controls.Add(this._gbOptionsInterpolation);
         this._gbOptions.Controls.Add(this._cbResize);
         this._gbOptions.Controls.Add(this._btnFillColor);
         this._gbOptions.Controls.Add(this._pnlFillColor);
         this._gbOptions.Controls.Add(this._lblFillColor);
         this._gbOptions.Controls.Add(this._numAngle);
         this._gbOptions.Controls.Add(this._lblAngle);
         this._gbOptions.Controls.Add(this._rbButtonBicubic);
         this._gbOptions.Controls.Add(this._rbButtonNormal);
         this._gbOptions.Controls.Add(this._rbButtonResample);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _lblInterpolation
         // 
         this._lblInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblInterpolation, "_lblInterpolation");
         this._lblInterpolation.Name = "_lblInterpolation";
         // 
         // _gbOptionsInterpolation
         // 
         this._gbOptionsInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptionsInterpolation, "_gbOptionsInterpolation");
         this._gbOptionsInterpolation.Name = "_gbOptionsInterpolation";
         this._gbOptionsInterpolation.TabStop = false;
         // 
         // _cbResize
         // 
         resources.ApplyResources(this._cbResize, "_cbResize");
         this._cbResize.Name = "_cbResize";
         // 
         // _btnFillColor
         // 
         resources.ApplyResources(this._btnFillColor, "_btnFillColor");
         this._btnFillColor.Name = "_btnFillColor";
         this._btnFillColor.Click += new System.EventHandler(this._btnFillColor_Click);
         // 
         // _pnlFillColor
         // 
         this._pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._pnlFillColor, "_pnlFillColor");
         this._pnlFillColor.Name = "_pnlFillColor";
         this._pnlFillColor.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlFillColor_Paint);
         // 
         // _lblFillColor
         // 
         this._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblFillColor, "_lblFillColor");
         this._lblFillColor.Name = "_lblFillColor";
         // 
         // _numAngle
         // 
         resources.ApplyResources(this._numAngle, "_numAngle");
         this._numAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
         this._numAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
         this._numAngle.Name = "_numAngle";
         this._numAngle.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblAngle
         // 
         this._lblAngle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblAngle, "_lblAngle");
         this._lblAngle.Name = "_lblAngle";
         // 
         // _rbButtonBicubic
         // 
         resources.ApplyResources(this._rbButtonBicubic, "_rbButtonBicubic");
         this._rbButtonBicubic.Name = "_rbButtonBicubic";
         // 
         // _rbButtonNormal
         // 
         resources.ApplyResources(this._rbButtonNormal, "_rbButtonNormal");
         this._rbButtonNormal.Name = "_rbButtonNormal";
         // 
         // _rbButtonResample
         // 
         resources.ApplyResources(this._rbButtonResample, "_rbButtonResample");
         this._rbButtonResample.Name = "_rbButtonResample";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // RotateDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "RotateDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.RotateDialog_Load);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numAngle)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblInterpolation;
      private System.Windows.Forms.GroupBox _gbOptionsInterpolation;
      private System.Windows.Forms.CheckBox _cbResize;
      private System.Windows.Forms.Button _btnFillColor;
      private System.Windows.Forms.Panel _pnlFillColor;
      private System.Windows.Forms.Label _lblFillColor;
      private System.Windows.Forms.NumericUpDown _numAngle;
      private System.Windows.Forms.Label _lblAngle;
      private System.Windows.Forms.RadioButton _rbButtonBicubic;
      private System.Windows.Forms.RadioButton _rbButtonNormal;
      private System.Windows.Forms.RadioButton _rbButtonResample;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;

   }
}