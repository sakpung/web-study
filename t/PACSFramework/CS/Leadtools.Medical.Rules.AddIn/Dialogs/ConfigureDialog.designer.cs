
using Leadtools.Medical.Rules.AddIn;
namespace Leadtools.Medical.Rules.AddIn.Dialogs
{
   partial class ConfigureDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureDialog));
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.tabPageResends = new System.Windows.Forms.TabPage();
            this.tabControlStoreMove = new System.Windows.Forms.TabControl();
            this.tabPageStores = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewDatasets = new System.Windows.Forms.ListView();
            this._columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListDataset = new System.Windows.Forms.ImageList(this.components);
            this.listViewServers = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDeleteServer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteAllServers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonVerify = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDeleteImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteAllImages = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonViewInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRetry = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRetryAll = new System.Windows.Forms.ToolStripButton();
            this.tabPageMoves = new System.Windows.Forms.TabPage();
            this.listViewMoves = new System.Windows.Forms.ListView();
            this.columnLastStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDestinationAE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnIdInstance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnIdInstanceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDeleteRequest = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteAllRequests = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRetryRequest = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRetryAllRequests = new System.Windows.Forms.ToolStripButton();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this._columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControlOptions.SuspendLayout();
            this.tabPageResends.SuspendLayout();
            this.tabControlStoreMove.SuspendLayout();
            this.tabPageStores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPageMoves.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.tabPageOptions);
            this.tabControlOptions.Controls.Add(this.tabPageResends);
            this.tabControlOptions.Controls.Add(this.tabPageDetails);
            this.tabControlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOptions.Location = new System.Drawing.Point(0, 0);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(775, 512);
            this.tabControlOptions.TabIndex = 0;
            this.tabControlOptions.SelectedIndexChanged += new System.EventHandler(this.tabControlOptions_SelectedIndexChanged);
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptions.Size = new System.Drawing.Size(767, 486);
            this.tabPageOptions.TabIndex = 0;
            this.tabPageOptions.Text = "Script";
            this.tabPageOptions.UseVisualStyleBackColor = true;
            // 
            // tabPageResends
            // 
            this.tabPageResends.Controls.Add(this.tabControlStoreMove);
            this.tabPageResends.Location = new System.Drawing.Point(4, 22);
            this.tabPageResends.Name = "tabPageResends";
            this.tabPageResends.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResends.Size = new System.Drawing.Size(767, 486);
            this.tabPageResends.TabIndex = 2;
            this.tabPageResends.Text = "Manual Resends";
            this.tabPageResends.UseVisualStyleBackColor = true;
            // 
            // tabControlStoreMove
            // 
            this.tabControlStoreMove.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlStoreMove.Controls.Add(this.tabPageStores);
            this.tabControlStoreMove.Controls.Add(this.tabPageMoves);
            this.tabControlStoreMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlStoreMove.Location = new System.Drawing.Point(3, 3);
            this.tabControlStoreMove.Multiline = true;
            this.tabControlStoreMove.Name = "tabControlStoreMove";
            this.tabControlStoreMove.SelectedIndex = 0;
            this.tabControlStoreMove.Size = new System.Drawing.Size(761, 480);
            this.tabControlStoreMove.TabIndex = 1;
            this.tabControlStoreMove.SelectedIndexChanged += new System.EventHandler(this.tabControlStoreMove_SelectedIndexChanged);
            // 
            // tabPageStores
            // 
            this.tabPageStores.Controls.Add(this.splitContainer1);
            this.tabPageStores.Controls.Add(this.toolStrip2);
            this.tabPageStores.Location = new System.Drawing.Point(23, 4);
            this.tabPageStores.Name = "tabPageStores";
            this.tabPageStores.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStores.Size = new System.Drawing.Size(734, 472);
            this.tabPageStores.TabIndex = 0;
            this.tabPageStores.Text = "Route";
            this.tabPageStores.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewDatasets);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewServers);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip3);
            this.splitContainer1.Size = new System.Drawing.Size(728, 441);
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 4;
            // 
            // listViewDatasets
            // 
            this.listViewDatasets.AllowDrop = true;
            this.listViewDatasets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._columnHeader1,
            this._columnHeader2,
            this._columnHeader3,
            this._columnHeader4,
            this._columnHeader5,
            this._columnHeader6});
            this.listViewDatasets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDatasets.FullRowSelect = true;
            this.listViewDatasets.GridLines = true;
            this.listViewDatasets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDatasets.HideSelection = false;
            this.listViewDatasets.Location = new System.Drawing.Point(0, 0);
            this.listViewDatasets.MultiSelect = false;
            this.listViewDatasets.Name = "listViewDatasets";
            this.listViewDatasets.Size = new System.Drawing.Size(728, 226);
            this.listViewDatasets.SmallImageList = this.imageListDataset;
            this.listViewDatasets.TabIndex = 1;
            this.listViewDatasets.UseCompatibleStateImageBehavior = false;
            this.listViewDatasets.View = System.Windows.Forms.View.Details;
            this.listViewDatasets.SelectedIndexChanged += new System.EventHandler(this.listViewDatasets_SelectedIndexChanged);
            this.listViewDatasets.DoubleClick += new System.EventHandler(this.listViewDatasets_DoubleClick);
            // 
            // _columnHeader1
            // 
            this._columnHeader1.Text = "Patient Name";
            this._columnHeader1.Width = 120;
            // 
            // _columnHeader2
            // 
            this._columnHeader2.Text = "Patient ID";
            this._columnHeader2.Width = 75;
            // 
            // _columnHeader3
            // 
            this._columnHeader3.Text = "Study ID";
            // 
            // _columnHeader4
            // 
            this._columnHeader4.Text = "Modality";
            // 
            // _columnHeader5
            // 
            this._columnHeader5.Text = "Transfer Syntax";
            this._columnHeader5.Width = 90;
            // 
            // imageListDataset
            // 
            this.imageListDataset.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDataset.ImageStream")));
            this.imageListDataset.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDataset.Images.SetKeyName(0, "retry.png");
            // 
            // listViewServers
            // 
            this.listViewServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7});
            this.listViewServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewServers.FullRowSelect = true;
            this.listViewServers.GridLines = true;
            this.listViewServers.HideSelection = false;
            this.listViewServers.Location = new System.Drawing.Point(0, 25);
            this.listViewServers.MultiSelect = false;
            this.listViewServers.Name = "listViewServers";
            this.listViewServers.Size = new System.Drawing.Size(728, 186);
            this.listViewServers.TabIndex = 5;
            this.listViewServers.UseCompatibleStateImageBehavior = false;
            this.listViewServers.View = System.Windows.Forms.View.Details;
            this.listViewServers.SelectedIndexChanged += new System.EventHandler(this.listViewServers_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Last Status";
            this.columnHeader6.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "AETitle";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "IP Address";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Port";
            this.columnHeader7.Width = 45;
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDeleteServer,
            this.toolStripButtonDeleteAllServers,
            this.toolStripSeparator2,
            this.toolStripButtonVerify});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(728, 25);
            this.toolStrip3.TabIndex = 4;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButtonDeleteServer
            // 
            this.toolStripButtonDeleteServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteServer.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.DeleteItem;
            this.toolStripButtonDeleteServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteServer.Name = "toolStripButtonDeleteServer";
            this.toolStripButtonDeleteServer.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteServer.Text = "Delete server";
            this.toolStripButtonDeleteServer.Click += new System.EventHandler(this.toolStripButtonDeleteServer_Click);
            // 
            // toolStripButtonDeleteAllServers
            // 
            this.toolStripButtonDeleteAllServers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteAllServers.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.DeleteAll;
            this.toolStripButtonDeleteAllServers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteAllServers.Name = "toolStripButtonDeleteAllServers";
            this.toolStripButtonDeleteAllServers.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteAllServers.Text = "Delete all servers";
            this.toolStripButtonDeleteAllServers.Click += new System.EventHandler(this.toolStripButtonDeleteAllServers_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonVerify
            // 
            this.toolStripButtonVerify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVerify.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.ServerVerify;
            this.toolStripButtonVerify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVerify.Name = "toolStripButtonVerify";
            this.toolStripButtonVerify.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonVerify.Text = "Verify server";
            this.toolStripButtonVerify.Click += new System.EventHandler(this.toolStripButtonVerify_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDeleteImage,
            this.toolStripButtonDeleteAllImages,
            this.toolStripSeparator1,
            this.toolStripButtonViewInfo,
            this.toolStripSplitButton1,
            this.toolStripButtonRetry,
            this.toolStripButtonRetryAll});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(728, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonDeleteImage
            // 
            this.toolStripButtonDeleteImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteImage.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.DeleteItem;
            this.toolStripButtonDeleteImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteImage.Name = "toolStripButtonDeleteImage";
            this.toolStripButtonDeleteImage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteImage.Text = "Delete image";
            this.toolStripButtonDeleteImage.ToolTipText = "Delete dataset";
            this.toolStripButtonDeleteImage.Click += new System.EventHandler(this.toolStripButtonDeleteImage_Click);
            // 
            // toolStripButtonDeleteAllImages
            // 
            this.toolStripButtonDeleteAllImages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteAllImages.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.DeleteAll;
            this.toolStripButtonDeleteAllImages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteAllImages.Name = "toolStripButtonDeleteAllImages";
            this.toolStripButtonDeleteAllImages.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteAllImages.Text = "Delete all images";
            this.toolStripButtonDeleteAllImages.ToolTipText = "Delete all datasets";
            this.toolStripButtonDeleteAllImages.Click += new System.EventHandler(this.toolStripButtonDeleteAllImages_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonViewInfo
            // 
            this.toolStripButtonViewInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonViewInfo.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.ViewDataset;
            this.toolStripButtonViewInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonViewInfo.Name = "toolStripButtonViewInfo";
            this.toolStripButtonViewInfo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonViewInfo.Text = "View dicom info";
            this.toolStripButtonViewInfo.ToolTipText = "View dataset info";
            this.toolStripButtonViewInfo.Click += new System.EventHandler(this.toolStripButtonViewInfo_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRetry
            // 
            this.toolStripButtonRetry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRetry.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.Retry;
            this.toolStripButtonRetry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRetry.Name = "toolStripButtonRetry";
            this.toolStripButtonRetry.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRetry.Text = "Retry";
            this.toolStripButtonRetry.Click += new System.EventHandler(this.toolStripButtonRetry_Click);
            // 
            // toolStripButtonRetryAll
            // 
            this.toolStripButtonRetryAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRetryAll.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.RetryAll;
            this.toolStripButtonRetryAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRetryAll.Name = "toolStripButtonRetryAll";
            this.toolStripButtonRetryAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRetryAll.Text = "Retry all";
            this.toolStripButtonRetryAll.Click += new System.EventHandler(this.toolStripButtonRetryAll_Click);
            // 
            // tabPageMoves
            // 
            this.tabPageMoves.Controls.Add(this.listViewMoves);
            this.tabPageMoves.Controls.Add(this.toolStrip1);
            this.tabPageMoves.Location = new System.Drawing.Point(23, 4);
            this.tabPageMoves.Name = "tabPageMoves";
            this.tabPageMoves.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMoves.Size = new System.Drawing.Size(734, 472);
            this.tabPageMoves.TabIndex = 1;
            this.tabPageMoves.Text = "Move";
            this.tabPageMoves.UseVisualStyleBackColor = true;
            // 
            // listViewMoves
            // 
            this.listViewMoves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnLastStatus,
            this.columnDestinationAE,
            this.columnIdInstance,
            this.columnIdInstanceType,
            this.columnHeaderFilename});
            this.listViewMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMoves.FullRowSelect = true;
            this.listViewMoves.Location = new System.Drawing.Point(3, 3);
            this.listViewMoves.Name = "listViewMoves";
            this.listViewMoves.Size = new System.Drawing.Size(728, 466);
            this.listViewMoves.TabIndex = 0;
            this.listViewMoves.UseCompatibleStateImageBehavior = false;
            this.listViewMoves.View = System.Windows.Forms.View.Details;
            this.listViewMoves.SelectedIndexChanged += new System.EventHandler(this.listViewMoves_SelectedIndexChanged);
            // 
            // columnLastStatus
            // 
            this.columnLastStatus.Text = "Last Status";
            this.columnLastStatus.Width = 150;
            // 
            // columnDestinationAE
            // 
            this.columnDestinationAE.Text = "Destination AE";
            this.columnDestinationAE.Width = 125;
            // 
            // columnIdInstance
            // 
            this.columnIdInstance.Text = "Id / Instance UID";
            this.columnIdInstance.Width = 150;
            // 
            // columnIdInstanceType
            // 
            this.columnIdInstanceType.Text = "Id / InstanceUID Type";
            this.columnIdInstanceType.Width = 125;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDeleteRequest,
            this.toolStripButtonDeleteAllRequests,
            this.toolStripSeparator3,
            this.toolStripButtonRetryRequest,
            this.toolStripButtonRetryAllRequests});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(728, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // toolStripButtonDeleteRequest
            // 
            this.toolStripButtonDeleteRequest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteRequest.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.DeleteItem;
            this.toolStripButtonDeleteRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteRequest.Name = "toolStripButtonDeleteRequest";
            this.toolStripButtonDeleteRequest.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteRequest.Text = "Delete request";
            this.toolStripButtonDeleteRequest.Click += new System.EventHandler(this.toolStripButtonDeleteRequest_Click);
            // 
            // toolStripButtonDeleteAllRequests
            // 
            this.toolStripButtonDeleteAllRequests.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteAllRequests.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.DeleteAll;
            this.toolStripButtonDeleteAllRequests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteAllRequests.Name = "toolStripButtonDeleteAllRequests";
            this.toolStripButtonDeleteAllRequests.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteAllRequests.Text = "Delete all requests";
            this.toolStripButtonDeleteAllRequests.Click += new System.EventHandler(this.toolStripButtonDeleteAllRequests_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRetryRequest
            // 
            this.toolStripButtonRetryRequest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRetryRequest.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.Retry;
            this.toolStripButtonRetryRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRetryRequest.Name = "toolStripButtonRetryRequest";
            this.toolStripButtonRetryRequest.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRetryRequest.Text = "Retry";
            this.toolStripButtonRetryRequest.Click += new System.EventHandler(this.toolStripButtonRetryRequest_Click);
            // 
            // toolStripButtonRetryAllRequests
            // 
            this.toolStripButtonRetryAllRequests.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRetryAllRequests.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.RetryAll;
            this.toolStripButtonRetryAllRequests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRetryAllRequests.Name = "toolStripButtonRetryAllRequests";
            this.toolStripButtonRetryAllRequests.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRetryAllRequests.Text = "Retry all";
            this.toolStripButtonRetryAllRequests.Click += new System.EventHandler(this.toolStripButtonRetryAllRequests_Click);
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetails.Size = new System.Drawing.Size(767, 486);
            this.tabPageDetails.TabIndex = 1;
            this.tabPageDetails.Text = "Details";
            this.tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 512);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 45);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(607, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "&OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(688, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _columnHeader6
            // 
            this._columnHeader6.Width = 0;
            // 
            // columnHeaderFilename
            // 
            this.columnHeaderFilename.Width = 0;
            // 
            // ConfigureDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 557);
            this.Controls.Add(this.tabControlOptions);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigureDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rules Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigureDialog_FormClosing);
            this.Load += new System.EventHandler(this.ConfigureDialog_Load);
            this.tabControlOptions.ResumeLayout(false);
            this.tabPageResends.ResumeLayout(false);
            this.tabControlStoreMove.ResumeLayout(false);
            this.tabPageStores.ResumeLayout(false);
            this.tabPageStores.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPageMoves.ResumeLayout(false);
            this.tabPageMoves.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControlOptions;
      private System.Windows.Forms.TabPage tabPageOptions;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TabPage tabPageDetails;
      private RuleEditorUserControl ruleEditorUserControl;
      private System.Windows.Forms.TabPage tabPageResends;
      private System.Windows.Forms.TabControl tabControlStoreMove;
      private System.Windows.Forms.TabPage tabPageStores;
      private System.Windows.Forms.TabPage tabPageMoves;
      private System.Windows.Forms.ListView listViewMoves;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStrip toolStrip2;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.ListView listViewDatasets;
      private System.Windows.Forms.ColumnHeader _columnHeader1;
      private System.Windows.Forms.ColumnHeader _columnHeader2;
      private System.Windows.Forms.ColumnHeader _columnHeader3;
      private System.Windows.Forms.ColumnHeader _columnHeader4;
      private System.Windows.Forms.ColumnHeader _columnHeader5;
      private System.Windows.Forms.ListView listViewServers;
      private System.Windows.Forms.ColumnHeader columnHeader6;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      private System.Windows.Forms.ColumnHeader columnHeader7;
      private System.Windows.Forms.ToolStrip toolStrip3;
      private System.Windows.Forms.ToolStripButton toolStripButtonDeleteImage;
      private System.Windows.Forms.ToolStripButton toolStripButtonDeleteAllImages;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton toolStripButtonViewInfo;
      private System.Windows.Forms.ToolStripButton toolStripButtonDeleteServer;
      private System.Windows.Forms.ToolStripButton toolStripButtonDeleteAllServers;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton toolStripButtonVerify;
      private System.Windows.Forms.ToolStripSeparator toolStripSplitButton1;
      private System.Windows.Forms.ToolStripButton toolStripButtonRetry;
      private System.Windows.Forms.ToolStripButton toolStripButtonRetryAll;
      private System.Windows.Forms.ColumnHeader columnLastStatus;
      private System.Windows.Forms.ColumnHeader columnDestinationAE;
      private System.Windows.Forms.ColumnHeader columnIdInstance;
      private System.Windows.Forms.ColumnHeader columnIdInstanceType;
      private System.Windows.Forms.ToolStripButton toolStripButtonDeleteRequest;
      private System.Windows.Forms.ToolStripButton toolStripButtonDeleteAllRequests;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton toolStripButtonRetryRequest;
      private System.Windows.Forms.ToolStripButton toolStripButtonRetryAllRequests;
      private System.Windows.Forms.ImageList imageListDataset;
      private System.Windows.Forms.ColumnHeader _columnHeader6;
      private System.Windows.Forms.ColumnHeader columnHeaderFilename;
   }
}