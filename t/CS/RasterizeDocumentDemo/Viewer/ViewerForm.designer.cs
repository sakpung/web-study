namespace RasterizeDocumentDemo.Viewer
{
   partial class ViewerForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerForm));
         this._mainMenuStrip = new System.Windows.Forms.MenuStrip();
         this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._filePrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._filePrintPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._filePrintSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._fileCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewGotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewGotoFirstPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewGotoPreviousPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewGotoNextPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewGotoLastPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewGotoPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._viewZoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewZoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._viewFitWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewFitPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewUseDpiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewRulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewRulerInchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewRulerMillimetersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewSep3ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._viewHighQualityPaintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._viewerControl = new RasterizeDocumentDemo.Viewer.ViewerControl();
         this._mainMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenuStrip
         // 
         this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._viewToolStripMenuItem});
         this._mainMenuStrip.Location = new System.Drawing.Point(0, 0);
         this._mainMenuStrip.Name = "_mainMenuStrip";
         this._mainMenuStrip.Size = new System.Drawing.Size(585, 24);
         this._mainMenuStrip.TabIndex = 0;
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._filePrintToolStripMenuItem,
            this._filePrintPreviewToolStripMenuItem,
            this._filePrintSetupToolStripMenuItem,
            this._fileSep1ToolStripMenuItem,
            this._fileCloseToolStripMenuItem});
         this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
         this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this._fileToolStripMenuItem.Text = "&File";
         this._fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this._fileToolStripMenuItem_DropDownOpening);
         // 
         // _filePrintToolStripMenuItem
         // 
         this._filePrintToolStripMenuItem.Name = "_filePrintToolStripMenuItem";
         this._filePrintToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
         this._filePrintToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._filePrintToolStripMenuItem.Text = "&Print...";
         this._filePrintToolStripMenuItem.Click += new System.EventHandler(this._filePrintToolStripMenuItem_Click);
         // 
         // _filePrintPreviewToolStripMenuItem
         // 
         this._filePrintPreviewToolStripMenuItem.Name = "_filePrintPreviewToolStripMenuItem";
         this._filePrintPreviewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._filePrintPreviewToolStripMenuItem.Text = "Print pre&view...";
         this._filePrintPreviewToolStripMenuItem.Click += new System.EventHandler(this._filePrintPreviewToolStripMenuItem_Click);
         // 
         // _filePrintSetupToolStripMenuItem
         // 
         this._filePrintSetupToolStripMenuItem.Name = "_filePrintSetupToolStripMenuItem";
         this._filePrintSetupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._filePrintSetupToolStripMenuItem.Text = "Print set&up...";
         this._filePrintSetupToolStripMenuItem.Click += new System.EventHandler(this._filePrintSetupToolStripMenuItem_Click);
         // 
         // _fileSep1ToolStripMenuItem
         // 
         this._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem";
         this._fileSep1ToolStripMenuItem.Size = new System.Drawing.Size(149, 6);
         // 
         // _fileCloseToolStripMenuItem
         // 
         this._fileCloseToolStripMenuItem.Name = "_fileCloseToolStripMenuItem";
         this._fileCloseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._fileCloseToolStripMenuItem.Text = "C&lose";
         this._fileCloseToolStripMenuItem.Click += new System.EventHandler(this._fileCloseToolStripMenuItem_Click);
         // 
         // _viewToolStripMenuItem
         // 
         this._viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._viewGotoToolStripMenuItem,
            this._viewSep1ToolStripMenuItem,
            this._viewZoomOutToolStripMenuItem,
            this._viewZoomInToolStripMenuItem,
            this._viewSep2ToolStripMenuItem,
            this._viewFitWidthToolStripMenuItem,
            this._viewFitPageToolStripMenuItem,
            this._viewUseDpiToolStripMenuItem,
            this._viewRulerToolStripMenuItem,
            this._viewSep3ToolStripMenuItem,
            this._viewHighQualityPaintToolStripMenuItem});
         this._viewToolStripMenuItem.Name = "_viewToolStripMenuItem";
         this._viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this._viewToolStripMenuItem.Text = "&View";
         this._viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this._viewToolStripMenuItem_DropDownOpening);
         // 
         // _viewGotoToolStripMenuItem
         // 
         this._viewGotoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._viewGotoFirstPageToolStripMenuItem,
            this._viewGotoPreviousPageToolStripMenuItem,
            this._viewGotoNextPageToolStripMenuItem,
            this._viewGotoLastPageToolStripMenuItem,
            this._viewGotoPageToolStripMenuItem});
         this._viewGotoToolStripMenuItem.Name = "_viewGotoToolStripMenuItem";
         this._viewGotoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this._viewGotoToolStripMenuItem.Text = "&Go to";
         this._viewGotoToolStripMenuItem.DropDownOpening += new System.EventHandler(this._viewGotoToolStripMenuItem_DropDownOpening);
         // 
         // _viewGotoFirstPageToolStripMenuItem
         // 
         this._viewGotoFirstPageToolStripMenuItem.Name = "_viewGotoFirstPageToolStripMenuItem";
         this._viewGotoFirstPageToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
         this._viewGotoFirstPageToolStripMenuItem.Text = "&First page";
         this._viewGotoFirstPageToolStripMenuItem.ToolTipText = "Goto the first page in the document";
         this._viewGotoFirstPageToolStripMenuItem.Click += new System.EventHandler(this._viewGotoPageToolStripMenuItem_Click);
         // 
         // _viewGotoPreviousPageToolStripMenuItem
         // 
         this._viewGotoPreviousPageToolStripMenuItem.Name = "_viewGotoPreviousPageToolStripMenuItem";
         this._viewGotoPreviousPageToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
         this._viewGotoPreviousPageToolStripMenuItem.Text = "P&revious page";
         this._viewGotoPreviousPageToolStripMenuItem.ToolTipText = "Goto the previous page in the document";
         this._viewGotoPreviousPageToolStripMenuItem.Click += new System.EventHandler(this._viewGotoPageToolStripMenuItem_Click);
         // 
         // _viewGotoNextPageToolStripMenuItem
         // 
         this._viewGotoNextPageToolStripMenuItem.Name = "_viewGotoNextPageToolStripMenuItem";
         this._viewGotoNextPageToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
         this._viewGotoNextPageToolStripMenuItem.Text = "&Next page";
         this._viewGotoNextPageToolStripMenuItem.ToolTipText = "Goto the next page in the document";
         this._viewGotoNextPageToolStripMenuItem.Click += new System.EventHandler(this._viewGotoPageToolStripMenuItem_Click);
         // 
         // _viewGotoLastPageToolStripMenuItem
         // 
         this._viewGotoLastPageToolStripMenuItem.Name = "_viewGotoLastPageToolStripMenuItem";
         this._viewGotoLastPageToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
         this._viewGotoLastPageToolStripMenuItem.Text = "&Last page";
         this._viewGotoLastPageToolStripMenuItem.ToolTipText = "Goto the last page in the document";
         this._viewGotoLastPageToolStripMenuItem.Click += new System.EventHandler(this._viewGotoPageToolStripMenuItem_Click);
         // 
         // _viewGotoPageToolStripMenuItem
         // 
         this._viewGotoPageToolStripMenuItem.Name = "_viewGotoPageToolStripMenuItem";
         this._viewGotoPageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                     | System.Windows.Forms.Keys.N)));
         this._viewGotoPageToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
         this._viewGotoPageToolStripMenuItem.Text = "&Page...";
         this._viewGotoPageToolStripMenuItem.ToolTipText = "Goto a specific page in the document";
         this._viewGotoPageToolStripMenuItem.Click += new System.EventHandler(this._viewGotoPageToolStripMenuItem_Click);
         // 
         // _viewSep1ToolStripMenuItem
         // 
         this._viewSep1ToolStripMenuItem.Name = "_viewSep1ToolStripMenuItem";
         this._viewSep1ToolStripMenuItem.Size = new System.Drawing.Size(182, 6);
         // 
         // _viewZoomOutToolStripMenuItem
         // 
         this._viewZoomOutToolStripMenuItem.Image = global::RasterizeDocumentDemo.Properties.Resources.ZoomOut;
         this._viewZoomOutToolStripMenuItem.Name = "_viewZoomOutToolStripMenuItem";
         this._viewZoomOutToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this._viewZoomOutToolStripMenuItem.Text = "Zoom &out";
         this._viewZoomOutToolStripMenuItem.ToolTipText = "Zoom out";
         this._viewZoomOutToolStripMenuItem.Click += new System.EventHandler(this._viewZoomOutToolStripMenuItem_Click);
         // 
         // _viewZoomInToolStripMenuItem
         // 
         this._viewZoomInToolStripMenuItem.Image = global::RasterizeDocumentDemo.Properties.Resources.ZoomIn;
         this._viewZoomInToolStripMenuItem.Name = "_viewZoomInToolStripMenuItem";
         this._viewZoomInToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this._viewZoomInToolStripMenuItem.Text = "Zoom &in";
         this._viewZoomInToolStripMenuItem.ToolTipText = "Zoom in";
         this._viewZoomInToolStripMenuItem.Click += new System.EventHandler(this._viewZoomInToolStripMenuItem_Click);
         // 
         // _viewSep2ToolStripMenuItem
         // 
         this._viewSep2ToolStripMenuItem.Name = "_viewSep2ToolStripMenuItem";
         this._viewSep2ToolStripMenuItem.Size = new System.Drawing.Size(182, 6);
         // 
         // _viewFitWidthToolStripMenuItem
         // 
         this._viewFitWidthToolStripMenuItem.Image = global::RasterizeDocumentDemo.Properties.Resources.FitPageWidth;
         this._viewFitWidthToolStripMenuItem.Name = "_viewFitWidthToolStripMenuItem";
         this._viewFitWidthToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this._viewFitWidthToolStripMenuItem.Text = "Fit &width";
         this._viewFitWidthToolStripMenuItem.ToolTipText = "Fit page width in window";
         this._viewFitWidthToolStripMenuItem.Click += new System.EventHandler(this._viewFitWidthToolStripMenuItem_Click);
         // 
         // _viewFitPageToolStripMenuItem
         // 
         this._viewFitPageToolStripMenuItem.Image = global::RasterizeDocumentDemo.Properties.Resources.FitPage;
         this._viewFitPageToolStripMenuItem.Name = "_viewFitPageToolStripMenuItem";
         this._viewFitPageToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this._viewFitPageToolStripMenuItem.Text = "&Fit page";
         this._viewFitPageToolStripMenuItem.ToolTipText = "Fit entire page in window";
         this._viewFitPageToolStripMenuItem.Click += new System.EventHandler(this._viewFitPageToolStripMenuItem_Click);
         // 
         // _viewUseDpiToolStripMenuItem
         // 
         this._viewUseDpiToolStripMenuItem.Image = global::RasterizeDocumentDemo.Properties.Resources.UseDpi;
         this._viewUseDpiToolStripMenuItem.Name = "_viewUseDpiToolStripMenuItem";
         this._viewUseDpiToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this._viewUseDpiToolStripMenuItem.Text = "&Use image resolution";
         this._viewUseDpiToolStripMenuItem.ToolTipText = "Use the image actual resolution instead of the screen when viewing";
         this._viewUseDpiToolStripMenuItem.Click += new System.EventHandler(this._viewUseDpiToolStripMenuItem_Click);
         // 
         // _viewRulerToolStripMenuItem
         // 
         this._viewRulerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._viewRulerInchesToolStripMenuItem,
            this._viewRulerMillimetersToolStripMenuItem});
         this._viewRulerToolStripMenuItem.Name = "_viewRulerToolStripMenuItem";
         this._viewRulerToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this._viewRulerToolStripMenuItem.Text = "&Ruler";
         this._viewRulerToolStripMenuItem.DropDownOpening += new System.EventHandler(this._viewRulerToolStripMenuItem_DropDownOpening);
         // 
         // _viewRulerInchesToolStripMenuItem
         // 
         this._viewRulerInchesToolStripMenuItem.Name = "_viewRulerInchesToolStripMenuItem";
         this._viewRulerInchesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
         this._viewRulerInchesToolStripMenuItem.Text = "&Inches";
         this._viewRulerInchesToolStripMenuItem.ToolTipText = "Use inches unit on the ruler (English)";
         this._viewRulerInchesToolStripMenuItem.Click += new System.EventHandler(this._viewRulerInchesToolStripMenuItem_Click);
         // 
         // _viewRulerMillimetersToolStripMenuItem
         // 
         this._viewRulerMillimetersToolStripMenuItem.Name = "_viewRulerMillimetersToolStripMenuItem";
         this._viewRulerMillimetersToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
         this._viewRulerMillimetersToolStripMenuItem.Text = "&Millimeters";
         this._viewRulerMillimetersToolStripMenuItem.ToolTipText = "Use millimeters unit on the ruler (Metric)";
         this._viewRulerMillimetersToolStripMenuItem.Click += new System.EventHandler(this._viewRulerMillimetersToolStripMenuItem_Click);
         // 
         // _viewSep3ToolStripMenuItem
         // 
         this._viewSep3ToolStripMenuItem.Name = "_viewSep3ToolStripMenuItem";
         this._viewSep3ToolStripMenuItem.Size = new System.Drawing.Size(182, 6);
         // 
         // _viewHighQualityPaintToolStripMenuItem
         // 
         this._viewHighQualityPaintToolStripMenuItem.Name = "_viewHighQualityPaintToolStripMenuItem";
         this._viewHighQualityPaintToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this._viewHighQualityPaintToolStripMenuItem.Text = "&High quality paint";
         this._viewHighQualityPaintToolStripMenuItem.Click += new System.EventHandler(this._viewHighQualityPaintToolStripMenuItem_Click);
         // 
         // _viewerControl
         // 
         this._viewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this._viewerControl.Location = new System.Drawing.Point(0, 24);
         this._viewerControl.Name = "_viewerControl";
         this._viewerControl.Size = new System.Drawing.Size(585, 536);
         this._viewerControl.TabIndex = 1;
         // 
         // ViewerForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(585, 560);
         this.Controls.Add(this._viewerControl);
         this.Controls.Add(this._mainMenuStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._mainMenuStrip;
         this.Name = "ViewerForm";
         this.Text = "ViewerForm";
         this._mainMenuStrip.ResumeLayout(false);
         this._mainMenuStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _mainMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fileCloseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewZoomOutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewZoomInToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _viewSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewFitWidthToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewFitPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewUseDpiToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewRulerToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewRulerInchesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewRulerMillimetersToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _viewSep3ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewHighQualityPaintToolStripMenuItem;
      private ViewerControl _viewerControl;
      private System.Windows.Forms.ToolStripMenuItem _viewGotoToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewGotoFirstPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewGotoPreviousPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewGotoNextPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewGotoLastPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewGotoPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _viewSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _filePrintToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _filePrintPreviewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _filePrintSetupToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep1ToolStripMenuItem;
   }
}