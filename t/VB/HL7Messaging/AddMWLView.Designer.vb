
Namespace HL7Messaging
   Partial Class AddMWLView
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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.textBox3 = New System.Windows.Forms.TextBox()
         Me.textBox2 = New System.Windows.Forms.TextBox()
         Me.textBox5 = New System.Windows.Forms.TextBox()
         Me.textBox1 = New System.Windows.Forms.TextBox()
         Me.label4 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label5 = New System.Windows.Forms.Label()
         Me.label6 = New System.Windows.Forms.Label()
         Me.label7 = New System.Windows.Forms.Label()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(205, 229)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(75, 23)
         Me.button1.TabIndex = 4
         Me.button1.Text = "&OK"
         Me.button1.UseVisualStyleBackColor = True
         ' 
         ' button2
         ' 
         Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.button2.Location = New System.Drawing.Point(286, 229)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(75, 23)
         Me.button2.TabIndex = 5
         Me.button2.Text = "&Cancel"
         Me.button2.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me.label5)
         Me.groupBox1.Controls.Add(Me.textBox3)
         Me.groupBox1.Controls.Add(Me.textBox2)
         Me.groupBox1.Controls.Add(Me.textBox5)
         Me.groupBox1.Controls.Add(Me.textBox1)
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(12, 12)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(349, 192)
         Me.groupBox1.TabIndex = 2
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Patient's Info"
         ' 
         ' textBox3
         ' 
         Me.textBox3.Location = New System.Drawing.Point(91, 147)
         Me.textBox3.Name = "textBox3"
         Me.textBox3.Size = New System.Drawing.Size(240, 20)
         Me.textBox3.TabIndex = 3
         ' 
         ' textBox2
         ' 
         Me.textBox2.Location = New System.Drawing.Point(91, 109)
         Me.textBox2.Name = "textBox2"
         Me.textBox2.Size = New System.Drawing.Size(240, 20)
         Me.textBox2.TabIndex = 2
         ' 
         ' textBox5
         ' 
         Me.textBox5.Location = New System.Drawing.Point(91, 70)
         Me.textBox5.Name = "textBox5"
         Me.textBox5.Size = New System.Drawing.Size(240, 20)
         Me.textBox5.TabIndex = 1
         ' 
         ' textBox1
         ' 
         Me.textBox1.Location = New System.Drawing.Point(91, 29)
         Me.textBox1.Name = "textBox1"
         Me.textBox1.Size = New System.Drawing.Size(240, 20)
         Me.textBox1.TabIndex = 0
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(19, 112)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(70, 13)
         Me.label4.TabIndex = 4
         Me.label4.Text = "Middle name:"
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(19, 150)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(59, 13)
         Me.label3.TabIndex = 4
         Me.label3.Text = "Last name:"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(19, 73)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(58, 13)
         Me.label2.TabIndex = 3
         Me.label2.Text = "First name:"
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(19, 37)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(19, 13)
         Me.label1.TabIndex = 2
         Me.label1.Text = "Id:"
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.ForeColor = System.Drawing.Color.Green
         Me.label5.Location = New System.Drawing.Point(333, 34)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(11, 13)
         Me.label5.TabIndex = 5
         Me.label5.Text = "*"
         ' 
         ' label6
         ' 
         Me.label6.AutoSize = True
         Me.label6.ForeColor = System.Drawing.Color.Green
         Me.label6.Location = New System.Drawing.Point(31, 209)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(11, 13)
         Me.label6.TabIndex = 6
         Me.label6.Text = "*"
         ' 
         ' label7
         ' 
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(45, 209)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(118, 13)
         Me.label7.TabIndex = 6
         Me.label7.Text = "Indicates required fields"
         ' 
         ' AddMWLView
         ' 
         Me.AcceptButton = Me.button1
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me.button2
         Me.ClientSize = New System.Drawing.Size(373, 261)
         Me.ControlBox = False
         Me.Controls.Add(Me.label7)
         Me.Controls.Add(Me.label6)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me.button2)
         Me.Controls.Add(Me.button1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Name = "AddMWLView"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "ADT_A01 - Add MWL Item"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents button2 As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private textBox3 As System.Windows.Forms.TextBox
      Private textBox2 As System.Windows.Forms.TextBox
      Private textBox5 As System.Windows.Forms.TextBox
      Private textBox1 As System.Windows.Forms.TextBox
      Private label4 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label1 As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private label6 As System.Windows.Forms.Label
      Private label7 As System.Windows.Forms.Label
   End Class
End Namespace
