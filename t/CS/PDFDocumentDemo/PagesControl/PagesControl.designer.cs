namespace PDFDocumentDemo.PagesControl
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
         Cleanup(disposing);

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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagesControl));
         this._rasterImageList = new Leadtools.Controls.ImageViewer(new Leadtools.Controls.ImageViewerVerticalViewLayout() { Columns = 1 });
         this._titleLabel = new System.Windows.Forms.Label();
         this._toolStrip = new System.Windows.Forms.ToolStrip();
         this._thumbnailsToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._bookmarksToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._signaturesToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._bookmarksTreeView = new System.Windows.Forms.TreeView();
         this._noBookmarksLabel = new System.Windows.Forms.Label();
         this._signaturesTreeView = new System.Windows.Forms.TreeView();
         this._noSignaturesLabel = new System.Windows.Forms.Label();
         this._toolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _rasterImageList
         // 

         this._rasterImageList.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._rasterImageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._rasterImageList.Dock = System.Windows.Forms.DockStyle.Fill;
         this._rasterImageList.ItemSize = new Leadtools.LeadSize(160, 160);
         this._rasterImageList.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._rasterImageList.Location = new System.Drawing.Point(0, 25);
         this._rasterImageList.ItemSpacing = new Leadtools.LeadSize(20, 20);
         this._rasterImageList.ItemBorderThickness = 2;
         this._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue;
         this._rasterImageList.ItemSizeMode = Leadtools.Controls.ControlSizeMode.Fit;
         this._rasterImageList.Name = "_rasterImageList";
         this._rasterImageList.Size = new System.Drawing.Size(164, 322);
         this._rasterImageList.TabIndex = 11;
         this._rasterImageList.InteractiveModes.Add(new Leadtools.Controls.ImageViewerSelectItemsInteractiveMode() { SelectionMode = Leadtools.Controls.ImageViewerSelectionMode.Single });
         this._rasterImageList.SelectedItemsChanged += new System.EventHandler(_rasterImageList_SelectedItemsChanged);
         resources.ApplyResources(this._rasterImageList, "_rasterImageList");
         this._rasterImageList.ItemSize = new Leadtools.LeadSize(140, 160);
         this._rasterImageList.UseDpi = true;
         this._rasterImageList.Scroll += new System.Windows.Forms.ScrollEventHandler(_rasterImageList_Scroll);
         // 
         // _titleLabel
         // 
         resources.ApplyResources(this._titleLabel, "_titleLabel");
         this._titleLabel.Name = "_titleLabel";
         // 
         // _toolStrip
         // 
         this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._thumbnailsToolStripButton,
            this._bookmarksToolStripButton,
            this._signaturesToolStripButton});
         resources.ApplyResources(this._toolStrip, "_toolStrip");
         this._toolStrip.Name = "_toolStrip";
         // 
         // _thumbnailsToolStripButton
         // 
         this._thumbnailsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._thumbnailsToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.Thumbnails;
         resources.ApplyResources(this._thumbnailsToolStripButton, "_thumbnailsToolStripButton");
         this._thumbnailsToolStripButton.Name = "_thumbnailsToolStripButton";
         this._thumbnailsToolStripButton.Click += new System.EventHandler(this._thumbnailsToolStripButton_Click);
         // 
         // _bookmarksToolStripButton
         // 
         this._bookmarksToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._bookmarksToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.Bookmarks;
         resources.ApplyResources(this._bookmarksToolStripButton, "_bookmarksToolStripButton");
         this._bookmarksToolStripButton.Name = "_bookmarksToolStripButton";
         this._bookmarksToolStripButton.Click += new System.EventHandler(this._bookmarksToolStripButton_Click);
         // 
         // _signaturesToolStripButton
         // 
         this._signaturesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._signaturesToolStripButton.Image = global::PDFDocumentDemo.Properties.Resources.Signature;
         this._signaturesToolStripButton.Name = "_signaturesToolStripButton";
         resources.ApplyResources(this._signaturesToolStripButton, "_signaturesToolStripButton");
         this._signaturesToolStripButton.Click += new System.EventHandler(this._signaturesToolStripButton_Click);
         // 
         // _bookmarksTreeView
         // 
         resources.ApplyResources(this._bookmarksTreeView, "_bookmarksTreeView");
         this._bookmarksTreeView.Name = "_bookmarksTreeView";
         this._bookmarksTreeView.ShowNodeToolTips = true;
         this._bookmarksTreeView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._bookmarksTreeView_KeyPress);
         this._bookmarksTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._bookmarksTreeView_NodeMouseClick);
         // 
         // _noBookmarksLabel
         // 
         resources.ApplyResources(this._noBookmarksLabel, "_noBookmarksLabel");
         this._noBookmarksLabel.Name = "_noBookmarksLabel";
         // 
         // _signaturesTreeView
         // 
         resources.ApplyResources(this._signaturesTreeView, "_signaturesTreeView");
         this._signaturesTreeView.Name = "_signaturesTreeView";
         this._signaturesTreeView.ShowNodeToolTips = true;
         this._signaturesTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._signaturesTreeView_NodeMouseClick);
         this._signaturesTreeView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._signaturesTreeView_KeyPress);
         // 
         // _noSignaturesLabel
         // 
         resources.ApplyResources(this._noSignaturesLabel, "_noSignaturesLabel");
         this._noSignaturesLabel.Name = "_noSignaturesLabel";
         // 
         // PagesControl
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._signaturesTreeView);
         this.Controls.Add(this._noSignaturesLabel);
         this.Controls.Add(this._noBookmarksLabel);
         this.Controls.Add(this._bookmarksTreeView);
         this.Controls.Add(this._rasterImageList);
         this.Controls.Add(this._toolStrip);
         this.Controls.Add(this._titleLabel);
         this.Name = "PagesControl";
         this._toolStrip.ResumeLayout(false);
         this._toolStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Leadtools.Controls.ImageViewer _rasterImageList;
      private System.Windows.Forms.Label _titleLabel;
      private System.Windows.Forms.ToolStrip _toolStrip;
      private System.Windows.Forms.ToolStripButton _thumbnailsToolStripButton;
      private System.Windows.Forms.ToolStripButton _bookmarksToolStripButton;
      private System.Windows.Forms.ToolStripButton _signaturesToolStripButton;
      private System.Windows.Forms.TreeView _bookmarksTreeView;
      private System.Windows.Forms.Label _noBookmarksLabel;
      private System.Windows.Forms.TreeView _signaturesTreeView;
      private System.Windows.Forms.Label _noSignaturesLabel;

   }
}
