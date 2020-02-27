namespace Leadtools.Medical.Winforms
{
   partial class ViewDatasetDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewDatasetDialog));
         this.tabPageDataset = new System.Windows.Forms.TabPage();
         this.panel2 = new System.Windows.Forms.Panel();
         this.button1 = new System.Windows.Forms.Button();
         this.tabControlDicom = new System.Windows.Forms.TabControl();
         this.tabPageImages = new System.Windows.Forms.TabPage();
         this.labelLoadInfo = new System.Windows.Forms.Label();
         this.progressBarLoad = new System.Windows.Forms.ProgressBar();
         this.panel2.SuspendLayout();
         this.tabControlDicom.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabPageDataset
         // 
         this.tabPageDataset.Location = new System.Drawing.Point(4, 22);
         this.tabPageDataset.Name = "tabPageDataset";
         this.tabPageDataset.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageDataset.Size = new System.Drawing.Size(555, 453);
         this.tabPageDataset.TabIndex = 0;
         this.tabPageDataset.Text = "Dataset";
         this.tabPageDataset.UseVisualStyleBackColor = true;
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
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(476, 14);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 0;
         this.button1.Text = "OK";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // tabControlDicom
         // 
         this.tabControlDicom.Controls.Add(this.tabPageDataset);
         this.tabControlDicom.Controls.Add(this.tabPageImages);
         this.tabControlDicom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControlDicom.Location = new System.Drawing.Point(0, 0);
         this.tabControlDicom.Name = "tabControlDicom";
         this.tabControlDicom.SelectedIndex = 0;
         this.tabControlDicom.Size = new System.Drawing.Size(563, 479);
         this.tabControlDicom.TabIndex = 3;
         this.tabControlDicom.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlDicom_Selected);
         // 
         // tabPageImages
         // 
         this.tabPageImages.Location = new System.Drawing.Point(4, 22);
         this.tabPageImages.Name = "tabPageImages";
         this.tabPageImages.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageImages.Size = new System.Drawing.Size(555, 453);
         this.tabPageImages.TabIndex = 1;
         this.tabPageImages.Text = "Image";
         this.tabPageImages.UseVisualStyleBackColor = true;
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
         // progressBarLoad
         // 
         this.progressBarLoad.Location = new System.Drawing.Point(95, 13);
         this.progressBarLoad.Name = "progressBarLoad";
         this.progressBarLoad.Size = new System.Drawing.Size(375, 23);
         this.progressBarLoad.TabIndex = 2;
         this.progressBarLoad.Visible = false;
         // 
         // ViewDatasetDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(563, 528);
         this.Controls.Add(this.tabControlDicom);
         this.Controls.Add(this.panel2);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ViewDatasetDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "View DICOM Dataset";
         this.Shown += new System.EventHandler(this.ViewDatasetDialog_Shown);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewDatasetDialog_FormClosing);
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.tabControlDicom.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TabControl tabControlDicom;
      private System.Windows.Forms.TabPage tabPageImages;
      private System.Windows.Forms.TabPage tabPageDataset;
      private System.Windows.Forms.ProgressBar progressBarLoad;
      private System.Windows.Forms.Label labelLoadInfo;

   }
}