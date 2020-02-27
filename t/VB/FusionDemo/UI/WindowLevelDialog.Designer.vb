
Partial Class WindowLevelDialog
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
      Me._btnOk = New System.Windows.Forms.Button()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._lbl = New System.Windows.Forms.Label()
      Me._lblStart = New System.Windows.Forms.Label()
      Me._numWidth = New System.Windows.Forms.NumericUpDown()
      Me._numLevel = New System.Windows.Forms.NumericUpDown()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me.groupBox1.SuspendLayout()
      CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.Location = New System.Drawing.Point(225, 40)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 0
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.Add(Me._lbl)
      Me.groupBox1.Controls.Add(Me._lblStart)
      Me.groupBox1.Controls.Add(Me._numWidth)
      Me.groupBox1.Controls.Add(Me._numLevel)
      Me.groupBox1.Location = New System.Drawing.Point(12, 12)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(200, 120)
      Me.groupBox1.TabIndex = 1
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "W/L Values"
      ' 
      ' _
      ' 
      Me._lbl.AutoSize = True
      Me._lbl.Location = New System.Drawing.Point(19, 75)
      Me._lbl.Name = "_"
      Me._lbl.Size = New System.Drawing.Size(35, 13)
      Me._lbl.TabIndex = 3
      Me._lbl.Text = "Width"
      ' 
      ' _lblStart
      ' 
      Me._lblStart.AutoSize = True
      Me._lblStart.Location = New System.Drawing.Point(19, 33)
      Me._lblStart.Name = "_lblStart"
      Me._lblStart.Size = New System.Drawing.Size(33, 13)
      Me._lblStart.TabIndex = 2
      Me._lblStart.Text = "Level"
      ' 
      ' _numWidth
      ' 
      Me._numWidth.Location = New System.Drawing.Point(74, 73)
      Me._numWidth.Name = "_numWidth"
      Me._numWidth.Size = New System.Drawing.Size(120, 20)
      Me._numWidth.TabIndex = 1
      ' 
      ' _numLevel
      ' 
      Me._numLevel.Location = New System.Drawing.Point(74, 31)
      Me._numLevel.Name = "_numLevel"
      Me._numLevel.Size = New System.Drawing.Size(120, 20)
      Me._numLevel.TabIndex = 0
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(225, 69)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 2
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' WindowLevelDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(329, 153)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me.groupBox1)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "WindowLevelDialog"
      Me.Text = "Window Level Dialog"
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numLevel, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private _lbl As System.Windows.Forms.Label
   Private _lblStart As System.Windows.Forms.Label
   Private _numWidth As System.Windows.Forms.NumericUpDown
   Private _numLevel As System.Windows.Forms.NumericUpDown
   Private _btnCancel As System.Windows.Forms.Button
End Class