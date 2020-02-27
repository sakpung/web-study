Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Public Partial Class FrmProgress
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
		 Me._lblPage = New System.Windows.Forms.Label()
		 Me._lblPrinter = New System.Windows.Forms.Label()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me.SuspendLayout()
		 ' 
		 ' _lblPage
		 ' 
		 Me._lblPage.AutoSize = True
		 Me._lblPage.Location = New System.Drawing.Point(102, 63)
		 Me._lblPage.Name = "_lblPage"
		 Me._lblPage.Size = New System.Drawing.Size(0, 13)
		 Me._lblPage.TabIndex = 0
		 ' 
		 ' _lblPrinter
		 ' 
		 Me._lblPrinter.AutoSize = True
		 Me._lblPrinter.Location = New System.Drawing.Point(12, 15)
		 Me._lblPrinter.Name = "_lblPrinter"
		 Me._lblPrinter.Size = New System.Drawing.Size(36, 13)
		 Me._lblPrinter.TabIndex = 1
		 Me._lblPrinter.Text = "printer"
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.Location = New System.Drawing.Point(83, 92)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(88, 21)
		 Me._btnCancel.TabIndex = 2
		 Me._btnCancel.Text = "Cancel Printing"
		 Me._btnCancel.UseVisualStyleBackColor = True
'		 Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		 ' 
		 ' FrmProgress
		 ' 
		 Me.ClientSize = New System.Drawing.Size(255, 121)
		 Me.ControlBox = False
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._lblPrinter)
		 Me.Controls.Add(Me._lblPage)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "FrmProgress"
		 Me.ShowIcon = False
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		 Me.Text = "Receiving Print Job..."
		 Me.TopMost = True
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _lblPage As System.Windows.Forms.Label
	  Private _lblPrinter As System.Windows.Forms.Label
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
   End Class
End Namespace