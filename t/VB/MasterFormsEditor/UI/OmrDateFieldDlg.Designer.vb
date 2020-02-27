
Partial Class OmrDateFieldDlg
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
      Me._gbName = New System.Windows.Forms.GroupBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me._tbName = New System.Windows.Forms.TextBox()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOK = New System.Windows.Forms.Button()
      Me._gbFields = New System.Windows.Forms.GroupBox()
      Me._btnEdit = New System.Windows.Forms.Button()
      Me._lbSelection = New System.Windows.Forms.ListBox()
      Me._gbName.SuspendLayout()
      Me._gbFields.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _gbName
      ' 
      Me._gbName.Controls.Add(Me.label1)
      Me._gbName.Controls.Add(Me._tbName)
      Me._gbName.Location = New System.Drawing.Point(12, 12)
      Me._gbName.Name = "_gbName"
      Me._gbName.Size = New System.Drawing.Size(330, 57)
      Me._gbName.TabIndex = 13
      Me._gbName.TabStop = False
      Me._gbName.Text = "Field Properties"
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(22, 22)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(60, 13)
      Me.label1.TabIndex = 16
      Me.label1.Text = "Field Name"
      ' 
      ' _tbName
      ' 
      Me._tbName.Location = New System.Drawing.Point(118, 19)
      Me._tbName.Name = "_tbName"
      Me._tbName.Size = New System.Drawing.Size(203, 20)
      Me._tbName.TabIndex = 16
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(130, 304)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(105, 27)
      Me._btnCancel.TabIndex = 15
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOK
      ' 
      Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOK.Location = New System.Drawing.Point(22, 304)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(102, 27)
      Me._btnOK.TabIndex = 14
      Me._btnOK.Text = "OK"
      Me._btnOK.UseVisualStyleBackColor = True
      ' 
      ' _gbFields
      ' 
      Me._gbFields.AutoSize = True
      Me._gbFields.Controls.Add(Me._btnEdit)
      Me._gbFields.Controls.Add(Me._lbSelection)
      Me._gbFields.Location = New System.Drawing.Point(12, 75)
      Me._gbFields.Name = "_gbFields"
      Me._gbFields.Size = New System.Drawing.Size(330, 223)
      Me._gbFields.TabIndex = 12
      Me._gbFields.TabStop = False
      Me._gbFields.Text = "Fields Values"
      ' 
      ' _btnEdit
      ' 
      Me._btnEdit.Location = New System.Drawing.Point(246, 39)
      Me._btnEdit.Name = "_btnEdit"
      Me._btnEdit.Size = New System.Drawing.Size(75, 23)
      Me._btnEdit.TabIndex = 16
      Me._btnEdit.Text = "Edit"
      Me._btnEdit.UseVisualStyleBackColor = True
      ' 
      ' _lbSelection
      ' 
      Me._lbSelection.FormattingEnabled = True
      Me._lbSelection.Location = New System.Drawing.Point(10, 28)
      Me._lbSelection.Name = "_lbSelection"
      Me._lbSelection.Size = New System.Drawing.Size(213, 173)
      Me._lbSelection.TabIndex = 0
      ' 
      ' OmrDateFieldDlg
      ' 
      Me.AcceptButton = Me._btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.AutoScroll = True
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(364, 341)
      Me.Controls.Add(Me._gbName)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOK)
      Me.Controls.Add(Me._gbFields)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OmrDateFieldDlg"
      Me.Text = "Omr Date Field"
      Me._gbName.ResumeLayout(False)
      Me._gbName.PerformLayout()
      Me._gbFields.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _gbName As System.Windows.Forms.GroupBox
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOK As System.Windows.Forms.Button
   Private _gbFields As System.Windows.Forms.GroupBox
   Private _tbName As System.Windows.Forms.TextBox
   Private label1 As System.Windows.Forms.Label
   Private WithEvents _btnEdit As System.Windows.Forms.Button
   Private _lbSelection As System.Windows.Forms.ListBox
End Class