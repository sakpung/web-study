namespace MainDemo
{
   partial class ColorResolutionDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorResolutionDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._grbOptions = new System.Windows.Forms.GroupBox();
         this._cbDither = new System.Windows.Forms.ComboBox();
         this._cbPalette = new System.Windows.Forms.ComboBox();
         this._cbOrder = new System.Windows.Forms.ComboBox();
         this._cbBitsPerPixel = new System.Windows.Forms.ComboBox();
         this._lblDither = new System.Windows.Forms.Label();
         this._lblPalette = new System.Windows.Forms.Label();
         this._lblOrder = new System.Windows.Forms.Label();
         this._lblBitsPerPixel = new System.Windows.Forms.Label();
         this._tsZoomLevel = new System.Windows.Forms.ToolStrip();
         this._tsbtnNormal = new System.Windows.Forms.ToolStripButton();
         this._tsbtnFit = new System.Windows.Forms.ToolStripButton();
         this._lblseparator2 = new System.Windows.Forms.Label();
         this._lblseparator1 = new System.Windows.Forms.Label();
         this._pbProgress = new System.Windows.Forms.ProgressBar();
         this._lblAfter = new System.Windows.Forms.Label();
         this._lblBefore = new System.Windows.Forms.Label();
         this._lblAfterlabel = new System.Windows.Forms.Label();
         this._lblBeforelabel = new System.Windows.Forms.Label();
         this._grbOptions.SuspendLayout();
         this._tsZoomLevel.SuspendLayout();
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
         // _grbOptions
         // 
         this._grbOptions.Controls.Add(this._cbDither);
         this._grbOptions.Controls.Add(this._cbPalette);
         this._grbOptions.Controls.Add(this._cbOrder);
         this._grbOptions.Controls.Add(this._cbBitsPerPixel);
         this._grbOptions.Controls.Add(this._lblDither);
         this._grbOptions.Controls.Add(this._lblPalette);
         this._grbOptions.Controls.Add(this._lblOrder);
         this._grbOptions.Controls.Add(this._lblBitsPerPixel);
         this._grbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._grbOptions, "_grbOptions");
         this._grbOptions.Name = "_grbOptions";
         this._grbOptions.TabStop = false;
         // 
         // _cbDither
         // 
         this._cbDither.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbDither.FormattingEnabled = true;
         resources.ApplyResources(this._cbDither, "_cbDither");
         this._cbDither.Name = "_cbDither";
         this._cbDither.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
         // 
         // _cbPalette
         // 
         this._cbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbPalette.FormattingEnabled = true;
         resources.ApplyResources(this._cbPalette, "_cbPalette");
         this._cbPalette.Name = "_cbPalette";
         this._cbPalette.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
         // 
         // _cbOrder
         // 
         this._cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbOrder.FormattingEnabled = true;
         resources.ApplyResources(this._cbOrder, "_cbOrder");
         this._cbOrder.Name = "_cbOrder";
         this._cbOrder.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
         // 
         // _cbBitsPerPixel
         // 
         this._cbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbBitsPerPixel.FormattingEnabled = true;
         resources.ApplyResources(this._cbBitsPerPixel, "_cbBitsPerPixel");
         this._cbBitsPerPixel.Name = "_cbBitsPerPixel";
         this._cbBitsPerPixel.SelectedIndexChanged += new System.EventHandler(this._cbBitsPerPixel_SelectedIndexChanged);
         // 
         // _lblDither
         // 
         this._lblDither.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblDither, "_lblDither");
         this._lblDither.Name = "_lblDither";
         // 
         // _lblPalette
         // 
         this._lblPalette.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblPalette, "_lblPalette");
         this._lblPalette.Name = "_lblPalette";
         // 
         // _lblOrder
         // 
         this._lblOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblOrder, "_lblOrder");
         this._lblOrder.Name = "_lblOrder";
         // 
         // _lblBitsPerPixel
         // 
         this._lblBitsPerPixel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblBitsPerPixel, "_lblBitsPerPixel");
         this._lblBitsPerPixel.Name = "_lblBitsPerPixel";
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
         // _lblseparator2
         // 
         this._lblseparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         resources.ApplyResources(this._lblseparator2, "_lblseparator2");
         this._lblseparator2.Name = "_lblseparator2";
         // 
         // _lblseparator1
         // 
         this._lblseparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         resources.ApplyResources(this._lblseparator1, "_lblseparator1");
         this._lblseparator1.Name = "_lblseparator1";
         // 
         // _pbProgress
         // 
         resources.ApplyResources(this._pbProgress, "_pbProgress");
         this._pbProgress.Name = "_pbProgress";
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
         // ColorResolutionDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._lblAfterlabel);
         this.Controls.Add(this._lblBeforelabel);
         this.Controls.Add(this._lblseparator2);
         this.Controls.Add(this._lblseparator1);
         this.Controls.Add(this._pbProgress);
         this.Controls.Add(this._lblAfter);
         this.Controls.Add(this._lblBefore);
         this.Controls.Add(this._tsZoomLevel);
         this.Controls.Add(this._grbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ColorResolutionDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.ColorResolutionDialog_Load);
         this._grbOptions.ResumeLayout(false);
         this._tsZoomLevel.ResumeLayout(false);
         this._tsZoomLevel.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _grbOptions;
      private System.Windows.Forms.Label _lblBitsPerPixel;
      private System.Windows.Forms.ComboBox _cbDither;
      private System.Windows.Forms.ComboBox _cbPalette;
      private System.Windows.Forms.ComboBox _cbOrder;
      private System.Windows.Forms.ComboBox _cbBitsPerPixel;
      private System.Windows.Forms.Label _lblDither;
      private System.Windows.Forms.Label _lblPalette;
      private System.Windows.Forms.Label _lblOrder;
      private System.Windows.Forms.ToolStrip _tsZoomLevel;
      private System.Windows.Forms.ToolStripButton _tsbtnNormal;
      private System.Windows.Forms.ToolStripButton _tsbtnFit;
      private System.Windows.Forms.Label _lblseparator2;
      private System.Windows.Forms.Label _lblseparator1;
      private System.Windows.Forms.ProgressBar _pbProgress;
      private System.Windows.Forms.Label _lblAfter;
      private System.Windows.Forms.Label _lblBefore;
      private System.Windows.Forms.Label _lblAfterlabel;
      private System.Windows.Forms.Label _lblBeforelabel;
   }
}