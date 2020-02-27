Imports Microsoft.VisualBasic
Imports System
Namespace ServerPrinterConfigDemo.UI
	Public Partial Class FrmMain
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
         Me._grpNetworkPrinters = New System.Windows.Forms.GroupBox
         Me._btnUninstall = New System.Windows.Forms.Button
         Me._ckSharePrinter = New System.Windows.Forms.CheckBox
         Me._ckNetworkEnabled = New System.Windows.Forms.CheckBox
         Me._btnAddNewPrinter = New System.Windows.Forms.Button
         Me._cmbNetworkPrinters = New System.Windows.Forms.ComboBox
         Me.label1 = New System.Windows.Forms.Label
         Me._grpPrinterSettings = New System.Windows.Forms.GroupBox
         Me._btnSave = New System.Windows.Forms.Button
         Me._grpSaveForamats = New System.Windows.Forms.GroupBox
         Me.label7 = New System.Windows.Forms.Label
         Me._btnBrowseTxt = New System.Windows.Forms.Button
         Me._txtLocationTxt = New System.Windows.Forms.TextBox
         Me.label6 = New System.Windows.Forms.Label
         Me._btnBrowseXps = New System.Windows.Forms.Button
         Me._txtLocationXps = New System.Windows.Forms.TextBox
         Me.label5 = New System.Windows.Forms.Label
         Me._btnBrowseDoc = New System.Windows.Forms.Button
         Me._txtLocationDoc = New System.Windows.Forms.TextBox
         Me.label3 = New System.Windows.Forms.Label
         Me._btnBrowsePdf = New System.Windows.Forms.Button
         Me._txtLocationPDF = New System.Windows.Forms.TextBox
         Me.label4 = New System.Windows.Forms.Label
         Me.label2 = New System.Windows.Forms.Label
         Me._txtPrinterDescription = New System.Windows.Forms.TextBox
         Me._grpNetworkPrinters.SuspendLayout()
         Me._grpPrinterSettings.SuspendLayout()
         Me._grpSaveForamats.SuspendLayout()
         Me.SuspendLayout()
         '
         '_grpNetworkPrinters
         '
         Me._grpNetworkPrinters.Controls.Add(Me._btnUninstall)
         Me._grpNetworkPrinters.Controls.Add(Me._ckSharePrinter)
         Me._grpNetworkPrinters.Controls.Add(Me._ckNetworkEnabled)
         Me._grpNetworkPrinters.Controls.Add(Me._btnAddNewPrinter)
         Me._grpNetworkPrinters.Controls.Add(Me._cmbNetworkPrinters)
         Me._grpNetworkPrinters.Controls.Add(Me.label1)
         Me._grpNetworkPrinters.Location = New System.Drawing.Point(12, 12)
         Me._grpNetworkPrinters.Name = "_grpNetworkPrinters"
         Me._grpNetworkPrinters.Size = New System.Drawing.Size(460, 153)
         Me._grpNetworkPrinters.TabIndex = 6
         Me._grpNetworkPrinters.TabStop = False
         Me._grpNetworkPrinters.Text = "Network Printers"
         '
         '_btnUninstall
         '
         Me._btnUninstall.Location = New System.Drawing.Point(356, 57)
         Me._btnUninstall.Name = "_btnUninstall"
         Me._btnUninstall.Size = New System.Drawing.Size(98, 21)
         Me._btnUninstall.TabIndex = 11
         Me._btnUninstall.Text = "Uninstall Printer"
         Me._btnUninstall.UseVisualStyleBackColor = True
         '
         '_ckSharePrinter
         '
         Me._ckSharePrinter.AutoSize = True
         Me._ckSharePrinter.Location = New System.Drawing.Point(6, 129)
         Me._ckSharePrinter.Name = "_ckSharePrinter"
         Me._ckSharePrinter.Size = New System.Drawing.Size(130, 17)
         Me._ckSharePrinter.TabIndex = 10
         Me._ckSharePrinter.Text = "Share Network Printer"
         Me._ckSharePrinter.UseVisualStyleBackColor = True
         '
         '_ckNetworkEnabled
         '
         Me._ckNetworkEnabled.AutoSize = True
         Me._ckNetworkEnabled.Location = New System.Drawing.Point(6, 106)
         Me._ckNetworkEnabled.Name = "_ckNetworkEnabled"
         Me._ckNetworkEnabled.Size = New System.Drawing.Size(140, 17)
         Me._ckNetworkEnabled.TabIndex = 9
         Me._ckNetworkEnabled.Text = "Enable Network Printing"
         Me._ckNetworkEnabled.UseVisualStyleBackColor = True
         '
         '_btnAddNewPrinter
         '
         Me._btnAddNewPrinter.Location = New System.Drawing.Point(356, 30)
         Me._btnAddNewPrinter.Name = "_btnAddNewPrinter"
         Me._btnAddNewPrinter.Size = New System.Drawing.Size(98, 21)
         Me._btnAddNewPrinter.TabIndex = 8
         Me._btnAddNewPrinter.Text = "Install Printer"
         Me._btnAddNewPrinter.UseVisualStyleBackColor = True
         '
         '_cmbNetworkPrinters
         '
         Me._cmbNetworkPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbNetworkPrinters.FormattingEnabled = True
         Me._cmbNetworkPrinters.Location = New System.Drawing.Point(80, 31)
         Me._cmbNetworkPrinters.Name = "_cmbNetworkPrinters"
         Me._cmbNetworkPrinters.Size = New System.Drawing.Size(270, 21)
         Me._cmbNetworkPrinters.TabIndex = 7
         '
         'label1
         '
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(6, 34)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(68, 13)
         Me.label1.TabIndex = 6
         Me.label1.Text = "Printer Name"
         '
         '_grpPrinterSettings
         '
         Me._grpPrinterSettings.Controls.Add(Me._btnSave)
         Me._grpPrinterSettings.Controls.Add(Me._grpSaveForamats)
         Me._grpPrinterSettings.Controls.Add(Me.label2)
         Me._grpPrinterSettings.Controls.Add(Me._txtPrinterDescription)
         Me._grpPrinterSettings.Location = New System.Drawing.Point(12, 175)
         Me._grpPrinterSettings.Name = "_grpPrinterSettings"
         Me._grpPrinterSettings.Size = New System.Drawing.Size(460, 380)
         Me._grpPrinterSettings.TabIndex = 8
         Me._grpPrinterSettings.TabStop = False
         Me._grpPrinterSettings.Text = "Printer Settings"
         '
         '_btnSave
         '
         Me._btnSave.Location = New System.Drawing.Point(327, 344)
         Me._btnSave.Name = "_btnSave"
         Me._btnSave.Size = New System.Drawing.Size(127, 23)
         Me._btnSave.TabIndex = 21
         Me._btnSave.Text = "Save"
         Me._btnSave.UseVisualStyleBackColor = True
         '
         '_grpSaveForamats
         '
         Me._grpSaveForamats.Controls.Add(Me.label7)
         Me._grpSaveForamats.Controls.Add(Me._btnBrowseTxt)
         Me._grpSaveForamats.Controls.Add(Me._txtLocationTxt)
         Me._grpSaveForamats.Controls.Add(Me.label6)
         Me._grpSaveForamats.Controls.Add(Me._btnBrowseXps)
         Me._grpSaveForamats.Controls.Add(Me._txtLocationXps)
         Me._grpSaveForamats.Controls.Add(Me.label5)
         Me._grpSaveForamats.Controls.Add(Me._btnBrowseDoc)
         Me._grpSaveForamats.Controls.Add(Me._txtLocationDoc)
         Me._grpSaveForamats.Controls.Add(Me.label3)
         Me._grpSaveForamats.Controls.Add(Me._btnBrowsePdf)
         Me._grpSaveForamats.Controls.Add(Me._txtLocationPDF)
         Me._grpSaveForamats.Controls.Add(Me.label4)
         Me._grpSaveForamats.Location = New System.Drawing.Point(9, 134)
         Me._grpSaveForamats.Name = "_grpSaveForamats"
         Me._grpSaveForamats.Size = New System.Drawing.Size(426, 179)
         Me._grpSaveForamats.TabIndex = 15
         Me._grpSaveForamats.TabStop = False
         Me._grpSaveForamats.Text = "Save Formats"
         '
         'label7
         '
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(6, 137)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(28, 13)
         Me.label7.TabIndex = 31
         Me.label7.Text = "Text"
         '
         '_btnBrowseTxt
         '
         Me._btnBrowseTxt.Location = New System.Drawing.Point(388, 134)
         Me._btnBrowseTxt.Name = "_btnBrowseTxt"
         Me._btnBrowseTxt.Size = New System.Drawing.Size(28, 23)
         Me._btnBrowseTxt.TabIndex = 30
         Me._btnBrowseTxt.Tag = "3"
         Me._btnBrowseTxt.Text = "..."
         Me._btnBrowseTxt.UseVisualStyleBackColor = True
         '
         '_txtLocationTxt
         '
         Me._txtLocationTxt.Location = New System.Drawing.Point(40, 134)
         Me._txtLocationTxt.Name = "_txtLocationTxt"
         Me._txtLocationTxt.Size = New System.Drawing.Size(342, 20)
         Me._txtLocationTxt.TabIndex = 29
         Me._txtLocationTxt.Tag = "3"
         '
         'label6
         '
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(6, 111)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(25, 13)
         Me.label6.TabIndex = 28
         Me.label6.Text = "Xps"
         '
         '_btnBrowseXps
         '
         Me._btnBrowseXps.Location = New System.Drawing.Point(388, 108)
         Me._btnBrowseXps.Name = "_btnBrowseXps"
         Me._btnBrowseXps.Size = New System.Drawing.Size(28, 23)
         Me._btnBrowseXps.TabIndex = 27
         Me._btnBrowseXps.Tag = "2"
         Me._btnBrowseXps.Text = "..."
         Me._btnBrowseXps.UseVisualStyleBackColor = True
         '
         '_txtLocationXps
         '
         Me._txtLocationXps.Location = New System.Drawing.Point(40, 108)
         Me._txtLocationXps.Name = "_txtLocationXps"
         Me._txtLocationXps.Size = New System.Drawing.Size(342, 20)
         Me._txtLocationXps.TabIndex = 26
         Me._txtLocationXps.Tag = "2"
         '
         'label5
         '
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(6, 85)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(27, 13)
         Me.label5.TabIndex = 25
         Me.label5.Text = "Doc"
         '
         '_btnBrowseDoc
         '
         Me._btnBrowseDoc.Location = New System.Drawing.Point(388, 82)
         Me._btnBrowseDoc.Name = "_btnBrowseDoc"
         Me._btnBrowseDoc.Size = New System.Drawing.Size(28, 23)
         Me._btnBrowseDoc.TabIndex = 24
         Me._btnBrowseDoc.Tag = "1"
         Me._btnBrowseDoc.Text = "..."
         Me._btnBrowseDoc.UseVisualStyleBackColor = True
         '
         '_txtLocationDoc
         '
         Me._txtLocationDoc.Location = New System.Drawing.Point(40, 82)
         Me._txtLocationDoc.Name = "_txtLocationDoc"
         Me._txtLocationDoc.Size = New System.Drawing.Size(342, 20)
         Me._txtLocationDoc.TabIndex = 23
         Me._txtLocationDoc.Tag = "1"
         '
         'label3
         '
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(6, 59)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(23, 13)
         Me.label3.TabIndex = 22
         Me.label3.Text = "Pdf"
         '
         '_btnBrowsePdf
         '
         Me._btnBrowsePdf.Location = New System.Drawing.Point(388, 56)
         Me._btnBrowsePdf.Name = "_btnBrowsePdf"
         Me._btnBrowsePdf.Size = New System.Drawing.Size(28, 23)
         Me._btnBrowsePdf.TabIndex = 21
         Me._btnBrowsePdf.Tag = "0"
         Me._btnBrowsePdf.Text = "..."
         Me._btnBrowsePdf.UseVisualStyleBackColor = True
         '
         '_txtLocationPDF
         '
         Me._txtLocationPDF.Location = New System.Drawing.Point(40, 56)
         Me._txtLocationPDF.Name = "_txtLocationPDF"
         Me._txtLocationPDF.Size = New System.Drawing.Size(342, 20)
         Me._txtLocationPDF.TabIndex = 18
         Me._txtLocationPDF.Tag = "0"
         '
         'label4
         '
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(37, 29)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(76, 13)
         Me.label4.TabIndex = 17
         Me.label4.Text = "Save Location"
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
         Me._txtPrinterDescription.Location = New System.Drawing.Point(6, 45)
         Me._txtPrinterDescription.Multiline = True
         Me._txtPrinterDescription.Name = "_txtPrinterDescription"
         Me._txtPrinterDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
         Me._txtPrinterDescription.Size = New System.Drawing.Size(429, 74)
         Me._txtPrinterDescription.TabIndex = 8
         '
         'FrmMain
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(482, 565)
         Me.Controls.Add(Me._grpPrinterSettings)
         Me.Controls.Add(Me._grpNetworkPrinters)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.MaximumSize = New System.Drawing.Size(498, 603)
         Me.MinimumSize = New System.Drawing.Size(498, 603)
         Me.Name = "FrmMain"
         Me.Text = "FrmMain"
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
		Private WithEvents _btnAddNewPrinter As System.Windows.Forms.Button
		Private WithEvents _cmbNetworkPrinters As System.Windows.Forms.ComboBox
		Private label1 As System.Windows.Forms.Label
		Private _grpPrinterSettings As System.Windows.Forms.GroupBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents _txtPrinterDescription As System.Windows.Forms.TextBox
		Private WithEvents _btnSave As System.Windows.Forms.Button
		Private _grpSaveForamats As System.Windows.Forms.GroupBox
		Private WithEvents _txtLocationPDF As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents _ckNetworkEnabled As System.Windows.Forms.CheckBox
		Private WithEvents _btnBrowsePdf As System.Windows.Forms.Button
		Private label7 As System.Windows.Forms.Label
		Private WithEvents _btnBrowseTxt As System.Windows.Forms.Button
		Private WithEvents _txtLocationTxt As System.Windows.Forms.TextBox
		Private label6 As System.Windows.Forms.Label
		Private WithEvents _btnBrowseXps As System.Windows.Forms.Button
		Private WithEvents _txtLocationXps As System.Windows.Forms.TextBox
		Private label5 As System.Windows.Forms.Label
		Private WithEvents _btnBrowseDoc As System.Windows.Forms.Button
		Private WithEvents _txtLocationDoc As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents _ckSharePrinter As System.Windows.Forms.CheckBox
		Private WithEvents _btnUninstall As System.Windows.Forms.Button
	End Class
End Namespace