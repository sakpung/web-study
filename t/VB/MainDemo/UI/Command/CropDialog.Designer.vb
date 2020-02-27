Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Partial Public Class CropDialog
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
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._gbOptions = New System.Windows.Forms.GroupBox()
         Me._numHeight = New System.Windows.Forms.NumericUpDown()
         Me._numWidth = New System.Windows.Forms.NumericUpDown()
         Me._numTop = New System.Windows.Forms.NumericUpDown()
         Me._numLeft = New System.Windows.Forms.NumericUpDown()
         Me._lblHeight = New System.Windows.Forms.Label()
         Me._lblWidth = New System.Windows.Forms.Label()
         Me._lblTop = New System.Windows.Forms.Label()
         Me._lblLeft = New System.Windows.Forms.Label()
         Me._gbOptions.SuspendLayout()
         CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numTop, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numLeft, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(317, 55)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(90, 27)
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(317, 18)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(90, 27)
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         ' 
         ' _gbOptions
         ' 
         Me._gbOptions.Controls.Add(Me._numHeight)
         Me._gbOptions.Controls.Add(Me._numWidth)
         Me._gbOptions.Controls.Add(Me._numTop)
         Me._gbOptions.Controls.Add(Me._numLeft)
         Me._gbOptions.Controls.Add(Me._lblHeight)
         Me._gbOptions.Controls.Add(Me._lblWidth)
         Me._gbOptions.Controls.Add(Me._lblTop)
         Me._gbOptions.Controls.Add(Me._lblLeft)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(10, 9)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Size = New System.Drawing.Size(278, 166)
         Me._gbOptions.TabIndex = 0
         Me._gbOptions.TabStop = False
         ' 
         ' _numHeight
         ' 
         Me._numHeight.Location = New System.Drawing.Point(115, 129)
         Me._numHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
         Me._numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numHeight.Name = "_numHeight"
         Me._numHeight.Size = New System.Drawing.Size(144, 22)
         Me._numHeight.TabIndex = 7
         Me._numHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '		 Me._numHeight.Leave += New System.EventHandler(Me._num_Leave);
         ' 
         ' _numWidth
         ' 
         Me._numWidth.Location = New System.Drawing.Point(115, 92)
         Me._numWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
         Me._numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numWidth.Name = "_numWidth"
         Me._numWidth.Size = New System.Drawing.Size(144, 22)
         Me._numWidth.TabIndex = 5
         Me._numWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '		 Me._numWidth.Leave += New System.EventHandler(Me._num_Leave);
         ' 
         ' _numTop
         ' 
         Me._numTop.Location = New System.Drawing.Point(115, 55)
         Me._numTop.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
         Me._numTop.Name = "_numTop"
         Me._numTop.Size = New System.Drawing.Size(144, 22)
         Me._numTop.TabIndex = 3
         Me._numTop.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '		 Me._numTop.Leave += New System.EventHandler(Me._num_Leave);
         ' 
         ' _numLeft
         ' 
         Me._numLeft.Location = New System.Drawing.Point(115, 18)
         Me._numLeft.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
         Me._numLeft.Name = "_numLeft"
         Me._numLeft.Size = New System.Drawing.Size(144, 22)
         Me._numLeft.TabIndex = 1
         Me._numLeft.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '		 Me._numLeft.Leave += New System.EventHandler(Me._num_Leave);
         ' 
         ' _lblHeight
         ' 
         Me._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblHeight.Location = New System.Drawing.Point(19, 129)
         Me._lblHeight.Name = "_lblHeight"
         Me._lblHeight.Size = New System.Drawing.Size(77, 27)
         Me._lblHeight.TabIndex = 6
         Me._lblHeight.Text = "Height"
         Me._lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _lblWidth
         ' 
         Me._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblWidth.Location = New System.Drawing.Point(19, 92)
         Me._lblWidth.Name = "_lblWidth"
         Me._lblWidth.Size = New System.Drawing.Size(77, 27)
         Me._lblWidth.TabIndex = 4
         Me._lblWidth.Text = "Width"
         Me._lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _lblTop
         ' 
         Me._lblTop.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblTop.Location = New System.Drawing.Point(19, 55)
         Me._lblTop.Name = "_lblTop"
         Me._lblTop.Size = New System.Drawing.Size(77, 27)
         Me._lblTop.TabIndex = 2
         Me._lblTop.Text = "Top"
         Me._lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _lblLeft
         ' 
         Me._lblLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblLeft.Location = New System.Drawing.Point(19, 18)
         Me._lblLeft.Name = "_lblLeft"
         Me._lblLeft.Size = New System.Drawing.Size(77, 27)
         Me._lblLeft.TabIndex = 0
         Me._lblLeft.Text = "Left"
         Me._lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' CropDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0F, 16.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(420, 190)
         Me.Controls.Add(Me._gbOptions)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "CropDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Crop (Trim)"
         '		 Me.Load += New System.EventHandler(Me.CropDialog_Load);
         Me._gbOptions.ResumeLayout(False)
         CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numTop, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numLeft, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _gbOptions As System.Windows.Forms.GroupBox
      Private WithEvents _numWidth As System.Windows.Forms.NumericUpDown
      Private WithEvents _numTop As System.Windows.Forms.NumericUpDown
      Private WithEvents _numLeft As System.Windows.Forms.NumericUpDown
      Private _lblHeight As System.Windows.Forms.Label
      Private _lblWidth As System.Windows.Forms.Label
      Private _lblTop As System.Windows.Forms.Label
      Private _lblLeft As System.Windows.Forms.Label
      Private WithEvents _numHeight As System.Windows.Forms.NumericUpDown
   End Class
End Namespace