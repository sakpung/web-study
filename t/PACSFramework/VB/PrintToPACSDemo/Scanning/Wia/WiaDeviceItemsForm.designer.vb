Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Public Partial Class WiaDeviceItemsForm
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
		 Me._tvWiaDeviceItems = New System.Windows.Forms.TreeView()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me.SuspendLayout()
		 ' 
		 ' _tvWiaDeviceItems
		 ' 
		 Me._tvWiaDeviceItems.Location = New System.Drawing.Point(12, 12)
		 Me._tvWiaDeviceItems.Name = "_tvWiaDeviceItems"
		 Me._tvWiaDeviceItems.Size = New System.Drawing.Size(239, 213)
		 Me._tvWiaDeviceItems.TabIndex = 0
'		 Me._tvWiaDeviceItems.DoubleClick += New System.EventHandler(Me._tvWiaDeviceItems_DoubleClick);
'		 Me._tvWiaDeviceItems.AfterSelect += New System.Windows.Forms.TreeViewEventHandler(Me._tvWiaDeviceItems_AfterSelect);
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.Location = New System.Drawing.Point(53, 231)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(75, 23)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "&OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(134, 231)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(75, 23)
		 Me._btnCancel.TabIndex = 2
		 Me._btnCancel.Text = "&Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' WiaDeviceItemsForm
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(263, 266)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._tvWiaDeviceItems)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		 Me.Name = "WiaDeviceItemsForm"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Select Item"
'		 Me.Load += New System.EventHandler(Me.WiaDeviceItemsForm_Load);
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private WithEvents _tvWiaDeviceItems As System.Windows.Forms.TreeView
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _btnCancel As System.Windows.Forms.Button
   End Class
End Namespace