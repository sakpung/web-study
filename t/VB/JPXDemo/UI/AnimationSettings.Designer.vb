<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnimationSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnimationSettings))
      Me._lblRenderHeight = New System.Windows.Forms.Label
      Me._nudRenderWidth = New System.Windows.Forms.NumericUpDown
      Me._grpRender = New System.Windows.Forms.GroupBox
      Me._nudRenderHeight = New System.Windows.Forms.NumericUpDown
      Me._lblRenderWidth = New System.Windows.Forms.Label
      Me._grpDelay = New System.Windows.Forms.GroupBox
      Me._nudDelay = New System.Windows.Forms.NumericUpDown
      Me._lblMilliSecond = New System.Windows.Forms.Label
      Me._btnCancel = New System.Windows.Forms.Button
      Me._btnOk = New System.Windows.Forms.Button
      CType(Me._nudRenderWidth, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._grpRender.SuspendLayout()
      CType(Me._nudRenderHeight, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._grpDelay.SuspendLayout()
      CType(Me._nudDelay, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      '_lblRenderHeight
      '
      Me._lblRenderHeight.AutoSize = True
      Me._lblRenderHeight.Location = New System.Drawing.Point(7, 45)
      Me._lblRenderHeight.Name = "_lblRenderHeight"
      Me._lblRenderHeight.Size = New System.Drawing.Size(38, 13)
      Me._lblRenderHeight.TabIndex = 6
      Me._lblRenderHeight.Text = "&Height"
      '
      '_nudRenderWidth
      '
      Me._nudRenderWidth.Location = New System.Drawing.Point(58, 19)
      Me._nudRenderWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
      Me._nudRenderWidth.Name = "_nudRenderWidth"
      Me._nudRenderWidth.Size = New System.Drawing.Size(59, 20)
      Me._nudRenderWidth.TabIndex = 3
      '
      '_grpRender
      '
      Me._grpRender.Controls.Add(Me._nudRenderHeight)
      Me._grpRender.Controls.Add(Me._lblRenderHeight)
      Me._grpRender.Controls.Add(Me._nudRenderWidth)
      Me._grpRender.Controls.Add(Me._lblRenderWidth)
      Me._grpRender.Location = New System.Drawing.Point(5, 6)
      Me._grpRender.Name = "_grpRender"
      Me._grpRender.Size = New System.Drawing.Size(139, 73)
      Me._grpRender.TabIndex = 10
      Me._grpRender.TabStop = False
      Me._grpRender.Text = "&Render"
      '
      '_nudRenderHeight
      '
      Me._nudRenderHeight.Location = New System.Drawing.Point(58, 43)
      Me._nudRenderHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
      Me._nudRenderHeight.Name = "_nudRenderHeight"
      Me._nudRenderHeight.Size = New System.Drawing.Size(59, 20)
      Me._nudRenderHeight.TabIndex = 5
      '
      '_lblRenderWidth
      '
      Me._lblRenderWidth.AutoSize = True
      Me._lblRenderWidth.Location = New System.Drawing.Point(7, 21)
      Me._lblRenderWidth.Name = "_lblRenderWidth"
      Me._lblRenderWidth.Size = New System.Drawing.Size(35, 13)
      Me._lblRenderWidth.TabIndex = 4
      Me._lblRenderWidth.Text = "&Width"
      '
      '_grpDelay
      '
      Me._grpDelay.Controls.Add(Me._nudDelay)
      Me._grpDelay.Controls.Add(Me._lblMilliSecond)
      Me._grpDelay.Location = New System.Drawing.Point(5, 85)
      Me._grpDelay.Name = "_grpDelay"
      Me._grpDelay.Size = New System.Drawing.Size(139, 48)
      Me._grpDelay.TabIndex = 9
      Me._grpDelay.TabStop = False
      Me._grpDelay.Text = "&Delay"
      '
      '_nudDelay
      '
      Me._nudDelay.Location = New System.Drawing.Point(10, 19)
      Me._nudDelay.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
      Me._nudDelay.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
      Me._nudDelay.Name = "_nudDelay"
      Me._nudDelay.Size = New System.Drawing.Size(59, 20)
      Me._nudDelay.TabIndex = 3
      Me._nudDelay.Value = New Decimal(New Integer() {10, 0, 0, 0})
      '
      '_lblMilliSecond
      '
      Me._lblMilliSecond.AutoSize = True
      Me._lblMilliSecond.Location = New System.Drawing.Point(75, 21)
      Me._lblMilliSecond.Name = "_lblMilliSecond"
      Me._lblMilliSecond.Size = New System.Drawing.Size(58, 13)
      Me._lblMilliSecond.TabIndex = 4
      Me._lblMilliSecond.Text = "millisecond"
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(150, 43)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 8
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '
      '_btnOk
      '
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.Location = New System.Drawing.Point(150, 13)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 7
      Me._btnOk.Text = "Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      '
      'AnimationSettings
      '
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(230, 138)
      Me.Controls.Add(Me._grpRender)
      Me.Controls.Add(Me._grpDelay)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AnimationSettings"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Animation Settings"
      CType(Me._nudRenderWidth, System.ComponentModel.ISupportInitialize).EndInit()
      Me._grpRender.ResumeLayout(False)
      Me._grpRender.PerformLayout()
      CType(Me._nudRenderHeight, System.ComponentModel.ISupportInitialize).EndInit()
      Me._grpDelay.ResumeLayout(False)
      Me._grpDelay.PerformLayout()
      CType(Me._nudDelay, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _lblRenderHeight As System.Windows.Forms.Label
   Private WithEvents _nudRenderWidth As System.Windows.Forms.NumericUpDown
   Private WithEvents _grpRender As System.Windows.Forms.GroupBox
   Private WithEvents _nudRenderHeight As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblRenderWidth As System.Windows.Forms.Label
   Private WithEvents _grpDelay As System.Windows.Forms.GroupBox
   Private WithEvents _nudDelay As System.Windows.Forms.NumericUpDown
   Private WithEvents _lblMilliSecond As System.Windows.Forms.Label
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
End Class
