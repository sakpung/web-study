<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XpsOptionsControl
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
      Me._xpsOptionsNote = New System.Windows.Forms.Label
      Me._generalXpsLoadOptionsGroupBox = New System.Windows.Forms.GroupBox
      Me._generalXpsLoadOptionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_xpsOptionsNote
      '
      Me._xpsOptionsNote.AutoSize = True
      Me._xpsOptionsNote.Location = New System.Drawing.Point(13, 35)
      Me._xpsOptionsNote.Name = "_xpsOptionsNote"
      Me._xpsOptionsNote.Size = New System.Drawing.Size(161, 13)
      Me._xpsOptionsNote.TabIndex = 0
      Me._xpsOptionsNote.Text = "XPS codecs has no load options"
      '
      '_generalXpsLoadOptionsGroupBox
      '
      Me._generalXpsLoadOptionsGroupBox.Controls.Add(Me._xpsOptionsNote)
      Me._generalXpsLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._generalXpsLoadOptionsGroupBox.Location = New System.Drawing.Point(0, 0)
      Me._generalXpsLoadOptionsGroupBox.Name = "_generalXpsLoadOptionsGroupBox"
      Me._generalXpsLoadOptionsGroupBox.Size = New System.Drawing.Size(500, 230)
      Me._generalXpsLoadOptionsGroupBox.TabIndex = 0
      Me._generalXpsLoadOptionsGroupBox.TabStop = False
      Me._generalXpsLoadOptionsGroupBox.Text = "General Open XML Paper Specification (XPS) load options:"
      '
      'XpsOptionsControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._generalXpsLoadOptionsGroupBox)
      Me.Name = "XpsOptionsControl"
      Me.Size = New System.Drawing.Size(500, 230)
      Me._generalXpsLoadOptionsGroupBox.ResumeLayout(False)
      Me._generalXpsLoadOptionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _xpsOptionsNote As System.Windows.Forms.Label
   Private WithEvents _generalXpsLoadOptionsGroupBox As System.Windows.Forms.GroupBox

End Class
