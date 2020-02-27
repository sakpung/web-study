Imports Microsoft.VisualBasic
Imports System
Namespace FormsDemo
   Public Partial Class MasterFormList
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
		  Me._masterFormList = New System.Windows.Forms.ListBox()
		  Me._btnOk = New System.Windows.Forms.Button()
		  Me._btnCancel = New System.Windows.Forms.Button()
		  Me.SuspendLayout()
		  ' 
		  ' _masterFormList
		  ' 
		  Me._masterFormList.FormattingEnabled = True
		  Me._masterFormList.Location = New System.Drawing.Point(49, 12)
		  Me._masterFormList.Name = "_masterFormList"
		  Me._masterFormList.Size = New System.Drawing.Size(155, 225)
		  Me._masterFormList.TabIndex = 0
'		  Me._masterFormList.MouseDoubleClick += New System.Windows.Forms.MouseEventHandler(Me._masterFormList_MouseDoubleClick);
'		  Me._masterFormList.SelectedIndexChanged += New System.EventHandler(Me._masterFormList_SelectedIndexChanged);
		  ' 
		  ' _btnOk
		  ' 
		  Me._btnOk.Enabled = False
		  Me._btnOk.Location = New System.Drawing.Point(49, 253)
		  Me._btnOk.Name = "_btnOk"
		  Me._btnOk.Size = New System.Drawing.Size(64, 26)
		  Me._btnOk.TabIndex = 1
		  Me._btnOk.Text = "OK"
		  Me._btnOk.UseVisualStyleBackColor = True
'		  Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		  ' 
		  ' _btnCancel
		  ' 
		  Me._btnCancel.Location = New System.Drawing.Point(140, 253)
		  Me._btnCancel.Name = "_btnCancel"
		  Me._btnCancel.Size = New System.Drawing.Size(64, 26)
		  Me._btnCancel.TabIndex = 2
		  Me._btnCancel.Text = "Cancel"
		  Me._btnCancel.UseVisualStyleBackColor = True
'		  Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		  ' 
		  ' MasterFormList
		  ' 
		  Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		  Me.ClientSize = New System.Drawing.Size(255, 291)
		  Me.ControlBox = False
		  Me.Controls.Add(Me._btnCancel)
		  Me.Controls.Add(Me._btnOk)
		  Me.Controls.Add(Me._masterFormList)
		  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		  Me.Name = "MasterFormList"
		  Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		  Me.Text = "Select Master Forms Folder To Load"
'		  Me.Load += New System.EventHandler(Me.MasterFormList_Load);
		  Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private WithEvents _masterFormList As System.Windows.Forms.ListBox
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
   End Class
End Namespace