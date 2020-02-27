// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using CCOWClientParticipationDemo.CCOW;
using CCOWClientParticipationDemo.Properties;
using CCOWClientParticipationDemo.UI;
using Leadtools;
using Leadtools.Ccow;
using Leadtools.Demos;
#if LEADTOOLS_V19_OR_LATER
using Leadtools.Ccow.Server;
using Leadtools.Ccow.Server.Data;
#endif // #if LEADTOOLS_V19_OR_LATER

namespace CCOWClientParticipationDemo
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private IContainer components;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelLink;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem contextToolStripMenuItem;
        private ToolTip toolTip;
        private ToolStripMenuItem suspendToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ClientContext _Context = null;
        private ToolStripStatusLabel toolStripStatusLabelUser;
        private ListView listViewPatients;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private bool _LoggedIn = false;       
        private string _NewPatientId = string.Empty;
        private string _NewUser = string.Empty;
        private ToolStripMenuItem logOffAllToolStripMenuItem;
        private bool _UpdateContext = true;
        private ToolStripMenuItem logOnToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private bool _LogOff = false;
        private static ActiveScenario _ActiveScenario;
        private static Leadtools.Demos.CCOWApplication _CCOWApplication;        
        private bool _AppOnlyLogin = false;
        private string _CurrentUser = string.Empty;

        //
        // Determines if the application is started as a user link participant.  If this is true the application
        // syncs with user and patient link.  If false it is only a patient linked application.
        //
        public static bool UserLink = false;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem resumeToolStripMenuItem;
        private TextBox textBoxHelp;
        private Label label1;
        public static bool Dashboard = false;
        private Panel panelInfo;
        private PictureBox pictureBoxStatus;
        private Label labelApplicationName;
        private ListView listViewContext;
        private Label label2;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Label label3;
        private Splitter splitter1;
        private Panel panel1;
        private SplitContainer splitContainer2;
        private RichTextBox richTextBoxLog;
        private Label label4;
        private CheckBox checkBoxShowPing;
        private Panel panel2;
        private static Color? _HiliteColor = null;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        
        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();            
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {               

                if (components != null)
                {
                    components.Dispose();
                }
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
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.toolStripStatusLabelLink = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.logOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
         this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.logOffAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.contextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.suspendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolTip = new System.Windows.Forms.ToolTip(this.components);
         this.listViewPatients = new System.Windows.Forms.ListView();
         this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.label3 = new System.Windows.Forms.Label();
         this.textBoxHelp = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.listViewContext = new System.Windows.Forms.ListView();
         this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.label2 = new System.Windows.Forms.Label();
         this.panelInfo = new System.Windows.Forms.Panel();
         this.labelApplicationName = new System.Windows.Forms.Label();
         this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
         this.splitter1 = new System.Windows.Forms.Splitter();
         this.panel1 = new System.Windows.Forms.Panel();
         this.splitContainer2 = new System.Windows.Forms.SplitContainer();
         this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
         this.panel2 = new System.Windows.Forms.Panel();
         this.label4 = new System.Windows.Forms.Label();
         this.checkBoxShowPing = new System.Windows.Forms.CheckBox();
         this.statusStrip1.SuspendLayout();
         this.menuStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.panelInfo.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
         this.splitContainer2.Panel1.SuspendLayout();
         this.splitContainer2.Panel2.SuspendLayout();
         this.splitContainer2.SuspendLayout();
         this.panel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLink,
            this.toolStripStatusLabelUser});
         this.statusStrip1.Location = new System.Drawing.Point(0, 583);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.ShowItemToolTips = true;
         this.statusStrip1.Size = new System.Drawing.Size(921, 22);
         this.statusStrip1.TabIndex = 1;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // toolStripStatusLabelLink
         // 
         this.toolStripStatusLabelLink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
         this.toolStripStatusLabelLink.Name = "toolStripStatusLabelLink";
         this.toolStripStatusLabelLink.Size = new System.Drawing.Size(902, 17);
         this.toolStripStatusLabelLink.Spring = true;
         this.toolStripStatusLabelLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // toolStripStatusLabelUser
         // 
         this.toolStripStatusLabelUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
         this.toolStripStatusLabelUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
         this.toolStripStatusLabelUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
         this.toolStripStatusLabelUser.Image = global::CCOWClientParticipationDemo.Properties.Resources.user;
         this.toolStripStatusLabelUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
         this.toolStripStatusLabelUser.Size = new System.Drawing.Size(4, 17);
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.contextToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(921, 24);
         this.menuStrip1.TabIndex = 2;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOnToolStripMenuItem,
            this.toolStripMenuItem3,
            this.logoutToolStripMenuItem,
            this.logOffAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         this.fileToolStripMenuItem.MouseHover += new System.EventHandler(this.MenuItem_MouseHover);
         // 
         // logOnToolStripMenuItem
         // 
         this.logOnToolStripMenuItem.Name = "logOnToolStripMenuItem";
         this.logOnToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.logOnToolStripMenuItem.Text = "Log-On";
         this.logOnToolStripMenuItem.Click += new System.EventHandler(this.logOnToolStripMenuItem_Click);
         this.logOnToolStripMenuItem.MouseHover += new System.EventHandler(this.MenuItem_MouseHover);
         // 
         // toolStripMenuItem3
         // 
         this.toolStripMenuItem3.Name = "toolStripMenuItem3";
         this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
         // 
         // logoutToolStripMenuItem
         // 
         this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
         this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.logoutToolStripMenuItem.Text = "&Log-Off";
         this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
         this.logoutToolStripMenuItem.MouseHover += new System.EventHandler(this.MenuItem_MouseHover);
         // 
         // logOffAllToolStripMenuItem
         // 
         this.logOffAllToolStripMenuItem.Name = "logOffAllToolStripMenuItem";
         this.logOffAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.logOffAllToolStripMenuItem.Text = "&Log-Off All";
         this.logOffAllToolStripMenuItem.Click += new System.EventHandler(this.logOffAllToolStripMenuItem_Click);
         this.logOffAllToolStripMenuItem.MouseHover += new System.EventHandler(this.MenuItem_MouseHover);
         // 
         // toolStripMenuItem2
         // 
         this.toolStripMenuItem2.Name = "toolStripMenuItem2";
         this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.exitToolStripMenuItem.Text = "&Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         this.exitToolStripMenuItem.MouseHover += new System.EventHandler(this.MenuItem_MouseHover);
         // 
         // contextToolStripMenuItem
         // 
         this.contextToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suspendToolStripMenuItem,
            this.resumeToolStripMenuItem});
         this.contextToolStripMenuItem.Name = "contextToolStripMenuItem";
         this.contextToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
         this.contextToolStripMenuItem.Text = "&Context";
         this.contextToolStripMenuItem.MouseHover += new System.EventHandler(this.MenuItem_MouseHover);
         // 
         // suspendToolStripMenuItem
         // 
         this.suspendToolStripMenuItem.Name = "suspendToolStripMenuItem";
         this.suspendToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
         this.suspendToolStripMenuItem.Text = "&Suspend";
         this.suspendToolStripMenuItem.Click += new System.EventHandler(this.suspendToolStripMenuItem_Click);
         this.suspendToolStripMenuItem.MouseHover += new System.EventHandler(this.MenuItem_MouseHover);
         // 
         // resumeToolStripMenuItem
         // 
         this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
         this.resumeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
         this.resumeToolStripMenuItem.Text = "&Resume";
         this.resumeToolStripMenuItem.Click += new System.EventHandler(this.resumeToolStripMenuItem_Click);
         this.resumeToolStripMenuItem.MouseHover += new System.EventHandler(this.MenuItem_MouseHover);
         // 
         // toolTip
         // 
         this.toolTip.IsBalloon = true;
         this.toolTip.ShowAlways = true;
         this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
         // 
         // listViewPatients
         // 
         this.listViewPatients.BackColor = System.Drawing.SystemColors.Window;
         this.listViewPatients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
         this.listViewPatients.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.listViewPatients.FullRowSelect = true;
         this.listViewPatients.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listViewPatients.HideSelection = false;
         this.listViewPatients.Location = new System.Drawing.Point(0, 13);
         this.listViewPatients.MultiSelect = false;
         this.listViewPatients.Name = "listViewPatients";
         this.listViewPatients.Size = new System.Drawing.Size(709, 198);
         this.listViewPatients.TabIndex = 3;
         this.listViewPatients.UseCompatibleStateImageBehavior = false;
         this.listViewPatients.View = System.Windows.Forms.View.Details;
         this.listViewPatients.SelectedIndexChanged += new System.EventHandler(this.listViewPatients_SelectedIndexChanged);
         this.listViewPatients.Resize += new System.EventHandler(this.listViewPatients_Resize);
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Id";
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Name";
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "BirthDate";
         this.columnHeader3.Width = 100;
         // 
         // columnHeader4
         // 
         this.columnHeader4.Text = "Sex";
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
         this.splitContainer1.Location = new System.Drawing.Point(0, 80);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.listViewPatients);
         this.splitContainer1.Panel1.Controls.Add(this.label3);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.textBoxHelp);
         this.splitContainer1.Panel2.Controls.Add(this.label1);
         this.splitContainer1.Size = new System.Drawing.Size(921, 211);
         this.splitContainer1.SplitterDistance = 709;
         this.splitContainer1.TabIndex = 4;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Dock = System.Windows.Forms.DockStyle.Top;
         this.label3.Location = new System.Drawing.Point(0, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(356, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Patients (Click on a patient to synchronize with other context applications):";
         // 
         // textBoxHelp
         // 
         this.textBoxHelp.Dock = System.Windows.Forms.DockStyle.Fill;
         this.textBoxHelp.Location = new System.Drawing.Point(0, 13);
         this.textBoxHelp.Multiline = true;
         this.textBoxHelp.Name = "textBoxHelp";
         this.textBoxHelp.ReadOnly = true;
         this.textBoxHelp.Size = new System.Drawing.Size(208, 198);
         this.textBoxHelp.TabIndex = 2;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Dock = System.Windows.Forms.DockStyle.Top;
         this.label1.Location = new System.Drawing.Point(0, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(32, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Help:";
         // 
         // listViewContext
         // 
         this.listViewContext.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
         this.listViewContext.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewContext.Location = new System.Drawing.Point(0, 13);
         this.listViewContext.Name = "listViewContext";
         this.listViewContext.Size = new System.Drawing.Size(921, 131);
         this.listViewContext.TabIndex = 1;
         this.listViewContext.UseCompatibleStateImageBehavior = false;
         this.listViewContext.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader5
         // 
         this.columnHeader5.Text = "Name";
         // 
         // columnHeader6
         // 
         this.columnHeader6.Text = "Value";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Dock = System.Windows.Forms.DockStyle.Top;
         this.label2.Location = new System.Drawing.Point(0, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(83, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Current Context:";
         // 
         // panelInfo
         // 
         this.panelInfo.Controls.Add(this.labelApplicationName);
         this.panelInfo.Controls.Add(this.pictureBoxStatus);
         this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelInfo.Location = new System.Drawing.Point(0, 24);
         this.panelInfo.Name = "panelInfo";
         this.panelInfo.Size = new System.Drawing.Size(921, 56);
         this.panelInfo.TabIndex = 5;
         // 
         // labelApplicationName
         // 
         this.labelApplicationName.AutoSize = true;
         this.labelApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelApplicationName.ForeColor = System.Drawing.Color.White;
         this.labelApplicationName.Location = new System.Drawing.Point(4, 10);
         this.labelApplicationName.Name = "labelApplicationName";
         this.labelApplicationName.Size = new System.Drawing.Size(101, 36);
         this.labelApplicationName.TabIndex = 1;
         this.labelApplicationName.Text = "label2";
         // 
         // pictureBoxStatus
         // 
         this.pictureBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.pictureBoxStatus.Image = global::CCOWClientParticipationDemo.Properties.Resources.Broken;
         this.pictureBoxStatus.Location = new System.Drawing.Point(861, 4);
         this.pictureBoxStatus.Name = "pictureBoxStatus";
         this.pictureBoxStatus.Size = new System.Drawing.Size(48, 48);
         this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this.pictureBoxStatus.TabIndex = 0;
         this.pictureBoxStatus.TabStop = false;
         // 
         // splitter1
         // 
         this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
         this.splitter1.Location = new System.Drawing.Point(0, 291);
         this.splitter1.Name = "splitter1";
         this.splitter1.Size = new System.Drawing.Size(921, 3);
         this.splitter1.TabIndex = 6;
         this.splitter1.TabStop = false;
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.splitContainer2);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel1.Location = new System.Drawing.Point(0, 294);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(921, 289);
         this.panel1.TabIndex = 7;
         // 
         // splitContainer2
         // 
         this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer2.Location = new System.Drawing.Point(0, 0);
         this.splitContainer2.Name = "splitContainer2";
         this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer2.Panel1
         // 
         this.splitContainer2.Panel1.Controls.Add(this.listViewContext);
         this.splitContainer2.Panel1.Controls.Add(this.label2);
         // 
         // splitContainer2.Panel2
         // 
         this.splitContainer2.Panel2.Controls.Add(this.richTextBoxLog);
         this.splitContainer2.Panel2.Controls.Add(this.panel2);
         this.splitContainer2.Size = new System.Drawing.Size(921, 289);
         this.splitContainer2.SplitterDistance = 144;
         this.splitContainer2.TabIndex = 2;
         // 
         // richTextBoxLog
         // 
         this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBoxLog.Location = new System.Drawing.Point(0, 18);
         this.richTextBoxLog.Name = "richTextBoxLog";
         this.richTextBoxLog.Size = new System.Drawing.Size(921, 123);
         this.richTextBoxLog.TabIndex = 1;
         this.richTextBoxLog.Text = "";
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.label4);
         this.panel2.Controls.Add(this.checkBoxShowPing);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel2.Location = new System.Drawing.Point(0, 0);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(921, 18);
         this.panel2.TabIndex = 3;
         // 
         // label4
         // 
         this.label4.Dock = System.Windows.Forms.DockStyle.Left;
         this.label4.Location = new System.Drawing.Point(0, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(34, 18);
         this.label4.TabIndex = 0;
         this.label4.Text = "Log:";
         // 
         // checkBoxShowPing
         // 
         this.checkBoxShowPing.AutoSize = true;
         this.checkBoxShowPing.Location = new System.Drawing.Point(40, -1);
         this.checkBoxShowPing.Name = "checkBoxShowPing";
         this.checkBoxShowPing.Size = new System.Drawing.Size(98, 17);
         this.checkBoxShowPing.TabIndex = 2;
         this.checkBoxShowPing.Text = "Show Ping Log";
         this.checkBoxShowPing.UseVisualStyleBackColor = true;
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(921, 605);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.splitter1);
         this.Controls.Add(this.splitContainer1);
         this.Controls.Add(this.statusStrip1);
         this.Controls.Add(this.panelInfo);
         this.Controls.Add(this.menuStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "XXX SDI Demo";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.Shown += new System.EventHandler(this.MainForm_Shown);
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel1.PerformLayout();
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.panelInfo.ResumeLayout(false);
         this.panelInfo.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
         this.panel1.ResumeLayout(false);
         this.splitContainer2.Panel1.ResumeLayout(false);
         this.splitContainer2.Panel1.PerformLayout();
         this.splitContainer2.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
         this.splitContainer2.ResumeLayout(false);
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }
        #endregion

        public const int WM_USER = 0x0400;
        public const int WM_GETID = WM_USER + 1;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
           if (!Support.SetLicense())
              return;

            if (RasterSupport.IsLocked(RasterSupportType.Ccow))
            {
                MessageBox.Show("CCOW Support is locked!  Application will exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //
            // See if multiple intances are running
            //
            Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);

            if (processes != null && processes.Length > 3)
            {
                string message = "Only three instances of this application are allowed to run.\r\nApplication will exit.";
                
                Messager.ShowInformation(null, message);
                Application.Exit();
                return;
            }
            else
            {
                _ActiveScenario = ActiveScenario.Load();                

                ReadCommandLine(args);
                if (!Dashboard)
                {
                    if(processes!=null)
                    {
                        Process current = Process.GetCurrentProcess();
                        List<int> indexes = new List<int>();

                        foreach (Process p in processes)
                        {
                            if (p.Id == current.Id)
                                continue;

                            IntPtr i = SendMessage(p.MainWindowHandle, WM_GETID, IntPtr.Zero, IntPtr.Zero);

                            indexes.Add(i.ToInt32());
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            if (indexes.Contains(i))
                                continue;

                            MainForm.ApplicationIndex = i;
                            break;
                        }                       
                    }

                    switch (ApplicationIndex)
                    {
                        case 0:
                            _HiliteColor = Color.Red;
                            break;
                        case 1:
                            _HiliteColor = Color.Green;
                            break;
                        default:
                            _HiliteColor = Color.Blue;
                            break;
                    }
                }

                if (_ActiveScenario != null && _ActiveScenario.Scenario != null && _ActiveScenario.Scenario.Applications.Count > ApplicationIndex)
                {
                    _CCOWApplication = _ActiveScenario.Scenario.Applications[ApplicationIndex];
                    MainForm.ApplicationName = _CCOWApplication.Name;
                    MainForm.Suffix = _CCOWApplication.Suffix;
                }                                
            }
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(new MainForm());
        }        

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {            
        }

        static void ReadCommandLine(string[] args)
        {
            string sQuestion = "/?";
            string sHelp = "/help";
            string sLink = "/link=";
            string sDashboard = "/dashboard";  // Passed if application launched from the dashboard.
            string sColor = "/color=";
            string sIndex = "/index=";

            foreach (string s in args)
            {
                string sVal = string.Empty;

                if ((string.Compare(sHelp, s, true) == 0) || (string.Compare(sQuestion, s, true) == 0))
                {
                    //MessageBox.Show(sHelpInstructions, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (string.Compare(sDashboard, s, true) == 0)
                {
                    Dashboard = true;
                }
                else if (s.StartsWith(sLink, true, null))
                {
                    sVal = s.Substring(sLink.Length);
                    if (sVal.ToLower() == "user")
                        UserLink = true;
                }
                else if (s.StartsWith(sColor, true, null))
                {
                    sVal = s.Substring(sColor.Length);
                    try
                    {
                        _HiliteColor = ColorTranslator.FromHtml(sVal);
                    }
                    catch { }
                }
                else if (s.StartsWith(sIndex, true, null))
                {
                    sVal = s.Substring(sIndex.Length);
                    try
                    {
                        ApplicationIndex = Convert.ToInt32(sVal);
                    }
                    catch{}
                }
            }
        }

        private static string _ApplicationName = "LEADTOOLS CCOW Desktop";

        public static string ApplicationName
        {
            get
            {
                return _ApplicationName;
            }
            set
            {
                _ApplicationName = value;
            }
        }

        private static string _Suffix = string.Empty;

        public static string Suffix
        {
            get
            {
                return _Suffix;
            }
            set
            {
                _Suffix = value;
            }
        }

        private static int _ApplicationIndex = 0;

        public static int ApplicationIndex
        {
            get
            {
                return _ApplicationIndex;
            }
            set
            {
                _ApplicationIndex = value;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_GETID)
            {
                m.Result = (IntPtr)ApplicationIndex;
            }
        }

        /// <summary>
        /// Initialize the Application.
        /// </summary>
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Messager.Caption = "C# CCOW Context Participation Demo";
            Text = Messager.Caption;                  
            SetCCowIcon(ContextState.Broken);            

            if (_HiliteColor != null)
            {
                panelInfo.BackColor = _HiliteColor.Value;
                toolStripStatusLabelUser.ForeColor = _HiliteColor.Value;
            }

            int width = listViewPatients.ClientRectangle.Width / listViewPatients.Columns.Count;

            foreach (ColumnHeader column in listViewPatients.Columns)
            {
                column.Width = width;
            }

            width = listViewContext.ClientRectangle.Width / listViewContext.Columns.Count;
            foreach (ColumnHeader column in listViewContext.Columns)
            {
                column.Width = width;
            }

            labelApplicationName.Text = MainForm.ApplicationName;
        }        

        private void SetCCowIcon(ContextState state)
        {
            switch (state)
            {
                case ContextState.Broken:
                    pictureBoxStatus.Image = Resources.Broken;                    
                    break;
                case ContextState.Changing:
                    pictureBoxStatus.Image = Resources.Changing;                    
                    break;
                case ContextState.Linked:
                    pictureBoxStatus.Image = Resources.Linked;                    
                    break;
            }
        }

       private void EnableAndVisibleMenu(MenuItem menu, bool value)
        {
            menu.Enabled = value;
            menu.Visible = value;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InfoDialog dialogInfo = new InfoDialog(this);
            Exception old = null;

            dialogInfo.Title = "Joining Common Context";
            dialogInfo.Description = "Attempting to join common context";
            try
            {
                _Context = new ClientContext(ApplicationName,this);
                _Context.Terminated += new EventHandler(Context_Terminated);
                _Context.ChangesAccepted += new EventHandler<ContextEventArgs>(Context_ChangesAccepted);
                _Context.ChangesCanceled += new EventHandler<ContextEventArgs>(Context_ChangesCanceled);
                _Context.ChangesPending += new EventHandler<ContextEventArgs>(Context_ChangesPending);
                _Context.LeftContext += new EventHandler(Context_LeftContext);
                _Context.JoinedContext += new EventHandler(Context_JoinedContext);
                _Context.Pinged += new EventHandler(Context_Pinged);

                if (dialogInfo.ShowDialog(() => _Context.Join(ApplicationName, true)) == DialogResult.OK)
                {
                   bool failedVerify = false;

                    SetCCowIcon(ContextState.Linked);
                    ShowContext();

                    try
                    {
                        dialogInfo.Title = "Secure Binding";
                        dialogInfo.Description = "Securely binding to context manager";
                        dialogInfo.ShowDialog(() => _Context.SecureBind(ref failedVerify));
                        if (dialogInfo.Exception != null)
                        {                           
                            throw dialogInfo.Exception;
                        }

                    }
                    catch (Exception exception)
                    {
                        old = exception;
                        Messager.ShowError(this, exception);
                    }

                    if (MainForm.Dashboard)
                    {                        
                        DoDashboard(true, failedVerify);
                    }
                    else
                    {                        
                        DoApplicationLogin();
                        if (_LoggedIn)
                        {
                            _AppOnlyLogin = true;
                            _Context.SetFilter("Patient");
                            SetLinkDisplay(Resources.PatientLink);
                            ShowContext();
                        }
                    }                    
                }
                else
                {
                    if (dialogInfo.Exception != null)
                    {                       
                        throw dialogInfo.Exception;
                    }
                }
                        
                if (_Context.Joined)
                {                   
                    InitializePatients();
                    if (_Context.LastCoupon != 0)
                    {
                        CheckPatient(_Context.LastCoupon, false);
                        SelectNewPatient();
                    }
                }
            }
            catch(Exception ex)
            {
                if (old != null && old.Message != ex.Message)
                {
                    string message = ex.Message;
                    bool exit = false;

                    if (ex.Message.ToLower().Contains("not allowed to participate"))
                    {
                        message += "\r\n\r\nPlease configure the CCOW server to allow this application (" + ApplicationName + ") ";
                        message += "to join the common context.";
                    }

                    if (ex.Message.Contains("already joined"))
                    {
                        message += "\r\n\r\nApplication will exit.";
                        exit = true;
                    }
                    if (ex.Message.Contains("A signature could not be authenticated"))
                    {
                        MainForm.UserLink = false;
                        try
                        {
                            if (_Context != null)
                                _Context.SetFilter("Patient");
                        }
                        catch (Exception exc)
                        {
                            Messager.ShowError(this, exc.Message);
                        }
                    }

                    if (!IsDisposed)
                    {
                        //
                        // Load patients if we have joined the context
                        //
                        if (_Context.Joined)
                        {
                            if (listViewPatients.Items.Count == 0)
                                InitializePatients();
                        }
                        Messager.ShowError(this, message);
                    }

                    if (exit)
                        Close();
                }
                else
                {
                    if (_Context.Joined)
                    {
                        if (listViewPatients.Items.Count == 0)
                            InitializePatients();
                    }
                }
            }            
            contextToolStripMenuItem.Enabled = _Context != null;   
            if(MainForm.UserLink)
                SetLinkDisplay(Resources.UserPatientLink);
            else
                SetLinkDisplay(Resources.PatientLink);
        }

        private void DoDashboard(bool showInfo, bool failedVerify)
        {
            if (MainForm.UserLink)
            {
                if (!_Context.IsUserContextSet())
                {
                    Process[] authApp = Process.GetProcessesByName("CSCCOWAuthenticationDemo");
                    Process[] authAppOrg = Process.GetProcessesByName("CSCCOWAuthenticationDemo_Original");

                    if (authApp.Length == 1 || authAppOrg.Length==1)
                    {
                        DialogResult result;

                        result = Messager.Show(this, "The user context is not set.  If another application has " +
                                           "logged in with a user unknown to this application, close this application and launch " +
                                           "without enabling SSO.  Select 'No', if you want to log in with the CSCCOWAuthentication demo." +
                                           "\r\n\r\nWould you like to close this application?",
                                           MessageBoxIcon.Stop, MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                        {
                            IntPtr mainWindow = authApp.Length == 1 ? authApp[0].MainWindowHandle : authAppOrg[0].MainWindowHandle;

                            SetForegroundWindow(mainWindow);
                        }
                        else
                        {
                            Close();
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        if (Messager.Show(this, "This application cannot continue.  The application was launched from the CCOW " +
                                                " Dashboard and requires that a user be set in the context.  If another application " +
                                                "has logged in with a user unknown to this application, select 'No' to close this application. Then, relaunch " +
                                                "from the dashboard without enabling SSO.\n\nWould you like to launch the CSCCOWAuthenticationDemo?",
                                                MessageBoxIcon.Asterisk, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CCOWUtils.LauchAuthApplication(null);
                        }
                        Close();
                        Environment.Exit(0);
                    }
                }
                else
                {
                    //
                    // The user context is set, therefore we need to check to see if we can logon this specific user
                    //
                    string user = _Context.GetCurrentUser();

                    if (!string.IsNullOrEmpty(user))
                    {
                        LogInApplication(user);
                        SetLinkDisplay(Resources.UserPatientLink);
                    }
                }
            }
            else
            {
                if (showInfo)
                {
                   if (!failedVerify)
                   {
                      Messager.Show(this, "This application was launched from the dashboard with user linking disabled. " +
                                           "You will be required to log into the application.  The login " +
                                           "dialog will appear when this message box is closed.  Once logged in, the application " +
                                           "will only be patient-linked.",
                                           MessageBoxIcon.Information, MessageBoxButtons.OK);
                   }
                   else
                   {
                      Messager.Show(this, "This application failed to securely bind with the context manager. " +
                                           "You will be required to log into the application.  The login " +
                                           "dialog will appear when this message box is closed.  Once logged in, the application " +
                                           "will only be patient-linked.",
                                           MessageBoxIcon.Information, MessageBoxButtons.OK);
                   }
                }
                DoApplicationLogin();
                if (_LoggedIn)
                {                    
                    //
                    // Only be notified of patient context changes
                    //
                    _AppOnlyLogin = true;
                    _Context.SetFilter("Patient");
                    SetLinkDisplay(Resources.PatientLink);
                }
            }
        }

        private void DoApplicationLogin()
        {
            LoginDialog dlgLogin = new LoginDialog(_CCOWApplication);

            dlgLogin.Text = "Log On: " + MainForm.ApplicationName;                        
            if (dlgLogin.ShowDialog(this) == DialogResult.OK)
            {                
                SetUserInfo(dlgLogin.Username);
                _LoggedIn = true;
            }
            else
            {
                Close();
                return;
            }
        }

        bool loggingIn = false;

        private void LogInApplication(string user)
        {
            if (loggingIn)
                return;

            try
            {
                loggingIn = true;
                string authData = _Context.GetAuthenticationData(user);

                //
                // If we do not have any authentication data then we need to display a dialog and
                // let the user log into this application. Once successfully logged in the user auth
                // data (password) will be added to the authentication repository.
                //
                if (string.IsNullOrEmpty(authData))
                {
                    LoginDialog dlgLogin = new LoginDialog(_CCOWApplication);

                    dlgLogin.Text = "Log On: " + MainForm.ApplicationName;
                    dlgLogin.Username = user;
                    dlgLogin.EnableUser = false;
                    dlgLogin.FirstLogin = true;
                    if (dlgLogin.ShowDialog(this) == DialogResult.OK)
                    {
                        _Context.SetAuthenticationData(user, dlgLogin.Password);
                        _LoggedIn = true;
                        SetUserInfo(user);
                    }
                    else
                    {
                        Close();
                        return;
                    }
                }
                else
                {
                    SetUserInfo(user);
                    _LoggedIn = true;
                }
            }
            finally
            {
                loggingIn = false;
            }
        }

        /// <summary>
        /// Initializes the patients.  This demo uses a list of predefined patients.  In a production scenario, the
        /// patient information should be read from a database of some other on site repository.  This examples serves
        /// as a sample of how to do things, not a representation of best practices.
        /// </summary>
        private void InitializePatients()
        {
            if (_CCOWApplication != null)
            {
                foreach (Patient patient in _CCOWApplication.Patients)
                {
                    AddPatient(patient);
                }
            }
        }

        private void AddPatient(Patient patient)
        {            
            ListViewItem item = new ListViewItem(patient.Id);
           
            item.SubItems.Add(patient.Name);
            item.SubItems.Add(patient.BirthDate.HasValue ? patient.BirthDate.Value.ToShortDateString() : string.Empty);
            item.SubItems.Add(patient.Sex);
            item.Tag = patient;
            listViewPatients.Items.Add(item);
        }        

        private void SetUserInfo(string user)
        {
            _CurrentUser = user;
            toolStripStatusLabelUser.Text = user;
            if (string.IsNullOrEmpty(user))
            {                
                _LoggedIn = false;
                toolStripStatusLabelUser.DisplayStyle = ToolStripItemDisplayStyle.Text;
            }
            else
            {                
                toolStripStatusLabelUser.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            }
        }

        private void Context_ChangesCanceled(object sender, ContextEventArgs e)
        {
            Log("=> Context Changes Canceled"); 
            _NewPatientId = string.Empty;
            _NewUser = string.Empty;
        }

        private void Context_ChangesAccepted(object sender, ContextEventArgs e)
        {
            Log("=> Context Changes Accepted");
            if (_LogOff)
            {
                Invoke(new MethodInvoker(LogOffUser));
            }
            else if (!string.IsNullOrEmpty(_NewUser) && MainForm.UserLink)
            {
                Invoke( new Action<string>(LogInApplication),_NewUser);
            }

            if (!loggingIn)
            {
                Invoke(new MethodInvoker(SelectNewPatient));
                Invoke(new MethodInvoker(ShowContext));
            }
        }

        private void Context_Terminated(object sender, EventArgs e)
        {
            Log("=> Context Terminated");
        }

        private void Context_ChangesPending(object sender, ContextEventArgs e)
        {
            Log("=> Context Changes Pending");
            if (_Context.IsSetting("user", "logon",e.ContextCoupon))
            {
                CheckUser(e);
            }
            CheckPatient(e.ContextCoupon,true);
            e.Decision = "accept";
        }

        private void Context_Pinged(object sender, EventArgs e)
        {
            if(checkBoxShowPing.Checked)
                Log("=> Received Ping");
        }

        private void Context_JoinedContext(object sender, EventArgs e)
        {
            Log("=> Successfully Joined Context");
            Log("     Participant Coupon: " + _Context.ParticipantCoupon.ToString());
        }

        private void CheckUser(ContextEventArgs e)
        {
            ContextItem item = new ContextItem("User.Id.logon." + MainForm.Suffix);
            string temp = _Context.GetItemValue(item, false, e.ContextCoupon);

            _NewUser = string.Empty;

            //
            // Check to see if we are removing the user
            //
            if (temp.Length == 0 && _LoggedIn)
            {
                _LogOff = true;
            }
            else
            {
                //
                // A new user has been logged in
                //
                if (_CurrentUser.ToLower() != temp.ToLower())
                {
                    _NewUser = temp;
                }
            }
        }

#if LEADTOOLS_V19_OR_LATER
        static bool CheckPatientDependencies()
        {
           if(!UserLink)
              return false;

           Monitor.Enter(CcowServer.LockObject);
           try
           {
              using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
              {
                 CCOWSubject patientSubject = db.CCOWSubject.FirstOrDefault(a => a.Subject.ToLower() == "patient");
                 foreach (CCOWSubjectDependency dp in patientSubject.DependentSubjects)
                 {
                    if(dp.CCOWSubject.Subject.ToLower() == "user")
                       return true;
                 }
              }
           }
           finally
           {
              Monitor.Exit(CcowServer.LockObject);
           }

           return false;
        }
#endif // #if LEADTOOLS_V19_OR_LATER
        private void CheckPatient(int contextCoupon, bool onlyChanges)
        {
            ContextItem item = new ContextItem("Patient.Id.MRN." + MainForm.Suffix);
            string temp = _Context.GetItemValue(item, onlyChanges, contextCoupon);

            _NewPatientId = string.Empty;
            foreach (Patient p in _CCOWApplication.Patients)
            {
                if (p.Id.ToLower() == temp.ToLower())
                {
                    _NewPatientId = temp;
                    break;
                }
            }
        }

        private void Context_LeftContext(object sender, EventArgs e)
        {
            SetCCowIcon(ContextState.Broken);
        }

        private void LogOffUser()
        {
            if (_LogOff)
            {
                SetUserInfo(string.Empty);
                _LogOff = false;

#if LEADTOOLS_V19_OR_LATER
                if (CheckPatientDependencies())
                   this._Context.Leave();
#endif // #if LEADTOOLS_V19_OR_LATER
            }
        }

        private void SelectNewPatient()
        {
            _UpdateContext = false;
            try
            {
                if (_NewPatientId == string.Empty)
                {
                    listViewPatients.SelectedItems.Clear();
                }
                else
                {
                    foreach (ListViewItem item in listViewPatients.Items)
                    {
                       Patient patient = item.Tag as Patient;

                       if (patient != null)
                          if (patient.Id.ToLower() == _NewPatientId.ToLower())
                          {
                             item.Selected = true;
                             break;
                          }
                    }
                }
            }
            finally
            {
                _UpdateContext = true;
            }
        }

        public void ShowContext()
        {
            NameValueCollection context = _Context.GetCurrentContext();

            Monitor.Enter(this);
            try
            {                
                listViewContext.Items.Clear();
                foreach (string name in context)
                {
                    ListViewItem item = listViewContext.Items.Add(name);

                    item.SubItems.Add(context[name]);
                }
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Context != null)
            {
                _Context.Terminated -= Context_Terminated;
                _Context.ChangesAccepted -= Context_ChangesAccepted;
                _Context.ChangesCanceled -= Context_ChangesCanceled;
                _Context.LeftContext -= Context_LeftContext;
                _Context.Pinged -= Context_Pinged;
                _Context.JoinedContext -= Context_JoinedContext;

                if (_Context.Joined)
                {
                    InfoDialog dlgInfo = new InfoDialog(this);

                    dlgInfo.Title = "Leaving Common Context";
                    dlgInfo.Description = "Attempting to leave common context";
                    try
                    {
                        dlgInfo.ShowDialog(() => _Context.Leave());
                    }
                    catch (Exception ex)
                    {
                        Messager.ShowError(this, ex);
                        e.Cancel = true;
                    }
                }
            }            
        }        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }               

        private void suspendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_Context.Suspended)
                {
                    _Context.Suspend();
                    if (_Context.Suspended)
                    {
                        SetCCowIcon(ContextState.Broken);
                        listViewPatients.Enabled = false;
                    }
                }
                else
                {
                    Messager.ShowInformation(this, "This application has already suspended it's participation.  Please resume before trying to suspend.");
                }
            }
            catch (Exception exception)
            {
                if (exception is COMException)
                {
                    //
                    // Check to see if the Context Manager server has terminated.
                    //
                    if (exception.Message.Contains("The RPC server is unavailable"))
                    {
                        Messager.Show(this, "The Context Management Server was terminated.  The application can no longer access the context and will restart to attempt to rejoin the context.",
                                      MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
                        Close();
                        CCOWUtils.Restart();
                    }
                    else
                    {
                        Messager.ShowError(null, exception);
                    }
                }
                else
                    Messager.ShowError(null, exception);
            }
        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Context.Suspended)
            {
                _Context.Resume(true);
                if (!_Context.Suspended)
                {
                    SetCCowIcon(ContextState.Linked);
                    listViewPatients.Enabled = true;
                    ShowContext();                                       
                    CheckPatient(_Context.LastCoupon, false);
                    SelectNewPatient();
                    if (MainForm.UserLink)
                    {
                        string user = _Context.GetCurrentUser();

                        SetUserInfo(user);
                    }
                }
            }
            else
            {
               Messager.ShowInformation(this, "This application's participation is not suspended. Please, suspend this application before trying to resume.");
            }
        }

        private void listViewPatients_Resize(object sender, EventArgs e)
        {
            int width = listViewPatients.ClientRectangle.Width / listViewPatients.Columns.Count;

            foreach (ColumnHeader column in listViewPatients.Columns)
            {
                column.Width = width;
            }
        }        

        private void listViewPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewPatients.SelectedItems.Count > 0 && _UpdateContext && _Context.Joined)
                {
                    Patient patient = listViewPatients.SelectedItems[0].Tag as Patient;
                    Subject patientSubject = new Subject("Patient");
                    ContextItem item = new ContextItem("Patient.Id.MRN." + MainForm.Suffix);

                   if (patient != null) item.Value = patient.Id;
                   patientSubject.Items.Add(item);
                    _Context.Set(patientSubject);
                    ShowContext();
                }
                else
                {
                    if (!_Context.Joined)
                    {
                        Log(Color.Red, "Not a member of the context");
                        Log("    Patient context not switched");
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is COMException)
                {   
                    //
                    // Check to see if the Context Manager server has terminated.
                    //
                    if (exception.Message.Contains("The RPC server is unavailable"))
                    {
                       Messager.Show(this, "The Context Management Server was terminated.  The application can no longer access the context and will restart to attempt to rejoin the context.",
                                      MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
                        Close();
                        CCOWUtils.Restart();
                    }
                    else
                    {
                        Messager.ShowError(null, exception);
                    }
                }
                else
                    Messager.ShowError(null, exception);
            }
        }        

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _Context.Leave();
                SetUserInfo(string.Empty);
                listViewContext.Items.Clear();
                _LoggedIn = false;
                SetLinkDisplay(string.Empty);
            }
            catch (Exception exception)
            {
                if (exception is COMException)
                {
                    //
                    // Check to see if the Context Manager server has terminated.
                    //
                    if (exception.Message.Contains("The RPC server is unavailable"))
                    {
                       Messager.Show(this, "The Context Management Server was terminated.  The application can no longer access the context and will restart to attempt to rejoin the context.",
                                      MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
                        Close();
                        CCOWUtils.Restart();
                    }
                    else
                    {
                        Messager.ShowError(null, exception);
                    }
                }
                else
                    Messager.ShowError(null, exception);
            }
        }

        private void logOffAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_Context.Joined)
            {
               Messager.ShowInformation(this, "This application is currently not joined to the context.  The 'Log-Off All' option " +
                                               "is not available. If you would like to enable the 'Log-Off All' option, close and restart this " +
                                               "application from the CCOW dashboard with the SSO option enabled.");
                return;
            }

            try
            {
                if (!_AppOnlyLogin)
                {
                    Subject userSubject = new Subject("User");
                    ContextItem item = new ContextItem("User.Id.logon." + MainForm.Suffix, string.Empty);

                    userSubject.Items.Add(item);
                    _Context.Set(userSubject);
                    SetUserInfo(string.Empty);
                    _LoggedIn = false;
                    ShowContext();
#if LEADTOOLS_V19_OR_LATER
                    if (CheckPatientDependencies())
                       this._Context.Leave();
#endif // #if LEADTOOLS_V19_OR_LATER
                }
                else
                {
                   Messager.ShowInformation(this, "This application is currently not joined to the context.  The 'Log-Off All' option " +
                                                  "is not available. If you would like to enable the 'Log-Off All' option, close and restart this " +
                                                  "application from the CCOW dashboard with the SSO option enabled.");
                }
            }
            catch (Exception exception)
            {
                if (exception is COMException)
                {
                    //
                    // Check to see if the Context Manager server has terminated.
                    //
                    if (exception.Message.Contains("The RPC server is unavailable"))
                    {
                       Messager.Show(this, "The Context Management Server was terminated.  The application can no longer access the context and will restart to attempt to rejoin the context.",
                                      MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
                        Close();
                        CCOWUtils.Restart();
                    }
                    else
                    {
                        Messager.ShowError(null, exception);
                    }
                }
                else
                    Messager.ShowError(null, exception);
            }
        }

        private void logOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exception old = null;

            if (!_LoggedIn)
            {
                InfoDialog dialogInfo = new InfoDialog(this);
                
                dialogInfo.Title = "Joining Common Context";
                dialogInfo.Description = "Attempting to join the common context";
                try
                {
                   bool failedVerify = false;

                    if (!_Context.Joined)
                    {
                        if (dialogInfo.ShowDialog(() => _Context.Join(ApplicationName, true)) == DialogResult.OK)
                        {
                            SetCCowIcon(ContextState.Linked);
                        }

                        if (dialogInfo.Exception != null)
                            throw dialogInfo.Exception;

                        try
                        {
                            dialogInfo.Title = "Secure Binding";
                            dialogInfo.Description = "Securely binding to the context manager";
                            dialogInfo.ShowDialog(() => _Context.SecureBind(ref failedVerify));
                            if (dialogInfo.Exception != null)
                                throw dialogInfo.Exception;

                        }
                        catch (Exception exception)
                        {
                            old = exception;
                            Messager.ShowError(this, exception);
                        }
                    }

                    if (MainForm.Dashboard)
                    {
                        DoDashboard(false, failedVerify);
                    }
                    else
                    {
                        DoApplicationLogin();
                    }
                    ShowContext();
                    if (listViewPatients.Items.Count == 0)
                        InitializePatients();

                    if (_Context.LastCoupon != 0)
                    {
                        CheckPatient(_Context.LastCoupon, false);
                        SelectNewPatient();
                    }
                }
                catch (Exception exception)
                {
                    if (exception is COMException)
                    {
                        //
                        // Check to see if the Context Manager server has terminated.
                        //
                        if (exception.Message.Contains("The RPC server is unavailable"))
                        {
                           Messager.Show(this, "The Context Management Server was terminated.  The application can no longer access the context and will restart to attempt to rejoin the context.",
                                          MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
                            Close();
                            CCOWUtils.Restart();
                        }
                        else
                        {
                            if(old!=null && old.Message!=exception.Message)
                                Messager.ShowError(null, exception);
                            if (_Context.Joined)
                            {
                                try
                                {
                                    ShowContext();
                                }
                                catch (Exception ex)
                                {
                                    Messager.ShowError(null, ex.Message);
                                }
                            }
                        }
                    }
                    else
                        Messager.ShowError(null, exception);
                }
            }
            else
            {
                Messager.ShowInformation(this, "A user is already logged into the application. This menu option will become available once the current user logs out.");
            }
        }        

        private void MenuItem_MouseHover(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
           if (item != null)
           {
              string name = item.Text.Replace("&",string.Empty).ToLower();
            
              //
              // No hover when menu disabled
              //
              switch (name)
              {
                 case "file":
                    textBoxHelp.Text = Resources.File;
                    break;
                 case "context":
                    textBoxHelp.Text = Resources.Context;
                    break;
                 case "join":
                    textBoxHelp.Text = Resources.Join;
                    break;
                 case "log-off all":
                    textBoxHelp.Text = Resources.LogOffAll;
                    break;
                 case "log-on":
                    textBoxHelp.Text = Resources.LogOn;
                    break;
                 case "log-off":
                    textBoxHelp.Text = Resources.LogOff;
                    break;
                 case "exit":
                    textBoxHelp.Text = Resources.Exit;
                    break;
                 case "suspend":
                    textBoxHelp.Text = Resources.Suspend;
                    break;
                 case "resume":
                    textBoxHelp.Text = Resources.Resume;
                    break;
                 default:
                    textBoxHelp.Text = string.Empty;
                    break;
              }
           }
        }

        private void SetLinkDisplay(string linkInfo)
        {
            toolStripStatusLabelLink.Text = linkInfo;
        }

        #region Logging Functions

        private delegate void LogDelegate(Color color,string format, params object[] args);

        public void Log(string format, params object[] args)
        {
            Log(Color.Empty, format, args);
        }

        public void Log(Color color,string format, params object[] args)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new LogDelegate(Log), color,format, args);
            }
            else
            {
                string message = string.Format(format, args) + "\r\n";
                int start = richTextBoxLog.TextLength;                

                if (color != Color.Empty)
                {
                    richTextBoxLog.SelectionColor = color;
                }
                richTextBoxLog.AppendText(message);
                if (color != Color.Empty)
                {
                    int end = 0;

                    end = richTextBoxLog.TextLength;
                    richTextBoxLog.Select(start, end - start);
                    richTextBoxLog.SelectionColor = color;
                    richTextBoxLog.SelectionLength = 0;                    
                }
                richTextBoxLog.SelectionStart = richTextBoxLog.TextLength;
                richTextBoxLog.ScrollToCaret();
            }
        }

        #endregion                       
    }
}
