namespace OmrProcessingDemo.UI
{
   partial class KeyPanel
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.pnlThumbnail = new System.Windows.Forms.Panel();
         this.grpSelectSource = new System.Windows.Forms.GroupBox();
         this.lblPassingGrade = new System.Windows.Forms.Label();
         this.txtScanPath = new System.Windows.Forms.TextBox();
         this.nudPassingGrade = new System.Windows.Forms.NumericUpDown();
         this.rdBtnFile = new System.Windows.Forms.RadioButton();
         this.txtFilePath = new System.Windows.Forms.TextBox();
         this.btnBrowse = new System.Windows.Forms.Button();
         this.btnScan = new System.Windows.Forms.Button();
         this.rdbtnTwain = new System.Windows.Forms.RadioButton();
         this.chkUseKey = new System.Windows.Forms.CheckBox();
         this.label2 = new System.Windows.Forms.Label();
         this.grpSelectSource.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.nudPassingGrade)).BeginInit();
         this.SuspendLayout();
         // 
         // pnlThumbnail
         // 
         this.pnlThumbnail.BackColor = System.Drawing.SystemColors.ControlDark;
         this.pnlThumbnail.Location = new System.Drawing.Point(445, 0);
         this.pnlThumbnail.Name = "pnlThumbnail";
         this.pnlThumbnail.Size = new System.Drawing.Size(169, 195);
         this.pnlThumbnail.TabIndex = 24;
         // 
         // grpSelectSource
         // 
         this.grpSelectSource.Controls.Add(this.lblPassingGrade);
         this.grpSelectSource.Controls.Add(this.txtScanPath);
         this.grpSelectSource.Controls.Add(this.nudPassingGrade);
         this.grpSelectSource.Controls.Add(this.chkUseKey);
         this.grpSelectSource.Controls.Add(this.rdBtnFile);
         this.grpSelectSource.Controls.Add(this.txtFilePath);
         this.grpSelectSource.Controls.Add(this.btnBrowse);
         this.grpSelectSource.Controls.Add(this.btnScan);
         this.grpSelectSource.Controls.Add(this.rdbtnTwain);
         this.grpSelectSource.Location = new System.Drawing.Point(4, 39);
         this.grpSelectSource.Name = "grpSelectSource";
         this.grpSelectSource.Size = new System.Drawing.Size(435, 156);
         this.grpSelectSource.TabIndex = 25;
         this.grpSelectSource.TabStop = false;
         this.grpSelectSource.Text = "Choose Answer Key";
         // 
         // lblPassingGrade
         // 
         this.lblPassingGrade.AutoSize = true;
         this.lblPassingGrade.Location = new System.Drawing.Point(7, 26);
         this.lblPassingGrade.Name = "lblPassingGrade";
         this.lblPassingGrade.Size = new System.Drawing.Size(79, 13);
         this.lblPassingGrade.TabIndex = 24;
         this.lblPassingGrade.Text = "Passing Grade:";
         // 
         // txtScanPath
         // 
         this.txtScanPath.Location = new System.Drawing.Point(109, 128);
         this.txtScanPath.Name = "txtScanPath";
         this.txtScanPath.Size = new System.Drawing.Size(229, 20);
         this.txtScanPath.TabIndex = 23;
         // 
         // nudPassingGrade
         // 
         this.nudPassingGrade.Location = new System.Drawing.Point(92, 24);
         this.nudPassingGrade.Name = "nudPassingGrade";
         this.nudPassingGrade.Size = new System.Drawing.Size(47, 20);
         this.nudPassingGrade.TabIndex = 4;
         this.nudPassingGrade.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
         // 
         // rdBtnFile
         // 
         this.rdBtnFile.AutoSize = true;
         this.rdBtnFile.Location = new System.Drawing.Point(6, 54);
         this.rdBtnFile.Name = "rdBtnFile";
         this.rdBtnFile.Size = new System.Drawing.Size(133, 17);
         this.rdBtnFile.TabIndex = 0;
         this.rdBtnFile.TabStop = true;
         this.rdBtnFile.Text = "Load From File on Disk";
         this.rdBtnFile.UseVisualStyleBackColor = true;
         this.rdBtnFile.CheckedChanged += new System.EventHandler(this.rdBtnToggled);
         // 
         // txtFilePath
         // 
         this.txtFilePath.Location = new System.Drawing.Point(28, 77);
         this.txtFilePath.Name = "txtFilePath";
         this.txtFilePath.Size = new System.Drawing.Size(310, 20);
         this.txtFilePath.TabIndex = 4;
         // 
         // btnBrowse
         // 
         this.btnBrowse.Location = new System.Drawing.Point(344, 77);
         this.btnBrowse.Name = "btnBrowse";
         this.btnBrowse.Size = new System.Drawing.Size(75, 23);
         this.btnBrowse.TabIndex = 5;
         this.btnBrowse.Text = "Browse";
         this.btnBrowse.UseVisualStyleBackColor = true;
         this.btnBrowse.Click += new System.EventHandler(this.btnImageFileBrowse_Click);
         // 
         // btnScan
         // 
         this.btnScan.Location = new System.Drawing.Point(28, 126);
         this.btnScan.Name = "btnScan";
         this.btnScan.Size = new System.Drawing.Size(75, 23);
         this.btnScan.TabIndex = 7;
         this.btnScan.Text = "Scan";
         this.btnScan.UseVisualStyleBackColor = true;
         this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
         // 
         // rdbtnTwain
         // 
         this.rdbtnTwain.AutoSize = true;
         this.rdbtnTwain.Location = new System.Drawing.Point(6, 103);
         this.rdbtnTwain.Name = "rdbtnTwain";
         this.rdbtnTwain.Size = new System.Drawing.Size(111, 17);
         this.rdbtnTwain.TabIndex = 18;
         this.rdbtnTwain.TabStop = true;
         this.rdbtnTwain.Text = "Get From Scanner";
         this.rdbtnTwain.UseVisualStyleBackColor = true;
         this.rdbtnTwain.CheckedChanged += new System.EventHandler(this.rdBtnToggled);
         // 
         // chkUseKey
         // 
         this.chkUseKey.AutoSize = true;
         this.chkUseKey.Checked = true;
         this.chkUseKey.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkUseKey.Location = new System.Drawing.Point(6, 0);
         this.chkUseKey.Name = "chkUseKey";
         this.chkUseKey.Size = new System.Drawing.Size(104, 17);
         this.chkUseKey.TabIndex = 22;
         this.chkUseKey.Text = "Use Answer Key";
         this.chkUseKey.UseVisualStyleBackColor = true;
         this.chkUseKey.CheckedChanged += new System.EventHandler(this.chkUseKey_CheckedChanged);
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(7, 8);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(432, 28);
         this.label2.TabIndex = 26;
         this.label2.Text = "Answer keys are generally used when processing exams or worksheets, but usually a" +
    "ren\'t necessary when processing surveys and questionnaires.";
         // 
         // KeyPanel
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.label2);
         this.Controls.Add(this.grpSelectSource);
         this.Controls.Add(this.pnlThumbnail);
         this.Name = "KeyPanel";
         this.Size = new System.Drawing.Size(617, 198);
         this.grpSelectSource.ResumeLayout(false);
         this.grpSelectSource.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.nudPassingGrade)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel pnlThumbnail;
      private System.Windows.Forms.GroupBox grpSelectSource;
      private System.Windows.Forms.CheckBox chkUseKey;
      private System.Windows.Forms.RadioButton rdBtnFile;
      private System.Windows.Forms.TextBox txtFilePath;
      private System.Windows.Forms.Button btnBrowse;
      private System.Windows.Forms.Button btnScan;
      private System.Windows.Forms.RadioButton rdbtnTwain;
      private System.Windows.Forms.NumericUpDown nudPassingGrade;
      private System.Windows.Forms.TextBox txtScanPath;
      private System.Windows.Forms.Label lblPassingGrade;
      private System.Windows.Forms.Label label2;
   }
}
