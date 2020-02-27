Imports Microsoft.VisualBasic
Imports System
Namespace PrinterClientInstaller
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
		   Me._grpPrinterInformation = New System.Windows.Forms.GroupBox()
		   Me._btnRefresh = New System.Windows.Forms.Button()
		   Me._txtServerName = New System.Windows.Forms.TextBox()
		   Me._cmbPrinters = New System.Windows.Forms.ComboBox()
		   Me.label3 = New System.Windows.Forms.Label()
		   Me._btnBrowse = New System.Windows.Forms.Button()
		   Me._txtPrinterDll = New System.Windows.Forms.TextBox()
		   Me.label2 = New System.Windows.Forms.Label()
		   Me.label1 = New System.Windows.Forms.Label()
		   Me._btnInstall = New System.Windows.Forms.Button()
		   Me._grpPrinterInformation.SuspendLayout()
		   Me.SuspendLayout()
		   ' 
		   ' _grpPrinterInformation
		   ' 
		   Me._grpPrinterInformation.Controls.Add(Me._btnRefresh)
		   Me._grpPrinterInformation.Controls.Add(Me._txtServerName)
		   Me._grpPrinterInformation.Controls.Add(Me._cmbPrinters)
		   Me._grpPrinterInformation.Controls.Add(Me.label3)
		   Me._grpPrinterInformation.Controls.Add(Me._btnBrowse)
		   Me._grpPrinterInformation.Controls.Add(Me._txtPrinterDll)
		   Me._grpPrinterInformation.Controls.Add(Me.label2)
		   Me._grpPrinterInformation.Controls.Add(Me.label1)
		   Me._grpPrinterInformation.Location = New System.Drawing.Point(12, 12)
		   Me._grpPrinterInformation.Name = "_grpPrinterInformation"
		   Me._grpPrinterInformation.Size = New System.Drawing.Size(538, 120)
		   Me._grpPrinterInformation.TabIndex = 0
		   Me._grpPrinterInformation.TabStop = False
		   Me._grpPrinterInformation.Text = "Network Printer"
		   ' 
		   ' _btnRefresh
		   ' 
		   Me._btnRefresh.Enabled = False
		   Me._btnRefresh.Location = New System.Drawing.Point(466, 52)
		   Me._btnRefresh.Name = "_btnRefresh"
		   Me._btnRefresh.Size = New System.Drawing.Size(58, 23)
		   Me._btnRefresh.TabIndex = 1
		   Me._btnRefresh.Text = "Refresh"
		   Me._btnRefresh.UseVisualStyleBackColor = True
'		   Me._btnRefresh.Click += New System.EventHandler(Me._btnRefresh_Click);
		   ' 
		   ' _txtServerName
		   ' 
		   Me._txtServerName.Location = New System.Drawing.Point(105, 24)
		   Me._txtServerName.Name = "_txtServerName"
		   Me._txtServerName.Size = New System.Drawing.Size(419, 20)
		   Me._txtServerName.TabIndex = 0
'		   Me._txtServerName.TextChanged += New System.EventHandler(Me._txtServerName_TextChanged);
		   ' 
		   ' _cmbPrinters
		   ' 
		   Me._cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		   Me._cmbPrinters.Enabled = False
		   Me._cmbPrinters.FormattingEnabled = True
		   Me._cmbPrinters.Location = New System.Drawing.Point(105, 54)
		   Me._cmbPrinters.Name = "_cmbPrinters"
		   Me._cmbPrinters.Size = New System.Drawing.Size(355, 21)
		   Me._cmbPrinters.TabIndex = 2
		   ' 
		   ' label3
		   ' 
		   Me.label3.AutoSize = True
		   Me.label3.Location = New System.Drawing.Point(6, 57)
		   Me.label3.Name = "label3"
		   Me.label3.Size = New System.Drawing.Size(68, 13)
		   Me.label3.TabIndex = 23
		   Me.label3.Text = "Printer Name"
		   ' 
		   ' _btnBrowse
		   ' 
		   Me._btnBrowse.Location = New System.Drawing.Point(497, 81)
		   Me._btnBrowse.Name = "_btnBrowse"
		   Me._btnBrowse.Size = New System.Drawing.Size(27, 23)
		   Me._btnBrowse.TabIndex = 3
		   Me._btnBrowse.Text = "..."
		   Me._btnBrowse.UseVisualStyleBackColor = True
'		   Me._btnBrowse.Click += New System.EventHandler(Me._btnBrowse_Click);
		   ' 
		   ' _txtPrinterDll
		   ' 
		   Me._txtPrinterDll.Location = New System.Drawing.Point(105, 81)
		   Me._txtPrinterDll.Name = "_txtPrinterDll"
		   Me._txtPrinterDll.Size = New System.Drawing.Size(386, 20)
		   Me._txtPrinterDll.TabIndex = 3
		   ' 
		   ' label2
		   ' 
		   Me.label2.AutoSize = True
		   Me.label2.Location = New System.Drawing.Point(6, 86)
		   Me.label2.Name = "label2"
		   Me.label2.Size = New System.Drawing.Size(83, 13)
		   Me.label2.TabIndex = 18
		   Me.label2.Text = "Printer Demo Dll"
		   ' 
		   ' label1
		   ' 
		   Me.label1.AutoSize = True
		   Me.label1.Location = New System.Drawing.Point(6, 27)
		   Me.label1.Name = "label1"
		   Me.label1.Size = New System.Drawing.Size(71, 13)
		   Me.label1.TabIndex = 6
		   Me.label1.Text = "Printer Server"
		   ' 
		   ' _btnInstall
		   ' 
		   Me._btnInstall.Location = New System.Drawing.Point(423, 156)
		   Me._btnInstall.Name = "_btnInstall"
		   Me._btnInstall.Size = New System.Drawing.Size(127, 23)
		   Me._btnInstall.TabIndex = 2
		   Me._btnInstall.Text = "Install"
		   Me._btnInstall.UseVisualStyleBackColor = True
'		   Me._btnInstall.Click += New System.EventHandler(Me._btnInstall_Click);
		   ' 
		   ' MainForm
		   ' 
		   Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		   Me.ClientSize = New System.Drawing.Size(562, 200)
		   Me.Controls.Add(Me._btnInstall)
		   Me.Controls.Add(Me._grpPrinterInformation)
		   Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		   Me.MaximizeBox = False
		   Me.MaximumSize = New System.Drawing.Size(578, 238)
		   Me.MinimumSize = New System.Drawing.Size(578, 238)
		   Me.Name = "MainForm"
		   Me.Text = "Client Printer Installation"
'		   Me.Load += New System.EventHandler(Me.MainForm_Load);
'		   Me.Shown += New System.EventHandler(Me.MainForm_Shown);
		   Me._grpPrinterInformation.ResumeLayout(False)
		   Me._grpPrinterInformation.PerformLayout()
		   Me.ResumeLayout(False)

		End Sub

		#End Region

		Private _grpPrinterInformation As System.Windows.Forms.GroupBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents _btnInstall As System.Windows.Forms.Button
		Private label2 As System.Windows.Forms.Label
		Private WithEvents _btnBrowse As System.Windows.Forms.Button
		Private _txtPrinterDll As System.Windows.Forms.TextBox
		Private _cmbPrinters As System.Windows.Forms.ComboBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents _btnRefresh As System.Windows.Forms.Button
		Private WithEvents _txtServerName As System.Windows.Forms.TextBox
	End Class
End Namespace