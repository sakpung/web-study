
Partial Class MeanShiftDialog
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
      Me._gbMeanShift = New System.Windows.Forms.GroupBox()
      Me._numColorDistance = New System.Windows.Forms.NumericUpDown()
      Me._numRadius = New System.Windows.Forms.NumericUpDown()
      Me._lblColorDistance = New System.Windows.Forms.Label()
      Me._lblRadius = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbMeanShift.SuspendLayout()
      CType(Me._numColorDistance, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numRadius, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbMeanShift
      ' 
      Me._gbMeanShift.Controls.Add(Me._numColorDistance)
      Me._gbMeanShift.Controls.Add(Me._numRadius)
      Me._gbMeanShift.Controls.Add(Me._lblColorDistance)
      Me._gbMeanShift.Controls.Add(Me._lblRadius)
      Me._gbMeanShift.Location = New System.Drawing.Point(6, 1)
      Me._gbMeanShift.Name = "_gbMeanShift"
      Me._gbMeanShift.Size = New System.Drawing.Size(210, 97)
      Me._gbMeanShift.TabIndex = 0
      Me._gbMeanShift.TabStop = False
      ' 
      ' _numColorDistance
      ' 
      Me._numColorDistance.Location = New System.Drawing.Point(107, 55)
      Me._numColorDistance.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numColorDistance.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numColorDistance.Name = "_numColorDistance"
      Me._numColorDistance.Size = New System.Drawing.Size(91, 20)
      Me._numColorDistance.TabIndex = 3
      Me._numColorDistance.Value = New Decimal(New Integer() {1, 0, 0, 0})
      ' 
      ' _numRadius
      ' 
      Me._numRadius.Location = New System.Drawing.Point(107, 19)
      Me._numRadius.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
      Me._numRadius.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numRadius.Name = "_numRadius"
      Me._numRadius.Size = New System.Drawing.Size(91, 20)
      Me._numRadius.TabIndex = 2
      Me._numRadius.Value = New Decimal(New Integer() {1, 0, 0, 0})
      ' 
      ' _lblColorDistance
      ' 
      Me._lblColorDistance.AutoSize = True
      Me._lblColorDistance.Location = New System.Drawing.Point(22, 57)
      Me._lblColorDistance.Name = "_lblColorDistance"
      Me._lblColorDistance.Size = New System.Drawing.Size(79, 13)
      Me._lblColorDistance.TabIndex = 1
      Me._lblColorDistance.Text = "ColorDistance :"
      ' 
      ' _lblRadius
      ' 
      Me._lblRadius.AutoSize = True
      Me._lblRadius.Location = New System.Drawing.Point(17, 20)
      Me._lblRadius.Name = "_lblRadius"
      Me._lblRadius.Size = New System.Drawing.Size(46, 13)
      Me._lblRadius.TabIndex = 0
      Me._lblRadius.Text = "Radius :"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(120, 103)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 15
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(35, 103)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 14
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' MeanShiftDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(222, 135)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gbMeanShift)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "MeanShiftDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Mean Shift"
      Me._gbMeanShift.ResumeLayout(False)
      Me._gbMeanShift.PerformLayout()
      CType(Me._numColorDistance, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numRadius, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbMeanShift As System.Windows.Forms.GroupBox
   Private _numColorDistance As System.Windows.Forms.NumericUpDown
   Private _numRadius As System.Windows.Forms.NumericUpDown
   Private _lblColorDistance As System.Windows.Forms.Label
   Private _lblRadius As System.Windows.Forms.Label
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
End Class