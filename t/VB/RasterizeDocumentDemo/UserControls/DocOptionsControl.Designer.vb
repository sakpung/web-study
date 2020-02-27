<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocOptionsControl
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
      Me._generalDocLoadOptionsGroupBox = New System.Windows.Forms.GroupBox()
      Me._resetToDefaultsButton = New System.Windows.Forms.Button()
      Me._bitDepthComboBox = New System.Windows.Forms.ComboBox()
      Me._bitDepthLabel = New System.Windows.Forms.Label()
      Me._generalDocLoadOptionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_generalDocLoadOptionsGroupBox
      '
      Me._generalDocLoadOptionsGroupBox.Controls.Add(Me._resetToDefaultsButton)
      Me._generalDocLoadOptionsGroupBox.Controls.Add(Me._bitDepthComboBox)
      Me._generalDocLoadOptionsGroupBox.Controls.Add(Me._bitDepthLabel)
      Me._generalDocLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._generalDocLoadOptionsGroupBox.Location = New System.Drawing.Point(0, 0)
      Me._generalDocLoadOptionsGroupBox.Name = "_generalDocLoadOptionsGroupBox"
      Me._generalDocLoadOptionsGroupBox.Size = New System.Drawing.Size(500, 230)
      Me._generalDocLoadOptionsGroupBox.TabIndex = 1
      Me._generalDocLoadOptionsGroupBox.TabStop = False
      Me._generalDocLoadOptionsGroupBox.Text = "General Word DOC (Doc, Docx) load options:"
      '
      '_resetToDefaultsButton
      '
      Me._resetToDefaultsButton.Location = New System.Drawing.Point(305, 201)
      Me._resetToDefaultsButton.Name = "_resetToDefaultsButton"
      Me._resetToDefaultsButton.Size = New System.Drawing.Size(189, 23)
      Me._resetToDefaultsButton.TabIndex = 4
      Me._resetToDefaultsButton.Text = "Reset to defa&ults"
      Me._resetToDefaultsButton.UseVisualStyleBackColor = True
      '
      '_bitDepthComboBox
      '
      Me._bitDepthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._bitDepthComboBox.FormattingEnabled = True
      Me._bitDepthComboBox.Location = New System.Drawing.Point(116, 31)
      Me._bitDepthComboBox.Name = "_bitDepthComboBox"
      Me._bitDepthComboBox.Size = New System.Drawing.Size(194, 21)
      Me._bitDepthComboBox.TabIndex = 3
      '
      '_bitDepthLabel
      '
      Me._bitDepthLabel.AutoSize = True
      Me._bitDepthLabel.Location = New System.Drawing.Point(15, 34)
      Me._bitDepthLabel.Name = "_bitDepthLabel"
      Me._bitDepthLabel.Size = New System.Drawing.Size(54, 13)
      Me._bitDepthLabel.TabIndex = 2
      Me._bitDepthLabel.Text = "&Bit Depth:"
      '
      'DocOptionsControl
      '
      Me.Controls.Add(Me._generalDocLoadOptionsGroupBox)
      Me.Name = "DocOptionsControl"
      Me.Size = New System.Drawing.Size(500, 230)
      Me._generalDocLoadOptionsGroupBox.ResumeLayout(False)
      Me._generalDocLoadOptionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

    Private WithEvents _generalDocLoadOptionsGroupBox As System.Windows.Forms.GroupBox
    Private WithEvents _bitDepthComboBox As System.Windows.Forms.ComboBox
    Private WithEvents _bitDepthLabel As System.Windows.Forms.Label
    Private WithEvents _resetToDefaultsButton As System.Windows.Forms.Button

End Class
