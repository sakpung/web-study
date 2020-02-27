namespace Leadtools.Medical.Winforms
{
   partial class StorageClassesControl
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageClassesControl));
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.buttonTransferSyntax = new System.Windows.Forms.Button();
         this._buttonDelete = new System.Windows.Forms.Button();
         this._buttonCreate = new System.Windows.Forms.Button();
         this._buttonModify = new System.Windows.Forms.Button();
         this.groupBoxUserDefined = new System.Windows.Forms.GroupBox();
         this.columnHeaderMasterUid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderMasterDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._listViewMaster = new System.Windows.Forms.ListView();
         this.columnHeaderSupportedUid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderSupportedDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._listViewSupported = new System.Windows.Forms.ListView();
         this._buttonAdd = new System.Windows.Forms.Button();
         this._buttonRemove = new System.Windows.Forms.Button();
         this.labelMaster = new System.Windows.Forms.Label();
         this.labelSupported = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.groupBoxUserDefined.SuspendLayout();
         this.SuspendLayout();
         // 
         // pictureBox1
         // 
         this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
         this.pictureBox1.Location = new System.Drawing.Point(622, 22);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(20, 20);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pictureBox1.TabIndex = 15;
         this.pictureBox1.TabStop = false;
         // 
         // buttonTransferSyntax
         // 
         this.buttonTransferSyntax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonTransferSyntax.Location = new System.Drawing.Point(534, 281);
         this.buttonTransferSyntax.Name = "buttonTransferSyntax";
         this.buttonTransferSyntax.Size = new System.Drawing.Size(106, 23);
         this.buttonTransferSyntax.TabIndex = 7;
         this.buttonTransferSyntax.Text = "IOD Properties...";
         this.buttonTransferSyntax.UseVisualStyleBackColor = true;
         this.buttonTransferSyntax.Click += new System.EventHandler(this.buttonTransferSyntax_Click);
         // 
         // _buttonDelete
         // 
         this._buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
         this._buttonDelete.Location = new System.Drawing.Point(16, 88);
         this._buttonDelete.Name = "_buttonDelete";
         this._buttonDelete.Size = new System.Drawing.Size(106, 23);
         this._buttonDelete.TabIndex = 2;
         this._buttonDelete.Text = "Delete";
         this._buttonDelete.UseVisualStyleBackColor = true;
         this._buttonDelete.Click += new System.EventHandler(this._buttonDelete_Click);
         // 
         // _buttonCreate
         // 
         this._buttonCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
         this._buttonCreate.Location = new System.Drawing.Point(16, 24);
         this._buttonCreate.Name = "_buttonCreate";
         this._buttonCreate.Size = new System.Drawing.Size(106, 23);
         this._buttonCreate.TabIndex = 0;
         this._buttonCreate.Text = "Create...";
         this._buttonCreate.UseVisualStyleBackColor = true;
         this._buttonCreate.Click += new System.EventHandler(this._buttonCreate_Click);
         // 
         // _buttonModify
         // 
         this._buttonModify.Anchor = System.Windows.Forms.AnchorStyles.None;
         this._buttonModify.Location = new System.Drawing.Point(16, 56);
         this._buttonModify.Name = "_buttonModify";
         this._buttonModify.Size = new System.Drawing.Size(106, 23);
         this._buttonModify.TabIndex = 1;
         this._buttonModify.Text = "Modify...";
         this._buttonModify.UseVisualStyleBackColor = true;
         this._buttonModify.Click += new System.EventHandler(this._buttonModify_Click);
         // 
         // groupBoxUserDefined
         // 
         this.groupBoxUserDefined.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxUserDefined.Controls.Add(this._buttonModify);
         this.groupBoxUserDefined.Controls.Add(this._buttonCreate);
         this.groupBoxUserDefined.Controls.Add(this._buttonDelete);
         this.groupBoxUserDefined.Location = new System.Drawing.Point(520, 24);
         this.groupBoxUserDefined.Name = "groupBoxUserDefined";
         this.groupBoxUserDefined.Size = new System.Drawing.Size(128, 128);
         this.groupBoxUserDefined.TabIndex = 6;
         this.groupBoxUserDefined.TabStop = false;
         this.groupBoxUserDefined.Text = "User-Defined IOD - ";
         // 
         // columnHeaderMasterUid
         // 
         this.columnHeaderMasterUid.Text = "UID";
         this.columnHeaderMasterUid.Width = 37;
         // 
         // columnHeaderMasterDescription
         // 
         this.columnHeaderMasterDescription.Text = "Description";
         this.columnHeaderMasterDescription.Width = 69;
         // 
         // _listViewMaster
         // 
         this._listViewMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._listViewMaster.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderMasterUid,
            this.columnHeaderMasterDescription});
         this._listViewMaster.FullRowSelect = true;
         this._listViewMaster.HideSelection = false;
         this._listViewMaster.Location = new System.Drawing.Point(16, 32);
         this._listViewMaster.Name = "_listViewMaster";
         this._listViewMaster.Size = new System.Drawing.Size(488, 183);
         this._listViewMaster.TabIndex = 1;
         this._listViewMaster.UseCompatibleStateImageBehavior = false;
         this._listViewMaster.View = System.Windows.Forms.View.Details;
         this._listViewMaster.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this._listViewMaster_ColumnClick);
         this._listViewMaster.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this._listViewMaster_ItemSelectionChanged);
         this._listViewMaster.DoubleClick += new System.EventHandler(this._listViewMaster_DoubleClick);
         // 
         // columnHeaderSupportedUid
         // 
         this.columnHeaderSupportedUid.Text = "UID";
         // 
         // columnHeaderSupportedDescription
         // 
         this.columnHeaderSupportedDescription.Text = "Description";
         this.columnHeaderSupportedDescription.Width = 78;
         // 
         // _listViewSupported
         // 
         this._listViewSupported.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._listViewSupported.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSupportedUid,
            this.columnHeaderSupportedDescription});
         this._listViewSupported.FullRowSelect = true;
         this._listViewSupported.HideSelection = false;
         this._listViewSupported.Location = new System.Drawing.Point(16, 281);
         this._listViewSupported.Name = "_listViewSupported";
         this._listViewSupported.Size = new System.Drawing.Size(488, 191);
         this._listViewSupported.TabIndex = 3;
         this._listViewSupported.UseCompatibleStateImageBehavior = false;
         this._listViewSupported.View = System.Windows.Forms.View.Details;
         this._listViewSupported.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this._listViewSupported_ColumnClick);
         this._listViewSupported.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this._listViewSupported_ItemSelectionChanged);
         this._listViewSupported.DoubleClick += new System.EventHandler(this._listViewSupported_DoubleClick);
         // 
         // _buttonAdd
         // 
         this._buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this._buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("_buttonAdd.Image")));
         this._buttonAdd.Location = new System.Drawing.Point(200, 224);
         this._buttonAdd.Name = "_buttonAdd";
         this._buttonAdd.Size = new System.Drawing.Size(56, 48);
         this._buttonAdd.TabIndex = 4;
         this._buttonAdd.Text = "Add";
         this._buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
         this._buttonAdd.UseVisualStyleBackColor = true;
         this._buttonAdd.Click += new System.EventHandler(this._buttonAdd_Click);
         // 
         // _buttonRemove
         // 
         this._buttonRemove.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this._buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("_buttonRemove.Image")));
         this._buttonRemove.Location = new System.Drawing.Point(280, 224);
         this._buttonRemove.Name = "_buttonRemove";
         this._buttonRemove.Size = new System.Drawing.Size(56, 48);
         this._buttonRemove.TabIndex = 5;
         this._buttonRemove.Text = "Remove";
         this._buttonRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
         this._buttonRemove.UseVisualStyleBackColor = true;
         this._buttonRemove.Click += new System.EventHandler(this._buttonRemove_Click);
         // 
         // labelMaster
         // 
         this.labelMaster.AutoSize = true;
         this.labelMaster.Location = new System.Drawing.Point(16, 15);
         this.labelMaster.Name = "labelMaster";
         this.labelMaster.Size = new System.Drawing.Size(120, 13);
         this.labelMaster.TabIndex = 0;
         this.labelMaster.Text = "Master Storage IOD List";
         // 
         // labelSupported
         // 
         this.labelSupported.AutoSize = true;
         this.labelSupported.Location = new System.Drawing.Point(16, 264);
         this.labelSupported.Name = "labelSupported";
         this.labelSupported.Size = new System.Drawing.Size(137, 13);
         this.labelSupported.TabIndex = 2;
         this.labelSupported.Text = "Supported Storage IOD List";
         // 
         // StorageClassesControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.groupBoxUserDefined);
         this.Controls.Add(this.buttonTransferSyntax);
         this.Controls.Add(this.labelSupported);
         this.Controls.Add(this.labelMaster);
         this.Controls.Add(this._buttonRemove);
         this.Controls.Add(this._buttonAdd);
         this.Controls.Add(this._listViewSupported);
         this.Controls.Add(this._listViewMaster);
         this.Name = "StorageClassesControl";
         this.Size = new System.Drawing.Size(660, 488);
         this.Load += new System.EventHandler(this.StorageClassesControl_Load);
         this.VisibleChanged += new System.EventHandler(this.StorageClassesControl_VisibleChanged);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.groupBoxUserDefined.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Button buttonTransferSyntax;
      private System.Windows.Forms.Button _buttonDelete;
      private System.Windows.Forms.Button _buttonCreate;
      private System.Windows.Forms.Button _buttonModify;
      private System.Windows.Forms.GroupBox groupBoxUserDefined;
      private System.Windows.Forms.ColumnHeader columnHeaderMasterUid;
      private System.Windows.Forms.ColumnHeader columnHeaderMasterDescription;
      private System.Windows.Forms.ListView _listViewMaster;
      private System.Windows.Forms.ColumnHeader columnHeaderSupportedUid;
      private System.Windows.Forms.ColumnHeader columnHeaderSupportedDescription;
      private System.Windows.Forms.ListView _listViewSupported;
      private System.Windows.Forms.Button _buttonAdd;
      private System.Windows.Forms.Button _buttonRemove;
      private System.Windows.Forms.Label labelMaster;
      private System.Windows.Forms.Label labelSupported;
   }
}