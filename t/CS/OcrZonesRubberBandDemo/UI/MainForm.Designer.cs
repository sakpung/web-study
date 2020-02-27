namespace OcrZonesRubberBandDemo
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
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this._toolbar = new System.Windows.Forms.ToolStrip();
         this._tsMainZoomComboBox = new System.Windows.Forms.ToolStripComboBox();
         this._viewer = new Leadtools.Controls.ImageViewer();
         this._recognitionResults = new System.Windows.Forms.RichTextBox();
         this._mmMain = new System.Windows.Forms.MainMenu(this.components);
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileSetLoadRes = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this._splitContainer.Panel1.SuspendLayout();
         this._splitContainer.Panel2.SuspendLayout();
         this._splitContainer.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this._toolbar.SuspendLayout();
         this.SuspendLayout();
         // 
         // _splitContainer
         // 
         this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer.Location = new System.Drawing.Point(0, 0);
         this._splitContainer.Name = "_splitContainer";
         this._splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splitContainer.Panel1
         // 
         this._splitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
         // 
         // _splitContainer.Panel2
         // 
         this._splitContainer.Panel2.Controls.Add(this._recognitionResults);
         this._splitContainer.Size = new System.Drawing.Size(715, 250);
         this._splitContainer.SplitterDistance = 176;
         this._splitContainer.TabIndex = 0;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 1;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Controls.Add(this._toolbar, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this._viewer, 0, 1);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(715, 176);
         this.tableLayoutPanel1.TabIndex = 4;
         // 
         // _toolbar
         // 
         this._toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsMainZoomComboBox});
         this._toolbar.Location = new System.Drawing.Point(0, 0);
         this._toolbar.Name = "_toolbar";
         this._toolbar.Size = new System.Drawing.Size(715, 25);
         this._toolbar.TabIndex = 3;
         this._toolbar.Text = "toolStrip1";
         // 
         // _tsMainZoomComboBox
         // 
         this._tsMainZoomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._tsMainZoomComboBox.Name = "_tsMainZoomComboBox";
         this._tsMainZoomComboBox.Size = new System.Drawing.Size(121, 25);
         this._tsMainZoomComboBox.SelectedIndexChanged += new System.EventHandler(this._tsMainZoomComboBox_SelectedIndexChanged);
         // 
         // _viewer
         // 
         this._viewer.AutoDisposeImages = true;
         this._viewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._viewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._viewer.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Near;
         this._viewer.Image = null;
         this._viewer.Location = new System.Drawing.Point(3, 28);
         this._viewer.Name = "_viewer";
         this._viewer.Size = new System.Drawing.Size(709, 145);
         this._viewer.TabIndex = 0;
         this._viewer.Text = "imageViewer";
         this._viewer.UseDpi = false;
         this._viewer.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Near;
         this._viewer.MouseUp += new System.Windows.Forms.MouseEventHandler(this._viewer_MouseUp);
         this._viewer.PostRenderItem += new System.EventHandler<Leadtools.Controls.ImageViewerRenderEventArgs>(this._viewer_Paint);
         // 
         // _recognitionResults
         // 
         this._recognitionResults.BackColor = System.Drawing.Color.White;
         this._recognitionResults.Dock = System.Windows.Forms.DockStyle.Fill;
         this._recognitionResults.Location = new System.Drawing.Point(0, 0);
         this._recognitionResults.Name = "_recognitionResults";
         this._recognitionResults.ReadOnly = true;
         this._recognitionResults.Size = new System.Drawing.Size(715, 70);
         this._recognitionResults.TabIndex = 0;
         this._recognitionResults.Text = "";
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpen,
            this._miFileSetLoadRes,
            this._miFileSep1,
            this._miFileExit});
         this._miFile.Text = "&File";
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Index = 0;
         this._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miFileOpen.Text = "&Open";
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileSetLoadRes
         // 
         this._miFileSetLoadRes.Index = 1;
         this._miFileSetLoadRes.Text = "Set Load &Resolution…";
         this._miFileSetLoadRes.Click += new System.EventHandler(this._miFileSetLoadRes_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 2;
         this._miFileSep1.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 3;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 1;
         this._miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miHelpAbout});
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Index = 0;
         this._miHelpAbout.Text = "&About";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(715, 250);
         this.Controls.Add(this._splitContainer);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "LEADTOOLS OCR Zones Rubberband Demo";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this._splitContainer.Panel1.ResumeLayout(false);
         this._splitContainer.Panel2.ResumeLayout(false);
         this._splitContainer.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this._toolbar.ResumeLayout(false);
         this._toolbar.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer _splitContainer;
      private Leadtools.Controls.ImageViewer _viewer;
      private System.Windows.Forms.RichTextBox _recognitionResults;
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileSetLoadRes;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.ToolStrip _toolbar;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.ToolStripComboBox _tsMainZoomComboBox;
      private System.Windows.Forms.MenuItem _miFileSep1;
   }
}

