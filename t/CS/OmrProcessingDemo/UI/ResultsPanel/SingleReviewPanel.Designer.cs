namespace OmrProcessingDemo.UI.ResultsPanel
{
   partial class SingleReviewPanel
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
         this.spltMain = new System.Windows.Forms.SplitContainer();
         this.grpInfo = new System.Windows.Forms.GroupBox();
         this.cbFiles = new System.Windows.Forms.ComboBox();
         this.btnNextWorksheet = new System.Windows.Forms.Button();
         this.btnPreviousWorksheet = new System.Windows.Forms.Button();
         this.lblFilename = new System.Windows.Forms.Label();
         this.spltInfo = new System.Windows.Forms.SplitContainer();
         this.grpAnswerCrop = new System.Windows.Forms.GroupBox();
         this.pnlAnswerCrop = new System.Windows.Forms.Panel();
         this.lblAnswerKey = new System.Windows.Forms.Label();
         this.cbZones = new System.Windows.Forms.ComboBox();
         this.chkSkipNonOMR = new System.Windows.Forms.CheckBox();
         this.btnNextZone = new System.Windows.Forms.Button();
         this.btnPreviousZone = new System.Windows.Forms.Button();
         this.lblCurrentPage = new System.Windows.Forms.Label();
         this.btnNextPage = new System.Windows.Forms.Button();
         this.btnPreviousPage = new System.Windows.Forms.Button();
         this.grpReview = new System.Windows.Forms.GroupBox();
         this.btnChooseFilters = new System.Windows.Forms.Button();
         this.rdbtnSpecific = new System.Windows.Forms.RadioButton();
         this.rdbtnAllFields = new System.Windows.Forms.RadioButton();
         this.btnCancel = new System.Windows.Forms.Button();
         this.pnlFullSheet = new System.Windows.Forms.Panel();
         this.lblNoFieldSelected = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
         this.spltMain.Panel1.SuspendLayout();
         this.spltMain.Panel2.SuspendLayout();
         this.spltMain.SuspendLayout();
         this.grpInfo.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spltInfo)).BeginInit();
         this.spltInfo.Panel1.SuspendLayout();
         this.spltInfo.Panel2.SuspendLayout();
         this.spltInfo.SuspendLayout();
         this.grpAnswerCrop.SuspendLayout();
         this.pnlAnswerCrop.SuspendLayout();
         this.grpReview.SuspendLayout();
         this.SuspendLayout();
         // 
         // spltMain
         // 
         this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.spltMain.IsSplitterFixed = true;
         this.spltMain.Location = new System.Drawing.Point(0, 0);
         this.spltMain.Name = "spltMain";
         // 
         // spltMain.Panel1
         // 
         this.spltMain.Panel1.BackColor = System.Drawing.SystemColors.Control;
         this.spltMain.Panel1.Controls.Add(this.grpInfo);
         this.spltMain.Panel1.Controls.Add(this.spltInfo);
         // 
         // spltMain.Panel2
         // 
         this.spltMain.Panel2.Controls.Add(this.lblCurrentPage);
         this.spltMain.Panel2.Controls.Add(this.btnNextPage);
         this.spltMain.Panel2.Controls.Add(this.btnPreviousPage);
         this.spltMain.Panel2.Controls.Add(this.grpReview);
         this.spltMain.Panel2.Controls.Add(this.btnCancel);
         this.spltMain.Panel2.Controls.Add(this.pnlFullSheet);
         this.spltMain.Size = new System.Drawing.Size(807, 751);
         this.spltMain.SplitterDistance = 308;
         this.spltMain.TabIndex = 1;
         // 
         // grpInfo
         // 
         this.grpInfo.Controls.Add(this.cbFiles);
         this.grpInfo.Controls.Add(this.btnNextWorksheet);
         this.grpInfo.Controls.Add(this.btnPreviousWorksheet);
         this.grpInfo.Controls.Add(this.lblFilename);
         this.grpInfo.Location = new System.Drawing.Point(4, 3);
         this.grpInfo.Name = "grpInfo";
         this.grpInfo.Size = new System.Drawing.Size(299, 82);
         this.grpInfo.TabIndex = 1;
         this.grpInfo.TabStop = false;
         this.grpInfo.Text = "Worksheet";
         // 
         // cbFiles
         // 
         this.cbFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cbFiles.FormattingEnabled = true;
         this.cbFiles.Location = new System.Drawing.Point(69, 19);
         this.cbFiles.Name = "cbFiles";
         this.cbFiles.Size = new System.Drawing.Size(224, 21);
         this.cbFiles.TabIndex = 5;
         this.cbFiles.SelectedIndexChanged += new System.EventHandler(this.cbFiles_SelectedIndexChanged);
         // 
         // btnNextWorksheet
         // 
         this.btnNextWorksheet.Location = new System.Drawing.Point(186, 46);
         this.btnNextWorksheet.Name = "btnNextWorksheet";
         this.btnNextWorksheet.Size = new System.Drawing.Size(106, 23);
         this.btnNextWorksheet.TabIndex = 3;
         this.btnNextWorksheet.Text = "N&ext Worksheet";
         this.btnNextWorksheet.UseVisualStyleBackColor = true;
         this.btnNextWorksheet.Click += new System.EventHandler(this.btnNextWorksheet_Click);
         // 
         // btnPreviousWorksheet
         // 
         this.btnPreviousWorksheet.Location = new System.Drawing.Point(10, 46);
         this.btnPreviousWorksheet.Name = "btnPreviousWorksheet";
         this.btnPreviousWorksheet.Size = new System.Drawing.Size(112, 23);
         this.btnPreviousWorksheet.TabIndex = 2;
         this.btnPreviousWorksheet.Text = "P&revious Worksheet";
         this.btnPreviousWorksheet.UseVisualStyleBackColor = true;
         this.btnPreviousWorksheet.Click += new System.EventHandler(this.btnPreviousWorksheet_Click);
         // 
         // lblFilename
         // 
         this.lblFilename.AutoSize = true;
         this.lblFilename.Location = new System.Drawing.Point(9, 22);
         this.lblFilename.Name = "lblFilename";
         this.lblFilename.Size = new System.Drawing.Size(38, 13);
         this.lblFilename.TabIndex = 0;
         this.lblFilename.Text = "Name:";
         // 
         // spltInfo
         // 
         this.spltInfo.Dock = System.Windows.Forms.DockStyle.Fill;
         this.spltInfo.IsSplitterFixed = true;
         this.spltInfo.Location = new System.Drawing.Point(0, 0);
         this.spltInfo.Name = "spltInfo";
         this.spltInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // spltInfo.Panel1
         // 
         this.spltInfo.Panel1.Controls.Add(this.grpAnswerCrop);
         // 
         // spltInfo.Panel2
         // 
         this.spltInfo.Panel2.Controls.Add(this.lblNoFieldSelected);
         this.spltInfo.Panel2.Controls.Add(this.cbZones);
         this.spltInfo.Panel2.Controls.Add(this.chkSkipNonOMR);
         this.spltInfo.Panel2.Controls.Add(this.btnNextZone);
         this.spltInfo.Panel2.Controls.Add(this.btnPreviousZone);
         this.spltInfo.Size = new System.Drawing.Size(308, 751);
         this.spltInfo.SplitterDistance = 247;
         this.spltInfo.TabIndex = 5;
         // 
         // grpAnswerCrop
         // 
         this.grpAnswerCrop.Controls.Add(this.pnlAnswerCrop);
         this.grpAnswerCrop.Location = new System.Drawing.Point(4, 91);
         this.grpAnswerCrop.Name = "grpAnswerCrop";
         this.grpAnswerCrop.Size = new System.Drawing.Size(299, 154);
         this.grpAnswerCrop.TabIndex = 1;
         this.grpAnswerCrop.TabStop = false;
         this.grpAnswerCrop.Text = "Answer Sheet";
         // 
         // pnlAnswerCrop
         // 
         this.pnlAnswerCrop.BackColor = System.Drawing.SystemColors.ControlDark;
         this.pnlAnswerCrop.Controls.Add(this.lblAnswerKey);
         this.pnlAnswerCrop.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlAnswerCrop.Location = new System.Drawing.Point(3, 16);
         this.pnlAnswerCrop.Name = "pnlAnswerCrop";
         this.pnlAnswerCrop.Size = new System.Drawing.Size(293, 135);
         this.pnlAnswerCrop.TabIndex = 2;
         // 
         // lblAnswerKey
         // 
         this.lblAnswerKey.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.lblAnswerKey.BackColor = System.Drawing.SystemColors.Control;
         this.lblAnswerKey.Location = new System.Drawing.Point(7, 59);
         this.lblAnswerKey.Name = "lblAnswerKey";
         this.lblAnswerKey.Size = new System.Drawing.Size(282, 13);
         this.lblAnswerKey.TabIndex = 0;
         this.lblAnswerKey.Text = "Answer Key";
         this.lblAnswerKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // cbZones
         // 
         this.cbZones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cbZones.FormattingEnabled = true;
         this.cbZones.Location = new System.Drawing.Point(49, 467);
         this.cbZones.Name = "cbZones";
         this.cbZones.Size = new System.Drawing.Size(211, 21);
         this.cbZones.TabIndex = 6;
         this.cbZones.SelectedIndexChanged += new System.EventHandler(this.cbZones_SelectedIndexChanged);
         // 
         // chkSkipNonOMR
         // 
         this.chkSkipNonOMR.AutoSize = true;
         this.chkSkipNonOMR.Checked = true;
         this.chkSkipNonOMR.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkSkipNonOMR.Location = new System.Drawing.Point(88, 440);
         this.chkSkipNonOMR.Name = "chkSkipNonOMR";
         this.chkSkipNonOMR.Size = new System.Drawing.Size(128, 17);
         this.chkSkipNonOMR.TabIndex = 5;
         this.chkSkipNonOMR.Text = "Skip Non-OMR Fields";
         this.chkSkipNonOMR.UseVisualStyleBackColor = true;
         // 
         // btnNextZone
         // 
         this.btnNextZone.Location = new System.Drawing.Point(225, 436);
         this.btnNextZone.Name = "btnNextZone";
         this.btnNextZone.Size = new System.Drawing.Size(75, 23);
         this.btnNextZone.TabIndex = 4;
         this.btnNextZone.Text = "&Next";
         this.btnNextZone.UseVisualStyleBackColor = true;
         this.btnNextZone.Click += new System.EventHandler(this.btnNextZone_Click);
         // 
         // btnPreviousZone
         // 
         this.btnPreviousZone.Location = new System.Drawing.Point(7, 436);
         this.btnPreviousZone.Name = "btnPreviousZone";
         this.btnPreviousZone.Size = new System.Drawing.Size(75, 23);
         this.btnPreviousZone.TabIndex = 3;
         this.btnPreviousZone.Text = "&Previous";
         this.btnPreviousZone.UseVisualStyleBackColor = true;
         this.btnPreviousZone.Click += new System.EventHandler(this.btnPreviousZone_Click);
         // 
         // lblCurrentPage
         // 
         this.lblCurrentPage.Location = new System.Drawing.Point(123, 645);
         this.lblCurrentPage.Name = "lblCurrentPage";
         this.lblCurrentPage.Size = new System.Drawing.Size(249, 23);
         this.lblCurrentPage.TabIndex = 6;
         this.lblCurrentPage.Text = "Page 1 of 1";
         this.lblCurrentPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // btnNextPage
         // 
         this.btnNextPage.Location = new System.Drawing.Point(378, 645);
         this.btnNextPage.Name = "btnNextPage";
         this.btnNextPage.Size = new System.Drawing.Size(105, 23);
         this.btnNextPage.TabIndex = 5;
         this.btnNextPage.Text = "Next Pa&ge";
         this.btnNextPage.UseVisualStyleBackColor = true;
         this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
         // 
         // btnPreviousPage
         // 
         this.btnPreviousPage.Location = new System.Drawing.Point(12, 645);
         this.btnPreviousPage.Name = "btnPreviousPage";
         this.btnPreviousPage.Size = new System.Drawing.Size(105, 23);
         this.btnPreviousPage.TabIndex = 4;
         this.btnPreviousPage.Text = "Previous P&age";
         this.btnPreviousPage.UseVisualStyleBackColor = true;
         this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
         // 
         // grpReview
         // 
         this.grpReview.Controls.Add(this.btnChooseFilters);
         this.grpReview.Controls.Add(this.rdbtnSpecific);
         this.grpReview.Controls.Add(this.rdbtnAllFields);
         this.grpReview.Location = new System.Drawing.Point(14, 687);
         this.grpReview.Name = "grpReview";
         this.grpReview.Size = new System.Drawing.Size(313, 52);
         this.grpReview.TabIndex = 3;
         this.grpReview.TabStop = false;
         this.grpReview.Text = "Fields to Review";
         // 
         // btnChooseFilters
         // 
         this.btnChooseFilters.Location = new System.Drawing.Point(186, 16);
         this.btnChooseFilters.Name = "btnChooseFilters";
         this.btnChooseFilters.Size = new System.Drawing.Size(114, 23);
         this.btnChooseFilters.TabIndex = 2;
         this.btnChooseFilters.Text = "&Choose Filters...";
         this.btnChooseFilters.UseVisualStyleBackColor = true;
         this.btnChooseFilters.Click += new System.EventHandler(this.btnChooseFilters_Click);
         // 
         // rdbtnSpecific
         // 
         this.rdbtnSpecific.AutoSize = true;
         this.rdbtnSpecific.Location = new System.Drawing.Point(87, 19);
         this.rdbtnSpecific.Name = "rdbtnSpecific";
         this.rdbtnSpecific.Size = new System.Drawing.Size(93, 17);
         this.rdbtnSpecific.TabIndex = 1;
         this.rdbtnSpecific.Text = "&Specific Fields";
         this.rdbtnSpecific.UseVisualStyleBackColor = true;
         // 
         // rdbtnAllFields
         // 
         this.rdbtnAllFields.AutoSize = true;
         this.rdbtnAllFields.Checked = true;
         this.rdbtnAllFields.Location = new System.Drawing.Point(15, 19);
         this.rdbtnAllFields.Name = "rdbtnAllFields";
         this.rdbtnAllFields.Size = new System.Drawing.Size(66, 17);
         this.rdbtnAllFields.TabIndex = 0;
         this.rdbtnAllFields.TabStop = true;
         this.rdbtnAllFields.Text = "&All Fields";
         this.rdbtnAllFields.UseVisualStyleBackColor = true;
         this.rdbtnAllFields.CheckedChanged += new System.EventHandler(this.rdbtnAllFields_CheckedChanged);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(408, 720);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 2;
         this.btnCancel.Text = "&Close";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // pnlFullSheet
         // 
         this.pnlFullSheet.Location = new System.Drawing.Point(3, 3);
         this.pnlFullSheet.Name = "pnlFullSheet";
         this.pnlFullSheet.Size = new System.Drawing.Size(489, 636);
         this.pnlFullSheet.TabIndex = 0;
         // 
         // lblNoFieldSelected
         // 
         this.lblNoFieldSelected.AutoSize = true;
         this.lblNoFieldSelected.Location = new System.Drawing.Point(110, 244);
         this.lblNoFieldSelected.Name = "lblNoFieldSelected";
         this.lblNoFieldSelected.Size = new System.Drawing.Size(89, 13);
         this.lblNoFieldSelected.TabIndex = 7;
         this.lblNoFieldSelected.Text = "No field selected.";
         // 
         // SingleReviewPanel
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(807, 751);
         this.Controls.Add(this.spltMain);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SingleReviewPanel";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Review";
         this.spltMain.Panel1.ResumeLayout(false);
         this.spltMain.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
         this.spltMain.ResumeLayout(false);
         this.grpInfo.ResumeLayout(false);
         this.grpInfo.PerformLayout();
         this.spltInfo.Panel1.ResumeLayout(false);
         this.spltInfo.Panel2.ResumeLayout(false);
         this.spltInfo.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spltInfo)).EndInit();
         this.spltInfo.ResumeLayout(false);
         this.grpAnswerCrop.ResumeLayout(false);
         this.pnlAnswerCrop.ResumeLayout(false);
         this.grpReview.ResumeLayout(false);
         this.grpReview.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer spltMain;
      private System.Windows.Forms.GroupBox grpInfo;
      private System.Windows.Forms.Panel pnlAnswerCrop;
      private System.Windows.Forms.Label lblFilename;
      private System.Windows.Forms.Panel pnlFullSheet;
      private System.Windows.Forms.Label lblAnswerKey;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnNextWorksheet;
      private System.Windows.Forms.Button btnPreviousWorksheet;
      private System.Windows.Forms.Button btnNextZone;
      private System.Windows.Forms.Button btnPreviousZone;
      private System.Windows.Forms.SplitContainer spltInfo;
      private System.Windows.Forms.GroupBox grpReview;
      private System.Windows.Forms.Button btnChooseFilters;
      private System.Windows.Forms.RadioButton rdbtnSpecific;
      private System.Windows.Forms.RadioButton rdbtnAllFields;
      private System.Windows.Forms.Label lblCurrentPage;
      private System.Windows.Forms.Button btnNextPage;
      private System.Windows.Forms.Button btnPreviousPage;
      private System.Windows.Forms.GroupBox grpAnswerCrop;
      private System.Windows.Forms.ComboBox cbFiles;
      private System.Windows.Forms.CheckBox chkSkipNonOMR;
      private System.Windows.Forms.ComboBox cbZones;
      private System.Windows.Forms.Label lblNoFieldSelected;
   }
}