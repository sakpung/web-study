using ScintillaNET;
namespace Leadtools.Medical.Rules.AddIn.Controls
{
   partial class DetachedEditorDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetachedEditorDialog));
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButtonCut = new System.Windows.Forms.ToolStripButton();
         this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
         this.toolStripButtonPaste = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
         this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripTextSearch = new ScintillaNET.ToolStripIncrementalSearcher();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButtonCheck = new System.Windows.Forms.ToolStripButton();
         this.panelEditor = new System.Windows.Forms.Panel();
         this.panel2 = new System.Windows.Forms.Panel();
         this.labelParameters = new System.Windows.Forms.Label();
         this.toolStrip1.SuspendLayout();
         this.panel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // toolStrip1
         // 
         this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonClose,
            this.toolStripSeparator5,
            this.toolStripButtonPrint,
            this.toolStripSeparator2,
            this.toolStripButtonCut,
            this.toolStripButtonCopy,
            this.toolStripButtonPaste,
            this.toolStripSeparator1,
            this.toolStripButtonUndo,
            this.toolStripButtonRedo,
            this.toolStripSeparator3,
            this.toolStripTextSearch,
            this.toolStripSeparator4,
            this.toolStripButtonCheck});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(746, 27);
         this.toolStrip1.TabIndex = 2;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripButtonClose
         // 
         this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonClose.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.Reattach;
         this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonClose.Name = "toolStripButtonClose";
         this.toolStripButtonClose.Size = new System.Drawing.Size(23, 24);
         this.toolStripButtonClose.Text = "Expand editor";
         this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
         // 
         // toolStripSeparator5
         // 
         this.toolStripSeparator5.Name = "toolStripSeparator5";
         this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
         // 
         // toolStripButtonPrint
         // 
         this.toolStripButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrint.Image")));
         this.toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonPrint.Name = "toolStripButtonPrint";
         this.toolStripButtonPrint.Size = new System.Drawing.Size(23, 24);
         this.toolStripButtonPrint.Text = "Print";
         this.toolStripButtonPrint.Click += new System.EventHandler(this.toolStripButtonPrint_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
         // 
         // toolStripButtonCut
         // 
         this.toolStripButtonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonCut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCut.Image")));
         this.toolStripButtonCut.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonCut.Name = "toolStripButtonCut";
         this.toolStripButtonCut.Size = new System.Drawing.Size(23, 24);
         this.toolStripButtonCut.Text = "toolStripButtonCut";
         this.toolStripButtonCut.Click += new System.EventHandler(this.toolStripButtonCut_Click);
         // 
         // toolStripButtonCopy
         // 
         this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopy.Image")));
         this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonCopy.Name = "toolStripButtonCopy";
         this.toolStripButtonCopy.Size = new System.Drawing.Size(23, 24);
         this.toolStripButtonCopy.Text = "toolStripButtonCopy";
         this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
         // 
         // toolStripButtonPaste
         // 
         this.toolStripButtonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPaste.Image")));
         this.toolStripButtonPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonPaste.Name = "toolStripButtonPaste";
         this.toolStripButtonPaste.Size = new System.Drawing.Size(23, 24);
         this.toolStripButtonPaste.Text = "toolStripButton";
         this.toolStripButtonPaste.Click += new System.EventHandler(this.toolStripButtonPaste_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
         // 
         // toolStripButtonUndo
         // 
         this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUndo.Image")));
         this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonUndo.Name = "toolStripButtonUndo";
         this.toolStripButtonUndo.Size = new System.Drawing.Size(23, 24);
         this.toolStripButtonUndo.Text = "toolStripButton4";
         this.toolStripButtonUndo.Click += new System.EventHandler(this.toolStripButtonUndo_Click);
         // 
         // toolStripButtonRedo
         // 
         this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRedo.Image")));
         this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonRedo.Name = "toolStripButtonRedo";
         this.toolStripButtonRedo.Size = new System.Drawing.Size(23, 24);
         this.toolStripButtonRedo.Text = "toolStripButton5";
         this.toolStripButtonRedo.Click += new System.EventHandler(this.toolStripButtonRedo_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
         // 
         // toolStripTextSearch
         // 
         this.toolStripTextSearch.BackColor = System.Drawing.Color.Transparent;
         this.toolStripTextSearch.Name = "toolStripTextSearch";
         this.toolStripTextSearch.Scintilla = null;
         this.toolStripTextSearch.Size = new System.Drawing.Size(262, 24);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
         // 
         // toolStripButtonCheck
         // 
         this.toolStripButtonCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonCheck.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.Compile;
         this.toolStripButtonCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonCheck.Name = "toolStripButtonCheck";
         this.toolStripButtonCheck.Size = new System.Drawing.Size(23, 24);
         this.toolStripButtonCheck.Text = "toolStripButton1";
         this.toolStripButtonCheck.ToolTipText = "Syntax check";
         this.toolStripButtonCheck.Click += new System.EventHandler(this.toolStripButtonCheck_Click);
         // 
         // panelEditor
         // 
         this.panelEditor.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelEditor.Location = new System.Drawing.Point(0, 27);
         this.panelEditor.Name = "panelEditor";
         this.panelEditor.Size = new System.Drawing.Size(746, 551);
         this.panelEditor.TabIndex = 3;
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.labelParameters);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel2.Location = new System.Drawing.Point(0, 578);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(746, 36);
         this.panel2.TabIndex = 4;
         // 
         // labelParameters
         // 
         this.labelParameters.Dock = System.Windows.Forms.DockStyle.Fill;
         this.labelParameters.ForeColor = System.Drawing.Color.Red;
         this.labelParameters.Location = new System.Drawing.Point(0, 0);
         this.labelParameters.Name = "labelParameters";
         this.labelParameters.Size = new System.Drawing.Size(746, 36);
         this.labelParameters.TabIndex = 0;
         // 
         // DetachedEditorDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(746, 614);
         this.Controls.Add(this.panelEditor);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.toolStrip1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "DetachedEditorDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "DetachedEditorDialog";
         this.Load += new System.EventHandler(this.DetachedEditorDialog_Load);
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.panel2.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton toolStripButtonClose;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private System.Windows.Forms.ToolStripButton toolStripButtonPrint;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton toolStripButtonCut;
      private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
      private System.Windows.Forms.ToolStripButton toolStripButtonPaste;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
      private System.Windows.Forms.ToolStripButton toolStripButtonRedo;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton toolStripButtonCheck;
      private System.Windows.Forms.Panel panelEditor;
      private ToolStripIncrementalSearcher toolStripTextSearch;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Label labelParameters;

   }
}