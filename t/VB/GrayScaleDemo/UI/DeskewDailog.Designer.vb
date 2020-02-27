
Partial Class DeskewDailog
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
      Me._gbOptions = New System.Windows.Forms.GroupBox()
      Me._rbNoFill = New System.Windows.Forms.RadioButton()
      Me._rbFill = New System.Windows.Forms.RadioButton()
      Me._pnlLevel = New System.Windows.Forms.Panel()
      Me._numFillColorLevel = New System.Windows.Forms.NumericUpDown()
      Me._lblFillColor = New System.Windows.Forms.Label()
      Me._pnlColor = New System.Windows.Forms.Panel()
      Me._pnlRevColor = New System.Windows.Forms.Panel()
      Me._btnRevColor = New System.Windows.Forms.Button()
      Me._lblColor = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbOptions.SuspendLayout()
      Me._pnlLevel.SuspendLayout()
      CType(Me._numFillColorLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._pnlColor.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._pnlLevel)
      Me._gbOptions.Controls.Add(Me._pnlColor)
      Me._gbOptions.Controls.Add(Me._rbNoFill)
      Me._gbOptions.Controls.Add(Me._rbFill)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(11, 7)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Size = New System.Drawing.Size(246, 120)
      Me._gbOptions.TabIndex = 3
      Me._gbOptions.TabStop = False
      ' 
      ' _rbNoFill
      ' 
      Me._rbNoFill.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbNoFill.Location = New System.Drawing.Point(14, 83)
      Me._rbNoFill.Margin = New System.Windows.Forms.Padding(2)
      Me._rbNoFill.Name = "_rbNoFill"
      Me._rbNoFill.Size = New System.Drawing.Size(153, 22)
      Me._rbNoFill.TabIndex = 4
      Me._rbNoFill.TabStop = True
      Me._rbNoFill.Text = "Do not fill exposed area"
      Me._rbNoFill.UseVisualStyleBackColor = True
      ' 
      ' _rbFill
      ' 
      Me._rbFill.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbFill.Location = New System.Drawing.Point(14, 23)
      Me._rbFill.Margin = New System.Windows.Forms.Padding(2)
      Me._rbFill.Name = "_rbFill"
      Me._rbFill.Size = New System.Drawing.Size(129, 22)
      Me._rbFill.TabIndex = 0
      Me._rbFill.TabStop = True
      Me._rbFill.Text = "Fill Exposed Area"
      Me._rbFill.UseVisualStyleBackColor = True
      ' 
      ' _pnlLevel
      ' 
      Me._pnlLevel.Controls.Add(Me._numFillColorLevel)
      Me._pnlLevel.Controls.Add(Me._lblFillColor)
      Me._pnlLevel.Location = New System.Drawing.Point(25, 45)
      Me._pnlLevel.Name = "_pnlLevel"
      Me._pnlLevel.Size = New System.Drawing.Size(217, 38)
      Me._pnlLevel.TabIndex = 6
      Me._pnlLevel.Visible = False
      ' 
      ' _numFillColorLevel
      ' 
      Me._numFillColorLevel.Location = New System.Drawing.Point(93, 8)
      Me._numFillColorLevel.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numFillColorLevel.Name = "_numFillColorLevel"
      Me._numFillColorLevel.Size = New System.Drawing.Size(98, 20)
      Me._numFillColorLevel.TabIndex = 5
      ' 
      ' _lblFillColor
      ' 
      Me._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblFillColor.Location = New System.Drawing.Point(12, 8)
      Me._lblFillColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblFillColor.Name = "_lblFillColor"
      Me._lblFillColor.Size = New System.Drawing.Size(76, 21)
      Me._lblFillColor.TabIndex = 1
      Me._lblFillColor.Text = "Fill Color Level"
      Me._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _pnlColor
      ' 
      Me._pnlColor.Controls.Add(Me._pnlRevColor)
      Me._pnlColor.Controls.Add(Me._btnRevColor)
      Me._pnlColor.Controls.Add(Me._lblColor)
      Me._pnlColor.Location = New System.Drawing.Point(27, 45)
      Me._pnlColor.Name = "_pnlColor"
      Me._pnlColor.Size = New System.Drawing.Size(207, 38)
      Me._pnlColor.TabIndex = 7
      ' 
      ' _pnlRevColor
      ' 
      Me._pnlRevColor.Location = New System.Drawing.Point(135, 7)
      Me._pnlRevColor.Name = "_pnlRevColor"
      Me._pnlRevColor.Size = New System.Drawing.Size(55, 25)
      Me._pnlRevColor.TabIndex = 3
      ' 
      ' _btnRevColor
      ' 
      Me._btnRevColor.Location = New System.Drawing.Point(86, 7)
      Me._btnRevColor.Name = "_btnRevColor"
      Me._btnRevColor.Size = New System.Drawing.Size(39, 26)
      Me._btnRevColor.TabIndex = 2
      Me._btnRevColor.Text = "..."
      Me._btnRevColor.UseVisualStyleBackColor = True
      ' 
      ' _lblColor
      ' 
      Me._lblColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblColor.Location = New System.Drawing.Point(12, 8)
      Me._lblColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblColor.Name = "_lblColor"
      Me._lblColor.Size = New System.Drawing.Size(76, 21)
      Me._lblColor.TabIndex = 1
      Me._lblColor.Text = "Fill Color :"
      Me._lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(268, 41)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 5
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(268, 11)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 4
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' DeskewDailog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(344, 138)
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DeskewDailog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Deskew"
      Me._gbOptions.ResumeLayout(False)
      Me._pnlLevel.ResumeLayout(False)
      CType(Me._numFillColorLevel, System.ComponentModel.ISupportInitialize).EndInit()
      Me._pnlColor.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _rbNoFill As System.Windows.Forms.RadioButton
   Private _rbFill As System.Windows.Forms.RadioButton
   Private _lblFillColor As System.Windows.Forms.Label
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _pnlLevel As System.Windows.Forms.Panel
   Private _pnlColor As System.Windows.Forms.Panel
   Private _lblColor As System.Windows.Forms.Label
   Private _pnlRevColor As System.Windows.Forms.Panel
   Private WithEvents _btnRevColor As System.Windows.Forms.Button
   Private _numFillColorLevel As System.Windows.Forms.NumericUpDown
End Class