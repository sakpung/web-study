
Partial Class SingleSelectionFieldDlg
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
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
      Me._tbName = New System.Windows.Forms.TextBox()
      Me._gbFields = New System.Windows.Forms.GroupBox()
      Me._gbName = New System.Windows.Forms.GroupBox()
      Me._gbName.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _btnOK
      ' 
      Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOK.Location = New System.Drawing.Point(22, 355)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(102, 27)
      Me._btnOK.TabIndex = 10
      Me._btnOK.Text = "OK"
      Me._btnOK.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(130, 355)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(105, 27)
      Me._btnCancel.TabIndex = 11
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _tbName
      ' 
      Me._tbName.Location = New System.Drawing.Point(10, 19)
      Me._tbName.Multiline = True
      Me._tbName.Name = "_tbName"
      Me._tbName.Size = New System.Drawing.Size(314, 54)
      Me._tbName.TabIndex = 0
      ' 
      ' _gbFields
      ' 
      Me._gbFields.AutoSize = True
      Me._gbFields.Location = New System.Drawing.Point(12, 97)
      Me._gbFields.Name = "_gbFields"
      Me._gbFields.Size = New System.Drawing.Size(330, 252)
      Me._gbFields.TabIndex = 8
      Me._gbFields.TabStop = False
      Me._gbFields.Text = "Fields Values"
      ' 
      ' _gbName
      ' 
      Me._gbName.Controls.Add(Me._tbName)
      Me._gbName.Location = New System.Drawing.Point(12, 12)
      Me._gbName.Name = "_gbName"
      Me._gbName.Size = New System.Drawing.Size(330, 79)
      Me._gbName.TabIndex = 9
      Me._gbName.TabStop = False
      Me._gbName.Text = "Field Name"
      ' 
      ' SingleSelectionFieldDlg
      ' 
      Me.AcceptButton = Me._btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.AutoScroll = True
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(361, 394)
      Me.Controls.Add(Me._gbName)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOK)
      Me.Controls.Add(Me._gbFields)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SingleSelectionFieldDlg"
      Me.Text = "Single Selection"
      Me._gbName.ResumeLayout(False)
      Me._gbName.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _btnOK As System.Windows.Forms.Button
   Private _btnCancel As System.Windows.Forms.Button
   Private _tbName As System.Windows.Forms.TextBox
   Private _gbFields As System.Windows.Forms.GroupBox
   Private _gbName As System.Windows.Forms.GroupBox
End Class