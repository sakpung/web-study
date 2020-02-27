Imports Microsoft.VisualBasic
Imports System
Namespace DocumentWritersDemo
   Partial Class InsertBookmarkForm
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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._tbY = New System.Windows.Forms.TextBox()
         Me.label4 = New System.Windows.Forms.Label()
         Me._tbX = New System.Windows.Forms.TextBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me._cbPageNumber = New System.Windows.Forms.ComboBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me._tbName = New System.Windows.Forms.TextBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me.panel1 = New System.Windows.Forms.Panel()
         Me.label7 = New System.Windows.Forms.Label()
         Me.label6 = New System.Windows.Forms.Label()
         Me.label5 = New System.Windows.Forms.Label()
         Me.pictureBox1 = New System.Windows.Forms.PictureBox()
         Me.groupBox1.SuspendLayout()
         Me.panel1.SuspendLayout()
         CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.groupBox1.Controls.Add(Me._tbY)
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me._tbX)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me._cbPageNumber)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me._tbName)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(12, 96)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(342, 138)
         Me.groupBox1.TabIndex = 0
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Bookmark Properties"
         ' 
         ' _tbY
         ' 
         Me._tbY.Location = New System.Drawing.Point(87, 101)
         Me._tbY.Name = "_tbY"
         Me._tbY.Size = New System.Drawing.Size(79, 20)
         Me._tbY.TabIndex = 7
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(6, 104)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(57, 13)
         Me.label4.TabIndex = 6
         Me.label4.Text = "Position Y:"
         ' 
         ' _tbX
         ' 
         Me._tbX.Location = New System.Drawing.Point(87, 75)
         Me._tbX.Name = "_tbX"
         Me._tbX.Size = New System.Drawing.Size(79, 20)
         Me._tbX.TabIndex = 5
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(6, 78)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(57, 13)
         Me.label3.TabIndex = 4
         Me.label3.Text = "Position X:"
         ' 
         ' _cbPageNumber
         ' 
         Me._cbPageNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbPageNumber.FormattingEnabled = True
         Me._cbPageNumber.Location = New System.Drawing.Point(87, 48)
         Me._cbPageNumber.Name = "_cbPageNumber"
         Me._cbPageNumber.Size = New System.Drawing.Size(79, 21)
         Me._cbPageNumber.TabIndex = 3
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(6, 51)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(75, 13)
         Me.label2.TabIndex = 2
         Me.label2.Text = "Page Number:"
         ' 
         ' _tbName
         ' 
         Me._tbName.Location = New System.Drawing.Point(87, 22)
         Me._tbName.Name = "_tbName"
         Me._tbName.Size = New System.Drawing.Size(249, 20)
         Me._tbName.TabIndex = 1
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(6, 25)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(38, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Name:"
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(279, 240)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 1
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOk
         ' 
         Me._btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.Location = New System.Drawing.Point(198, 240)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(75, 23)
         Me._btnOk.TabIndex = 2
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         ' 
         ' panel1
         ' 
         Me.panel1.BackColor = System.Drawing.SystemColors.HighlightText
         Me.panel1.Controls.Add(Me.label7)
         Me.panel1.Controls.Add(Me.label6)
         Me.panel1.Controls.Add(Me.label5)
         Me.panel1.Controls.Add(Me.pictureBox1)
         Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
         Me.panel1.Location = New System.Drawing.Point(0, 0)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(366, 90)
         Me.panel1.TabIndex = 3
         ' 
         ' label7
         ' 
         Me.label7.AutoSize = True
         Me.label7.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me.label7.ForeColor = System.Drawing.Color.Red
         Me.label7.Location = New System.Drawing.Point(96, 70)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(253, 13)
         Me.label7.TabIndex = 3
         Me.label7.Text = "Bookmarks are ONLY available when saving to PDF."
         ' 
         ' label6
         ' 
         Me.label6.Location = New System.Drawing.Point(96, 29)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(265, 41)
         Me.label6.TabIndex = 2
         Me.label6.Text = "You can specify the bookmark X and Y coordinates by going back to the image and c" & "lick where you wish the bookmark to point at."
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me.label5.Location = New System.Drawing.Point(96, 12)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(175, 13)
         Me.label5.TabIndex = 1
         Me.label5.Text = "Inserting bookmarks into PDF"
         ' 
         ' pictureBox1
         ' 
         Me.pictureBox1.Image = Global.DocumentWritersDemo.Resources.Bookmark
         Me.pictureBox1.Location = New System.Drawing.Point(12, 12)
         Me.pictureBox1.Name = "pictureBox1"
         Me.pictureBox1.Size = New System.Drawing.Size(64, 64)
         Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
         Me.pictureBox1.TabIndex = 0
         Me.pictureBox1.TabStop = False
         ' 
         ' InsertBookmarkForm
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(366, 275)
         Me.Controls.Add(Me.panel1)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "InsertBookmarkForm"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Insert Bookmark"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.panel1.ResumeLayout(False)
         Me.panel1.PerformLayout()
         CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private label1 As System.Windows.Forms.Label
      Private WithEvents _tbName As System.Windows.Forms.TextBox
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private WithEvents _cbPageNumber As System.Windows.Forms.ComboBox
      Private label4 As System.Windows.Forms.Label
      Private panel1 As System.Windows.Forms.Panel
      Private label5 As System.Windows.Forms.Label
      Private pictureBox1 As System.Windows.Forms.PictureBox
      Private label6 As System.Windows.Forms.Label
      Private WithEvents _tbY As System.Windows.Forms.TextBox
      Private WithEvents _tbX As System.Windows.Forms.TextBox
      Private label7 As System.Windows.Forms.Label
   End Class
End Namespace
