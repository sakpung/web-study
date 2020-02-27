Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Public Partial Class AcquireSourceForm
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
		 Me._btnOK = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._lbAcquireSources = New System.Windows.Forms.ListBox()
		 Me.SuspendLayout()
		 ' 
		 ' _btnOK
		 ' 
		 Me._btnOK.Location = New System.Drawing.Point(12, 88)
		 Me._btnOK.Name = "_btnOK"
		 Me._btnOK.Size = New System.Drawing.Size(75, 23)
		 Me._btnOK.TabIndex = 2
		 Me._btnOK.Text = "&OK"
		 Me._btnOK.UseVisualStyleBackColor = True
'		 Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(94, 88)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(75, 23)
		 Me._btnCancel.TabIndex = 3
		 Me._btnCancel.Text = "&Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _lbAcquireSources
		 ' 
		 Me._lbAcquireSources.FormattingEnabled = True
		 Me._lbAcquireSources.Location = New System.Drawing.Point(12, 12)
		 Me._lbAcquireSources.Name = "_lbAcquireSources"
		 Me._lbAcquireSources.Size = New System.Drawing.Size(157, 69)
		 Me._lbAcquireSources.TabIndex = 1
'		 Me._lbAcquireSources.DoubleClick += New System.EventHandler(Me._lbAcquireSources_DoubleClick);
		 ' 
		 ' AcquireSourceForm
		 ' 
		 Me.AcceptButton = Me._btnOK
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(181, 123)
		 Me.Controls.Add(Me._lbAcquireSources)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOK)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		 Me.Name = "AcquireSourceForm"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Acquire Sources"
'		 Me.Load += New System.EventHandler(Me.AcquireSourceForm_Load);
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private WithEvents _btnOK As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _lbAcquireSources As System.Windows.Forms.ListBox
   End Class
End Namespace