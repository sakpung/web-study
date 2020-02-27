Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
   Public Partial Class CalibrateRulerDialog
	  ''' <summary>
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary>
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		 If disposing AndAlso (Not components Is Nothing) Then
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
		 Me._btnApply = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOK = New System.Windows.Forms.Button()
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me._chkApplyToAll = New System.Windows.Forms.CheckBox()
		 Me._cmbUnit = New System.Windows.Forms.ComboBox()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me._txtDistance = New MedicalViewerLayoutDemo.FNumericTextBox()
		 Me.groupBox1.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _btnApply
		 ' 
		 Me._btnApply.Location = New System.Drawing.Point(156, 110)
		 Me._btnApply.Name = "_btnApply"
		 Me._btnApply.Size = New System.Drawing.Size(71, 29)
		 Me._btnApply.TabIndex = 19
		 Me._btnApply.Text = "App&ly"
		 Me._btnApply.UseVisualStyleBackColor = True
'		 Me._btnApply.Click += New System.EventHandler(Me.applyButton_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(80, 110)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(71, 29)
		 Me._btnCancel.TabIndex = 18
		 Me._btnCancel.Text = "Canc&el"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _btnOK
		 ' 
		 Me._btnOK.Location = New System.Drawing.Point(5, 110)
		 Me._btnOK.Name = "_btnOK"
		 Me._btnOK.Size = New System.Drawing.Size(71, 29)
		 Me._btnOK.TabIndex = 17
		 Me._btnOK.Text = "&OK"
		 Me._btnOK.UseVisualStyleBackColor = True
'		 Me._btnOK.Click += New System.EventHandler(Me.okButton_Click);
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me._chkApplyToAll)
		 Me.groupBox1.Controls.Add(Me._txtDistance)
		 Me.groupBox1.Controls.Add(Me._cmbUnit)
		 Me.groupBox1.Controls.Add(Me.label1)
		 Me.groupBox1.Location = New System.Drawing.Point(6, 7)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(218, 96)
		 Me.groupBox1.TabIndex = 16
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "&Arrow Properties"
		 ' 
		 ' _chkApplyToAll
		 ' 
		 Me._chkApplyToAll.AutoSize = True
		 Me._chkApplyToAll.Location = New System.Drawing.Point(9, 68)
		 Me._chkApplyToAll.Name = "_chkApplyToAll"
		 Me._chkApplyToAll.Size = New System.Drawing.Size(121, 17)
		 Me._chkApplyToAll.TabIndex = 5
		 Me._chkApplyToAll.Text = "A&pply to all sub-cells"
		 Me._chkApplyToAll.UseVisualStyleBackColor = True
		 ' 
		 ' _cmbUnit
		 ' 
		 Me._cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbUnit.FormattingEnabled = True
		 Me._cmbUnit.Items.AddRange(New Object() { "Inches", "Feet", "Micrometers", "Millimeters", "Centimeters", "Meters"})
		 Me._cmbUnit.Location = New System.Drawing.Point(111, 27)
		 Me._cmbUnit.Name = "_cmbUnit"
		 Me._cmbUnit.Size = New System.Drawing.Size(96, 21)
		 Me._cmbUnit.TabIndex = 1
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(7, 31)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(49, 13)
		 Me.label1.TabIndex = 0
		 Me.label1.Text = "&Distance"
		 ' 
		 ' _txtDistance
		 ' 
		 Me._txtDistance.Location = New System.Drawing.Point(65, 28)
		 Me._txtDistance.MaximumAllowed = 100
		 Me._txtDistance.MinimumAllowed = 0.1
		 Me._txtDistance.Name = "_txtDistance"
		 Me._txtDistance.Size = New System.Drawing.Size(41, 20)
		 Me._txtDistance.TabIndex = 4
		 Me._txtDistance.Text = "0"
		 Me._txtDistance.Value = 0
		 ' 
		 ' CalibrateRulerDialog
		 ' 
		 Me.AcceptButton = Me._btnOK
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(231, 146)
		 Me.Controls.Add(Me._btnApply)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOK)
		 Me.Controls.Add(Me.groupBox1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "CalibrateRulerDialog"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Calibrate Dialog"
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private WithEvents _btnApply As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOK As System.Windows.Forms.Button
	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private _cmbUnit As System.Windows.Forms.ComboBox
	  Private label1 As System.Windows.Forms.Label
	  Private _chkApplyToAll As System.Windows.Forms.CheckBox
	  Private _txtDistance As FNumericTextBox
   End Class
End Namespace