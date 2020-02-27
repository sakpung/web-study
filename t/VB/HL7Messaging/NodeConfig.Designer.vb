
Namespace HL7Messaging
   Partial Class NodeConfig
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
         Me.label2 = New System.Windows.Forms.Label()
         Me.label4 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.textBox5 = New System.Windows.Forms.TextBox()
         Me.textBox3 = New System.Windows.Forms.TextBox()
         Me.textBox2 = New System.Windows.Forms.TextBox()
         Me.textBox1 = New System.Windows.Forms.TextBox()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.label6 = New System.Windows.Forms.Label()
         Me.label7 = New System.Windows.Forms.Label()
         Me.textBox6 = New System.Windows.Forms.TextBox()
         Me.textBox7 = New System.Windows.Forms.TextBox()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me.checkBox1 = New System.Windows.Forms.CheckBox()
         Me.label11 = New System.Windows.Forms.Label()
         Me.label5 = New System.Windows.Forms.Label()
         Me.textBox9 = New System.Windows.Forms.TextBox()
         Me.textBox4 = New System.Windows.Forms.TextBox()
         Me.textBox8 = New System.Windows.Forms.TextBox()
         Me.label9 = New System.Windows.Forms.Label()
         Me.comboBox1 = New System.Windows.Forms.ComboBox()
         Me.label10 = New System.Windows.Forms.Label()
         Me.label8 = New System.Windows.Forms.Label()
         Me.label12 = New System.Windows.Forms.Label()
         Me.textBox10 = New System.Windows.Forms.TextBox()
         Me.groupBox1.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.button1.Location = New System.Drawing.Point(175, 435)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(75, 23)
         Me.button1.TabIndex = 5
         Me.button1.Text = "&Cancel"
         Me.button1.UseVisualStyleBackColor = True
         ' 
         ' button2
         ' 
         Me.button2.Location = New System.Drawing.Point(256, 435)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(75, 23)
         Me.button2.TabIndex = 6
         Me.button2.Text = "&OK"
         Me.button2.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Controls.Add(Me.textBox5)
         Me.groupBox1.Controls.Add(Me.textBox3)
         Me.groupBox1.Controls.Add(Me.textBox2)
         Me.groupBox1.Controls.Add(Me.textBox1)
         Me.groupBox1.Location = New System.Drawing.Point(10, 65)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(321, 152)
         Me.groupBox1.TabIndex = 2
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "&Remote Server"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(12, 57)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(76, 13)
         Me.label2.TabIndex = 2
         Me.label2.Text = "&Port: (required)"
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(12, 125)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(42, 13)
         Me.label4.TabIndex = 6
         Me.label4.Text = "&Facility:"
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(12, 97)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(58, 13)
         Me.label3.TabIndex = 4
         Me.label3.Text = "&App name:"
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(12, 27)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(67, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "&IP: (required)"
         ' 
         ' textBox5
         ' 
         Me.textBox5.Location = New System.Drawing.Point(94, 54)
         Me.textBox5.Name = "textBox5"
         Me.textBox5.Size = New System.Drawing.Size(205, 20)
         Me.textBox5.TabIndex = 3
         ' 
         ' textBox3
         ' 
         Me.textBox3.Location = New System.Drawing.Point(94, 122)
         Me.textBox3.Name = "textBox3"
         Me.textBox3.Size = New System.Drawing.Size(205, 20)
         Me.textBox3.TabIndex = 7
         ' 
         ' textBox2
         ' 
         Me.textBox2.Location = New System.Drawing.Point(94, 94)
         Me.textBox2.Name = "textBox2"
         Me.textBox2.Size = New System.Drawing.Size(205, 20)
         Me.textBox2.TabIndex = 5
         ' 
         ' textBox1
         ' 
         Me.textBox1.Location = New System.Drawing.Point(94, 24)
         Me.textBox1.Name = "textBox1"
         Me.textBox1.Size = New System.Drawing.Size(205, 20)
         Me.textBox1.TabIndex = 1
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me.label6)
         Me.groupBox2.Controls.Add(Me.label7)
         Me.groupBox2.Controls.Add(Me.textBox6)
         Me.groupBox2.Controls.Add(Me.textBox7)
         Me.groupBox2.Location = New System.Drawing.Point(10, 224)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(321, 80)
         Me.groupBox2.TabIndex = 3
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "&Client"
         ' 
         ' label6
         ' 
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(12, 50)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(42, 13)
         Me.label6.TabIndex = 2
         Me.label6.Text = "&Facility:"
         ' 
         ' label7
         ' 
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(12, 22)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(58, 13)
         Me.label7.TabIndex = 0
         Me.label7.Text = "&App name:"
         ' 
         ' textBox6
         ' 
         Me.textBox6.Location = New System.Drawing.Point(94, 47)
         Me.textBox6.Name = "textBox6"
         Me.textBox6.Size = New System.Drawing.Size(205, 20)
         Me.textBox6.TabIndex = 3
         ' 
         ' textBox7
         ' 
         Me.textBox7.Location = New System.Drawing.Point(94, 19)
         Me.textBox7.Name = "textBox7"
         Me.textBox7.Size = New System.Drawing.Size(205, 20)
         Me.textBox7.TabIndex = 1
         ' 
         ' groupBox3
         ' 
         Me.groupBox3.Controls.Add(Me.checkBox1)
         Me.groupBox3.Controls.Add(Me.label11)
         Me.groupBox3.Controls.Add(Me.label5)
         Me.groupBox3.Controls.Add(Me.textBox9)
         Me.groupBox3.Controls.Add(Me.textBox4)
         Me.groupBox3.Controls.Add(Me.textBox8)
         Me.groupBox3.Controls.Add(Me.label9)
         Me.groupBox3.Controls.Add(Me.comboBox1)
         Me.groupBox3.Controls.Add(Me.label10)
         Me.groupBox3.Controls.Add(Me.label8)
         Me.groupBox3.Location = New System.Drawing.Point(10, 311)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(321, 118)
         Me.groupBox3.TabIndex = 4
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "Comm&unication"
         ' 
         ' checkBox1
         ' 
         Me.checkBox1.AutoSize = True
         Me.checkBox1.Location = New System.Drawing.Point(15, 94)
         Me.checkBox1.Name = "checkBox1"
         Me.checkBox1.Size = New System.Drawing.Size(177, 17)
         Me.checkBox1.TabIndex = 9
         Me.checkBox1.Text = "&Wait for ACK (acknowledgment)"
         Me.checkBox1.UseVisualStyleBackColor = True
         ' 
         ' label11
         ' 
         Me.label11.AutoSize = True
         Me.label11.Location = New System.Drawing.Point(163, 64)
         Me.label11.Name = "label11"
         Me.label11.Size = New System.Drawing.Size(59, 13)
         Me.label11.TabIndex = 7
         Me.label11.Text = "&MLP suffi&x:"
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(12, 64)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(60, 13)
         Me.label5.TabIndex = 5
         Me.label5.Text = "&MLP prefix:"
         ' 
         ' textBox9
         ' 
         Me.textBox9.Location = New System.Drawing.Point(228, 61)
         Me.textBox9.Name = "textBox9"
         Me.textBox9.Size = New System.Drawing.Size(85, 20)
         Me.textBox9.TabIndex = 8
         ' 
         ' textBox4
         ' 
         Me.textBox4.Location = New System.Drawing.Point(77, 61)
         Me.textBox4.Name = "textBox4"
         Me.textBox4.Size = New System.Drawing.Size(80, 20)
         Me.textBox4.TabIndex = 6
         ' 
         ' textBox8
         ' 
         Me.textBox8.Location = New System.Drawing.Point(126, 19)
         Me.textBox8.Name = "textBox8"
         Me.textBox8.Size = New System.Drawing.Size(115, 20)
         Me.textBox8.TabIndex = 1
         ' 
         ' label9
         ' 
         Me.label9.AutoSize = True
         Me.label9.Location = New System.Drawing.Point(12, 39)
         Me.label9.Name = "label9"
         Me.label9.Size = New System.Drawing.Size(95, 13)
         Me.label9.TabIndex = 3
         Me.label9.Text = "Messages &version:"
         Me.label9.Visible = False
         ' 
         ' comboBox1
         ' 
         Me.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.comboBox1.FormattingEnabled = True
         Me.comboBox1.Location = New System.Drawing.Point(126, 36)
         Me.comboBox1.Name = "comboBox1"
         Me.comboBox1.Size = New System.Drawing.Size(121, 21)
         Me.comboBox1.TabIndex = 4
         Me.comboBox1.Visible = False
         ' 
         ' label10
         ' 
         Me.label10.AutoSize = True
         Me.label10.Location = New System.Drawing.Point(246, 22)
         Me.label10.Name = "label10"
         Me.label10.Size = New System.Drawing.Size(67, 13)
         Me.label10.TabIndex = 2
         Me.label10.Text = "(0 for infinite)"
         ' 
         ' label8
         ' 
         Me.label8.AutoSize = True
         Me.label8.Location = New System.Drawing.Point(12, 22)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(113, 13)
         Me.label8.TabIndex = 0
         Me.label8.Text = "&Timeout: (milliseconds)"
         ' 
         ' label12
         ' 
         Me.label12.AutoSize = True
         Me.label12.Location = New System.Drawing.Point(7, 26)
         Me.label12.Name = "label12"
         Me.label12.Size = New System.Drawing.Size(38, 13)
         Me.label12.TabIndex = 0
         Me.label12.Text = "&Name:"
         ' 
         ' textBox10
         ' 
         Me.textBox10.Location = New System.Drawing.Point(51, 23)
         Me.textBox10.Name = "textBox10"
         Me.textBox10.Size = New System.Drawing.Size(280, 20)
         Me.textBox10.TabIndex = 1
         ' 
         ' NodeConfig
         ' 
         Me.AcceptButton = Me.button2
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me.button1
         Me.ClientSize = New System.Drawing.Size(343, 467)
         Me.Controls.Add(Me.label12)
         Me.Controls.Add(Me.groupBox3)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me.button2)
         Me.Controls.Add(Me.textBox10)
         Me.Controls.Add(Me.button1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "NodeConfig"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.Text = "Node Configuration"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox3.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents button2 As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label2 As System.Windows.Forms.Label
      Private label1 As System.Windows.Forms.Label
      Private WithEvents textBox5 As System.Windows.Forms.TextBox
      Private WithEvents textBox1 As System.Windows.Forms.TextBox
      Private label4 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private textBox3 As System.Windows.Forms.TextBox
      Private textBox2 As System.Windows.Forms.TextBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private label6 As System.Windows.Forms.Label
      Private label7 As System.Windows.Forms.Label
      Private textBox6 As System.Windows.Forms.TextBox
      Private textBox7 As System.Windows.Forms.TextBox
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private label8 As System.Windows.Forms.Label
      Private checkBox1 As System.Windows.Forms.CheckBox
      Private label11 As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private textBox9 As System.Windows.Forms.TextBox
      Private textBox4 As System.Windows.Forms.TextBox
      Private textBox8 As System.Windows.Forms.TextBox
      Private label9 As System.Windows.Forms.Label
      Private comboBox1 As System.Windows.Forms.ComboBox
      Private label10 As System.Windows.Forms.Label
      Private label12 As System.Windows.Forms.Label
      Private textBox10 As System.Windows.Forms.TextBox
   End Class
End Namespace
