
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
      Me._gbOptions = New System.Windows.Forms.GroupBox()
      Me._lblEnd = New System.Windows.Forms.Label()
      Me._lblStart = New System.Windows.Forms.Label()
      Me._numWidth = New System.Windows.Forms.NumericUpDown()
      Me._numLevel = New System.Windows.Forms.NumericUpDown()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbOptions.SuspendLayout()
      CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._lblEnd)
      Me._gbOptions.Controls.Add(Me._lblStart)
      Me._gbOptions.Controls.Add(Me._numWidth)
      Me._gbOptions.Controls.Add(Me._numLevel)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(6, 4)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Size = New System.Drawing.Size(190, 91)
      Me._gbOptions.TabIndex = 9
      Me._gbOptions.TabStop = False
      Me._gbOptions.Text = "W/L Values "
      ' 
      ' _lblEnd
      ' 
      Me._lblEnd.AutoSize = True
      Me._lblEnd.Location = New System.Drawing.Point(17, 61)
      Me._lblEnd.Name = "_lblEnd"
      Me._lblEnd.Size = New System.Drawing.Size(35, 13)
      Me._lblEnd.TabIndex = 3
      Me._lblEnd.Text = "Width"
      ' 
      ' _lblStart
      ' 
      Me._lblStart.AutoSize = True
      Me._lblStart.Location = New System.Drawing.Point(17, 32)
      Me._lblStart.Name = "_lblStart"
      Me._lblStart.Size = New System.Drawing.Size(33, 13)
      Me._lblStart.TabIndex = 2
      Me._lblStart.Text = "Level"
      ' 
      ' _numWidth
      ' 
      Me._numWidth.Location = New System.Drawing.Point(70, 59)
      Me._numWidth.Margin = New System.Windows.Forms.Padding(2)
      Me._numWidth.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numWidth.Name = "_numWidth"
      Me._numWidth.Size = New System.Drawing.Size(116, 20)
      Me._numWidth.TabIndex = 1
      ' 
      ' _numLevel
      ' 
      Me._numLevel.Location = New System.Drawing.Point(70, 30)
      Me._numLevel.Margin = New System.Windows.Forms.Padding(2)
      Me._numLevel.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numLevel.Name = "_numLevel"
      Me._numLevel.Size = New System.Drawing.Size(116, 20)
      Me._numLevel.TabIndex = 0
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(200, 51)
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
      Me._btnOk.Location = New System.Drawing.Point(200, 21)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 10
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' WindowLevelDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(278, 98)
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "WindowLevelDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Window Level"
      Me._gbOptions.ResumeLayout(False)
      Me._gbOptions.PerformLayout()
      CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numLevel, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _lblEnd As System.Windows.Forms.Label
   Private _lblStart As System.Windows.Forms.Label
   Private _numWidth As System.Windows.Forms.NumericUpDown
   Private _numLevel As System.Windows.Forms.NumericUpDown
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button

End Class