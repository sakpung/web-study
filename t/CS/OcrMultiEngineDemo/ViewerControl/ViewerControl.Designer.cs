namespace OcrMultiEngineDemo.ViewerControl
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
         this._titleLabel = new System.Windows.Forms.Label();
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
         this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._selectModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._panModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomToSelectionModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._drawZoneModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._zonePropertiesToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._showZonesToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._showZoneNameToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._rasterImageViewer = new Leadtools.Annotations.WinForms.AutomationImageViewer();
         this._splitContainer = new System.Windows.Forms.SplitContainer();
         this._mousePositionLabel = new System.Windows.Forms.Label();
         this._cellIndexLabel = new System.Windows.Forms.Label();
         this._toolStrip.SuspendLayout();
         this._splitContainer.Panel1.SuspendLayout();
         this._splitContainer.Panel2.SuspendLayout();
         this._splitContainer.SuspendLayout();
         this.SuspendLayout();
         // 
         // _titleLabel
         // 
         resources.ApplyResources(this._titleLabel, "_titleLabel");
         this._titleLabel.Name = "_titleLabel";
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
            this._panModeToolStripButton,
            this._zoomToSelectionModeToolStripButton,
            this._drawZoneModeToolStripButton,
            this._toolStripSeparator3,
            this._zonePropertiesToolStripButton,
            this._showZonesToolStripButton,
            this._showZoneNameToolStripButton});
         resources.ApplyResources(this._toolStrip, "_toolStrip");
         this._toolStrip.Name = "_toolStrip";
         // 
         // _previousPageToolStripButton
         // 
         this._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._previousPageToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.PreviousPage;
         resources.ApplyResources(this._previousPageToolStripButton, "_previousPageToolStripButton");
         this._previousPageToolStripButton.Name = "_previousPageToolStripButton";
         this._previousPageToolStripButton.Click += new System.EventHandler(this._previousPageToolStripButton_Click);
         // 
         // _nextPageToolStripButton
         // 
         this._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._nextPageToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.NextPage;
         resources.ApplyResources(this._nextPageToolStripButton, "_nextPageToolStripButton");
         this._nextPageToolStripButton.Name = "_nextPageToolStripButton";
         this._nextPageToolStripButton.Click += new System.EventHandler(this._nextPageToolStripButton_Click);
         // 
         // _pageToolStripTextBox
         // 
         this._pageToolStripTextBox.Name = "_pageToolStripTextBox";
         resources.ApplyResources(this._pageToolStripTextBox, "_pageToolStripTextBox");
         this._pageToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._pageToolStripTextBox_KeyPress);
         // 
         // _pageToolStripLabel
         // 
         this._pageToolStripLabel.Name = "_pageToolStripLabel";
         resources.ApplyResources(this._pageToolStripLabel, "_pageToolStripLabel");
         // 
         // _toolStripSeparator1
         // 
         this._toolStripSeparator1.Name = "_toolStripSeparator1";
         resources.ApplyResources(this._toolStripSeparator1, "_toolStripSeparator1");
         // 
         // _zoomOutToolStripButton
         // 
         this._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomOutToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.ZoomOut;
         resources.ApplyResources(this._zoomOutToolStripButton, "_zoomOutToolStripButton");
         this._zoomOutToolStripButton.Name = "_zoomOutToolStripButton";
         this._zoomOutToolStripButton.Click += new System.EventHandler(this._zoomOutToolStripButton_Click);
         // 
         // _zoomInToolStripButton
         // 
         this._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomInToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.ZoomIn;
         resources.ApplyResources(this._zoomInToolStripButton, "_zoomInToolStripButton");
         this._zoomInToolStripButton.Name = "_zoomInToolStripButton";
         this._zoomInToolStripButton.Click += new System.EventHandler(this._zoomInToolStripButton_Click);
         // 
         // _zoomToolStripComboBox
         // 
         this._zoomToolStripComboBox.DropDownWidth = 80;
         this._zoomToolStripComboBox.Items.AddRange(new object[] {
            resources.GetString("_zoomToolStripComboBox.Items"),
            resources.GetString("_zoomToolStripComboBox.Items1"),
            resources.GetString("_zoomToolStripComboBox.Items2"),
            resources.GetString("_zoomToolStripComboBox.Items3"),
            resources.GetString("_zoomToolStripComboBox.Items4"),
            resources.GetString("_zoomToolStripComboBox.Items5"),
            resources.GetString("_zoomToolStripComboBox.Items6"),
            resources.GetString("_zoomToolStripComboBox.Items7"),
            resources.GetString("_zoomToolStripComboBox.Items8"),
            resources.GetString("_zoomToolStripComboBox.Items9"),
            resources.GetString("_zoomToolStripComboBox.Items10"),
            resources.GetString("_zoomToolStripComboBox.Items11"),
            resources.GetString("_zoomToolStripComboBox.Items12"),
            resources.GetString("_zoomToolStripComboBox.Items13"),
            resources.GetString("_zoomToolStripComboBox.Items14"),
            resources.GetString("_zoomToolStripComboBox.Items15")});
         this._zoomToolStripComboBox.Name = "_zoomToolStripComboBox";
         resources.ApplyResources(this._zoomToolStripComboBox, "_zoomToolStripComboBox");
         this._zoomToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this._zoomToolStripComboBox_SelectedIndexChanged);
         this._zoomToolStripComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._zoomToolStripComboBox_KeyPress);
         // 
         // _fitPageWidthToolStripButton
         // 
         this._fitPageWidthToolStripButton.CheckOnClick = true;
         this._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageWidthToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.FitPageWidth;
         resources.ApplyResources(this._fitPageWidthToolStripButton, "_fitPageWidthToolStripButton");
         this._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton";
         this._fitPageWidthToolStripButton.Click += new System.EventHandler(this._fitPageWidthToolStripButton_Click);
         // 
         // _fitPageToolStripButton
         // 
         this._fitPageToolStripButton.CheckOnClick = true;
         this._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.FitPage;
         resources.ApplyResources(this._fitPageToolStripButton, "_fitPageToolStripButton");
         this._fitPageToolStripButton.Name = "_fitPageToolStripButton";
         this._fitPageToolStripButton.Click += new System.EventHandler(this._fitPageToolStripButton_Click);
         // 
         // _toolStripSeparator2
         // 
         this._toolStripSeparator2.Name = "_toolStripSeparator2";
         resources.ApplyResources(this._toolStripSeparator2, "_toolStripSeparator2");
         // 
         // _selectModeToolStripButton
         // 
         this._selectModeToolStripButton.CheckOnClick = true;
         this._selectModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._selectModeToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.SelectMode;
         resources.ApplyResources(this._selectModeToolStripButton, "_selectModeToolStripButton");
         this._selectModeToolStripButton.Name = "_selectModeToolStripButton";
         this._selectModeToolStripButton.Click += new System.EventHandler(this._selectModeToolStripButton_Click);
         // 
         // _panModeToolStripButton
         // 
         this._panModeToolStripButton.CheckOnClick = true;
         this._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._panModeToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.PanMode;
         resources.ApplyResources(this._panModeToolStripButton, "_panModeToolStripButton");
         this._panModeToolStripButton.Name = "_panModeToolStripButton";
         this._panModeToolStripButton.Click += new System.EventHandler(this._panModeToolStripButton_Click);
         // 
         // _zoomToSelectionModeToolStripButton
         // 
         this._zoomToSelectionModeToolStripButton.CheckOnClick = true;
         this._zoomToSelectionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomToSelectionModeToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.ZoomSelection;
         resources.ApplyResources(this._zoomToSelectionModeToolStripButton, "_zoomToSelectionModeToolStripButton");
         this._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton";
         this._zoomToSelectionModeToolStripButton.Click += new System.EventHandler(this._zoomToSelectionModeToolStripButton_Click);
         // 
         // _drawZoneModeToolStripButton
         // 
         this._drawZoneModeToolStripButton.CheckOnClick = true;
         this._drawZoneModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._drawZoneModeToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.DrawZoneMode;
         resources.ApplyResources(this._drawZoneModeToolStripButton, "_drawZoneModeToolStripButton");
         this._drawZoneModeToolStripButton.Name = "_drawZoneModeToolStripButton";
         this._drawZoneModeToolStripButton.Click += new System.EventHandler(this._drawZoneModeToolStripButton_Click);
         // 
         // _toolStripSeparator3
         // 
         this._toolStripSeparator3.Name = "_toolStripSeparator3";
         resources.ApplyResources(this._toolStripSeparator3, "_toolStripSeparator3");
         // 
         // _zonePropertiesToolStripButton
         // 
         this._zonePropertiesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zonePropertiesToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.ZoneProperties;
         resources.ApplyResources(this._zonePropertiesToolStripButton, "_zonePropertiesToolStripButton");
         this._zonePropertiesToolStripButton.Name = "_zonePropertiesToolStripButton";
         this._zonePropertiesToolStripButton.Click += new System.EventHandler(this._zonePropertiesToolStripButton_Click);
         // 
         // _showZonesToolStripButton
         // 
         this._showZonesToolStripButton.Checked = true;
         this._showZonesToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
         this._showZonesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._showZonesToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.ShowZones;
         resources.ApplyResources(this._showZonesToolStripButton, "_showZonesToolStripButton");
         this._showZonesToolStripButton.Name = "_showZonesToolStripButton";
         this._showZonesToolStripButton.Click += new System.EventHandler(this._showZonesToolStripButton_Click);
         // 
         // _showZoneNameToolStripButton
         // 
         this._showZoneNameToolStripButton.Checked = true;
         this._showZoneNameToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
         this._showZoneNameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._showZoneNameToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.ShowZoneName;
         resources.ApplyResources(this._showZoneNameToolStripButton, "_showZoneNameToolStripButton");
         this._showZoneNameToolStripButton.Name = "_showZoneNameToolStripButton";
         this._showZoneNameToolStripButton.Click += new System.EventHandler(this._showZoneNameToolStripButton_Click);
         // 
         // _rasterImageViewer
         // 
         this._rasterImageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._rasterImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
         resources.ApplyResources(this._rasterImageViewer, "_rasterImageViewer");
         this._rasterImageViewer.AutoScroll = true;
         this._rasterImageViewer.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageViewer.Name = "_rasterImageViewer";
         this._rasterImageViewer.Zoom(Leadtools.Controls.ControlSizeMode.Fit, _rasterImageViewer.ScaleFactor, _rasterImageViewer.DefaultZoomOrigin);
         this._rasterImageViewer.UseDpi = true;
         this._rasterImageViewer.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageViewer.PostRender += new System.EventHandler<Leadtools.Controls.ImageViewerRenderEventArgs>(_rasterImageViewer_PostImagePaint); //+= new System.Windows.Forms.PaintEventHandler(this._rasterImageViewer_PostImagePaint);
         this._rasterImageViewer.TransformChanged += new System.EventHandler(this._rasterImageViewer_TransformChanged);
         this._rasterImageViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this._rasterImageViewer_MouseMove);
         // 
         // _splitContainer
         // 
         this._splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._splitContainer, "_splitContainer");
         this._splitContainer.Name = "_splitContainer";
         // 
         // _splitContainer.Panel1
         // 
         this._splitContainer.Panel1.Controls.Add(this._mousePositionLabel);
         // 
         // _splitContainer.Panel2
         // 
         this._splitContainer.Panel2.Controls.Add(this._cellIndexLabel);
         // 
         // _mousePositionLabel
         // 
         resources.ApplyResources(this._mousePositionLabel, "_mousePositionLabel");
         this._mousePositionLabel.Name = "_mousePositionLabel";
         // 
         // _cellIndexLabel
         // 
         resources.ApplyResources(this._cellIndexLabel, "_cellIndexLabel");
         this._cellIndexLabel.Name = "_cellIndexLabel";
         // 
         // ViewerControl
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._rasterImageViewer);
         this.Controls.Add(this._splitContainer);
         this.Controls.Add(this._toolStrip);
         this.Controls.Add(this._titleLabel);
         this.Name = "ViewerControl";
         this._toolStrip.ResumeLayout(false);
         this._toolStrip.PerformLayout();
         this._splitContainer.Panel1.ResumeLayout(false);
         this._splitContainer.Panel2.ResumeLayout(false);
         this._splitContainer.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _titleLabel;
      public System.Windows.Forms.ToolStrip _toolStrip;
      private Leadtools.Annotations.WinForms.AutomationImageViewer _rasterImageViewer;
      private System.Windows.Forms.ToolStripButton _previousPageToolStripButton;
      private System.Windows.Forms.ToolStripButton _nextPageToolStripButton;
      private System.Windows.Forms.ToolStripTextBox _pageToolStripTextBox;
      private System.Windows.Forms.ToolStripLabel _pageToolStripLabel;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton _zoomOutToolStripButton;
      private System.Windows.Forms.ToolStripButton _zoomInToolStripButton;
      private System.Windows.Forms.ToolStripComboBox _zoomToolStripComboBox;
      private System.Windows.Forms.ToolStripButton _fitPageWidthToolStripButton;
      private System.Windows.Forms.ToolStripButton _fitPageToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton _selectModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _panModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _zoomToSelectionModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _drawZoneModeToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton _zonePropertiesToolStripButton;
      private System.Windows.Forms.ToolStripButton _showZonesToolStripButton;
      private System.Windows.Forms.ToolStripButton _showZoneNameToolStripButton;
      private System.Windows.Forms.SplitContainer _splitContainer;
      private System.Windows.Forms.Label _mousePositionLabel;
      private System.Windows.Forms.Label _cellIndexLabel;
   }
}
