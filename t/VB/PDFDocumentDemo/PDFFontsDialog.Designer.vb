<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDFFontsDialog
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
      Me._fontsGroupBox = New System.Windows.Forms.GroupBox()
      Me._fontsListView = New System.Windows.Forms.ListView()
      Me._faceNameColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me._typeColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me._encodingColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me._okButton = New System.Windows.Forms.Button()
      Me._fontsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_fontsGroupBox
      '
      Me._fontsGroupBox.Controls.Add(Me._fontsListView)
      Me._fontsGroupBox.Location = New System.Drawing.Point(12, 12)
      Me._fontsGroupBox.Name = "_fontsGroupBox"
      Me._fontsGroupBox.Size = New System.Drawing.Size(721, 367)
      Me._fontsGroupBox.TabIndex = 0
      Me._fontsGroupBox.TabStop = False
      Me._fontsGroupBox.Text = "&Fonts used in this Document"
      '
      '_fontsListView
      '
      Me._fontsListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._faceNameColumnHeader, Me._typeColumnHeader, Me._encodingColumnHeader})
      Me._fontsListView.Location = New System.Drawing.Point(22, 37)
      Me._fontsListView.Name = "_fontsListView"
      Me._fontsListView.Size = New System.Drawing.Size(668, 309)
      Me._fontsListView.Sorting = System.Windows.Forms.SortOrder.Ascending
      Me._fontsListView.TabIndex = 0
      Me._fontsListView.UseCompatibleStateImageBehavior = False
      Me._fontsListView.View = System.Windows.Forms.View.Details
      '
      '_faceNameColumnHeader
      '
      Me._faceNameColumnHeader.Text = "Face Name"
      Me._faceNameColumnHeader.Width = 120
      '
      '_typeColumnHeader
      '
      Me._typeColumnHeader.Text = "Type"
      Me._typeColumnHeader.Width = 120
      '
      '_encodingColumnHeader
      '
      Me._encodingColumnHeader.Text = "Encoding"
      Me._encodingColumnHeader.Width = 180
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._okButton.Location = New System.Drawing.Point(621, 409)
      Me._okButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(112, 35)
      Me._okButton.TabIndex = 1
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      'PDFFontsDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._okButton
      Me.ClientSize = New System.Drawing.Size(746, 497)
      Me.ControlBox = False
      Me.Controls.Add(Me._fontsGroupBox)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PDFFontsDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Fonts"
      Me._fontsGroupBox.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

   Private WithEvents _fontsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _fontsListView As System.Windows.Forms.ListView
   Private WithEvents _faceNameColumnHeader As System.Windows.Forms.ColumnHeader
   Private WithEvents _typeColumnHeader As System.Windows.Forms.ColumnHeader
   Private WithEvents _encodingColumnHeader As System.Windows.Forms.ColumnHeader
   Private WithEvents _okButton As System.Windows.Forms.Button
End Class
