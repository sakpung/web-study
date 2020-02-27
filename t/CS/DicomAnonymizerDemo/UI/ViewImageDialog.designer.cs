namespace DicomAnonymizer
{
   partial class ViewImageDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewImageDialog));
         this.panel2 = new System.Windows.Forms.Panel();
         this.progressBarLoad = new System.Windows.Forms.ProgressBar();
         this.labelLoadInfo = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.panelViewer = new System.Windows.Forms.Panel();
         this.panel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.progressBarLoad);
         this.panel2.Controls.Add(this.labelLoadInfo);
         this.panel2.Controls.Add(this.button1);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel2.Location = new System.Drawing.Point(0, 479);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(563, 49);
         this.panel2.TabIndex = 1;
         // 
         // progressBarLoad
         // 
         this.progressBarLoad.Location = new System.Drawing.Point(95, 13);
         this.progressBarLoad.Name = "progressBarLoad";
         this.progressBarLoad.Size = new System.Drawing.Size(375, 23);
         this.progressBarLoad.TabIndex = 2;
         this.progressBarLoad.Visible = false;
         // 
         // labelLoadInfo
         // 
         this.labelLoadInfo.AutoSize = true;
         this.labelLoadInfo.Location = new System.Drawing.Point(4, 23);
         this.labelLoadInfo.Name = "labelLoadInfo";
         this.labelLoadInfo.Size = new System.Drawing.Size(85, 13);
         this.labelLoadInfo.TabIndex = 1;
         this.labelLoadInfo.Text = "Loading Images:";
         this.labelLoadInfo.Visible = false;
         // 
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(476, 13);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 0;
         this.button1.Text = "OK";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // panelViewer
         // 
         this.panelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelViewer.Location = new System.Drawing.Point(0, 0);
         this.panelViewer.Name = "panelViewer";
         this.panelViewer.Size = new System.Drawing.Size(563, 479);
         this.panelViewer.TabIndex = 2;
         // 
         // ViewImageDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(563, 528);
         this.Controls.Add(this.panelViewer);
         this.Controls.Add(this.panel2);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ViewImageDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Draw Blackout Rectangles";
         this.Shown += new System.EventHandler(this.ViewDatasetDialog_Shown);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewDatasetDialog_FormClosing);
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.ProgressBar progressBarLoad;
      private System.Windows.Forms.Label labelLoadInfo;
      private System.Windows.Forms.Panel panelViewer;

   }
}