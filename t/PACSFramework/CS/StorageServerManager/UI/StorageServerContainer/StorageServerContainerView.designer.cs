using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Demos.StorageServer.UI
{
   partial class StorageServerContainerView
   {
      private void InitializeComponent()
      {
         this.LeftPanel = new DoubleBufferedPanel();
         this.ContentsPanel = new DoubleBufferedPanel();
         this.TopPanel = new DoubleBufferedPanel();
         this.HeaderPanel = new DoubleBufferedPanel();
         this.LogoPictureBox = new System.Windows.Forms.PictureBox();
         this.TopPanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
         this.SuspendLayout();
         // 
         // LeftPanel
         // 
         this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
         this.LeftPanel.Location = new System.Drawing.Point(0, 128);
         this.LeftPanel.Name = "LeftPanel";
         this.LeftPanel.Size = new System.Drawing.Size(200, 478);
         this.LeftPanel.TabIndex = 1;
         // 
         // ContentsPanel
         // 
         this.ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ContentsPanel.Location = new System.Drawing.Point(200, 128);
         this.ContentsPanel.Name = "ContentsPanel";
         this.ContentsPanel.Size = new System.Drawing.Size(569, 478);
         this.ContentsPanel.TabIndex = 2;
         // 
         // TopPanel
         // 
         this.TopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this.TopPanel.Controls.Add(this.HeaderPanel);
         this.TopPanel.Controls.Add(this.LogoPictureBox);
         this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
         this.TopPanel.Location = new System.Drawing.Point(0, 0);
         this.TopPanel.Name = "TopPanel";
         this.TopPanel.Size = new System.Drawing.Size(769, 128);
         this.TopPanel.TabIndex = 0;
         // 
         // HeaderPanel
         // 
         this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.HeaderPanel.Location = new System.Drawing.Point(200, 0);
         this.HeaderPanel.Name = "HeaderPanel";
         this.HeaderPanel.Size = new System.Drawing.Size(569, 128);
         this.HeaderPanel.TabIndex = 1;
         // 
         // LogoPictureBox
         // 
         this.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
         this.LogoPictureBox.Location = new System.Drawing.Point(0, 0);
         this.LogoPictureBox.Name = "LogoPictureBox";
         this.LogoPictureBox.Size = new System.Drawing.Size(200, 128);
         this.LogoPictureBox.TabIndex = 0;
         this.LogoPictureBox.TabStop = false;
         // 
         // StorageServerContainerView
         // 
         this.BackgroundImage = global::Leadtools.Demos.StorageServer.Properties.Resources.gradient;
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.Controls.Add(this.ContentsPanel);
         this.Controls.Add(this.LeftPanel);
         this.Controls.Add(this.TopPanel);
         this.Name = "StorageServerContainerView";
         this.Size = new System.Drawing.Size(769, 606);
         this.TopPanel.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
         this.ResumeLayout(false);

      }

      private DoubleBufferedPanel TopPanel;
      private DoubleBufferedPanel LeftPanel;
      private DoubleBufferedPanel ContentsPanel;
      private DoubleBufferedPanel HeaderPanel;
      private System.Windows.Forms.PictureBox LogoPictureBox;
   }
   
}
