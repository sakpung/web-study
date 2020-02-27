namespace Leadtools.Medical.Worklist.AddIns.Controls
{
   partial class AddInConfiguration
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.btnBrowseMWLIODPath = new System.Windows.Forms.Button();
         this.txtMWLIODPath = new System.Windows.Forms.TextBox();
         this.chkClientLimitMWLResponsesToClientAE = new System.Windows.Forms.CheckBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.chkStatusDiscontinued = new System.Windows.Forms.CheckBox();
         this.chkStatusCompleted = new System.Windows.Forms.CheckBox();
         this.chkStatusInProgress = new System.Windows.Forms.CheckBox();
         this.grbServerRequestDatasetValidation = new System.Windows.Forms.GroupBox();
         this.chkServerRequestDatasetValidationPrivateElements = new System.Windows.Forms.CheckBox();
         this.chkServerRequestDatasetValidationExtraElements = new System.Windows.Forms.CheckBox();
         this.chkServerRequestDatasetValidationMultiple = new System.Windows.Forms.CheckBox();
         this.chkServerRequestDatasetValidationZero = new System.Windows.Forms.CheckBox();
         this.lblMWLIODPath = new System.Windows.Forms.Label();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.btnBrowseNSetIODPath = new System.Windows.Forms.Button();
         this.txtNSetIODPath = new System.Windows.Forms.TextBox();
         this.lblNSetIODPath = new System.Windows.Forms.Label();
         this.chkNSetAllowPrivate = new System.Windows.Forms.CheckBox();
         this.chkNSetAllowExtra = new System.Windows.Forms.CheckBox();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this.btnBrowseNCreateIODPath = new System.Windows.Forms.Button();
         this.txtNCreateIODPath = new System.Windows.Forms.TextBox();
         this.lblNCreateIODPath = new System.Windows.Forms.Label();
         this.chkNCreatevalidateRelational = new System.Windows.Forms.CheckBox();
         this.chkNCreateAllowPrivate = new System.Windows.Forms.CheckBox();
         this.chkNCreateAllowExtra = new System.Windows.Forms.CheckBox();
         this.iodOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.LimitResponsesCheckBox = new System.Windows.Forms.CheckBox();
         this.NumberOfResponsesNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.grbServerRequestDatasetValidation.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.groupBox4.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.NumberOfResponsesNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.NumberOfResponsesNumericUpDown);
         this.groupBox1.Controls.Add(this.LimitResponsesCheckBox);
         this.groupBox1.Controls.Add(this.btnBrowseMWLIODPath);
         this.groupBox1.Controls.Add(this.txtMWLIODPath);
         this.groupBox1.Controls.Add(this.chkClientLimitMWLResponsesToClientAE);
         this.groupBox1.Controls.Add(this.groupBox2);
         this.groupBox1.Controls.Add(this.grbServerRequestDatasetValidation);
         this.groupBox1.Controls.Add(this.lblMWLIODPath);
         this.groupBox1.Location = new System.Drawing.Point(3, 3);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(588, 251);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Modality Worklist C-Find AddIn";
         // 
         // btnBrowseMWLIODPath
         // 
         this.btnBrowseMWLIODPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnBrowseMWLIODPath.Location = new System.Drawing.Point(507, 220);
         this.btnBrowseMWLIODPath.Name = "btnBrowseMWLIODPath";
         this.btnBrowseMWLIODPath.Size = new System.Drawing.Size(75, 23);
         this.btnBrowseMWLIODPath.TabIndex = 7;
         this.btnBrowseMWLIODPath.Text = "Browse...";
         this.btnBrowseMWLIODPath.UseVisualStyleBackColor = true;
         this.btnBrowseMWLIODPath.Click += new System.EventHandler(this.btnBrowseMWLIODPath_Click);
         // 
         // txtMWLIODPath
         // 
         this.txtMWLIODPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtMWLIODPath.Location = new System.Drawing.Point(96, 220);
         this.txtMWLIODPath.Name = "txtMWLIODPath";
         this.txtMWLIODPath.ReadOnly = true;
         this.txtMWLIODPath.Size = new System.Drawing.Size(405, 20);
         this.txtMWLIODPath.TabIndex = 6;
         // 
         // chkClientLimitMWLResponsesToClientAE
         // 
         this.chkClientLimitMWLResponsesToClientAE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.chkClientLimitMWLResponsesToClientAE.Location = new System.Drawing.Point(7, 18);
         this.chkClientLimitMWLResponsesToClientAE.Name = "chkClientLimitMWLResponsesToClientAE";
         this.chkClientLimitMWLResponsesToClientAE.Size = new System.Drawing.Size(567, 31);
         this.chkClientLimitMWLResponsesToClientAE.TabIndex = 3;
         this.chkClientLimitMWLResponsesToClientAE.Text = "&Limit MWL query response matching to only the procedures scheduled for the query" +
             "ing station";
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this.chkStatusDiscontinued);
         this.groupBox2.Controls.Add(this.chkStatusCompleted);
         this.groupBox2.Controls.Add(this.chkStatusInProgress);
         this.groupBox2.Location = new System.Drawing.Point(7, 76);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(575, 58);
         this.groupBox2.TabIndex = 4;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Don\'t return MWL that has an associated performed procedure with any of the follo" +
             "wing status:";
         // 
         // chkStatusDiscontinued
         // 
         this.chkStatusDiscontinued.Location = new System.Drawing.Point(300, 23);
         this.chkStatusDiscontinued.Name = "chkStatusDiscontinued";
         this.chkStatusDiscontinued.Size = new System.Drawing.Size(112, 24);
         this.chkStatusDiscontinued.TabIndex = 2;
         this.chkStatusDiscontinued.Text = "&DISCONTINUED";
         // 
         // chkStatusCompleted
         // 
         this.chkStatusCompleted.Location = new System.Drawing.Point(160, 23);
         this.chkStatusCompleted.Name = "chkStatusCompleted";
         this.chkStatusCompleted.Size = new System.Drawing.Size(104, 24);
         this.chkStatusCompleted.TabIndex = 1;
         this.chkStatusCompleted.Text = "&COMPLETED";
         // 
         // chkStatusInProgress
         // 
         this.chkStatusInProgress.Location = new System.Drawing.Point(8, 23);
         this.chkStatusInProgress.Name = "chkStatusInProgress";
         this.chkStatusInProgress.Size = new System.Drawing.Size(111, 24);
         this.chkStatusInProgress.TabIndex = 0;
         this.chkStatusInProgress.Text = "&IN PROGRESS";
         // 
         // grbServerRequestDatasetValidation
         // 
         this.grbServerRequestDatasetValidation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.grbServerRequestDatasetValidation.Controls.Add(this.chkServerRequestDatasetValidationPrivateElements);
         this.grbServerRequestDatasetValidation.Controls.Add(this.chkServerRequestDatasetValidationExtraElements);
         this.grbServerRequestDatasetValidation.Controls.Add(this.chkServerRequestDatasetValidationMultiple);
         this.grbServerRequestDatasetValidation.Controls.Add(this.chkServerRequestDatasetValidationZero);
         this.grbServerRequestDatasetValidation.Location = new System.Drawing.Point(7, 140);
         this.grbServerRequestDatasetValidation.Name = "grbServerRequestDatasetValidation";
         this.grbServerRequestDatasetValidation.Size = new System.Drawing.Size(575, 74);
         this.grbServerRequestDatasetValidation.TabIndex = 5;
         this.grbServerRequestDatasetValidation.TabStop = false;
         this.grbServerRequestDatasetValidation.Text = "Request Dataset Validation";
         // 
         // chkServerRequestDatasetValidationPrivateElements
         // 
         this.chkServerRequestDatasetValidationPrivateElements.Location = new System.Drawing.Point(160, 22);
         this.chkServerRequestDatasetValidationPrivateElements.Name = "chkServerRequestDatasetValidationPrivateElements";
         this.chkServerRequestDatasetValidationPrivateElements.Size = new System.Drawing.Size(136, 18);
         this.chkServerRequestDatasetValidationPrivateElements.TabIndex = 2;
         this.chkServerRequestDatasetValidationPrivateElements.Text = "Allow &private elements";
         // 
         // chkServerRequestDatasetValidationExtraElements
         // 
         this.chkServerRequestDatasetValidationExtraElements.Location = new System.Drawing.Point(160, 45);
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
         this.lblMWLIODPath.Location = new System.Drawing.Point(11, 224);
         this.lblMWLIODPath.Name = "lblMWLIODPath";
         this.lblMWLIODPath.Size = new System.Drawing.Size(79, 13);
         this.lblMWLIODPath.TabIndex = 8;
         this.lblMWLIODPath.Text = "IOD XML Path:";
         // 
         // groupBox3
         // 
         this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox3.Controls.Add(this.btnBrowseNSetIODPath);
         this.groupBox3.Controls.Add(this.txtNSetIODPath);
         this.groupBox3.Controls.Add(this.lblNSetIODPath);
         this.groupBox3.Controls.Add(this.chkNSetAllowPrivate);
         this.groupBox3.Controls.Add(this.chkNSetAllowExtra);
         this.groupBox3.Location = new System.Drawing.Point(5, 391);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(586, 99);
         this.groupBox3.TabIndex = 3;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Modality Performed Procedure Step N-Set AddIn";
         // 
         // btnBrowseNSetIODPath
         // 
         this.btnBrowseNSetIODPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnBrowseNSetIODPath.Location = new System.Drawing.Point(507, 70);
         this.btnBrowseNSetIODPath.Name = "btnBrowseNSetIODPath";
         this.btnBrowseNSetIODPath.Size = new System.Drawing.Size(75, 23);
         this.btnBrowseNSetIODPath.TabIndex = 13;
         this.btnBrowseNSetIODPath.Text = "Browse...";
         this.btnBrowseNSetIODPath.UseVisualStyleBackColor = true;
         this.btnBrowseNSetIODPath.Click += new System.EventHandler(this.btnBrowseNSetIODPath_Click);
         // 
         // txtNSetIODPath
         // 
         this.txtNSetIODPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtNSetIODPath.Location = new System.Drawing.Point(96, 70);
         this.txtNSetIODPath.Name = "txtNSetIODPath";
         this.txtNSetIODPath.ReadOnly = true;
         this.txtNSetIODPath.Size = new System.Drawing.Size(405, 20);
         this.txtNSetIODPath.TabIndex = 12;
         // 
         // lblNSetIODPath
         // 
         this.lblNSetIODPath.AutoSize = true;
         this.lblNSetIODPath.Location = new System.Drawing.Point(11, 74);
         this.lblNSetIODPath.Name = "lblNSetIODPath";
         this.lblNSetIODPath.Size = new System.Drawing.Size(79, 13);
         this.lblNSetIODPath.TabIndex = 14;
         this.lblNSetIODPath.Text = "IOD XML Path:";
         // 
         // chkNSetAllowPrivate
         // 
         this.chkNSetAllowPrivate.Location = new System.Drawing.Point(9, 23);
         this.chkNSetAllowPrivate.Name = "chkNSetAllowPrivate";
         this.chkNSetAllowPrivate.Size = new System.Drawing.Size(220, 18);
         this.chkNSetAllowPrivate.TabIndex = 0;
         this.chkNSetAllowPrivate.Text = "Allow &private elements in request dataset";
         // 
         // chkNSetAllowExtra
         // 
         this.chkNSetAllowExtra.Location = new System.Drawing.Point(9, 46);
         this.chkNSetAllowExtra.Name = "chkNSetAllowExtra";
         this.chkNSetAllowExtra.Size = new System.Drawing.Size(216, 18);
         this.chkNSetAllowExtra.TabIndex = 1;
         this.chkNSetAllowExtra.Text = "Allow &extra elements in request dataset";
         // 
         // groupBox4
         // 
         this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox4.Controls.Add(this.btnBrowseNCreateIODPath);
         this.groupBox4.Controls.Add(this.txtNCreateIODPath);
         this.groupBox4.Controls.Add(this.lblNCreateIODPath);
         this.groupBox4.Controls.Add(this.chkNCreatevalidateRelational);
         this.groupBox4.Controls.Add(this.chkNCreateAllowPrivate);
         this.groupBox4.Controls.Add(this.chkNCreateAllowExtra);
         this.groupBox4.Location = new System.Drawing.Point(3, 260);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(588, 125);
         this.groupBox4.TabIndex = 2;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Modality Performed Procedure Step N-Create AddIn";
         // 
         // btnBrowseNCreateIODPath
         // 
         this.btnBrowseNCreateIODPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnBrowseNCreateIODPath.Location = new System.Drawing.Point(507, 96);
         this.btnBrowseNCreateIODPath.Name = "btnBrowseNCreateIODPath";
         this.btnBrowseNCreateIODPath.Size = new System.Drawing.Size(75, 23);
         this.btnBrowseNCreateIODPath.TabIndex = 10;
         this.btnBrowseNCreateIODPath.Text = "Browse...";
         this.btnBrowseNCreateIODPath.UseVisualStyleBackColor = true;
         this.btnBrowseNCreateIODPath.Click += new System.EventHandler(this.btnBrowseNCreateIODPath_Click);
         // 
         // txtNCreateIODPath
         // 
         this.txtNCreateIODPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtNCreateIODPath.Location = new System.Drawing.Point(96, 96);
         this.txtNCreateIODPath.Name = "txtNCreateIODPath";
         this.txtNCreateIODPath.ReadOnly = true;
         this.txtNCreateIODPath.Size = new System.Drawing.Size(405, 20);
         this.txtNCreateIODPath.TabIndex = 9;
         // 
         // lblNCreateIODPath
         // 
         this.lblNCreateIODPath.AutoSize = true;
         this.lblNCreateIODPath.Location = new System.Drawing.Point(11, 100);
         this.lblNCreateIODPath.Name = "lblNCreateIODPath";
         this.lblNCreateIODPath.Size = new System.Drawing.Size(79, 13);
         this.lblNCreateIODPath.TabIndex = 11;
         this.lblNCreateIODPath.Text = "IOD XML Path:";
         // 
         // chkNCreatevalidateRelational
         // 
         this.chkNCreatevalidateRelational.Location = new System.Drawing.Point(9, 24);
         this.chkNCreatevalidateRelational.Name = "chkNCreatevalidateRelational";
         this.chkNCreatevalidateRelational.Size = new System.Drawing.Size(297, 24);
         this.chkNCreatevalidateRelational.TabIndex = 0;
         this.chkNCreatevalidateRelational.Text = "&Validate relational attributes according to the IHE rules";
         // 
         // chkNCreateAllowPrivate
         // 
         this.chkNCreateAllowPrivate.Location = new System.Drawing.Point(9, 51);
         this.chkNCreateAllowPrivate.Name = "chkNCreateAllowPrivate";
         this.chkNCreateAllowPrivate.Size = new System.Drawing.Size(239, 18);
         this.chkNCreateAllowPrivate.TabIndex = 1;
         this.chkNCreateAllowPrivate.Text = "Allow &private elements in request dataset";
         // 
         // chkNCreateAllowExtra
         // 
         this.chkNCreateAllowExtra.Location = new System.Drawing.Point(9, 75);
         this.chkNCreateAllowExtra.Name = "chkNCreateAllowExtra";
         this.chkNCreateAllowExtra.Size = new System.Drawing.Size(223, 18);
         this.chkNCreateAllowExtra.TabIndex = 2;
         this.chkNCreateAllowExtra.Text = "Allow &extra elements in request dataset";
         // 
         // iodOpenFileDialog
         // 
         this.iodOpenFileDialog.FileName = "IOD XML File";
         this.iodOpenFileDialog.Filter = "XML files|*.xml";
         // 
         // LimitResponsesCheckBox
         // 
         this.LimitResponsesCheckBox.AutoSize = true;
         this.LimitResponsesCheckBox.Location = new System.Drawing.Point(7, 49);
         this.LimitResponsesCheckBox.Name = "LimitResponsesCheckBox";
         this.LimitResponsesCheckBox.Size = new System.Drawing.Size(155, 17);
         this.LimitResponsesCheckBox.TabIndex = 9;
         this.LimitResponsesCheckBox.Text = "Limit &number of marching to";
         // 
         // NumberOfResponsesNumericUpDown
         // 
         this.NumberOfResponsesNumericUpDown.Location = new System.Drawing.Point(163, 49);
         this.NumberOfResponsesNumericUpDown.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
         this.NumberOfResponsesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.NumberOfResponsesNumericUpDown.Name = "NumberOfResponsesNumericUpDown";
         this.NumberOfResponsesNumericUpDown.Size = new System.Drawing.Size(68, 20);
         this.NumberOfResponsesNumericUpDown.TabIndex = 10;
         this.NumberOfResponsesNumericUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(237, 52);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(64, 13);
         this.label1.TabIndex = 11;
         this.label1.Text = "response(s).";
         // 
         // AddInConfiguration
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox4);
         this.Controls.Add(this.groupBox1);
         this.Name = "AddInConfiguration";
         this.Size = new System.Drawing.Size(594, 494);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.grbServerRequestDatasetValidation.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.groupBox4.ResumeLayout(false);
         this.groupBox4.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.NumberOfResponsesNumericUpDown)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckBox chkClientLimitMWLResponsesToClientAE;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.CheckBox chkStatusDiscontinued;
      private System.Windows.Forms.CheckBox chkStatusCompleted;
      private System.Windows.Forms.CheckBox chkStatusInProgress;
      private System.Windows.Forms.GroupBox grbServerRequestDatasetValidation;
      private System.Windows.Forms.CheckBox chkServerRequestDatasetValidationPrivateElements;
      private System.Windows.Forms.CheckBox chkServerRequestDatasetValidationExtraElements;
      private System.Windows.Forms.CheckBox chkServerRequestDatasetValidationMultiple;
      private System.Windows.Forms.CheckBox chkServerRequestDatasetValidationZero;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.CheckBox chkNSetAllowPrivate;
      private System.Windows.Forms.CheckBox chkNSetAllowExtra;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.CheckBox chkNCreatevalidateRelational;
      private System.Windows.Forms.CheckBox chkNCreateAllowPrivate;
      private System.Windows.Forms.CheckBox chkNCreateAllowExtra;
      private System.Windows.Forms.Button btnBrowseMWLIODPath;
      private System.Windows.Forms.TextBox txtMWLIODPath;
      private System.Windows.Forms.Label lblMWLIODPath;
      private System.Windows.Forms.OpenFileDialog iodOpenFileDialog;
      private System.Windows.Forms.Button btnBrowseNCreateIODPath;
      private System.Windows.Forms.TextBox txtNCreateIODPath;
      private System.Windows.Forms.Label lblNCreateIODPath;
      private System.Windows.Forms.Button btnBrowseNSetIODPath;
      private System.Windows.Forms.TextBox txtNSetIODPath;
      private System.Windows.Forms.Label lblNSetIODPath;
      private System.Windows.Forms.CheckBox LimitResponsesCheckBox;
      private System.Windows.Forms.NumericUpDown NumberOfResponsesNumericUpDown;
      private System.Windows.Forms.Label label1;
   }
}
