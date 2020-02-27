
Partial Class SelectDataDialog
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
      Me._gbSelectData = New System.Windows.Forms.GroupBox()
      Me._cbCombine = New System.Windows.Forms.CheckBox()
      Me._numThreshold = New System.Windows.Forms.NumericUpDown()
      Me._numSourceHighBit = New System.Windows.Forms.NumericUpDown()
      Me._numSourceLowBit = New System.Windows.Forms.NumericUpDown()
      Me._lblThreshold = New System.Windows.Forms.Label()
      Me._lblSourceHighBit = New System.Windows.Forms.Label()
      Me._lblSourceLowBit = New System.Windows.Forms.Label()
      Me._lblColor = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnColor = New System.Windows.Forms.Button()
      Me._pnlColor = New System.Windows.Forms.Panel()
      Me._gbSelectData.SuspendLayout()
      CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numSourceHighBit, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numSourceLowBit, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbSelectData
      ' 
      Me._gbSelectData.Controls.Add(Me._pnlColor)
      Me._gbSelectData.Controls.Add(Me._btnColor)
      Me._gbSelectData.Controls.Add(Me._cbCombine)
      Me._gbSelectData.Controls.Add(Me._numThreshold)
      Me._gbSelectData.Controls.Add(Me._numSourceHighBit)
      Me._gbSelectData.Controls.Add(Me._numSourceLowBit)
      Me._gbSelectData.Controls.Add(Me._lblThreshold)
      Me._gbSelectData.Controls.Add(Me._lblSourceHighBit)
      Me._gbSelectData.Controls.Add(Me._lblSourceLowBit)
      Me._gbSelectData.Controls.Add(Me._lblColor)
      Me._gbSelectData.Location = New System.Drawing.Point(9, 3)
      Me._gbSelectData.Name = "_gbSelectData"
      Me._gbSelectData.Size = New System.Drawing.Size(251, 164)
      Me._gbSelectData.TabIndex = 0
      Me._gbSelectData.TabStop = False
      ' 
      ' _cbCombine
      ' 
      Me._cbCombine.AutoSize = True
      Me._cbCombine.Location = New System.Drawing.Point(18, 50)
      Me._cbCombine.Name = "_cbCombine"
      Me._cbCombine.Size = New System.Drawing.Size(67, 17)
      Me._cbCombine.TabIndex = 10
      Me._cbCombine.Text = "Combine"
      Me._cbCombine.UseVisualStyleBackColor = True
      ' 
      ' _numThreshold
      ' 
      Me._numThreshold.Location = New System.Drawing.Point(122, 131)
      Me._numThreshold.Name = "_numThreshold"
      Me._numThreshold.Size = New System.Drawing.Size(120, 20)
      Me._numThreshold.TabIndex = 9
      ' 
      ' _numSourceHighBit
      ' 
      Me._numSourceHighBit.Location = New System.Drawing.Point(122, 104)
      Me._numSourceHighBit.Name = "_numSourceHighBit"
      Me._numSourceHighBit.Size = New System.Drawing.Size(120, 20)
      Me._numSourceHighBit.TabIndex = 8
      ' 
      ' _numSourceLowBit
      ' 
      Me._numSourceLowBit.Location = New System.Drawing.Point(122, 77)
      Me._numSourceLowBit.Name = "_numSourceLowBit"
      Me._numSourceLowBit.Size = New System.Drawing.Size(120, 20)
      Me._numSourceLowBit.TabIndex = 7
      ' 
      ' _lblThreshold
      ' 
      Me._lblThreshold.AutoSize = True
      Me._lblThreshold.Location = New System.Drawing.Point(15, 133)
      Me._lblThreshold.Name = "_lblThreshold"
      Me._lblThreshold.Size = New System.Drawing.Size(60, 13)
      Me._lblThreshold.TabIndex = 4
      Me._lblThreshold.Text = "Threshold :"
      ' 
      ' _lblSourceHighBit
      ' 
      Me._lblSourceHighBit.AutoSize = True
      Me._lblSourceHighBit.Location = New System.Drawing.Point(15, 106)
      Me._lblSourceHighBit.Name = "_lblSourceHighBit"
      Me._lblSourceHighBit.Size = New System.Drawing.Size(87, 13)
      Me._lblSourceHighBit.TabIndex = 3
      Me._lblSourceHighBit.Text = "Source High Bit :"
      ' 
      ' _lblSourceLowBit
      ' 
      Me._lblSourceLowBit.AutoSize = True
      Me._lblSourceLowBit.Location = New System.Drawing.Point(15, 79)
      Me._lblSourceLowBit.Name = "_lblSourceLowBit"
      Me._lblSourceLowBit.Size = New System.Drawing.Size(85, 13)
      Me._lblSourceLowBit.TabIndex = 2
      Me._lblSourceLowBit.Text = "Source Low Bit :"
      ' 
      ' _lblColor
      ' 
      Me._lblColor.AutoSize = True
      Me._lblColor.Location = New System.Drawing.Point(15, 25)
      Me._lblColor.Name = "_lblColor"
      Me._lblColor.Size = New System.Drawing.Size(40, 13)
      Me._lblColor.TabIndex = 0
      Me._lblColor.Text = "Color : "
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(143, 172)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 19
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(58, 172)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 18
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _btnColor
      ' 
      Me._btnColor.Location = New System.Drawing.Point(122, 19)
      Me._btnColor.Name = "_btnColor"
      Me._btnColor.Size = New System.Drawing.Size(37, 24)
      Me._btnColor.TabIndex = 11
      Me._btnColor.Text = "..."
      Me._btnColor.UseVisualStyleBackColor = True
      ' 
      ' _pnlColor
      ' 
      Me._pnlColor.Location = New System.Drawing.Point(170, 19)
      Me._pnlColor.Name = "_pnlColor"
      Me._pnlColor.Size = New System.Drawing.Size(72, 24)
      Me._pnlColor.TabIndex = 12
      ' 
      ' SelectDataDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(269, 209)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gbSelectData)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SelectDataDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Select Data"
      Me._gbSelectData.ResumeLayout(False)
      Me._gbSelectData.PerformLayout()
      CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numSourceHighBit, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numSourceLowBit, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbSelectData As System.Windows.Forms.GroupBox
   Private _lblThreshold As System.Windows.Forms.Label
   Private _lblSourceHighBit As System.Windows.Forms.Label
   Private _lblSourceLowBit As System.Windows.Forms.Label
   Private _lblColor As System.Windows.Forms.Label
   Private _numThreshold As System.Windows.Forms.NumericUpDown
   Private _numSourceHighBit As System.Windows.Forms.NumericUpDown
   Private _numSourceLowBit As System.Windows.Forms.NumericUpDown
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _cbCombine As System.Windows.Forms.CheckBox
   Private _pnlColor As System.Windows.Forms.Panel
   Private WithEvents _btnColor As System.Windows.Forms.Button
End Class