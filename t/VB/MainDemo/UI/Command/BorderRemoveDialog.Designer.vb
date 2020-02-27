Namespace MainDemo
   Partial Public Class BorderRemoveDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BorderRemoveDialog))
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._gbFlags = New System.Windows.Forms.GroupBox()
         Me._cbUseVariance = New System.Windows.Forms.CheckBox()
         Me._cbImageUnchanged = New System.Windows.Forms.CheckBox()
         Me._gbBorder = New System.Windows.Forms.GroupBox()
         Me._cbBottom = New System.Windows.Forms.CheckBox()
         Me._cbRight = New System.Windows.Forms.CheckBox()
         Me._cbTop = New System.Windows.Forms.CheckBox()
         Me._cbLeft = New System.Windows.Forms.CheckBox()
         Me._gbOptions = New System.Windows.Forms.GroupBox()
         Me._numWhiteNoiseLength = New System.Windows.Forms.NumericUpDown()
         Me._numVariance = New System.Windows.Forms.NumericUpDown()
         Me._numPercent = New System.Windows.Forms.NumericUpDown()
         Me._lblWhiteNoiseLength = New System.Windows.Forms.Label()
         Me._lblVariance = New System.Windows.Forms.Label()
         Me._lblPercent = New System.Windows.Forms.Label()
         Me._cbAutoRemove = New System.Windows.Forms.CheckBox()
         Me._gbFlags.SuspendLayout()
         Me._gbBorder.SuspendLayout()
         Me._gbOptions.SuspendLayout()
         CType(Me._numWhiteNoiseLength, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numVariance, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numPercent, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         resources.ApplyResources(Me._btnCancel, "_btnCancel")
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         resources.ApplyResources(Me._btnOk, "_btnOk")
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.UseVisualStyleBackColor = True
         ' 
         ' _gbFlags
         ' 
         Me._gbFlags.Controls.Add(Me._cbAutoRemove)
         Me._gbFlags.Controls.Add(Me._cbUseVariance)
         Me._gbFlags.Controls.Add(Me._cbImageUnchanged)
         Me._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System
         resources.ApplyResources(Me._gbFlags, "_gbFlags")
         Me._gbFlags.Name = "_gbFlags"
         Me._gbFlags.TabStop = False
         ' 
         ' _cbUseVariance
         ' 
         resources.ApplyResources(Me._cbAutoRemove, "_cbAutoRemove")
         Me._cbAutoRemove.Name = "_cbAutoRemove"
         Me._cbAutoRemove.UseVisualStyleBackColor = True
         ' 
         ' _cbUseVariance
         ' 
         resources.ApplyResources(Me._cbUseVariance, "_cbUseVariance")
         Me._cbUseVariance.Name = "_cbUseVariance"
         Me._cbUseVariance.UseVisualStyleBackColor = True
         ' 
         ' _cbImageUnchanged
         ' 
         resources.ApplyResources(Me._cbImageUnchanged, "_cbImageUnchanged")
         Me._cbImageUnchanged.Name = "_cbImageUnchanged"
         Me._cbImageUnchanged.UseVisualStyleBackColor = True
         ' 
         ' _gbBorder
         ' 
         Me._gbBorder.Controls.Add(Me._cbBottom)
         Me._gbBorder.Controls.Add(Me._cbRight)
         Me._gbBorder.Controls.Add(Me._cbTop)
         Me._gbBorder.Controls.Add(Me._cbLeft)
         Me._gbBorder.FlatStyle = System.Windows.Forms.FlatStyle.System
         resources.ApplyResources(Me._gbBorder, "_gbBorder")
         Me._gbBorder.Name = "_gbBorder"
         Me._gbBorder.TabStop = False
         ' 
         ' _cbBottom
         ' 
         resources.ApplyResources(Me._cbBottom, "_cbBottom")
         Me._cbBottom.Name = "_cbBottom"
         Me._cbBottom.UseVisualStyleBackColor = True
         ' 
         ' _cbRight
         ' 
         resources.ApplyResources(Me._cbRight, "_cbRight")
         Me._cbRight.Name = "_cbRight"
         Me._cbRight.UseVisualStyleBackColor = True
         ' 
         ' _cbTop
         ' 
         resources.ApplyResources(Me._cbTop, "_cbTop")
         Me._cbTop.Name = "_cbTop"
         Me._cbTop.UseVisualStyleBackColor = True
         ' 
         ' _cbLeft
         ' 
         resources.ApplyResources(Me._cbLeft, "_cbLeft")
         Me._cbLeft.Name = "_cbLeft"
         Me._cbLeft.UseVisualStyleBackColor = True
         ' 
         ' _gbOptions
         ' 
         Me._gbOptions.Controls.Add(Me._numWhiteNoiseLength)
         Me._gbOptions.Controls.Add(Me._numVariance)
         Me._gbOptions.Controls.Add(Me._numPercent)
         Me._gbOptions.Controls.Add(Me._lblWhiteNoiseLength)
         Me._gbOptions.Controls.Add(Me._lblVariance)
         Me._gbOptions.Controls.Add(Me._lblPercent)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         resources.ApplyResources(Me._gbOptions, "_gbOptions")
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.TabStop = False
         ' 
         ' _numWhiteNoiseLength
         ' 
         resources.ApplyResources(Me._numWhiteNoiseLength, "_numWhiteNoiseLength")
         Me._numWhiteNoiseLength.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
         Me._numWhiteNoiseLength.Name = "_numWhiteNoiseLength"
         ' 
         ' _numVariance
         ' 
         resources.ApplyResources(Me._numVariance, "_numVariance")
         Me._numVariance.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
         Me._numVariance.Name = "_numVariance"
         ' 
         ' _numPercent
         ' 
         resources.ApplyResources(Me._numPercent, "_numPercent")
         Me._numPercent.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._numPercent.Name = "_numPercent"
         Me._numPercent.Value = New Decimal(New Integer() {1, 0, 0, 0})
         ' 
         ' _lblWhiteNoiseLength
         ' 
         Me._lblWhiteNoiseLength.FlatStyle = System.Windows.Forms.FlatStyle.System
         resources.ApplyResources(Me._lblWhiteNoiseLength, "_lblWhiteNoiseLength")
         Me._lblWhiteNoiseLength.Name = "_lblWhiteNoiseLength"
         ' 
         ' _lblVariance
         ' 
         Me._lblVariance.FlatStyle = System.Windows.Forms.FlatStyle.System
         resources.ApplyResources(Me._lblVariance, "_lblVariance")
         Me._lblVariance.Name = "_lblVariance"
         ' 
         ' _lblPercent
         ' 
         Me._lblPercent.FlatStyle = System.Windows.Forms.FlatStyle.System
         resources.ApplyResources(Me._lblPercent, "_lblPercent")
         Me._lblPercent.Name = "_lblPercent"
         ' 
         ' _cbAutoRemove
         ' 
         resources.ApplyResources(Me._cbAutoRemove, "_cbAutoRemove")
         Me._cbAutoRemove.Name = "_cbAutoRemove"
         Me._cbAutoRemove.UseVisualStyleBackColor = True
         ' 
         ' BorderRemoveDialog
         ' 
         Me.AcceptButton = Me._btnOk
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.Controls.Add(Me._gbOptions)
         Me.Controls.Add(Me._gbBorder)
         Me.Controls.Add(Me._gbFlags)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "BorderRemoveDialog"
         Me.ShowInTaskbar = False
         Me._gbFlags.ResumeLayout(False)
         Me._gbFlags.PerformLayout()
         Me._gbBorder.ResumeLayout(False)
         Me._gbOptions.ResumeLayout(False)
         CType(Me._numWhiteNoiseLength, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numVariance, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numPercent, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _gbFlags As System.Windows.Forms.GroupBox
      Private _gbBorder As System.Windows.Forms.GroupBox
      Private _gbOptions As System.Windows.Forms.GroupBox
      Private WithEvents _cbUseVariance As System.Windows.Forms.CheckBox
      Private _cbImageUnchanged As System.Windows.Forms.CheckBox
      Private _cbBottom As System.Windows.Forms.CheckBox
      Private _cbRight As System.Windows.Forms.CheckBox
      Private _cbTop As System.Windows.Forms.CheckBox
      Private _cbLeft As System.Windows.Forms.CheckBox
      Private _lblPercent As System.Windows.Forms.Label
      Private WithEvents _numWhiteNoiseLength As System.Windows.Forms.NumericUpDown
      Private WithEvents _numVariance As System.Windows.Forms.NumericUpDown
      Private WithEvents _numPercent As System.Windows.Forms.NumericUpDown
      Private _lblWhiteNoiseLength As System.Windows.Forms.Label
      Private _lblVariance As System.Windows.Forms.Label
      Private WithEvents _cbAutoRemove As System.Windows.Forms.CheckBox
   End Class
End Namespace