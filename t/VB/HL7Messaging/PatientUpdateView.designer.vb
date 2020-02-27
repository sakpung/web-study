Namespace HL7Messaging
   Partial Class PatientUpdateView
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
         Me.button1 = New System.Windows.Forms.Button()
         Me.button2 = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.label8 = New System.Windows.Forms.Label()
         Me.label4 = New System.Windows.Forms.Label()
         Me.textBox3 = New System.Windows.Forms.TextBox()
         Me.textBox5 = New System.Windows.Forms.TextBox()
         Me.textBox1 = New System.Windows.Forms.TextBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label7 = New System.Windows.Forms.Label()
         Me.label6 = New System.Windows.Forms.Label()
         Me.comboBox1 = New System.Windows.Forms.ComboBox()
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
         Me.groupBox1.Controls.Add(Me.comboBox1)
         Me.groupBox1.Controls.Add(Me.label8)
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me.textBox3)
         Me.groupBox1.Controls.Add(Me.textBox5)
         Me.groupBox1.Controls.Add(Me.textBox1)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(12, 12)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(349, 187)
         Me.groupBox1.TabIndex = 2
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Patient's Info"
         ' 
         ' label8
         ' 
         Me.label8.AutoSize = True
         Me.label8.ForeColor = System.Drawing.Color.Green
         Me.label8.Location = New System.Drawing.Point(332, 32)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(11, 13)
         Me.label8.TabIndex = 7
         Me.label8.Text = "*"
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(19, 139)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(51, 13)
         Me.label4.TabIndex = 5
         Me.label4.Text = "New sex:"
         ' 
         ' textBox3
         ' 
         Me.textBox3.Location = New System.Drawing.Point(105, 100)
         Me.textBox3.Name = "textBox3"
         Me.textBox3.Size = New System.Drawing.Size(223, 20)
         Me.textBox3.TabIndex = 4
         ' 
         ' textBox5
         ' 
         Me.textBox5.Location = New System.Drawing.Point(105, 65)
         Me.textBox5.Name = "textBox5"
         Me.textBox5.Size = New System.Drawing.Size(223, 20)
         Me.textBox5.TabIndex = 2
         ' 
         ' textBox1
         ' 
         Me.textBox1.Location = New System.Drawing.Point(105, 29)
         Me.textBox1.Name = "textBox1"
         Me.textBox1.Size = New System.Drawing.Size(223, 20)
         Me.textBox1.TabIndex = 0
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(19, 103)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(80, 13)
         Me.label3.TabIndex = 4
         Me.label3.Text = "New last name:"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(19, 68)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(80, 13)
         Me.label2.TabIndex = 3
         Me.label2.Text = "New first name:"
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(19, 33)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(19, 13)
         Me.label1.TabIndex = 2
         Me.label1.Text = "Id:"
         ' 
         ' label7
         ' 
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(51, 209)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(118, 13)
         Me.label7.TabIndex = 8
         Me.label7.Text = "Indicates required fields"
         ' 
         ' label6
         ' 
         Me.label6.AutoSize = True
         Me.label6.ForeColor = System.Drawing.Color.Green
         Me.label6.Location = New System.Drawing.Point(37, 210)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(11, 13)
         Me.label6.TabIndex = 7
         Me.label6.Text = "*"
         ' 
         ' comboBox1
         ' 
         Me.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBox1.FormattingEnabled = True
         Me.comboBox1.Items.AddRange(New Object() {"F", "M", "O"})
         Me.comboBox1.Location = New System.Drawing.Point(105, 136)
         Me.comboBox1.Name = "comboBox1"
         Me.comboBox1.Size = New System.Drawing.Size(223, 21)
         Me.comboBox1.TabIndex = 8
         ' 
         ' PatientUpdateView
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
         Me.Name = "PatientUpdateView"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "ADT_A01 - Patient Update"
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
      Private textBox5 As System.Windows.Forms.TextBox
      Private textBox1 As System.Windows.Forms.TextBox
      Private label3 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label1 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private label7 As System.Windows.Forms.Label
      Private label6 As System.Windows.Forms.Label
      Private label8 As System.Windows.Forms.Label
      Private comboBox1 As System.Windows.Forms.ComboBox
   End Class
End Namespace
