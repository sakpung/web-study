Imports Microsoft.VisualBasic
Imports System

   Partial Public Class ResponseHandling
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
Me.label1 = New System.Windows.Forms.Label
Me.mtxtIpAddress = New System.Windows.Forms.MaskedTextBox
Me.btnAdd = New System.Windows.Forms.Button
Me.btnRemove = New System.Windows.Forms.Button
Me.lstAddresses = New System.Windows.Forms.ListBox
Me.btnOK = New System.Windows.Forms.Button
Me.btnCancel = New System.Windows.Forms.Button
Me.groupBox1 = New System.Windows.Forms.GroupBox
Me.txtDumpdataFolder = New System.Windows.Forms.TextBox
Me.btnBrowse = New System.Windows.Forms.Button
Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
Me.label2 = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'label1
'
Me.label1.AutoSize = True
Me.label1.Location = New System.Drawing.Point(6, 71)
Me.label1.Name = "label1"
Me.label1.Size = New System.Drawing.Size(392, 17)
Me.label1.TabIndex = 3
Me.label1.Text = "Dump response data for clients with the following IP addresses:"
'
'mtxtIpAddress
'
Me.mtxtIpAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.mtxtIpAddress.Location = New System.Drawing.Point(6, 91)
Me.mtxtIpAddress.Name = "mtxtIpAddress"
Me.mtxtIpAddress.Size = New System.Drawing.Size(154, 24)
Me.mtxtIpAddress.TabIndex = 4
'
'btnAdd
'
Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnAdd.Location = New System.Drawing.Point(166, 88)
Me.btnAdd.Name = "btnAdd"
Me.btnAdd.Size = New System.Drawing.Size(80, 27)
Me.btnAdd.TabIndex = 5
Me.btnAdd.Text = "Add"
Me.btnAdd.UseVisualStyleBackColor = True
'
'btnRemove
'
Me.btnRemove.Location = New System.Drawing.Point(6, 131)
Me.btnRemove.Name = "btnRemove"
Me.btnRemove.Size = New System.Drawing.Size(80, 27)
Me.btnRemove.TabIndex = 6
Me.btnRemove.Text = "Remove"
Me.btnRemove.UseVisualStyleBackColor = True
'
'lstAddresses
'
Me.lstAddresses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.lstAddresses.FormattingEnabled = True
Me.lstAddresses.ItemHeight = 16
Me.lstAddresses.Location = New System.Drawing.Point(96, 131)
Me.lstAddresses.Name = "lstAddresses"
Me.lstAddresses.Size = New System.Drawing.Size(309, 212)
Me.lstAddresses.TabIndex = 7
'
'btnOK
'
Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
Me.btnOK.Location = New System.Drawing.Point(246, 364)
Me.btnOK.Name = "btnOK"
Me.btnOK.Size = New System.Drawing.Size(80, 27)
Me.btnOK.TabIndex = 8
Me.btnOK.Text = "OK"
Me.btnOK.UseVisualStyleBackColor = True
'
'btnCancel
'
Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.btnCancel.Location = New System.Drawing.Point(330, 364)
Me.btnCancel.Name = "btnCancel"
Me.btnCancel.Size = New System.Drawing.Size(80, 27)
Me.btnCancel.TabIndex = 9
Me.btnCancel.Text = "Cancel"
Me.btnCancel.UseVisualStyleBackColor = True
'
'groupBox1
'
Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.groupBox1.Location = New System.Drawing.Point(-26, 354)
Me.groupBox1.Name = "groupBox1"
Me.groupBox1.Size = New System.Drawing.Size(451, 3)
Me.groupBox1.TabIndex = 7
Me.groupBox1.TabStop = False
'
'txtDumpdataFolder
'
Me.txtDumpdataFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.txtDumpdataFolder.Location = New System.Drawing.Point(9, 41)
Me.txtDumpdataFolder.Name = "txtDumpdataFolder"
Me.txtDumpdataFolder.Size = New System.Drawing.Size(301, 24)
Me.txtDumpdataFolder.TabIndex = 1
'
'btnBrowse
'
Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnBrowse.Location = New System.Drawing.Point(316, 41)
Me.btnBrowse.Name = "btnBrowse"
Me.btnBrowse.Size = New System.Drawing.Size(77, 25)
Me.btnBrowse.TabIndex = 2
Me.btnBrowse.Text = "Browse..."
Me.btnBrowse.UseVisualStyleBackColor = True
'
'label2
'
Me.label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.label2.Location = New System.Drawing.Point(3, 3)
Me.label2.Name = "label2"
Me.label2.Size = New System.Drawing.Size(396, 34)
Me.label2.TabIndex = 0
Me.label2.Text = "Dump response data to the following directory, subdirectories will be created for" & _
    " each client IP address:"
'
'ResponseHandling
'
Me.AcceptButton = Me.btnOK
Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.CancelButton = Me.btnCancel
Me.ClientSize = New System.Drawing.Size(417, 398)
Me.Controls.Add(Me.label2)
Me.Controls.Add(Me.btnBrowse)
Me.Controls.Add(Me.txtDumpdataFolder)
Me.Controls.Add(Me.groupBox1)
Me.Controls.Add(Me.btnCancel)
Me.Controls.Add(Me.btnOK)
Me.Controls.Add(Me.lstAddresses)
Me.Controls.Add(Me.btnRemove)
Me.Controls.Add(Me.btnAdd)
Me.Controls.Add(Me.mtxtIpAddress)
Me.Controls.Add(Me.label1)
Me.MinimizeBox = False
Me.Name = "ResponseHandling"
Me.ShowIcon = False
Me.ShowInTaskbar = False
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Response Handling"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

      Private label1 As System.Windows.Forms.Label
      Private mtxtIpAddress As System.Windows.Forms.MaskedTextBox
      Private WithEvents btnAdd As System.Windows.Forms.Button
      Private WithEvents btnRemove As System.Windows.Forms.Button
      Private lstAddresses As System.Windows.Forms.ListBox
      Private WithEvents btnOK As System.Windows.Forms.Button
      Private btnCancel As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private txtDumpdataFolder As System.Windows.Forms.TextBox
      Private WithEvents btnBrowse As System.Windows.Forms.Button
      Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
      Private label2 As System.Windows.Forms.Label
   End Class
