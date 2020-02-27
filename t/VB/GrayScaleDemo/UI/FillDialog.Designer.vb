
Partial Class FillDialog
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
      Me._pnlLevel = New System.Windows.Forms.Panel()
      Me._numLevel = New System.Windows.Forms.NumericUpDown()
      Me._lblLevel = New System.Windows.Forms.Label()
      Me._pnlColor = New System.Windows.Forms.Panel()
      Me._pnlRevColor = New System.Windows.Forms.Panel()
      Me._btnDlgColor = New System.Windows.Forms.Button()
      Me._lblColor = New System.Windows.Forms.Label()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._pnlLevel.SuspendLayout()
      CType(Me._numLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._pnlColor.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _pnlLevel
      ' 
      Me._pnlLevel.Controls.Add(Me._numLevel)
      Me._pnlLevel.Controls.Add(Me._lblLevel)
      Me._pnlLevel.Location = New System.Drawing.Point(12, 12)
      Me._pnlLevel.Name = "_pnlLevel"
      Me._pnlLevel.Size = New System.Drawing.Size(236, 54)
      Me._pnlLevel.TabIndex = 0
      ' 
      ' _numLevel
      ' 
      Me._numLevel.Location = New System.Drawing.Point(108, 21)
      Me._numLevel.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numLevel.Name = "_numLevel"
      Me._numLevel.Size = New System.Drawing.Size(120, 20)
      Me._numLevel.TabIndex = 1
      ' 
      ' _lblLevel
      ' 
      Me._lblLevel.AutoSize = True
      Me._lblLevel.Location = New System.Drawing.Point(21, 23)
      Me._lblLevel.Name = "_lblLevel"
      Me._lblLevel.Size = New System.Drawing.Size(81, 13)
      Me._lblLevel.TabIndex = 0
      Me._lblLevel.Text = "Fill Color Level :"
      ' 
      ' _pnlColor
      ' 
      Me._pnlColor.Controls.Add(Me._pnlRevColor)
      Me._pnlColor.Controls.Add(Me._btnDlgColor)
      Me._pnlColor.Controls.Add(Me._lblColor)
      Me._pnlColor.Location = New System.Drawing.Point(12, 17)
      Me._pnlColor.Name = "_pnlColor"
      Me._pnlColor.Size = New System.Drawing.Size(236, 54)
      Me._pnlColor.TabIndex = 1
      ' 
      ' _pnlRevColor
      ' 
      Me._pnlRevColor.Location = New System.Drawing.Point(128, 16)
      Me._pnlRevColor.Name = "_pnlRevColor"
      Me._pnlRevColor.Size = New System.Drawing.Size(90, 26)
      Me._pnlRevColor.TabIndex = 2
      ' 
      ' _btnDlgColor
      ' 
      Me._btnDlgColor.Location = New System.Drawing.Point(90, 16)
      Me._btnDlgColor.Name = "_btnDlgColor"
      Me._btnDlgColor.Size = New System.Drawing.Size(32, 26)
      Me._btnDlgColor.TabIndex = 1
      Me._btnDlgColor.Text = "..."
      Me._btnDlgColor.UseVisualStyleBackColor = True
      ' 
      ' _lblColor
      ' 
      Me._lblColor.AutoSize = True
      Me._lblColor.Location = New System.Drawing.Point(21, 23)
      Me._lblColor.Name = "_lblColor"
      Me._lblColor.Size = New System.Drawing.Size(37, 13)
      Me._lblColor.TabIndex = 0
      Me._lblColor.Text = "Color :"
      ' 
      ' _btnOk
      ' 
      Me._btnOk.Location = New System.Drawing.Point(59, 86)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 25)
      Me._btnOk.TabIndex = 2
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.Location = New System.Drawing.Point(134, 85)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 25)
      Me._btnCancel.TabIndex = 3
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' FillDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(260, 122)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._pnlColor)
      Me.Controls.Add(Me._pnlLevel)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FillDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Fill"
      Me._pnlLevel.ResumeLayout(False)
      Me._pnlLevel.PerformLayout()
      CType(Me._numLevel, System.ComponentModel.ISupportInitialize).EndInit()
      Me._pnlColor.ResumeLayout(False)
      Me._pnlColor.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _pnlLevel As System.Windows.Forms.Panel
   Private _numLevel As System.Windows.Forms.NumericUpDown
   Private _lblLevel As System.Windows.Forms.Label
   Private _pnlColor As System.Windows.Forms.Panel
   Private WithEvents _btnDlgColor As System.Windows.Forms.Button
   Private _lblColor As System.Windows.Forms.Label
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private _pnlRevColor As System.Windows.Forms.Panel
End Class