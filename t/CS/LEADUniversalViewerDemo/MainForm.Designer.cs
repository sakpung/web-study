using Leadtools.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LEADUniversalViewer
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
            this._controlsPanel = new System.Windows.Forms.Panel();
            this._tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._btnStop = new System.Windows.Forms.Button();
            this._btnPause = new System.Windows.Forms.Button();
            this._numericUpDown = new System.Windows.Forms.NumericUpDown();
            this._btnPlay = new System.Windows.Forms.Button();
            this._btnNext = new System.Windows.Forms.Button();
            this._btnFwd = new System.Windows.Forms.Button();
            this._btnRew = new System.Windows.Forms.Button();
            this._btnPrev = new System.Windows.Forms.Button();
            this._btnFullScreen = new System.Windows.Forms.Button();
            this._tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._lbltrkPosition = new System.Windows.Forms.Label();
            this._trkPosition = new System.Windows.Forms.TrackBar();
            this._imageViewer1 = new Leadtools.Controls.ImageViewer();
            this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._filePlayMoreFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._fileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._optionsLoadAllPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._optionsSupportLoadingTEXTFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._optionsPlaybackMediaFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._optionsChangeloadingOrRasterizingResolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._helpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._filesNamesListBox = new System.Windows.Forms.ListBox();
            this._tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._playerPanel = new System.Windows.Forms.Panel();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._controlsPanel.SuspendLayout();
            this._tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown)).BeginInit();
            this._tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trkPosition)).BeginInit();
            this._menuStrip1.SuspendLayout();
            this._tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            //
            // ControlsPanel
            //
            this._controlsPanel.AutoScroll = true;
            this._controlsPanel.AutoSize = true;
            this._controlsPanel.BackColor = System.Drawing.Color.White;
            this._controlsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._controlsPanel.Controls.Add(this._tableLayoutPanel3);
            this._controlsPanel.Controls.Add(this._tableLayoutPanel2);
            this._controlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._controlsPanel.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._controlsPanel.Location = new System.Drawing.Point(178, 850);
            this._controlsPanel.Name = "ControlsPanel";
            this._controlsPanel.Size = new System.Drawing.Size(1176, 68);
            this._controlsPanel.TabIndex = 1;
            //
            // tableLayoutPanel3
            //
            this._tableLayoutPanel3.ColumnCount = 9;
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel3.Controls.Add(this._btnStop, 0, 0);
            this._tableLayoutPanel3.Controls.Add(this._btnPause, 1, 0);
            this._tableLayoutPanel3.Controls.Add(this._numericUpDown, 6, 0);
            this._tableLayoutPanel3.Controls.Add(this._btnPlay, 2, 0);
            this._tableLayoutPanel3.Controls.Add(this._btnNext, 8, 0);
            this._tableLayoutPanel3.Controls.Add(this._btnFwd, 7, 0);
            this._tableLayoutPanel3.Controls.Add(this._btnRew, 5, 0);
            this._tableLayoutPanel3.Controls.Add(this._btnPrev, 4, 0);
            this._tableLayoutPanel3.Controls.Add(this._btnFullScreen, 3, 0);
            this._tableLayoutPanel3.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tableLayoutPanel3.Location = new System.Drawing.Point(465, 26);
            this._tableLayoutPanel3.Name = "tableLayoutPanel3";
            this._tableLayoutPanel3.RowCount = 1;
            this._tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel3.Size = new System.Drawing.Size(434, 36);
            this._tableLayoutPanel3.TabIndex = 11;
            //
            // btnStop
            //
            this._btnStop.BackgroundImage = global::LEADUniversalViewer.Properties.Resources.Stop;
            this._btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnStop.Location = new System.Drawing.Point(3, 3);
            this._btnStop.Name = "btnStop";
            this._btnStop.Size = new System.Drawing.Size(42, 30);
            this._btnStop.TabIndex = 4;
            this._toolTip.SetToolTip(this._btnStop, "Stop");
            this._btnStop.UseVisualStyleBackColor = true;
            this._btnStop.Click += new System.EventHandler(this.btnStop_Click);
            //
            // btnPause
            //
            this._btnPause.BackgroundImage = global::LEADUniversalViewer.Properties.Resources.Pause;
            this._btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btnPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnPause.Location = new System.Drawing.Point(51, 3);
            this._btnPause.Name = "btnPause";
            this._btnPause.Size = new System.Drawing.Size(42, 30);
            this._btnPause.TabIndex = 3;
            this._toolTip.SetToolTip(this._btnPause, "Pause");
            this._btnPause.UseVisualStyleBackColor = true;
            this._btnPause.Click += new System.EventHandler(this.btnPause_Click);
            //
            // numericUpDown1
            //
            this._numericUpDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._numericUpDown.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._numericUpDown.ForeColor = System.Drawing.Color.RoyalBlue;
            this._numericUpDown.Location = new System.Drawing.Point(290, 8);
            this._numericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this._numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numericUpDown.Name = "numericUpDown1";
            this._numericUpDown.Size = new System.Drawing.Size(44, 26);
            this._numericUpDown.TabIndex = 7;
            this._toolTip.SetToolTip(this._numericUpDown, "Current page number");
            this._numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numericUpDown.Visible = false;
            this._numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            //
            // btnPlay
            //
            this._btnPlay.BackgroundImage = global::LEADUniversalViewer.Properties.Resources.Play;
            this._btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btnPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnPlay.Location = new System.Drawing.Point(99, 3);
            this._btnPlay.Name = "btnPlay";
            this._btnPlay.Size = new System.Drawing.Size(42, 30);
            this._btnPlay.TabIndex = 2;
            this._toolTip.SetToolTip(this._btnPlay, "Play");
            this._btnPlay.UseVisualStyleBackColor = true;
            this._btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            //
            // btnNext
            //
            this._btnNext.BackgroundImage = global::LEADUniversalViewer.Properties.Resources.Next;
            this._btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnNext.Location = new System.Drawing.Point(387, 3);
            this._btnNext.Name = "btnNext";
            this._btnNext.Size = new System.Drawing.Size(44, 30);
            this._btnNext.TabIndex = 6;
            this._toolTip.SetToolTip(this._btnNext, "Next file in the list");
            this._btnNext.UseVisualStyleBackColor = true;
            this._btnNext.Click += new System.EventHandler(this.btnNext_Click);
            //
            // btnFwd
            //
            this._btnFwd.BackColor = System.Drawing.Color.White;
            this._btnFwd.BackgroundImage = global::LEADUniversalViewer.Properties.Resources.Fwd;
            this._btnFwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btnFwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnFwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnFwd.ForeColor = System.Drawing.Color.White;
            this._btnFwd.ImageIndex = 8;
            this._btnFwd.Location = new System.Drawing.Point(339, 3);
            this._btnFwd.Name = "btnFwd";
            this._btnFwd.Size = new System.Drawing.Size(42, 30);
            this._btnFwd.TabIndex = 5;
            this._toolTip.SetToolTip(this._btnFwd, "Next");
            this._btnFwd.UseVisualStyleBackColor = false;
            this._btnFwd.Click += new System.EventHandler(this.btnFwd_Click);
            this._btnFwd.MouseHover += new System.EventHandler(this.btnFwd_MouseHover);
            //
            // btnRew
            //
            this._btnRew.BackgroundImage = global::LEADUniversalViewer.Properties.Resources.Rew;
            this._btnRew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btnRew.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnRew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRew.Location = new System.Drawing.Point(243, 3);
            this._btnRew.Name = "btnRew";
            this._btnRew.Size = new System.Drawing.Size(42, 30);
            this._btnRew.TabIndex = 1;
            this._toolTip.SetToolTip(this._btnRew, "Prev");
            this._btnRew.UseVisualStyleBackColor = true;
            this._btnRew.Click += new System.EventHandler(this.btnRew_Click);
            this._btnRew.MouseHover += new System.EventHandler(this.btnRew_MouseHover);
            //
            // btnPrev
            //
            this._btnPrev.BackgroundImage = global::LEADUniversalViewer.Properties.Resources.Prev;
            this._btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btnPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnPrev.Location = new System.Drawing.Point(195, 3);
            this._btnPrev.Name = "btnPrev";
            this._btnPrev.Size = new System.Drawing.Size(42, 30);
            this._btnPrev.TabIndex = 0;
            this._toolTip.SetToolTip(this._btnPrev, "Prev file in the list");
            this._btnPrev.UseVisualStyleBackColor = true;
            this._btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            //
            // btnFullScreen
            //
            this._btnFullScreen.BackgroundImage = global::LEADUniversalViewer.Properties.Resources.Fullscreen64;
            this._btnFullScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btnFullScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnFullScreen.Location = new System.Drawing.Point(147, 3);
            this._btnFullScreen.Name = "btnFullScreen";
            this._btnFullScreen.Size = new System.Drawing.Size(42, 30);
            this._btnFullScreen.TabIndex = 8;
            this._toolTip.SetToolTip(this._btnFullScreen, "Full Screen");
            this._btnFullScreen.UseVisualStyleBackColor = true;
            this._btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            //
            // tableLayoutPanel2
            //
            this._tableLayoutPanel2.ColumnCount = 2;
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._tableLayoutPanel2.Controls.Add(this._lbltrkPosition, 1, 0);
            this._tableLayoutPanel2.Controls.Add(this._trkPosition, 0, 0);
            this._tableLayoutPanel2.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tableLayoutPanel2.Location = new System.Drawing.Point(464, 0);
            this._tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this._tableLayoutPanel2.Name = "tableLayoutPanel2";
            this._tableLayoutPanel2.RowCount = 1;
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel2.Size = new System.Drawing.Size(701, 22);
            this._tableLayoutPanel2.TabIndex = 10;
            //
            // lbltrkPosition
            //
            this._lbltrkPosition.AutoSize = true;
            this._lbltrkPosition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lbltrkPosition.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbltrkPosition.ForeColor = System.Drawing.Color.RoyalBlue;
            this._lbltrkPosition.Location = new System.Drawing.Point(422, 5);
            this._lbltrkPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lbltrkPosition.Name = "lbltrkPosition";
            this._lbltrkPosition.Size = new System.Drawing.Size(277, 17);
            this._lbltrkPosition.TabIndex = 8;
            this._lbltrkPosition.Text = "----";
            //
            // trkPosition
            //
            this._trkPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._trkPosition.AutoSize = false;
            this._trkPosition.BackColor = System.Drawing.SystemColors.Control;
            this._trkPosition.LargeChange = 500;
            this._trkPosition.Location = new System.Drawing.Point(2, 2);
            this._trkPosition.Margin = new System.Windows.Forms.Padding(2);
            this._trkPosition.Maximum = 10000;
            this._trkPosition.Name = "trkPosition";
            this._trkPosition.Size = new System.Drawing.Size(416, 15);
            this._trkPosition.TabIndex = 5;
            this._trkPosition.TickFrequency = 400;
            this._trkPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this._trkPosition.Scroll += new System.EventHandler(this.trkPosition_Scroll);
            //
            // imageViewer1
            //
            this._imageViewer1.BackColor = System.Drawing.Color.White;
            this._imageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._imageViewer1.IsSyncSource = true;
            this._imageViewer1.IsSyncTarget = true;
            this._imageViewer1.ItemSpacing = new Leadtools.LeadSize(0, 0);
            this._imageViewer1.Location = new System.Drawing.Point(0, 0);
            this._imageViewer1.Name = "imageViewer1";
            this._imageViewer1.Size = new System.Drawing.Size(1046, 713);
            this._imageViewer1.TabIndex = 0;
            this._imageViewer1.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
            this._imageViewer1.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Center;
            this._imageViewer1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageViewer1_MouseDoubleClick);
            //
            // _fileToolStripMenuItem
            //
            this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._filePlayMoreFilesToolStripMenuItem,
            this._toolStripSeparator2,
            this._fileExitToolStripMenuItem});
            this._fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this._fileToolStripMenuItem.Text = "&File";
            //
            // _filePlayMoreFilesToolStripMenuItem
            //
            this._filePlayMoreFilesToolStripMenuItem.Name = "_filePlayMoreFilesToolStripMenuItem";
            this._filePlayMoreFilesToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this._filePlayMoreFilesToolStripMenuItem.Text = "&Browse Images and Media Files...";
            this._filePlayMoreFilesToolStripMenuItem.Click += new System.EventHandler(this.playMoreFilesToolStripMenuItem_Click);
            //
            // toolStripSeparator2
            //
            this._toolStripSeparator2.Name = "toolStripSeparator2";
            this._toolStripSeparator2.Size = new System.Drawing.Size(244, 6);
            //
            // _fileExitToolStripMenuItem
            //
            this._fileExitToolStripMenuItem.Name = "_fileExitToolStripMenuItem";
            this._fileExitToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this._fileExitToolStripMenuItem.Text = "E&xit";
            this._fileExitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            //
            // menuStrip1
            //
            this._menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this._menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._recentToolStripMenuItem,
            this._optionsToolStripMenuItem,
            this._helpToolStripMenuItem});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "menuStrip1";
            this._menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this._menuStrip1.Size = new System.Drawing.Size(1357, 24);
            this._menuStrip1.TabIndex = 0;
            this._menuStrip1.Text = "menuStrip1";
            //
            // _recentToolStripMenuItem
            //
            this._recentToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this._recentToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this._recentToolStripMenuItem.Name = "_recentToolStripMenuItem";
            this._recentToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this._recentToolStripMenuItem.Text = "Recent Places";
            //
            // _optionsToolStripMenuItem
            //
            this._optionsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this._optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._optionsLoadAllPagesToolStripMenuItem,
            this._optionsSupportLoadingTEXTFilesToolStripMenuItem,
            this._toolStripSeparator1,
            this._optionsPlaybackMediaFilesToolStripMenuItem,
            this._toolStripSeparator3,
            this._optionsChangeloadingOrRasterizingResolutionToolStripMenuItem});
            this._optionsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this._optionsToolStripMenuItem.Name = "_optionsToolStripMenuItem";
            this._optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this._optionsToolStripMenuItem.Text = "&Options";
            //
            // _optionsLoadAllPagesToolStripMenuItem
            //
            this._optionsLoadAllPagesToolStripMenuItem.Name = "_optionsLoadAllPagesToolStripMenuItem";
            this._optionsLoadAllPagesToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this._optionsLoadAllPagesToolStripMenuItem.Text = "Support Loading &All Pages";
            this._optionsLoadAllPagesToolStripMenuItem.Click += new System.EventHandler(this.loadAllPagesToolStripMenuItem_Click);
            //
            // _optionsSupportLoadingTEXTFilesToolStripMenuItem
            //
            this._optionsSupportLoadingTEXTFilesToolStripMenuItem.Name = "_optionsSupportLoadingTEXTFilesToolStripMenuItem";
            this._optionsSupportLoadingTEXTFilesToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this._optionsSupportLoadingTEXTFilesToolStripMenuItem.Text = "Support Loading &TEXT files";
            this._optionsSupportLoadingTEXTFilesToolStripMenuItem.Click += new System.EventHandler(this.supportLoadingTEXTFilesToolStripMenuItem_Click);
            //
            // toolStripSeparator1
            //
            this._toolStripSeparator1.Name = "toolStripSeparator1";
            this._toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
            //
            // _optionsPlaybackMediaFilesToolStripMenuItem
            //
            this._optionsPlaybackMediaFilesToolStripMenuItem.Checked = true;
            this._optionsPlaybackMediaFilesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._optionsPlaybackMediaFilesToolStripMenuItem.Name = "_optionsPlaybackMediaFilesToolStripMenuItem";
            this._optionsPlaybackMediaFilesToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this._optionsPlaybackMediaFilesToolStripMenuItem.Text = "Auto &Play Media Files";
            this._optionsPlaybackMediaFilesToolStripMenuItem.Click += new System.EventHandler(this.playbackMediaFilesToolStripMenuItem_Click);
            //
            // toolStripSeparator3
            //
            this._toolStripSeparator3.Name = "toolStripSeparator3";
            this._toolStripSeparator3.Size = new System.Drawing.Size(226, 6);
            //
            // _optionsChangeloadingOrRasterizingResolutionToolStripMenuItem
            //
            this._optionsChangeloadingOrRasterizingResolutionToolStripMenuItem.Name = "_optionsChangeloadingOrRasterizingResolutionToolStripMenuItem";
            this._optionsChangeloadingOrRasterizingResolutionToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this._optionsChangeloadingOrRasterizingResolutionToolStripMenuItem.Text = "Change &Loading Resolution...";
            this._optionsChangeloadingOrRasterizingResolutionToolStripMenuItem.Click += new System.EventHandler(this.changeloadingOrRasterizingResolutionToolStripMenuItem_Click);
            //
            // _helpToolStripMenuItem
            //
            this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._helpAboutToolStripMenuItem});
            this._helpToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
            this._helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this._helpToolStripMenuItem.Text = "Help";
            //
            // _helpAboutToolStripMenuItem
            //
            this._helpAboutToolStripMenuItem.Name = "_helpAboutToolStripMenuItem";
            this._helpAboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this._helpAboutToolStripMenuItem.Text = "&About...";
            this._helpAboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            //
            // listBox1
            //
            this._filesNamesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._filesNamesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._filesNamesListBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._filesNamesListBox.FormattingEnabled = true;
            this._filesNamesListBox.HorizontalScrollbar = true;
            this._filesNamesListBox.ItemHeight = 15;
            this._filesNamesListBox.Location = new System.Drawing.Point(2, 2);
            this._filesNamesListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this._filesNamesListBox.Name = "listBox1";
            this._filesNamesListBox.ScrollAlwaysVisible = true;
            this._filesNamesListBox.Size = new System.Drawing.Size(171, 845);
            this._filesNamesListBox.TabIndex = 0;
            this._filesNamesListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedValueChanged);
            this._filesNamesListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            //
            // tableLayoutPanel1
            //
            this._tableLayoutPanel1.ColumnCount = 2;
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel1.Controls.Add(this._filesNamesListBox, 0, 0);
            this._tableLayoutPanel1.Controls.Add(this._controlsPanel, 1, 1);
            this._tableLayoutPanel1.Controls.Add(this._playerPanel, 1, 0);
            this._tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this._tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this._tableLayoutPanel1.Name = "tableLayoutPanel1";
            this._tableLayoutPanel1.RowCount = 2;
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92F));
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this._tableLayoutPanel1.Size = new System.Drawing.Size(1357, 921);
            this._tableLayoutPanel1.TabIndex = 4;
            //
            // PlayerPanel
            //
            this._playerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._playerPanel.BackColor = System.Drawing.Color.Black;
            this._playerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._playerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._playerPanel.Location = new System.Drawing.Point(178, 3);
            this._playerPanel.Name = "PlayerPanel";
            this._playerPanel.Size = new System.Drawing.Size(1176, 841);
            this._playerPanel.TabIndex = 2;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1357, 945);
            this.Controls.Add(this._tableLayoutPanel1);
            this.Controls.Add(this._menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip1;
            this.Name = "MainForm";
            this.Text = "LEADTOOLS C# Universal Viewer Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this._controlsPanel.ResumeLayout(false);
            this._tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDown)).EndInit();
            this._tableLayoutPanel2.ResumeLayout(false);
            this._tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trkPosition)).EndInit();
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this._tableLayoutPanel1.ResumeLayout(false);
            this._tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel _controlsPanel;
      private System.Windows.Forms.Button _btnStop;
      private System.Windows.Forms.Button _btnPause;
      private System.Windows.Forms.Button _btnPlay;
      private System.Windows.Forms.Button _btnRew;
      private System.Windows.Forms.Button _btnPrev;
      private System.Windows.Forms.Button _btnNext;
      private System.Windows.Forms.Button _btnFwd;
      private System.Windows.Forms.Button _btnFullScreen;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _filePlayMoreFilesToolStripMenuItem;
      private System.Windows.Forms.MenuStrip _menuStrip1;
      private Leadtools.Controls.ImageViewer _imageViewer1;
      private NumericUpDown _numericUpDown;
      private ListBox _filesNamesListBox;
      private TableLayoutPanel _tableLayoutPanel1;
      private Panel _playerPanel;
      private ToolTip _toolTip;
      private ToolStripMenuItem _optionsToolStripMenuItem;
      private ToolStripMenuItem _optionsLoadAllPagesToolStripMenuItem;
      private ToolStripMenuItem _optionsPlaybackMediaFilesToolStripMenuItem;
      private TrackBar _trkPosition;
      private Label _lbltrkPosition;
      private TableLayoutPanel _tableLayoutPanel2;
      private ToolStripMenuItem _recentToolStripMenuItem;
      private ToolStripSeparator _toolStripSeparator2;
      private ToolStripMenuItem _fileExitToolStripMenuItem;
      private ToolStripSeparator _toolStripSeparator1;
      private TableLayoutPanel _tableLayoutPanel3;
      private ToolStripSeparator _toolStripSeparator3;
      private ToolStripMenuItem _optionsChangeloadingOrRasterizingResolutionToolStripMenuItem;
      private ToolStripMenuItem _helpToolStripMenuItem;
      private ToolStripMenuItem _helpAboutToolStripMenuItem;
      private ToolStripMenuItem _optionsSupportLoadingTEXTFilesToolStripMenuItem;
   }
}