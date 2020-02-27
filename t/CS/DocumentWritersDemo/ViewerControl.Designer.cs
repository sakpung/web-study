namespace DocumentWritersDemo
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
         this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._bringToFrontToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._sendToBackToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._bringToFirstToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._sendToLastToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this._propertiesToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._mousePositionLabel = new System.Windows.Forms.Label();
         this._rasterImageViewer = new Leadtools.Annotations.WinForms.AutomationImageViewer(); 
         this._toolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _titleLabel
         // 
         this._titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
         this._titleLabel.Location = new System.Drawing.Point(0, 0);
         this._titleLabel.Name = "_titleLabel";
         this._titleLabel.Size = new System.Drawing.Size(619, 13);
         this._titleLabel.TabIndex = 1;
         this._titleLabel.Text = "_titleLabel";
         this._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this._toolStripSeparator3,
            this._bringToFrontToolStripButton,
            this._sendToBackToolStripButton,
            this._bringToFirstToolStripButton,
            this._sendToLastToolStripButton,
            this._toolStripSeparator4,
            this._propertiesToolStripButton});
         this._toolStrip.Location = new System.Drawing.Point(0, 13);
         this._toolStrip.Name = "_toolStrip";
         this._toolStrip.Size = new System.Drawing.Size(619, 25);
         this._toolStrip.TabIndex = 2;
         // 
         // _previousPageToolStripButton
         // 
         this._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._previousPageToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.PreviousPage;
         this._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._previousPageToolStripButton.Name = "_previousPageToolStripButton";
         this._previousPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._previousPageToolStripButton.ToolTipText = "Go to previous page in the document";
         this._previousPageToolStripButton.Click += new System.EventHandler(this._previousPageToolStripButton_Click);
         // 
         // _nextPageToolStripButton
         // 
         this._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._nextPageToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.NextPage;
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
         this._zoomOutToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.ZoomOut;
         this._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomOutToolStripButton.Name = "_zoomOutToolStripButton";
         this._zoomOutToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomOutToolStripButton.ToolTipText = "Zoom out";
         this._zoomOutToolStripButton.Click += new System.EventHandler(this._zoomOutToolStripButton_Click);
         // 
         // _zoomInToolStripButton
         // 
         this._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomInToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.ZoomIn;
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
         this._fitPageWidthToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.FitPageWidth;
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
         this._fitPageToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.FitPage;
         this._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._fitPageToolStripButton.Name = "_fitPageToolStripButton";
         this._fitPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._fitPageToolStripButton.ToolTipText = "Fit entire page in window";
         this._fitPageToolStripButton.Click += new System.EventHandler(this._fitPageToolStripButton_Click);
         // 
         // _toolStripSeparator2
         // 
         this._toolStripSeparator2.Name = "_toolStripSeparator2";
         this._toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // _selectModeToolStripButton
         // 
         this._selectModeToolStripButton.CheckOnClick = true;
         this._selectModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._selectModeToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.SelectMode;
         this._selectModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._selectModeToolStripButton.Name = "_selectModeToolStripButton";
         this._selectModeToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._selectModeToolStripButton.ToolTipText = "Select mode";
         this._selectModeToolStripButton.Click += new System.EventHandler(this._selectModeToolStripButton_Click);
         // 
         // _panModeToolStripButton
         // 
         this._panModeToolStripButton.CheckOnClick = true;
         this._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._panModeToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.PanMode;
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
         this._zoomToSelectionModeToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.ZoomSelection;
         this._zoomToSelectionModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton";
         this._zoomToSelectionModeToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomToSelectionModeToolStripButton.ToolTipText = "Zoom to selection mode";
         this._zoomToSelectionModeToolStripButton.Click += new System.EventHandler(this._zoomToSelectionModeToolStripButton_Click);
         // 
         // _toolStripSeparator3
         // 
         this._toolStripSeparator3.Name = "_toolStripSeparator3";
         this._toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // _bringToFrontToolStripButton
         // 
         this._bringToFrontToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._bringToFrontToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.BringToFront;
         this._bringToFrontToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._bringToFrontToolStripButton.Name = "_bringToFrontToolStripButton";
         this._bringToFrontToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._bringToFrontToolStripButton.ToolTipText = "Bring selected object(s) to front";
         this._bringToFrontToolStripButton.Click += new System.EventHandler(this._bringToFrontToolStripButton_Click);
         // 
         // _sendToBackToolStripButton
         // 
         this._sendToBackToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._sendToBackToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.SendToBack;
         this._sendToBackToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._sendToBackToolStripButton.Name = "_sendToBackToolStripButton";
         this._sendToBackToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._sendToBackToolStripButton.ToolTipText = "Send selected object(s) to back";
         this._sendToBackToolStripButton.Click += new System.EventHandler(this._sendToBackToolStripButton_Click);
         // 
         // _bringToFirstToolStripButton
         // 
         this._bringToFirstToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._bringToFirstToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.BringToFirst;
         this._bringToFirstToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._bringToFirstToolStripButton.Name = "_bringToFirstToolStripButton";
         this._bringToFirstToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._bringToFirstToolStripButton.ToolTipText = "Bring selected object(s) to first";
         this._bringToFirstToolStripButton.Click += new System.EventHandler(this._bringToFirstToolStripButton_Click);
         // 
         // _sendToLastToolStripButton
         // 
         this._sendToLastToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._sendToLastToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.SendToLast;
         this._sendToLastToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._sendToLastToolStripButton.Name = "_sendToLastToolStripButton";
         this._sendToLastToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._sendToLastToolStripButton.ToolTipText = "Send selected object(s) to last";
         this._sendToLastToolStripButton.Click += new System.EventHandler(this._sendToLastToolStripButton_Click);
         // 
         // _toolStripSeparator4
         // 
         this._toolStripSeparator4.Name = "_toolStripSeparator4";
         this._toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
         // 
         // _propertiesToolStripButton
         // 
         this._propertiesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._propertiesToolStripButton.Image = global::DocumentWritersDemo.Properties.Resources.ObjectProperties;
         this._propertiesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._propertiesToolStripButton.Name = "_propertiesToolStripButton";
         this._propertiesToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._propertiesToolStripButton.ToolTipText = "Show selected object(s) properties";
         this._propertiesToolStripButton.Click += new System.EventHandler(this._propertiesToolStripButton_Click);
         // 
         // _mousePositionLabel
         // 
         this._mousePositionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._mousePositionLabel.Location = new System.Drawing.Point(0, 408);
         this._mousePositionLabel.Name = "_mousePositionLabel";
         this._mousePositionLabel.Size = new System.Drawing.Size(619, 13);
         this._mousePositionLabel.TabIndex = 3;
         this._mousePositionLabel.Text = "_mousePositionLabel";
         this._mousePositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _rasterImageViewer
         //
         this._rasterImageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._rasterImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this._rasterImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._rasterImageViewer.RestrictScroll = false;
         this._rasterImageViewer.ScrollMode = Leadtools.Controls.ControlScrollMode.Auto;
         this._rasterImageViewer.HorizontalScroll.Enabled = true;
         this._rasterImageViewer.VerticalScroll.Enabled = true;
         this._rasterImageViewer.VerticalScroll.Visible = true;
         this._rasterImageViewer.AutoScroll = true;
         this._rasterImageViewer.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageViewer.Location = new System.Drawing.Point(0, 38);
         this._rasterImageViewer.Name = "_rasterImageViewer";
         this._rasterImageViewer.Size = new System.Drawing.Size(619, 370);
         this._rasterImageViewer.TabIndex = 4;
         this._rasterImageViewer.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageViewer.TransformChanged += new System.EventHandler(this._rasterImageViewer_TransformChanged);
         this._rasterImageViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this._rasterImageViewer_MouseMove);
         this._rasterImageViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this._rasterImageViewer_MouseDown);
         // 
         // ViewerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._rasterImageViewer);
         this.Controls.Add(this._mousePositionLabel);
         this.Controls.Add(this._toolStrip);
         this.Controls.Add(this._titleLabel);
         this.Name = "ViewerControl";
         this.Size = new System.Drawing.Size(619, 421);
         this._toolStrip.ResumeLayout(false);
         this._toolStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _titleLabel;
      private System.Windows.Forms.ToolStrip _toolStrip;
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
      private System.Windows.Forms.Label _mousePositionLabel;
      private Leadtools.Annotations.WinForms.AutomationImageViewer  _rasterImageViewer;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton _propertiesToolStripButton;
      private System.Windows.Forms.ToolStripButton _bringToFrontToolStripButton;
      private System.Windows.Forms.ToolStripButton _sendToBackToolStripButton;
      private System.Windows.Forms.ToolStripButton _bringToFirstToolStripButton;
      private System.Windows.Forms.ToolStripButton _sendToLastToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator4;
   }
}
