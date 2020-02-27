namespace DicomDemo
{
   partial class MainForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._splitContainer = new System.Windows.Forms.SplitContainer();
         this._listViewImages = new System.Windows.Forms.ListView();
         this._columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._contextMenuStripImages = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._toolStripMenuItemRemoveSelected = new System.Windows.Forms.ToolStripMenuItem();
         this._toolStripMenuItemRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
         this._label1 = new System.Windows.Forms.Label();
         this._splitContainer1 = new System.Windows.Forms.SplitContainer();
         this._buttonStorageCommit = new System.Windows.Forms.Button();
         this._buttonCancel = new System.Windows.Forms.Button();
         this._groupBoxServer = new System.Windows.Forms.GroupBox();
         this._labelServerPort = new System.Windows.Forms.Label();
         this._labelServerIp = new System.Windows.Forms.Label();
         this._labelServerAeTitle = new System.Windows.Forms.Label();
         this._textBoxServerPort = new System.Windows.Forms.TextBox();
         this._textBoxServerIp = new System.Windows.Forms.TextBox();
         this._comboBoxService = new System.Windows.Forms.ComboBox();
         this._buttonStore = new System.Windows.Forms.Button();
         this._buttonOptions = new System.Windows.Forms.Button();
         this._labelStatus = new System.Windows.Forms.Label();
         this._richTextBoxLog = new System.Windows.Forms.RichTextBox();
         this._contextMenuStripLog = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.clearLogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this._label2 = new System.Windows.Forms.Label();
         this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.addDICOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.addDICOMDIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.storeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.showHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuStrip = new System.Windows.Forms.MenuStrip();
         this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
         this._splitContainer.Panel1.SuspendLayout();
         this._splitContainer.Panel2.SuspendLayout();
         this._splitContainer.SuspendLayout();
         this._contextMenuStripImages.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
         this._splitContainer1.Panel1.SuspendLayout();
         this._splitContainer1.Panel2.SuspendLayout();
         this._splitContainer1.SuspendLayout();
         this._groupBoxServer.SuspendLayout();
         this._contextMenuStripLog.SuspendLayout();
         this._menuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _splitContainer
         // 
         this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer.Location = new System.Drawing.Point(0, 24);
         this._splitContainer.Name = "_splitContainer";
         this._splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splitContainer.Panel1
         // 
         this._splitContainer.Panel1.Controls.Add(this._listViewImages);
         this._splitContainer.Panel1.Controls.Add(this._label1);
         // 
         // _splitContainer.Panel2
         // 
         this._splitContainer.Panel2.Controls.Add(this._splitContainer1);
         this._splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this._splitContainer.Size = new System.Drawing.Size(747, 512);
         this._splitContainer.SplitterDistance = 291;
         this._splitContainer.TabIndex = 0;
         // 
         // _listViewImages
         // 
         this._listViewImages.AllowDrop = true;
         this._listViewImages.CheckBoxes = true;
         this._listViewImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._columnHeader1,
            this._columnHeader2,
            this._columnHeader3,
            this._columnHeader4,
            this._columnHeader5,
            this._columnHeader6,
            this._columnHeader7});
         this._listViewImages.ContextMenuStrip = this._contextMenuStripImages;
         this._listViewImages.Dock = System.Windows.Forms.DockStyle.Fill;
         this._listViewImages.FullRowSelect = true;
         this._listViewImages.GridLines = true;
         this._listViewImages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this._listViewImages.HideSelection = false;
         this._listViewImages.Location = new System.Drawing.Point(0, 23);
         this._listViewImages.Name = "_listViewImages";
         this._listViewImages.Size = new System.Drawing.Size(747, 268);
         this._listViewImages.TabIndex = 1;
         this._listViewImages.UseCompatibleStateImageBehavior = false;
         this._listViewImages.View = System.Windows.Forms.View.Details;
         this._listViewImages.DragDrop += new System.Windows.Forms.DragEventHandler(this._listViewImages_DragDrop);
         this._listViewImages.DragEnter += new System.Windows.Forms.DragEventHandler(this._listViewImages_DragEnter);
         this._listViewImages.Resize += new System.EventHandler(this._listViewImages_Resize);
         // 
         // _columnHeader1
         // 
         this._columnHeader1.Text = "Patient Name";
         // 
         // _columnHeader2
         // 
         this._columnHeader2.Text = "Patient ID";
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
         // 
         // _columnHeader6
         // 
         this._columnHeader6.Text = "File Path";
         // 
         // _columnHeader7
         // 
         this._columnHeader7.Text = "SOP Instance UID";
         // 
         // _contextMenuStripImages
         // 
         this._contextMenuStripImages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItemRemoveSelected,
            this._toolStripMenuItemRemoveAll});
         this._contextMenuStripImages.Name = "_contextMenuStripImages";
         this._contextMenuStripImages.Size = new System.Drawing.Size(165, 48);
         // 
         // _toolStripMenuItemRemoveSelected
         // 
         this._toolStripMenuItemRemoveSelected.Name = "_toolStripMenuItemRemoveSelected";
         this._toolStripMenuItemRemoveSelected.Size = new System.Drawing.Size(164, 22);
         this._toolStripMenuItemRemoveSelected.Text = "Remove &Selected";
         this._toolStripMenuItemRemoveSelected.Click += new System.EventHandler(this._toolStripMenuItemRemoveSelected_Click);
         // 
         // _toolStripMenuItemRemoveAll
         // 
         this._toolStripMenuItemRemoveAll.Name = "_toolStripMenuItemRemoveAll";
         this._toolStripMenuItemRemoveAll.Size = new System.Drawing.Size(164, 22);
         this._toolStripMenuItemRemoveAll.Text = "Remove &All";
         this._toolStripMenuItemRemoveAll.Click += new System.EventHandler(this._toolStripMenuItemRemoveAll_Click);
         // 
         // _label1
         // 
         this._label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._label1.Dock = System.Windows.Forms.DockStyle.Top;
         this._label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._label1.Location = new System.Drawing.Point(0, 0);
         this._label1.Name = "_label1";
         this._label1.Size = new System.Drawing.Size(747, 23);
         this._label1.TabIndex = 0;
         this._label1.Text = "Images: (File->Add Dicom) or (Drag and Drop) -- Right-click to delete";
         // 
         // _splitContainer1
         // 
         this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer1.Location = new System.Drawing.Point(0, 0);
         this._splitContainer1.Name = "_splitContainer1";
         // 
         // _splitContainer1.Panel1
         // 
         this._splitContainer1.Panel1.Controls.Add(this._buttonStorageCommit);
         this._splitContainer1.Panel1.Controls.Add(this._buttonCancel);
         this._splitContainer1.Panel1.Controls.Add(this._groupBoxServer);
         this._splitContainer1.Panel1.Controls.Add(this._buttonStore);
         this._splitContainer1.Panel1.Controls.Add(this._buttonOptions);
         // 
         // _splitContainer1.Panel2
         // 
         this._splitContainer1.Panel2.Controls.Add(this._labelStatus);
         this._splitContainer1.Panel2.Controls.Add(this._richTextBoxLog);
         this._splitContainer1.Panel2.Controls.Add(this._label2);
         this._splitContainer1.Panel2.Resize += new System.EventHandler(this.splitContainer1_Panel2_Resize);
         this._splitContainer1.Size = new System.Drawing.Size(747, 217);
         this._splitContainer1.SplitterDistance = 245;
         this._splitContainer1.TabIndex = 2;
         // 
         // _buttonStorageCommit
         // 
         this._buttonStorageCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._buttonStorageCommit.Location = new System.Drawing.Point(3, 186);
         this._buttonStorageCommit.Name = "_buttonStorageCommit";
         this._buttonStorageCommit.Size = new System.Drawing.Size(106, 23);
         this._buttonStorageCommit.TabIndex = 11;
         this._buttonStorageCommit.Text = "Storage Commit";
         this._buttonStorageCommit.UseVisualStyleBackColor = true;
         this._buttonStorageCommit.Click += new System.EventHandler(this._buttonStorageCommit_Click);
         // 
         // _buttonCancel
         // 
         this._buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._buttonCancel.Location = new System.Drawing.Point(167, 157);
         this._buttonCancel.Name = "_buttonCancel";
         this._buttonCancel.Size = new System.Drawing.Size(75, 23);
         this._buttonCancel.TabIndex = 3;
         this._buttonCancel.Text = "&Cancel";
         this._buttonCancel.UseVisualStyleBackColor = true;
         this._buttonCancel.Click += new System.EventHandler(this._buttonCancel_Click);
         // 
         // _groupBoxServer
         // 
         this._groupBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._groupBoxServer.Controls.Add(this._labelServerPort);
         this._groupBoxServer.Controls.Add(this._labelServerIp);
         this._groupBoxServer.Controls.Add(this._labelServerAeTitle);
         this._groupBoxServer.Controls.Add(this._textBoxServerPort);
         this._groupBoxServer.Controls.Add(this._textBoxServerIp);
         this._groupBoxServer.Controls.Add(this._comboBoxService);
         this._groupBoxServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._groupBoxServer.Location = new System.Drawing.Point(0, 0);
         this._groupBoxServer.Name = "_groupBoxServer";
         this._groupBoxServer.Size = new System.Drawing.Size(248, 122);
         this._groupBoxServer.TabIndex = 10;
         this._groupBoxServer.TabStop = false;
         this._groupBoxServer.Text = "Server";
         // 
         // _labelServerPort
         // 
         this._labelServerPort.AutoSize = true;
         this._labelServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._labelServerPort.Location = new System.Drawing.Point(8, 67);
         this._labelServerPort.Name = "_labelServerPort";
         this._labelServerPort.Size = new System.Drawing.Size(29, 13);
         this._labelServerPort.TabIndex = 14;
         this._labelServerPort.Text = "Port:";
         this._labelServerPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _labelServerIp
         // 
         this._labelServerIp.AutoSize = true;
         this._labelServerIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._labelServerIp.Location = new System.Drawing.Point(8, 44);
         this._labelServerIp.Name = "_labelServerIp";
         this._labelServerIp.Size = new System.Drawing.Size(20, 13);
         this._labelServerIp.TabIndex = 13;
         this._labelServerIp.Text = "IP:";
         this._labelServerIp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _labelServerAeTitle
         // 
         this._labelServerAeTitle.AutoSize = true;
         this._labelServerAeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._labelServerAeTitle.Location = new System.Drawing.Point(8, 20);
         this._labelServerAeTitle.Name = "_labelServerAeTitle";
         this._labelServerAeTitle.Size = new System.Drawing.Size(24, 13);
         this._labelServerAeTitle.TabIndex = 12;
         this._labelServerAeTitle.Text = "AE:";
         this._labelServerAeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _textBoxServerPort
         // 
         this._textBoxServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._textBoxServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._textBoxServerPort.Location = new System.Drawing.Point(48, 63);
         this._textBoxServerPort.Name = "_textBoxServerPort";
         this._textBoxServerPort.ReadOnly = true;
         this._textBoxServerPort.Size = new System.Drawing.Size(195, 20);
         this._textBoxServerPort.TabIndex = 11;
         // 
         // _textBoxServerIp
         // 
         this._textBoxServerIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._textBoxServerIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._textBoxServerIp.Location = new System.Drawing.Point(48, 40);
         this._textBoxServerIp.Name = "_textBoxServerIp";
         this._textBoxServerIp.ReadOnly = true;
         this._textBoxServerIp.Size = new System.Drawing.Size(195, 20);
         this._textBoxServerIp.TabIndex = 10;
         // 
         // _comboBoxService
         // 
         this._comboBoxService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._comboBoxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboBoxService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._comboBoxService.FormattingEnabled = true;
         this._comboBoxService.Location = new System.Drawing.Point(48, 16);
         this._comboBoxService.Name = "_comboBoxService";
         this._comboBoxService.Size = new System.Drawing.Size(195, 21);
         this._comboBoxService.TabIndex = 9;
         this._comboBoxService.SelectionChangeCommitted += new System.EventHandler(this._comboBoxService_SelectionChangeCommitted);
         // 
         // _buttonStore
         // 
         this._buttonStore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._buttonStore.Location = new System.Drawing.Point(3, 157);
         this._buttonStore.Name = "_buttonStore";
         this._buttonStore.Size = new System.Drawing.Size(106, 23);
         this._buttonStore.TabIndex = 1;
         this._buttonStore.Text = "&Store";
         this._buttonStore.UseVisualStyleBackColor = true;
         this._buttonStore.Click += new System.EventHandler(this._buttonStore_Click);
         // 
         // _buttonOptions
         // 
         this._buttonOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._buttonOptions.Location = new System.Drawing.Point(3, 128);
         this._buttonOptions.Name = "_buttonOptions";
         this._buttonOptions.Size = new System.Drawing.Size(106, 23);
         this._buttonOptions.TabIndex = 0;
         this._buttonOptions.Text = "&Options...";
         this._buttonOptions.UseVisualStyleBackColor = true;
         this._buttonOptions.Click += new System.EventHandler(this._buttonOptions_Click);
         // 
         // _labelStatus
         // 
         this._labelStatus.AutoSize = true;
         this._labelStatus.ForeColor = System.Drawing.Color.Blue;
         this._labelStatus.Location = new System.Drawing.Point(232, 8);
         this._labelStatus.Name = "_labelStatus";
         this._labelStatus.Size = new System.Drawing.Size(35, 13);
         this._labelStatus.TabIndex = 5;
         this._labelStatus.Text = "status";
         // 
         // _richTextBoxLog
         // 
         this._richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._richTextBoxLog.BackColor = System.Drawing.SystemColors.Control;
         this._richTextBoxLog.ContextMenuStrip = this._contextMenuStripLog;
         this._richTextBoxLog.Location = new System.Drawing.Point(0, 24);
         this._richTextBoxLog.Name = "_richTextBoxLog";
         this._richTextBoxLog.ReadOnly = true;
         this._richTextBoxLog.Size = new System.Drawing.Size(504, 195);
         this._richTextBoxLog.TabIndex = 4;
         this._richTextBoxLog.Text = "";
         this._richTextBoxLog.WordWrap = false;
         // 
         // _contextMenuStripLog
         // 
         this._contextMenuStripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogToolStripMenuItem1});
         this._contextMenuStripLog.Name = "_contextMenuStripLog";
         this._contextMenuStripLog.Size = new System.Drawing.Size(125, 26);
         // 
         // clearLogToolStripMenuItem1
         // 
         this.clearLogToolStripMenuItem1.Name = "clearLogToolStripMenuItem1";
         this.clearLogToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
         this.clearLogToolStripMenuItem1.Text = "&Clear Log";
         this.clearLogToolStripMenuItem1.Click += new System.EventHandler(this.clearLogToolStripMenuItem1_Click);
         // 
         // _label2
         // 
         this._label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._label2.Location = new System.Drawing.Point(0, 0);
         this._label2.Name = "_label2";
         this._label2.Size = new System.Drawing.Size(500, 23);
         this._label2.TabIndex = 3;
         this._label2.Text = "Log: (Right-click to clear)";
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDICOMToolStripMenuItem,
            this.addDICOMDIRToolStripMenuItem,
            this.toolStripSeparator1,
            this.removeSelectedToolStripMenuItem,
            this.removeAllToolStripMenuItem,
            this.toolStripSeparator4,
            this.optionsToolStripMenuItem,
            this.clearLogToolStripMenuItem,
            this.toolStripSeparator2,
            this.storeToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
         this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
         this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this._fileToolStripMenuItem.Text = "&File";
         // 
         // addDICOMToolStripMenuItem
         // 
         this.addDICOMToolStripMenuItem.Name = "addDICOMToolStripMenuItem";
         this.addDICOMToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.addDICOMToolStripMenuItem.Text = "Add &DICOM...";
         this.addDICOMToolStripMenuItem.Click += new System.EventHandler(this.addDICOMToolStripMenuItem_Click);
         // 
         // addDICOMDIRToolStripMenuItem
         // 
         this.addDICOMDIRToolStripMenuItem.Name = "addDICOMDIRToolStripMenuItem";
         this.addDICOMDIRToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.addDICOMDIRToolStripMenuItem.Text = "Add DICOMDI&R...";
         this.addDICOMDIRToolStripMenuItem.Click += new System.EventHandler(this.addDICOMDIRToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
         // 
         // removeSelectedToolStripMenuItem
         // 
         this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
         this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.removeSelectedToolStripMenuItem.Text = "Remove &Selected";
         this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
         // 
         // removeAllToolStripMenuItem
         // 
         this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
         this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.removeAllToolStripMenuItem.Text = "Remove &All";
         this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.removeAllToolStripMenuItem_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(162, 6);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.optionsToolStripMenuItem.Text = "&Options...";
         this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
         // 
         // clearLogToolStripMenuItem
         // 
         this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
         this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.clearLogToolStripMenuItem.Text = "&Clear Log";
         this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
         // 
         // storeToolStripMenuItem
         // 
         this.storeToolStripMenuItem.Name = "storeToolStripMenuItem";
         this.storeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.storeToolStripMenuItem.Text = "&Store";
         this.storeToolStripMenuItem.Click += new System.EventHandler(this.storeToolStripMenuItem_Click);
         // 
         // cancelToolStripMenuItem
         // 
         this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
         this.cancelToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.cancelToolStripMenuItem.Text = "&Cancel";
         this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(162, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
         this.exitToolStripMenuItem.Text = "&Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // _helpToolStripMenuItem
         // 
         this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
         this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
         this._helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this._helpToolStripMenuItem.Text = "&Help";
         // 
         // showHelpToolStripMenuItem
         // 
         this.showHelpToolStripMenuItem.Name = "showHelpToolStripMenuItem";
         this.showHelpToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
         this.showHelpToolStripMenuItem.Text = "&Show Help...";
         this.showHelpToolStripMenuItem.Click += new System.EventHandler(this.showHelpToolStripMenuItem_Click);
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
         this.aboutToolStripMenuItem.Text = "&About...";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
         // 
         // _menuStrip
         // 
         this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._helpToolStripMenuItem});
         this._menuStrip.Location = new System.Drawing.Point(0, 0);
         this._menuStrip.Name = "_menuStrip";
         this._menuStrip.Size = new System.Drawing.Size(747, 24);
         this._menuStrip.TabIndex = 1;
         this._menuStrip.Text = "_menuStrip";
         // 
         // _openFileDialog
         // 
         this._openFileDialog.FileName = "_openFileDialog";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(747, 536);
         this.Controls.Add(this._splitContainer);
         this.Controls.Add(this._menuStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.Text = "LEADTOOLS High Level DICOM Store Demo - C#";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.Shown += new System.EventHandler(this.MainForm_Shown);
         this._splitContainer.Panel1.ResumeLayout(false);
         this._splitContainer.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
         this._splitContainer.ResumeLayout(false);
         this._contextMenuStripImages.ResumeLayout(false);
         this._splitContainer1.Panel1.ResumeLayout(false);
         this._splitContainer1.Panel2.ResumeLayout(false);
         this._splitContainer1.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
         this._splitContainer1.ResumeLayout(false);
         this._groupBoxServer.ResumeLayout(false);
         this._groupBoxServer.PerformLayout();
         this._contextMenuStripLog.ResumeLayout(false);
         this._menuStrip.ResumeLayout(false);
         this._menuStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.SplitContainer _splitContainer;
      private System.Windows.Forms.ListView _listViewImages;
      private System.Windows.Forms.Label _label1;
      private System.Windows.Forms.ContextMenuStrip _contextMenuStripLog;
      private System.Windows.Forms.ColumnHeader _columnHeader1;
      private System.Windows.Forms.ColumnHeader _columnHeader2;
      private System.Windows.Forms.ColumnHeader _columnHeader3;
      private System.Windows.Forms.ColumnHeader _columnHeader4;
      private System.Windows.Forms.ColumnHeader _columnHeader5;
      private System.Windows.Forms.ColumnHeader _columnHeader6;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
      private System.Windows.Forms.MenuStrip _menuStrip;
      private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem addDICOMToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem addDICOMDIRToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem storeToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.OpenFileDialog _openFileDialog;
      private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ContextMenuStrip _contextMenuStripImages;
      private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemRemoveSelected;
      private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemRemoveAll;
      private System.Windows.Forms.SplitContainer _splitContainer1;
      private System.Windows.Forms.Button _buttonStore;
      private System.Windows.Forms.Button _buttonOptions;
      private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
      private System.Windows.Forms.Button _buttonCancel;
      private System.Windows.Forms.ToolStripMenuItem showHelpToolStripMenuItem;
      private System.Windows.Forms.GroupBox _groupBoxServer;
      private System.Windows.Forms.Label _labelServerPort;
      private System.Windows.Forms.Label _labelServerIp;
      private System.Windows.Forms.Label _labelServerAeTitle;
      private System.Windows.Forms.TextBox _textBoxServerPort;
      private System.Windows.Forms.TextBox _textBoxServerIp;
      private System.Windows.Forms.ComboBox _comboBoxService;
      private System.Windows.Forms.Label _labelStatus;
      private System.Windows.Forms.RichTextBox _richTextBoxLog;
      private System.Windows.Forms.Label _label2;
      private System.Windows.Forms.Button _buttonStorageCommit;
      private System.Windows.Forms.ColumnHeader _columnHeader7;
   }
}

