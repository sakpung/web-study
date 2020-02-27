<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModifyTablesDlg
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
        Me.buttonClose = New System.Windows.Forms.Button
        Me.groupBoxContextGroupTable = New System.Windows.Forms.GroupBox
        Me.buttonContextGroupFile = New System.Windows.Forms.Button
        Me.buttonResetContextGroupTable = New System.Windows.Forms.Button
        Me.textBoxContextGroupFile = New System.Windows.Forms.TextBox
        Me.buttonLoadContextGroupTable = New System.Windows.Forms.Button
        Me.buttonShowContextGroupTable = New System.Windows.Forms.Button
        Me.groupBoxIodTable = New System.Windows.Forms.GroupBox
        Me.buttonIodFile = New System.Windows.Forms.Button
        Me.buttonResetIodTable = New System.Windows.Forms.Button
        Me.textBoxIodFile = New System.Windows.Forms.TextBox
        Me.buttonLoadIodTable = New System.Windows.Forms.Button
        Me.buttonShowIodTable = New System.Windows.Forms.Button
        Me.groupBoxElementTagTable = New System.Windows.Forms.GroupBox
        Me.buttonTagFile = New System.Windows.Forms.Button
        Me.buttonResetTagTable = New System.Windows.Forms.Button
        Me.textBoxTagFile = New System.Windows.Forms.TextBox
        Me.buttonLoadTagTable = New System.Windows.Forms.Button
        Me.buttonTagTable = New System.Windows.Forms.Button
        Me.groupBoxUidTable = New System.Windows.Forms.GroupBox
        Me.buttonUidFile = New System.Windows.Forms.Button
        Me.textBoxUidFile = New System.Windows.Forms.TextBox
        Me.buttonShowUidTable = New System.Windows.Forms.Button
        Me.buttonResetUidTable = New System.Windows.Forms.Button
        Me.buttonLoadUidTable = New System.Windows.Forms.Button
        Me.groupBoxContextGroupTable.SuspendLayout()
        Me.groupBoxIodTable.SuspendLayout()
        Me.groupBoxElementTagTable.SuspendLayout()
        Me.groupBoxUidTable.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonClose
        '
        Me.buttonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonClose.Location = New System.Drawing.Point(639, 430)
        Me.buttonClose.Name = "buttonClose"
        Me.buttonClose.Size = New System.Drawing.Size(75, 23)
        Me.buttonClose.TabIndex = 9
        Me.buttonClose.Text = "Close"
        Me.buttonClose.UseVisualStyleBackColor = True
        '
        'groupBoxContextGroupTable
        '
        Me.groupBoxContextGroupTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBoxContextGroupTable.Controls.Add(Me.buttonContextGroupFile)
        Me.groupBoxContextGroupTable.Controls.Add(Me.buttonResetContextGroupTable)
        Me.groupBoxContextGroupTable.Controls.Add(Me.textBoxContextGroupFile)
        Me.groupBoxContextGroupTable.Controls.Add(Me.buttonLoadContextGroupTable)
        Me.groupBoxContextGroupTable.Controls.Add(Me.buttonShowContextGroupTable)
        Me.groupBoxContextGroupTable.Location = New System.Drawing.Point(15, 318)
        Me.groupBoxContextGroupTable.Name = "groupBoxContextGroupTable"
        Me.groupBoxContextGroupTable.Size = New System.Drawing.Size(696, 100)
        Me.groupBoxContextGroupTable.TabIndex = 8
        Me.groupBoxContextGroupTable.TabStop = False
        Me.groupBoxContextGroupTable.Text = "Context Group Table"
        '
        'buttonContextGroupFile
        '
        Me.buttonContextGroupFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonContextGroupFile.Location = New System.Drawing.Point(656, 19)
        Me.buttonContextGroupFile.Name = "buttonContextGroupFile"
        Me.buttonContextGroupFile.Size = New System.Drawing.Size(32, 23)
        Me.buttonContextGroupFile.TabIndex = 19
        Me.buttonContextGroupFile.Text = "..."
        Me.buttonContextGroupFile.UseVisualStyleBackColor = True
        '
        'buttonResetContextGroupTable
        '
        Me.buttonResetContextGroupTable.Location = New System.Drawing.Point(16, 43)
        Me.buttonResetContextGroupTable.Name = "buttonResetContextGroupTable"
        Me.buttonResetContextGroupTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonResetContextGroupTable.TabIndex = 16
        Me.buttonResetContextGroupTable.Text = "Reset..."
        Me.buttonResetContextGroupTable.UseVisualStyleBackColor = True
        '
        'textBoxContextGroupFile
        '
        Me.textBoxContextGroupFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBoxContextGroupFile.Location = New System.Drawing.Point(120, 20)
        Me.textBoxContextGroupFile.Name = "textBoxContextGroupFile"
        Me.textBoxContextGroupFile.Size = New System.Drawing.Size(528, 20)
        Me.textBoxContextGroupFile.TabIndex = 18
        '
        'buttonLoadContextGroupTable
        '
        Me.buttonLoadContextGroupTable.Location = New System.Drawing.Point(16, 19)
        Me.buttonLoadContextGroupTable.Name = "buttonLoadContextGroupTable"
        Me.buttonLoadContextGroupTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonLoadContextGroupTable.TabIndex = 15
        Me.buttonLoadContextGroupTable.Text = "Load from file-->"
        Me.buttonLoadContextGroupTable.UseVisualStyleBackColor = True
        '
        'buttonShowContextGroupTable
        '
        Me.buttonShowContextGroupTable.Location = New System.Drawing.Point(16, 67)
        Me.buttonShowContextGroupTable.Name = "buttonShowContextGroupTable"
        Me.buttonShowContextGroupTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonShowContextGroupTable.TabIndex = 17
        Me.buttonShowContextGroupTable.Text = "Show..."
        Me.buttonShowContextGroupTable.UseVisualStyleBackColor = True
        '
        'groupBoxIodTable
        '
        Me.groupBoxIodTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBoxIodTable.Controls.Add(Me.buttonIodFile)
        Me.groupBoxIodTable.Controls.Add(Me.buttonResetIodTable)
        Me.groupBoxIodTable.Controls.Add(Me.textBoxIodFile)
        Me.groupBoxIodTable.Controls.Add(Me.buttonLoadIodTable)
        Me.groupBoxIodTable.Controls.Add(Me.buttonShowIodTable)
        Me.groupBoxIodTable.Location = New System.Drawing.Point(15, 217)
        Me.groupBoxIodTable.Name = "groupBoxIodTable"
        Me.groupBoxIodTable.Size = New System.Drawing.Size(696, 100)
        Me.groupBoxIodTable.TabIndex = 7
        Me.groupBoxIodTable.TabStop = False
        Me.groupBoxIodTable.Text = "IOD Table"
        '
        'buttonIodFile
        '
        Me.buttonIodFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonIodFile.Location = New System.Drawing.Point(656, 19)
        Me.buttonIodFile.Name = "buttonIodFile"
        Me.buttonIodFile.Size = New System.Drawing.Size(32, 23)
        Me.buttonIodFile.TabIndex = 14
        Me.buttonIodFile.Text = "..."
        Me.buttonIodFile.UseVisualStyleBackColor = True
        '
        'buttonResetIodTable
        '
        Me.buttonResetIodTable.Location = New System.Drawing.Point(16, 43)
        Me.buttonResetIodTable.Name = "buttonResetIodTable"
        Me.buttonResetIodTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonResetIodTable.TabIndex = 11
        Me.buttonResetIodTable.Text = "Reset..."
        Me.buttonResetIodTable.UseVisualStyleBackColor = True
        '
        'textBoxIodFile
        '
        Me.textBoxIodFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBoxIodFile.Location = New System.Drawing.Point(120, 20)
        Me.textBoxIodFile.Name = "textBoxIodFile"
        Me.textBoxIodFile.Size = New System.Drawing.Size(528, 20)
        Me.textBoxIodFile.TabIndex = 13
        '
        'buttonLoadIodTable
        '
        Me.buttonLoadIodTable.Location = New System.Drawing.Point(16, 19)
        Me.buttonLoadIodTable.Name = "buttonLoadIodTable"
        Me.buttonLoadIodTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonLoadIodTable.TabIndex = 10
        Me.buttonLoadIodTable.Text = "Load from file-->"
        Me.buttonLoadIodTable.UseVisualStyleBackColor = True
        '
        'buttonShowIodTable
        '
        Me.buttonShowIodTable.Location = New System.Drawing.Point(16, 67)
        Me.buttonShowIodTable.Name = "buttonShowIodTable"
        Me.buttonShowIodTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonShowIodTable.TabIndex = 12
        Me.buttonShowIodTable.Text = "Show..."
        Me.buttonShowIodTable.UseVisualStyleBackColor = True
        '
        'groupBoxElementTagTable
        '
        Me.groupBoxElementTagTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBoxElementTagTable.Controls.Add(Me.buttonTagFile)
        Me.groupBoxElementTagTable.Controls.Add(Me.buttonResetTagTable)
        Me.groupBoxElementTagTable.Controls.Add(Me.textBoxTagFile)
        Me.groupBoxElementTagTable.Controls.Add(Me.buttonLoadTagTable)
        Me.groupBoxElementTagTable.Controls.Add(Me.buttonTagTable)
        Me.groupBoxElementTagTable.Location = New System.Drawing.Point(15, 116)
        Me.groupBoxElementTagTable.Name = "groupBoxElementTagTable"
        Me.groupBoxElementTagTable.Size = New System.Drawing.Size(696, 100)
        Me.groupBoxElementTagTable.TabIndex = 6
        Me.groupBoxElementTagTable.TabStop = False
        Me.groupBoxElementTagTable.Text = "Element Tag Table"
        '
        'buttonTagFile
        '
        Me.buttonTagFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonTagFile.Location = New System.Drawing.Point(656, 19)
        Me.buttonTagFile.Name = "buttonTagFile"
        Me.buttonTagFile.Size = New System.Drawing.Size(32, 23)
        Me.buttonTagFile.TabIndex = 9
        Me.buttonTagFile.Text = "..."
        Me.buttonTagFile.UseVisualStyleBackColor = True
        '
        'buttonResetTagTable
        '
        Me.buttonResetTagTable.Location = New System.Drawing.Point(16, 43)
        Me.buttonResetTagTable.Name = "buttonResetTagTable"
        Me.buttonResetTagTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonResetTagTable.TabIndex = 6
        Me.buttonResetTagTable.Text = "Reset..."
        Me.buttonResetTagTable.UseVisualStyleBackColor = True
        '
        'textBoxTagFile
        '
        Me.textBoxTagFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBoxTagFile.Location = New System.Drawing.Point(120, 20)
        Me.textBoxTagFile.Name = "textBoxTagFile"
        Me.textBoxTagFile.Size = New System.Drawing.Size(528, 20)
        Me.textBoxTagFile.TabIndex = 8
        '
        'buttonLoadTagTable
        '
        Me.buttonLoadTagTable.Location = New System.Drawing.Point(16, 19)
        Me.buttonLoadTagTable.Name = "buttonLoadTagTable"
        Me.buttonLoadTagTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonLoadTagTable.TabIndex = 5
        Me.buttonLoadTagTable.Text = "Load from file-->"
        Me.buttonLoadTagTable.UseVisualStyleBackColor = True
        '
        'buttonTagTable
        '
        Me.buttonTagTable.Location = New System.Drawing.Point(16, 67)
        Me.buttonTagTable.Name = "buttonTagTable"
        Me.buttonTagTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonTagTable.TabIndex = 7
        Me.buttonTagTable.Text = "Show..."
        Me.buttonTagTable.UseVisualStyleBackColor = True
        '
        'groupBoxUidTable
        '
        Me.groupBoxUidTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBoxUidTable.Controls.Add(Me.buttonUidFile)
        Me.groupBoxUidTable.Controls.Add(Me.textBoxUidFile)
        Me.groupBoxUidTable.Controls.Add(Me.buttonShowUidTable)
        Me.groupBoxUidTable.Controls.Add(Me.buttonResetUidTable)
        Me.groupBoxUidTable.Controls.Add(Me.buttonLoadUidTable)
        Me.groupBoxUidTable.Location = New System.Drawing.Point(15, 15)
        Me.groupBoxUidTable.Name = "groupBoxUidTable"
        Me.groupBoxUidTable.Size = New System.Drawing.Size(696, 100)
        Me.groupBoxUidTable.TabIndex = 5
        Me.groupBoxUidTable.TabStop = False
        Me.groupBoxUidTable.Text = "UID Table"
        '
        'buttonUidFile
        '
        Me.buttonUidFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonUidFile.Location = New System.Drawing.Point(656, 16)
        Me.buttonUidFile.Name = "buttonUidFile"
        Me.buttonUidFile.Size = New System.Drawing.Size(32, 23)
        Me.buttonUidFile.TabIndex = 4
        Me.buttonUidFile.Text = "..."
        Me.buttonUidFile.UseVisualStyleBackColor = True
        '
        'textBoxUidFile
        '
        Me.textBoxUidFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBoxUidFile.Location = New System.Drawing.Point(120, 17)
        Me.textBoxUidFile.Name = "textBoxUidFile"
        Me.textBoxUidFile.Size = New System.Drawing.Size(528, 20)
        Me.textBoxUidFile.TabIndex = 3
        '
        'buttonShowUidTable
        '
        Me.buttonShowUidTable.Location = New System.Drawing.Point(16, 64)
        Me.buttonShowUidTable.Name = "buttonShowUidTable"
        Me.buttonShowUidTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonShowUidTable.TabIndex = 2
        Me.buttonShowUidTable.Text = "Show..."
        Me.buttonShowUidTable.UseVisualStyleBackColor = True
        '
        'buttonResetUidTable
        '
        Me.buttonResetUidTable.Location = New System.Drawing.Point(16, 40)
        Me.buttonResetUidTable.Name = "buttonResetUidTable"
        Me.buttonResetUidTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonResetUidTable.TabIndex = 1
        Me.buttonResetUidTable.Text = "Reset..."
        Me.buttonResetUidTable.UseVisualStyleBackColor = True
        '
        'buttonLoadUidTable
        '
        Me.buttonLoadUidTable.Location = New System.Drawing.Point(16, 16)
        Me.buttonLoadUidTable.Name = "buttonLoadUidTable"
        Me.buttonLoadUidTable.Size = New System.Drawing.Size(96, 23)
        Me.buttonLoadUidTable.TabIndex = 0
        Me.buttonLoadUidTable.Text = "Load from file-->"
        Me.buttonLoadUidTable.UseVisualStyleBackColor = True
        '
        'ModifyTablesDlg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 469)
        Me.Controls.Add(Me.buttonClose)
        Me.Controls.Add(Me.groupBoxContextGroupTable)
        Me.Controls.Add(Me.groupBoxIodTable)
        Me.Controls.Add(Me.groupBoxElementTagTable)
        Me.Controls.Add(Me.groupBoxUidTable)
        Me.MinimizeBox = False
        Me.Name = "ModifyTablesDlg"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modify Tables"
        Me.groupBoxContextGroupTable.ResumeLayout(False)
        Me.groupBoxContextGroupTable.PerformLayout()
        Me.groupBoxIodTable.ResumeLayout(False)
        Me.groupBoxIodTable.PerformLayout()
        Me.groupBoxElementTagTable.ResumeLayout(False)
        Me.groupBoxElementTagTable.PerformLayout()
        Me.groupBoxUidTable.ResumeLayout(False)
        Me.groupBoxUidTable.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents buttonClose As System.Windows.Forms.Button
    Private WithEvents groupBoxContextGroupTable As System.Windows.Forms.GroupBox
    Private WithEvents buttonContextGroupFile As System.Windows.Forms.Button
    Private WithEvents buttonResetContextGroupTable As System.Windows.Forms.Button
    Private WithEvents textBoxContextGroupFile As System.Windows.Forms.TextBox
    Private WithEvents buttonLoadContextGroupTable As System.Windows.Forms.Button
    Private WithEvents buttonShowContextGroupTable As System.Windows.Forms.Button
    Private WithEvents groupBoxIodTable As System.Windows.Forms.GroupBox
    Private WithEvents buttonIodFile As System.Windows.Forms.Button
    Private WithEvents buttonResetIodTable As System.Windows.Forms.Button
    Private WithEvents textBoxIodFile As System.Windows.Forms.TextBox
    Private WithEvents buttonLoadIodTable As System.Windows.Forms.Button
    Private WithEvents buttonShowIodTable As System.Windows.Forms.Button
    Private WithEvents groupBoxElementTagTable As System.Windows.Forms.GroupBox
    Private WithEvents buttonTagFile As System.Windows.Forms.Button
    Private WithEvents buttonResetTagTable As System.Windows.Forms.Button
    Private WithEvents textBoxTagFile As System.Windows.Forms.TextBox
    Private WithEvents buttonLoadTagTable As System.Windows.Forms.Button
    Private WithEvents buttonTagTable As System.Windows.Forms.Button
    Private WithEvents groupBoxUidTable As System.Windows.Forms.GroupBox
    Private WithEvents buttonUidFile As System.Windows.Forms.Button
    Private WithEvents textBoxUidFile As System.Windows.Forms.TextBox
    Private WithEvents buttonShowUidTable As System.Windows.Forms.Button
    Private WithEvents buttonResetUidTable As System.Windows.Forms.Button
    Private WithEvents buttonLoadUidTable As System.Windows.Forms.Button
End Class
