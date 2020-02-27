Namespace Leadtools.Dicom.Server.Manager.Dialogs
    Partial Public Class EditAeTitleDialog
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditAeTitleDialog))
            Me.AETitle = New System.Windows.Forms.TextBox
            Me.labelAeTitle = New System.Windows.Forms.Label
            Me.radioButtonHost = New System.Windows.Forms.RadioButton
            Me.radioButtonIp = New System.Windows.Forms.RadioButton
            Me.Hostname = New System.Windows.Forms.TextBox
            Me.textboxIPAddress = New System.Windows.Forms.TextBox
            Me.labelPort = New System.Windows.Forms.Label
            Me.Port = New System.Windows.Forms.NumericUpDown
            Me.SecurePort = New System.Windows.Forms.NumericUpDown
            Me.labelSecurePort = New System.Windows.Forms.Label
            Me.buttonOk = New System.Windows.Forms.Button
            Me.buttonCancel = New System.Windows.Forms.Button
            CType(Me.Port, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SecurePort, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'AETitle
            '
            Me.AETitle.Location = New System.Drawing.Point(96, 12)
            Me.AETitle.Name = "AETitle"
            Me.AETitle.Size = New System.Drawing.Size(191, 20)
            Me.AETitle.TabIndex = 2
            '
            'labelAeTitle
            '
            Me.labelAeTitle.AutoSize = True
            Me.labelAeTitle.Location = New System.Drawing.Point(43, 16)
            Me.labelAeTitle.Name = "labelAeTitle"
            Me.labelAeTitle.Size = New System.Drawing.Size(47, 13)
            Me.labelAeTitle.TabIndex = 1
            Me.labelAeTitle.Text = "AE Title:"
            '
            'radioButtonHost
            '
            Me.radioButtonHost.AutoSize = True
            Me.radioButtonHost.Location = New System.Drawing.Point(12, 40)
            Me.radioButtonHost.Name = "radioButtonHost"
            Me.radioButtonHost.Size = New System.Drawing.Size(81, 17)
            Me.radioButtonHost.TabIndex = 3
            Me.radioButtonHost.TabStop = True
            Me.radioButtonHost.Text = "Host Name:"
            Me.radioButtonHost.UseVisualStyleBackColor = True
            '
            'radioButtonIp
            '
            Me.radioButtonIp.AutoSize = True
            Me.radioButtonIp.Location = New System.Drawing.Point(12, 66)
            Me.radioButtonIp.Name = "radioButtonIp"
            Me.radioButtonIp.Size = New System.Drawing.Size(79, 17)
            Me.radioButtonIp.TabIndex = 4
            Me.radioButtonIp.TabStop = True
            Me.radioButtonIp.Text = "IP Address:"
            Me.radioButtonIp.UseVisualStyleBackColor = True
            '
            'Hostname
            '
            Me.Hostname.Location = New System.Drawing.Point(96, 38)
            Me.Hostname.Name = "Hostname"
            Me.Hostname.Size = New System.Drawing.Size(191, 20)
            Me.Hostname.TabIndex = 5
            '
            'textboxIPAddress
            '
            Me.textboxIPAddress.Location = New System.Drawing.Point(96, 64)
            Me.textboxIPAddress.MaxLength = 15
            Me.textboxIPAddress.Name = "textboxIPAddress"
            Me.textboxIPAddress.Size = New System.Drawing.Size(191, 20)
            Me.textboxIPAddress.TabIndex = 6
            '
            'labelPort
            '
            Me.labelPort.AutoSize = True
            Me.labelPort.Location = New System.Drawing.Point(61, 94)
            Me.labelPort.Name = "labelPort"
            Me.labelPort.Size = New System.Drawing.Size(29, 13)
            Me.labelPort.TabIndex = 7
            Me.labelPort.Text = "Port:"
            '
            'Port
            '
            Me.Port.Location = New System.Drawing.Point(96, 90)
            Me.Port.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
            Me.Port.Name = "Port"
            Me.Port.Size = New System.Drawing.Size(54, 20)
            Me.Port.TabIndex = 8
            '
            'SecurePort
            '
            Me.SecurePort.Location = New System.Drawing.Point(233, 90)
            Me.SecurePort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
            Me.SecurePort.Name = "SecurePort"
            Me.SecurePort.Size = New System.Drawing.Size(54, 20)
            Me.SecurePort.TabIndex = 10
            '
            'labelSecurePort
            '
            Me.labelSecurePort.AutoSize = True
            Me.labelSecurePort.Location = New System.Drawing.Point(161, 94)
            Me.labelSecurePort.Name = "labelSecurePort"
            Me.labelSecurePort.Size = New System.Drawing.Size(66, 13)
            Me.labelSecurePort.TabIndex = 9
            Me.labelSecurePort.Text = "Secure Port:"
            '
            'buttonOk
            '
            Me.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.buttonOk.Location = New System.Drawing.Point(131, 137)
            Me.buttonOk.Name = "buttonOk"
            Me.buttonOk.Size = New System.Drawing.Size(75, 23)
            Me.buttonOk.TabIndex = 11
            Me.buttonOk.Text = "OK"
            Me.buttonOk.UseVisualStyleBackColor = True
            '
            'buttonCancel
            '
            Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.buttonCancel.Location = New System.Drawing.Point(212, 137)
            Me.buttonCancel.Name = "buttonCancel"
            Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
            Me.buttonCancel.TabIndex = 12
            Me.buttonCancel.Text = "Cancel"
            Me.buttonCancel.UseVisualStyleBackColor = True
            '
            'EditAeTitleDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.buttonCancel
            Me.ClientSize = New System.Drawing.Size(304, 172)
            Me.Controls.Add(Me.buttonCancel)
            Me.Controls.Add(Me.buttonOk)
            Me.Controls.Add(Me.SecurePort)
            Me.Controls.Add(Me.labelSecurePort)
            Me.Controls.Add(Me.Port)
            Me.Controls.Add(Me.labelPort)
            Me.Controls.Add(Me.textboxIPAddress)
            Me.Controls.Add(Me.Hostname)
            Me.Controls.Add(Me.radioButtonIp)
            Me.Controls.Add(Me.radioButtonHost)
            Me.Controls.Add(Me.AETitle)
            Me.Controls.Add(Me.labelAeTitle)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "EditAeTitleDialog"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "EditAeTitleDialog"
            CType(Me.Port, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SecurePort, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private WithEvents AETitle As System.Windows.Forms.TextBox
        Private labelAeTitle As System.Windows.Forms.Label
        Private WithEvents radioButtonHost As System.Windows.Forms.RadioButton
        Private WithEvents radioButtonIp As System.Windows.Forms.RadioButton
        Private WithEvents Hostname As System.Windows.Forms.TextBox
        Private labelPort As System.Windows.Forms.Label
        Private Port As System.Windows.Forms.NumericUpDown
        Private SecurePort As System.Windows.Forms.NumericUpDown
        Private labelSecurePort As System.Windows.Forms.Label
        Private buttonOk As System.Windows.Forms.Button
        Private buttonCancel As System.Windows.Forms.Button
        Private WithEvents textboxIPAddress As System.Windows.Forms.TextBox
    End Class
End Namespace