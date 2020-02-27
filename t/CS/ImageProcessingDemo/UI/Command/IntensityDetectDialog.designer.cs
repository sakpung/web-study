namespace ImageProcessingDemo
{
   partial class IntensityDetectDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntensityDetectDialog));
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._lblMsg = new System.Windows.Forms.Label();
          this._gbOptions = new System.Windows.Forms.GroupBox();
          this._btnOutColor = new System.Windows.Forms.Button();
          this._btnInColor = new System.Windows.Forms.Button();
          this._cbChannel = new System.Windows.Forms.ComboBox();
          this._pnlOutColor = new System.Windows.Forms.Panel();
          this._pnlInColor = new System.Windows.Forms.Panel();
          this._numHigh = new System.Windows.Forms.NumericUpDown();
          this._numLow = new System.Windows.Forms.NumericUpDown();
          this._lblChannel = new System.Windows.Forms.Label();
          this._lblOutColor = new System.Windows.Forms.Label();
          this._lblInColor = new System.Windows.Forms.Label();
          this._lblHigh = new System.Windows.Forms.Label();
          this._lblLow = new System.Windows.Forms.Label();
          this._gbOptions.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numHigh)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numLow)).BeginInit();
          this.SuspendLayout();
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          // 
          // _btnOk
          // 
          this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // _lblMsg
          // 
          this._lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblMsg, "_lblMsg");
          this._lblMsg.Name = "_lblMsg";
          // 
          // _gbOptions
          // 
          this._gbOptions.Controls.Add(this._btnOutColor);
          this._gbOptions.Controls.Add(this._btnInColor);
          this._gbOptions.Controls.Add(this._cbChannel);
          this._gbOptions.Controls.Add(this._pnlOutColor);
          this._gbOptions.Controls.Add(this._pnlInColor);
          this._gbOptions.Controls.Add(this._numHigh);
          this._gbOptions.Controls.Add(this._numLow);
          this._gbOptions.Controls.Add(this._lblChannel);
          this._gbOptions.Controls.Add(this._lblOutColor);
          this._gbOptions.Controls.Add(this._lblInColor);
          this._gbOptions.Controls.Add(this._lblHigh);
          this._gbOptions.Controls.Add(this._lblLow);
          this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbOptions, "_gbOptions");
          this._gbOptions.Name = "_gbOptions";
          this._gbOptions.TabStop = false;
          // 
          // _btnOutColor
          // 
          resources.ApplyResources(this._btnOutColor, "_btnOutColor");
          this._btnOutColor.Name = "_btnOutColor";
          this._btnOutColor.UseVisualStyleBackColor = true;
          this._btnOutColor.Click += new System.EventHandler(this._btnOutColor_Click);
          // 
          // _btnInColor
          // 
          resources.ApplyResources(this._btnInColor, "_btnInColor");
          this._btnInColor.Name = "_btnInColor";
          this._btnInColor.UseVisualStyleBackColor = true;
          this._btnInColor.Click += new System.EventHandler(this._btnInColor_Click);
          // 
          // _cbChannel
          // 
          this._cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cbChannel.FormattingEnabled = true;
          resources.ApplyResources(this._cbChannel, "_cbChannel");
          this._cbChannel.Name = "_cbChannel";
          this._cbChannel.SelectedIndexChanged += new System.EventHandler(this._cbChannel_SelectedIndexChanged);
          // 
          // _pnlOutColor
          // 
          this._pnlOutColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._pnlOutColor, "_pnlOutColor");
          this._pnlOutColor.Name = "_pnlOutColor";
          this._pnlOutColor.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlOutColor_Paint);
          // 
          // _pnlInColor
          // 
          this._pnlInColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._pnlInColor, "_pnlInColor");
          this._pnlInColor.Name = "_pnlInColor";
          this._pnlInColor.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlInColor_Paint);
          // 
          // _numHigh
          // 
          resources.ApplyResources(this._numHigh, "_numHigh");
          this._numHigh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
          this._numHigh.Name = "_numHigh";
          this._numHigh.Leave += new System.EventHandler(this._num_Leave);
          // 
          // _numLow
          // 
          resources.ApplyResources(this._numLow, "_numLow");
          this._numLow.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
          this._numLow.Name = "_numLow";
          this._numLow.Leave += new System.EventHandler(this._num_Leave);
          // 
          // _lblChannel
          // 
          this._lblChannel.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblChannel, "_lblChannel");
          this._lblChannel.Name = "_lblChannel";
          // 
          // _lblOutColor
          // 
          this._lblOutColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblOutColor, "_lblOutColor");
          this._lblOutColor.Name = "_lblOutColor";
          // 
          // _lblInColor
          // 
          this._lblInColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblInColor, "_lblInColor");
          this._lblInColor.Name = "_lblInColor";
          // 
          // _lblHigh
          // 
          this._lblHigh.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblHigh, "_lblHigh");
          this._lblHigh.Name = "_lblHigh";
          // 
          // _lblLow
          // 
          this._lblLow.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblLow, "_lblLow");
          this._lblLow.Name = "_lblLow";
          // 
          // IntensityDetectDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._lblMsg);
          this.Controls.Add(this._gbOptions);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "IntensityDetectDialog";
          this.ShowIcon = false;
          this.ShowInTaskbar = false;
          this.Load += new System.EventHandler(this.IntensityDetectDialog_Load);
          this._gbOptions.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this._numHigh)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numLow)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Label _lblMsg;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.NumericUpDown _numHigh;
      private System.Windows.Forms.NumericUpDown _numLow;
      private System.Windows.Forms.Label _lblInColor;
      private System.Windows.Forms.Label _lblHigh;
      private System.Windows.Forms.Label _lblLow;
      private System.Windows.Forms.Button _btnOutColor;
      private System.Windows.Forms.Button _btnInColor;
      private System.Windows.Forms.ComboBox _cbChannel;
      private System.Windows.Forms.Panel _pnlOutColor;
      private System.Windows.Forms.Panel _pnlInColor;
      private System.Windows.Forms.Label _lblChannel;
      private System.Windows.Forms.Label _lblOutColor;
   }
}