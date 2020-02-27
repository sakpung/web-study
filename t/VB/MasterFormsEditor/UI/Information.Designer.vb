
Partial Class InformationDlg
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformationDlg))
      Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
      Me.checkBox1 = New System.Windows.Forms.CheckBox()
      Me._btn_OK = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' richTextBox1
      ' 
      Me.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.richTextBox1.Location = New System.Drawing.Point(12, 12)
      Me.richTextBox1.Name = "richTextBox1"
      Me.richTextBox1.[ReadOnly] = True
      Me.richTextBox1.Size = New System.Drawing.Size(663, 413)
      Me.richTextBox1.TabIndex = 0
      Me.richTextBox1.Text = ""
      ' 
      ' checkBox1
      ' 
      Me.checkBox1.AutoSize = True
      Me.checkBox1.Location = New System.Drawing.Point(12, 431)
      Me.checkBox1.Name = "checkBox1"
      Me.checkBox1.Size = New System.Drawing.Size(184, 17)
      Me.checkBox1.TabIndex = 1
      Me.checkBox1.Text = "Do not Show This Message Again"
      Me.checkBox1.UseVisualStyleBackColor = True
      ' 
      ' _btn_OK
      ' 
      Me._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btn_OK.Location = New System.Drawing.Point(283, 454)
      Me._btn_OK.Name = "_btn_OK"
      Me._btn_OK.Size = New System.Drawing.Size(121, 23)
      Me._btn_OK.TabIndex = 2
      Me._btn_OK.Text = "OK"
      Me._btn_OK.UseVisualStyleBackColor = True
      ' 
      ' InformationDlg
      ' 
      Me.AcceptButton = Me._btn_OK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(687, 494)
      Me.Controls.Add(Me._btn_OK)
      Me.Controls.Add(Me.checkBox1)
      Me.Controls.Add(Me.richTextBox1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "InformationDlg"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Information"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private richTextBox1 As System.Windows.Forms.RichTextBox
   Private WithEvents checkBox1 As System.Windows.Forms.CheckBox
   Private _btn_OK As System.Windows.Forms.Button
End Class
