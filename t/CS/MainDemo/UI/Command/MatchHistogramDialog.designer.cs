namespace MainDemo
{
   partial class MatchHistogramDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchHistogramDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._tsbtnNormal = new System.Windows.Forms.ToolStripButton();
         this._tsbtnFit = new System.Windows.Forms.ToolStripButton();
         this._pbProgress = new System.Windows.Forms.ProgressBar();
         this._tsZoomLevel = new System.Windows.Forms.ToolStrip();
         this._lblREF = new System.Windows.Forms.Label();
         this._lblDST = new System.Windows.Forms.Label();
         this._lblseparator1 = new System.Windows.Forms.Label();
         this._lblseparator2 = new System.Windows.Forms.Label();
         this._lblREFlabel = new System.Windows.Forms.Label();
         this._lblDSTlabel = new System.Windows.Forms.Label();
         this._cmbREFImage = new System.Windows.Forms.ComboBox();
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
         // _lblREF
         // 
         this._lblREF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._lblREF, "_lblREF");
         this._lblREF.Name = "_lblREF";
         // 
         // _lblDST
         // 
         this._lblDST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._lblDST, "_lblDST");
         this._lblDST.Name = "_lblDST";
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
         // _lblREFlabel
         // 
         resources.ApplyResources(this._lblREFlabel, "_lblREFlabel");
         this._lblREFlabel.Name = "_lblREFlabel";
         // 
         // _lblDSTlabel
         // 
         resources.ApplyResources(this._lblDSTlabel, "_lblDSTlabel");
         this._lblDSTlabel.Name = "_lblDSTlabel";
         // 
         // _cmbREFImage
         // 
         this._cmbREFImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbREFImage.FormattingEnabled = true;
         resources.ApplyResources(this._cmbREFImage, "_cmbREFImage");
         this._cmbREFImage.Name = "_cmbREFImage";
         this._cmbREFImage.SelectedIndexChanged += new System.EventHandler(this._cmbREFImage_SelectedIndexChanged);
         // 
         // MatchHistogramDialog
         // 
         resources.ApplyResources(this, "$this");
         this.Controls.Add(this._cmbREFImage);
         this.Controls.Add(this._lblREFlabel);
         this.Controls.Add(this._lblDSTlabel);
         this.Controls.Add(this._lblseparator2);
         this.Controls.Add(this._lblseparator1);
         this.Controls.Add(this._pbProgress);
         this.Controls.Add(this._tsZoomLevel);
         this.Controls.Add(this._lblREF);
         this.Controls.Add(this._lblDST);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MatchHistogramDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.MatchHistogramDialog_Load);
         this._tsZoomLevel.ResumeLayout(false);
         this._tsZoomLevel.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.ToolStripButton _tsbtnNormal;
      private System.Windows.Forms.ToolStripButton _tsbtnFit;
      private System.Windows.Forms.ProgressBar _pbProgress;
      private System.Windows.Forms.ToolStrip _tsZoomLevel;
      private System.Windows.Forms.Label _lblREF;
      private System.Windows.Forms.Label _lblDST;
      private System.Windows.Forms.Label _lblseparator1;
      private System.Windows.Forms.Label _lblseparator2;
      private System.Windows.Forms.Label _lblREFlabel;
      private System.Windows.Forms.Label _lblDSTlabel;
      private System.Windows.Forms.ComboBox _cmbREFImage;
   }
}
