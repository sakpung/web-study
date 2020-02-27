Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Partial Public Class FrmUsage
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
   Me.groupBox1 = New System.Windows.Forms.GroupBox()
   Me.label16 = New System.Windows.Forms.Label()
   Me.label14 = New System.Windows.Forms.Label()
   Me.label6 = New System.Windows.Forms.Label()
   Me.label1 = New System.Windows.Forms.Label()
   Me.label17 = New System.Windows.Forms.Label()
   Me.label15 = New System.Windows.Forms.Label()
   Me.label13 = New System.Windows.Forms.Label()
   Me.label12 = New System.Windows.Forms.Label()
   Me.label11 = New System.Windows.Forms.Label()
   Me.label10 = New System.Windows.Forms.Label()
   Me.label9 = New System.Windows.Forms.Label()
   Me.label7 = New System.Windows.Forms.Label()
   Me.label8 = New System.Windows.Forms.Label()
   Me.label5 = New System.Windows.Forms.Label()
   Me.label4 = New System.Windows.Forms.Label()
   Me.groupBox2 = New System.Windows.Forms.GroupBox()
   Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
   Me.groupBox1.SuspendLayout()
   Me.groupBox2.SuspendLayout()
   Me.SuspendLayout()
   ' 
   ' groupBox1
   ' 
   Me.groupBox1.Controls.Add(Me.label16)
   Me.groupBox1.Controls.Add(Me.label14)
   Me.groupBox1.Controls.Add(Me.label6)
   Me.groupBox1.Controls.Add(Me.label1)
   Me.groupBox1.Controls.Add(Me.label17)
   Me.groupBox1.Controls.Add(Me.label15)
   Me.groupBox1.Controls.Add(Me.label13)
   Me.groupBox1.Controls.Add(Me.label12)
   Me.groupBox1.Controls.Add(Me.label11)
   Me.groupBox1.Controls.Add(Me.label10)
   Me.groupBox1.Controls.Add(Me.label9)
   Me.groupBox1.Controls.Add(Me.label7)
   Me.groupBox1.Controls.Add(Me.label8)
   Me.groupBox1.Controls.Add(Me.label5)
   Me.groupBox1.Controls.Add(Me.label4)
   Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
   Me.groupBox1.Location = New System.Drawing.Point(12, 12)
   Me.groupBox1.Name = "groupBox1"
   Me.groupBox1.Size = New System.Drawing.Size(394, 212)
   Me.groupBox1.TabIndex = 44
   Me.groupBox1.TabStop = False
   Me.groupBox1.Text = "How to use this demo:"
   ' 
   ' label16
   ' 
   Me.label16.AutoSize = True
   Me.label16.Location = New System.Drawing.Point(6, 181)
   Me.label16.Name = "label16"
   Me.label16.Size = New System.Drawing.Size(108, 15)
   Me.label16.TabIndex = 57
   Me.label16.Text = "6.Select one of the"
   ' 
   ' label14
   ' 
   Me.label14.AutoSize = True
   Me.label14.Location = New System.Drawing.Point(6, 159)
   Me.label14.Name = "label14"
   Me.label14.Size = New System.Drawing.Size(118, 15)
   Me.label14.TabIndex = 55
   Me.label14.Text = "5. Select the desired"
   ' 
   ' label6
   ' 
   Me.label6.AutoSize = True
   Me.label6.Location = New System.Drawing.Point(6, 45)
   Me.label6.Name = "label6"
   Me.label6.Size = New System.Drawing.Size(54, 15)
   Me.label6.TabIndex = 46
   Me.label6.Text = "2. Select"
   ' 
   ' label1
   ' 
   Me.label1.AutoSize = True
   Me.label1.Location = New System.Drawing.Point(6, 23)
   Me.label1.Name = "label1"
   Me.label1.Size = New System.Drawing.Size(189, 15)
   Me.label1.TabIndex = 44
   Me.label1.Text = "1. Capture image using any of the"
   ' 
   ' label17
   ' 
   Me.label17.AutoSize = True
   Me.label17.Cursor = System.Windows.Forms.Cursors.Hand
   Me.label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0F, (CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle)), System.Drawing.GraphicsUnit.Point, (CByte(0)))
   Me.label17.ForeColor = System.Drawing.Color.Blue
   Me.label17.Location = New System.Drawing.Point(110, 181)
   Me.label17.Name = "label17"
   Me.label17.Size = New System.Drawing.Size(101, 15)
   Me.label17.TabIndex = 58
   Me.label17.Tag = "4"
   Me.label17.Text = "Export Options"
'		 Me.label17.MouseLeave += New System.EventHandler(Me.label_MouseLeave);
'		 Me.label17.MouseEnter += New System.EventHandler(Me.label_MouseEnter);
   ' 
   ' label15
   ' 
   Me.label15.AutoSize = True
   Me.label15.Cursor = System.Windows.Forms.Cursors.Hand
   Me.label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0F, (CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle)), System.Drawing.GraphicsUnit.Point, (CByte(0)))
   Me.label15.ForeColor = System.Drawing.Color.Blue
   Me.label15.Location = New System.Drawing.Point(121, 159)
   Me.label15.Name = "label15"
   Me.label15.Size = New System.Drawing.Size(91, 15)
   Me.label15.TabIndex = 56
   Me.label15.Tag = "3"
   Me.label15.Text = "Compression"
'		 Me.label15.MouseLeave += New System.EventHandler(Me.label_MouseLeave);
'		 Me.label15.MouseEnter += New System.EventHandler(Me.label_MouseEnter);
   ' 
   ' label13
   ' 
   Me.label13.AutoSize = True
   Me.label13.Location = New System.Drawing.Point(6, 137)
   Me.label13.Name = "label13"
   Me.label13.Size = New System.Drawing.Size(208, 15)
   Me.label13.TabIndex = 54
   Me.label13.Text = "4. Select the image(s) for conversion "
   ' 
   ' label12
   ' 
   Me.label12.AutoSize = True
   Me.label12.Location = New System.Drawing.Point(41, 115)
   Me.label12.Name = "label12"
   Me.label12.Size = New System.Drawing.Size(247, 15)
   Me.label12.TabIndex = 53
   Me.label12.Text = "Skip this process if manual entry is desired.  "
   ' 
   ' label11
   ' 
   Me.label11.AutoSize = True
   Me.label11.ForeColor = System.Drawing.Color.Red
   Me.label11.Location = New System.Drawing.Point(6, 115)
   Me.label11.Name = "label11"
   Me.label11.Size = New System.Drawing.Size(39, 15)
   Me.label11.TabIndex = 52
   Me.label11.Text = "Note: "
   ' 
   ' label10
   ' 
   Me.label10.AutoSize = True
   Me.label10.Location = New System.Drawing.Point(17, 99)
   Me.label10.Name = "label10"
   Me.label10.Size = New System.Drawing.Size(185, 15)
   Me.label10.TabIndex = 51
   Me.label10.Text = " data to the DICOM editor list box"
   ' 
   ' label9
   ' 
   Me.label9.AutoSize = True
   Me.label9.Location = New System.Drawing.Point(202, 83)
   Me.label9.Name = "label9"
   Me.label9.Size = New System.Drawing.Size(187, 15)
   Me.label9.TabIndex = 50
   Me.label9.Text = "and select an item to transfer the "
   ' 
   ' label7
   ' 
   Me.label7.AutoSize = True
   Me.label7.Cursor = System.Windows.Forms.Cursors.Hand
   Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0F, (CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle)), System.Drawing.GraphicsUnit.Point, (CByte(0)))
   Me.label7.ForeColor = System.Drawing.Color.Blue
   Me.label7.Location = New System.Drawing.Point(17, 83)
   Me.label7.Name = "label7"
   Me.label7.Size = New System.Drawing.Size(192, 15)
   Me.label7.TabIndex = 49
   Me.label7.Tag = "2"
   Me.label7.Text = "Metadata Collection Options "
'		 Me.label7.MouseLeave += New System.EventHandler(Me.label_MouseLeave);
'		 Me.label7.MouseEnter += New System.EventHandler(Me.label_MouseEnter);
   ' 
   ' label8
   ' 
   Me.label8.AutoSize = True
   Me.label8.Location = New System.Drawing.Point(6, 67)
   Me.label8.Name = "label8"
   Me.label8.Size = New System.Drawing.Size(274, 15)
   Me.label8.TabIndex = 48
   Me.label8.Text = "3. Gather patient/study metadata using any of the "
   ' 
   ' label5
   ' 
   Me.label5.AutoSize = True
   Me.label5.Cursor = System.Windows.Forms.Cursors.Hand
   Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0F, (CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle)), System.Drawing.GraphicsUnit.Point, (CByte(0)))
   Me.label5.ForeColor = System.Drawing.Color.Blue
   Me.label5.Location = New System.Drawing.Point(56, 45)
   Me.label5.Name = "label5"
   Me.label5.Size = New System.Drawing.Size(132, 15)
   Me.label5.TabIndex = 47
   Me.label5.Tag = "1"
   Me.label5.Text = "Output DICOM Type"
'		 Me.label5.MouseLeave += New System.EventHandler(Me.label_MouseLeave);
'		 Me.label5.MouseEnter += New System.EventHandler(Me.label_MouseEnter);
   ' 
   ' label4
   ' 
   Me.label4.AutoSize = True
   Me.label4.Cursor = System.Windows.Forms.Cursors.Hand
   Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0F, (CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle)), System.Drawing.GraphicsUnit.Point, (CByte(0)))
   Me.label4.ForeColor = System.Drawing.Color.Blue
   Me.label4.Location = New System.Drawing.Point(192, 23)
   Me.label4.Name = "label4"
   Me.label4.Size = New System.Drawing.Size(110, 15)
   Me.label4.TabIndex = 45
   Me.label4.Tag = "0"
   Me.label4.Text = "Capture Options"
'		 Me.label4.MouseLeave += New System.EventHandler(Me.label_MouseLeave);
'		 Me.label4.MouseEnter += New System.EventHandler(Me.label_MouseEnter);
   ' 
   ' groupBox2
   ' 
   Me.groupBox2.Controls.Add(Me.richTextBox1)
   Me.groupBox2.Location = New System.Drawing.Point(12, 230)
   Me.groupBox2.Name = "groupBox2"
   Me.groupBox2.Size = New System.Drawing.Size(394, 289)
   Me.groupBox2.TabIndex = 46
   Me.groupBox2.TabStop = False
   ' 
   ' richTextBox1
   ' 
   Me.richTextBox1.BackColor = System.Drawing.Color.White
   Me.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
   Me.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText
   Me.richTextBox1.Location = New System.Drawing.Point(3, 16)
   Me.richTextBox1.Name = "richTextBox1"
   Me.richTextBox1.ReadOnly = True
   Me.richTextBox1.Size = New System.Drawing.Size(388, 270)
   Me.richTextBox1.TabIndex = 46
   Me.richTextBox1.Text = ""
   ' 
   ' FrmUsage
   ' 
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.ClientSize = New System.Drawing.Size(418, 527)
   Me.Controls.Add(Me.groupBox2)
   Me.Controls.Add(Me.groupBox1)
   Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
   Me.MinimizeBox = False
   Me.Name = "FrmUsage"
   Me.ShowIcon = False
   Me.ShowInTaskbar = False
   Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
   Me.Text = "Print To PACS Demo How To Use"
'		 Me.Load += New System.EventHandler(Me.FrmUsage2_Load);
   Me.groupBox1.ResumeLayout(False)
   Me.groupBox1.PerformLayout()
   Me.groupBox2.ResumeLayout(False)
   Me.ResumeLayout(False)

   End Sub

#End Region

   Private groupBox1 As System.Windows.Forms.GroupBox
   Private WithEvents label17 As System.Windows.Forms.Label
   Private label16 As System.Windows.Forms.Label
   Private WithEvents label15 As System.Windows.Forms.Label
   Private label14 As System.Windows.Forms.Label
   Private label13 As System.Windows.Forms.Label
   Private label12 As System.Windows.Forms.Label
   Private label11 As System.Windows.Forms.Label
   Private label10 As System.Windows.Forms.Label
   Private label9 As System.Windows.Forms.Label
   Private WithEvents label7 As System.Windows.Forms.Label
   Private label8 As System.Windows.Forms.Label
   Private WithEvents label5 As System.Windows.Forms.Label
   Private label6 As System.Windows.Forms.Label
   Private WithEvents label4 As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private groupBox2 As System.Windows.Forms.GroupBox
   Private richTextBox1 As System.Windows.Forms.RichTextBox

   End Class
End Namespace