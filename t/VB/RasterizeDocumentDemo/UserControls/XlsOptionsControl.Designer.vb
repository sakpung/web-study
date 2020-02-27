<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XlsOptionsControl
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
      Me._generalXlsLoadOptionsGroupBox = New System.Windows.Forms.GroupBox
      Me._resetToDefaultsButton = New System.Windows.Forms.Button
      Me._multiPageSheetCheckBox = New System.Windows.Forms.CheckBox
      Me._controlsToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me._generalXlsLoadOptionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_generalXlsLoadOptionsGroupBox
      '
      Me._generalXlsLoadOptionsGroupBox.Controls.Add(Me._resetToDefaultsButton)
      Me._generalXlsLoadOptionsGroupBox.Controls.Add(Me._multiPageSheetCheckBox)
      Me._generalXlsLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._generalXlsLoadOptionsGroupBox.Location = New System.Drawing.Point(0, 0)
      Me._generalXlsLoadOptionsGroupBox.Name = "_generalXlsLoadOptionsGroupBox"
      Me._generalXlsLoadOptionsGroupBox.Size = New System.Drawing.Size(500, 230)
      Me._generalXlsLoadOptionsGroupBox.TabIndex = 0
      Me._generalXlsLoadOptionsGroupBox.TabStop = False
      Me._generalXlsLoadOptionsGroupBox.Text = "General Microsoft Excel 2003 (XLS) Document load options:"
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
      '_multiPageSheetCheckBox
      '
      Me._multiPageSheetCheckBox.AutoSize = True
      Me._multiPageSheetCheckBox.Location = New System.Drawing.Point(21, 19)
      Me._multiPageSheetCheckBox.Name = "_multiPageSheetCheckBox"
      Me._multiPageSheetCheckBox.Size = New System.Drawing.Size(127, 17)
      Me._multiPageSheetCheckBox.TabIndex = 1
      Me._multiPageSheetCheckBox.Text = "&Multi-page XLS sheet"
      Me._controlsToolTip.SetToolTip(Me._multiPageSheetCheckBox, "Use one sheet per page when rendering XLS documents")
      Me._multiPageSheetCheckBox.UseVisualStyleBackColor = True
      '
      '_controlsToolTip
      '
      Me._controlsToolTip.IsBalloon = True
      Me._controlsToolTip.ShowAlways = True
      '
      'XlsOptionsControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._generalXlsLoadOptionsGroupBox)
      Me.Name = "XlsOptionsControl"
      Me.Size = New System.Drawing.Size(500, 230)
      Me._generalXlsLoadOptionsGroupBox.ResumeLayout(False)
      Me._generalXlsLoadOptionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _generalXlsLoadOptionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _resetToDefaultsButton As System.Windows.Forms.Button
   Private WithEvents _controlsToolTip As System.Windows.Forms.ToolTip
   Private WithEvents _multiPageSheetCheckBox As System.Windows.Forms.CheckBox

End Class
