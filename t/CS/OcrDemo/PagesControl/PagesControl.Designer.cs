namespace OcrDemo.PagesControl
{
   partial class PagesControl
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
         this._insertPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._deleteCurrentPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._movePageUpToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._movePageDownToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._rasterImageList = new Leadtools.Controls.ImageViewer(new Leadtools.Controls.ImageViewerVerticalViewLayout() { Columns = 1 });
         this._toolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _titleLabel
         // 
         this._titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
         this._titleLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._titleLabel.Location = new System.Drawing.Point(0, 0);
         this._titleLabel.Name = "_titleLabel";
         this._titleLabel.Size = new System.Drawing.Size(197, 13);
         this._titleLabel.TabIndex = 0;
         this._titleLabel.Text = "Pages";
         this._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _toolStrip
         // 
         this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._insertPageToolStripButton,
            this._deleteCurrentPageToolStripButton,
            this._movePageUpToolStripButton,
            this._movePageDownToolStripButton});
         this._toolStrip.Location = new System.Drawing.Point(0, 13);
         this._toolStrip.Name = "_toolStrip";
         this._toolStrip.Size = new System.Drawing.Size(197, 25);
         this._toolStrip.TabIndex = 1;
         // 
         // _insertPageToolStripButton
         // 
         this._insertPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._insertPageToolStripButton.Image = global::OcrDemo.Properties.Resources.InsertPage;
         this._insertPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._insertPageToolStripButton.Name = "_insertPageToolStripButton";
         this._insertPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._insertPageToolStripButton.ToolTipText = "Insert page or pages to the document from a disk file";
         this._insertPageToolStripButton.Click += new System.EventHandler(this._insertPageToolStripButton_Click);
         // 
         // _deleteCurrentPageToolStripButton
         // 
         this._deleteCurrentPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._deleteCurrentPageToolStripButton.Image = global::OcrDemo.Properties.Resources.DeletePage;
         this._deleteCurrentPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._deleteCurrentPageToolStripButton.Name = "_deleteCurrentPageToolStripButton";
         this._deleteCurrentPageToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._deleteCurrentPageToolStripButton.ToolTipText = "Delete current page";
         this._deleteCurrentPageToolStripButton.Click += new System.EventHandler(this._deleteCurrentPageToolStripButton_Click);
         // 
         // _movePageUpToolStripButton
         // 
         this._movePageUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._movePageUpToolStripButton.Image = global::OcrDemo.Properties.Resources.MovePageUp;
         this._movePageUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._movePageUpToolStripButton.Name = "_movePageUpToolStripButton";
         this._movePageUpToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._movePageUpToolStripButton.ToolTipText = "Move current page up in the document";
         this._movePageUpToolStripButton.Click += new System.EventHandler(this._movePageUpToolStripButton_Click);
         // 
         // _movePageDownToolStripButton
         // 
         this._movePageDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._movePageDownToolStripButton.Image = global::OcrDemo.Properties.Resources.MovePageDown;
         this._movePageDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._movePageDownToolStripButton.Name = "_movePageDownToolStripButton";
         this._movePageDownToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._movePageDownToolStripButton.ToolTipText = "Move current page down in the document";
         this._movePageDownToolStripButton.Click += new System.EventHandler(this._movePageDownToolStripButton_Click);
         // 
         // _rasterImageList
         // 
         this._rasterImageList.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._rasterImageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._rasterImageList.ItemSpacing = new Leadtools.LeadSize(20, 20);
         this._rasterImageList.ItemSizeMode = Leadtools.Controls.ControlSizeMode.Fit;
         this._rasterImageList.ItemSize = new Leadtools.LeadSize(180, 200);
         this._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue;
         this._rasterImageList.Dock = System.Windows.Forms.DockStyle.Left;
         this._rasterImageList.Location = new System.Drawing.Point(0, 93);
         this._rasterImageList.Size = new System.Drawing.Size(197, 475);
         this._rasterImageList.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageList.Name = "_ImageList";
         this._rasterImageList.UseDpi = true;
         this._rasterImageList.ItemBorderThickness = 2;
         this._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue;
         this._rasterImageList.SelectedItemsChanged += new System.EventHandler(this._rasterImageList_SelectedItemChanged);
         this._rasterImageList.PostRender += new System.EventHandler<Leadtools.Controls.ImageViewerRenderEventArgs>(_rasterImageList_Paint);
         this._rasterImageList.InteractiveModes.Add(new Leadtools.Controls.ImageViewerSelectItemsInteractiveMode() { SelectionMode = Leadtools.Controls.ImageViewerSelectionMode.Single });
         // 
         // PagesControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._rasterImageList);
         this.Controls.Add(this._toolStrip);
         this.Controls.Add(this._titleLabel);
         this.Name = "PagesControl";
         this.Size = new System.Drawing.Size(197, 364);
         this._toolStrip.ResumeLayout(false);
         this._toolStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _titleLabel;
      private System.Windows.Forms.ToolStrip _toolStrip;
      private System.Windows.Forms.ToolStripButton _insertPageToolStripButton;
      private System.Windows.Forms.ToolStripButton _deleteCurrentPageToolStripButton;
      private System.Windows.Forms.ToolStripButton _movePageUpToolStripButton;
      private System.Windows.Forms.ToolStripButton _movePageDownToolStripButton;
      private Leadtools.Controls.ImageViewer _rasterImageList;
   }
}
