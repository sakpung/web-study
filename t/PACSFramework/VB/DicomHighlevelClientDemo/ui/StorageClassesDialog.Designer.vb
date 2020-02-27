<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StorageClassesDialog
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StorageClassesDialog))
      Me.labelInstructions = New System.Windows.Forms.Label()
      Me.buttonUnselectAll = New System.Windows.Forms.Button()
      Me.buttonSelectAll = New System.Windows.Forms.Button()
      Me._listViewClasses = New System.Windows.Forms.ListView()
      Me.columnHeaderUid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.columnHeaderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.buttonCancel = New System.Windows.Forms.Button()
      Me.buttonOK = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'labelInstructions
      '
      Me.labelInstructions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.labelInstructions.Location = New System.Drawing.Point(12, 11)
      Me.labelInstructions.Name = "labelInstructions"
      Me.labelInstructions.Size = New System.Drawing.Size(535, 38)
      Me.labelInstructions.TabIndex = 20
      Me.labelInstructions.Text = "label1"
      '
      'buttonUnselectAll
      '
      Me.buttonUnselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.buttonUnselectAll.Location = New System.Drawing.Point(94, 625)
      Me.buttonUnselectAll.Name = "buttonUnselectAll"
      Me.buttonUnselectAll.Size = New System.Drawing.Size(75, 23)
      Me.buttonUnselectAll.TabIndex = 19
      Me.buttonUnselectAll.Text = "Unselect All"
      Me.buttonUnselectAll.UseVisualStyleBackColor = True
      '
      'buttonSelectAll
      '
      Me.buttonSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.buttonSelectAll.Location = New System.Drawing.Point(12, 625)
      Me.buttonSelectAll.Name = "buttonSelectAll"
      Me.buttonSelectAll.Size = New System.Drawing.Size(75, 23)
      Me.buttonSelectAll.TabIndex = 18
      Me.buttonSelectAll.Text = "Select All"
      Me.buttonSelectAll.UseVisualStyleBackColor = True
      '
      '_listViewClasses
      '
      Me._listViewClasses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._listViewClasses.CheckBoxes = True
      Me._listViewClasses.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeaderUid, Me.columnHeaderName})
      Me._listViewClasses.FullRowSelect = True
      Me._listViewClasses.Location = New System.Drawing.Point(12, 64)
      Me._listViewClasses.Name = "_listViewClasses"
      Me._listViewClasses.Size = New System.Drawing.Size(534, 544)
      Me._listViewClasses.TabIndex = 17
      Me._listViewClasses.UseCompatibleStateImageBehavior = False
      Me._listViewClasses.View = System.Windows.Forms.View.Details
      '
      'columnHeaderUid
      '
      Me.columnHeaderUid.Text = "SOP Class UID"
      '
      'columnHeaderName
      '
      Me.columnHeaderName.Text = "SOP Class Name"
      '
      'buttonCancel
      '
      Me.buttonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.buttonCancel.CausesValidation = False
      Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.buttonCancel.Location = New System.Drawing.Point(472, 625)
      Me.buttonCancel.Name = "buttonCancel"
      Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
      Me.buttonCancel.TabIndex = 16
      Me.buttonCancel.Text = "&Cancel"
      '
      'buttonOK
      '
      Me.buttonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.buttonOK.Location = New System.Drawing.Point(387, 625)
      Me.buttonOK.Name = "buttonOK"
      Me.buttonOK.Size = New System.Drawing.Size(75, 23)
      Me.buttonOK.TabIndex = 15
      Me.buttonOK.Text = "&OK"
      '
      'StorageClassesDialog
      '
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
      Me.ClientSize = New System.Drawing.Size(558, 658)
      Me.Controls.Add(Me.labelInstructions)
      Me.Controls.Add(Me.buttonUnselectAll)
      Me.Controls.Add(Me.buttonSelectAll)
      Me.Controls.Add(Me._listViewClasses)
      Me.Controls.Add(Me.buttonCancel)
      Me.Controls.Add(Me.buttonOK)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "StorageClassesDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "C-GET Storage Classes"
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents labelInstructions As System.Windows.Forms.Label
   Private WithEvents buttonUnselectAll As System.Windows.Forms.Button
   Private WithEvents buttonSelectAll As System.Windows.Forms.Button
   Private WithEvents _listViewClasses As System.Windows.Forms.ListView
   Private WithEvents columnHeaderUid As System.Windows.Forms.ColumnHeader
   Private WithEvents columnHeaderName As System.Windows.Forms.ColumnHeader
   Private WithEvents buttonCancel As System.Windows.Forms.Button
   Private WithEvents buttonOK As System.Windows.Forms.Button
End Class
