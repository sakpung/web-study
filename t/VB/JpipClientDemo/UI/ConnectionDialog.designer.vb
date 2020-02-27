Imports Microsoft.VisualBasic
Imports System

   Partial Public Class ConnectionDialog
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
Me.btnCancel = New System.Windows.Forms.Button
Me.btnOK = New System.Windows.Forms.Button
Me.label2 = New System.Windows.Forms.Label
Me.textCacheDirectoryName = New System.Windows.Forms.TextBox
Me.label5 = New System.Windows.Forms.Label
Me.label4 = New System.Windows.Forms.Label
Me.label3 = New System.Windows.Forms.Label
Me.groupBox1 = New System.Windows.Forms.GroupBox
Me.textPortNumber = New System.Windows.Forms.MaskedTextBox
Me.textPacketSize = New System.Windows.Forms.MaskedTextBox
Me.lblConnection = New System.Windows.Forms.Label
Me.cmbConnectionType = New System.Windows.Forms.ComboBox
Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
Me.OpenFolderDialogButton = New System.Windows.Forms.Button
Me.label7 = New System.Windows.Forms.Label
Me.textRequestTimeout = New System.Windows.Forms.MaskedTextBox
Me.btnDefault = New System.Windows.Forms.Button
Me.cmbIpAddress = New System.Windows.Forms.ComboBox
Me.txtEnumerationServicePort = New System.Windows.Forms.MaskedTextBox
Me.label1 = New System.Windows.Forms.Label
Me.chkRequestTimeout = New System.Windows.Forms.CheckBox
Me.lblNote = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'btnCancel
'
Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.btnCancel.Location = New System.Drawing.Point(339, 321)
Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
Me.btnCancel.Name = "btnCancel"
Me.btnCancel.Size = New System.Drawing.Size(87, 28)
Me.btnCancel.TabIndex = 17
Me.btnCancel.Text = "Cancel"
'
'btnOK
'
Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
Me.btnOK.Location = New System.Drawing.Point(244, 321)
Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
Me.btnOK.Name = "btnOK"
Me.btnOK.Size = New System.Drawing.Size(87, 28)
Me.btnOK.TabIndex = 16
Me.btnOK.Text = "OK"
'
'label2
'
Me.label2.AutoSize = True
Me.label2.Location = New System.Drawing.Point(5, 17)
Me.label2.Name = "label2"
Me.label2.Size = New System.Drawing.Size(151, 17)
Me.label2.TabIndex = 0
Me.label2.Text = "Cache Directory Name:"
'
'textCacheDirectoryName
'
Me.textCacheDirectoryName.Location = New System.Drawing.Point(171, 17)
Me.textCacheDirectoryName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
Me.textCacheDirectoryName.Name = "textCacheDirectoryName"
Me.textCacheDirectoryName.Size = New System.Drawing.Size(223, 24)
Me.textCacheDirectoryName.TabIndex = 1
'
'label5
'
Me.label5.AutoSize = True
Me.label5.Location = New System.Drawing.Point(5, 182)
Me.label5.Name = "label5"
Me.label5.Size = New System.Drawing.Size(122, 17)
Me.label5.TabIndex = 11
Me.label5.Text = "Packet Size / byte:"
'
'label4
'
Me.label4.AutoSize = True
Me.label4.Location = New System.Drawing.Point(5, 82)
Me.label4.Name = "label4"
Me.label4.Size = New System.Drawing.Size(92, 17)
Me.label4.TabIndex = 5
Me.label4.Text = "Port Number:"
'
'label3
'
Me.label3.AutoSize = True
Me.label3.Location = New System.Drawing.Point(5, 50)
Me.label3.Name = "label3"
Me.label3.Size = New System.Drawing.Size(77, 17)
Me.label3.TabIndex = 3
Me.label3.Text = "IP Address:"
'
'groupBox1
'
Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.groupBox1.Location = New System.Drawing.Point(-27, 290)
Me.groupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.groupBox1.Name = "groupBox1"
Me.groupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.groupBox1.Size = New System.Drawing.Size(467, 2)
Me.groupBox1.TabIndex = 17
Me.groupBox1.TabStop = False
'
'textPortNumber
'
Me.textPortNumber.HidePromptOnLeave = True
Me.textPortNumber.Location = New System.Drawing.Point(171, 82)
Me.textPortNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.textPortNumber.Mask = "00000"
Me.textPortNumber.Name = "textPortNumber"
Me.textPortNumber.Size = New System.Drawing.Size(100, 24)
Me.textPortNumber.TabIndex = 6
'
'textPacketSize
'
Me.textPacketSize.Location = New System.Drawing.Point(171, 182)
Me.textPacketSize.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.textPacketSize.Mask = "00000"
Me.textPacketSize.Name = "textPacketSize"
Me.textPacketSize.Size = New System.Drawing.Size(100, 24)
Me.textPacketSize.TabIndex = 12
Me.textPacketSize.ValidatingType = GetType(Integer)
'
'lblConnection
'
Me.lblConnection.AutoSize = True
Me.lblConnection.Location = New System.Drawing.Point(5, 150)
Me.lblConnection.Name = "lblConnection"
Me.lblConnection.Size = New System.Drawing.Size(83, 17)
Me.lblConnection.TabIndex = 9
Me.lblConnection.Text = "Connection:"
'
'cmbConnectionType
'
Me.cmbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cmbConnectionType.FormattingEnabled = True
Me.cmbConnectionType.Location = New System.Drawing.Point(171, 150)
Me.cmbConnectionType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.cmbConnectionType.Name = "cmbConnectionType"
Me.cmbConnectionType.Size = New System.Drawing.Size(121, 24)
Me.cmbConnectionType.TabIndex = 10
'
'OpenFolderDialogButton
'
Me.OpenFolderDialogButton.Location = New System.Drawing.Point(398, 16)
Me.OpenFolderDialogButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
Me.OpenFolderDialogButton.Name = "OpenFolderDialogButton"
Me.OpenFolderDialogButton.Size = New System.Drawing.Size(28, 26)
Me.OpenFolderDialogButton.TabIndex = 2
Me.OpenFolderDialogButton.Text = "..."
Me.OpenFolderDialogButton.UseVisualStyleBackColor = True
'
'label7
'
Me.label7.AutoSize = True
Me.label7.Location = New System.Drawing.Point(5, 212)
Me.label7.Name = "label7"
Me.label7.Size = New System.Drawing.Size(150, 17)
Me.label7.TabIndex = 13
Me.label7.Text = "Request Timeout / sec:"
'
'textRequestTimeout
'
Me.textRequestTimeout.Location = New System.Drawing.Point(171, 212)
Me.textRequestTimeout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.textRequestTimeout.Mask = "0000000"
Me.textRequestTimeout.Name = "textRequestTimeout"
Me.textRequestTimeout.Size = New System.Drawing.Size(100, 24)
Me.textRequestTimeout.TabIndex = 14
Me.textRequestTimeout.ValidatingType = GetType(Integer)
'
'btnDefault
'
Me.btnDefault.Location = New System.Drawing.Point(339, 254)
Me.btnDefault.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
Me.btnDefault.Name = "btnDefault"
Me.btnDefault.Size = New System.Drawing.Size(87, 28)
Me.btnDefault.TabIndex = 15
Me.btnDefault.Text = "&Default"
Me.btnDefault.UseVisualStyleBackColor = True
'
'cmbIpAddress
'
Me.cmbIpAddress.FormattingEnabled = True
Me.cmbIpAddress.Location = New System.Drawing.Point(171, 48)
Me.cmbIpAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.cmbIpAddress.Name = "cmbIpAddress"
Me.cmbIpAddress.Size = New System.Drawing.Size(255, 24)
Me.cmbIpAddress.TabIndex = 4
'
'txtEnumerationServicePort
'
Me.txtEnumerationServicePort.HidePromptOnLeave = True
Me.txtEnumerationServicePort.Location = New System.Drawing.Point(171, 117)
Me.txtEnumerationServicePort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtEnumerationServicePort.Mask = "00000"
Me.txtEnumerationServicePort.Name = "txtEnumerationServicePort"
Me.txtEnumerationServicePort.Size = New System.Drawing.Size(100, 24)
Me.txtEnumerationServicePort.TabIndex = 8
'
'label1
'
Me.label1.AutoSize = True
Me.label1.Location = New System.Drawing.Point(5, 117)
Me.label1.Name = "label1"
Me.label1.Size = New System.Drawing.Size(169, 17)
Me.label1.TabIndex = 7
Me.label1.Text = "Enumeration Service Port:"
'
'chkRequestTimeout
'
Me.chkRequestTimeout.AutoSize = True
Me.chkRequestTimeout.Location = New System.Drawing.Point(277, 214)
Me.chkRequestTimeout.Name = "chkRequestTimeout"
Me.chkRequestTimeout.Size = New System.Drawing.Size(85, 21)
Me.chkRequestTimeout.TabIndex = 18
Me.chkRequestTimeout.Text = "&Unlimited"
Me.chkRequestTimeout.UseVisualStyleBackColor = True
'
'lblNote
'
Me.lblNote.AutoSize = True
Me.lblNote.ForeColor = System.Drawing.Color.Blue
Me.lblNote.Location = New System.Drawing.Point(5, 297)
Me.lblNote.Name = "lblNote"
Me.lblNote.Size = New System.Drawing.Size(384, 17)
Me.lblNote.TabIndex = 19
Me.lblNote.Text = "*Make sure the server is running before making a connection."
'
'ConnectionDialog
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(432, 355)
Me.Controls.Add(Me.lblNote)
Me.Controls.Add(Me.chkRequestTimeout)
Me.Controls.Add(Me.txtEnumerationServicePort)
Me.Controls.Add(Me.label1)
Me.Controls.Add(Me.cmbIpAddress)
Me.Controls.Add(Me.btnDefault)
Me.Controls.Add(Me.textRequestTimeout)
Me.Controls.Add(Me.label7)
Me.Controls.Add(Me.OpenFolderDialogButton)
Me.Controls.Add(Me.cmbConnectionType)
Me.Controls.Add(Me.lblConnection)
Me.Controls.Add(Me.textPacketSize)
Me.Controls.Add(Me.textPortNumber)
Me.Controls.Add(Me.groupBox1)
Me.Controls.Add(Me.textCacheDirectoryName)
Me.Controls.Add(Me.label4)
Me.Controls.Add(Me.label3)
Me.Controls.Add(Me.label5)
Me.Controls.Add(Me.label2)
Me.Controls.Add(Me.btnOK)
Me.Controls.Add(Me.btnCancel)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "ConnectionDialog"
Me.ShowInTaskbar = False
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Configuration"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

        Private btnCancel As System.Windows.Forms.Button
       Private WithEvents btnOK As System.Windows.Forms.Button
       Private label2 As System.Windows.Forms.Label
       Private textCacheDirectoryName As System.Windows.Forms.TextBox
      Private label5 As System.Windows.Forms.Label
       Private label4 As System.Windows.Forms.Label
       Private label3 As System.Windows.Forms.Label
       Private groupBox1 As System.Windows.Forms.GroupBox
       Private textPortNumber As System.Windows.Forms.MaskedTextBox
       Private textPacketSize As System.Windows.Forms.MaskedTextBox
       Private lblConnection As System.Windows.Forms.Label
       Private cmbConnectionType As System.Windows.Forms.ComboBox
       Private folderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
       Private WithEvents OpenFolderDialogButton As System.Windows.Forms.Button
       Private label7 As System.Windows.Forms.Label
       Private textRequestTimeout As System.Windows.Forms.MaskedTextBox
      Private WithEvents btnDefault As System.Windows.Forms.Button
      Friend WithEvents cmbIpAddress As System.Windows.Forms.ComboBox
      Private WithEvents txtEnumerationServicePort As System.Windows.Forms.MaskedTextBox
      Private WithEvents label1 As System.Windows.Forms.Label
      Friend WithEvents chkRequestTimeout As System.Windows.Forms.CheckBox
      Friend WithEvents lblNote As System.Windows.Forms.Label
   End Class
