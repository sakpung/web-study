Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class AeInfoDetails
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
         Me.components = New System.ComponentModel.Container()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.AETitleTextBox = New System.Windows.Forms.TextBox()
         Me.SecureCheckBox = New System.Windows.Forms.CheckBox()
         Me.PortNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.RejectChangesButton = New System.Windows.Forms.Button()
         Me.ConfirmChangesButton = New System.Windows.Forms.Button()
         Me.IpAddressComboBox = New System.Windows.Forms.ComboBox()
         Me.errorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
         CType(Me.PortNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(12, 9)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(47, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "AE Title:"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(12, 41)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(48, 13)
         Me.label2.TabIndex = 2
         Me.label2.Text = "Address:"
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(12, 65)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(29, 13)
         Me.label3.TabIndex = 4
         Me.label3.Text = "Port:"
         ' 
         ' AETitleTextBox
         ' 
         Me.AETitleTextBox.Location = New System.Drawing.Point(66, 9)
         Me.AETitleTextBox.Name = "AETitleTextBox"
         Me.AETitleTextBox.Size = New System.Drawing.Size(163, 20)
         Me.AETitleTextBox.TabIndex = 1
         ' 
         ' SecureCheckBox
         ' 
         Me.SecureCheckBox.AutoSize = True
         Me.SecureCheckBox.Location = New System.Drawing.Point(169, 68)
         Me.SecureCheckBox.Name = "SecureCheckBox"
         Me.SecureCheckBox.Size = New System.Drawing.Size(60, 17)
         Me.SecureCheckBox.TabIndex = 6
         Me.SecureCheckBox.Text = "Secure"
         Me.SecureCheckBox.UseVisualStyleBackColor = True
         ' 
         ' PortNumericUpDown
         ' 
         Me.PortNumericUpDown.Location = New System.Drawing.Point(66, 65)
         Me.PortNumericUpDown.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
         Me.PortNumericUpDown.Name = "PortNumericUpDown"
         Me.PortNumericUpDown.Size = New System.Drawing.Size(64, 20)
         Me.PortNumericUpDown.TabIndex = 5
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.groupBox1.Location = New System.Drawing.Point(-34, 89)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(314, 3)
         Me.groupBox1.TabIndex = 8
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "groupBox1"
         ' 
         ' RejectChangesButton
         ' 
         Me.RejectChangesButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.RejectChangesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.RejectChangesButton.Location = New System.Drawing.Point(173, 98)
         Me.RejectChangesButton.Name = "RejectChangesButton"
         Me.RejectChangesButton.Size = New System.Drawing.Size(75, 23)
         Me.RejectChangesButton.TabIndex = 8
         Me.RejectChangesButton.Text = "Cancel"
         Me.RejectChangesButton.UseVisualStyleBackColor = True
         ' 
         ' ConfirmChangesButton
         ' 
         Me.ConfirmChangesButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.ConfirmChangesButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.ConfirmChangesButton.Location = New System.Drawing.Point(92, 98)
         Me.ConfirmChangesButton.Name = "ConfirmChangesButton"
         Me.ConfirmChangesButton.Size = New System.Drawing.Size(75, 23)
         Me.ConfirmChangesButton.TabIndex = 7
         Me.ConfirmChangesButton.Text = "OK"
         Me.ConfirmChangesButton.UseVisualStyleBackColor = True
         ' 
         ' IpAddressComboBox
         ' 
         Me.IpAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.IpAddressComboBox.FormattingEnabled = True
         Me.IpAddressComboBox.Location = New System.Drawing.Point(66, 38)
         Me.IpAddressComboBox.Name = "IpAddressComboBox"
         Me.IpAddressComboBox.Size = New System.Drawing.Size(163, 21)
         Me.IpAddressComboBox.TabIndex = 3
         ' 
         ' errorProvider1
         ' 
         Me.errorProvider1.ContainerControl = Me
         ' 
         ' AeInfoDetails
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(254, 130)
         Me.ControlBox = False
         Me.Controls.Add(Me.IpAddressComboBox)
         Me.Controls.Add(Me.ConfirmChangesButton)
         Me.Controls.Add(Me.RejectChangesButton)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me.PortNumericUpDown)
         Me.Controls.Add(Me.SecureCheckBox)
         Me.Controls.Add(Me.AETitleTextBox)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Name = "AeInfoDetails"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "AeInfoDetails"
         CType(Me.PortNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private AETitleTextBox As System.Windows.Forms.TextBox
      Private SecureCheckBox As System.Windows.Forms.CheckBox
      Private PortNumericUpDown As System.Windows.Forms.NumericUpDown
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private RejectChangesButton As System.Windows.Forms.Button
      Private ConfirmChangesButton As System.Windows.Forms.Button
      Private IpAddressComboBox As System.Windows.Forms.ComboBox
      Private errorProvider1 As System.Windows.Forms.ErrorProvider
   End Class
End Namespace