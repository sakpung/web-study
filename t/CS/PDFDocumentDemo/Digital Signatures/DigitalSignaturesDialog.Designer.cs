namespace PDFDocumentDemo
{
   partial class DigitalSignaturesDialog
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
         this._certificateTabControl = new System.Windows.Forms.TabControl();
         this._summaryTabPage = new System.Windows.Forms.TabPage();
         this._certificationInformationGroupBox = new System.Windows.Forms.GroupBox();
         this._certificationInformationLabel = new System.Windows.Forms.Label();
         this._intededUsageValueLabel = new System.Windows.Forms.Label();
         this._validToValueLabel = new System.Windows.Forms.Label();
         this._validFromValueLabel = new System.Windows.Forms.Label();
         this._issuedByValueLabel = new System.Windows.Forms.Label();
         this._signedByValueLabel = new System.Windows.Forms.Label();
         this._intededUsageLabel = new System.Windows.Forms.Label();
         this._validToLabel = new System.Windows.Forms.Label();
         this._validFromLabel = new System.Windows.Forms.Label();
         this._issuedByLabel = new System.Windows.Forms.Label();
         this._signedByLabel = new System.Windows.Forms.Label();
         this._detailsTabPage = new System.Windows.Forms.TabPage();
         this._valueDescriptionTextBox = new System.Windows.Forms.TextBox();
         this._certificateDataLabel = new System.Windows.Forms.Label();
         this._certificateDataGridView = new System.Windows.Forms.DataGridView();
         this._nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._signatureValidityStateGroupBox = new System.Windows.Forms.GroupBox();
         this._signatureValidityStateValueLabel = new System.Windows.Forms.Label();
         this._signatureValidityStateLabel = new System.Windows.Forms.Label();
         this.toolTipControl = new System.Windows.Forms.ToolTip(this.components);
         this._okButton = new System.Windows.Forms.Button();
         this._certificateTabControl.SuspendLayout();
         this._summaryTabPage.SuspendLayout();
         this._certificationInformationGroupBox.SuspendLayout();
         this._detailsTabPage.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._certificateDataGridView)).BeginInit();
         this._signatureValidityStateGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _certificateTabControl
         // 
         this._certificateTabControl.Controls.Add(this._summaryTabPage);
         this._certificateTabControl.Controls.Add(this._detailsTabPage);
         this._certificateTabControl.Location = new System.Drawing.Point(12, 89);
         this._certificateTabControl.Name = "_certificateTabControl";
         this._certificateTabControl.SelectedIndex = 0;
         this._certificateTabControl.Size = new System.Drawing.Size(491, 397);
         this._certificateTabControl.TabIndex = 0;
         // 
         // _summaryTabPage
         // 
         this._summaryTabPage.BackColor = System.Drawing.Color.White;
         this._summaryTabPage.Controls.Add(this._certificationInformationGroupBox);
         this._summaryTabPage.Controls.Add(this._intededUsageValueLabel);
         this._summaryTabPage.Controls.Add(this._validToValueLabel);
         this._summaryTabPage.Controls.Add(this._validFromValueLabel);
         this._summaryTabPage.Controls.Add(this._issuedByValueLabel);
         this._summaryTabPage.Controls.Add(this._signedByValueLabel);
         this._summaryTabPage.Controls.Add(this._intededUsageLabel);
         this._summaryTabPage.Controls.Add(this._validToLabel);
         this._summaryTabPage.Controls.Add(this._validFromLabel);
         this._summaryTabPage.Controls.Add(this._issuedByLabel);
         this._summaryTabPage.Controls.Add(this._signedByLabel);
         this._summaryTabPage.Location = new System.Drawing.Point(4, 22);
         this._summaryTabPage.Name = "_summaryTabPage";
         this._summaryTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._summaryTabPage.Size = new System.Drawing.Size(483, 371);
         this._summaryTabPage.TabIndex = 0;
         this._summaryTabPage.Text = "Summary";
         // 
         // _certificationInformationGroupBox
         // 
         this._certificationInformationGroupBox.BackColor = System.Drawing.Color.Transparent;
         this._certificationInformationGroupBox.Controls.Add(this._certificationInformationLabel);
         this._certificationInformationGroupBox.Location = new System.Drawing.Point(52, 250);
         this._certificationInformationGroupBox.Name = "_certificationInformationGroupBox";
         this._certificationInformationGroupBox.Size = new System.Drawing.Size(384, 105);
         this._certificationInformationGroupBox.TabIndex = 10;
         this._certificationInformationGroupBox.TabStop = false;
         this._certificationInformationGroupBox.Text = "Certification Information";
         // 
         // _certificationInformationLabel
         // 
         this._certificationInformationLabel.Location = new System.Drawing.Point(27, 26);
         this._certificationInformationLabel.Name = "_certificationInformationLabel";
         this._certificationInformationLabel.Size = new System.Drawing.Size(346, 52);
         this._certificationInformationLabel.TabIndex = 0;
         this._certificationInformationLabel.Text = "Signature is {0}, signed by {1}\r\n\r\nThe Document has not been modified since this " +
    "signature was applied .\r\nThe signer\'s identity is {2} .";
         // 
         // _intededUsageValueLabel
         // 
         this._intededUsageValueLabel.AutoSize = true;
         this._intededUsageValueLabel.Location = new System.Drawing.Point(125, 157);
         this._intededUsageValueLabel.Name = "_intededUsageValueLabel";
         this._intededUsageValueLabel.Size = new System.Drawing.Size(139, 13);
         this._intededUsageValueLabel.TabIndex = 9;
         this._intededUsageValueLabel.Text = "______________________";
         // 
         // _validToValueLabel
         // 
         this._validToValueLabel.AutoSize = true;
         this._validToValueLabel.Location = new System.Drawing.Point(125, 129);
         this._validToValueLabel.Name = "_validToValueLabel";
         this._validToValueLabel.Size = new System.Drawing.Size(139, 13);
         this._validToValueLabel.TabIndex = 8;
         this._validToValueLabel.Text = "______________________";
         // 
         // _validFromValueLabel
         // 
         this._validFromValueLabel.AutoSize = true;
         this._validFromValueLabel.Location = new System.Drawing.Point(125, 99);
         this._validFromValueLabel.Name = "_validFromValueLabel";
         this._validFromValueLabel.Size = new System.Drawing.Size(139, 13);
         this._validFromValueLabel.TabIndex = 7;
         this._validFromValueLabel.Text = "______________________";
         // 
         // _issuedByValueLabel
         // 
         this._issuedByValueLabel.AutoSize = true;
         this._issuedByValueLabel.Location = new System.Drawing.Point(125, 69);
         this._issuedByValueLabel.Name = "_issuedByValueLabel";
         this._issuedByValueLabel.Size = new System.Drawing.Size(139, 13);
         this._issuedByValueLabel.TabIndex = 6;
         this._issuedByValueLabel.Text = "______________________";
         // 
         // _signedByValueLabel
         // 
         this._signedByValueLabel.AutoSize = true;
         this._signedByValueLabel.Location = new System.Drawing.Point(125, 17);
         this._signedByValueLabel.Name = "_signedByValueLabel";
         this._signedByValueLabel.Size = new System.Drawing.Size(139, 13);
         this._signedByValueLabel.TabIndex = 5;
         this._signedByValueLabel.Text = "______________________";
         // 
         // _intededUsageLabel
         // 
         this._intededUsageLabel.AutoSize = true;
         this._intededUsageLabel.Location = new System.Drawing.Point(27, 157);
         this._intededUsageLabel.Name = "_intededUsageLabel";
         this._intededUsageLabel.Size = new System.Drawing.Size(82, 13);
         this._intededUsageLabel.TabIndex = 4;
         this._intededUsageLabel.Text = "Inteded Usage:";
         // 
         // _validToLabel
         // 
         this._validToLabel.AutoSize = true;
         this._validToLabel.Location = new System.Drawing.Point(61, 129);
         this._validToLabel.Name = "_validToLabel";
         this._validToLabel.Size = new System.Drawing.Size(48, 13);
         this._validToLabel.TabIndex = 3;
         this._validToLabel.Text = "Valid To:";
         // 
         // _validFromLabel
         // 
         this._validFromLabel.AutoSize = true;
         this._validFromLabel.Location = new System.Drawing.Point(49, 99);
         this._validFromLabel.Name = "_validFromLabel";
         this._validFromLabel.Size = new System.Drawing.Size(60, 13);
         this._validFromLabel.TabIndex = 2;
         this._validFromLabel.Text = "Valid From:";
         // 
         // _issuedByLabel
         // 
         this._issuedByLabel.AutoSize = true;
         this._issuedByLabel.Location = new System.Drawing.Point(49, 69);
         this._issuedByLabel.Name = "_issuedByLabel";
         this._issuedByLabel.Size = new System.Drawing.Size(58, 13);
         this._issuedByLabel.TabIndex = 1;
         this._issuedByLabel.Text = "Issued By:";
         // 
         // _signedByLabel
         // 
         this._signedByLabel.AutoSize = true;
         this._signedByLabel.Location = new System.Drawing.Point(49, 17);
         this._signedByLabel.Name = "_signedByLabel";
         this._signedByLabel.Size = new System.Drawing.Size(58, 13);
         this._signedByLabel.TabIndex = 0;
         this._signedByLabel.Text = "Signed By:";
         // 
         // _detailsTabPage
         // 
         this._detailsTabPage.BackColor = System.Drawing.Color.White;
         this._detailsTabPage.Controls.Add(this._valueDescriptionTextBox);
         this._detailsTabPage.Controls.Add(this._certificateDataLabel);
         this._detailsTabPage.Controls.Add(this._certificateDataGridView);
         this._detailsTabPage.Location = new System.Drawing.Point(4, 22);
         this._detailsTabPage.Name = "_detailsTabPage";
         this._detailsTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._detailsTabPage.Size = new System.Drawing.Size(483, 371);
         this._detailsTabPage.TabIndex = 1;
         this._detailsTabPage.Text = "Details";
         // 
         // _valueDescriptionTextBox
         // 
         this._valueDescriptionTextBox.BackColor = System.Drawing.Color.Gainsboro;
         this._valueDescriptionTextBox.Enabled = false;
         this._valueDescriptionTextBox.Location = new System.Drawing.Point(21, 260);
         this._valueDescriptionTextBox.Multiline = true;
         this._valueDescriptionTextBox.Name = "_valueDescriptionTextBox";
         this._valueDescriptionTextBox.Size = new System.Drawing.Size(443, 79);
         this._valueDescriptionTextBox.TabIndex = 2;
         // 
         // _certificateDataLabel
         // 
         this._certificateDataLabel.AutoSize = true;
         this._certificateDataLabel.Location = new System.Drawing.Point(18, 19);
         this._certificateDataLabel.Name = "_certificateDataLabel";
         this._certificateDataLabel.Size = new System.Drawing.Size(87, 13);
         this._certificateDataLabel.TabIndex = 1;
         this._certificateDataLabel.Text = "Certificate Data:";
         // 
         // _certificateDataGridView
         // 
         this._certificateDataGridView.AllowUserToAddRows = false;
         this._certificateDataGridView.AllowUserToDeleteRows = false;
         this._certificateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this._certificateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._nameColumn,
            this._valueColumn});
         this._certificateDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
         this._certificateDataGridView.Location = new System.Drawing.Point(21, 46);
         this._certificateDataGridView.MultiSelect = false;
         this._certificateDataGridView.Name = "_certificateDataGridView";
         this._certificateDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
         this._certificateDataGridView.RowHeadersWidth = 25;
         this._certificateDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this._certificateDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this._certificateDataGridView.Size = new System.Drawing.Size(443, 190);
         this._certificateDataGridView.TabIndex = 0;
         this._certificateDataGridView.SelectionChanged += new System.EventHandler(this._certificateDataGridView_SelectionChanged);
         // 
         // _nameColumn
         // 
         this._nameColumn.HeaderText = "Name";
         this._nameColumn.Name = "_nameColumn";
         // 
         // _valueColumn
         // 
         this._valueColumn.HeaderText = "Value";
         this._valueColumn.Name = "_valueColumn";
         this._valueColumn.Width = 300;
         // 
         // _signatureValidityStateGroupBox
         // 
         this._signatureValidityStateGroupBox.Controls.Add(this._signatureValidityStateValueLabel);
         this._signatureValidityStateGroupBox.Controls.Add(this._signatureValidityStateLabel);
         this._signatureValidityStateGroupBox.Location = new System.Drawing.Point(12, 13);
         this._signatureValidityStateGroupBox.Name = "_signatureValidityStateGroupBox";
         this._signatureValidityStateGroupBox.Size = new System.Drawing.Size(491, 70);
         this._signatureValidityStateGroupBox.TabIndex = 1;
         this._signatureValidityStateGroupBox.TabStop = false;
         this._signatureValidityStateGroupBox.Text = "Certificate Viewer";
         // 
         // _signatureValidityStateValueLabel
         // 
         this._signatureValidityStateValueLabel.AutoSize = true;
         this._signatureValidityStateValueLabel.Location = new System.Drawing.Point(105, 35);
         this._signatureValidityStateValueLabel.Name = "_signatureValidityStateValueLabel";
         this._signatureValidityStateValueLabel.Size = new System.Drawing.Size(49, 13);
         this._signatureValidityStateValueLabel.TabIndex = 1;
         this._signatureValidityStateValueLabel.Text = "_______";
         // 
         // _signatureValidityStateLabel
         // 
         this._signatureValidityStateLabel.AutoSize = true;
         this._signatureValidityStateLabel.Location = new System.Drawing.Point(6, 35);
         this._signatureValidityStateLabel.Name = "_signatureValidityStateLabel";
         this._signatureValidityStateLabel.Size = new System.Drawing.Size(103, 13);
         this._signatureValidityStateLabel.TabIndex = 0;
         this._signatureValidityStateLabel.Text = "Signature validity is ";
         // 
         // _okButton
         // 
         this._okButton.Location = new System.Drawing.Point(217, 494);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 2;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // DigitalSignaturesDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(521, 529);
         this.Controls.Add(this._okButton);
         this.Controls.Add(this._certificateTabControl);
         this.Controls.Add(this._signatureValidityStateGroupBox);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DigitalSignaturesDialog";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Certificate Details";
         this._certificateTabControl.ResumeLayout(false);
         this._summaryTabPage.ResumeLayout(false);
         this._summaryTabPage.PerformLayout();
         this._certificationInformationGroupBox.ResumeLayout(false);
         this._certificationInformationGroupBox.PerformLayout();
         this._detailsTabPage.ResumeLayout(false);
         this._detailsTabPage.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._certificateDataGridView)).EndInit();
         this._signatureValidityStateGroupBox.ResumeLayout(false);
         this._signatureValidityStateGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl _certificateTabControl;
      private System.Windows.Forms.TabPage _summaryTabPage;
      private System.Windows.Forms.TabPage _detailsTabPage;
      private System.Windows.Forms.GroupBox _signatureValidityStateGroupBox;
      private System.Windows.Forms.Label _intededUsageValueLabel;
      private System.Windows.Forms.Label _validToValueLabel;
      private System.Windows.Forms.Label _validFromValueLabel;
      private System.Windows.Forms.Label _issuedByValueLabel;
      private System.Windows.Forms.Label _signedByValueLabel;
      private System.Windows.Forms.Label _intededUsageLabel;
      private System.Windows.Forms.Label _validToLabel;
      private System.Windows.Forms.Label _validFromLabel;
      private System.Windows.Forms.Label _issuedByLabel;
      private System.Windows.Forms.Label _signedByLabel;
      private System.Windows.Forms.TextBox _valueDescriptionTextBox;
      private System.Windows.Forms.Label _certificateDataLabel;
      private System.Windows.Forms.DataGridView _certificateDataGridView;
      private System.Windows.Forms.DataGridViewTextBoxColumn _nameColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn _valueColumn;
      private System.Windows.Forms.Label _signatureValidityStateLabel;
      private System.Windows.Forms.GroupBox _certificationInformationGroupBox;
      private System.Windows.Forms.Label _certificationInformationLabel;
      private System.Windows.Forms.Label _signatureValidityStateValueLabel;
      private System.Windows.Forms.ToolTip toolTipControl;
      private System.Windows.Forms.Button _okButton;
   }
}