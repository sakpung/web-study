namespace MainDemo
{
   partial class BalanceColorsDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceColorsDialog));
         this._gbRedWeights = new System.Windows.Forms.GroupBox();
         this._lblBlueinRedWeight = new System.Windows.Forms.Label();
         this._lblGreeninRedWeight = new System.Windows.Forms.Label();
         this._lblRedinRedWeight = new System.Windows.Forms.Label();
         this._numBlueinRedWeight = new System.Windows.Forms.NumericUpDown();
         this._numGreeninRedWeight = new System.Windows.Forms.NumericUpDown();
         this._numRedinRedWeight = new System.Windows.Forms.NumericUpDown();
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
         this._lblAfterlabel = new System.Windows.Forms.Label();
         this._lblBeforelabel = new System.Windows.Forms.Label();
         this._gbGreenWeights = new System.Windows.Forms.GroupBox();
         this._lblBlueinGreenWeight = new System.Windows.Forms.Label();
         this._lblGreeninGreenWeight = new System.Windows.Forms.Label();
         this._lblRedinGreenWeight = new System.Windows.Forms.Label();
         this._numBlueinGreenWeight = new System.Windows.Forms.NumericUpDown();
         this._numGreeninGreenWeight = new System.Windows.Forms.NumericUpDown();
         this._numRedinGreenWeight = new System.Windows.Forms.NumericUpDown();
         this._gbBlueWeights = new System.Windows.Forms.GroupBox();
         this._lblBlueinBlueWeight = new System.Windows.Forms.Label();
         this._lblGreeninBlueWeight = new System.Windows.Forms.Label();
         this._lblRedinBlueWeight = new System.Windows.Forms.Label();
         this._numBlueinBlueWeight = new System.Windows.Forms.NumericUpDown();
         this._numGreeninBlueWeight = new System.Windows.Forms.NumericUpDown();
         this._numRedinBlueWeight = new System.Windows.Forms.NumericUpDown();
         this._gbRedWeights.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numBlueinRedWeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGreeninRedWeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRedinRedWeight)).BeginInit();
         this._tsZoomLevel.SuspendLayout();
         this._gbGreenWeights.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numBlueinGreenWeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGreeninGreenWeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRedinGreenWeight)).BeginInit();
         this._gbBlueWeights.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numBlueinBlueWeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGreeninBlueWeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRedinBlueWeight)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbRedWeights
         // 
         this._gbRedWeights.Controls.Add(this._lblBlueinRedWeight);
         this._gbRedWeights.Controls.Add(this._lblGreeninRedWeight);
         this._gbRedWeights.Controls.Add(this._lblRedinRedWeight);
         this._gbRedWeights.Controls.Add(this._numBlueinRedWeight);
         this._gbRedWeights.Controls.Add(this._numGreeninRedWeight);
         this._gbRedWeights.Controls.Add(this._numRedinRedWeight);
         this._gbRedWeights.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbRedWeights, "_gbRedWeights");
         this._gbRedWeights.Name = "_gbRedWeights";
         this._gbRedWeights.TabStop = false;
         // 
         // _lblBlueinRedWeight
         // 
         resources.ApplyResources(this._lblBlueinRedWeight, "_lblBlueinRedWeight");
         this._lblBlueinRedWeight.Name = "_lblBlueinRedWeight";
         // 
         // _lblGreeninRedWeight
         // 
         resources.ApplyResources(this._lblGreeninRedWeight, "_lblGreeninRedWeight");
         this._lblGreeninRedWeight.Name = "_lblGreeninRedWeight";
         // 
         // _lblRedinRedWeight
         // 
         resources.ApplyResources(this._lblRedinRedWeight, "_lblRedinRedWeight");
         this._lblRedinRedWeight.Name = "_lblRedinRedWeight";
         // 
         // _numBlueinRedWeight
         // 
         this._numBlueinRedWeight.BackColor = System.Drawing.SystemColors.Window;
         resources.ApplyResources(this._numBlueinRedWeight, "_numBlueinRedWeight");
         this._numBlueinRedWeight.Name = "_numBlueinRedWeight";
         this._numBlueinRedWeight.ValueChanged += new System.EventHandler(this.RedWeights_ValueChanged);
         this._numBlueinRedWeight.Leave += new System.EventHandler(this.RedWeights_Leave);
         // 
         // _numGreeninRedWeight
         // 
         this._numGreeninRedWeight.BackColor = System.Drawing.SystemColors.Window;
         resources.ApplyResources(this._numGreeninRedWeight, "_numGreeninRedWeight");
         this._numGreeninRedWeight.Name = "_numGreeninRedWeight";
         this._numGreeninRedWeight.ValueChanged += new System.EventHandler(this.RedWeights_ValueChanged);
         this._numGreeninRedWeight.Leave += new System.EventHandler(this.RedWeights_Leave);
         // 
         // _numRedinRedWeight
         // 
         this._numRedinRedWeight.BackColor = System.Drawing.SystemColors.Window;
         resources.ApplyResources(this._numRedinRedWeight, "_numRedinRedWeight");
         this._numRedinRedWeight.Name = "_numRedinRedWeight";
         this._numRedinRedWeight.ValueChanged += new System.EventHandler(this.RedWeights_ValueChanged);
         this._numRedinRedWeight.Leave += new System.EventHandler(this.RedWeights_Leave);
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
         // _lblAfterlabel
         // 
         resources.ApplyResources(this._lblAfterlabel, "_lblAfterlabel");
         this._lblAfterlabel.Name = "_lblAfterlabel";
         // 
         // _lblBeforelabel
         // 
         resources.ApplyResources(this._lblBeforelabel, "_lblBeforelabel");
         this._lblBeforelabel.Name = "_lblBeforelabel";
         // 
         // _gbGreenWeights
         // 
         this._gbGreenWeights.Controls.Add(this._lblBlueinGreenWeight);
         this._gbGreenWeights.Controls.Add(this._lblGreeninGreenWeight);
         this._gbGreenWeights.Controls.Add(this._lblRedinGreenWeight);
         this._gbGreenWeights.Controls.Add(this._numBlueinGreenWeight);
         this._gbGreenWeights.Controls.Add(this._numGreeninGreenWeight);
         this._gbGreenWeights.Controls.Add(this._numRedinGreenWeight);
         this._gbGreenWeights.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbGreenWeights, "_gbGreenWeights");
         this._gbGreenWeights.Name = "_gbGreenWeights";
         this._gbGreenWeights.TabStop = false;
         // 
         // _lblBlueinGreenWeight
         // 
         resources.ApplyResources(this._lblBlueinGreenWeight, "_lblBlueinGreenWeight");
         this._lblBlueinGreenWeight.Name = "_lblBlueinGreenWeight";
         // 
         // _lblGreeninGreenWeight
         // 
         resources.ApplyResources(this._lblGreeninGreenWeight, "_lblGreeninGreenWeight");
         this._lblGreeninGreenWeight.Name = "_lblGreeninGreenWeight";
         // 
         // _lblRedinGreenWeight
         // 
         resources.ApplyResources(this._lblRedinGreenWeight, "_lblRedinGreenWeight");
         this._lblRedinGreenWeight.Name = "_lblRedinGreenWeight";
         // 
         // _numBlueinGreenWeight
         // 
         this._numBlueinGreenWeight.BackColor = System.Drawing.SystemColors.Window;
         resources.ApplyResources(this._numBlueinGreenWeight, "_numBlueinGreenWeight");
         this._numBlueinGreenWeight.Name = "_numBlueinGreenWeight";
         this._numBlueinGreenWeight.ValueChanged += new System.EventHandler(this.GreenWeights_ValueChanged);
         this._numBlueinGreenWeight.Leave += new System.EventHandler(this.GreenWeights_Leave);
         // 
         // _numGreeninGreenWeight
         // 
         this._numGreeninGreenWeight.BackColor = System.Drawing.SystemColors.Window;
         resources.ApplyResources(this._numGreeninGreenWeight, "_numGreeninGreenWeight");
         this._numGreeninGreenWeight.Name = "_numGreeninGreenWeight";
         this._numGreeninGreenWeight.ValueChanged += new System.EventHandler(this.GreenWeights_ValueChanged);
         this._numGreeninGreenWeight.Leave += new System.EventHandler(this.GreenWeights_Leave);
         // 
         // _numRedinGreenWeight
         // 
         this._numRedinGreenWeight.BackColor = System.Drawing.SystemColors.Window;
         resources.ApplyResources(this._numRedinGreenWeight, "_numRedinGreenWeight");
         this._numRedinGreenWeight.Name = "_numRedinGreenWeight";
         this._numRedinGreenWeight.ValueChanged += new System.EventHandler(this.GreenWeights_ValueChanged);
         this._numRedinGreenWeight.Leave += new System.EventHandler(this.GreenWeights_Leave);
         // 
         // _gbBlueWeights
         // 
         this._gbBlueWeights.Controls.Add(this._lblBlueinBlueWeight);
         this._gbBlueWeights.Controls.Add(this._lblGreeninBlueWeight);
         this._gbBlueWeights.Controls.Add(this._lblRedinBlueWeight);
         this._gbBlueWeights.Controls.Add(this._numBlueinBlueWeight);
         this._gbBlueWeights.Controls.Add(this._numGreeninBlueWeight);
         this._gbBlueWeights.Controls.Add(this._numRedinBlueWeight);
         this._gbBlueWeights.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbBlueWeights, "_gbBlueWeights");
         this._gbBlueWeights.Name = "_gbBlueWeights";
         this._gbBlueWeights.TabStop = false;
         // 
         // _lblBlueinBlueWeight
         // 
         resources.ApplyResources(this._lblBlueinBlueWeight, "_lblBlueinBlueWeight");
         this._lblBlueinBlueWeight.Name = "_lblBlueinBlueWeight";
         // 
         // _lblGreeninBlueWeight
         // 
         resources.ApplyResources(this._lblGreeninBlueWeight, "_lblGreeninBlueWeight");
         this._lblGreeninBlueWeight.Name = "_lblGreeninBlueWeight";
         // 
         // _lblRedinBlueWeight
         // 
         resources.ApplyResources(this._lblRedinBlueWeight, "_lblRedinBlueWeight");
         this._lblRedinBlueWeight.Name = "_lblRedinBlueWeight";
         // 
         // _numBlueinBlueWeight
         // 
         this._numBlueinBlueWeight.BackColor = System.Drawing.SystemColors.Window;
         resources.ApplyResources(this._numBlueinBlueWeight, "_numBlueinBlueWeight");
         this._numBlueinBlueWeight.Name = "_numBlueinBlueWeight";
         this._numBlueinBlueWeight.ValueChanged += new System.EventHandler(this.BlueWeights_ValueChanged);
         this._numBlueinBlueWeight.Leave += new System.EventHandler(this.BlueWeights_Leave);
         // 
         // _numGreeninBlueWeight
         // 
         this._numGreeninBlueWeight.BackColor = System.Drawing.SystemColors.Window;
         resources.ApplyResources(this._numGreeninBlueWeight, "_numGreeninBlueWeight");
         this._numGreeninBlueWeight.Name = "_numGreeninBlueWeight";
         this._numGreeninBlueWeight.ValueChanged += new System.EventHandler(this.BlueWeights_ValueChanged);
         this._numGreeninBlueWeight.Leave += new System.EventHandler(this.BlueWeights_Leave);
         // 
         // _numRedinBlueWeight
         // 
         this._numRedinBlueWeight.BackColor = System.Drawing.SystemColors.Window;
         resources.ApplyResources(this._numRedinBlueWeight, "_numRedinBlueWeight");
         this._numRedinBlueWeight.Name = "_numRedinBlueWeight";
         this._numRedinBlueWeight.ValueChanged += new System.EventHandler(this.BlueWeights_ValueChanged);
         this._numRedinBlueWeight.Leave += new System.EventHandler(this.BlueWeights_Leave);
         // 
         // BalanceColorsDialog
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
         this.Controls.Add(this._gbBlueWeights);
         this.Controls.Add(this._gbGreenWeights);
         this.Controls.Add(this._gbRedWeights);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BalanceColorsDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.BalanceColorsDialog_Load);
         this._gbRedWeights.ResumeLayout(false);
         this._gbRedWeights.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numBlueinRedWeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGreeninRedWeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRedinRedWeight)).EndInit();
         this._tsZoomLevel.ResumeLayout(false);
         this._tsZoomLevel.PerformLayout();
         this._gbGreenWeights.ResumeLayout(false);
         this._gbGreenWeights.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numBlueinGreenWeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGreeninGreenWeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRedinGreenWeight)).EndInit();
         this._gbBlueWeights.ResumeLayout(false);
         this._gbBlueWeights.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numBlueinBlueWeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGreeninBlueWeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRedinBlueWeight)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      private System.Windows.Forms.GroupBox _gbRedWeights;
      private System.Windows.Forms.NumericUpDown _numRedinRedWeight;
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
      private System.Windows.Forms.Label _lblAfterlabel;
      private System.Windows.Forms.Label _lblBeforelabel;
      private System.Windows.Forms.Label _lblRedinRedWeight;
      private System.Windows.Forms.Label _lblGreeninRedWeight;
      private System.Windows.Forms.NumericUpDown _numGreeninRedWeight;
      private System.Windows.Forms.Label _lblBlueinRedWeight;
      private System.Windows.Forms.NumericUpDown _numBlueinRedWeight;
      private System.Windows.Forms.GroupBox _gbGreenWeights;
      private System.Windows.Forms.Label _lblBlueinGreenWeight;
      private System.Windows.Forms.Label _lblGreeninGreenWeight;
      private System.Windows.Forms.Label _lblRedinGreenWeight;
      private System.Windows.Forms.NumericUpDown _numBlueinGreenWeight;
      private System.Windows.Forms.NumericUpDown _numGreeninGreenWeight;
      private System.Windows.Forms.NumericUpDown _numRedinGreenWeight;
      private System.Windows.Forms.GroupBox _gbBlueWeights;
      private System.Windows.Forms.Label _lblBlueinBlueWeight;
      private System.Windows.Forms.Label _lblGreeninBlueWeight;
      private System.Windows.Forms.Label _lblRedinBlueWeight;
      private System.Windows.Forms.NumericUpDown _numBlueinBlueWeight;
      private System.Windows.Forms.NumericUpDown _numGreeninBlueWeight;
      private System.Windows.Forms.NumericUpDown _numRedinBlueWeight;
   }
}
