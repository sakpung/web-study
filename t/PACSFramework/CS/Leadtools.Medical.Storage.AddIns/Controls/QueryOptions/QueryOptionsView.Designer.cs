namespace Leadtools.Medical.Storage.AddIns
{
   partial class QueryOptionsView
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
         this.CFindQueryAddInPanel = new System.Windows.Forms.Panel();
         this.ResponseCountGroupBox = new System.Windows.Forms.GroupBox();
         this.textBoxStatus = new System.Windows.Forms.TextBox();
         this.comboBoxStatus = new System.Windows.Forms.ComboBox();
         this.lblStatus = new System.Windows.Forms.Label();
         this.numericUpDownMaximumCountCFindRsp = new System.Windows.Forms.NumericUpDown();
         this.chkLimitCFindResponses = new System.Windows.Forms.CheckBox();
         this.ResponseDataSetGroupBox = new System.Windows.Forms.GroupBox();
         this.IncludeSeriesInstancesCheckBox = new System.Windows.Forms.CheckBox();
         this.IncludeStudyInstancesCheckBox = new System.Windows.Forms.CheckBox();
         this.IncludeStudySeriesCheckBox = new System.Windows.Forms.CheckBox();
         this.IncludePatientInstancesCheckBox = new System.Windows.Forms.CheckBox();
         this.IncludePatientSeriesCheckBox = new System.Windows.Forms.CheckBox();
         this.IncludePatientStudiesCheckBox = new System.Windows.Forms.CheckBox();
         this.btnBrowseMWLIODPath = new System.Windows.Forms.Button();
         this.QueryIODPathTextBox = new System.Windows.Forms.TextBox();
         this.grbServerRequestDatasetValidation = new System.Windows.Forms.GroupBox();
         this.chkServerRequestDatasetValidationPrivateElements = new System.Windows.Forms.CheckBox();
         this.chkServerRequestDatasetValidationExtraElements = new System.Windows.Forms.CheckBox();
         this.chkServerRequestDatasetValidationMultiple = new System.Windows.Forms.CheckBox();
         this.chkServerRequestDatasetValidationZero = new System.Windows.Forms.CheckBox();
         this.lblMWLIODPath = new System.Windows.Forms.Label();
         this.iodOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.CFindQueryAddInPanel.SuspendLayout();
         this.ResponseCountGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumCountCFindRsp)).BeginInit();
         this.ResponseDataSetGroupBox.SuspendLayout();
         this.grbServerRequestDatasetValidation.SuspendLayout();
         this.SuspendLayout();
         // 
         // CFindQueryAddInPanel
         // 
         this.CFindQueryAddInPanel.Controls.Add(this.ResponseCountGroupBox);
         this.CFindQueryAddInPanel.Controls.Add(this.ResponseDataSetGroupBox);
         this.CFindQueryAddInPanel.Controls.Add(this.btnBrowseMWLIODPath);
         this.CFindQueryAddInPanel.Controls.Add(this.QueryIODPathTextBox);
         this.CFindQueryAddInPanel.Controls.Add(this.grbServerRequestDatasetValidation);
         this.CFindQueryAddInPanel.Controls.Add(this.lblMWLIODPath);
         this.CFindQueryAddInPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.CFindQueryAddInPanel.Location = new System.Drawing.Point(0, 0);
         this.CFindQueryAddInPanel.Name = "CFindQueryAddInPanel";
         this.CFindQueryAddInPanel.Size = new System.Drawing.Size(606, 323);
         this.CFindQueryAddInPanel.TabIndex = 0;
         this.CFindQueryAddInPanel.Text = "CFind Query AddIn";
         // 
         // ResponseCountGroupBox
         // 
         this.ResponseCountGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.ResponseCountGroupBox.Controls.Add(this.textBoxStatus);
         this.ResponseCountGroupBox.Controls.Add(this.comboBoxStatus);
         this.ResponseCountGroupBox.Controls.Add(this.lblStatus);
         this.ResponseCountGroupBox.Controls.Add(this.numericUpDownMaximumCountCFindRsp);
         this.ResponseCountGroupBox.Controls.Add(this.chkLimitCFindResponses);
         this.ResponseCountGroupBox.Location = new System.Drawing.Point(7, 198);
         this.ResponseCountGroupBox.Name = "ResponseCountGroupBox";
         this.ResponseCountGroupBox.Size = new System.Drawing.Size(592, 72);
         this.ResponseCountGroupBox.TabIndex = 2;
         this.ResponseCountGroupBox.TabStop = false;
         this.ResponseCountGroupBox.Text = "Response Count";
         // 
         // textBoxStatus
         // 
         this.textBoxStatus.Location = new System.Drawing.Point(280, 45);
         this.textBoxStatus.Name = "textBoxStatus";
         this.textBoxStatus.Size = new System.Drawing.Size(71, 20);
         this.textBoxStatus.TabIndex = 3;
         // 
         // comboBoxStatus
         // 
         this.comboBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBoxStatus.FormattingEnabled = true;
         this.comboBoxStatus.Location = new System.Drawing.Point(364, 45);
         this.comboBoxStatus.Name = "comboBoxStatus";
         this.comboBoxStatus.Size = new System.Drawing.Size(222, 21);
         this.comboBoxStatus.TabIndex = 4;
         // 
         // lblStatus
         // 
         this.lblStatus.AutoSize = true;
         this.lblStatus.Location = new System.Drawing.Point(25, 49);
         this.lblStatus.Name = "lblStatus";
         this.lblStatus.Size = new System.Drawing.Size(168, 13);
         this.lblStatus.TabIndex = 2;
         this.lblStatus.Text = "Service Status for Final CFind-Rsp";
         // 
         // numericUpDownMaximumCountCFindRsp
         // 
         this.numericUpDownMaximumCountCFindRsp.Location = new System.Drawing.Point(280, 21);
         this.numericUpDownMaximumCountCFindRsp.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.numericUpDownMaximumCountCFindRsp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownMaximumCountCFindRsp.Name = "numericUpDownMaximumCountCFindRsp";
         this.numericUpDownMaximumCountCFindRsp.Size = new System.Drawing.Size(71, 20);
         this.numericUpDownMaximumCountCFindRsp.TabIndex = 1;
         this.numericUpDownMaximumCountCFindRsp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // chkLimitCFindResponses
         // 
         this.chkLimitCFindResponses.AutoSize = true;
         this.chkLimitCFindResponses.Location = new System.Drawing.Point(8, 21);
         this.chkLimitCFindResponses.Name = "chkLimitCFindResponses";
         this.chkLimitCFindResponses.Size = new System.Drawing.Size(213, 17);
         this.chkLimitCFindResponses.TabIndex = 0;
         this.chkLimitCFindResponses.Text = "Limit Number of CFind-Rsp Per Request";
         this.chkLimitCFindResponses.UseVisualStyleBackColor = true;
         // 
         // ResponseDataSetGroupBox
         // 
         this.ResponseDataSetGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.ResponseDataSetGroupBox.Controls.Add(this.IncludeSeriesInstancesCheckBox);
         this.ResponseDataSetGroupBox.Controls.Add(this.IncludeStudyInstancesCheckBox);
         this.ResponseDataSetGroupBox.Controls.Add(this.IncludeStudySeriesCheckBox);
         this.ResponseDataSetGroupBox.Controls.Add(this.IncludePatientInstancesCheckBox);
         this.ResponseDataSetGroupBox.Controls.Add(this.IncludePatientSeriesCheckBox);
         this.ResponseDataSetGroupBox.Controls.Add(this.IncludePatientStudiesCheckBox);
         this.ResponseDataSetGroupBox.Location = new System.Drawing.Point(7, 94);
         this.ResponseDataSetGroupBox.Name = "ResponseDataSetGroupBox";
         this.ResponseDataSetGroupBox.Size = new System.Drawing.Size(592, 100);
         this.ResponseDataSetGroupBox.TabIndex = 1;
         this.ResponseDataSetGroupBox.TabStop = false;
         this.ResponseDataSetGroupBox.Text = "Response Dataset";
         // 
         // IncludeSeriesInstancesCheckBox
         // 
         this.IncludeSeriesInstancesCheckBox.AutoSize = true;
         this.IncludeSeriesInstancesCheckBox.Location = new System.Drawing.Point(280, 72);
         this.IncludeSeriesInstancesCheckBox.Name = "IncludeSeriesInstancesCheckBox";
         this.IncludeSeriesInstancesCheckBox.Size = new System.Drawing.Size(237, 17);
         this.IncludeSeriesInstancesCheckBox.TabIndex = 5;
         this.IncludeSeriesInstancesCheckBox.Text = "Include Number of Series Related Instances ";
         this.IncludeSeriesInstancesCheckBox.UseVisualStyleBackColor = true;
         // 
         // IncludeStudyInstancesCheckBox
         // 
         this.IncludeStudyInstancesCheckBox.AutoSize = true;
         this.IncludeStudyInstancesCheckBox.Location = new System.Drawing.Point(280, 46);
         this.IncludeStudyInstancesCheckBox.Name = "IncludeStudyInstancesCheckBox";
         this.IncludeStudyInstancesCheckBox.Size = new System.Drawing.Size(235, 17);
         this.IncludeStudyInstancesCheckBox.TabIndex = 4;
         this.IncludeStudyInstancesCheckBox.Text = "Include Number of Study Related Instances ";
         this.IncludeStudyInstancesCheckBox.UseVisualStyleBackColor = true;
         // 
         // IncludeStudySeriesCheckBox
         // 
         this.IncludeStudySeriesCheckBox.AutoSize = true;
         this.IncludeStudySeriesCheckBox.Location = new System.Drawing.Point(280, 20);
         this.IncludeStudySeriesCheckBox.Name = "IncludeStudySeriesCheckBox";
         this.IncludeStudySeriesCheckBox.Size = new System.Drawing.Size(218, 17);
         this.IncludeStudySeriesCheckBox.TabIndex = 3;
         this.IncludeStudySeriesCheckBox.Text = "Include Number of Study Related Series ";
         this.IncludeStudySeriesCheckBox.UseVisualStyleBackColor = true;
         // 
         // IncludePatientInstancesCheckBox
         // 
         this.IncludePatientInstancesCheckBox.AutoSize = true;
         this.IncludePatientInstancesCheckBox.Location = new System.Drawing.Point(8, 72);
         this.IncludePatientInstancesCheckBox.Name = "IncludePatientInstancesCheckBox";
         this.IncludePatientInstancesCheckBox.Size = new System.Drawing.Size(241, 17);
         this.IncludePatientInstancesCheckBox.TabIndex = 2;
         this.IncludePatientInstancesCheckBox.Text = "Include Number of Patient Related Instances ";
         this.IncludePatientInstancesCheckBox.UseVisualStyleBackColor = true;
         // 
         // IncludePatientSeriesCheckBox
         // 
         this.IncludePatientSeriesCheckBox.AutoSize = true;
         this.IncludePatientSeriesCheckBox.Location = new System.Drawing.Point(8, 46);
         this.IncludePatientSeriesCheckBox.Name = "IncludePatientSeriesCheckBox";
         this.IncludePatientSeriesCheckBox.Size = new System.Drawing.Size(224, 17);
         this.IncludePatientSeriesCheckBox.TabIndex = 1;
         this.IncludePatientSeriesCheckBox.Text = "Include Number of Patient Related Series ";
         this.IncludePatientSeriesCheckBox.UseVisualStyleBackColor = true;
         // 
         // IncludePatientStudiesCheckBox
         // 
         this.IncludePatientStudiesCheckBox.AutoSize = true;
         this.IncludePatientStudiesCheckBox.Location = new System.Drawing.Point(8, 20);
         this.IncludePatientStudiesCheckBox.Name = "IncludePatientStudiesCheckBox";
         this.IncludePatientStudiesCheckBox.Size = new System.Drawing.Size(230, 17);
         this.IncludePatientStudiesCheckBox.TabIndex = 0;
         this.IncludePatientStudiesCheckBox.Text = "Include Number of Patient Related Studies ";
         this.IncludePatientStudiesCheckBox.UseVisualStyleBackColor = true;
         // 
         // btnBrowseMWLIODPath
         // 
         this.btnBrowseMWLIODPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnBrowseMWLIODPath.CausesValidation = false;
         this.btnBrowseMWLIODPath.Location = new System.Drawing.Point(525, 293);
         this.btnBrowseMWLIODPath.Name = "btnBrowseMWLIODPath";
         this.btnBrowseMWLIODPath.Size = new System.Drawing.Size(75, 23);
         this.btnBrowseMWLIODPath.TabIndex = 5;
         this.btnBrowseMWLIODPath.Text = "Browse...";
         this.btnBrowseMWLIODPath.UseVisualStyleBackColor = true;
         // 
         // QueryIODPathTextBox
         // 
         this.QueryIODPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.QueryIODPathTextBox.Location = new System.Drawing.Point(96, 293);
         this.QueryIODPathTextBox.Name = "QueryIODPathTextBox";
         this.QueryIODPathTextBox.Size = new System.Drawing.Size(423, 20);
         this.QueryIODPathTextBox.TabIndex = 4;
         // 
         // grbServerRequestDatasetValidation
         // 
         this.grbServerRequestDatasetValidation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.grbServerRequestDatasetValidation.Controls.Add(this.chkServerRequestDatasetValidationPrivateElements);
         this.grbServerRequestDatasetValidation.Controls.Add(this.chkServerRequestDatasetValidationExtraElements);
         this.grbServerRequestDatasetValidation.Controls.Add(this.chkServerRequestDatasetValidationMultiple);
         this.grbServerRequestDatasetValidation.Controls.Add(this.chkServerRequestDatasetValidationZero);
         this.grbServerRequestDatasetValidation.Location = new System.Drawing.Point(7, 19);
         this.grbServerRequestDatasetValidation.Name = "grbServerRequestDatasetValidation";
         this.grbServerRequestDatasetValidation.Size = new System.Drawing.Size(593, 74);
         this.grbServerRequestDatasetValidation.TabIndex = 0;
         this.grbServerRequestDatasetValidation.TabStop = false;
         this.grbServerRequestDatasetValidation.Text = "Request Dataset Validation";
         // 
         // chkServerRequestDatasetValidationPrivateElements
         // 
         this.chkServerRequestDatasetValidationPrivateElements.Location = new System.Drawing.Point(280, 22);
         this.chkServerRequestDatasetValidationPrivateElements.Name = "chkServerRequestDatasetValidationPrivateElements";
         this.chkServerRequestDatasetValidationPrivateElements.Size = new System.Drawing.Size(136, 18);
         this.chkServerRequestDatasetValidationPrivateElements.TabIndex = 2;
         this.chkServerRequestDatasetValidationPrivateElements.Text = "Allow &private elements";
         // 
         // chkServerRequestDatasetValidationExtraElements
         // 
         this.chkServerRequestDatasetValidationExtraElements.Location = new System.Drawing.Point(280, 45);
         this.chkServerRequestDatasetValidationExtraElements.Name = "chkServerRequestDatasetValidationExtraElements";
         this.chkServerRequestDatasetValidationExtraElements.Size = new System.Drawing.Size(136, 18);
         this.chkServerRequestDatasetValidationExtraElements.TabIndex = 3;
         this.chkServerRequestDatasetValidationExtraElements.Text = "Allow &extra elements";
         // 
         // chkServerRequestDatasetValidationMultiple
         // 
         this.chkServerRequestDatasetValidationMultiple.Location = new System.Drawing.Point(8, 45);
         this.chkServerRequestDatasetValidationMultiple.Name = "chkServerRequestDatasetValidationMultiple";
         this.chkServerRequestDatasetValidationMultiple.Size = new System.Drawing.Size(125, 18);
         this.chkServerRequestDatasetValidationMultiple.TabIndex = 1;
         this.chkServerRequestDatasetValidationMultiple.Text = "Allow &multiple items";
         // 
         // chkServerRequestDatasetValidationZero
         // 
         this.chkServerRequestDatasetValidationZero.Location = new System.Drawing.Point(8, 22);
         this.chkServerRequestDatasetValidationZero.Name = "chkServerRequestDatasetValidationZero";
         this.chkServerRequestDatasetValidationZero.Size = new System.Drawing.Size(107, 18);
         this.chkServerRequestDatasetValidationZero.TabIndex = 0;
         this.chkServerRequestDatasetValidationZero.Text = "Allow &zero items";
         // 
         // lblMWLIODPath
         // 
         this.lblMWLIODPath.AutoSize = true;
         this.lblMWLIODPath.Location = new System.Drawing.Point(11, 297);
         this.lblMWLIODPath.Name = "lblMWLIODPath";
         this.lblMWLIODPath.Size = new System.Drawing.Size(79, 13);
         this.lblMWLIODPath.TabIndex = 3;
         this.lblMWLIODPath.Text = "IOD XML Path:";
         // 
         // iodOpenFileDialog
         // 
         this.iodOpenFileDialog.FileName = "IOD XML File";
         this.iodOpenFileDialog.Filter = "XML files|*.xml";
         // 
         // QueryOptionsView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.CFindQueryAddInPanel);
         this.Name = "QueryOptionsView";
         this.Size = new System.Drawing.Size(606, 323);
         this.CFindQueryAddInPanel.ResumeLayout(false);
         this.CFindQueryAddInPanel.PerformLayout();
         this.ResponseCountGroupBox.ResumeLayout(false);
         this.ResponseCountGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumCountCFindRsp)).EndInit();
         this.ResponseDataSetGroupBox.ResumeLayout(false);
         this.ResponseDataSetGroupBox.PerformLayout();
         this.grbServerRequestDatasetValidation.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel CFindQueryAddInPanel;
      private System.Windows.Forms.GroupBox ResponseDataSetGroupBox;
      private System.Windows.Forms.CheckBox IncludeSeriesInstancesCheckBox;
      private System.Windows.Forms.CheckBox IncludeStudyInstancesCheckBox;
      private System.Windows.Forms.CheckBox IncludeStudySeriesCheckBox;
      private System.Windows.Forms.CheckBox IncludePatientInstancesCheckBox;
      private System.Windows.Forms.CheckBox IncludePatientSeriesCheckBox;
      private System.Windows.Forms.CheckBox IncludePatientStudiesCheckBox;
      private System.Windows.Forms.Button btnBrowseMWLIODPath;
      private System.Windows.Forms.TextBox QueryIODPathTextBox;
      private System.Windows.Forms.GroupBox grbServerRequestDatasetValidation;
      private System.Windows.Forms.CheckBox chkServerRequestDatasetValidationPrivateElements;
      private System.Windows.Forms.CheckBox chkServerRequestDatasetValidationExtraElements;
      private System.Windows.Forms.CheckBox chkServerRequestDatasetValidationMultiple;
      private System.Windows.Forms.CheckBox chkServerRequestDatasetValidationZero;
      private System.Windows.Forms.Label lblMWLIODPath;
      private System.Windows.Forms.OpenFileDialog iodOpenFileDialog;
      private System.Windows.Forms.GroupBox ResponseCountGroupBox;
      private System.Windows.Forms.NumericUpDown numericUpDownMaximumCountCFindRsp;
      private System.Windows.Forms.CheckBox chkLimitCFindResponses;
      private System.Windows.Forms.Label lblStatus;
      private System.Windows.Forms.TextBox textBoxStatus;
      private System.Windows.Forms.ComboBox comboBoxStatus;
   }
}
