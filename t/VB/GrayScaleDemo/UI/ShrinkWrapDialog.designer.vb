
Partial Class ShrinkWrapDialog
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
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._gbParameters = New System.Windows.Forms.GroupBox()
      Me._cbType = New System.Windows.Forms.ComboBox()
      Me._numThreshold = New System.Windows.Forms.NumericUpDown()
      Me.label1 = New System.Windows.Forms.Label()
      Me.label2 = New System.Windows.Forms.Label()
      Me._btnApply = New System.Windows.Forms.Button()
      Me._cbCombine = New System.Windows.Forms.ComboBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me._gbParameters.SuspendLayout()
      CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.Location = New System.Drawing.Point(168, 141)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 0
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _gbParameters
      ' 
      Me._gbParameters.Controls.Add(Me._cbCombine)
      Me._gbParameters.Controls.Add(Me.label3)
      Me._gbParameters.Controls.Add(Me._cbType)
      Me._gbParameters.Controls.Add(Me._numThreshold)
      Me._gbParameters.Controls.Add(Me.label1)
      Me._gbParameters.Controls.Add(Me.label2)
      Me._gbParameters.Location = New System.Drawing.Point(12, 8)
      Me._gbParameters.Name = "_gbParameters"
      Me._gbParameters.Size = New System.Drawing.Size(246, 127)
      Me._gbParameters.TabIndex = 1
      Me._gbParameters.TabStop = False
      Me._gbParameters.Text = "Parameters"
      ' 
      ' _cbType
      ' 
      Me._cbType.FormattingEnabled = True
      Me._cbType.Items.AddRange(New Object() {"Circle", "Rectangle"})
      Me._cbType.Location = New System.Drawing.Point(110, 53)
      Me._cbType.Name = "_cbType"
      Me._cbType.Size = New System.Drawing.Size(121, 21)
      Me._cbType.TabIndex = 5
      ' 
      ' _numThreshold
      ' 
      Me._numThreshold.Location = New System.Drawing.Point(111, 20)
      Me._numThreshold.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numThreshold.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numThreshold.Name = "_numThreshold"
      Me._numThreshold.Size = New System.Drawing.Size(120, 20)
      Me._numThreshold.TabIndex = 4
      Me._numThreshold.Value = New Decimal(New Integer() {30, 0, 0, 0})
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(31, 27)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(54, 13)
      Me.label1.TabIndex = 2
      Me.label1.Text = "Threshold"
      ' 
      ' label2
      ' 
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(31, 61)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(31, 13)
      Me.label2.TabIndex = 3
      Me.label2.Text = "Type"
      ' 
      ' _btnApply
      ' 
      Me._btnApply.Location = New System.Drawing.Point(22, 141)
      Me._btnApply.Name = "_btnApply"
      Me._btnApply.Size = New System.Drawing.Size(75, 23)
      Me._btnApply.TabIndex = 2
      Me._btnApply.Text = "Apply"
      Me._btnApply.UseVisualStyleBackColor = True
      ' 
      ' _cbCombine
      ' 
      Me._cbCombine.FormattingEnabled = True
      Me._cbCombine.Items.AddRange(New Object() {"AND", "SET", "AND NOT BITMAP", "AND NOT RGN", "OR", "XOR", _
       "SETNOT"})
      Me._cbCombine.Location = New System.Drawing.Point(110, 90)
      Me._cbCombine.Name = "_cbCombine"
      Me._cbCombine.Size = New System.Drawing.Size(121, 21)
      Me._cbCombine.TabIndex = 7
      ' 
      ' label3
      ' 
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(31, 98)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(48, 13)
      Me.label3.TabIndex = 6
      Me.label3.Text = "Combine"
      ' 
      ' ShrinkWrapDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(270, 176)
      Me.Controls.Add(Me._btnApply)
      Me.Controls.Add(Me._gbParameters)
      Me.Controls.Add(Me._btnCancel)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ShrinkWrapDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Shrink Wrap Tool"
      Me.TopMost = True
      Me._gbParameters.ResumeLayout(False)
      Me._gbParameters.PerformLayout()
      CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private _gbParameters As System.Windows.Forms.GroupBox
   Private _cbType As System.Windows.Forms.ComboBox
   Private _numThreshold As System.Windows.Forms.NumericUpDown
   Private label1 As System.Windows.Forms.Label
   Private label2 As System.Windows.Forms.Label
   Private WithEvents _btnApply As System.Windows.Forms.Button
   Private _cbCombine As System.Windows.Forms.ComboBox
   Private label3 As System.Windows.Forms.Label
End Class