namespace FormsDemo
{
   partial class RecognitionResult
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecognitionResult));
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
         this._splitContainer1 = new System.Windows.Forms.SplitContainer();
         this._splitContainer2 = new System.Windows.Forms.SplitContainer();
         this._txtPageConfidence = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this._txtFormConficence = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this._txtMasterForm = new System.Windows.Forms.TextBox();
         this._cmbSelectedPage = new System.Windows.Forms.ComboBox();
         this._cmbSelectedForm = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._splitContainer3 = new System.Windows.Forms.SplitContainer();
         this._tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this._fieldViewer = new Leadtools.Controls.ImageViewer();
         this._fieldViewerToobar = new System.Windows.Forms.ToolStrip();
         this._btnFieldPan = new System.Windows.Forms.ToolStripButton();
         this._btnFieldZoomRect = new System.Windows.Forms.ToolStripButton();
         this._btnFieldZoomNormal = new System.Windows.Forms.ToolStripButton();
         this._btnFieldZoomIn = new System.Windows.Forms.ToolStripButton();
         this._btnFieldZoomOut = new System.Windows.Forms.ToolStripButton();
         this._btnFieldFit = new System.Windows.Forms.ToolStripButton();
         this._btnFieldFitWidth = new System.Windows.Forms.ToolStripButton();
         this._fieldResults = new System.Windows.Forms.DataGridView();
         this._fieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._fieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._fieldResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._confidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._boundingRect = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this._filledFormViewer = new Leadtools.Annotations.WinForms.AutomationImageViewer();
         this._filledFormViewerToolbar = new System.Windows.Forms.ToolStrip();
         this._btnFormPan = new System.Windows.Forms.ToolStripButton();
         this._btnFormZoomRect = new System.Windows.Forms.ToolStripButton();
         this._btnFormZoomNormal = new System.Windows.Forms.ToolStripButton();
         this._btnFormZoomIn = new System.Windows.Forms.ToolStripButton();
         this._btnFormZoomOut = new System.Windows.Forms.ToolStripButton();
         this._btnFormFit = new System.Windows.Forms.ToolStripButton();
         this._btnFormFitWidth = new System.Windows.Forms.ToolStripButton();
         this._tablePanel2 = new System.Windows.Forms.TableLayoutPanel();
         this._toolBar = new System.Windows.Forms.ToolStrip();
         this._btnPanTool = new System.Windows.Forms.ToolStripButton();
         this._btnZoomDrawTool = new System.Windows.Forms.ToolStripButton();
         this._btnZoomNormal = new System.Windows.Forms.ToolStripButton();
         this._btnZoomIn = new System.Windows.Forms.ToolStripButton();
         this._btnZoomOut = new System.Windows.Forms.ToolStripButton();
         this._btnFit = new System.Windows.Forms.ToolStripButton();
         this._subSplitContainer = new System.Windows.Forms.SplitContainer();
         this._viewer = new Leadtools.Controls.ImageViewer();
         this._txtFieldInfo = new System.Windows.Forms.TextBox();
         this._splitContainer1.Panel1.SuspendLayout();
         this._splitContainer1.Panel2.SuspendLayout();
         this._splitContainer1.SuspendLayout();
         this._splitContainer2.Panel1.SuspendLayout();
         this._splitContainer2.Panel2.SuspendLayout();
         this._splitContainer2.SuspendLayout();
         this._splitContainer3.Panel1.SuspendLayout();
         this._splitContainer3.Panel2.SuspendLayout();
         this._splitContainer3.SuspendLayout();
         this._tableLayoutPanel1.SuspendLayout();
         this._fieldViewerToobar.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._fieldResults)).BeginInit();
         this._tableLayoutPanel2.SuspendLayout();
         this._filledFormViewerToolbar.SuspendLayout();
         this._tablePanel2.SuspendLayout();
         this._toolBar.SuspendLayout();
         this._subSplitContainer.Panel1.SuspendLayout();
         this._subSplitContainer.Panel2.SuspendLayout();
         this._subSplitContainer.SuspendLayout();
         this.SuspendLayout();
         // 
         // _splitContainer1
         // 
         this._splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer1.Location = new System.Drawing.Point(0, 0);
         this._splitContainer1.Name = "_splitContainer1";
         // 
         // _splitContainer1.Panel1
         // 
         this._splitContainer1.Panel1.Controls.Add(this._splitContainer2);
         // 
         // _splitContainer1.Panel2
         // 
         this._splitContainer1.Panel2.Controls.Add(this._tableLayoutPanel2);
         this._splitContainer1.Size = new System.Drawing.Size(641, 447);
         this._splitContainer1.SplitterDistance = 321;
         this._splitContainer1.TabIndex = 0;
         // 
         // _splitContainer2
         // 
         this._splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
         this._splitContainer2.IsSplitterFixed = true;
         this._splitContainer2.Location = new System.Drawing.Point(0, 0);
         this._splitContainer2.Name = "_splitContainer2";
         this._splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splitContainer2.Panel1
         // 
         this._splitContainer2.Panel1.Controls.Add(this._txtPageConfidence);
         this._splitContainer2.Panel1.Controls.Add(this.label5);
         this._splitContainer2.Panel1.Controls.Add(this._txtFormConficence);
         this._splitContainer2.Panel1.Controls.Add(this.label4);
         this._splitContainer2.Panel1.Controls.Add(this._txtMasterForm);
         this._splitContainer2.Panel1.Controls.Add(this._cmbSelectedPage);
         this._splitContainer2.Panel1.Controls.Add(this._cmbSelectedForm);
         this._splitContainer2.Panel1.Controls.Add(this.label3);
         this._splitContainer2.Panel1.Controls.Add(this.label2);
         this._splitContainer2.Panel1.Controls.Add(this.label1);
         // 
         // _splitContainer2.Panel2
         // 
         this._splitContainer2.Panel2.Controls.Add(this._splitContainer3);
         this._splitContainer2.Size = new System.Drawing.Size(321, 447);
         this._splitContainer2.SplitterDistance = 142;
         this._splitContainer2.TabIndex = 0;
         // 
         // _txtPageConfidence
         // 
         this._txtPageConfidence.Location = new System.Drawing.Point(120, 112);
         this._txtPageConfidence.Name = "_txtPageConfidence";
         this._txtPageConfidence.ReadOnly = true;
         this._txtPageConfidence.Size = new System.Drawing.Size(65, 20);
         this._txtPageConfidence.TabIndex = 9;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(12, 115);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(89, 13);
         this.label5.TabIndex = 8;
         this.label5.Text = "Page Confidence";
         // 
         // _txtFormConficence
         // 
         this._txtFormConficence.Location = new System.Drawing.Point(120, 60);
         this._txtFormConficence.Name = "_txtFormConficence";
         this._txtFormConficence.ReadOnly = true;
         this._txtFormConficence.Size = new System.Drawing.Size(65, 20);
         this._txtFormConficence.TabIndex = 7;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(12, 63);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(87, 13);
         this.label4.TabIndex = 6;
         this.label4.Text = "Form Confidence";
         // 
         // _txtMasterForm
         // 
         this._txtMasterForm.Location = new System.Drawing.Point(120, 34);
         this._txtMasterForm.Name = "_txtMasterForm";
         this._txtMasterForm.ReadOnly = true;
         this._txtMasterForm.Size = new System.Drawing.Size(194, 20);
         this._txtMasterForm.TabIndex = 5;
         // 
         // _cmbSelectedPage
         // 
         this._cmbSelectedPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbSelectedPage.FormattingEnabled = true;
         this._cmbSelectedPage.Location = new System.Drawing.Point(120, 86);
         this._cmbSelectedPage.Name = "_cmbSelectedPage";
         this._cmbSelectedPage.Size = new System.Drawing.Size(65, 21);
         this._cmbSelectedPage.TabIndex = 4;
         this._cmbSelectedPage.SelectedIndexChanged += new System.EventHandler(this._cmbSelectedPage_SelectedIndexChanged);
         // 
         // _cmbSelectedForm
         // 
         this._cmbSelectedForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbSelectedForm.FormattingEnabled = true;
         this._cmbSelectedForm.Location = new System.Drawing.Point(120, 7);
         this._cmbSelectedForm.Name = "_cmbSelectedForm";
         this._cmbSelectedForm.Size = new System.Drawing.Size(194, 21);
         this._cmbSelectedForm.TabIndex = 3;
         this._cmbSelectedForm.SelectedIndexChanged += new System.EventHandler(this._cmbSelectedForm_SelectedIndexChanged);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(12, 37);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(65, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "Master Form";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 89);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(77, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Selected Page";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 10);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(102, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Selected Filled Form";
         // 
         // _splitContainer3
         // 
         this._splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer3.Location = new System.Drawing.Point(0, 0);
         this._splitContainer3.Name = "_splitContainer3";
         this._splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splitContainer3.Panel1
         // 
         this._splitContainer3.Panel1.Controls.Add(this._tableLayoutPanel1);
         // 
         // _splitContainer3.Panel2
         // 
         this._splitContainer3.Panel2.Controls.Add(this._fieldResults);
         this._splitContainer3.Size = new System.Drawing.Size(321, 301);
         this._splitContainer3.SplitterDistance = 142;
         this._splitContainer3.TabIndex = 0;
         // 
         // _tableLayoutPanel1
         // 
         this._tableLayoutPanel1.ColumnCount = 1;
         this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this._tableLayoutPanel1.Controls.Add(this._fieldViewer, 0, 1);
         this._tableLayoutPanel1.Controls.Add(this._fieldViewerToobar, 0, 0);
         this._tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this._tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
         this._tableLayoutPanel1.Name = "_tableLayoutPanel1";
         this._tableLayoutPanel1.RowCount = 2;
         this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
         this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this._tableLayoutPanel1.Size = new System.Drawing.Size(317, 138);
         this._tableLayoutPanel1.TabIndex = 0;
         // 
         // _fieldViewer
         // 
         this._fieldViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._fieldViewer.Cursor = System.Windows.Forms.Cursors.Hand;
         this._fieldViewer.Dock = System.Windows.Forms.DockStyle.Fill;         
         this._fieldViewer.ScrollMode = Leadtools.Controls.ControlScrollMode.Auto;
         this._fieldViewer.HorizontalScroll.Enabled = true;
         this._fieldViewer.VerticalScroll.Enabled = true;   
         this._fieldViewer.Location = new System.Drawing.Point(3, 29);
         this._fieldViewer.Name = "_fieldViewer";
         this._fieldViewer.Size = new System.Drawing.Size(311, 106);
         this._fieldViewer.TabIndex = 2;
         this._fieldViewer.Text = "rasterImageViewer1";
         // 
         // _fieldViewerToobar
         // 
         this._fieldViewerToobar.BackColor = System.Drawing.SystemColors.MenuBar;
         this._fieldViewerToobar.Dock = System.Windows.Forms.DockStyle.Fill;
         this._fieldViewerToobar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this._fieldViewerToobar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnFieldPan,
            this._btnFieldZoomRect,
            this._btnFieldZoomNormal,
            this._btnFieldZoomIn,
            this._btnFieldZoomOut,
            this._btnFieldFit,
            this._btnFieldFitWidth});
         this._fieldViewerToobar.Location = new System.Drawing.Point(0, 0);
         this._fieldViewerToobar.Name = "_fieldViewerToobar";
         this._fieldViewerToobar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
         this._fieldViewerToobar.Size = new System.Drawing.Size(317, 26);
         this._fieldViewerToobar.TabIndex = 1;
         this._fieldViewerToobar.Text = "toolStrip1";
         // 
         // _btnFieldPan
         // 
         this._btnFieldPan.Checked = true;
         this._btnFieldPan.CheckOnClick = true;
         this._btnFieldPan.CheckState = System.Windows.Forms.CheckState.Checked;
         this._btnFieldPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFieldPan.Image = ((System.Drawing.Image)(resources.GetObject("_btnFieldPan.Image")));
         this._btnFieldPan.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFieldPan.Name = "_btnFieldPan";
         this._btnFieldPan.Size = new System.Drawing.Size(23, 23);
         this._btnFieldPan.Text = "Pan";
         this._btnFieldPan.Click += new System.EventHandler(this._btnFieldPan_Click);
         // 
         // _btnFieldZoomRect
         // 
         this._btnFieldZoomRect.CheckOnClick = true;
         this._btnFieldZoomRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFieldZoomRect.Image = ((System.Drawing.Image)(resources.GetObject("_btnFieldZoomRect.Image")));
         this._btnFieldZoomRect.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFieldZoomRect.Name = "_btnFieldZoomRect";
         this._btnFieldZoomRect.Size = new System.Drawing.Size(23, 23);
         this._btnFieldZoomRect.Text = "Zoom To Selection";
         this._btnFieldZoomRect.Click += new System.EventHandler(this._btnFieldZoomRect_Click);
         // 
         // _btnFieldZoomNormal
         // 
         this._btnFieldZoomNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFieldZoomNormal.Image = ((System.Drawing.Image)(resources.GetObject("_btnFieldZoomNormal.Image")));
         this._btnFieldZoomNormal.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFieldZoomNormal.Name = "_btnFieldZoomNormal";
         this._btnFieldZoomNormal.Size = new System.Drawing.Size(23, 23);
         this._btnFieldZoomNormal.Text = "Normal";
         this._btnFieldZoomNormal.Click += new System.EventHandler(this._btnFieldZoomNormal_Click);
         // 
         // _btnFieldZoomIn
         // 
         this._btnFieldZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFieldZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("_btnFieldZoomIn.Image")));
         this._btnFieldZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFieldZoomIn.Name = "_btnFieldZoomIn";
         this._btnFieldZoomIn.Size = new System.Drawing.Size(23, 23);
         this._btnFieldZoomIn.Text = "Zoom In";
         this._btnFieldZoomIn.Click += new System.EventHandler(this._btnFieldZoomIn_Click);
         // 
         // _btnFieldZoomOut
         // 
         this._btnFieldZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFieldZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("_btnFieldZoomOut.Image")));
         this._btnFieldZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFieldZoomOut.Name = "_btnFieldZoomOut";
         this._btnFieldZoomOut.Size = new System.Drawing.Size(23, 23);
         this._btnFieldZoomOut.Text = "Zoom Out";
         this._btnFieldZoomOut.Click += new System.EventHandler(this._btnFieldZoomOut_Click);
         // 
         // _btnFieldFit
         // 
         this._btnFieldFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFieldFit.Image = ((System.Drawing.Image)(resources.GetObject("_btnFieldFit.Image")));
         this._btnFieldFit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFieldFit.Name = "_btnFieldFit";
         this._btnFieldFit.Size = new System.Drawing.Size(23, 23);
         this._btnFieldFit.Text = "Fit To Window";
         this._btnFieldFit.Click += new System.EventHandler(this._btnFieldFit_Click);
         // 
         // _btnFieldFitWidth
         // 
         this._btnFieldFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFieldFitWidth.Image = ((System.Drawing.Image)(resources.GetObject("_btnFieldFitWidth.Image")));
         this._btnFieldFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFieldFitWidth.Name = "_btnFieldFitWidth";
         this._btnFieldFitWidth.Size = new System.Drawing.Size(23, 23);
         this._btnFieldFitWidth.Text = "Fit To Image Width";
         this._btnFieldFitWidth.Click += new System.EventHandler(this._btnFieldFitWidth_Click);
         // 
         // _fieldResults
         // 
         this._fieldResults.AllowUserToAddRows = false;
         this._fieldResults.AllowUserToDeleteRows = false;
         this._fieldResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
         this._fieldResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this._fieldResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._fieldName,
            this._fieldType,
            this._fieldResult,
            this._confidence,
            this._boundingRect});
         this._fieldResults.Dock = System.Windows.Forms.DockStyle.Fill;
         this._fieldResults.Location = new System.Drawing.Point(0, 0);
         this._fieldResults.MultiSelect = false;
         this._fieldResults.Name = "_fieldResults";
         this._fieldResults.ReadOnly = true;
         this._fieldResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this._fieldResults.Size = new System.Drawing.Size(317, 151);
         this._fieldResults.TabIndex = 0;
         this._fieldResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._fieldResults_MouseDoubleClick);
         this._fieldResults.SelectionChanged += new System.EventHandler(this._fieldResults_SelectionChanged);
         // 
         // _fieldName
         // 
         this._fieldName.HeaderText = "Field";
         this._fieldName.Name = "_fieldName";
         this._fieldName.ReadOnly = true;
         this._fieldName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         this._fieldName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
         this._fieldName.Width = 35;
         // 
         // _fieldType
         // 
         this._fieldType.HeaderText = "Type";
         this._fieldType.Name = "_fieldType";
         this._fieldType.ReadOnly = true;
         this._fieldType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
         this._fieldType.Width = 37;
         // 
         // _fieldResult
         // 
         dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this._fieldResult.DefaultCellStyle = dataGridViewCellStyle2;
         this._fieldResult.HeaderText = "Result";
         this._fieldResult.Name = "_fieldResult";
         this._fieldResult.ReadOnly = true;
         this._fieldResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
         this._fieldResult.Width = 43;
         // 
         // _confidence
         // 
         this._confidence.HeaderText = "Confidence";
         this._confidence.Name = "_confidence";
         this._confidence.ReadOnly = true;
         this._confidence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
         this._confidence.Width = 67;
         // 
         // _boundingRect
         // 
         this._boundingRect.HeaderText = "Bounding Rectangle";
         this._boundingRect.Name = "_boundingRect";
         this._boundingRect.ReadOnly = true;
         this._boundingRect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
         this._boundingRect.Width = 99;
         // 
         // _tableLayoutPanel2
         // 
         this._tableLayoutPanel2.ColumnCount = 1;
         this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this._tableLayoutPanel2.Controls.Add(this._filledFormViewer, 0, 1);
         this._tableLayoutPanel2.Controls.Add(this._filledFormViewerToolbar, 0, 0);
         this._tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this._tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
         this._tableLayoutPanel2.Name = "_tableLayoutPanel2";
         this._tableLayoutPanel2.RowCount = 2;
         this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
         this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this._tableLayoutPanel2.Size = new System.Drawing.Size(312, 443);
         this._tableLayoutPanel2.TabIndex = 0;
         // 
         // _filledFormViewer
         // 
         this._filledFormViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._filledFormViewer.Cursor = System.Windows.Forms.Cursors.Hand;
         this._filledFormViewer.Dock = System.Windows.Forms.DockStyle.Fill;         
         this._filledFormViewer.ScrollMode = Leadtools.Controls.ControlScrollMode.Auto;
         this._filledFormViewer.HorizontalScroll.Enabled = true;
         this._filledFormViewer.VerticalScroll.Enabled = true; 

         this._filledFormViewer.Location = new System.Drawing.Point(3, 29);
         this._filledFormViewer.Name = "_filledFormViewer";
         this._filledFormViewer.Size = new System.Drawing.Size(306, 411);
         this._filledFormViewer.TabIndex = 3;
         this._filledFormViewer.Text = "rasterImageViewer1";
         // 
         // _filledFormViewerToolbar
         // 
         this._filledFormViewerToolbar.BackColor = System.Drawing.SystemColors.MenuBar;
         this._filledFormViewerToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
         this._filledFormViewerToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this._filledFormViewerToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnFormPan,
            this._btnFormZoomRect,
            this._btnFormZoomNormal,
            this._btnFormZoomIn,
            this._btnFormZoomOut,
            this._btnFormFit,
            this._btnFormFitWidth});
         this._filledFormViewerToolbar.Location = new System.Drawing.Point(0, 0);
         this._filledFormViewerToolbar.Name = "_filledFormViewerToolbar";
         this._filledFormViewerToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
         this._filledFormViewerToolbar.Size = new System.Drawing.Size(312, 26);
         this._filledFormViewerToolbar.TabIndex = 2;
         this._filledFormViewerToolbar.Text = "toolStrip1";
         // 
         // _btnFormPan
         // 
         this._btnFormPan.Checked = true;
         this._btnFormPan.CheckOnClick = true;
         this._btnFormPan.CheckState = System.Windows.Forms.CheckState.Checked;
         this._btnFormPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFormPan.Image = ((System.Drawing.Image)(resources.GetObject("_btnFormPan.Image")));
         this._btnFormPan.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFormPan.Name = "_btnFormPan";
         this._btnFormPan.Size = new System.Drawing.Size(23, 23);
         this._btnFormPan.Text = "Pan";
         this._btnFormPan.Click += new System.EventHandler(this._btnFormPan_Click);
         // 
         // _btnFormZoomRect
         // 
         this._btnFormZoomRect.CheckOnClick = true;
         this._btnFormZoomRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFormZoomRect.Image = ((System.Drawing.Image)(resources.GetObject("_btnFormZoomRect.Image")));
         this._btnFormZoomRect.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFormZoomRect.Name = "_btnFormZoomRect";
         this._btnFormZoomRect.Size = new System.Drawing.Size(23, 23);
         this._btnFormZoomRect.Text = "Zoom To Selection";
         this._btnFormZoomRect.Click += new System.EventHandler(this._btnFormZoomRect_Click);
         // 
         // _btnFormZoomNormal
         // 
         this._btnFormZoomNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFormZoomNormal.Image = ((System.Drawing.Image)(resources.GetObject("_btnFormZoomNormal.Image")));
         this._btnFormZoomNormal.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFormZoomNormal.Name = "_btnFormZoomNormal";
         this._btnFormZoomNormal.Size = new System.Drawing.Size(23, 23);
         this._btnFormZoomNormal.Text = "Normal";
         this._btnFormZoomNormal.Click += new System.EventHandler(this._btnFormZoomNormal_Click);
         // 
         // _btnFormZoomIn
         // 
         this._btnFormZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFormZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("_btnFormZoomIn.Image")));
         this._btnFormZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFormZoomIn.Name = "_btnFormZoomIn";
         this._btnFormZoomIn.Size = new System.Drawing.Size(23, 23);
         this._btnFormZoomIn.Text = "Zoom In";
         this._btnFormZoomIn.Click += new System.EventHandler(this._btnFormZoomIn_Click);
         // 
         // _btnFormZoomOut
         // 
         this._btnFormZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFormZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("_btnFormZoomOut.Image")));
         this._btnFormZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFormZoomOut.Name = "_btnFormZoomOut";
         this._btnFormZoomOut.Size = new System.Drawing.Size(23, 23);
         this._btnFormZoomOut.Text = "Zoom Out";
         this._btnFormZoomOut.Click += new System.EventHandler(this._btnFormZoomOut_Click);
         // 
         // _btnFormFit
         // 
         this._btnFormFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFormFit.Image = ((System.Drawing.Image)(resources.GetObject("_btnFormFit.Image")));
         this._btnFormFit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFormFit.Name = "_btnFormFit";
         this._btnFormFit.Size = new System.Drawing.Size(23, 23);
         this._btnFormFit.Text = "Fit To Window";
         this._btnFormFit.Click += new System.EventHandler(this._btnFormFit_Click);
         // 
         // _btnFormFitWidth
         // 
         this._btnFormFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFormFitWidth.Image = ((System.Drawing.Image)(resources.GetObject("_btnFormFitWidth.Image")));
         this._btnFormFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFormFitWidth.Name = "_btnFormFitWidth";
         this._btnFormFitWidth.Size = new System.Drawing.Size(23, 23);
         this._btnFormFitWidth.Text = "Fit To Image Width";
         this._btnFormFitWidth.Click += new System.EventHandler(this._btnFormFitWidth_Click);
         // 
         // _tablePanel2
         // 
         this._tablePanel2.ColumnCount = 1;
         this._tablePanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this._tablePanel2.Controls.Add(this._toolBar, 0, 0);
         this._tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this._tablePanel2.Location = new System.Drawing.Point(0, 0);
         this._tablePanel2.Name = "_tablePanel2";
         this._tablePanel2.RowCount = 2;
         this._tablePanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this._tablePanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this._tablePanel2.Size = new System.Drawing.Size(200, 100);
         this._tablePanel2.TabIndex = 0;
         // 
         // _toolBar
         // 
         this._toolBar.BackColor = System.Drawing.SystemColors.MenuBar;
         this._toolBar.Dock = System.Windows.Forms.DockStyle.None;
         this._toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this._toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnPanTool,
            this._btnZoomDrawTool,
            this._btnZoomNormal,
            this._btnZoomIn,
            this._btnZoomOut,
            this._btnFit});
         this._toolBar.Location = new System.Drawing.Point(0, 0);
         this._toolBar.Name = "_toolBar";
         this._toolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
         this._toolBar.Size = new System.Drawing.Size(141, 20);
         this._toolBar.TabIndex = 0;
         this._toolBar.Text = "toolStrip1";
         // 
         // _btnPanTool
         // 
         this._btnPanTool.Checked = true;
         this._btnPanTool.CheckOnClick = true;
         this._btnPanTool.CheckState = System.Windows.Forms.CheckState.Checked;
         this._btnPanTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnPanTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnPanTool.Image")));
         this._btnPanTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnPanTool.Name = "_btnPanTool";
         this._btnPanTool.Size = new System.Drawing.Size(23, 17);
         this._btnPanTool.Text = "Pan";
         // 
         // _btnZoomDrawTool
         // 
         this._btnZoomDrawTool.CheckOnClick = true;
         this._btnZoomDrawTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomDrawTool.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomDrawTool.Image")));
         this._btnZoomDrawTool.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomDrawTool.Name = "_btnZoomDrawTool";
         this._btnZoomDrawTool.Size = new System.Drawing.Size(23, 17);
         this._btnZoomDrawTool.Text = "Zoom To Selection";
         // 
         // _btnZoomNormal
         // 
         this._btnZoomNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomNormal.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomNormal.Image")));
         this._btnZoomNormal.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomNormal.Name = "_btnZoomNormal";
         this._btnZoomNormal.Size = new System.Drawing.Size(23, 17);
         this._btnZoomNormal.Text = "Normal";
         // 
         // _btnZoomIn
         // 
         this._btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomIn.Image")));
         this._btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomIn.Name = "_btnZoomIn";
         this._btnZoomIn.Size = new System.Drawing.Size(23, 17);
         this._btnZoomIn.Text = "Zoom In";
         // 
         // _btnZoomOut
         // 
         this._btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomOut.Image")));
         this._btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnZoomOut.Name = "_btnZoomOut";
         this._btnZoomOut.Size = new System.Drawing.Size(23, 17);
         this._btnZoomOut.Text = "Zoom Out";
         // 
         // _btnFit
         // 
         this._btnFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnFit.Image = ((System.Drawing.Image)(resources.GetObject("_btnFit.Image")));
         this._btnFit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnFit.Name = "_btnFit";
         this._btnFit.Size = new System.Drawing.Size(23, 17);
         this._btnFit.Text = "Fit To Window";
         // 
         // _subSplitContainer
         // 
         this._subSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._subSplitContainer.Location = new System.Drawing.Point(3, 28);
         this._subSplitContainer.Name = "_subSplitContainer";
         this._subSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _subSplitContainer.Panel1
         // 
         this._subSplitContainer.Panel1.Controls.Add(this._viewer);
         // 
         // _subSplitContainer.Panel2
         // 
         this._subSplitContainer.Panel2.Controls.Add(this._txtFieldInfo);
         this._subSplitContainer.Size = new System.Drawing.Size(315, 129);
         this._subSplitContainer.SplitterDistance = 56;
         this._subSplitContainer.TabIndex = 1;
         // 
         // _viewer
         // 
         this._viewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this._viewer.Cursor = System.Windows.Forms.Cursors.Hand;
         this._viewer.Location = new System.Drawing.Point(0, 0);
         this._viewer.Name = "_viewer";
         this._viewer.Size = new System.Drawing.Size(427, 124);
         this._viewer.TabIndex = 0;
         this._viewer.Text = "rasterImageViewer1";
         // 
         // _txtFieldInfo
         // 
         this._txtFieldInfo.BackColor = System.Drawing.Color.White;
         this._txtFieldInfo.Dock = System.Windows.Forms.DockStyle.Fill;
         this._txtFieldInfo.Location = new System.Drawing.Point(0, 0);
         this._txtFieldInfo.Multiline = true;
         this._txtFieldInfo.Name = "_txtFieldInfo";
         this._txtFieldInfo.ReadOnly = true;
         this._txtFieldInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this._txtFieldInfo.Size = new System.Drawing.Size(315, 69);
         this._txtFieldInfo.TabIndex = 2;
         this._txtFieldInfo.WordWrap = false;
         // 
         // RecognitionResult
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(641, 447);
         this.Controls.Add(this._splitContainer1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "RecognitionResult";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Results";
         this.Load += new System.EventHandler(this.RecognitionResult_Load);
         this._splitContainer1.Panel1.ResumeLayout(false);
         this._splitContainer1.Panel2.ResumeLayout(false);
         this._splitContainer1.ResumeLayout(false);
         this._splitContainer2.Panel1.ResumeLayout(false);
         this._splitContainer2.Panel1.PerformLayout();
         this._splitContainer2.Panel2.ResumeLayout(false);
         this._splitContainer2.ResumeLayout(false);
         this._splitContainer3.Panel1.ResumeLayout(false);
         this._splitContainer3.Panel2.ResumeLayout(false);
         this._splitContainer3.ResumeLayout(false);
         this._tableLayoutPanel1.ResumeLayout(false);
         this._tableLayoutPanel1.PerformLayout();
         this._fieldViewerToobar.ResumeLayout(false);
         this._fieldViewerToobar.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._fieldResults)).EndInit();
         this._tableLayoutPanel2.ResumeLayout(false);
         this._tableLayoutPanel2.PerformLayout();
         this._filledFormViewerToolbar.ResumeLayout(false);
         this._filledFormViewerToolbar.PerformLayout();
         this._tablePanel2.ResumeLayout(false);
         this._tablePanel2.PerformLayout();
         this._toolBar.ResumeLayout(false);
         this._toolBar.PerformLayout();
         this._subSplitContainer.Panel1.ResumeLayout(false);
         this._subSplitContainer.Panel2.ResumeLayout(false);
         this._subSplitContainer.Panel2.PerformLayout();
         this._subSplitContainer.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer _splitContainer1;
      private System.Windows.Forms.SplitContainer _splitContainer2;
      private System.Windows.Forms.SplitContainer _splitContainer3;
      private System.Windows.Forms.TableLayoutPanel _tablePanel2;
      private System.Windows.Forms.ToolStrip _toolBar;
      private System.Windows.Forms.ToolStripButton _btnPanTool;
      private System.Windows.Forms.ToolStripButton _btnZoomDrawTool;
      private System.Windows.Forms.ToolStripButton _btnZoomNormal;
      private System.Windows.Forms.ToolStripButton _btnZoomIn;
      private System.Windows.Forms.ToolStripButton _btnZoomOut;
      private System.Windows.Forms.ToolStripButton _btnFit;
      private System.Windows.Forms.SplitContainer _subSplitContainer;
      private Leadtools.Controls.ImageViewer _viewer;
      private System.Windows.Forms.TextBox _txtFieldInfo;
      private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel1;
      private System.Windows.Forms.ToolStrip _fieldViewerToobar;
      private System.Windows.Forms.ToolStripButton _btnFieldPan;
      private System.Windows.Forms.ToolStripButton _btnFieldZoomRect;
      private System.Windows.Forms.ToolStripButton _btnFieldZoomNormal;
      private System.Windows.Forms.ToolStripButton _btnFieldZoomIn;
      private System.Windows.Forms.ToolStripButton _btnFieldZoomOut;
      private System.Windows.Forms.ToolStripButton _btnFieldFit;
      private Leadtools.Controls.ImageViewer _fieldViewer;
      private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel2;
      private Leadtools.Annotations.WinForms.AutomationImageViewer _filledFormViewer;
      private System.Windows.Forms.ToolStrip _filledFormViewerToolbar;
      private System.Windows.Forms.ToolStripButton _btnFormPan;
      private System.Windows.Forms.ToolStripButton _btnFormZoomRect;
      private System.Windows.Forms.ToolStripButton _btnFormZoomNormal;
      private System.Windows.Forms.ToolStripButton _btnFormZoomIn;
      private System.Windows.Forms.ToolStripButton _btnFormZoomOut;
      private System.Windows.Forms.ToolStripButton _btnFormFit;
      private System.Windows.Forms.DataGridView _fieldResults;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox _cmbSelectedPage;
      private System.Windows.Forms.ComboBox _cmbSelectedForm;
       private System.Windows.Forms.TextBox _txtMasterForm;
      private System.Windows.Forms.ToolStripButton _btnFormFitWidth;
       private System.Windows.Forms.ToolStripButton _btnFieldFitWidth;
      private System.Windows.Forms.TextBox _txtFormConficence;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox _txtPageConfidence;
      private System.Windows.Forms.Label label5;
       private System.Windows.Forms.DataGridViewTextBoxColumn _fieldName;
       private System.Windows.Forms.DataGridViewTextBoxColumn _fieldType;
       private System.Windows.Forms.DataGridViewTextBoxColumn _fieldResult;
       private System.Windows.Forms.DataGridViewTextBoxColumn _confidence;
       private System.Windows.Forms.DataGridViewTextBoxColumn _boundingRect;

   }
}