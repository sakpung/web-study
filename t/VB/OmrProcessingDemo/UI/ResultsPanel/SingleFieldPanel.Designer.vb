Partial Class SingleFieldPanel
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me.spltResult = New System.Windows.Forms.SplitContainer()
      Me.lblDetectedIssues = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me.txtSelection = New System.Windows.Forms.TextBox()
      Me.lstSelection = New System.Windows.Forms.ListBox()
      Me.lstErrors = New System.Windows.Forms.ListBox()
      Me.txtConfidence = New System.Windows.Forms.TextBox()
      Me.lblExpected = New System.Windows.Forms.Label()
      Me.lblConfidence = New System.Windows.Forms.Label()
      Me.txtExpected = New System.Windows.Forms.TextBox()
      Me.lblActual = New System.Windows.Forms.Label()
      CType(Me.spltResult, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.spltResult.Panel2.SuspendLayout()
      Me.spltResult.SuspendLayout()
      Me.SuspendLayout()
      Me.spltResult.Dock = System.Windows.Forms.DockStyle.Fill
      Me.spltResult.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
      Me.spltResult.Location = New System.Drawing.Point(0, 0)
      Me.spltResult.Name = "spltResult"
      Me.spltResult.Orientation = System.Windows.Forms.Orientation.Horizontal
      Me.spltResult.Panel2.Controls.Add(Me.lblDetectedIssues)
      Me.spltResult.Panel2.Controls.Add(Me.label1)
      Me.spltResult.Panel2.Controls.Add(Me.txtSelection)
      Me.spltResult.Panel2.Controls.Add(Me.lstSelection)
      Me.spltResult.Panel2.Controls.Add(Me.lstErrors)
      Me.spltResult.Panel2.Controls.Add(Me.txtConfidence)
      Me.spltResult.Panel2.Controls.Add(Me.lblExpected)
      Me.spltResult.Panel2.Controls.Add(Me.lblConfidence)
      Me.spltResult.Panel2.Controls.Add(Me.txtExpected)
      Me.spltResult.Panel2.Controls.Add(Me.lblActual)
      Me.spltResult.Size = New System.Drawing.Size(300, 436)
      Me.spltResult.SplitterDistance = 150
      Me.spltResult.TabIndex = 13
      Me.lblDetectedIssues.AutoSize = True
      Me.lblDetectedIssues.Location = New System.Drawing.Point(13, 188)
      Me.lblDetectedIssues.Name = "lblDetectedIssues"
      Me.lblDetectedIssues.Size = New System.Drawing.Size(87, 13)
      Me.lblDetectedIssues.TabIndex = 18
      Me.lblDetectedIssues.Text = "Detected Issues:"
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(13, 100)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(105, 13)
      Me.label1.TabIndex = 17
      Me.label1.Text = "Available Selections:"
      Me.txtSelection.Enabled = False
      Me.txtSelection.Location = New System.Drawing.Point(151, 68)
      Me.txtSelection.Name = "txtSelection"
      Me.txtSelection.[ReadOnly] = True
      Me.txtSelection.Size = New System.Drawing.Size(121, 20)
      Me.txtSelection.TabIndex = 16
      Me.lstSelection.FormattingEnabled = True
      Me.lstSelection.Location = New System.Drawing.Point(16, 116)
      Me.lstSelection.Name = "lstSelection"
      Me.lstSelection.Size = New System.Drawing.Size(269, 69)
      Me.lstSelection.TabIndex = 15
      AddHandler Me.lstSelection.SelectedIndexChanged, AddressOf Me.lstSelection_SelectedIndexChanged
      Me.lstErrors.FormattingEnabled = True
      Me.lstErrors.Location = New System.Drawing.Point(16, 204)
      Me.lstErrors.Name = "lstErrors"
      Me.lstErrors.Size = New System.Drawing.Size(269, 56)
      Me.lstErrors.TabIndex = 13
      Me.txtConfidence.Enabled = False
      Me.txtConfidence.Location = New System.Drawing.Point(151, 39)
      Me.txtConfidence.Name = "txtConfidence"
      Me.txtConfidence.[ReadOnly] = True
      Me.txtConfidence.Size = New System.Drawing.Size(121, 20)
      Me.txtConfidence.TabIndex = 11
      Me.lblExpected.AutoSize = True
      Me.lblExpected.Location = New System.Drawing.Point(43, 16)
      Me.lblExpected.Name = "lblExpected"
      Me.lblExpected.Size = New System.Drawing.Size(101, 13)
      Me.lblExpected.TabIndex = 6
      Me.lblExpected.Text = "Detected Selection:"
      Me.lblConfidence.AutoSize = True
      Me.lblConfidence.Location = New System.Drawing.Point(43, 42)
      Me.lblConfidence.Name = "lblConfidence"
      Me.lblConfidence.Size = New System.Drawing.Size(64, 13)
      Me.lblConfidence.TabIndex = 10
      Me.lblConfidence.Text = "Confidence:"
      Me.txtExpected.Location = New System.Drawing.Point(151, 13)
      Me.txtExpected.Name = "txtExpected"
      Me.txtExpected.[ReadOnly] = True
      Me.txtExpected.Size = New System.Drawing.Size(121, 20)
      Me.txtExpected.TabIndex = 7
      Me.lblActual.AutoSize = True
      Me.lblActual.Location = New System.Drawing.Point(43, 68)
      Me.lblActual.Name = "lblActual"
      Me.lblActual.Size = New System.Drawing.Size(79, 13)
      Me.lblActual.TabIndex = 8
      Me.lblActual.Text = "New Selection:"
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.spltResult)
      Me.Name = "SingleFieldPanel"
      Me.Size = New System.Drawing.Size(300, 436)
      Me.spltResult.Panel2.ResumeLayout(False)
      Me.spltResult.Panel2.PerformLayout()
      CType(Me.spltResult, System.ComponentModel.ISupportInitialize).EndInit()
      Me.spltResult.ResumeLayout(False)
      Me.ResumeLayout(False)
   End Sub

   Private spltResult As System.Windows.Forms.SplitContainer
   Private txtSelection As System.Windows.Forms.TextBox
   Private lstSelection As System.Windows.Forms.ListBox
   Private lstErrors As System.Windows.Forms.ListBox
   Private txtConfidence As System.Windows.Forms.TextBox
   Private lblExpected As System.Windows.Forms.Label
   Private lblConfidence As System.Windows.Forms.Label
   Private txtExpected As System.Windows.Forms.TextBox
   Private lblActual As System.Windows.Forms.Label
   Private lblDetectedIssues As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
End Class
