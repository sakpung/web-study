namespace RasterizeDocumentDemo.Viewer
{
   partial class ViewerControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._imageInfoPanel = new System.Windows.Forms.Panel();
         this._imageInfoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
         this._imageInfoFileSizeLabel = new System.Windows.Forms.Label();
         this._imageInfoFileSizeValueLabel = new System.Windows.Forms.Label();
         this._imageInfoMemorySizeValueLabel = new System.Windows.Forms.Label();
         this._imageInfoBitsPerPixelValueLabel = new System.Windows.Forms.Label();
         this._imageInfoPageSizeLabel = new System.Windows.Forms.Label();
         this._imageInfoPageSizeLogicalLabel = new System.Windows.Forms.Label();
         this._imageInfoPageSizePixelsLabel = new System.Windows.Forms.Label();
         this._imageInfoPageSizeResolutionLabel = new System.Windows.Forms.Label();
         this._imageInfoMemorySizeLabel = new System.Windows.Forms.Label();
         this._imageInfoBitsPerPixelLabel = new System.Windows.Forms.Label();
         this._toolStrip = new System.Windows.Forms.ToolStrip();
         this._previousPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._nextPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._pageToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
         this._pageToolStripLabel = new System.Windows.Forms.ToolStripLabel();
         this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._zoomOutToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomInToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
         this._fitPageWidthToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._fitPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._useDpiToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._panModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomToSelectionModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._mousePositionLabel = new System.Windows.Forms.Label();
         this._imageViewer = new Leadtools.Controls.ImageViewer();
         this._imageList = new Leadtools.Controls.ImageViewer(new Leadtools.Controls.ImageViewerVerticalViewLayout() { Columns = 1 });
         this._imageInfoPanel.SuspendLayout();
         this._imageInfoTableLayoutPanel.SuspendLayout();
         this._toolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _imageInfoPanel
         // 
         this._imageInfoPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._imageInfoPanel.Controls.Add(this._imageInfoTableLayoutPanel);
         this._imageInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
         this._imageInfoPanel.Location = new System.Drawing.Point(0, 0);
         this._imageInfoPanel.Name = "_imageInfoPanel";
         this._imageInfoPanel.Size = new System.Drawing.Size(850, 68);
         this._imageInfoPanel.TabIndex = 7;
         // 
         // _imageInfoTableLayoutPanel
         // 
         this._imageInfoTableLayoutPanel.ColumnCount = 4;
         this._imageInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
         this._imageInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this._imageInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
         this._imageInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
         this._imageInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this._imageInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this._imageInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this._imageInfoTableLayoutPanel.Controls.Add(this._imageInfoFileSizeLabel, 0, 0);
         this._imageInfoTableLayoutPanel.Controls.Add(this._imageInfoFileSizeValueLabel, 1, 0);
         this._imageInfoTableLayoutPanel.Controls.Add(this._imageInfoMemorySizeValueLabel, 1, 1);
         this._imageInfoTableLayoutPanel.Controls.Add(this._imageInfoBitsPerPixelValueLabel, 1, 2);
         this._imageInfoTableLayoutPanel.Controls.Add(this._imageInfoPageSizeLabel, 2, 0);
         this._imageInfoTableLayoutPanel.Controls.Add(this._imageInfoPageSizeLogicalLabel, 3, 0);
         this._imageInfoTableLayoutPanel.Controls.Add(this._imageInfoPageSizePixelsLabel, 3, 1);
         this._imageInfoTableLayoutPanel.Controls.Add(this._imageInfoPageSizeResolutionLabel, 3, 2);
         this._imageInfoTableLayoutPanel.Controls.Add(this._imageInfoMemorySizeLabel, 0, 1);
         this._imageInfoTableLayoutPanel.Controls.Add(this._imageInfoBitsPerPixelLabel, 0, 2);
         this._imageInfoTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
         this._imageInfoTableLayoutPanel.Name = "_imageInfoTableLayoutPanel";
         this._imageInfoTableLayoutPanel.RowCount = 4;
         this._imageInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this._imageInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this._imageInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this._imageInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this._imageInfoTableLayoutPanel.Size = new System.Drawing.Size(546, 60);
         this._imageInfoTableLayoutPanel.TabIndex = 7;
         // 
         // _imageInfoFileSizeLabel
         // 
         this._imageInfoFileSizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageInfoFileSizeLabel.Location = new System.Drawing.Point(3, 0);
         this._imageInfoFileSizeLabel.Name = "_imageInfoFileSizeLabel";
         this._imageInfoFileSizeLabel.Size = new System.Drawing.Size(74, 20);
         this._imageInfoFileSizeLabel.TabIndex = 0;
         this._imageInfoFileSizeLabel.Text = "File size:";
         this._imageInfoFileSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _imageInfoFileSizeValueLabel
         // 
         this._imageInfoFileSizeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageInfoFileSizeValueLabel.Location = new System.Drawing.Point(83, 0);
         this._imageInfoFileSizeValueLabel.Name = "_imageInfoFileSizeValueLabel";
         this._imageInfoFileSizeValueLabel.Size = new System.Drawing.Size(194, 20);
         this._imageInfoFileSizeValueLabel.TabIndex = 1;
         this._imageInfoFileSizeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _imageInfoMemorySizeValueLabel
         // 
         this._imageInfoMemorySizeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageInfoMemorySizeValueLabel.Location = new System.Drawing.Point(83, 20);
         this._imageInfoMemorySizeValueLabel.Name = "_imageInfoMemorySizeValueLabel";
         this._imageInfoMemorySizeValueLabel.Size = new System.Drawing.Size(194, 20);
         this._imageInfoMemorySizeValueLabel.TabIndex = 3;
         this._imageInfoMemorySizeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _imageInfoBitsPerPixelValueLabel
         // 
         this._imageInfoBitsPerPixelValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageInfoBitsPerPixelValueLabel.Location = new System.Drawing.Point(83, 40);
         this._imageInfoBitsPerPixelValueLabel.Name = "_imageInfoBitsPerPixelValueLabel";
         this._imageInfoBitsPerPixelValueLabel.Size = new System.Drawing.Size(194, 20);
         this._imageInfoBitsPerPixelValueLabel.TabIndex = 5;
         this._imageInfoBitsPerPixelValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _imageInfoPageSizeLabel
         // 
         this._imageInfoPageSizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageInfoPageSizeLabel.Location = new System.Drawing.Point(283, 0);
         this._imageInfoPageSizeLabel.Name = "_imageInfoPageSizeLabel";
         this._imageInfoPageSizeLabel.Size = new System.Drawing.Size(74, 20);
         this._imageInfoPageSizeLabel.TabIndex = 6;
         this._imageInfoPageSizeLabel.Text = "Page size:";
         this._imageInfoPageSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _imageInfoPageSizeLogicalLabel
         // 
         this._imageInfoPageSizeLogicalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageInfoPageSizeLogicalLabel.Location = new System.Drawing.Point(363, 0);
         this._imageInfoPageSizeLogicalLabel.Name = "_imageInfoPageSizeLogicalLabel";
         this._imageInfoPageSizeLogicalLabel.Size = new System.Drawing.Size(180, 20);
         this._imageInfoPageSizeLogicalLabel.TabIndex = 7;
         this._imageInfoPageSizeLogicalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _imageInfoPageSizePixelsLabel
         // 
         this._imageInfoPageSizePixelsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageInfoPageSizePixelsLabel.Location = new System.Drawing.Point(363, 20);
         this._imageInfoPageSizePixelsLabel.Name = "_imageInfoPageSizePixelsLabel";
         this._imageInfoPageSizePixelsLabel.Size = new System.Drawing.Size(180, 20);
         this._imageInfoPageSizePixelsLabel.TabIndex = 8;
         this._imageInfoPageSizePixelsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _imageInfoPageSizeResolutionLabel
         // 
         this._imageInfoPageSizeResolutionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageInfoPageSizeResolutionLabel.Location = new System.Drawing.Point(363, 40);
         this._imageInfoPageSizeResolutionLabel.Name = "_imageInfoPageSizeResolutionLabel";
         this._imageInfoPageSizeResolutionLabel.Size = new System.Drawing.Size(180, 20);
         this._imageInfoPageSizeResolutionLabel.TabIndex = 9;
         this._imageInfoPageSizeResolutionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _imageInfoMemorySizeLabel
         // 
         this._imageInfoMemorySizeLabel.AutoSize = true;
         this._imageInfoMemorySizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageInfoMemorySizeLabel.Location = new System.Drawing.Point(3, 20);
         this._imageInfoMemorySizeLabel.Name = "_imageInfoMemorySizeLabel";
         this._imageInfoMemorySizeLabel.Size = new System.Drawing.Size(74, 20);
         this._imageInfoMemorySizeLabel.TabIndex = 10;
         this._imageInfoMemorySizeLabel.Text = "Memory size:";
         this._imageInfoMemorySizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _imageInfoBitsPerPixelLabel
         // 
         this._imageInfoBitsPerPixelLabel.AutoSize = true;
         this._imageInfoBitsPerPixelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageInfoBitsPerPixelLabel.Location = new System.Drawing.Point(3, 40);
         this._imageInfoBitsPerPixelLabel.Name = "_imageInfoBitsPerPixelLabel";
         this._imageInfoBitsPerPixelLabel.Size = new System.Drawing.Size(74, 20);
         this._imageInfoBitsPerPixelLabel.TabIndex = 11;
         this._imageInfoBitsPerPixelLabel.Text = "Bits per pixel:";
         this._imageInfoBitsPerPixelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _toolStrip
         // 
         this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._previousPageToolStripButton,
            this._nextPageToolStripButton,
            this._pageToolStripTextBox,
            this._pageToolStripLabel,
            this._toolStripSeparator1,
            this._zoomOutToolStripButton,
            this._zoomInToolStripButton,
            this._zoomToolStripComboBox,
            this._fitPageWidthToolStripButton,
            this._fitPageToolStripButton,
            this._useDpiToolStripButton,
            this._toolStripSeparator2,
            this._panModeToolStripButton,
            this._zoomToSelectionModeToolStripButton});
         this._toolStrip.Location = new System.Drawing.Point(0, 68);
         this._toolStrip.Name = "_toolStrip";
         this._toolStrip.Size = new System.Drawing.Size(850, 25);
         this._toolStrip.TabIndex = 8;
         // 
         // _previousPageToolStripButton
         // 
         this._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._previousPageToolStripButton.Image = global::RasterizeDocumentDemo.Properties.Resources.PreviousPage;
         this._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._previousPageToolStripButton.Name = "_previousPageToolStripButton";
         this._previousPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._previousPageToolStripButton.ToolTipText = "Go to previous page in the document";
         this._previousPageToolStripButton.Click += new System.EventHandler(this._previousPageToolStripButton_Click);
         // 
         // _nextPageToolStripButton
         // 
         this._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._nextPageToolStripButton.Image = global::RasterizeDocumentDemo.Properties.Resources.NextPage;
         this._nextPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._nextPageToolStripButton.Name = "_nextPageToolStripButton";
         this._nextPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._nextPageToolStripButton.ToolTipText = "Go to next page in the document";
         this._nextPageToolStripButton.Click += new System.EventHandler(this._nextPageToolStripButton_Click);
         // 
         // _pageToolStripTextBox
         // 
         this._pageToolStripTextBox.Name = "_pageToolStripTextBox";
         this._pageToolStripTextBox.Size = new System.Drawing.Size(40, 25);
         this._pageToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this._pageToolStripTextBox.ToolTipText = "Current page number in the document";
         this._pageToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._pageToolStripTextBox_KeyPress);
         // 
         // _pageToolStripLabel
         // 
         this._pageToolStripLabel.Name = "_pageToolStripLabel";
         this._pageToolStripLabel.Size = new System.Drawing.Size(48, 22);
         this._pageToolStripLabel.Text = "/ WWW";
         // 
         // _toolStripSeparator1
         // 
         this._toolStripSeparator1.Name = "_toolStripSeparator1";
         this._toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // _zoomOutToolStripButton
         // 
         this._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomOutToolStripButton.Image = global::RasterizeDocumentDemo.Properties.Resources.ZoomOut;
         this._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomOutToolStripButton.Name = "_zoomOutToolStripButton";
         this._zoomOutToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomOutToolStripButton.ToolTipText = "Zoom out";
         this._zoomOutToolStripButton.Click += new System.EventHandler(this._zoomOutToolStripButton_Click);
         // 
         // _zoomInToolStripButton
         // 
         this._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomInToolStripButton.Image = global::RasterizeDocumentDemo.Properties.Resources.ZoomIn;
         this._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomInToolStripButton.Name = "_zoomInToolStripButton";
         this._zoomInToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomInToolStripButton.ToolTipText = "Zoom In";
         this._zoomInToolStripButton.Click += new System.EventHandler(this._zoomInToolStripButton_Click);
         // 
         // _zoomToolStripComboBox
         // 
         this._zoomToolStripComboBox.DropDownWidth = 80;
         this._zoomToolStripComboBox.Items.AddRange(new object[] {
            "10%",
            "25%",
            "50%",
            "75%",
            "100%",
            "125%",
            "200%",
            "400%",
            "800%",
            "1600%",
            "2400%",
            "3200%",
            "6400%",
            "Actual Size",
            "Fit Page",
            "Fit Width"});
         this._zoomToolStripComboBox.Name = "_zoomToolStripComboBox";
         this._zoomToolStripComboBox.Size = new System.Drawing.Size(80, 25);
         this._zoomToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this._zoomToolStripComboBox_SelectedIndexChanged);
         this._zoomToolStripComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._zoomToolStripComboBox_KeyPress);
         // 
         // _fitPageWidthToolStripButton
         // 
         this._fitPageWidthToolStripButton.CheckOnClick = true;
         this._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageWidthToolStripButton.Image = global::RasterizeDocumentDemo.Properties.Resources.FitPageWidth;
         this._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton";
         this._fitPageWidthToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._fitPageWidthToolStripButton.ToolTipText = "Fit page width in window";
         this._fitPageWidthToolStripButton.Click += new System.EventHandler(this._fitPageWidthToolStripButton_Click);
         // 
         // _fitPageToolStripButton
         // 
         this._fitPageToolStripButton.CheckOnClick = true;
         this._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageToolStripButton.Image = global::RasterizeDocumentDemo.Properties.Resources.FitPage;
         this._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._fitPageToolStripButton.Name = "_fitPageToolStripButton";
         this._fitPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._fitPageToolStripButton.ToolTipText = "Fit entire page in window";
         this._fitPageToolStripButton.Click += new System.EventHandler(this._fitPageToolStripButton_Click);
         // 
         // _useDpiToolStripButton
         // 
         this._useDpiToolStripButton.CheckOnClick = true;
         this._useDpiToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._useDpiToolStripButton.Image = global::RasterizeDocumentDemo.Properties.Resources.UseDpi;
         this._useDpiToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._useDpiToolStripButton.Name = "_useDpiToolStripButton";
         this._useDpiToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._useDpiToolStripButton.ToolTipText = "Use the image actual resolution instead of the screen when viewing";
         this._useDpiToolStripButton.Click += new System.EventHandler(this._useDpiToolStripButton_Click);
         // 
         // _toolStripSeparator2
         // 
         this._toolStripSeparator2.Name = "_toolStripSeparator2";
         this._toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // _panModeToolStripButton
         // 
         this._panModeToolStripButton.CheckOnClick = true;
         this._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._panModeToolStripButton.Image = global::RasterizeDocumentDemo.Properties.Resources.PanMode;
         this._panModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._panModeToolStripButton.Name = "_panModeToolStripButton";
         this._panModeToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._panModeToolStripButton.ToolTipText = "Pan mode";
         this._panModeToolStripButton.Click += new System.EventHandler(this._panModeToolStripButton_Click);
         // 
         // _zoomToSelectionModeToolStripButton
         // 
         this._zoomToSelectionModeToolStripButton.CheckOnClick = true;
         this._zoomToSelectionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomToSelectionModeToolStripButton.Image = global::RasterizeDocumentDemo.Properties.Resources.ZoomSelection;
         this._zoomToSelectionModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton";
         this._zoomToSelectionModeToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomToSelectionModeToolStripButton.ToolTipText = "Zoom to selection mode";
         this._zoomToSelectionModeToolStripButton.Click += new System.EventHandler(this._zoomToSelectionModeToolStripButton_Click);
         // 
         // _mousePositionLabel
         // 
         this._mousePositionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._mousePositionLabel.Location = new System.Drawing.Point(0, 568);
         this._mousePositionLabel.Name = "_mousePositionLabel";
         this._mousePositionLabel.Size = new System.Drawing.Size(850, 13);
         this._mousePositionLabel.TabIndex = 9;
         this._mousePositionLabel.Text = "_mousePositionLabel";
         this._mousePositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _rasterImageViewer
         // 
         this._imageViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._imageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._imageViewer.ViewPadding = new System.Windows.Forms.Padding(10);
         this._imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this._imageViewer.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._imageViewer.Location = new System.Drawing.Point(229, 122);
         this._imageViewer.Name = "_imageViewer";
         this._imageViewer.Size = new System.Drawing.Size(496, 220);
         this._imageViewer.TabIndex = 10;
         this._imageViewer.UseDpi = true;
         this._imageViewer.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._imageViewer.TransformChanged += new System.EventHandler(this._imageViewer_TransformChanged);
         this._imageViewer.MouseMove +=  new System.Windows.Forms.MouseEventHandler(this._imageViewer_MouseMove);
         // 
         // _rasterImageList
         // 
         this._imageList.BackColor = System.Drawing.SystemColors.Control;
         this._imageList.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._imageList.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._imageList.ItemSpacing = new Leadtools.LeadSize(20, 20);
         this._imageList.ItemBorderThickness = 2;
         this._imageList.SelectedItemBorderColor = System.Drawing.Color.Blue;
         this._imageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this._imageList.Dock = System.Windows.Forms.DockStyle.Left;
         this._imageList.ItemSize = new Leadtools.LeadSize(160, 160);
         this._imageList.ItemSizeMode = Leadtools.Controls.ControlSizeMode.Fit;
         this._imageList.Location = new System.Drawing.Point(0, 93);
         this._imageList.Name = "_imageList";
         this._imageList.Size = new System.Drawing.Size(197, 475);
         this._imageList.TabIndex = 11;
         this._imageList.InteractiveModes.Add(new Leadtools.Controls.ImageViewerSelectItemsInteractiveMode() { SelectionMode = Leadtools.Controls.ImageViewerSelectionMode.Single });
         this._imageList.SelectedItemsChanged += new System.EventHandler(_imageList_SelectedItemsChanged);
         // 
         // ViewerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._imageList);
         this.Controls.Add(this._imageViewer);
         this.Controls.Add(this._mousePositionLabel);
         this.Controls.Add(this._toolStrip);
         this.Controls.Add(this._imageInfoPanel);
         this.Name = "ViewerControl";
         this.Size = new System.Drawing.Size(850, 581);
         this._imageInfoPanel.ResumeLayout(false);
         this._imageInfoTableLayoutPanel.ResumeLayout(false);
         this._imageInfoTableLayoutPanel.PerformLayout();
         this._toolStrip.ResumeLayout(false);
         this._toolStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel _imageInfoPanel;
      private System.Windows.Forms.TableLayoutPanel _imageInfoTableLayoutPanel;
      private System.Windows.Forms.Label _imageInfoFileSizeLabel;
      private System.Windows.Forms.Label _imageInfoFileSizeValueLabel;
      private System.Windows.Forms.Label _imageInfoMemorySizeValueLabel;
      private System.Windows.Forms.Label _imageInfoBitsPerPixelValueLabel;
      private System.Windows.Forms.Label _imageInfoPageSizeLabel;
      private System.Windows.Forms.Label _imageInfoPageSizeLogicalLabel;
      private System.Windows.Forms.Label _imageInfoPageSizePixelsLabel;
      private System.Windows.Forms.Label _imageInfoPageSizeResolutionLabel;
      private System.Windows.Forms.ToolStrip _toolStrip;
      private System.Windows.Forms.ToolStripButton _zoomOutToolStripButton;
      private System.Windows.Forms.ToolStripButton _zoomInToolStripButton;
      private System.Windows.Forms.ToolStripComboBox _zoomToolStripComboBox;
      private System.Windows.Forms.ToolStripButton _fitPageWidthToolStripButton;
      private System.Windows.Forms.ToolStripButton _fitPageToolStripButton;
      private System.Windows.Forms.ToolStripButton _useDpiToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton _panModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _zoomToSelectionModeToolStripButton;
      private System.Windows.Forms.Label _mousePositionLabel;
      private Leadtools.Controls.ImageViewer _imageViewer;
      private System.Windows.Forms.Label _imageInfoMemorySizeLabel;
      private System.Windows.Forms.Label _imageInfoBitsPerPixelLabel;
      private Leadtools.Controls.ImageViewer _imageList;
      private System.Windows.Forms.ToolStripButton _previousPageToolStripButton;
      private System.Windows.Forms.ToolStripButton _nextPageToolStripButton;
      private System.Windows.Forms.ToolStripTextBox _pageToolStripTextBox;
      private System.Windows.Forms.ToolStripLabel _pageToolStripLabel;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
   }
}
