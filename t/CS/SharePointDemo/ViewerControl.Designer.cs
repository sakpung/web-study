namespace SharePointDemo
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
         this._openFileToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._uploadToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._previousPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._nextPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._pageToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
         this._pageToolStripLabel = new System.Windows.Forms.ToolStripLabel();
         this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._zoomOutToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomInToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
         this._fitPageWidthToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._fitPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._selectModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._panModeToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._zoomToSelectionToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _titleLabel
         // 
         this._titleLabel.AutoEllipsis = true;
         this._titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
         this._titleLabel.Location = new System.Drawing.Point(0, 0);
         this._titleLabel.Name = "_titleLabel";
         this._titleLabel.Size = new System.Drawing.Size(468, 23);
         this._titleLabel.TabIndex = 0;
         this._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _toolStrip
         // 
         this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openFileToolStripButton,
            this._uploadToolStripButton,
            this._toolStripSeparator1,
            this._previousPageToolStripButton,
            this._nextPageToolStripButton,
            this._pageToolStripTextBox,
            this._pageToolStripLabel,
            this._toolStripSeparator2,
            this._zoomOutToolStripButton,
            this._zoomInToolStripButton,
            this._zoomToolStripComboBox,
            this._fitPageWidthToolStripButton,
            this._fitPageToolStripButton,
            this._toolStripSeparator3,
            this._selectModeToolStripButton,
            this._panModeToolStripButton,
            this._zoomToSelectionToolStripButton});
         this._toolStrip.Location = new System.Drawing.Point(0, 23);
         this._toolStrip.Name = "_toolStrip";
         this._toolStrip.Size = new System.Drawing.Size(468, 25);
         this._toolStrip.TabIndex = 3;
         this._toolStrip.Text = "toolStrip1";
         // 
         // _openFileToolStripButton
         // 
         this._openFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._openFileToolStripButton.Image = global::SharePointDemo.Properties.Resources.OpenFile;
         this._openFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._openFileToolStripButton.Name = "_openFileToolStripButton";
         this._openFileToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._openFileToolStripButton.ToolTipText = "Open image from disk file";
         this._openFileToolStripButton.Click += new System.EventHandler(this._openFileToolStripButton_Click);
         // 
         // _uploadToolStripButton
         // 
         this._uploadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._uploadToolStripButton.Image = global::SharePointDemo.Properties.Resources.Upload;
         this._uploadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._uploadToolStripButton.Name = "_uploadToolStripButton";
         this._uploadToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._uploadToolStripButton.ToolTipText = "Upload current image to the server";
         this._uploadToolStripButton.Click += new System.EventHandler(this._uploadToolStripButton_Click);
         // 
         // _toolStripSeparator1
         // 
         this._toolStripSeparator1.Name = "_toolStripSeparator1";
         this._toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // _previousPageToolStripButton
         // 
         this._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._previousPageToolStripButton.Image = global::SharePointDemo.Properties.Resources.PreviousPage;
         this._previousPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._previousPageToolStripButton.Name = "_previousPageToolStripButton";
         this._previousPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._previousPageToolStripButton.ToolTipText = "Go to previous page in the document";
         this._previousPageToolStripButton.Click += new System.EventHandler(this._previousPageToolStripButton_Click);
         // 
         // _nextPageToolStripButton
         // 
         this._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._nextPageToolStripButton.Image = global::SharePointDemo.Properties.Resources.NextPage;
         this._nextPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._nextPageToolStripButton.Name = "_nextPageToolStripButton";
         this._nextPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._nextPageToolStripButton.ToolTipText = "Go to next page in the document";
         this._nextPageToolStripButton.Click += new System.EventHandler(this._nextPageToolStripButton_Click);
         // 
         // _pageToolStripTextBox
         // 
         this._pageToolStripTextBox.AutoSize = false;
         this._pageToolStripTextBox.Name = "_pageToolStripTextBox";
         this._pageToolStripTextBox.Size = new System.Drawing.Size(40, 25);
         this._pageToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this._pageToolStripTextBox.ToolTipText = "Current page number in the document";
         this._pageToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._pageToolStripTextBox_KeyPress);
         // 
         // _pageToolStripLabel
         // 
         this._pageToolStripLabel.AutoSize = false;
         this._pageToolStripLabel.Name = "_pageToolStripLabel";
         this._pageToolStripLabel.Size = new System.Drawing.Size(40, 22);
         this._pageToolStripLabel.Text = "/ WWW";
         // 
         // _toolStripSeparator2
         // 
         this._toolStripSeparator2.Name = "_toolStripSeparator2";
         this._toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // _zoomOutToolStripButton
         // 
         this._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomOutToolStripButton.Image = global::SharePointDemo.Properties.Resources.ZoomOut;
         this._zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomOutToolStripButton.Name = "_zoomOutToolStripButton";
         this._zoomOutToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomOutToolStripButton.ToolTipText = "Zoom out";
         this._zoomOutToolStripButton.Click += new System.EventHandler(this._zoomOutToolStripButton_Click);
         // 
         // _zoomInToolStripButton
         // 
         this._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomInToolStripButton.Image = global::SharePointDemo.Properties.Resources.ZoomIn;
         this._zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomInToolStripButton.Name = "_zoomInToolStripButton";
         this._zoomInToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomInToolStripButton.ToolTipText = "Zoom in";
         this._zoomInToolStripButton.Click += new System.EventHandler(this._zoomInToolStripButton_Click);
         // 
         // _zoomToolStripComboBox
         // 
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
         this._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageWidthToolStripButton.Image = global::SharePointDemo.Properties.Resources.FitPageWidth;
         this._fitPageWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton";
         this._fitPageWidthToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._fitPageWidthToolStripButton.ToolTipText = "Fit page width in window";
         this._fitPageWidthToolStripButton.Click += new System.EventHandler(this._fitPageWidthToolStripButton_Click);
         // 
         // _fitPageToolStripButton
         // 
         this._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._fitPageToolStripButton.Image = global::SharePointDemo.Properties.Resources.FitPage;
         this._fitPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._fitPageToolStripButton.Name = "_fitPageToolStripButton";
         this._fitPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._fitPageToolStripButton.ToolTipText = "Fit entire page in window";
         this._fitPageToolStripButton.Click += new System.EventHandler(this._fitPageToolStripButton_Click);
         // 
         // _toolStripSeparator3
         // 
         this._toolStripSeparator3.Name = "_toolStripSeparator3";
         this._toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // _selectModeToolStripButton
         // 
         this._selectModeToolStripButton.CheckOnClick = true;
         this._selectModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._selectModeToolStripButton.Image = global::SharePointDemo.Properties.Resources.SelectMode;
         this._selectModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._selectModeToolStripButton.Name = "_selectModeToolStripButton";
         this._selectModeToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._selectModeToolStripButton.ToolTipText = "Select mode";
         this._selectModeToolStripButton.Click += new System.EventHandler(this._selectModeToolStripButton_Click);
         // 
         // _panModeToolStripButton
         // 
         this._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._panModeToolStripButton.Image = global::SharePointDemo.Properties.Resources.PanMode;
         this._panModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._panModeToolStripButton.Name = "_panModeToolStripButton";
         this._panModeToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._panModeToolStripButton.ToolTipText = "Pan mode";
         this._panModeToolStripButton.Click += new System.EventHandler(this._panModeToolStripButton_Click);
         // 
         // _zoomToSelectionToolStripButton
         // 
         this._zoomToSelectionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._zoomToSelectionToolStripButton.Image = global::SharePointDemo.Properties.Resources.ZoomSelectionMode;
         this._zoomToSelectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._zoomToSelectionToolStripButton.Name = "_zoomToSelectionToolStripButton";
         this._zoomToSelectionToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._zoomToSelectionToolStripButton.ToolTipText = "Zoom to selection mode";
         this._zoomToSelectionToolStripButton.Click += new System.EventHandler(this._zoomToSelectionToolStripButton_Click);
         // 
         // ViewerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._toolStrip);
         this.Controls.Add(this._titleLabel);
         this.Name = "ViewerControl";
         this.Size = new System.Drawing.Size(468, 448);
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
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton _zoomOutToolStripButton;
      private System.Windows.Forms.ToolStripButton _zoomInToolStripButton;
      private System.Windows.Forms.ToolStripComboBox _zoomToolStripComboBox;
      private System.Windows.Forms.ToolStripButton _fitPageWidthToolStripButton;
      private System.Windows.Forms.ToolStripButton _fitPageToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton _selectModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _panModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _zoomToSelectionToolStripButton;
      private System.Windows.Forms.ToolStripButton _openFileToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton _uploadToolStripButton;
   }
}
