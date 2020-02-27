
Partial Class SigmaDialog
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
      Me._gbSigma = New System.Windows.Forms.GroupBox()
      Me._numThreshold = New System.Windows.Forms.NumericUpDown()
      Me._numSigma = New System.Windows.Forms.NumericUpDown()
      Me._numDimension = New System.Windows.Forms.NumericUpDown()
      Me._cbOutline = New System.Windows.Forms.CheckBox()
      Me._lblThreshold = New System.Windows.Forms.Label()
      Me._lblSigma = New System.Windows.Forms.Label()
      Me._lblDimension = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbSigma.SuspendLayout()
      CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numSigma, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numDimension, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbSigma
      ' 
      Me._gbSigma.Controls.Add(Me._numThreshold)
      Me._gbSigma.Controls.Add(Me._numSigma)
      Me._gbSigma.Controls.Add(Me._numDimension)
      Me._gbSigma.Controls.Add(Me._cbOutline)
      Me._gbSigma.Controls.Add(Me._lblThreshold)
      Me._gbSigma.Controls.Add(Me._lblSigma)
      Me._gbSigma.Controls.Add(Me._lblDimension)
      Me._gbSigma.Location = New System.Drawing.Point(7, 4)
      Me._gbSigma.Name = "_gbSigma"
      Me._gbSigma.Size = New System.Drawing.Size(243, 126)
      Me._gbSigma.TabIndex = 0
      Me._gbSigma.TabStop = False
      ' 
      ' _numThreshold
      ' 
      Me._numThreshold.DecimalPlaces = 2
      Me._numThreshold.Location = New System.Drawing.Point(108, 73)
      Me._numThreshold.Name = "_numThreshold"
      Me._numThreshold.Size = New System.Drawing.Size(120, 20)
      Me._numThreshold.TabIndex = 6
      ' 
      ' _numSigma
      ' 
      Me._numSigma.Location = New System.Drawing.Point(108, 48)
      Me._numSigma.Name = "_numSigma"
      Me._numSigma.Size = New System.Drawing.Size(120, 20)
      Me._numSigma.TabIndex = 5
      ' 
      ' _numDimension
      ' 
      Me._numDimension.Location = New System.Drawing.Point(108, 23)
      Me._numDimension.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
      Me._numDimension.Name = "_numDimension"
      Me._numDimension.Size = New System.Drawing.Size(120, 20)
      Me._numDimension.TabIndex = 4
      Me._numDimension.Value = New Decimal(New Integer() {2, 0, 0, 0})
      ' 
      ' _cbOutline
      ' 
      Me._cbOutline.AutoSize = True
      Me._cbOutline.Location = New System.Drawing.Point(20, 100)
      Me._cbOutline.Name = "_cbOutline"
      Me._cbOutline.Size = New System.Drawing.Size(59, 17)
      Me._cbOutline.TabIndex = 3
      Me._cbOutline.Text = "Outline"
      Me._cbOutline.UseVisualStyleBackColor = True
      ' 
      ' _lblThreshold
      ' 
      Me._lblThreshold.AutoSize = True
      Me._lblThreshold.Location = New System.Drawing.Point(19, 75)
      Me._lblThreshold.Name = "_lblThreshold"
      Me._lblThreshold.Size = New System.Drawing.Size(60, 13)
      Me._lblThreshold.TabIndex = 2
      Me._lblThreshold.Text = "Threshold :"
      ' 
      ' _lblSigma
      ' 
      Me._lblSigma.AutoSize = True
      Me._lblSigma.Location = New System.Drawing.Point(19, 50)
      Me._lblSigma.Name = "_lblSigma"
      Me._lblSigma.Size = New System.Drawing.Size(42, 13)
      Me._lblSigma.TabIndex = 1
      Me._lblSigma.Text = "Sigma :"
      ' 
      ' _lblDimension
      ' 
      Me._lblDimension.AutoSize = True
      Me._lblDimension.Location = New System.Drawing.Point(19, 25)
      Me._lblDimension.Name = "_lblDimension"
      Me._lblDimension.Size = New System.Drawing.Size(62, 13)
      Me._lblDimension.TabIndex = 0
      Me._lblDimension.Text = "Dimension :"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(136, 135)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 11
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(52, 135)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 10
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' SigmaDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(257, 174)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gbSigma)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SigmaDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Sigma"
      Me._gbSigma.ResumeLayout(False)
      Me._gbSigma.PerformLayout()
      CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numSigma, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numDimension, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbSigma As System.Windows.Forms.GroupBox
   Private _cbOutline As System.Windows.Forms.CheckBox
   Private _lblThreshold As System.Windows.Forms.Label
   Private _lblSigma As System.Windows.Forms.Label
   Private _lblDimension As System.Windows.Forms.Label
   Private _numThreshold As System.Windows.Forms.NumericUpDown
   Private _numSigma As System.Windows.Forms.NumericUpDown
   Private _numDimension As System.Windows.Forms.NumericUpDown
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
End Class