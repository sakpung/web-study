
Partial Class RenameOmrFieldsDlg
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
      Me._rbAlpha = New System.Windows.Forms.RadioButton()
      Me._rbNum1 = New System.Windows.Forms.RadioButton()
      Me._txtPrefix = New System.Windows.Forms.TextBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me._btnOK = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me.label2 = New System.Windows.Forms.Label()
      Me._lblName = New System.Windows.Forms.Label()
      Me._numStartsWith = New System.Windows.Forms.NumericUpDown()
      Me._rbStartsWith = New System.Windows.Forms.RadioButton()
      Me.groupBox1.SuspendLayout()
      CType(Me._numStartsWith, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.Add(Me._numStartsWith)
      Me.groupBox1.Controls.Add(Me._rbAlpha)
      Me.groupBox1.Controls.Add(Me._rbNum1)
      Me.groupBox1.Controls.Add(Me._rbStartsWith)
      Me.groupBox1.Location = New System.Drawing.Point(154, 6)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(114, 114)
      Me.groupBox1.TabIndex = 0
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Postfix"
      ' 
      ' _rbAlpha
      ' 
      Me._rbAlpha.AutoSize = True
      Me._rbAlpha.Location = New System.Drawing.Point(6, 42)
      Me._rbAlpha.Name = "_rbAlpha"
      Me._rbAlpha.Size = New System.Drawing.Size(72, 17)
      Me._rbAlpha.TabIndex = 5
      Me._rbAlpha.Text = "A B C D..."
      Me._rbAlpha.UseVisualStyleBackColor = True
      ' 
      ' _rbNum1
      ' 
      Me._rbNum1.AutoSize = True
      Me._rbNum1.Checked = True
      Me._rbNum1.Location = New System.Drawing.Point(6, 19)
      Me._rbNum1.Name = "_rbNum1"
      Me._rbNum1.Size = New System.Drawing.Size(67, 17)
      Me._rbNum1.TabIndex = 5
      Me._rbNum1.TabStop = True
      Me._rbNum1.Text = "1 2 3 4..."
      Me._rbNum1.UseVisualStyleBackColor = True
      ' 
      ' _txtPrefix
      ' 
      Me._txtPrefix.Location = New System.Drawing.Point(48, 12)
      Me._txtPrefix.Name = "_txtPrefix"
      Me._txtPrefix.Size = New System.Drawing.Size(100, 20)
      Me._txtPrefix.TabIndex = 1
      Me._txtPrefix.Text = "Q1"
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(7, 15)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(33, 13)
      Me.label1.TabIndex = 2
      Me.label1.Text = "Prefix"
      ' 
      ' _btnOK
      ' 
      Me._btnOK.Location = New System.Drawing.Point(48, 126)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(75, 23)
      Me._btnOK.TabIndex = 3
      Me._btnOK.Text = "OK"
      Me._btnOK.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.Location = New System.Drawing.Point(137, 126)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 4
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' label2
      ' 
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(12, 48)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(73, 13)
      Me.label2.TabIndex = 5
      Me.label2.Text = "Sample Name"
      ' 
      ' _lblName
      ' 
      Me._lblName.AutoSize = True
      Me._lblName.Location = New System.Drawing.Point(18, 71)
      Me._lblName.Name = "_lblName"
      Me._lblName.Size = New System.Drawing.Size(0, 13)
      Me._lblName.TabIndex = 6
      ' 
      ' _numStartsWith
      ' 
      Me._numStartsWith.Location = New System.Drawing.Point(58, 88)
      Me._numStartsWith.Name = "_numStartsWith"
      Me._numStartsWith.Size = New System.Drawing.Size(50, 20)
      Me._numStartsWith.TabIndex = 7
      ' 
      ' _rbStartsWith
      ' 
      Me._rbStartsWith.AutoSize = True
      Me._rbStartsWith.Location = New System.Drawing.Point(7, 66)
      Me._rbStartsWith.Name = "_rbStartsWith"
      Me._rbStartsWith.Size = New System.Drawing.Size(74, 17)
      Me._rbStartsWith.TabIndex = 8
      Me._rbStartsWith.TabStop = True
      Me._rbStartsWith.Text = "Starts with"
      Me._rbStartsWith.UseVisualStyleBackColor = True
      ' 
      ' RenameOmrFieldsDlg
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(276, 161)
      Me.Controls.Add(Me._lblName)
      Me.Controls.Add(Me.label2)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOK)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me._txtPrefix)
      Me.Controls.Add(Me.groupBox1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "RenameOmrFieldsDlg"
      Me.ShowIcon = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Rename Omr Fields"
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      CType(Me._numStartsWith, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private groupBox1 As System.Windows.Forms.GroupBox
   Private WithEvents _rbAlpha As System.Windows.Forms.RadioButton
   Private WithEvents _rbNum1 As System.Windows.Forms.RadioButton
   Private WithEvents _txtPrefix As System.Windows.Forms.TextBox
   Private label1 As System.Windows.Forms.Label
   Private WithEvents _btnOK As System.Windows.Forms.Button
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private label2 As System.Windows.Forms.Label
   Private _lblName As System.Windows.Forms.Label
   Private WithEvents _numStartsWith As System.Windows.Forms.NumericUpDown
   Private WithEvents _rbStartsWith As System.Windows.Forms.RadioButton
End Class