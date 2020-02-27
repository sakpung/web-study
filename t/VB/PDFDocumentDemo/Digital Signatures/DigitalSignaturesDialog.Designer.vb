Imports Microsoft.VisualBasic

Namespace PDFDocumentDemo
   Partial Class DigitalSignaturesDialog
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container()
         Me._certificateTabControl = New System.Windows.Forms.TabControl()
         Me._summaryTabPage = New System.Windows.Forms.TabPage()
         Me._certificationInformationGroupBox = New System.Windows.Forms.GroupBox()
         Me._certificationInformationLabel = New System.Windows.Forms.Label()
         Me._intededUsageValueLabel = New System.Windows.Forms.Label()
         Me._validToValueLabel = New System.Windows.Forms.Label()
         Me._validFromValueLabel = New System.Windows.Forms.Label()
         Me._issuedByValueLabel = New System.Windows.Forms.Label()
         Me._signedByValueLabel = New System.Windows.Forms.Label()
         Me._intededUsageLabel = New System.Windows.Forms.Label()
         Me._validToLabel = New System.Windows.Forms.Label()
         Me._validFromLabel = New System.Windows.Forms.Label()
         Me._issuedByLabel = New System.Windows.Forms.Label()
         Me._signedByLabel = New System.Windows.Forms.Label()
         Me._detailsTabPage = New System.Windows.Forms.TabPage()
         Me._valueDescriptionTextBox = New System.Windows.Forms.TextBox()
         Me._certificateDataLabel = New System.Windows.Forms.Label()
         Me._certificateDataGridView = New System.Windows.Forms.DataGridView()
         Me._nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me._valueColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
         Me._signatureValidityStateGroupBox = New System.Windows.Forms.GroupBox()
         Me._signatureValidityStateValueLabel = New System.Windows.Forms.Label()
         Me._signatureValidityStateLabel = New System.Windows.Forms.Label()
         Me.toolTipControl = New System.Windows.Forms.ToolTip(Me.components)
         Me._okButton = New System.Windows.Forms.Button()
         Me._certificateTabControl.SuspendLayout()
         Me._summaryTabPage.SuspendLayout()
         Me._certificationInformationGroupBox.SuspendLayout()
         Me._detailsTabPage.SuspendLayout()
         CType(Me._certificateDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._signatureValidityStateGroupBox.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _certificateTabControl
         ' 
         Me._certificateTabControl.Controls.Add(Me._summaryTabPage)
         Me._certificateTabControl.Controls.Add(Me._detailsTabPage)
         Me._certificateTabControl.Location = New System.Drawing.Point(12, 89)
         Me._certificateTabControl.Name = "_certificateTabControl"
         Me._certificateTabControl.SelectedIndex = 0
         Me._certificateTabControl.Size = New System.Drawing.Size(491, 397)
         Me._certificateTabControl.TabIndex = 0
         ' 
         ' _summaryTabPage
         ' 
         Me._summaryTabPage.BackColor = System.Drawing.Color.White
         Me._summaryTabPage.Controls.Add(Me._certificationInformationGroupBox)
         Me._summaryTabPage.Controls.Add(Me._intededUsageValueLabel)
         Me._summaryTabPage.Controls.Add(Me._validToValueLabel)
         Me._summaryTabPage.Controls.Add(Me._validFromValueLabel)
         Me._summaryTabPage.Controls.Add(Me._issuedByValueLabel)
         Me._summaryTabPage.Controls.Add(Me._signedByValueLabel)
         Me._summaryTabPage.Controls.Add(Me._intededUsageLabel)
         Me._summaryTabPage.Controls.Add(Me._validToLabel)
         Me._summaryTabPage.Controls.Add(Me._validFromLabel)
         Me._summaryTabPage.Controls.Add(Me._issuedByLabel)
         Me._summaryTabPage.Controls.Add(Me._signedByLabel)
         Me._summaryTabPage.Location = New System.Drawing.Point(4, 22)
         Me._summaryTabPage.Name = "_summaryTabPage"
         Me._summaryTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._summaryTabPage.Size = New System.Drawing.Size(483, 371)
         Me._summaryTabPage.TabIndex = 0
         Me._summaryTabPage.Text = "Summary"
         ' 
         ' _certificationInformationGroupBox
         ' 
         Me._certificationInformationGroupBox.BackColor = System.Drawing.Color.Transparent
         Me._certificationInformationGroupBox.Controls.Add(Me._certificationInformationLabel)
         Me._certificationInformationGroupBox.Location = New System.Drawing.Point(52, 250)
         Me._certificationInformationGroupBox.Name = "_certificationInformationGroupBox"
         Me._certificationInformationGroupBox.Size = New System.Drawing.Size(384, 105)
         Me._certificationInformationGroupBox.TabIndex = 10
         Me._certificationInformationGroupBox.TabStop = False
         Me._certificationInformationGroupBox.Text = "Certification Information"
         ' 
         ' _certificationInformationLabel
         ' 
         Me._certificationInformationLabel.Location = New System.Drawing.Point(27, 26)
         Me._certificationInformationLabel.Name = "_certificationInformationLabel"
         Me._certificationInformationLabel.Size = New System.Drawing.Size(346, 52)
         Me._certificationInformationLabel.TabIndex = 0
         Me._certificationInformationLabel.Text = "Signature is {0}, signed by {1}" & vbCr & vbLf & vbCr & vbLf & "The Document has not been modified since this " + "signature was applied ." & vbCr & vbLf & "The signer's identity is {2} ."
         ' 
         ' _intededUsageValueLabel
         ' 
         Me._intededUsageValueLabel.AutoSize = True
         Me._intededUsageValueLabel.Location = New System.Drawing.Point(125, 157)
         Me._intededUsageValueLabel.Name = "_intededUsageValueLabel"
         Me._intededUsageValueLabel.Size = New System.Drawing.Size(139, 13)
         Me._intededUsageValueLabel.TabIndex = 9
         Me._intededUsageValueLabel.Text = "______________________"
         ' 
         ' _validToValueLabel
         ' 
         Me._validToValueLabel.AutoSize = True
         Me._validToValueLabel.Location = New System.Drawing.Point(125, 129)
         Me._validToValueLabel.Name = "_validToValueLabel"
         Me._validToValueLabel.Size = New System.Drawing.Size(139, 13)
         Me._validToValueLabel.TabIndex = 8
         Me._validToValueLabel.Text = "______________________"
         ' 
         ' _validFromValueLabel
         ' 
         Me._validFromValueLabel.AutoSize = True
         Me._validFromValueLabel.Location = New System.Drawing.Point(125, 99)
         Me._validFromValueLabel.Name = "_validFromValueLabel"
         Me._validFromValueLabel.Size = New System.Drawing.Size(139, 13)
         Me._validFromValueLabel.TabIndex = 7
         Me._validFromValueLabel.Text = "______________________"
         ' 
         ' _issuedByValueLabel
         ' 
         Me._issuedByValueLabel.AutoSize = True
         Me._issuedByValueLabel.Location = New System.Drawing.Point(125, 69)
         Me._issuedByValueLabel.Name = "_issuedByValueLabel"
         Me._issuedByValueLabel.Size = New System.Drawing.Size(139, 13)
         Me._issuedByValueLabel.TabIndex = 6
         Me._issuedByValueLabel.Text = "______________________"
         ' 
         ' _signedByValueLabel
         ' 
         Me._signedByValueLabel.AutoSize = True
         Me._signedByValueLabel.Location = New System.Drawing.Point(125, 17)
         Me._signedByValueLabel.Name = "_signedByValueLabel"
         Me._signedByValueLabel.Size = New System.Drawing.Size(139, 13)
         Me._signedByValueLabel.TabIndex = 5
         Me._signedByValueLabel.Text = "______________________"
         ' 
         ' _intededUsageLabel
         ' 
         Me._intededUsageLabel.AutoSize = True
         Me._intededUsageLabel.Location = New System.Drawing.Point(27, 157)
         Me._intededUsageLabel.Name = "_intededUsageLabel"
         Me._intededUsageLabel.Size = New System.Drawing.Size(82, 13)
         Me._intededUsageLabel.TabIndex = 4
         Me._intededUsageLabel.Text = "Inteded Usage:"
         ' 
         ' _validToLabel
         ' 
         Me._validToLabel.AutoSize = True
         Me._validToLabel.Location = New System.Drawing.Point(61, 129)
         Me._validToLabel.Name = "_validToLabel"
         Me._validToLabel.Size = New System.Drawing.Size(48, 13)
         Me._validToLabel.TabIndex = 3
         Me._validToLabel.Text = "Valid To:"
         ' 
         ' _validFromLabel
         ' 
         Me._validFromLabel.AutoSize = True
         Me._validFromLabel.Location = New System.Drawing.Point(49, 99)
         Me._validFromLabel.Name = "_validFromLabel"
         Me._validFromLabel.Size = New System.Drawing.Size(60, 13)
         Me._validFromLabel.TabIndex = 2
         Me._validFromLabel.Text = "Valid From:"
         ' 
         ' _issuedByLabel
         ' 
         Me._issuedByLabel.AutoSize = True
         Me._issuedByLabel.Location = New System.Drawing.Point(49, 69)
         Me._issuedByLabel.Name = "_issuedByLabel"
         Me._issuedByLabel.Size = New System.Drawing.Size(58, 13)
         Me._issuedByLabel.TabIndex = 1
         Me._issuedByLabel.Text = "Issued By:"
         ' 
         ' _signedByLabel
         ' 
         Me._signedByLabel.AutoSize = True
         Me._signedByLabel.Location = New System.Drawing.Point(49, 17)
         Me._signedByLabel.Name = "_signedByLabel"
         Me._signedByLabel.Size = New System.Drawing.Size(58, 13)
         Me._signedByLabel.TabIndex = 0
         Me._signedByLabel.Text = "Signed By:"
         ' 
         ' _detailsTabPage
         ' 
         Me._detailsTabPage.BackColor = System.Drawing.Color.White
         Me._detailsTabPage.Controls.Add(Me._valueDescriptionTextBox)
         Me._detailsTabPage.Controls.Add(Me._certificateDataLabel)
         Me._detailsTabPage.Controls.Add(Me._certificateDataGridView)
         Me._detailsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._detailsTabPage.Name = "_detailsTabPage"
         Me._detailsTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._detailsTabPage.Size = New System.Drawing.Size(483, 371)
         Me._detailsTabPage.TabIndex = 1
         Me._detailsTabPage.Text = "Details"
         ' 
         ' _valueDescriptionTextBox
         ' 
         Me._valueDescriptionTextBox.BackColor = System.Drawing.Color.Gainsboro
         Me._valueDescriptionTextBox.Enabled = False
         Me._valueDescriptionTextBox.Location = New System.Drawing.Point(21, 260)
         Me._valueDescriptionTextBox.Multiline = True
         Me._valueDescriptionTextBox.Name = "_valueDescriptionTextBox"
         Me._valueDescriptionTextBox.Size = New System.Drawing.Size(443, 79)
         Me._valueDescriptionTextBox.TabIndex = 2
         ' 
         ' _certificateDataLabel
         ' 
         Me._certificateDataLabel.AutoSize = True
         Me._certificateDataLabel.Location = New System.Drawing.Point(18, 19)
         Me._certificateDataLabel.Name = "_certificateDataLabel"
         Me._certificateDataLabel.Size = New System.Drawing.Size(87, 13)
         Me._certificateDataLabel.TabIndex = 1
         Me._certificateDataLabel.Text = "Certificate Data:"
         ' 
         ' _certificateDataGridView
         ' 
         Me._certificateDataGridView.AllowUserToAddRows = False
         Me._certificateDataGridView.AllowUserToDeleteRows = False
         Me._certificateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
         Me._certificateDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me._nameColumn, Me._valueColumn})
         Me._certificateDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
         Me._certificateDataGridView.Location = New System.Drawing.Point(21, 46)
         Me._certificateDataGridView.MultiSelect = False
         Me._certificateDataGridView.Name = "_certificateDataGridView"
         Me._certificateDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
         Me._certificateDataGridView.RowHeadersWidth = 25
         Me._certificateDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
         Me._certificateDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
         Me._certificateDataGridView.Size = New System.Drawing.Size(443, 190)
         Me._certificateDataGridView.TabIndex = 0
         ' 
         ' _nameColumn
         ' 
         Me._nameColumn.HeaderText = "Name"
         Me._nameColumn.Name = "_nameColumn"
         ' 
         ' _valueColumn
         ' 
         Me._valueColumn.HeaderText = "Value"
         Me._valueColumn.Name = "_valueColumn"
         Me._valueColumn.Width = 300
         ' 
         ' _signatureValidityStateGroupBox
         ' 
         Me._signatureValidityStateGroupBox.Controls.Add(Me._signatureValidityStateValueLabel)
         Me._signatureValidityStateGroupBox.Controls.Add(Me._signatureValidityStateLabel)
         Me._signatureValidityStateGroupBox.Location = New System.Drawing.Point(12, 13)
         Me._signatureValidityStateGroupBox.Name = "_signatureValidityStateGroupBox"
         Me._signatureValidityStateGroupBox.Size = New System.Drawing.Size(491, 70)
         Me._signatureValidityStateGroupBox.TabIndex = 1
         Me._signatureValidityStateGroupBox.TabStop = False
         Me._signatureValidityStateGroupBox.Text = "Certificate Viewer"
         ' 
         ' _signatureValidityStateValueLabel
         ' 
         Me._signatureValidityStateValueLabel.AutoSize = True
         Me._signatureValidityStateValueLabel.Location = New System.Drawing.Point(105, 35)
         Me._signatureValidityStateValueLabel.Name = "_signatureValidityStateValueLabel"
         Me._signatureValidityStateValueLabel.Size = New System.Drawing.Size(49, 13)
         Me._signatureValidityStateValueLabel.TabIndex = 1
         Me._signatureValidityStateValueLabel.Text = "_______"
         ' 
         ' _signatureValidityStateLabel
         ' 
         Me._signatureValidityStateLabel.AutoSize = True
         Me._signatureValidityStateLabel.Location = New System.Drawing.Point(6, 35)
         Me._signatureValidityStateLabel.Name = "_signatureValidityStateLabel"
         Me._signatureValidityStateLabel.Size = New System.Drawing.Size(103, 13)
         Me._signatureValidityStateLabel.TabIndex = 0
         Me._signatureValidityStateLabel.Text = "Signature validity is "
         ' 
         ' _okButton
         ' 
         Me._okButton.Location = New System.Drawing.Point(217, 494)
         Me._okButton.Name = "_okButton"
         Me._okButton.Size = New System.Drawing.Size(75, 23)
         Me._okButton.TabIndex = 2
         Me._okButton.Text = "OK"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' DigitalSignaturesDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(521, 529)
         Me.Controls.Add(Me._okButton)
         Me.Controls.Add(Me._certificateTabControl)
         Me.Controls.Add(Me._signatureValidityStateGroupBox)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "DigitalSignaturesDialog"
         Me.ShowIcon = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Certificate Details"
         Me._certificateTabControl.ResumeLayout(False)
         Me._summaryTabPage.ResumeLayout(False)
         Me._summaryTabPage.PerformLayout()
         Me._certificationInformationGroupBox.ResumeLayout(False)
         Me._certificationInformationGroupBox.PerformLayout()
         Me._detailsTabPage.ResumeLayout(False)
         Me._detailsTabPage.PerformLayout()
         CType(Me._certificateDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
         Me._signatureValidityStateGroupBox.ResumeLayout(False)
         Me._signatureValidityStateGroupBox.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _certificateTabControl As System.Windows.Forms.TabControl
      Private _summaryTabPage As System.Windows.Forms.TabPage
      Private _detailsTabPage As System.Windows.Forms.TabPage
      Private _signatureValidityStateGroupBox As System.Windows.Forms.GroupBox
      Private _intededUsageValueLabel As System.Windows.Forms.Label
      Private _validToValueLabel As System.Windows.Forms.Label
      Private _validFromValueLabel As System.Windows.Forms.Label
      Private _issuedByValueLabel As System.Windows.Forms.Label
      Private _signedByValueLabel As System.Windows.Forms.Label
      Private _intededUsageLabel As System.Windows.Forms.Label
      Private _validToLabel As System.Windows.Forms.Label
      Private _validFromLabel As System.Windows.Forms.Label
      Private _issuedByLabel As System.Windows.Forms.Label
      Private _signedByLabel As System.Windows.Forms.Label
      Private _valueDescriptionTextBox As System.Windows.Forms.TextBox
      Private _certificateDataLabel As System.Windows.Forms.Label
      Private WithEvents _certificateDataGridView As System.Windows.Forms.DataGridView
      Private _nameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
      Private _valueColumn As System.Windows.Forms.DataGridViewTextBoxColumn
      Private _signatureValidityStateLabel As System.Windows.Forms.Label
      Private _certificationInformationGroupBox As System.Windows.Forms.GroupBox
      Private _certificationInformationLabel As System.Windows.Forms.Label
      Private _signatureValidityStateValueLabel As System.Windows.Forms.Label
      Private toolTipControl As System.Windows.Forms.ToolTip
      Private WithEvents _okButton As System.Windows.Forms.Button
   End Class
End Namespace