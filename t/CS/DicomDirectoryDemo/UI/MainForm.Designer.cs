namespace DicomDemo
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.chkRejectInvalidFileIds = new System.Windows.Forms.CheckBox();
         this.btnSave = new System.Windows.Forms.Button();
         this.btnLoad = new System.Windows.Forms.Button();
         this.btnInsert = new System.Windows.Forms.Button();
         this.txtDirectory = new System.Windows.Forms.TextBox();
         this.chkInsertIconImageSequence = new System.Windows.Forms.CheckBox();
         this.btnCreate = new System.Windows.Forms.Button();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.txtElementValue = new System.Windows.Forms.TextBox();
         this.trvDicomDir = new System.Windows.Forms.TreeView();
         this.txtStatus = new System.Windows.Forms.TextBox();
         this.btnCancel = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(352, 166);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(6, 118);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(340, 45);
         this.label3.TabIndex = 2;
         this.label3.Text = "- If you double click the Referenced File ID element, which goes under the IMAGE " +
    "key, you will be able to see a preview for the Pixel Data element of the referen" +
    "ced DICOM file.";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(6, 61);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(340, 57);
         this.label2.TabIndex = 1;
         this.label2.Text = resources.GetString("label2.Text");
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(6, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(340, 45);
         this.label1.TabIndex = 0;
         this.label1.Text = resources.GetString("label1.Text");
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.btnCancel);
         this.groupBox2.Controls.Add(this.chkRejectInvalidFileIds);
         this.groupBox2.Controls.Add(this.btnSave);
         this.groupBox2.Controls.Add(this.btnLoad);
         this.groupBox2.Controls.Add(this.btnInsert);
         this.groupBox2.Controls.Add(this.txtDirectory);
         this.groupBox2.Controls.Add(this.chkInsertIconImageSequence);
         this.groupBox2.Controls.Add(this.btnCreate);
         this.groupBox2.Location = new System.Drawing.Point(12, 184);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(352, 126);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Selected Directory";
         // 
         // chkRejectInvalidFileIds
         // 
         this.chkRejectInvalidFileIds.AutoSize = true;
         this.chkRejectInvalidFileIds.Location = new System.Drawing.Point(9, 101);
         this.chkRejectInvalidFileIds.Name = "chkRejectInvalidFileIds";
         this.chkRejectInvalidFileIds.Size = new System.Drawing.Size(127, 17);
         this.chkRejectInvalidFileIds.TabIndex = 6;
         this.chkRejectInvalidFileIds.Text = "Reject Invalid File Ids";
         this.chkRejectInvalidFileIds.UseVisualStyleBackColor = true;
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(269, 20);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(75, 23);
         this.btnSave.TabIndex = 3;
         this.btnSave.Text = "Save";
         this.btnSave.UseVisualStyleBackColor = true;
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // btnLoad
         // 
         this.btnLoad.Location = new System.Drawing.Point(186, 20);
         this.btnLoad.Name = "btnLoad";
         this.btnLoad.Size = new System.Drawing.Size(75, 23);
         this.btnLoad.TabIndex = 2;
         this.btnLoad.Text = "Load";
         this.btnLoad.UseVisualStyleBackColor = true;
         this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
         // 
         // btnInsert
         // 
         this.btnInsert.Location = new System.Drawing.Point(79, 20);
         this.btnInsert.Name = "btnInsert";
         this.btnInsert.Size = new System.Drawing.Size(99, 23);
         this.btnInsert.TabIndex = 1;
         this.btnInsert.Text = "Insert Single File";
         this.btnInsert.UseVisualStyleBackColor = true;
         this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
         // 
         // txtDirectory
         // 
         this.txtDirectory.Location = new System.Drawing.Point(9, 75);
         this.txtDirectory.Name = "txtDirectory";
         this.txtDirectory.ReadOnly = true;
         this.txtDirectory.Size = new System.Drawing.Size(337, 20);
         this.txtDirectory.TabIndex = 5;
         // 
         // chkInsertIconImageSequence
         // 
         this.chkInsertIconImageSequence.AutoSize = true;
         this.chkInsertIconImageSequence.Location = new System.Drawing.Point(175, 101);
         this.chkInsertIconImageSequence.Name = "chkInsertIconImageSequence";
         this.chkInsertIconImageSequence.Size = new System.Drawing.Size(160, 17);
         this.chkInsertIconImageSequence.TabIndex = 7;
         this.chkInsertIconImageSequence.Text = "Insert Icon Image Sequence";
         this.chkInsertIconImageSequence.UseVisualStyleBackColor = true;
         // 
         // btnCreate
         // 
         this.btnCreate.Location = new System.Drawing.Point(9, 20);
         this.btnCreate.Name = "btnCreate";
         this.btnCreate.Size = new System.Drawing.Size(62, 23);
         this.btnCreate.TabIndex = 0;
         this.btnCreate.Text = "Create";
         this.btnCreate.UseVisualStyleBackColor = true;
         this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.txtElementValue);
         this.groupBox3.Location = new System.Drawing.Point(12, 316);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(352, 197);
         this.groupBox3.TabIndex = 2;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Element Value:";
         // 
         // txtElementValue
         // 
         this.txtElementValue.Location = new System.Drawing.Point(6, 19);
         this.txtElementValue.Multiline = true;
         this.txtElementValue.Name = "txtElementValue";
         this.txtElementValue.ReadOnly = true;
         this.txtElementValue.Size = new System.Drawing.Size(340, 172);
         this.txtElementValue.TabIndex = 0;
         // 
         // trvDicomDir
         // 
         this.trvDicomDir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.trvDicomDir.Location = new System.Drawing.Point(370, 12);
         this.trvDicomDir.Name = "trvDicomDir";
         this.trvDicomDir.Size = new System.Drawing.Size(383, 501);
         this.trvDicomDir.TabIndex = 4;
         this.trvDicomDir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDicomDir_AfterSelect);
         this.trvDicomDir.DoubleClick += new System.EventHandler(this.trvDicomDir_DoubleClick);
         // 
         // txtStatus
         // 
         this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtStatus.Location = new System.Drawing.Point(12, 519);
         this.txtStatus.Multiline = true;
         this.txtStatus.Name = "txtStatus";
         this.txtStatus.ReadOnly = true;
         this.txtStatus.Size = new System.Drawing.Size(741, 54);
         this.txtStatus.TabIndex = 3;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(269, 48);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 4;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(765, 585);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.txtStatus);
         this.Controls.Add(this.trvDicomDir);
         this.Controls.Add(this.groupBox1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.Text = "Dicom Directory Demo - C#";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView trvDicomDir;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.CheckBox chkInsertIconImageSequence;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtElementValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkRejectInvalidFileIds;
        private System.Windows.Forms.Button btnCancel;
    }
}