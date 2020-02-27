namespace OmrProcessingDemo
{
   partial class NewTemplateDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTemplateDialog));
         this.BtnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.rdbtnTwain = new System.Windows.Forms.RadioButton();
         this.grpTwain = new System.Windows.Forms.GroupBox();
         this.txtScanPath = new System.Windows.Forms.TextBox();
         this.btnScan = new System.Windows.Forms.Button();
         this.grpLoad = new System.Windows.Forms.GroupBox();
         this.txtFilePath = new System.Windows.Forms.TextBox();
         this.btnBrowse = new System.Windows.Forms.Button();
         this.rdBtnFile = new System.Windows.Forms.RadioButton();
         this.pnlThumbnail = new System.Windows.Forms.Panel();
         this.lblDescription = new System.Windows.Forms.Label();
         this.txtTemplateName = new System.Windows.Forms.TextBox();
         this.btnPreviousPage = new System.Windows.Forms.Button();
         this.btnNextPage = new System.Windows.Forms.Button();
         this.lblPageIndex = new System.Windows.Forms.Label();
         this.grpTwain.SuspendLayout();
         this.grpLoad.SuspendLayout();
         this.SuspendLayout();
         // 
         // BtnOK
         // 
         this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.BtnOK.Location = new System.Drawing.Point(454, 227);
         this.BtnOK.Name = "BtnOK";
         this.BtnOK.Size = new System.Drawing.Size(71, 23);
         this.BtnOK.TabIndex = 2;
         this.BtnOK.Text = "OK";
         this.BtnOK.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(531, 227);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 3;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // rdbtnTwain
         // 
         this.rdbtnTwain.AutoSize = true;
         this.rdbtnTwain.Location = new System.Drawing.Point(24, 149);
         this.rdbtnTwain.Name = "rdbtnTwain";
         this.rdbtnTwain.Size = new System.Drawing.Size(91, 17);
         this.rdbtnTwain.TabIndex = 13;
         this.rdbtnTwain.TabStop = true;
         this.rdbtnTwain.Text = "From Scanner";
         this.rdbtnTwain.UseVisualStyleBackColor = true;
         this.rdbtnTwain.CheckedChanged += new System.EventHandler(this.rdBtnToggled);
         // 
         // grpTwain
         // 
         this.grpTwain.Controls.Add(this.txtScanPath);
         this.grpTwain.Controls.Add(this.btnScan);
         this.grpTwain.Location = new System.Drawing.Point(18, 160);
         this.grpTwain.Name = "grpTwain";
         this.grpTwain.Size = new System.Drawing.Size(430, 61);
         this.grpTwain.TabIndex = 15;
         this.grpTwain.TabStop = false;
         // 
         // txtScanPath
         // 
         this.txtScanPath.Location = new System.Drawing.Point(90, 23);
         this.txtScanPath.Name = "txtScanPath";
         this.txtScanPath.Size = new System.Drawing.Size(329, 20);
         this.txtScanPath.TabIndex = 8;
         // 
         // btnScan
         // 
         this.btnScan.Location = new System.Drawing.Point(9, 23);
         this.btnScan.Name = "btnScan";
         this.btnScan.Size = new System.Drawing.Size(75, 23);
         this.btnScan.TabIndex = 7;
         this.btnScan.Text = "Scan";
         this.btnScan.UseVisualStyleBackColor = true;
         this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
         // 
         // grpLoad
         // 
         this.grpLoad.Controls.Add(this.txtFilePath);
         this.grpLoad.Controls.Add(this.btnBrowse);
         this.grpLoad.Location = new System.Drawing.Point(18, 77);
         this.grpLoad.Name = "grpLoad";
         this.grpLoad.Size = new System.Drawing.Size(430, 66);
         this.grpLoad.TabIndex = 14;
         this.grpLoad.TabStop = false;
         // 
         // txtFilePath
         // 
         this.txtFilePath.Location = new System.Drawing.Point(9, 19);
         this.txtFilePath.Name = "txtFilePath";
         this.txtFilePath.Size = new System.Drawing.Size(329, 20);
         this.txtFilePath.TabIndex = 4;
         // 
         // btnBrowse
         // 
         this.btnBrowse.Location = new System.Drawing.Point(344, 19);
         this.btnBrowse.Name = "btnBrowse";
         this.btnBrowse.Size = new System.Drawing.Size(75, 23);
         this.btnBrowse.TabIndex = 5;
         this.btnBrowse.Text = "Browse";
         this.btnBrowse.UseVisualStyleBackColor = true;
         this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
         // 
         // rdBtnFile
         // 
         this.rdBtnFile.AutoSize = true;
         this.rdBtnFile.Location = new System.Drawing.Point(24, 64);
         this.rdBtnFile.Name = "rdBtnFile";
         this.rdBtnFile.Size = new System.Drawing.Size(80, 17);
         this.rdBtnFile.TabIndex = 0;
         this.rdBtnFile.TabStop = true;
         this.rdBtnFile.Text = "File on Disk";
         this.rdBtnFile.UseVisualStyleBackColor = true;
         this.rdBtnFile.CheckedChanged += new System.EventHandler(this.rdBtnToggled);
         // 
         // pnlThumbnail
         // 
         this.pnlThumbnail.BackColor = System.Drawing.SystemColors.ControlDark;
         this.pnlThumbnail.Location = new System.Drawing.Point(454, 12);
         this.pnlThumbnail.Name = "pnlThumbnail";
         this.pnlThumbnail.Size = new System.Drawing.Size(152, 180);
         this.pnlThumbnail.TabIndex = 25;
         // 
         // lblDescription
         // 
         this.lblDescription.AutoSize = true;
         this.lblDescription.Location = new System.Drawing.Point(24, 26);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(85, 13);
         this.lblDescription.TabIndex = 26;
         this.lblDescription.Text = "Template Name:";
         // 
         // txtTemplateName
         // 
         this.txtTemplateName.Location = new System.Drawing.Point(115, 23);
         this.txtTemplateName.Name = "txtTemplateName";
         this.txtTemplateName.Size = new System.Drawing.Size(322, 20);
         this.txtTemplateName.TabIndex = 27;
         this.txtTemplateName.TextChanged += new System.EventHandler(this.txtTemplateName_TextChanged);
         // 
         // btnPreviousPage
         // 
         this.btnPreviousPage.Enabled = false;
         this.btnPreviousPage.Location = new System.Drawing.Point(454, 198);
         this.btnPreviousPage.Name = "btnPreviousPage";
         this.btnPreviousPage.Size = new System.Drawing.Size(29, 23);
         this.btnPreviousPage.TabIndex = 28;
         this.btnPreviousPage.Text = "<<";
         this.btnPreviousPage.UseVisualStyleBackColor = true;
         this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
         // 
         // btnNextPage
         // 
         this.btnNextPage.Enabled = false;
         this.btnNextPage.Location = new System.Drawing.Point(576, 198);
         this.btnNextPage.Name = "btnNextPage";
         this.btnNextPage.Size = new System.Drawing.Size(29, 23);
         this.btnNextPage.TabIndex = 29;
         this.btnNextPage.Text = ">>";
         this.btnNextPage.UseVisualStyleBackColor = true;
         this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
         // 
         // lblPageIndex
         // 
         this.lblPageIndex.Location = new System.Drawing.Point(494, 203);
         this.lblPageIndex.Name = "lblPageIndex";
         this.lblPageIndex.Size = new System.Drawing.Size(71, 18);
         this.lblPageIndex.TabIndex = 30;
         this.lblPageIndex.Text = "Page X of Y";
         this.lblPageIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         this.lblPageIndex.Visible = false;
         // 
         // NewTemplateDialog
         // 
         this.AcceptButton = this.BtnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(618, 263);
         this.Controls.Add(this.rdbtnTwain);
         this.Controls.Add(this.lblPageIndex);
         this.Controls.Add(this.rdBtnFile);
         this.Controls.Add(this.btnNextPage);
         this.Controls.Add(this.btnPreviousPage);
         this.Controls.Add(this.txtTemplateName);
         this.Controls.Add(this.lblDescription);
         this.Controls.Add(this.pnlThumbnail);
         this.Controls.Add(this.grpTwain);
         this.Controls.Add(this.grpLoad);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.BtnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "NewTemplateDialog";
         this.ShowInTaskbar = false;
         this.Text = "Create New Template";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GetNewImageDialog_FormClosing);
         this.grpTwain.ResumeLayout(false);
         this.grpTwain.PerformLayout();
         this.grpLoad.ResumeLayout(false);
         this.grpLoad.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button BtnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.RadioButton rdbtnTwain;
      private System.Windows.Forms.GroupBox grpTwain;
      private System.Windows.Forms.Button btnScan;
      private System.Windows.Forms.GroupBox grpLoad;
      private System.Windows.Forms.TextBox txtFilePath;
      private System.Windows.Forms.Button btnBrowse;
      private System.Windows.Forms.RadioButton rdBtnFile;
      private System.Windows.Forms.Panel pnlThumbnail;
      private System.Windows.Forms.Label lblDescription;
      private System.Windows.Forms.TextBox txtTemplateName;
      private System.Windows.Forms.TextBox txtScanPath;
      private System.Windows.Forms.Button btnPreviousPage;
      private System.Windows.Forms.Button btnNextPage;
      private System.Windows.Forms.Label lblPageIndex;
   }
}