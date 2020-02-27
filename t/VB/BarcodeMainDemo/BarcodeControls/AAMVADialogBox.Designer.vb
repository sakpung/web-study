<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AAMVADialogBox
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
      Me._commonFieldsLabel = New System.Windows.Forms.Label()
      Me._listViewCommonFields = New System.Windows.Forms.ListView()
      Me._dataElementsLabel = New System.Windows.Forms.Label()
      Me._listViewRawDataElements = New System.Windows.Forms.ListView()
      Me._btnCloseAAMVA = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      '_commonFieldsLabel
      '
      Me._commonFieldsLabel.AutoSize = True
      Me._commonFieldsLabel.Location = New System.Drawing.Point(12, 9)
      Me._commonFieldsLabel.Name = "_commonFieldsLabel"
      Me._commonFieldsLabel.Size = New System.Drawing.Size(78, 13)
      Me._commonFieldsLabel.TabIndex = 0
      Me._commonFieldsLabel.Text = "Common Fields"
      '
      '_listViewCommonFields
      '
      Me._listViewCommonFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._listViewCommonFields.Location = New System.Drawing.Point(12, 25)
      Me._listViewCommonFields.Name = "_listViewCommonFields"
      Me._listViewCommonFields.Size = New System.Drawing.Size(759, 197)
      Me._listViewCommonFields.TabIndex = 1
      Me._listViewCommonFields.UseCompatibleStateImageBehavior = False
      '
      '_dataElementsLabel
      '
      Me._dataElementsLabel.AutoSize = True
      Me._dataElementsLabel.Location = New System.Drawing.Point(12, 250)
      Me._dataElementsLabel.Name = "_dataElementsLabel"
      Me._dataElementsLabel.Size = New System.Drawing.Size(101, 13)
      Me._dataElementsLabel.TabIndex = 2
      Me._dataElementsLabel.Text = "Raw Data Elements"
      '
      '_listViewRawDataElements
      '
      Me._listViewRawDataElements.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._listViewRawDataElements.Location = New System.Drawing.Point(12, 266)
      Me._listViewRawDataElements.Name = "_listViewRawDataElements"
      Me._listViewRawDataElements.Size = New System.Drawing.Size(760, 231)
      Me._listViewRawDataElements.TabIndex = 3
      Me._listViewRawDataElements.UseCompatibleStateImageBehavior = False
      '
      '_btnCloseAAMVA
      '
      Me._btnCloseAAMVA.Location = New System.Drawing.Point(697, 526)
      Me._btnCloseAAMVA.Name = "_btnCloseAAMVA"
      Me._btnCloseAAMVA.Size = New System.Drawing.Size(75, 23)
      Me._btnCloseAAMVA.TabIndex = 4
      Me._btnCloseAAMVA.Text = "Close"
      Me._btnCloseAAMVA.UseVisualStyleBackColor = True
      '
      'AAMVADialogBox
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(784, 561)
      Me.Controls.Add(Me._btnCloseAAMVA)
      Me.Controls.Add(Me._listViewRawDataElements)
      Me.Controls.Add(Me._dataElementsLabel)
      Me.Controls.Add(Me._listViewCommonFields)
      Me.Controls.Add(Me._commonFieldsLabel)
      Me.MinimumSize = New System.Drawing.Size(800, 600)
      Me.Name = "AAMVADialogBox"
      Me.ShowIcon = False
      Me.Text = "AAMVA ID Data"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents _commonFieldsLabel As System.Windows.Forms.Label
   Friend WithEvents _listViewCommonFields As System.Windows.Forms.ListView
   Friend WithEvents _dataElementsLabel As System.Windows.Forms.Label
   Friend WithEvents _listViewRawDataElements As System.Windows.Forms.ListView
   Friend WithEvents _btnCloseAAMVA As System.Windows.Forms.Button
End Class
