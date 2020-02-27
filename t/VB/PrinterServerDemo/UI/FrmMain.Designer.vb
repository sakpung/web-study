Imports Microsoft.VisualBasic
Imports System
Namespace ServerPrinterDemo.UI
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
         Me._lstBoxLog = New System.Windows.Forms.ListBox
         Me._btnCancel = New System.Windows.Forms.Button
         Me._txtPrinterName = New System.Windows.Forms.TextBox
         Me.label1 = New System.Windows.Forms.Label
         Me._btnChange = New System.Windows.Forms.Button
         Me._btnOpen = New System.Windows.Forms.Button
         Me._btnShow = New System.Windows.Forms.Button
         Me._btnClear = New System.Windows.Forms.Button
         Me._btnReadMe = New System.Windows.Forms.Button
         Me._grpNetworkPrinters.SuspendLayout()
         Me.SuspendLayout()
         '
         '_grpNetworkPrinters
         '
         Me._grpNetworkPrinters.Controls.Add(Me._lstBoxLog)
         Me._grpNetworkPrinters.Location = New System.Drawing.Point(12, 51)
         Me._grpNetworkPrinters.Name = "_grpNetworkPrinters"
         Me._grpNetworkPrinters.Size = New System.Drawing.Size(460, 374)
         Me._grpNetworkPrinters.TabIndex = 6
         Me._grpNetworkPrinters.TabStop = False
         Me._grpNetworkPrinters.Text = "Printer Log"
         '
         '_lstBoxLog
         '
         Me._lstBoxLog.FormattingEnabled = True
         Me._lstBoxLog.HorizontalScrollbar = True
         Me._lstBoxLog.Location = New System.Drawing.Point(6, 19)
         Me._lstBoxLog.Name = "_lstBoxLog"
         Me._lstBoxLog.Size = New System.Drawing.Size(448, 342)
         Me._lstBoxLog.TabIndex = 9
         '
         '_btnCancel
         '
         Me._btnCancel.Enabled = False
         Me._btnCancel.Location = New System.Drawing.Point(15, 499)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(457, 23)
         Me._btnCancel.TabIndex = 9
         Me._btnCancel.Text = "Cancel Printing"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         '_txtPrinterName
         '
         Me._txtPrinterName.BackColor = System.Drawing.Color.White
         Me._txtPrinterName.Enabled = False
         Me._txtPrinterName.Location = New System.Drawing.Point(91, 12)
         Me._txtPrinterName.Name = "_txtPrinterName"
         Me._txtPrinterName.Size = New System.Drawing.Size(312, 20)
         Me._txtPrinterName.TabIndex = 11
         '
         'label1
         '
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(12, 15)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(68, 13)
         Me.label1.TabIndex = 10
         Me.label1.Text = "Printer Name"
         '
         '_btnChange
         '
         Me._btnChange.Location = New System.Drawing.Point(409, 9)
         Me._btnChange.Name = "_btnChange"
         Me._btnChange.Size = New System.Drawing.Size(63, 23)
         Me._btnChange.TabIndex = 12
         Me._btnChange.Text = "Change"
         Me._btnChange.UseVisualStyleBackColor = True
         '
         '_btnOpen
         '
         Me._btnOpen.Enabled = False
         Me._btnOpen.Location = New System.Drawing.Point(15, 431)
         Me._btnOpen.Name = "_btnOpen"
         Me._btnOpen.Size = New System.Drawing.Size(75, 23)
         Me._btnOpen.TabIndex = 13
         Me._btnOpen.Text = "Open File"
         Me._btnOpen.UseVisualStyleBackColor = True
         '
         '_btnShow
         '
         Me._btnShow.Enabled = False
         Me._btnShow.Location = New System.Drawing.Point(96, 431)
         Me._btnShow.Name = "_btnShow"
         Me._btnShow.Size = New System.Drawing.Size(79, 23)
         Me._btnShow.TabIndex = 14
         Me._btnShow.Text = "Show Folder"
         Me._btnShow.UseVisualStyleBackColor = True
         '
         '_btnClear
         '
         Me._btnClear.Enabled = False
         Me._btnClear.Location = New System.Drawing.Point(393, 431)
         Me._btnClear.Name = "_btnClear"
         Me._btnClear.Size = New System.Drawing.Size(79, 23)
         Me._btnClear.TabIndex = 15
         Me._btnClear.Text = "Clear Log"
         Me._btnClear.UseVisualStyleBackColor = True
         '
         '_btnReadMe
         '
         Me._btnReadMe.Location = New System.Drawing.Point(393, 460)
         Me._btnReadMe.Name = "_btnReadMe"
         Me._btnReadMe.Size = New System.Drawing.Size(79, 23)
         Me._btnReadMe.TabIndex = 16
         Me._btnReadMe.Text = "Read Me"
         Me._btnReadMe.UseVisualStyleBackColor = True
         '
         'FrmMain
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(482, 534)
         Me.Controls.Add(Me._btnReadMe)
         Me.Controls.Add(Me._btnClear)
         Me.Controls.Add(Me._btnShow)
         Me.Controls.Add(Me._btnOpen)
         Me.Controls.Add(Me._btnChange)
         Me.Controls.Add(Me._txtPrinterName)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._grpNetworkPrinters)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.Name = "FrmMain"
         Me.Text = "LEADTOOLS Server Printer Demo"
         Me._grpNetworkPrinters.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

		#End Region

		Private _grpNetworkPrinters As System.Windows.Forms.GroupBox
		Private WithEvents _btnCancel As System.Windows.Forms.Button
		Private WithEvents _lstBoxLog As System.Windows.Forms.ListBox
		Private _txtPrinterName As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents _btnChange As System.Windows.Forms.Button
		Private WithEvents _btnOpen As System.Windows.Forms.Button
		Private WithEvents _btnShow As System.Windows.Forms.Button
      Private WithEvents _btnClear As System.Windows.Forms.Button
      Private WithEvents _btnReadMe As System.Windows.Forms.Button
	End Class
End Namespace