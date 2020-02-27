Imports Microsoft.VisualBasic
Imports System
Namespace ManagedPrinterClientDemo
	Public Partial Class MainForm
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._grpNetworkPrinters = New System.Windows.Forms.GroupBox
         Me._txtPrinterName = New System.Windows.Forms.TextBox
         Me.label1 = New System.Windows.Forms.Label
         Me._grpPrinterSettings = New System.Windows.Forms.GroupBox
         Me._grpSaveForamats = New System.Windows.Forms.GroupBox
         Me._txtSavePath = New System.Windows.Forms.TextBox
         Me.label3 = New System.Windows.Forms.Label
         Me._txtSaveName = New System.Windows.Forms.TextBox
         Me.label4 = New System.Windows.Forms.Label
         Me._cmbFileFormats = New System.Windows.Forms.ComboBox
         Me._lblFileFormat = New System.Windows.Forms.Label
         Me.label2 = New System.Windows.Forms.Label
         Me._txtPrinterDescription = New System.Windows.Forms.TextBox
         Me._btnOk = New System.Windows.Forms.Button
         Me._btnCancel = New System.Windows.Forms.Button
         Me._grpNetworkPrinters.SuspendLayout()
         Me._grpPrinterSettings.SuspendLayout()
         Me._grpSaveForamats.SuspendLayout()
         Me.SuspendLayout()
         '
         '_grpNetworkPrinters
         '
         Me._grpNetworkPrinters.Controls.Add(Me._txtPrinterName)
         Me._grpNetworkPrinters.Controls.Add(Me.label1)
         Me._grpNetworkPrinters.Location = New System.Drawing.Point(12, 12)
         Me._grpNetworkPrinters.Name = "_grpNetworkPrinters"
         Me._grpNetworkPrinters.Size = New System.Drawing.Size(460, 61)
         Me._grpNetworkPrinters.TabIndex = 7
         Me._grpNetworkPrinters.TabStop = False
         Me._grpNetworkPrinters.Text = "Network Printer"
         '
         '_txtPrinterName
         '
         Me._txtPrinterName.BackColor = System.Drawing.Color.White
         Me._txtPrinterName.Enabled = False
         Me._txtPrinterName.Location = New System.Drawing.Point(83, 24)
         Me._txtPrinterName.Name = "_txtPrinterName"
         Me._txtPrinterName.ReadOnly = True
         Me._txtPrinterName.Size = New System.Drawing.Size(371, 20)
         Me._txtPrinterName.TabIndex = 19
         '
         'label1
         '
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(6, 27)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(68, 13)
         Me.label1.TabIndex = 6
         Me.label1.Text = "Printer Name"
         '
         '_grpPrinterSettings
         '
         Me._grpPrinterSettings.Controls.Add(Me._grpSaveForamats)
         Me._grpPrinterSettings.Controls.Add(Me.label2)
         Me._grpPrinterSettings.Controls.Add(Me._txtPrinterDescription)
         Me._grpPrinterSettings.Location = New System.Drawing.Point(12, 79)
         Me._grpPrinterSettings.Name = "_grpPrinterSettings"
         Me._grpPrinterSettings.Size = New System.Drawing.Size(460, 285)
         Me._grpPrinterSettings.TabIndex = 9
         Me._grpPrinterSettings.TabStop = False
         Me._grpPrinterSettings.Text = "Printer Settings"
         '
         '_grpSaveForamats
         '
         Me._grpSaveForamats.Controls.Add(Me._txtSavePath)
         Me._grpSaveForamats.Controls.Add(Me.label3)
         Me._grpSaveForamats.Controls.Add(Me._txtSaveName)
         Me._grpSaveForamats.Controls.Add(Me.label4)
         Me._grpSaveForamats.Controls.Add(Me._cmbFileFormats)
         Me._grpSaveForamats.Controls.Add(Me._lblFileFormat)
         Me._grpSaveForamats.Location = New System.Drawing.Point(9, 131)
         Me._grpSaveForamats.Name = "_grpSaveForamats"
         Me._grpSaveForamats.Size = New System.Drawing.Size(445, 133)
         Me._grpSaveForamats.TabIndex = 0
         Me._grpSaveForamats.TabStop = False
         Me._grpSaveForamats.Text = "Save Formats"
         '
         '_txtSavePath
         '
         Me._txtSavePath.BackColor = System.Drawing.Color.White
         Me._txtSavePath.Enabled = False
         Me._txtSavePath.Location = New System.Drawing.Point(110, 43)
         Me._txtSavePath.Name = "_txtSavePath"
         Me._txtSavePath.Size = New System.Drawing.Size(316, 20)
         Me._txtSavePath.TabIndex = 20
         '
         'label3
         '
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(107, 27)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(57, 13)
         Me.label3.TabIndex = 19
         Me.label3.Text = "Save Path"
         '
         '_txtSaveName
         '
         Me._txtSaveName.Location = New System.Drawing.Point(9, 92)
         Me._txtSaveName.Name = "_txtSaveName"
         Me._txtSaveName.Size = New System.Drawing.Size(417, 20)
         Me._txtSaveName.TabIndex = 0
         '
         'label4
         '
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(6, 76)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(54, 13)
         Me.label4.TabIndex = 17
         Me.label4.Text = "File Name"
         '
         '_cmbFileFormats
         '
         Me._cmbFileFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbFileFormats.FormattingEnabled = True
         Me._cmbFileFormats.Location = New System.Drawing.Point(6, 43)
         Me._cmbFileFormats.Name = "_cmbFileFormats"
         Me._cmbFileFormats.Size = New System.Drawing.Size(84, 21)
         Me._cmbFileFormats.TabIndex = 16
         '
         '_lblFileFormat
         '
         Me._lblFileFormat.AutoSize = True
         Me._lblFileFormat.Location = New System.Drawing.Point(6, 27)
         Me._lblFileFormat.Name = "_lblFileFormat"
         Me._lblFileFormat.Size = New System.Drawing.Size(58, 13)
         Me._lblFileFormat.TabIndex = 15
         Me._lblFileFormat.Text = "File Foramt"
         '
         'label2
         '
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(6, 29)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(93, 13)
         Me.label2.TabIndex = 9
         Me.label2.Text = "Printer Description"
         '
         '_txtPrinterDescription
         '
         Me._txtPrinterDescription.BackColor = System.Drawing.Color.White
         Me._txtPrinterDescription.Location = New System.Drawing.Point(9, 51)
         Me._txtPrinterDescription.Multiline = True
         Me._txtPrinterDescription.Name = "_txtPrinterDescription"
         Me._txtPrinterDescription.ReadOnly = True
         Me._txtPrinterDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
         Me._txtPrinterDescription.Size = New System.Drawing.Size(445, 74)
         Me._txtPrinterDescription.TabIndex = 8
         '
         '_btnOk
         '
         Me._btnOk.Location = New System.Drawing.Point(12, 370)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(127, 23)
         Me._btnOk.TabIndex = 21
         Me._btnOk.Text = "Ok"
         Me._btnOk.UseVisualStyleBackColor = True
         '
         '_btnCancel
         '
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(345, 370)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(127, 23)
         Me._btnCancel.TabIndex = 20
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         'MainForm
         '
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(491, 407)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._grpPrinterSettings)
         Me.Controls.Add(Me._grpNetworkPrinters)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.Name = "MainForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "MainForm"
         Me._grpNetworkPrinters.ResumeLayout(False)
         Me._grpNetworkPrinters.PerformLayout()
         Me._grpPrinterSettings.ResumeLayout(False)
         Me._grpPrinterSettings.PerformLayout()
         Me._grpSaveForamats.ResumeLayout(False)
         Me._grpSaveForamats.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

		#End Region

		Private _grpNetworkPrinters As System.Windows.Forms.GroupBox
		Private _txtPrinterName As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private _grpPrinterSettings As System.Windows.Forms.GroupBox
		Private WithEvents _btnOk As System.Windows.Forms.Button
		Private _btnCancel As System.Windows.Forms.Button
		Private _grpSaveForamats As System.Windows.Forms.GroupBox
		Private WithEvents _txtSaveName As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents _cmbFileFormats As System.Windows.Forms.ComboBox
		Private _lblFileFormat As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private _txtPrinterDescription As System.Windows.Forms.TextBox
		Private _txtSavePath As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
	End Class
End Namespace