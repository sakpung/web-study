namespace DicomDemo
{
    partial class MPPSDatasetEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MPPSDatasetEditor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.treeViewDataset = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.treeViewMPPSDataset = new System.Windows.Forms.TreeView();
            this.imageListMPPSDataset = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 481);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 46);
            this.panel1.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(408, 10);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(489, 11);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // treeViewDataset
            // 
            this.treeViewDataset.CheckBoxes = true;
            this.treeViewDataset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDataset.FullRowSelect = true;
            this.treeViewDataset.Location = new System.Drawing.Point(0, 13);
            this.treeViewDataset.Name = "treeViewDataset";
            this.treeViewDataset.Size = new System.Drawing.Size(576, 247);
            this.treeViewDataset.TabIndex = 1;
            this.treeViewDataset.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDataset_AfterCheck);
            this.treeViewDataset.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDataset_AfterSelect);
            this.treeViewDataset.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewDataset_BeforeCheck);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewDataset);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeViewMPPSDataset);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(576, 481);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dataset Options:";
            // 
            // treeViewMPPSDataset
            // 
            this.treeViewMPPSDataset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMPPSDataset.FullRowSelect = true;
            this.treeViewMPPSDataset.HideSelection = false;
            this.treeViewMPPSDataset.ImageIndex = 0;
            this.treeViewMPPSDataset.ImageList = this.imageListMPPSDataset;
            this.treeViewMPPSDataset.Location = new System.Drawing.Point(0, 13);
            this.treeViewMPPSDataset.Name = "treeViewMPPSDataset";
            this.treeViewMPPSDataset.SelectedImageIndex = 0;
            this.treeViewMPPSDataset.Size = new System.Drawing.Size(576, 204);
            this.treeViewMPPSDataset.TabIndex = 1;
            // 
            // imageListMPPSDataset
            // 
            this.imageListMPPSDataset.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMPPSDataset.ImageStream")));
            this.imageListMPPSDataset.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMPPSDataset.Images.SetKeyName(0, "");
            this.imageListMPPSDataset.Images.SetKeyName(1, "");
            this.imageListMPPSDataset.Images.SetKeyName(2, "");
            this.imageListMPPSDataset.Images.SetKeyName(3, "");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "MPPS Dataset:";
            // 
            // MPPSDatasetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 527);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MPPSDatasetEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MPPS DICOM Dataset Editor";
            this.Load += new System.EventHandler(this.MPPSDatasetEditor_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TreeView treeViewDataset;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeViewMPPSDataset;
        private System.Windows.Forms.ImageList imageListMPPSDataset;
    }
}