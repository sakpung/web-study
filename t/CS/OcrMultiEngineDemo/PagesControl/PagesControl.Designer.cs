namespace OcrMultiEngineDemo.PagesControl
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
         this._titleLabel = new System.Windows.Forms.Label();
         this._toolStrip = new System.Windows.Forms.ToolStrip();
         this._insertPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._deleteCurrentPageToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._movePageUpToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._movePageDownToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._ImageList = new Leadtools.Controls.ImageViewer(new Leadtools.Controls.ImageViewerVerticalViewLayout() { Columns = 1 });
         this._toolStrip.SuspendLayout();
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
            this._insertPageToolStripButton,
            this._deleteCurrentPageToolStripButton,
            this._movePageUpToolStripButton,
            this._movePageDownToolStripButton});
         resources.ApplyResources(this._toolStrip, "_toolStrip");
         this._toolStrip.Name = "_toolStrip";
         // 
         // _insertPageToolStripButton
         // 
         this._insertPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._insertPageToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.InsertPage;
         resources.ApplyResources(this._insertPageToolStripButton, "_insertPageToolStripButton");
         this._insertPageToolStripButton.Name = "_insertPageToolStripButton";
         this._insertPageToolStripButton.Click += new System.EventHandler(this._insertPageToolStripButton_Click);
         // 
         // _deleteCurrentPageToolStripButton
         // 
         this._deleteCurrentPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._deleteCurrentPageToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.DeletePage;
         resources.ApplyResources(this._deleteCurrentPageToolStripButton, "_deleteCurrentPageToolStripButton");
         this._deleteCurrentPageToolStripButton.Name = "_deleteCurrentPageToolStripButton";
         this._deleteCurrentPageToolStripButton.Click += new System.EventHandler(this._deleteCurrentPageToolStripButton_Click);
         // 
         // _movePageUpToolStripButton
         // 
         this._movePageUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._movePageUpToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.MovePageUp;
         resources.ApplyResources(this._movePageUpToolStripButton, "_movePageUpToolStripButton");
         this._movePageUpToolStripButton.Name = "_movePageUpToolStripButton";
         this._movePageUpToolStripButton.Click += new System.EventHandler(this._movePageUpToolStripButton_Click);
         // 
         // _movePageDownToolStripButton
         // 
         this._movePageDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._movePageDownToolStripButton.Image = global::OcrMultiEngineDemo.Properties.Resources.MovePageDown;
         resources.ApplyResources(this._movePageDownToolStripButton, "_movePageDownToolStripButton");
         this._movePageDownToolStripButton.Name = "_movePageDownToolStripButton";
         this._movePageDownToolStripButton.Click += new System.EventHandler(this._movePageDownToolStripButton_Click);
         // 
         // _ImageList
         // 
         this._ImageList.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._ImageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._ImageList, "_ImageList");
         this._ImageList.ItemSpacing = new Leadtools.LeadSize(20, 20);
         this._ImageList.ItemSizeMode = Leadtools.Controls.ControlSizeMode.Fit;
         this._ImageList.ItemSize = new Leadtools.LeadSize(180, 200);
         this._ImageList.SelectedItemBorderColor = System.Drawing.Color.Blue;
         this._ImageList.Dock = System.Windows.Forms.DockStyle.Left;
         this._ImageList.Location = new System.Drawing.Point(0, 93);
         this._ImageList.Size = new System.Drawing.Size(197, 475);
         this._ImageList.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
         this._ImageList.Name = "_ImageList";
         this._ImageList.UseDpi = true;
         this._ImageList.ItemBorderThickness = 2;
         this._ImageList.SelectedItemBorderColor = System.Drawing.Color.Blue;
         this._ImageList.SelectedItemsChanged += new System.EventHandler(this._ImageList_SelectedItemChanged);
         this._ImageList.PostRender += new System.EventHandler<Leadtools.Controls.ImageViewerRenderEventArgs>(_ImageList_Paint);
         this._ImageList.InteractiveModes.Add(new Leadtools.Controls.ImageViewerSelectItemsInteractiveMode() { SelectionMode = Leadtools.Controls.ImageViewerSelectionMode.Single });
         // 
         // PagesControl
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._ImageList);
         this.Controls.Add(this._toolStrip);
         this.Controls.Add(this._titleLabel);
         this.Name = "PagesControl";
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
      private Leadtools.Controls.ImageViewer _ImageList;
   }
}
