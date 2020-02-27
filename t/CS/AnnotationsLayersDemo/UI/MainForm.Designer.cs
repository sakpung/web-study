namespace AnnotationsLayersDemo
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
            CleanUp(disposing);
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
         this._tbAnnotationsPage = new System.Windows.Forms.TabPage();
         this._tvLayers = new CheckBoxTreeView();
         this._mainMenu = new System.Windows.Forms.MenuStrip();
         this._miFile = new System.Windows.Forms.ToolStripMenuItem();
         this._miFileLoad = new System.Windows.Forms.ToolStripMenuItem();
         this._miFileSave = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._mainMenu.SuspendLayout();
         this.SuspendLayout();
         // 
         // _tbAnnotationsPage
         // 
         this._tbAnnotationsPage.Location = new System.Drawing.Point(0, 0);
         this._tbAnnotationsPage.Name = "_tbAnnotationsPage";
         this._tbAnnotationsPage.Size = new System.Drawing.Size(200, 100);
         this._tbAnnotationsPage.TabIndex = 0;
         // 
         // _tvLayers
         // 
         this._tvLayers.Dock = System.Windows.Forms.DockStyle.Left;
         this._tvLayers.Location = new System.Drawing.Point(0, 24);
         this._tvLayers.Name = "_tvLayers";
         this._tvLayers.Size = new System.Drawing.Size(181, 497);
         this._tvLayers.TabIndex = 1;
         this._tvLayers.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this._tvLayers_AfterCheck);
         this._tvLayers.MouseUp += new System.Windows.Forms.MouseEventHandler(this._tvLayers_MouseUp);
         this._tvLayers.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._tvLayers_NodeMouseClick);
         // 
         // _mainMenu
         // 
         this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFile,
            this._miHelp});
         this._mainMenu.Location = new System.Drawing.Point(0, 0);
         this._mainMenu.Name = "_mainMenu";
         this._mainMenu.Size = new System.Drawing.Size(850, 24);
         this._mainMenu.TabIndex = 2;
         this._mainMenu.Text = "_mainMenu";
         // 
         // _miFile
         // 
         this._miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFileLoad,
            this._miFileSave});
         this._miFile.Name = "_miFile";
         this._miFile.Size = new System.Drawing.Size(37, 20);
         this._miFile.Text = "&File";
         // 
         // _miFileLoad
         // 
         this._miFileLoad.Name = "_miFileLoad";
         this._miFileLoad.Size = new System.Drawing.Size(168, 22);
         this._miFileLoad.Text = "Load Annotations";
         this._miFileLoad.Click += new System.EventHandler(this._miLoad_Click);
         // 
         // _miFileSave
         // 
         this._miFileSave.Name = "_miFileSave";
         this._miFileSave.Size = new System.Drawing.Size(168, 22);
         this._miFileSave.Text = "Save Annotations";
         this._miFileSave.Click += new System.EventHandler(this._miSave_Click);
         // 
         // _miHelp
         // 
         this._miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miHelpAbout});
         this._miHelp.Name = "_miHelp";
         this._miHelp.Size = new System.Drawing.Size(44, 20);
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Name = "_miHelpAbout";
         this._miHelpAbout.Size = new System.Drawing.Size(107, 22);
         this._miHelpAbout.Text = "&About";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(850, 521);
         this.Controls.Add(this._tvLayers);
         this.Controls.Add(this._mainMenu);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Form1";
         this._mainMenu.ResumeLayout(false);
         this._mainMenu.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TabPage _tbAnnotationsPage;
      private System.Windows.Forms.TreeView _tvLayers;
      private System.Windows.Forms.MenuStrip _mainMenu;
      private System.Windows.Forms.ToolStripMenuItem _miFile;
      private System.Windows.Forms.ToolStripMenuItem _miFileLoad;
      private System.Windows.Forms.ToolStripMenuItem _miFileSave;
      private System.Windows.Forms.ToolStripMenuItem _miHelp;
      private System.Windows.Forms.ToolStripMenuItem _miHelpAbout;
   }
}

