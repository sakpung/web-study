Imports Microsoft.VisualBasic
Imports System
Namespace ServerPrinterDemo
   Public Partial Class FrmGetPrinterName
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
		  Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGetPrinterName))
		  Me._lblSelectActivePrinter = New System.Windows.Forms.Label()
		  Me._cmbPrintersList = New System.Windows.Forms.ComboBox()
		  Me._btnCancel = New System.Windows.Forms.Button()
		  Me._btnOk = New System.Windows.Forms.Button()
		  Me.SuspendLayout()
		  ' 
		  ' _lblSelectActivePrinter
		  ' 
		  Me._lblSelectActivePrinter.AutoSize = True
		  Me._lblSelectActivePrinter.Location = New System.Drawing.Point(19, 9)
		  Me._lblSelectActivePrinter.Name = "_lblSelectActivePrinter"
		  Me._lblSelectActivePrinter.Size = New System.Drawing.Size(260, 13)
		  Me._lblSelectActivePrinter.TabIndex = 0
		  Me._lblSelectActivePrinter.Text = "Please choose the active printer, or create a new one"
		  ' 
		  ' _cmbPrintersList
		  ' 
		  Me._cmbPrintersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		  Me._cmbPrintersList.FormattingEnabled = True
		  Me._cmbPrintersList.Location = New System.Drawing.Point(22, 37)
		  Me._cmbPrintersList.Name = "_cmbPrintersList"
		  Me._cmbPrintersList.Size = New System.Drawing.Size(282, 21)
		  Me._cmbPrintersList.TabIndex = 1
		  ' 
		  ' _btnCancel
		  ' 
		  Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		  Me._btnCancel.Location = New System.Drawing.Point(242, 81)
		  Me._btnCancel.Name = "_btnCancel"
		  Me._btnCancel.Size = New System.Drawing.Size(62, 29)
		  Me._btnCancel.TabIndex = 4
		  Me._btnCancel.Text = "Cancel"
		  Me._btnCancel.UseVisualStyleBackColor = True
		  ' 
		  ' _btnOk
		  ' 
		  Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		  Me._btnOk.Location = New System.Drawing.Point(172, 81)
		  Me._btnOk.Name = "_btnOk"
		  Me._btnOk.Size = New System.Drawing.Size(62, 29)
		  Me._btnOk.TabIndex = 3
		  Me._btnOk.Text = "Ok"
		  Me._btnOk.UseVisualStyleBackColor = True
		  ' 
		  ' FrmGetPrinterName
		  ' 
		  Me.AcceptButton = Me._btnOk
		  Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		  Me.CancelButton = Me._btnCancel
		  Me.ClientSize = New System.Drawing.Size(326, 118)
		  Me.Controls.Add(Me._btnOk)
		  Me.Controls.Add(Me._btnCancel)
		  Me.Controls.Add(Me._cmbPrintersList)
		  Me.Controls.Add(Me._lblSelectActivePrinter)
		  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		  Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		  Me.MaximizeBox = False
		  Me.MinimizeBox = False
		  Me.Name = "FrmGetPrinterName"
		  Me.ShowIcon = False
		  Me.ShowInTaskbar = False
		  Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		  Me.Text = "Get Printer Name"
'		  Me.Load += New System.EventHandler(Me.FrmGetPrinterName_Load);
'		  Me.FormClosed += New System.Windows.Forms.FormClosedEventHandler(Me.FrmGetPrinterName_FormClosed);
		  Me.ResumeLayout(False)
		  Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _lblSelectActivePrinter As System.Windows.Forms.Label
	  Private _cmbPrintersList As System.Windows.Forms.ComboBox
	  Private _btnCancel As System.Windows.Forms.Button
	  Private _btnOk As System.Windows.Forms.Button
   End Class
End Namespace