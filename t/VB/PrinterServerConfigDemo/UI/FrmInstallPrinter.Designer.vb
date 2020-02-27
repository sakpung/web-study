Imports Microsoft.VisualBasic
Imports System
Namespace PrinterDemo
   Public Partial Class FrmInstallPrinter
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
		  Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInstallPrinter))
		  Me._lblPrinterName = New System.Windows.Forms.Label()
		  Me._txtBoxPrinterName = New System.Windows.Forms.TextBox()
		  Me._btnOk = New System.Windows.Forms.Button()
		  Me._btnCancel = New System.Windows.Forms.Button()
		  Me._ckEnableNetwork = New System.Windows.Forms.CheckBox()
		  Me.SuspendLayout()
		  ' 
		  ' _lblPrinterName
		  ' 
		  Me._lblPrinterName.AutoSize = True
		  Me._lblPrinterName.Location = New System.Drawing.Point(12, 20)
		  Me._lblPrinterName.Name = "_lblPrinterName"
		  Me._lblPrinterName.Size = New System.Drawing.Size(68, 13)
		  Me._lblPrinterName.TabIndex = 0
		  Me._lblPrinterName.Text = "Printer Name"
		  ' 
		  ' _txtBoxPrinterName
		  ' 
		  Me._txtBoxPrinterName.Location = New System.Drawing.Point(115, 17)
		  Me._txtBoxPrinterName.Name = "_txtBoxPrinterName"
		  Me._txtBoxPrinterName.Size = New System.Drawing.Size(215, 20)
		  Me._txtBoxPrinterName.TabIndex = 1
'		  Me._txtBoxPrinterName.TextChanged += New System.EventHandler(Me._txtBoxPrinterName_TextChanged);
		  ' 
		  ' _btnOk
		  ' 
		  Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		  Me._btnOk.Enabled = False
		  Me._btnOk.Location = New System.Drawing.Point(200, 100)
		  Me._btnOk.Name = "_btnOk"
		  Me._btnOk.Size = New System.Drawing.Size(62, 29)
		  Me._btnOk.TabIndex = 5
		  Me._btnOk.Text = "Ok"
		  Me._btnOk.UseVisualStyleBackColor = True
		  ' 
		  ' _btnCancel
		  ' 
		  Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		  Me._btnCancel.Location = New System.Drawing.Point(268, 100)
		  Me._btnCancel.Name = "_btnCancel"
		  Me._btnCancel.Size = New System.Drawing.Size(62, 29)
		  Me._btnCancel.TabIndex = 6
		  Me._btnCancel.Text = "Cancel"
		  Me._btnCancel.UseVisualStyleBackColor = True
		  ' 
		  ' _ckEnableNetwork
		  ' 
		  Me._ckEnableNetwork.AutoSize = True
		  Me._ckEnableNetwork.Checked = True
		  Me._ckEnableNetwork.CheckState = System.Windows.Forms.CheckState.Checked
		  Me._ckEnableNetwork.Enabled = False
		  Me._ckEnableNetwork.Location = New System.Drawing.Point(115, 55)
		  Me._ckEnableNetwork.Name = "_ckEnableNetwork"
		  Me._ckEnableNetwork.Size = New System.Drawing.Size(140, 17)
		  Me._ckEnableNetwork.TabIndex = 7
		  Me._ckEnableNetwork.Text = "Enable Network Printing"
		  Me._ckEnableNetwork.UseVisualStyleBackColor = True
		  ' 
		  ' FrmInstallPrinter
		  ' 
		  Me.AcceptButton = Me._btnOk
		  Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		  Me.CancelButton = Me._btnCancel
		  Me.ClientSize = New System.Drawing.Size(341, 134)
		  Me.Controls.Add(Me._ckEnableNetwork)
		  Me.Controls.Add(Me._btnOk)
		  Me.Controls.Add(Me._btnCancel)
		  Me.Controls.Add(Me._txtBoxPrinterName)
		  Me.Controls.Add(Me._lblPrinterName)
		  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		  Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		  Me.MaximizeBox = False
		  Me.MinimizeBox = False
		  Me.Name = "FrmInstallPrinter"
		  Me.ShowIcon = False
		  Me.ShowInTaskbar = False
		  Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		  Me.Text = "Install Printer"
'		  Me.Load += New System.EventHandler(Me.FrmInstallPrinter_Load);
'		  Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.FrmInstallPrinter_FormClosing);
		  Me.ResumeLayout(False)
		  Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _lblPrinterName As System.Windows.Forms.Label
	  Private WithEvents _txtBoxPrinterName As System.Windows.Forms.TextBox
	  Private _btnOk As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
	  Private _ckEnableNetwork As System.Windows.Forms.CheckBox
   End Class
End Namespace