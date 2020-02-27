<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentPagesControl
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
      Me._lastPageNumberTextBox = New System.Windows.Forms.TextBox
      Me._firstPageNumberTextBox = New System.Windows.Forms.TextBox
      Me._pagesGroupBox = New System.Windows.Forms.GroupBox
      Me._loadAllPagesCheckBox = New System.Windows.Forms.CheckBox
      Me._lastPageNumberLabel = New System.Windows.Forms.Label
      Me._firstPageNumberLabel = New System.Windows.Forms.Label
      Me._pagesGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_lastPageNumberTextBox
      '
      Me._lastPageNumberTextBox.Location = New System.Drawing.Point(366, 29)
      Me._lastPageNumberTextBox.Name = "_lastPageNumberTextBox"
      Me._lastPageNumberTextBox.Size = New System.Drawing.Size(100, 20)
      Me._lastPageNumberTextBox.TabIndex = 3
      '
      '_firstPageNumberTextBox
      '
      Me._firstPageNumberTextBox.Location = New System.Drawing.Point(144, 29)
      Me._firstPageNumberTextBox.Name = "_firstPageNumberTextBox"
      Me._firstPageNumberTextBox.Size = New System.Drawing.Size(100, 20)
      Me._firstPageNumberTextBox.TabIndex = 1
      '
      '_pagesGroupBox
      '
      Me._pagesGroupBox.Controls.Add(Me._loadAllPagesCheckBox)
      Me._pagesGroupBox.Controls.Add(Me._lastPageNumberTextBox)
      Me._pagesGroupBox.Controls.Add(Me._firstPageNumberTextBox)
      Me._pagesGroupBox.Controls.Add(Me._lastPageNumberLabel)
      Me._pagesGroupBox.Controls.Add(Me._firstPageNumberLabel)
      Me._pagesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._pagesGroupBox.Location = New System.Drawing.Point(0, 0)
      Me._pagesGroupBox.Name = "_pagesGroupBox"
      Me._pagesGroupBox.Size = New System.Drawing.Size(489, 86)
      Me._pagesGroupBox.TabIndex = 0
      Me._pagesGroupBox.TabStop = False
      Me._pagesGroupBox.Text = "This document contains ### total &pages.  Select the pages you want to load:"
      '
      '_loadAllPagesCheckBox
      '
      Me._loadAllPagesCheckBox.AutoSize = True
      Me._loadAllPagesCheckBox.Location = New System.Drawing.Point(47, 55)
      Me._loadAllPagesCheckBox.Name = "_loadAllPagesCheckBox"
      Me._loadAllPagesCheckBox.Size = New System.Drawing.Size(95, 17)
      Me._loadAllPagesCheckBox.TabIndex = 4
      Me._loadAllPagesCheckBox.Text = "&Load all pages"
      Me._loadAllPagesCheckBox.UseVisualStyleBackColor = True
      '
      '_lastPageNumberLabel
      '
      Me._lastPageNumberLabel.AutoSize = True
      Me._lastPageNumberLabel.Location = New System.Drawing.Point(265, 32)
      Me._lastPageNumberLabel.Name = "_lastPageNumberLabel"
      Me._lastPageNumberLabel.Size = New System.Drawing.Size(95, 13)
      Me._lastPageNumberLabel.TabIndex = 2
      Me._lastPageNumberLabel.Text = "&Last page number:"
      '
      '_firstPageNumberLabel
      '
      Me._firstPageNumberLabel.AutoSize = True
      Me._firstPageNumberLabel.Location = New System.Drawing.Point(44, 32)
      Me._firstPageNumberLabel.Name = "_firstPageNumberLabel"
      Me._firstPageNumberLabel.Size = New System.Drawing.Size(94, 13)
      Me._firstPageNumberLabel.TabIndex = 0
      Me._firstPageNumberLabel.Text = "F&irst page number:"
      '
      'DocumentPagesControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._pagesGroupBox)
      Me.Name = "DocumentPagesControl"
      Me.Size = New System.Drawing.Size(489, 86)
      Me._pagesGroupBox.ResumeLayout(False)
      Me._pagesGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _lastPageNumberTextBox As System.Windows.Forms.TextBox
   Private WithEvents _firstPageNumberTextBox As System.Windows.Forms.TextBox
   Private WithEvents _pagesGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _loadAllPagesCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _lastPageNumberLabel As System.Windows.Forms.Label
   Private WithEvents _firstPageNumberLabel As System.Windows.Forms.Label

End Class
