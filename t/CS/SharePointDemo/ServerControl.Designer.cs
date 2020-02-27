namespace SharePointDemo
{
   partial class ServerControl
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
         this.components = new System.ComponentModel.Container();
         this._titleLabel = new System.Windows.Forms.Label();
         this._toolStrip = new System.Windows.Forms.ToolStrip();
         this._serverToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._downloadToolStripButton = new System.Windows.Forms.ToolStripButton();
         this._listView = new System.Windows.Forms.ListView();
         this._nameColumnHeader = new System.Windows.Forms.ColumnHeader();
         this._typeColumnHeader = new System.Windows.Forms.ColumnHeader();
         this._imageList = new System.Windows.Forms.ImageList(this.components);
         this._toolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _titleLabel
         // 
         this._titleLabel.AutoEllipsis = true;
         this._titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
         this._titleLabel.Location = new System.Drawing.Point(0, 0);
         this._titleLabel.Name = "_titleLabel";
         this._titleLabel.Size = new System.Drawing.Size(465, 23);
         this._titleLabel.TabIndex = 0;
         this._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _toolStrip
         // 
         this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._serverToolStripButton,
            this._refreshToolStripButton,
            this._toolStripSeparator1,
            this._downloadToolStripButton});
         this._toolStrip.Location = new System.Drawing.Point(0, 23);
         this._toolStrip.Name = "_toolStrip";
         this._toolStrip.Size = new System.Drawing.Size(465, 25);
         this._toolStrip.TabIndex = 1;
         // 
         // _serverToolStripButton
         // 
         this._serverToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._serverToolStripButton.Image = global::SharePointDemo.Properties.Resources.Server;
         this._serverToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._serverToolStripButton.Name = "_serverToolStripButton";
         this._serverToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._serverToolStripButton.ToolTipText = "Select the SharePoint server address";
         this._serverToolStripButton.Click += new System.EventHandler(this._serverToolStripButton_Click);
         // 
         // _refreshToolStripButton
         // 
         this._refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._refreshToolStripButton.Image = global::SharePointDemo.Properties.Resources.Refresh;
         this._refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._refreshToolStripButton.Name = "_refreshToolStripButton";
         this._refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._refreshToolStripButton.ToolTipText = "Refresh the documents list";
         this._refreshToolStripButton.Click += new System.EventHandler(this._refreshToolStripButton_Click);
         // 
         // _toolStripSeparator1
         // 
         this._toolStripSeparator1.Name = "_toolStripSeparator1";
         this._toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // _downloadToolStripButton
         // 
         this._downloadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._downloadToolStripButton.Image = global::SharePointDemo.Properties.Resources.Download;
         this._downloadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._downloadToolStripButton.Name = "_downloadToolStripButton";
         this._downloadToolStripButton.Size = new System.Drawing.Size(23, 22);
         this._downloadToolStripButton.ToolTipText = "Download and view the selected image";
         this._downloadToolStripButton.Click += new System.EventHandler(this._downloadToolStripButton_Click);
         // 
         // _listView
         // 
         this._listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._nameColumnHeader,
            this._typeColumnHeader});
         this._listView.Dock = System.Windows.Forms.DockStyle.Fill;
         this._listView.FullRowSelect = true;
         this._listView.HideSelection = false;
         this._listView.Location = new System.Drawing.Point(0, 48);
         this._listView.MultiSelect = false;
         this._listView.Name = "_listView";
         this._listView.Size = new System.Drawing.Size(465, 384);
         this._listView.SmallImageList = this._imageList;
         this._listView.TabIndex = 2;
         this._listView.UseCompatibleStateImageBehavior = false;
         this._listView.View = System.Windows.Forms.View.Details;
         this._listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._listView_MouseDoubleClick);
         this._listView.SelectedIndexChanged += new System.EventHandler(this._listView_SelectedIndexChanged);
         this._listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this._listView_ColumnClick);
         this._listView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._listView_KeyPress);
         // 
         // _nameColumnHeader
         // 
         this._nameColumnHeader.Text = "Name";
         this._nameColumnHeader.Width = 151;
         // 
         // _typeColumnHeader
         // 
         this._typeColumnHeader.Text = "Type";
         this._typeColumnHeader.Width = 200;
         // 
         // _imageList
         // 
         this._imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
         this._imageList.ImageSize = new System.Drawing.Size(16, 16);
         this._imageList.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // ServerControl
         // 
         this.Controls.Add(this._listView);
         this.Controls.Add(this._toolStrip);
         this.Controls.Add(this._titleLabel);
         this.Name = "ServerControl";
         this.Size = new System.Drawing.Size(465, 432);
         this._toolStrip.ResumeLayout(false);
         this._toolStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _titleLabel;
      private System.Windows.Forms.ToolStrip _toolStrip;
      private System.Windows.Forms.ToolStripButton _serverToolStripButton;
      private System.Windows.Forms.ToolStripButton _refreshToolStripButton;
      private System.Windows.Forms.ListView _listView;
      private System.Windows.Forms.ColumnHeader _typeColumnHeader;
      private System.Windows.Forms.ColumnHeader _nameColumnHeader;
      private System.Windows.Forms.ImageList _imageList;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton _downloadToolStripButton;
   }
}
