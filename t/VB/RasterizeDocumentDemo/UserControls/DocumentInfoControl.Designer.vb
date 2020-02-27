<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentInfoControl
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
      Me._warningLabel = New System.Windows.Forms.Label
      Me._loadDocumentSizePixelsLabel = New System.Windows.Forms.Label
      Me._documentInfoGroupBox = New System.Windows.Forms.GroupBox
      Me._loadDocumentSizeValueLabel = New System.Windows.Forms.Label
      Me._originalDocumentSizeValueLabel = New System.Windows.Forms.Label
      Me._pagesValueLabel = New System.Windows.Forms.Label
      Me._formatValueLabel = New System.Windows.Forms.Label
      Me._loadDocumentSizeLabel = New System.Windows.Forms.Label
      Me._originalDocumentSizeLabel = New System.Windows.Forms.Label
      Me._pagesLabel = New System.Windows.Forms.Label
      Me._formatLabel = New System.Windows.Forms.Label
      Me._documentInfoGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_warningLabel
      '
      Me._warningLabel.Location = New System.Drawing.Point(22, 148)
      Me._warningLabel.Name = "_warningLabel"
      Me._warningLabel.Size = New System.Drawing.Size(455, 49)
      Me._warningLabel.TabIndex = 9
      Me._warningLabel.Text = "Warning: This file is a normal raster format and not a document format. Loading t" & _
          "his file will not use the Rasterize Document Options you set. The file will be l" & _
          "oaded using its original size."
      '
      '_loadDocumentSizePixelsLabel
      '
      Me._loadDocumentSizePixelsLabel.AutoSize = True
      Me._loadDocumentSizePixelsLabel.Location = New System.Drawing.Point(151, 125)
      Me._loadDocumentSizePixelsLabel.Name = "_loadDocumentSizePixelsLabel"
      Me._loadDocumentSizePixelsLabel.Size = New System.Drawing.Size(188, 13)
      Me._loadDocumentSizePixelsLabel.TabIndex = 8
      Me._loadDocumentSizePixelsLabel.Text = "9999 by 9999 pixels at 300 pixels/inch"
      '
      '_documentInfoGroupBox
      '
      Me._documentInfoGroupBox.Controls.Add(Me._warningLabel)
      Me._documentInfoGroupBox.Controls.Add(Me._loadDocumentSizePixelsLabel)
      Me._documentInfoGroupBox.Controls.Add(Me._loadDocumentSizeValueLabel)
      Me._documentInfoGroupBox.Controls.Add(Me._originalDocumentSizeValueLabel)
      Me._documentInfoGroupBox.Controls.Add(Me._pagesValueLabel)
      Me._documentInfoGroupBox.Controls.Add(Me._formatValueLabel)
      Me._documentInfoGroupBox.Controls.Add(Me._loadDocumentSizeLabel)
      Me._documentInfoGroupBox.Controls.Add(Me._originalDocumentSizeLabel)
      Me._documentInfoGroupBox.Controls.Add(Me._pagesLabel)
      Me._documentInfoGroupBox.Controls.Add(Me._formatLabel)
      Me._documentInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._documentInfoGroupBox.Location = New System.Drawing.Point(0, 0)
      Me._documentInfoGroupBox.Name = "_documentInfoGroupBox"
      Me._documentInfoGroupBox.Size = New System.Drawing.Size(520, 200)
      Me._documentInfoGroupBox.TabIndex = 0
      Me._documentInfoGroupBox.TabStop = False
      Me._documentInfoGroupBox.Text = "Document information:"
      '
      '_loadDocumentSizeValueLabel
      '
      Me._loadDocumentSizeValueLabel.AutoSize = True
      Me._loadDocumentSizeValueLabel.Location = New System.Drawing.Point(151, 102)
      Me._loadDocumentSizeValueLabel.Name = "_loadDocumentSizeValueLabel"
      Me._loadDocumentSizeValueLabel.Size = New System.Drawing.Size(106, 13)
      Me._loadDocumentSizeValueLabel.TabIndex = 7
      Me._loadDocumentSizeValueLabel.Text = "9999 by 9999 inches"
      '
      '_originalDocumentSizeValueLabel
      '
      Me._originalDocumentSizeValueLabel.AutoSize = True
      Me._originalDocumentSizeValueLabel.Location = New System.Drawing.Point(151, 79)
      Me._originalDocumentSizeValueLabel.Name = "_originalDocumentSizeValueLabel"
      Me._originalDocumentSizeValueLabel.Size = New System.Drawing.Size(106, 13)
      Me._originalDocumentSizeValueLabel.TabIndex = 5
      Me._originalDocumentSizeValueLabel.Text = "9999 by 9999 inches"
      '
      '_pagesValueLabel
      '
      Me._pagesValueLabel.AutoSize = True
      Me._pagesValueLabel.Location = New System.Drawing.Point(151, 56)
      Me._pagesValueLabel.Name = "_pagesValueLabel"
      Me._pagesValueLabel.Size = New System.Drawing.Size(25, 13)
      Me._pagesValueLabel.TabIndex = 3
      Me._pagesValueLabel.Text = "999"
      '
      '_formatValueLabel
      '
      Me._formatValueLabel.AutoSize = True
      Me._formatValueLabel.Location = New System.Drawing.Point(151, 33)
      Me._formatValueLabel.Name = "_formatValueLabel"
      Me._formatValueLabel.Size = New System.Drawing.Size(197, 13)
      Me._formatValueLabel.TabIndex = 1
      Me._formatValueLabel.Text = "Adobe Portable Document Format (PDF)"
      '
      '_loadDocumentSizeLabel
      '
      Me._loadDocumentSizeLabel.AutoSize = True
      Me._loadDocumentSizeLabel.Location = New System.Drawing.Point(22, 102)
      Me._loadDocumentSizeLabel.Name = "_loadDocumentSizeLabel"
      Me._loadDocumentSizeLabel.Size = New System.Drawing.Size(105, 13)
      Me._loadDocumentSizeLabel.TabIndex = 6
      Me._loadDocumentSizeLabel.Text = "Load document size:"
      '
      '_originalDocumentSizeLabel
      '
      Me._originalDocumentSizeLabel.AutoSize = True
      Me._originalDocumentSizeLabel.Location = New System.Drawing.Point(22, 79)
      Me._originalDocumentSizeLabel.Name = "_originalDocumentSizeLabel"
      Me._originalDocumentSizeLabel.Size = New System.Drawing.Size(116, 13)
      Me._originalDocumentSizeLabel.TabIndex = 4
      Me._originalDocumentSizeLabel.Text = "Original document size:"
      '
      '_pagesLabel
      '
      Me._pagesLabel.AutoSize = True
      Me._pagesLabel.Location = New System.Drawing.Point(22, 56)
      Me._pagesLabel.Name = "_pagesLabel"
      Me._pagesLabel.Size = New System.Drawing.Size(40, 13)
      Me._pagesLabel.TabIndex = 2
      Me._pagesLabel.Text = "Pages:"
      '
      '_formatLabel
      '
      Me._formatLabel.AutoSize = True
      Me._formatLabel.Location = New System.Drawing.Point(22, 33)
      Me._formatLabel.Name = "_formatLabel"
      Me._formatLabel.Size = New System.Drawing.Size(42, 13)
      Me._formatLabel.TabIndex = 0
      Me._formatLabel.Text = "Format:"
      '
      'DocumentInfoControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._documentInfoGroupBox)
      Me.Name = "DocumentInfoControl"
      Me.Size = New System.Drawing.Size(520, 200)
      Me._documentInfoGroupBox.ResumeLayout(False)
      Me._documentInfoGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _warningLabel As System.Windows.Forms.Label
   Private WithEvents _loadDocumentSizePixelsLabel As System.Windows.Forms.Label
   Private WithEvents _documentInfoGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _loadDocumentSizeValueLabel As System.Windows.Forms.Label
   Private WithEvents _originalDocumentSizeValueLabel As System.Windows.Forms.Label
   Private WithEvents _pagesValueLabel As System.Windows.Forms.Label
   Private WithEvents _formatValueLabel As System.Windows.Forms.Label
   Private WithEvents _loadDocumentSizeLabel As System.Windows.Forms.Label
   Private WithEvents _originalDocumentSizeLabel As System.Windows.Forms.Label
   Private WithEvents _pagesLabel As System.Windows.Forms.Label
   Private WithEvents _formatLabel As System.Windows.Forms.Label

End Class
