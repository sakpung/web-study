<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecognizedWordsDialog
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
      Me._wordsListBox = New System.Windows.Forms.ListBox
      Me._pagesListBox = New System.Windows.Forms.ListBox
      Me._closeButton = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      '_wordsListBox
      '
      Me._wordsListBox.Font = New System.Drawing.Font("Tahoma", 8.0!)
      Me._wordsListBox.FormattingEnabled = True
      Me._wordsListBox.HorizontalScrollbar = True
      Me._wordsListBox.Location = New System.Drawing.Point(137, 13)
      Me._wordsListBox.Name = "_wordsListBox"
      Me._wordsListBox.Size = New System.Drawing.Size(221, 316)
      Me._wordsListBox.TabIndex = 1
      '
      '_pagesListBox
      '
      Me._pagesListBox.FormattingEnabled = True
      Me._pagesListBox.Location = New System.Drawing.Point(13, 13)
      Me._pagesListBox.Name = "_pagesListBox"
      Me._pagesListBox.Size = New System.Drawing.Size(107, 316)
      Me._pagesListBox.TabIndex = 0
      '
      '_closeButton
      '
      Me._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._closeButton.Location = New System.Drawing.Point(283, 345)
      Me._closeButton.Name = "_closeButton"
      Me._closeButton.Size = New System.Drawing.Size(75, 23)
      Me._closeButton.TabIndex = 2
      Me._closeButton.Text = "Close"
      Me._closeButton.UseVisualStyleBackColor = True
      '
      'RecognizedWordsDialog
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._closeButton
      Me.ClientSize = New System.Drawing.Size(370, 380)
      Me.Controls.Add(Me._wordsListBox)
      Me.Controls.Add(Me._pagesListBox)
      Me.Controls.Add(Me._closeButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "RecognizedWordsDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Recognized Words"
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _wordsListBox As System.Windows.Forms.ListBox
   Private WithEvents _pagesListBox As System.Windows.Forms.ListBox
   Private WithEvents _closeButton As System.Windows.Forms.Button
End Class
