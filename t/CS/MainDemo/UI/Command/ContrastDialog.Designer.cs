namespace MainDemo
{
   partial class ContrastDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContrastDialog));
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._numValue = new System.Windows.Forms.NumericUpDown();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._tsbtnNormal = new System.Windows.Forms.ToolStripButton();
         this._tsbtnFit = new System.Windows.Forms.ToolStripButton();
         this._pbProgress = new System.Windows.Forms.ProgressBar();
         this._tsZoomLevel = new System.Windows.Forms.ToolStrip();
         this._lblAfter = new System.Windows.Forms.Label();
         this._lblBefore = new System.Windows.Forms.Label();
         this._lblseparator1 = new System.Windows.Forms.Label();
         this._lblseparator2 = new System.Windows.Forms.Label();
         this._lblBeforelabel = new System.Windows.Forms.Label();
         this._lblAfterlabel = new System.Windows.Forms.Label();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numValue)).BeginInit();
         this._tsZoomLevel.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._numValue);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _numValue
         // 
         this._numValue.BackColor = System.Drawing.SystemColors.Window;
         resources.ApplyResources(this._numValue, "_numValue");
         this._numValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numValue.Name = "_numValue";
         this._numValue.ReadOnly = true;
         this._numValue.ValueChanged += new System.EventHandler(this._numValue_ValueChanged);
         this._numValue.Leave += new System.EventHandler(this._num_Leave);
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
         // _tsbtnNormal
         // 
         this._tsbtnNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         resources.ApplyResources(this._tsbtnNormal, "_tsbtnNormal");
         this._tsbtnNormal.Name = "_tsbtnNormal";
         this._tsbtnNormal.Click += new System.EventHandler(this._tsbtnNormal_Click);
         // 
         // _tsbtnFit
         // 
         this._tsbtnFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         resources.ApplyResources(this._tsbtnFit, "_tsbtnFit");
         this._tsbtnFit.Name = "_tsbtnFit";
         this._tsbtnFit.Click += new System.EventHandler(this._tsbtnFit_Click);
         // 
         // _pbProgress
         // 
         resources.ApplyResources(this._pbProgress, "_pbProgress");
         this._pbProgress.Name = "_pbProgress";
         // 
         // _tsZoomLevel
         // 
         this._tsZoomLevel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsbtnNormal,
            this._tsbtnFit});
         resources.ApplyResources(this._tsZoomLevel, "_tsZoomLevel");
         this._tsZoomLevel.Name = "_tsZoomLevel";
         this._tsZoomLevel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
         // 
         // _lblAfter
         // 
         this._lblAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._lblAfter, "_lblAfter");
         this._lblAfter.Name = "_lblAfter";
         // 
         // _lblBefore
         // 
         this._lblBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._lblBefore, "_lblBefore");
         this._lblBefore.Name = "_lblBefore";
         // 
         // _lblseparator1
         // 
         this._lblseparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         resources.ApplyResources(this._lblseparator1, "_lblseparator1");
         this._lblseparator1.Name = "_lblseparator1";
         // 
         // _lblseparator2
         // 
         this._lblseparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         resources.ApplyResources(this._lblseparator2, "_lblseparator2");
         this._lblseparator2.Name = "_lblseparator2";
         // 
         // _lblBeforelabel
         // 
         resources.ApplyResources(this._lblBeforelabel, "_lblBeforelabel");
         this._lblBeforelabel.Name = "_lblBeforelabel";
         // 
         // _lblAfterlabel
         // 
         resources.ApplyResources(this._lblAfterlabel, "_lblAfterlabel");
         this._lblAfterlabel.Name = "_lblAfterlabel";
         // 
         // ContrastDialog
         // 
         resources.ApplyResources(this, "$this");
         this.Controls.Add(this._lblAfterlabel);
         this.Controls.Add(this._lblBeforelabel);
         this.Controls.Add(this._lblseparator2);
         this.Controls.Add(this._lblseparator1);
         this.Controls.Add(this._pbProgress);
         this.Controls.Add(this._tsZoomLevel);
         this.Controls.Add(this._lblAfter);
         this.Controls.Add(this._lblBefore);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbOptions);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ContrastDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.ContrastDialog_Load);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numValue)).EndInit();
         this._tsZoomLevel.ResumeLayout(false);
         this._tsZoomLevel.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.NumericUpDown _numValue;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.ToolStripButton _tsbtnNormal;
      private System.Windows.Forms.ToolStripButton _tsbtnFit;
      private System.Windows.Forms.ProgressBar _pbProgress;
      private System.Windows.Forms.ToolStrip _tsZoomLevel;
      private System.Windows.Forms.Label _lblAfter;
      private System.Windows.Forms.Label _lblBefore;
      private System.Windows.Forms.Label _lblseparator1;
      private System.Windows.Forms.Label _lblseparator2;
      private System.Windows.Forms.Label _lblBeforelabel;
      private System.Windows.Forms.Label _lblAfterlabel;
   }
}
