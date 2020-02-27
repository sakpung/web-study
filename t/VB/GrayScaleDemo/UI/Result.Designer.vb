
Partial Class Result
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
      Me._lblResult = New System.Windows.Forms.Label()
      Me._btnOk = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _lblResult
      ' 
      Me._lblResult.Location = New System.Drawing.Point(33, 9)
      Me._lblResult.Name = "_lblResult"
      Me._lblResult.Size = New System.Drawing.Size(97, 19)
      Me._lblResult.TabIndex = 0
      Me._lblResult.Text = "label1"
      ' 
      ' _btnOk
      ' 
      Me._btnOk.Location = New System.Drawing.Point(56, 37)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(53, 27)
      Me._btnOk.TabIndex = 1
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' Result
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(162, 68)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._lblResult)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Result"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Result"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _lblResult As System.Windows.Forms.Label
   Private WithEvents _btnOk As System.Windows.Forms.Button
End Class