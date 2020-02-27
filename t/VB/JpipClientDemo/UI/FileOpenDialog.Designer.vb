Imports Microsoft.VisualBasic
Imports System

   Partial Public Class FileOpenDialog
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
Me.rbtnFileName = New System.Windows.Forms.RadioButton
Me.tbtnEnumerate = New System.Windows.Forms.RadioButton
Me.txtFileName = New System.Windows.Forms.TextBox
Me.pnlEnumerateService = New System.Windows.Forms.Panel
Me.lstFiles = New System.Windows.Forms.ListBox
Me.btnGetFiles = New System.Windows.Forms.Button
Me.grpSepa = New System.Windows.Forms.GroupBox
Me.btnOK = New System.Windows.Forms.Button
Me.btnCancel = New System.Windows.Forms.Button
Me.pnlEnumerateService.SuspendLayout()
Me.SuspendLayout()
'
'rbtnFileName
'
Me.rbtnFileName.AutoSize = True
Me.rbtnFileName.Checked = True
Me.rbtnFileName.Location = New System.Drawing.Point(12, 12)
Me.rbtnFileName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.rbtnFileName.Name = "rbtnFileName"
Me.rbtnFileName.Size = New System.Drawing.Size(145, 21)
Me.rbtnFileName.TabIndex = 0
Me.rbtnFileName.TabStop = True
Me.rbtnFileName.Text = "Enter image name:"
Me.rbtnFileName.UseVisualStyleBackColor = True
'
'tbtnEnumerate
'
Me.tbtnEnumerate.AutoSize = True
Me.tbtnEnumerate.Location = New System.Drawing.Point(12, 80)
Me.tbtnEnumerate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.tbtnEnumerate.Name = "tbtnEnumerate"
Me.tbtnEnumerate.Size = New System.Drawing.Size(327, 21)
Me.tbtnEnumerate.TabIndex = 2
Me.tbtnEnumerate.TabStop = True
Me.tbtnEnumerate.Text = "Enumerate images from LEAD JPIP Server Demo"
Me.tbtnEnumerate.UseVisualStyleBackColor = True
'
'txtFileName
'
Me.txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.txtFileName.Location = New System.Drawing.Point(30, 39)
Me.txtFileName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtFileName.Name = "txtFileName"
Me.txtFileName.Size = New System.Drawing.Size(485, 24)
Me.txtFileName.TabIndex = 1
'
'pnlEnumerateService
'
Me.pnlEnumerateService.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.pnlEnumerateService.Controls.Add(Me.lstFiles)
Me.pnlEnumerateService.Enabled = False
Me.pnlEnumerateService.Location = New System.Drawing.Point(30, 106)
Me.pnlEnumerateService.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.pnlEnumerateService.Name = "pnlEnumerateService"
Me.pnlEnumerateService.Size = New System.Drawing.Size(486, 314)
Me.pnlEnumerateService.TabIndex = 3
'
'lstFiles
'
Me.lstFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.lstFiles.FormattingEnabled = True
Me.lstFiles.ItemHeight = 16
Me.lstFiles.Location = New System.Drawing.Point(5, 3)
Me.lstFiles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.lstFiles.Name = "lstFiles"
Me.lstFiles.Size = New System.Drawing.Size(472, 308)
Me.lstFiles.TabIndex = 5
'
'btnGetFiles
'
Me.btnGetFiles.Enabled = False
Me.btnGetFiles.Location = New System.Drawing.Point(339, 79)
Me.btnGetFiles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.btnGetFiles.Name = "btnGetFiles"
Me.btnGetFiles.Size = New System.Drawing.Size(77, 25)
Me.btnGetFiles.TabIndex = 4
Me.btnGetFiles.Text = "Get Files"
Me.btnGetFiles.UseVisualStyleBackColor = True
'
'grpSepa
'
Me.grpSepa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.grpSepa.Location = New System.Drawing.Point(-36, 425)
Me.grpSepa.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.grpSepa.Name = "grpSepa"
Me.grpSepa.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.grpSepa.Size = New System.Drawing.Size(567, 2)
Me.grpSepa.TabIndex = 4
Me.grpSepa.TabStop = False
'
'btnOK
'
Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
Me.btnOK.Enabled = False
Me.btnOK.Location = New System.Drawing.Point(341, 434)
Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.btnOK.Name = "btnOK"
Me.btnOK.Size = New System.Drawing.Size(75, 30)
Me.btnOK.TabIndex = 4
Me.btnOK.Text = "OK"
Me.btnOK.UseVisualStyleBackColor = True
'
'btnCancel
'
Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.btnCancel.Location = New System.Drawing.Point(421, 434)
Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.btnCancel.Name = "btnCancel"
Me.btnCancel.Size = New System.Drawing.Size(75, 30)
Me.btnCancel.TabIndex = 5
Me.btnCancel.Text = "Cancel"
Me.btnCancel.UseVisualStyleBackColor = True
'
'FileOpenDialog
'
Me.AcceptButton = Me.btnOK
Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.CancelButton = Me.btnCancel
Me.ClientSize = New System.Drawing.Size(521, 469)
Me.Controls.Add(Me.btnOK)
Me.Controls.Add(Me.btnGetFiles)
Me.Controls.Add(Me.btnCancel)
Me.Controls.Add(Me.grpSepa)
Me.Controls.Add(Me.pnlEnumerateService)
Me.Controls.Add(Me.txtFileName)
Me.Controls.Add(Me.tbtnEnumerate)
Me.Controls.Add(Me.rbtnFileName)
Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.MinimizeBox = False
Me.Name = "FileOpenDialog"
Me.ShowIcon = False
Me.ShowInTaskbar = False
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "File Open"
Me.pnlEnumerateService.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

      Private WithEvents rbtnFileName As System.Windows.Forms.RadioButton
      Private tbtnEnumerate As System.Windows.Forms.RadioButton
      Private WithEvents txtFileName As System.Windows.Forms.TextBox
      Private pnlEnumerateService As System.Windows.Forms.Panel
      Private WithEvents btnGetFiles As System.Windows.Forms.Button
      Private WithEvents lstFiles As System.Windows.Forms.ListBox
      Private grpSepa As System.Windows.Forms.GroupBox
      Private WithEvents btnOK As System.Windows.Forms.Button
      Private btnCancel As System.Windows.Forms.Button
   End Class
