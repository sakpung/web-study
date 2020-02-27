
Partial Class FieldNameDlg
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
      Me._btn_cancel = New System.Windows.Forms.Button()
      Me._btn_ok = New System.Windows.Forms.Button()
      Me.label1 = New System.Windows.Forms.Label()
      Me._txtBox_FieldName = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      ' 
      ' _btn_cancel
      ' 
      Me._btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btn_cancel.Location = New System.Drawing.Point(28, 63)
      Me._btn_cancel.Name = "_btn_cancel"
      Me._btn_cancel.Size = New System.Drawing.Size(105, 23)
      Me._btn_cancel.TabIndex = 0
      Me._btn_cancel.Text = "Cancel"
      Me._btn_cancel.UseVisualStyleBackColor = True
      ' 
      ' _btn_ok
      ' 
      Me._btn_ok.Location = New System.Drawing.Point(151, 63)
      Me._btn_ok.Name = "_btn_ok"
      Me._btn_ok.Size = New System.Drawing.Size(105, 23)
      Me._btn_ok.TabIndex = 1
      Me._btn_ok.Text = "OK"
      Me._btn_ok.UseVisualStyleBackColor = True
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(12, 18)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(66, 13)
      Me.label1.TabIndex = 2
      Me.label1.Text = "Field Name :"
      ' 
      ' _txtBox_FieldName
      ' 
      Me._txtBox_FieldName.Location = New System.Drawing.Point(84, 18)
      Me._txtBox_FieldName.Name = "_txtBox_FieldName"
      Me._txtBox_FieldName.Size = New System.Drawing.Size(188, 20)
      Me._txtBox_FieldName.TabIndex = 3
      ' 
      ' FieldNameDlg
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(284, 102)
      Me.Controls.Add(Me._txtBox_FieldName)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me._btn_ok)
      Me.Controls.Add(Me._btn_cancel)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "FieldNameDlg"
      Me.Text = "Field Name"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _btn_cancel As System.Windows.Forms.Button
   Private WithEvents _btn_ok As System.Windows.Forms.Button
   Private label1 As System.Windows.Forms.Label
   Private _txtBox_FieldName As System.Windows.Forms.TextBox
End Class
