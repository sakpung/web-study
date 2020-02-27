<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RtfOptionsControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
      Me.components = New System.ComponentModel.Container
      Me._resetToDefaultsButton = New System.Windows.Forms.Button
      Me._generalRtfLoadOptionsGroupBox = New System.Windows.Forms.GroupBox
      Me._backColorButton = New System.Windows.Forms.Button
      Me._backColorPanel = New System.Windows.Forms.Panel
      Me._backColorLabel = New System.Windows.Forms.Label
      Me._controlsToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me._generalRtfLoadOptionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_resetToDefaultsButton
      '
      Me._resetToDefaultsButton.Location = New System.Drawing.Point(305, 201)
      Me._resetToDefaultsButton.Name = "_resetToDefaultsButton"
      Me._resetToDefaultsButton.Size = New System.Drawing.Size(189, 23)
      Me._resetToDefaultsButton.TabIndex = 12
      Me._resetToDefaultsButton.Text = "Reset to defa&ults"
      Me._controlsToolTip.SetToolTip(Me._resetToDefaultsButton, "Reset the options to LEADTOOLS default values")
      Me._resetToDefaultsButton.UseVisualStyleBackColor = True
      '
      '_generalRtfLoadOptionsGroupBox
      '
      Me._generalRtfLoadOptionsGroupBox.Controls.Add(Me._resetToDefaultsButton)
      Me._generalRtfLoadOptionsGroupBox.Controls.Add(Me._backColorButton)
      Me._generalRtfLoadOptionsGroupBox.Controls.Add(Me._backColorPanel)
      Me._generalRtfLoadOptionsGroupBox.Controls.Add(Me._backColorLabel)
      Me._generalRtfLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._generalRtfLoadOptionsGroupBox.Location = New System.Drawing.Point(0, 0)
      Me._generalRtfLoadOptionsGroupBox.Name = "_generalRtfLoadOptionsGroupBox"
      Me._generalRtfLoadOptionsGroupBox.Size = New System.Drawing.Size(500, 230)
      Me._generalRtfLoadOptionsGroupBox.TabIndex = 0
      Me._generalRtfLoadOptionsGroupBox.TabStop = False
      Me._generalRtfLoadOptionsGroupBox.Text = "General Rich Text Format (RTF) load options:"
      '
      '_backColorButton
      '
      Me._backColorButton.Location = New System.Drawing.Point(157, 30)
      Me._backColorButton.Name = "_backColorButton"
      Me._backColorButton.Size = New System.Drawing.Size(25, 23)
      Me._backColorButton.TabIndex = 2
      Me._backColorButton.Text = "..."
      Me._controlsToolTip.SetToolTip(Me._backColorButton, "Change the background used when rendering RTF documents")
      Me._backColorButton.UseVisualStyleBackColor = True
      '
      '_backColorPanel
      '
      Me._backColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._backColorPanel.Location = New System.Drawing.Point(80, 30)
      Me._backColorPanel.Name = "_backColorPanel"
      Me._backColorPanel.Size = New System.Drawing.Size(71, 23)
      Me._backColorPanel.TabIndex = 1
      Me._controlsToolTip.SetToolTip(Me._backColorPanel, "The background color used when rendering RTF documents")
      '
      '_backColorLabel
      '
      Me._backColorLabel.AutoSize = True
      Me._backColorLabel.Location = New System.Drawing.Point(13, 35)
      Me._backColorLabel.Name = "_backColorLabel"
      Me._backColorLabel.Size = New System.Drawing.Size(61, 13)
      Me._backColorLabel.TabIndex = 0
      Me._backColorLabel.Text = "&Back color:"
      '
      '_controlsToolTip
      '
      Me._controlsToolTip.IsBalloon = True
      Me._controlsToolTip.ShowAlways = True
      '
      'RtfOptionsControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._generalRtfLoadOptionsGroupBox)
      Me.Name = "RtfOptionsControl"
      Me.Size = New System.Drawing.Size(500, 230)
      Me._generalRtfLoadOptionsGroupBox.ResumeLayout(False)
      Me._generalRtfLoadOptionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _resetToDefaultsButton As System.Windows.Forms.Button
   Private WithEvents _controlsToolTip As System.Windows.Forms.ToolTip
   Private WithEvents _generalRtfLoadOptionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _backColorButton As System.Windows.Forms.Button
   Private WithEvents _backColorPanel As System.Windows.Forms.Panel
   Private WithEvents _backColorLabel As System.Windows.Forms.Label

End Class
