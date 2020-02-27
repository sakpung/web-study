
Partial Class IntensityDetectDailog
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
      Me._lblMsg = New System.Windows.Forms.Label()
      Me._gbOptions = New System.Windows.Forms.GroupBox()
      Me._pnlLevel = New System.Windows.Forms.Panel()
      Me._numOutColorLevel = New System.Windows.Forms.NumericUpDown()
      Me._numInColorLevel = New System.Windows.Forms.NumericUpDown()
      Me._lblOutColor = New System.Windows.Forms.Label()
      Me._lblInColor = New System.Windows.Forms.Label()
      Me._pnlColor = New System.Windows.Forms.Panel()
      Me._lblOutClr = New System.Windows.Forms.Label()
      Me._pnlOutRevColor = New System.Windows.Forms.Panel()
      Me._pnlInRevColor = New System.Windows.Forms.Panel()
      Me._btnOutColor = New System.Windows.Forms.Button()
      Me._btnInColor = New System.Windows.Forms.Button()
      Me._lblInClr = New System.Windows.Forms.Label()
      Me._cbChannel = New System.Windows.Forms.ComboBox()
      Me._numHigh = New System.Windows.Forms.NumericUpDown()
      Me._numLow = New System.Windows.Forms.NumericUpDown()
      Me._lblChannel = New System.Windows.Forms.Label()
      Me._lblHigh = New System.Windows.Forms.Label()
      Me._lblLow = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbOptions.SuspendLayout()
      Me._pnlLevel.SuspendLayout()
      CType(Me._numOutColorLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numInColorLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._pnlColor.SuspendLayout()
      CType(Me._numHigh, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numLow, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _lblMsg
      ' 
      Me._lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblMsg.Location = New System.Drawing.Point(11, 214)
      Me._lblMsg.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblMsg.Name = "_lblMsg"
      Me._lblMsg.Size = New System.Drawing.Size(208, 22)
      Me._lblMsg.TabIndex = 5
      Me._lblMsg.Text = "Low must be less than High."
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._pnlColor)
      Me._gbOptions.Controls.Add(Me._cbChannel)
      Me._gbOptions.Controls.Add(Me._numHigh)
      Me._gbOptions.Controls.Add(Me._numLow)
      Me._gbOptions.Controls.Add(Me._lblChannel)
      Me._gbOptions.Controls.Add(Me._lblHigh)
      Me._gbOptions.Controls.Add(Me._lblLow)
      Me._gbOptions.Controls.Add(Me._pnlLevel)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(11, 11)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Size = New System.Drawing.Size(273, 188)
      Me._gbOptions.TabIndex = 4
      Me._gbOptions.TabStop = False
      ' 
      ' _pnlLevel
      ' 
      Me._pnlLevel.Controls.Add(Me._numOutColorLevel)
      Me._pnlLevel.Controls.Add(Me._numInColorLevel)
      Me._pnlLevel.Controls.Add(Me._lblOutColor)
      Me._pnlLevel.Controls.Add(Me._lblInColor)
      Me._pnlLevel.Location = New System.Drawing.Point(5, 77)
      Me._pnlLevel.Name = "_pnlLevel"
      Me._pnlLevel.Size = New System.Drawing.Size(252, 69)
      Me._pnlLevel.TabIndex = 14
      ' 
      ' _numOutColorLevel
      ' 
      Me._numOutColorLevel.Location = New System.Drawing.Point(116, 40)
      Me._numOutColorLevel.Margin = New System.Windows.Forms.Padding(2)
      Me._numOutColorLevel.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numOutColorLevel.Name = "_numOutColorLevel"
      Me._numOutColorLevel.Size = New System.Drawing.Size(115, 20)
      Me._numOutColorLevel.TabIndex = 13
      ' 
      ' _numInColorLevel
      ' 
      Me._numInColorLevel.Location = New System.Drawing.Point(116, 11)
      Me._numInColorLevel.Margin = New System.Windows.Forms.Padding(2)
      Me._numInColorLevel.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numInColorLevel.Name = "_numInColorLevel"
      Me._numInColorLevel.Size = New System.Drawing.Size(115, 20)
      Me._numInColorLevel.TabIndex = 12
      ' 
      ' _lblOutColor
      ' 
      Me._lblOutColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblOutColor.Location = New System.Drawing.Point(9, 38)
      Me._lblOutColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblOutColor.Name = "_lblOutColor"
      Me._lblOutColor.Size = New System.Drawing.Size(75, 21)
      Me._lblOutColor.TabIndex = 7
      Me._lblOutColor.Text = "Out Color Level"
      Me._lblOutColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _lblInColor
      ' 
      Me._lblInColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblInColor.Location = New System.Drawing.Point(9, 9)
      Me._lblInColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblInColor.Name = "_lblInColor"
      Me._lblInColor.Size = New System.Drawing.Size(75, 21)
      Me._lblInColor.TabIndex = 4
      Me._lblInColor.Text = "In Color Level"
      Me._lblInColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _pnlColor
      ' 
      Me._pnlColor.Controls.Add(Me._lblOutClr)
      Me._pnlColor.Controls.Add(Me._pnlOutRevColor)
      Me._pnlColor.Controls.Add(Me._pnlInRevColor)
      Me._pnlColor.Controls.Add(Me._btnOutColor)
      Me._pnlColor.Controls.Add(Me._btnInColor)
      Me._pnlColor.Controls.Add(Me._lblInClr)
      Me._pnlColor.Location = New System.Drawing.Point(5, 77)
      Me._pnlColor.Name = "_pnlColor"
      Me._pnlColor.Size = New System.Drawing.Size(252, 68)
      Me._pnlColor.TabIndex = 15
      ' 
      ' _lblOutClr
      ' 
      Me._lblOutClr.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblOutClr.Location = New System.Drawing.Point(9, 38)
      Me._lblOutClr.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblOutClr.Name = "_lblOutClr"
      Me._lblOutClr.Size = New System.Drawing.Size(75, 21)
      Me._lblOutClr.TabIndex = 7
      Me._lblOutClr.Text = "Out Color "
      Me._lblOutClr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _pnlOutRevColor
      ' 
      Me._pnlOutRevColor.Location = New System.Drawing.Point(157, 35)
      Me._pnlOutRevColor.Name = "_pnlOutRevColor"
      Me._pnlOutRevColor.Size = New System.Drawing.Size(72, 21)
      Me._pnlOutRevColor.TabIndex = 11
      ' 
      ' _pnlInRevColor
      ' 
      Me._pnlInRevColor.Location = New System.Drawing.Point(157, 7)
      Me._pnlInRevColor.Name = "_pnlInRevColor"
      Me._pnlInRevColor.Size = New System.Drawing.Size(72, 21)
      Me._pnlInRevColor.TabIndex = 10
      ' 
      ' _btnOutColor
      ' 
      Me._btnOutColor.Location = New System.Drawing.Point(116, 34)
      Me._btnOutColor.Name = "_btnOutColor"
      Me._btnOutColor.Size = New System.Drawing.Size(29, 24)
      Me._btnOutColor.TabIndex = 9
      Me._btnOutColor.Text = "..."
      Me._btnOutColor.UseVisualStyleBackColor = True
      ' 
      ' _btnInColor
      ' 
      Me._btnInColor.Location = New System.Drawing.Point(116, 2)
      Me._btnInColor.Name = "_btnInColor"
      Me._btnInColor.Size = New System.Drawing.Size(29, 26)
      Me._btnInColor.TabIndex = 8
      Me._btnInColor.Text = "..."
      Me._btnInColor.UseVisualStyleBackColor = True
      ' 
      ' _lblInClr
      ' 
      Me._lblInClr.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblInClr.Location = New System.Drawing.Point(9, 9)
      Me._lblInClr.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblInClr.Name = "_lblInClr"
      Me._lblInClr.Size = New System.Drawing.Size(75, 21)
      Me._lblInClr.TabIndex = 4
      Me._lblInClr.Text = "In Color"
      Me._lblInClr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _cbChannel
      ' 
      Me._cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbChannel.FormattingEnabled = True
      Me._cbChannel.Location = New System.Drawing.Point(121, 151)
      Me._cbChannel.Margin = New System.Windows.Forms.Padding(2)
      Me._cbChannel.Name = "_cbChannel"
      Me._cbChannel.Size = New System.Drawing.Size(116, 21)
      Me._cbChannel.TabIndex = 11
      ' 
      ' _numHigh
      ' 
      Me._numHigh.Location = New System.Drawing.Point(121, 55)
      Me._numHigh.Margin = New System.Windows.Forms.Padding(2)
      Me._numHigh.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numHigh.Name = "_numHigh"
      Me._numHigh.Size = New System.Drawing.Size(115, 20)
      Me._numHigh.TabIndex = 3
      ' 
      ' _numLow
      ' 
      Me._numLow.Location = New System.Drawing.Point(121, 25)
      Me._numLow.Margin = New System.Windows.Forms.Padding(2)
      Me._numLow.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numLow.Name = "_numLow"
      Me._numLow.Size = New System.Drawing.Size(115, 20)
      Me._numLow.TabIndex = 1
      ' 
      ' _lblChannel
      ' 
      Me._lblChannel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblChannel.Location = New System.Drawing.Point(14, 150)
      Me._lblChannel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblChannel.Name = "_lblChannel"
      Me._lblChannel.Size = New System.Drawing.Size(56, 21)
      Me._lblChannel.TabIndex = 10
      Me._lblChannel.Text = "Blue Factor"
      Me._lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _lblHigh
      ' 
      Me._lblHigh.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblHigh.Location = New System.Drawing.Point(14, 53)
      Me._lblHigh.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblHigh.Name = "_lblHigh"
      Me._lblHigh.Size = New System.Drawing.Size(56, 21)
      Me._lblHigh.TabIndex = 2
      Me._lblHigh.Text = "High"
      Me._lblHigh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _lblLow
      ' 
      Me._lblLow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblLow.Location = New System.Drawing.Point(14, 23)
      Me._lblLow.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblLow.Name = "_lblLow"
      Me._lblLow.Size = New System.Drawing.Size(56, 21)
      Me._lblLow.TabIndex = 0
      Me._lblLow.Text = "Low"
      Me._lblLow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(288, 52)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 7
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(288, 22)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 6
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' IntensityDetectDailog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(372, 243)
      Me.Controls.Add(Me._lblMsg)
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "IntensityDetectDailog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Intensity Detect"
      Me._gbOptions.ResumeLayout(False)
      Me._pnlLevel.ResumeLayout(False)
      CType(Me._numOutColorLevel, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numInColorLevel, System.ComponentModel.ISupportInitialize).EndInit()
      Me._pnlColor.ResumeLayout(False)
      CType(Me._numHigh, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numLow, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _lblMsg As System.Windows.Forms.Label
   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _cbChannel As System.Windows.Forms.ComboBox
   Private _numHigh As System.Windows.Forms.NumericUpDown
   Private _numLow As System.Windows.Forms.NumericUpDown
   Private _lblChannel As System.Windows.Forms.Label
   Private _lblOutColor As System.Windows.Forms.Label
   Private _lblInColor As System.Windows.Forms.Label
   Private _lblHigh As System.Windows.Forms.Label
   Private _lblLow As System.Windows.Forms.Label
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _numOutColorLevel As System.Windows.Forms.NumericUpDown
   Private _numInColorLevel As System.Windows.Forms.NumericUpDown
   Private _pnlLevel As System.Windows.Forms.Panel
   Private _pnlColor As System.Windows.Forms.Panel
   Private WithEvents _btnOutColor As System.Windows.Forms.Button
   Private WithEvents _btnInColor As System.Windows.Forms.Button
   Private _lblOutClr As System.Windows.Forms.Label
   Private _lblInClr As System.Windows.Forms.Label
   Private _pnlOutRevColor As System.Windows.Forms.Panel
   Private _pnlInRevColor As System.Windows.Forms.Panel
End Class