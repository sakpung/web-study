Namespace MedicalViewerDemo
   Partial Class AdaptiveContrastDialog
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
         Me._gbOptions = New System.Windows.Forms.GroupBox()
         Me._numAmount = New System.Windows.Forms.NumericUpDown()
         Me._numSize = New System.Windows.Forms.NumericUpDown()
         Me._lblRadius = New System.Windows.Forms.Label()
         Me._lblAmount = New System.Windows.Forms.Label()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._lblColorSpace = New System.Windows.Forms.Label()
         Me._cbType = New System.Windows.Forms.ComboBox()
         Me._btnApply = New System.Windows.Forms.Button()
         Me._gbOptions.SuspendLayout()
         CType(Me._numAmount, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numSize, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _gbOptions
         ' 
         Me._gbOptions.Controls.Add(Me._numAmount)
         Me._gbOptions.Controls.Add(Me._numSize)
         Me._gbOptions.Controls.Add(Me._lblRadius)
         Me._gbOptions.Controls.Add(Me._lblAmount)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(9, 10)
         Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
         Me._gbOptions.Size = New System.Drawing.Size(208, 81)
         Me._gbOptions.TabIndex = 0
         Me._gbOptions.TabStop = False
         Me._gbOptions.Text = "Parameters"
         ' 
         ' _numAmount
         ' 
         Me._numAmount.Location = New System.Drawing.Point(83, 48)
         Me._numAmount.Margin = New System.Windows.Forms.Padding(2)
         Me._numAmount.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
         Me._numAmount.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
         Me._numAmount.Name = "_numAmount"
         Me._numAmount.Size = New System.Drawing.Size(109, 20)
         Me._numAmount.TabIndex = 11
         Me._numAmount.Value = New Decimal(New Integer() {255, 0, 0, 0})
         ' 
         ' _numSize
         ' 
         Me._numSize.Location = New System.Drawing.Point(83, 18)
         Me._numSize.Margin = New System.Windows.Forms.Padding(2)
         Me._numSize.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
         Me._numSize.Name = "_numSize"
         Me._numSize.Size = New System.Drawing.Size(109, 20)
         Me._numSize.TabIndex = 10
         Me._numSize.Value = New Decimal(New Integer() {9, 0, 0, 0})
         ' 
         ' _lblRadius
         ' 
         Me._lblRadius.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblRadius.Location = New System.Drawing.Point(14, 48)
         Me._lblRadius.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblRadius.Name = "_lblRadius"
         Me._lblRadius.Size = New System.Drawing.Size(65, 22)
         Me._lblRadius.TabIndex = 2
         Me._lblRadius.Text = "Amount:"
         Me._lblRadius.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _lblAmount
         ' 
         Me._lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblAmount.Location = New System.Drawing.Point(14, 18)
         Me._lblAmount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblAmount.Name = "_lblAmount"
         Me._lblAmount.Size = New System.Drawing.Size(65, 22)
         Me._lblAmount.TabIndex = 0
         Me._lblAmount.Text = "Size:"
         Me._lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(235, 98)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(68, 22)
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(235, 55)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(68, 22)
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "OK"
         ' 
         ' _lblColorSpace
         ' 
         Me._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblColorSpace.Location = New System.Drawing.Point(23, 104)
         Me._lblColorSpace.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblColorSpace.Name = "_lblColorSpace"
         Me._lblColorSpace.Size = New System.Drawing.Size(65, 22)
         Me._lblColorSpace.TabIndex = 10
         Me._lblColorSpace.Text = "Type:"
         Me._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _cbType
         ' 
         Me._cbType.FormattingEnabled = True
         Me._cbType.Items.AddRange(New Object() {"Exponential", "Linear"})
         Me._cbType.Location = New System.Drawing.Point(80, 102)
         Me._cbType.Name = "_cbType"
         Me._cbType.Size = New System.Drawing.Size(121, 21)
         Me._cbType.TabIndex = 12
         ' 
         ' _btnApply
         ' 
         Me._btnApply.Location = New System.Drawing.Point(235, 12)
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.Size = New System.Drawing.Size(68, 22)
         Me._btnApply.TabIndex = 13
         Me._btnApply.Text = "Apply"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' AdaptiveContrastDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(315, 135)
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me._cbType)
         Me.Controls.Add(Me._lblColorSpace)
         Me.Controls.Add(Me._gbOptions)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Margin = New System.Windows.Forms.Padding(2)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "AdaptiveContrastDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Adaptive Contrast"
         Me._gbOptions.ResumeLayout(False)
         CType(Me._numAmount, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numSize, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _gbOptions As System.Windows.Forms.GroupBox
      Private _lblRadius As System.Windows.Forms.Label
      Private _lblAmount As System.Windows.Forms.Label
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _numAmount As System.Windows.Forms.NumericUpDown
      Private _numSize As System.Windows.Forms.NumericUpDown
      Private _lblColorSpace As System.Windows.Forms.Label
      Private _cbType As System.Windows.Forms.ComboBox
      Private WithEvents _btnApply As System.Windows.Forms.Button
   End Class
End Namespace
