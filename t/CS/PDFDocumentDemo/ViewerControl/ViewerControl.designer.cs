namespace PDFDocumentDemo.ViewerControl
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
         if (disposing && (components != null))
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerControl));
         this._pageInfoLabel = new System.Windows.Forms.Label();
         this._zoomToSelectionModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._panModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._selectModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._mousePositionLabel = new System.Windows.Forms.Label();
         this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._fitPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._pageToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
         this._nextPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._previousPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStrip = new System.Windows.Forms.ToolStrip();
         this._pageToolStripLabel = new System.Windows.Forms.ToolStripLabel();
         this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._zoomOutToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomInToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
         this._fitPageWidthToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._highlightObjectsToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._rasterImageViewer = new Leadtools.Annotations.WinForms.AutomationImageViewer();
         this._highlightTextModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _pageInfoLabel
         // 
         this._pageInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
         this._pageInfoLabel.Location = new System.Drawing.Point(0, 25);
         this._pageInfoLabel.Name = "_pageInfoLabel";
         this._pageInfoLabel.Size = new System.Drawing.Size(619, 13);
         this._pageInfoLabel.TabIndex = 10;
         this._pageInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _zoomToSelectionModeToolStripButton
         // 
         this._zoomToSelectionModeToolStripButton.CheckOnClick = true;
         this._zoomToSelectionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomToSelectionModeToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.ZoomSelection;
         this._zoomToSelectionModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton";

         this._zoomToSelectionModeToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomToSelectionModeToolStripButton.ToolTipText = resources.GetString("resx_ZoomToSelectionMode");
         this._zoomToSelectionModeToolStripButton.Click += new System.EventHandler(this._zoomToSelectionModeToolStripButton_Click);
         // 
         // _panModeToolStripButton
         // 
         this._panModeToolStripButton.CheckOnClick = true;
         this._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._panModeToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.PanMode;
         this._panModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._panModeToolStripButton.Name = "_panModeToolStripButton";
         this._panModeToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._panModeToolStripButton.ToolTipText = resources.GetString("resx_PanMode");
         this._panModeToolStripButton.Click += new System.EventHandler(this._panModeToolStripButton_Click);
         // 
         // _selectModeToolStripButton
         // 
         this._selectModeToolStripButton.CheckOnClick = true;
         this._selectModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._selectModeToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.SelectMode;
         this._selectModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._selectModeToolStripButton.Name = "_selectModeToolStripButton";
         this._selectModeToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._selectModeToolStripButton.ToolTipText = resources.GetString("resx_Select");
         this._selectModeToolStripButton.Click += new System.EventHandler(this._selectModeToolStripButton_Click);
         // 
         // _mousePositionLabel
         // 
         this._mousePositionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._mousePositionLabel.Location = new System.Drawing.Point(0, 408);
         this._mousePositionLabel.Name = "_mousePositionLabel";
         this._mousePositionLabel.Size = new System.Drawing.Size(619, 13);
         this._mousePositionLabel.TabIndex = 12;
         this._mousePositionLabel.Text = "_mousePositionLabel";
         // 
         // _toolStripSeparator2
         // 
         this._toolStripSeparator2.Name = "_toolStripSeparator2";
         this._toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // _fitPageToolStripButton
         // 
         this._fitPageToolStripButton.CheckOnClick = true;
         this._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.FitPage;
         this._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._fitPageToolStripButton.Name = "_fitPageToolStripButton";
         this._fitPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._fitPageToolStripButton.ToolTipText = resources.GetString("resx_FitEntirePageInWindow");
         this._fitPageToolStripButton.Click += new System.EventHandler(this._fitPageToolStripButton_Click);
         // 
         // _pageToolStripTextBox
         // 
         this._pageToolStripTextBox.Name = "_pageToolStripTextBox";
         this._pageToolStripTextBox.Size = new System.Drawing.Size(40, 25);
         this._pageToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this._pageToolStripTextBox.ToolTipText = resources.GetString("resx_CurrentPageNumber");
         this._pageToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._pageToolStripTextBox_KeyPress);
         // 
         // _nextPageToolStripButton
         // 
         this._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._nextPageToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.NextPage;
         this._nextPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._nextPageToolStripButton.Name = "_nextPageToolStripButton";
         this._nextPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._nextPageToolStripButton.ToolTipText = resources.GetString("resx_GoToNextPage");
         this._nextPageToolStripButton.Click += new System.EventHandler(this._nextPageToolStripButton_Click);
         // 
         // _previousPageToolStripButton
         // 
         this._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._previousPageToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.PreviousPage;
         this._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._previousPageToolStripButton.Name = "_previousPageToolStripButton";
         this._previousPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._previousPageToolStripButton.ToolTipText = resources.GetString("resx_GoToPreviousPage");
         this._previousPageToolStripButton.Click += new System.EventHandler(this._previousPageToolStripButton_Click);
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
            this._toolStripSeparator2,
            this._selectModeToolStripButton,
            this._highlightTextModeToolStripButton,
            this._panModeToolStripButton,
            this._zoomToSelectionModeToolStripButton,
            this._toolStripSeparator3,
            this._highlightObjectsToolStripButton});
         this._toolStrip.Location = new System.Drawing.Point(0, 0);
         this._toolStrip.Name = "_toolStrip";
         this._toolStrip.Size = new System.Drawing.Size(619, 25);
         this._toolStrip.TabIndex = 11;
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
         this._zoomOutToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.ZoomOut;
         this._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomOutToolStripButton.Name = "_zoomOutToolStripButton";
         this._zoomOutToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomOutToolStripButton.ToolTipText = resources.GetString("resx_ZoomOut");
         this._zoomOutToolStripButton.Click += new System.EventHandler(this._zoomOutToolStripButton_Click);
         // 
         // _zoomInToolStripButton
         // 
         this._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomInToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.ZoomIn;
         this._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomInToolStripButton.Name = "_zoomInToolStripButton";
         this._zoomInToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomInToolStripButton.ToolTipText = resources.GetString("resx_ZoomIn");
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
            resources.GetString("resx_ActualSize"),
            resources.GetString("resx_FitPage"),
            resources.GetString("resx_FitWidth")});
         this._zoomToolStripComboBox.Name = "_zoomToolStripComboBox";
         this._zoomToolStripComboBox.Size = new System.Drawing.Size(80, 25);
         this._zoomToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this._zoomToolStripComboBox_SelectedIndexChanged);
         this._zoomToolStripComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._zoomToolStripComboBox_KeyPress);
         // 
         // _fitPageWidthToolStripButton
         // 
         this._fitPageWidthToolStripButton.CheckOnClick = true;
         this._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageWidthToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.FitPageWidth;
         this._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton";
         this._fitPageWidthToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._fitPageWidthToolStripButton.ToolTipText = resources.GetString("resx_FitPageWidthInWindow");
         this._fitPageWidthToolStripButton.Click += new System.EventHandler(this._fitPageWidthToolStripButton_Click);
         // 
         // _toolStripSeparator3
         // 
         this._toolStripSeparator3.Name = "_toolStripSeparator3";
         this._toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // _highlightObjectsToolStripButton
         // 
         this._highlightObjectsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._highlightObjectsToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.HighlightObjects;
         this._highlightObjectsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._highlightObjectsToolStripButton.Name = "_highlightObjectsToolStripButton";
         this._highlightObjectsToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._highlightObjectsToolStripButton.ToolTipText = resources.GetString("resx_HighlightTheObjects");
         this._highlightObjectsToolStripButton.Click += new System.EventHandler(this._highlightObjectsToolStripButton_Click);
         // 
         // _rasterImageViewer
         // 
         this._rasterImageViewer.ImageRegionRenderMode = Leadtools.Controls.ControlRegionRenderMode.None;
         this._rasterImageViewer.AutomationAntiAlias = false;
         this._rasterImageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._rasterImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._rasterImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._rasterImageViewer.ScrollMode = Leadtools.Controls.ControlScrollMode.Auto;
         this._rasterImageViewer.ViewMargin = new System.Windows.Forms.Padding(1);
         this._rasterImageViewer.ImageBorderThickness = 2;
         this._rasterImageViewer.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageViewer.Location = new System.Drawing.Point(0, 38);
         this._rasterImageViewer.Name = "_rasterImageViewer";
         this._rasterImageViewer.Size = new System.Drawing.Size(619, 370);
         this._rasterImageViewer.Zoom(Leadtools.Controls.ControlSizeMode.FitAlways, 1, _rasterImageViewer.DefaultZoomOrigin);
         this._rasterImageViewer.TabIndex = 13;
         this._rasterImageViewer.UseDpi = true;
         this._rasterImageViewer.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageViewer.TransformChanged += new System.EventHandler(this._rasterImageViewer_TransformChanged);
         this._rasterImageViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this._rasterImageViewer_MouseDown);
         this._rasterImageViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this._rasterImageViewer_MouseMove);
         this._rasterImageViewer.PostRender +=new System.EventHandler<Leadtools.Controls.ImageViewerRenderEventArgs>(_rasterImageViewer_PostRender);
         // 
         // _highlightTextModeToolStripButton
         // 
         this._highlightTextModeToolStripButton.CheckOnClick = true;
         this._highlightTextModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._highlightTextModeToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.HighlightText;
         this._highlightTextModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._highlightTextModeToolStripButton.Name = "_highlightTextModeToolStripButton";
         this._highlightTextModeToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._highlightTextModeToolStripButton.ToolTipText = resources.GetString("resx_SelectTheTextToHighlight");
         this._highlightTextModeToolStripButton.Click += new System.EventHandler(this._highlightTextModeToolStripButton_Click);
         // 
         // ViewerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._rasterImageViewer);
         this.Controls.Add(this._pageInfoLabel);
         this.Controls.Add(this._mousePositionLabel);
         this.Controls.Add(this._toolStrip);
         this.Name = "ViewerControl";
         this.Size = new System.Drawing.Size(619, 421);
         this._toolStrip.ResumeLayout(false);
         this._toolStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _pageInfoLabel;
      private System.Windows.Forms.ToolStripButton _zoomToSelectionModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _panModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _selectModeToolStripButton;
      private System.Windows.Forms.Label _mousePositionLabel;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton _fitPageToolStripButton;
      private System.Windows.Forms.ToolStripTextBox _pageToolStripTextBox;
      private System.Windows.Forms.ToolStripButton _nextPageToolStripButton;
      private System.Windows.Forms.ToolStripButton _previousPageToolStripButton;
      private System.Windows.Forms.ToolStrip _toolStrip;
      private System.Windows.Forms.ToolStripLabel _pageToolStripLabel;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton _zoomOutToolStripButton;
      private System.Windows.Forms.ToolStripButton _zoomInToolStripButton;
      private System.Windows.Forms.ToolStripComboBox _zoomToolStripComboBox;
      private System.Windows.Forms.ToolStripButton _fitPageWidthToolStripButton;
      private Leadtools.Annotations.WinForms.AutomationImageViewer _rasterImageViewer;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton _highlightObjectsToolStripButton;
      private System.Windows.Forms.ToolStripButton _highlightTextModeToolStripButton;
   }
}
