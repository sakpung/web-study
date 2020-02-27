
Partial Class SkeletonDialog
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
      Me._numThreshold = New System.Windows.Forms.NumericUpDown()
      Me._lblThreshold = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me.groupBox1.SuspendLayout()
      CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.Add(Me._numThreshold)
      Me.groupBox1.Controls.Add(Me._lblThreshold)
      Me.groupBox1.Location = New System.Drawing.Point(10, 10)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(227, 49)
      Me.groupBox1.TabIndex = 0
      Me.groupBox1.TabStop = False
      ' 
      ' _numThreshold
      ' 
      Me._numThreshold.Location = New System.Drawing.Point(86, 19)
      Me._numThreshold.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
      Me._numThreshold.Name = "_numThreshold"
      Me._numThreshold.Size = New System.Drawing.Size(120, 20)
      Me._numThreshold.TabIndex = 1
      ' 
      ' _lblThreshold
      ' 
      Me._lblThreshold.AutoSize = True
      Me._lblThreshold.Location = New System.Drawing.Point(16, 21)
      Me._lblThreshold.Name = "_lblThreshold"
      Me._lblThreshold.Size = New System.Drawing.Size(60, 13)
      Me._lblThreshold.TabIndex = 0
      Me._lblThreshold.Text = "Threshold :"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(132, 64)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 17
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(47, 64)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 16
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' SkeletonDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(247, 104)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me.groupBox1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SkeletonDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Skeleton"
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private groupBox1 As System.Windows.Forms.GroupBox
   Private _numThreshold As System.Windows.Forms.NumericUpDown
   Private _lblThreshold As System.Windows.Forms.Label
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
End Class