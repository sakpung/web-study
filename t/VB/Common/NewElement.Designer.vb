Imports Microsoft.VisualBasic
Imports System
Namespace FormsDemo
   Public Partial Class NewElement
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
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewElement))
		 Me._txtName = New System.Windows.Forms.TextBox()
		 Me._lblName = New System.Windows.Forms.Label()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me.SuspendLayout()
		 ' 
		 ' _txtName
		 ' 
		 Me._txtName.Location = New System.Drawing.Point(115, 6)
		 Me._txtName.Name = "_txtName"
		 Me._txtName.Size = New System.Drawing.Size(165, 20)
		 Me._txtName.TabIndex = 0
		 ' 
		 ' _lblName
		 ' 
		 Me._lblName.AutoSize = True
		 Me._lblName.Location = New System.Drawing.Point(12, 9)
		 Me._lblName.Name = "_lblName"
		 Me._lblName.Size = New System.Drawing.Size(25, 13)
		 Me._lblName.TabIndex = 1
		 Me._lblName.Text = "$$$"
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.Location = New System.Drawing.Point(64, 32)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(79, 24)
		 Me._btnOk.TabIndex = 2
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(149, 32)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(79, 24)
		 Me._btnCancel.TabIndex = 3
		 Me._btnCancel.Text = "Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
'		 Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		 ' 
		 ' NewElement
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(292, 65)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._lblName)
		 Me.Controls.Add(Me._txtName)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		 Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "NewElement"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "###"
'		 Me.Load += New System.EventHandler(Me.NewElement_Load);
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _txtName As System.Windows.Forms.TextBox
	  Private _lblName As System.Windows.Forms.Label
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
   End Class
End Namespace