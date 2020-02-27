
Namespace HL7Messaging
   Partial Class SendHl7MessageView
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
         Me.button1 = New System.Windows.Forms.Button()
         Me.button2 = New System.Windows.Forms.Button()
         Me.label3 = New System.Windows.Forms.Label()
         Me.comboBox1 = New System.Windows.Forms.ComboBox()
         Me.button3 = New System.Windows.Forms.Button()
         Me.button4 = New System.Windows.Forms.Button()
         Me.button5 = New System.Windows.Forms.Button()
         Me.label1 = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(171, 114)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(75, 23)
         Me.button1.TabIndex = 6
         Me.button1.Text = "&Send"
         Me.button1.UseVisualStyleBackColor = True
         ' 
         ' button2
         ' 
         Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.button2.Location = New System.Drawing.Point(252, 114)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(75, 23)
         Me.button2.TabIndex = 7
         Me.button2.Text = "&Close"
         Me.button2.UseVisualStyleBackColor = True
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(12, 24)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(47, 13)
         Me.label3.TabIndex = 0
         Me.label3.Text = "&Send to:"
         ' 
         ' comboBox1
         ' 
         Me.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBox1.FormattingEnabled = True
         Me.comboBox1.Location = New System.Drawing.Point(66, 21)
         Me.comboBox1.Name = "comboBox1"
         Me.comboBox1.Size = New System.Drawing.Size(261, 21)
         Me.comboBox1.TabIndex = 1
         ' 
         ' button3
         ' 
         Me.button3.Location = New System.Drawing.Point(66, 60)
         Me.button3.Name = "button3"
         Me.button3.Size = New System.Drawing.Size(75, 23)
         Me.button3.TabIndex = 2
         Me.button3.Text = "&New"
         Me.button3.UseVisualStyleBackColor = True
         ' 
         ' button4
         ' 
         Me.button4.Location = New System.Drawing.Point(157, 60)
         Me.button4.Name = "button4"
         Me.button4.Size = New System.Drawing.Size(75, 23)
         Me.button4.TabIndex = 3
         Me.button4.Text = "&Delete"
         Me.button4.UseVisualStyleBackColor = True
         ' 
         ' button5
         ' 
         Me.button5.Location = New System.Drawing.Point(252, 60)
         Me.button5.Name = "button5"
         Me.button5.Size = New System.Drawing.Size(75, 23)
         Me.button5.TabIndex = 4
         Me.button5.Text = "&Edit"
         Me.button5.UseVisualStyleBackColor = True
         ' 
         ' label1
         ' 
         Me.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me.label1.Location = New System.Drawing.Point(9, 98)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(318, 1)
         Me.label1.TabIndex = 8
         ' 
         ' SendHl7MessageView
         ' 
         Me.AcceptButton = Me.button1
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me.button2
         Me.ClientSize = New System.Drawing.Size(339, 151)
         Me.ControlBox = False
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.comboBox1)
         Me.Controls.Add(Me.button5)
         Me.Controls.Add(Me.button4)
         Me.Controls.Add(Me.button3)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me.button2)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Name = "SendHl7MessageView"
         Me.ShowIcon = False
         Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Send HL7 Message"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents button2 As System.Windows.Forms.Button
      Private label3 As System.Windows.Forms.Label
      Private comboBox1 As System.Windows.Forms.ComboBox
      Private WithEvents button3 As System.Windows.Forms.Button
      Private WithEvents button4 As System.Windows.Forms.Button
      Private WithEvents button5 As System.Windows.Forms.Button
      Private label1 As System.Windows.Forms.Label
   End Class
End Namespace
