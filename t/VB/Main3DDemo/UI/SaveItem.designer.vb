Namespace Main3DDemo
   Partial Class SaveItemialog
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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._txtItemName = New System.Windows.Forms.TextBox()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _btnOK
         ' 
         Me._btnOK.Location = New System.Drawing.Point(24, 75)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(81, 30)
         Me._btnOK.TabIndex = 34
         Me._btnOK.Text = "&OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(144, 75)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(81, 30)
         Me._btnCancel.TabIndex = 35
         Me._btnCancel.Text = "&Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._txtItemName)
         Me.groupBox1.Location = New System.Drawing.Point(12, 12)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(236, 57)
         Me.groupBox1.TabIndex = 33
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "&Item Name"
         ' 
         ' _txtItemName
         ' 
         Me._txtItemName.Location = New System.Drawing.Point(6, 24)
         Me._txtItemName.Name = "_txtItemName"
         Me._txtItemName.Size = New System.Drawing.Size(223, 20)
         Me._txtItemName.TabIndex = 33
         Me._txtItemName.Text = "Item 1"
         ' 
         ' SaveItemialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(261, 117)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SaveItemialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Save Item Dialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _txtItemName As System.Windows.Forms.TextBox
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
   End Class
End Namespace
