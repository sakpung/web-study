Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
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
            Me.components = New System.ComponentModel.Container()
            Me.AETitleTextBox = New System.Windows.Forms.TextBox()
            Me.AeTitleLabel = New System.Windows.Forms.Label()
            Me.HostNameTextBox = New System.Windows.Forms.TextBox()
            Me.PortLabel = New System.Windows.Forms.Label()
            Me.PortNumericUpDown = New System.Windows.Forms.NumericUpDown()
            Me.SecurePortNumericUpDown = New System.Windows.Forms.NumericUpDown()
            Me.SecurePortLabel = New System.Windows.Forms.Label()
            Me.OkButton = New System.Windows.Forms.Button()
            Me.CancelDialogButton = New System.Windows.Forms.Button()
            Me.AeErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.label1 = New System.Windows.Forms.Label()
            Me.pictureBoxSecurePort = New System.Windows.Forms.PictureBox()
            Me.pictureBoxUnsecurePort = New System.Windows.Forms.PictureBox()
            Me.PortUsageLabel = New System.Windows.Forms.Label()
            Me.comboBoxClientPortSelection = New System.Windows.Forms.ComboBox()
            CType(Me.PortNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SecurePortNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AeErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pictureBoxSecurePort, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pictureBoxUnsecurePort, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'AETitleTextBox
            '
            Me.AETitleTextBox.Location = New System.Drawing.Point(107, 12)
            Me.AETitleTextBox.Name = "AETitleTextBox"
            Me.AETitleTextBox.Size = New System.Drawing.Size(191, 20)
            Me.AETitleTextBox.TabIndex = 1
            '
            'AeTitleLabel
            '
            Me.AeTitleLabel.AutoSize = True
            Me.AeTitleLabel.Location = New System.Drawing.Point(12, 16)
            Me.AeTitleLabel.Name = "AeTitleLabel"
            Me.AeTitleLabel.Size = New System.Drawing.Size(47, 13)
            Me.AeTitleLabel.TabIndex = 0
            Me.AeTitleLabel.Text = "AE Title:"
            '
            'HostNameTextBox
            '
            Me.HostNameTextBox.Location = New System.Drawing.Point(107, 38)
            Me.HostNameTextBox.Name = "HostNameTextBox"
            Me.HostNameTextBox.Size = New System.Drawing.Size(191, 20)
            Me.HostNameTextBox.TabIndex = 3
            '
            'PortLabel
            '
            Me.PortLabel.AutoSize = True
            Me.PortLabel.Location = New System.Drawing.Point(12, 68)
            Me.PortLabel.Name = "PortLabel"
            Me.PortLabel.Size = New System.Drawing.Size(29, 13)
            Me.PortLabel.TabIndex = 6
            Me.PortLabel.Text = "Port:"
            '
            'PortNumericUpDown
            '
            Me.PortNumericUpDown.Location = New System.Drawing.Point(107, 64)
            Me.PortNumericUpDown.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
            Me.PortNumericUpDown.Name = "PortNumericUpDown"
            Me.PortNumericUpDown.Size = New System.Drawing.Size(109, 20)
            Me.PortNumericUpDown.TabIndex = 7
            '
            'SecurePortNumericUpDown
            '
            Me.SecurePortNumericUpDown.Location = New System.Drawing.Point(107, 90)
            Me.SecurePortNumericUpDown.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
            Me.SecurePortNumericUpDown.Name = "SecurePortNumericUpDown"
            Me.SecurePortNumericUpDown.Size = New System.Drawing.Size(109, 20)
            Me.SecurePortNumericUpDown.TabIndex = 9
            '
            'SecurePortLabel
            '
            Me.SecurePortLabel.AutoSize = True
            Me.SecurePortLabel.Location = New System.Drawing.Point(12, 94)
            Me.SecurePortLabel.Name = "SecurePortLabel"
            Me.SecurePortLabel.Size = New System.Drawing.Size(66, 13)
            Me.SecurePortLabel.TabIndex = 8
            Me.SecurePortLabel.Text = "Secure Port:"
            '
            'OkButton
            '
            Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.OkButton.Location = New System.Drawing.Point(141, 157)
            Me.OkButton.Name = "OkButton"
            Me.OkButton.Size = New System.Drawing.Size(75, 23)
            Me.OkButton.TabIndex = 10
            Me.OkButton.Text = "OK"
            Me.OkButton.UseVisualStyleBackColor = True
            '
            'CancelDialogButton
            '
            Me.CancelDialogButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CancelDialogButton.CausesValidation = False
            Me.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.CancelDialogButton.Location = New System.Drawing.Point(222, 157)
            Me.CancelDialogButton.Name = "CancelDialogButton"
            Me.CancelDialogButton.Size = New System.Drawing.Size(75, 23)
            Me.CancelDialogButton.TabIndex = 11
            Me.CancelDialogButton.Text = "Cancel"
            Me.CancelDialogButton.UseVisualStyleBackColor = True
            '
            'AeErrorProvider
            '
            Me.AeErrorProvider.ContainerControl = Me
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(12, 42)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(88, 13)
            Me.label1.TabIndex = 12
            Me.label1.Text = "Host/IP Address:"
            '
            'pictureBoxSecurePort
            '
            Me.pictureBoxSecurePort.Image = Global.Resources.Tick
            Me.pictureBoxSecurePort.Location = New System.Drawing.Point(222, 90)
            Me.pictureBoxSecurePort.Name = "pictureBoxSecurePort"
            Me.pictureBoxSecurePort.Size = New System.Drawing.Size(20, 20)
            Me.pictureBoxSecurePort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.pictureBoxSecurePort.TabIndex = 20
            Me.pictureBoxSecurePort.TabStop = False
            '
            'pictureBoxUnsecurePort
            '
            Me.pictureBoxUnsecurePort.Image = Global.Resources.Tick
            Me.pictureBoxUnsecurePort.Location = New System.Drawing.Point(222, 64)
            Me.pictureBoxUnsecurePort.Name = "pictureBoxUnsecurePort"
            Me.pictureBoxUnsecurePort.Size = New System.Drawing.Size(20, 20)
            Me.pictureBoxUnsecurePort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.pictureBoxUnsecurePort.TabIndex = 19
            Me.pictureBoxUnsecurePort.TabStop = False
            '
            'PortUsageLabel
            '
            Me.PortUsageLabel.AutoSize = True
            Me.PortUsageLabel.Location = New System.Drawing.Point(12, 120)
            Me.PortUsageLabel.Name = "PortUsageLabel"
            Me.PortUsageLabel.Size = New System.Drawing.Size(63, 13)
            Me.PortUsageLabel.TabIndex = 18
            Me.PortUsageLabel.Text = "Port Usage:"
            '
            'comboBoxClientPortSelection
            '
            Me.comboBoxClientPortSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.comboBoxClientPortSelection.FormattingEnabled = True
            Me.comboBoxClientPortSelection.Location = New System.Drawing.Point(107, 116)
            Me.comboBoxClientPortSelection.Name = "comboBoxClientPortSelection"
            Me.comboBoxClientPortSelection.Size = New System.Drawing.Size(109, 21)
            Me.comboBoxClientPortSelection.TabIndex = 17
            '
            'EditAeTitleDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.CancelDialogButton
            Me.ClientSize = New System.Drawing.Size(304, 185)
            Me.Controls.Add(Me.pictureBoxSecurePort)
            Me.Controls.Add(Me.pictureBoxUnsecurePort)
            Me.Controls.Add(Me.PortUsageLabel)
            Me.Controls.Add(Me.comboBoxClientPortSelection)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.CancelDialogButton)
            Me.Controls.Add(Me.OkButton)
            Me.Controls.Add(Me.SecurePortNumericUpDown)
            Me.Controls.Add(Me.SecurePortLabel)
            Me.Controls.Add(Me.PortNumericUpDown)
            Me.Controls.Add(Me.PortLabel)
            Me.Controls.Add(Me.HostNameTextBox)
            Me.Controls.Add(Me.AETitleTextBox)
            Me.Controls.Add(Me.AeTitleLabel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "EditAeTitleDialog"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "EditAeTitleDialog"
            CType(Me.PortNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SecurePortNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AeErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pictureBoxSecurePort, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pictureBoxUnsecurePort, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Protected WithEvents AETitleTextBox As System.Windows.Forms.TextBox
		Protected AeTitleLabel As System.Windows.Forms.Label
		Protected HostNameTextBox As System.Windows.Forms.TextBox
		Protected PortLabel As System.Windows.Forms.Label
		Protected PortNumericUpDown As System.Windows.Forms.NumericUpDown
		Protected SecurePortNumericUpDown As System.Windows.Forms.NumericUpDown
		Protected SecurePortLabel As System.Windows.Forms.Label
		Protected OkButton As System.Windows.Forms.Button
		Protected CancelDialogButton As System.Windows.Forms.Button
		Protected AeErrorProvider As System.Windows.Forms.ErrorProvider
		Protected label1 As System.Windows.Forms.Label
        Private WithEvents pictureBoxSecurePort As Windows.Forms.PictureBox
        Private WithEvents pictureBoxUnsecurePort As Windows.Forms.PictureBox
        Protected WithEvents PortUsageLabel As Windows.Forms.Label
        Private WithEvents comboBoxClientPortSelection As Windows.Forms.ComboBox
    End Class
End Namespace