
Partial Class DigitalSubtractDialog
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
      Me._gbDigitalSubtract = New System.Windows.Forms.GroupBox()
      Me._cmbMaskImage = New System.Windows.Forms.ComboBox()
      Me._lblMaskImage = New System.Windows.Forms.Label()
      Me._cbOptimizeRange = New System.Windows.Forms.CheckBox()
      Me._cbContrastEnhancement = New System.Windows.Forms.CheckBox()
      Me._lblFlags = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbDigitalSubtract.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _gbDigitalSubtract
      ' 
      Me._gbDigitalSubtract.Controls.Add(Me._cmbMaskImage)
      Me._gbDigitalSubtract.Controls.Add(Me._lblMaskImage)
      Me._gbDigitalSubtract.Controls.Add(Me._cbOptimizeRange)
      Me._gbDigitalSubtract.Controls.Add(Me._cbContrastEnhancement)
      Me._gbDigitalSubtract.Controls.Add(Me._lblFlags)
      Me._gbDigitalSubtract.Location = New System.Drawing.Point(6, 9)
      Me._gbDigitalSubtract.Name = "_gbDigitalSubtract"
      Me._gbDigitalSubtract.Size = New System.Drawing.Size(860, 98)
      Me._gbDigitalSubtract.TabIndex = 0
      Me._gbDigitalSubtract.TabStop = False
      ' 
      ' _cmbMaskImage
      ' 
      Me._cmbMaskImage.FormattingEnabled = True
      Me._cmbMaskImage.Location = New System.Drawing.Point(83, 19)
      Me._cmbMaskImage.Name = "_cmbMaskImage"
      Me._cmbMaskImage.Size = New System.Drawing.Size(771, 21)
      Me._cmbMaskImage.TabIndex = 4
      ' 
      ' _lblMaskImage
      ' 
      Me._lblMaskImage.AutoSize = True
      Me._lblMaskImage.Location = New System.Drawing.Point(6, 22)
      Me._lblMaskImage.Name = "_lblMaskImage"
      Me._lblMaskImage.Size = New System.Drawing.Size(71, 13)
      Me._lblMaskImage.TabIndex = 3
      Me._lblMaskImage.Text = "Mask Image :"
      ' 
      ' _cbOptimizeRange
      ' 
      Me._cbOptimizeRange.AutoSize = True
      Me._cbOptimizeRange.Location = New System.Drawing.Point(83, 75)
      Me._cbOptimizeRange.Name = "_cbOptimizeRange"
      Me._cbOptimizeRange.Size = New System.Drawing.Size(101, 17)
      Me._cbOptimizeRange.TabIndex = 2
      Me._cbOptimizeRange.Text = "Optimize Range"
      Me._cbOptimizeRange.UseVisualStyleBackColor = True
      ' 
      ' _cbContrastEnhancement
      ' 
      Me._cbContrastEnhancement.AutoSize = True
      Me._cbContrastEnhancement.Location = New System.Drawing.Point(83, 52)
      Me._cbContrastEnhancement.Name = "_cbContrastEnhancement"
      Me._cbContrastEnhancement.Size = New System.Drawing.Size(134, 17)
      Me._cbContrastEnhancement.TabIndex = 1
      Me._cbContrastEnhancement.Text = "Contrast Enhancement"
      Me._cbContrastEnhancement.UseVisualStyleBackColor = True
      ' 
      ' _lblFlags
      ' 
      Me._lblFlags.AutoSize = True
      Me._lblFlags.Location = New System.Drawing.Point(6, 56)
      Me._lblFlags.Name = "_lblFlags"
      Me._lblFlags.Size = New System.Drawing.Size(38, 13)
      Me._lblFlags.TabIndex = 0
      Me._lblFlags.Text = "Flags :"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(798, 118)
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
      Me._btnOk.Location = New System.Drawing.Point(726, 118)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 10
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' DigitalSubtractDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(878, 149)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gbDigitalSubtract)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DigitalSubtractDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Digital Subtract"
      Me._gbDigitalSubtract.ResumeLayout(False)
      Me._gbDigitalSubtract.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbDigitalSubtract As System.Windows.Forms.GroupBox
   Private _cmbMaskImage As System.Windows.Forms.ComboBox
   Private _lblMaskImage As System.Windows.Forms.Label
   Private _cbOptimizeRange As System.Windows.Forms.CheckBox
   Private _cbContrastEnhancement As System.Windows.Forms.CheckBox
   Private _lblFlags As System.Windows.Forms.Label
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
End Class