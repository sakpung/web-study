using System.Windows.Forms;
namespace FusionDemo
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mainMenu = new System.Windows.Forms.MenuStrip();
         this._menuFile = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemFileLoadDICOM = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemFileLoadDICOMDIR = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._menuFile_exit = new System.Windows.Forms.ToolStripMenuItem();
         this._menuEdit = new System.Windows.Forms.ToolStripMenuItem();
         this._menuAddFusion = new System.Windows.Forms.ToolStripMenuItem();
         this._menuAdjustFusion = new System.Windows.Forms.ToolStripMenuItem();
         this._menuFuseTwoCells = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._menuDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
         this._menuView = new System.Windows.Forms.ToolStripMenuItem();
         this._menuProperties = new System.Windows.Forms.ToolStripMenuItem();
         this._actionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionWindowLevel = new System.Windows.Forms.ToolStripMenuItem();
         this._manualWLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._linearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._exponentialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._logarithmicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._sigmoidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionAlpha = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionScale = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionMagnify = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionPan = new System.Windows.Forms.ToolStripMenuItem();
         this._menuActionTranslucensy = new System.Windows.Forms.ToolStripMenuItem();
         this._helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._printCellMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.nudgeToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.shrinkToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.setToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.customizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this._miEffectInvert = new System.Windows.Forms.ToolStripMenuItem();
         this._mainPanel = new System.Windows.Forms.Panel();
         this._displayPanel = new System.Windows.Forms.Panel();
         this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
         this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
         this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
         this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
         this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
         this._mainMenu.SuspendLayout();
         this._mainPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFile,
            this._menuEdit,
            this._menuView,
            this._actionsMenuItem,
            this._helpMenuItem});
         this._mainMenu.Location = new System.Drawing.Point(0, 0);
         this._mainMenu.Name = "_mainMenu";
         this._mainMenu.Size = new System.Drawing.Size(1284, 24);
         this._mainMenu.TabIndex = 1;
         this._mainMenu.Text = "_mainMenu";
         // 
         // _menuFile
         // 
         this._menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemFileLoadDICOM,
            this._menuItemFileLoadDICOMDIR,
            this.toolStripSeparator3,
            this._menuFile_exit});
         this._menuFile.Name = "_menuFile";
         this._menuFile.Size = new System.Drawing.Size(37, 20);
         this._menuFile.Text = "&File";
         // 
         // _menuItemFileLoadDICOM
         // 
         this._menuItemFileLoadDICOM.Name = "_menuItemFileLoadDICOM";
         this._menuItemFileLoadDICOM.Size = new System.Drawing.Size(169, 22);
         this._menuItemFileLoadDICOM.Text = "&Load DICOM...";
         this._menuItemFileLoadDICOM.Click += new System.EventHandler(this._menuItemFileLoadDICOM_Click);
         // 
         // _menuItemFileLoadDICOMDIR
         // 
         this._menuItemFileLoadDICOMDIR.Name = "_menuItemFileLoadDICOMDIR";
         this._menuItemFileLoadDICOMDIR.Size = new System.Drawing.Size(169, 22);
         this._menuItemFileLoadDICOMDIR.Text = "Load &DICOMDIR...";
         this._menuItemFileLoadDICOMDIR.Click += new System.EventHandler(this._menuItemFileLoadDICOMDIR_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(166, 6);
         // 
         // _menuFile_exit
         // 
         this._menuFile_exit.Name = "_menuFile_exit";
         this._menuFile_exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
         this._menuFile_exit.Size = new System.Drawing.Size(169, 22);
         this._menuFile_exit.Text = "&Exit";
         this._menuFile_exit.Click += new System.EventHandler(this._menuFile_exit_Click);
         // 
         // _menuEdit
         // 
         this._menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuAddFusion,
            this._menuAdjustFusion,
            this._menuFuseTwoCells,
            this.toolStripSeparator1,
            this._menuDeleteAll});
         this._menuEdit.Name = "_menuEdit";
         this._menuEdit.Size = new System.Drawing.Size(39, 20);
         this._menuEdit.Text = "&Edit";
         this._menuEdit.DropDownOpening += new System.EventHandler(this._menuEdit_DropDownOpening);
         // 
         // _menuAddFusion
         // 
         this._menuAddFusion.Name = "_menuAddFusion";
         this._menuAddFusion.Size = new System.Drawing.Size(197, 22);
         this._menuAddFusion.Text = "&Add / Remove Fusion...";
         this._menuAddFusion.Click += new System.EventHandler(this._menuAddFusion_Click);
         // 
         // _menuAdjustFusion
         // 
         this._menuAdjustFusion.Name = "_menuAdjustFusion";
         this._menuAdjustFusion.Size = new System.Drawing.Size(197, 22);
         this._menuAdjustFusion.Text = "&Adjust Fused Images...";
         this._menuAdjustFusion.Click += new System.EventHandler(this._menuAdjustFusion_Click);
         // 
         // _menuFuseTwoCells
         // 
         this._menuFuseTwoCells.Name = "_menuFuseTwoCells";
         this._menuFuseTwoCells.Size = new System.Drawing.Size(197, 22);
         this._menuFuseTwoCells.Text = "Fuse Two Cells";
         this._menuFuseTwoCells.Click += new System.EventHandler(this._menuFuseTwoCells_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
         // 
         // _menuDeleteAll
         // 
         this._menuDeleteAll.Name = "_menuDeleteAll";
         this._menuDeleteAll.Size = new System.Drawing.Size(197, 22);
         this._menuDeleteAll.Text = "&Delete All";
         this._menuDeleteAll.Click += new System.EventHandler(this._menuDeleteAll_Click);
         // 
         // _menuView
         // 
         this._menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuProperties});
         this._menuView.Name = "_menuView";
         this._menuView.Size = new System.Drawing.Size(44, 20);
         this._menuView.Text = "&View";
         // 
         // _menuProperties
         // 
         this._menuProperties.Name = "_menuProperties";
         this._menuProperties.Size = new System.Drawing.Size(136, 22);
         this._menuProperties.Text = "&Properties...";
         this._menuProperties.Click += new System.EventHandler(this._menuProperties_Click);
         // 
         // _actionsMenuItem
         // 
         this._actionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuActionWindowLevel,
            this._menuActionAlpha,
            this._menuActionScale,
            this._menuActionMagnify,
            this._menuActionPan,
            this._menuActionTranslucensy});
         this._actionsMenuItem.Name = "_actionsMenuItem";
         this._actionsMenuItem.Size = new System.Drawing.Size(59, 20);
         this._actionsMenuItem.Text = "&Actions";
         this._actionsMenuItem.DropDownOpening += new System.EventHandler(this._actionsMenuItem_DropDownOpening);
         // 
         // _menuActionWindowLevel
         // 
         this._menuActionWindowLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._manualWLToolStripMenuItem,
            this._linearToolStripMenuItem,
            this._exponentialToolStripMenuItem,
            this._logarithmicToolStripMenuItem,
            this._sigmoidToolStripMenuItem});
         this._menuActionWindowLevel.Name = "_menuActionWindowLevel";
         this._menuActionWindowLevel.Size = new System.Drawing.Size(152, 22);
         this._menuActionWindowLevel.Text = "&Window Level";
         this._menuActionWindowLevel.Click += new System.EventHandler(this._menuActionWindowLevel_Click);
         // 
         // _manualWLToolStripMenuItem
         // 
         this._manualWLToolStripMenuItem.Name = "_manualWLToolStripMenuItem";
         this._manualWLToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
         this._manualWLToolStripMenuItem.Text = "Set W/L Manually";
         this._manualWLToolStripMenuItem.Click += new System.EventHandler(this.manualWLToolStripMenuItem_Click);
         // 
         // _linearToolStripMenuItem
         // 
         this._linearToolStripMenuItem.Name = "_linearToolStripMenuItem";
         this._linearToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
         this._linearToolStripMenuItem.Text = "Linear";
         this._linearToolStripMenuItem.Click += new System.EventHandler(this._curveTypeToolStripMenuItem_Click);
         // 
         // _exponentialToolStripMenuItem
         // 
         this._exponentialToolStripMenuItem.Name = "_exponentialToolStripMenuItem";
         this._exponentialToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
         this._exponentialToolStripMenuItem.Text = "Exponential";
         this._exponentialToolStripMenuItem.Click += new System.EventHandler(this._curveTypeToolStripMenuItem_Click);
         // 
         // _logarithmicToolStripMenuItem
         // 
         this._logarithmicToolStripMenuItem.Name = "_logarithmicToolStripMenuItem";
         this._logarithmicToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
         this._logarithmicToolStripMenuItem.Text = "Logarithmic";
         this._logarithmicToolStripMenuItem.Click += new System.EventHandler(this._curveTypeToolStripMenuItem_Click);
         // 
         // _sigmoidToolStripMenuItem
         // 
         this._sigmoidToolStripMenuItem.Name = "_sigmoidToolStripMenuItem";
         this._sigmoidToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
         this._sigmoidToolStripMenuItem.Text = "Sigmoid";
         this._sigmoidToolStripMenuItem.Click += new System.EventHandler(this._curveTypeToolStripMenuItem_Click);
         // 
         // _menuActionAlpha
         // 
         this._menuActionAlpha.Name = "_menuActionAlpha";
         this._menuActionAlpha.Size = new System.Drawing.Size(152, 22);
         this._menuActionAlpha.Text = "&Alpha";
         this._menuActionAlpha.Click += new System.EventHandler(this._menuActionAlpha_Click);
         // 
         // _menuActionScale
         // 
         this._menuActionScale.Name = "_menuActionScale";
         this._menuActionScale.Size = new System.Drawing.Size(152, 22);
         this._menuActionScale.Text = "&Scale";
         this._menuActionScale.Click += new System.EventHandler(this._menuActionScale_Click);
         // 
         // _menuActionMagnify
         // 
         this._menuActionMagnify.Name = "_menuActionMagnify";
         this._menuActionMagnify.Size = new System.Drawing.Size(152, 22);
         this._menuActionMagnify.Text = "&Magnify";
         this._menuActionMagnify.Click += new System.EventHandler(this._menuActionMagnify_Click);
         // 
         // _menuActionPan
         // 
         this._menuActionPan.Name = "_menuActionPan";
         this._menuActionPan.Size = new System.Drawing.Size(152, 22);
         this._menuActionPan.Text = "&Pan";
         this._menuActionPan.Click += new System.EventHandler(this._menuActionPan_Click);
         // 
         // _menuActionTranslucensy
         // 
         this._menuActionTranslucensy.Name = "_menuActionTranslucensy";
         this._menuActionTranslucensy.Size = new System.Drawing.Size(152, 22);
         this._menuActionTranslucensy.Text = "&Translucency";
         this._menuActionTranslucensy.Click += new System.EventHandler(this._menuActionTranslucensy_Click);
         // 
         // _helpMenuItem
         // 
         this._helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuAbout});
         this._helpMenuItem.Name = "_helpMenuItem";
         this._helpMenuItem.Size = new System.Drawing.Size(44, 20);
         this._helpMenuItem.Text = "&Help";
         // 
         // _menuAbout
         // 
         this._menuAbout.Name = "_menuAbout";
         this._menuAbout.Size = new System.Drawing.Size(116, 22);
         this._menuAbout.Text = "&About...";
         this._menuAbout.Click += new System.EventHandler(this._menuAbout_Click);
         // 
         // _printCellMenuItem
         // 
         this._printCellMenuItem.Name = "_printCellMenuItem";
         this._printCellMenuItem.Size = new System.Drawing.Size(175, 22);
         this._printCellMenuItem.Text = "&Print Cell...";
         // 
         // nudgeToolToolStripMenuItem
         // 
         this.nudgeToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem,
            this.customizeToolStripMenuItem});
         this.nudgeToolToolStripMenuItem.Name = "nudgeToolToolStripMenuItem";
         this.nudgeToolToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.nudgeToolToolStripMenuItem.Text = "&Nudge tool";
         // 
         // setToolStripMenuItem
         // 
         this.setToolStripMenuItem.Name = "setToolStripMenuItem";
         this.setToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
         this.setToolStripMenuItem.Text = "&Set..";
         // 
         // customizeToolStripMenuItem
         // 
         this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
         this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
         this.customizeToolStripMenuItem.Text = "&Customize";
         // 
         // shrinkToolToolStripMenuItem
         // 
         this.shrinkToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem1,
            this.customizeToolStripMenuItem1});
         this.shrinkToolToolStripMenuItem.Name = "shrinkToolToolStripMenuItem";
         this.shrinkToolToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.shrinkToolToolStripMenuItem.Text = "&Shrink tool";
         // 
         // setToolStripMenuItem1
         // 
         this.setToolStripMenuItem1.Name = "setToolStripMenuItem1";
         this.setToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
         this.setToolStripMenuItem1.Text = "&Set...";
         // 
         // customizeToolStripMenuItem1
         // 
         this.customizeToolStripMenuItem1.Name = "customizeToolStripMenuItem1";
         this.customizeToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
         this.customizeToolStripMenuItem1.Text = "&Customize...";
         // 
         // _miEffectInvert
         // 
         this._miEffectInvert.Name = "_miEffectInvert";
         this._miEffectInvert.Size = new System.Drawing.Size(152, 22);
         this._miEffectInvert.Text = "&Invert";
         // 
         // _mainPanel
         // 
         this._mainPanel.Controls.Add(this._displayPanel);
         this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._mainPanel.Location = new System.Drawing.Point(0, 24);
         this._mainPanel.Name = "_mainPanel";
         this._mainPanel.Size = new System.Drawing.Size(1284, 705);
         this._mainPanel.TabIndex = 2;
         this._mainPanel.SizeChanged += new System.EventHandler(this._mainPanel_SizeChanged);
         // 
         // _displayPanel
         // 
         this._displayPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this._displayPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._displayPanel.Location = new System.Drawing.Point(3, 3);
         this._displayPanel.Name = "_displayPanel";
         this._displayPanel.Size = new System.Drawing.Size(1278, 699);
         this._displayPanel.TabIndex = 13;
         // 
         // BottomToolStripPanel
         // 
         this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
         this.BottomToolStripPanel.Name = "BottomToolStripPanel";
         this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
         this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
         this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
         // 
         // TopToolStripPanel
         // 
         this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
         this.TopToolStripPanel.Name = "TopToolStripPanel";
         this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
         this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
         this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
         // 
         // RightToolStripPanel
         // 
         this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
         this.RightToolStripPanel.Name = "RightToolStripPanel";
         this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
         this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
         this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
         // 
         // LeftToolStripPanel
         // 
         this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
         this.LeftToolStripPanel.Name = "LeftToolStripPanel";
         this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
         this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
         this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
         // 
         // ContentPanel
         // 
         this.ContentPanel.Size = new System.Drawing.Size(339, 243);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1284, 729);
         this.Controls.Add(this._mainPanel);
         this.Controls.Add(this._mainMenu);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._mainMenu;
         this.Name = "MainForm";
         this.Text = "Fusion Demo";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this._mainMenu.ResumeLayout(false);
         this._mainMenu.PerformLayout();
         this._mainPanel.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }


      #endregion

      private System.Windows.Forms.MenuStrip _mainMenu;
       private System.Windows.Forms.ToolStripMenuItem _menuFile;
      private System.Windows.Forms.ToolStripMenuItem _menuEdit;
       private System.Windows.Forms.ToolStripMenuItem _helpMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _menuFile_exit;
       private System.Windows.Forms.Panel _mainPanel;
       private System.Windows.Forms.ToolStripMenuItem _miEffectInvert;
      private System.Windows.Forms.ToolStripMenuItem _printCellMenuItem;
      private System.Windows.Forms.ToolStripMenuItem nudgeToolToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem shrinkToolToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem1;
       private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem1;
       private System.Windows.Forms.ToolStripMenuItem _menuItemFileLoadDICOM;
       private System.Windows.Forms.ToolStripMenuItem _menuItemFileLoadDICOMDIR;
       private System.Windows.Forms.ToolStripMenuItem _menuAbout;
       private System.Windows.Forms.Panel _displayPanel;
       private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
       private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
       private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
       private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
       private System.Windows.Forms.ToolStripContentPanel ContentPanel;
      private System.Windows.Forms.ToolStripMenuItem _actionsMenuItem;
       private System.Windows.Forms.ToolStripMenuItem _menuActionWindowLevel;
       private System.Windows.Forms.ToolStripMenuItem _menuActionAlpha;
       private System.Windows.Forms.ToolStripMenuItem _menuActionScale;
       private System.Windows.Forms.ToolStripMenuItem _menuActionMagnify;
       private System.Windows.Forms.ToolStripMenuItem _menuActionPan;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private ToolStripMenuItem _menuView;
       private ToolStripMenuItem _menuDeleteAll;
       private ToolStripMenuItem _menuAddFusion;
       private ToolStripMenuItem _menuAdjustFusion;
       private ToolStripSeparator toolStripSeparator1;
       private ToolStripMenuItem _menuProperties;
       private ToolStripMenuItem _menuFuseTwoCells;
       private ToolStripMenuItem _menuActionTranslucensy;
      private ToolStripMenuItem _manualWLToolStripMenuItem;
      private ToolStripMenuItem _linearToolStripMenuItem;
      private ToolStripMenuItem _exponentialToolStripMenuItem;
      private ToolStripMenuItem _logarithmicToolStripMenuItem;
      private ToolStripMenuItem _sigmoidToolStripMenuItem;
   }
}

