Namespace Leadtools.Demos.Workstation.Customized
   Partial Class ActionsEditorDialog
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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.MouseButtonsComboBox = New System.Windows.Forms.ComboBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me.ActionDisplayNameTextBox = New System.Windows.Forms.TextBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.ActionComboBox = New System.Windows.Forms.ComboBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.ToolStripButtonsGroupBox = New System.Windows.Forms.GroupBox()
         Me.BrowseButton = New System.Windows.Forms.Button()
         Me.FeautreIdTextBox = New System.Windows.Forms.TextBox()
         Me.label6 = New System.Windows.Forms.Label()
         Me.ImagePictureBox = New System.Windows.Forms.PictureBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me.AddActionButton = New System.Windows.Forms.Button()
         Me.RemoveActionButton = New System.Windows.Forms.Button()
         Me.CloseButton = New System.Windows.Forms.Button()
         Me.AlternativeImageButton = New System.Windows.Forms.Button()
         Me.AltImagePictureBox = New System.Windows.Forms.PictureBox()
         Me.label4 = New System.Windows.Forms.Label()
         Me.errorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
         Me.groupBox1.SuspendLayout()
         Me.ToolStripButtonsGroupBox.SuspendLayout()
         CType(Me.ImagePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.AltImagePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.groupBox1.Controls.Add(Me.MouseButtonsComboBox)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me.ActionDisplayNameTextBox)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.ActionComboBox)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(12, 12)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(291, 113)
         Me.groupBox1.TabIndex = 8
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Action"
         ' 
         ' MouseButtonsComboBox
         ' 
         Me.MouseButtonsComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.MouseButtonsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.MouseButtonsComboBox.FormattingEnabled = True
         Me.MouseButtonsComboBox.Location = New System.Drawing.Point(89, 76)
         Me.MouseButtonsComboBox.Name = "MouseButtonsComboBox"
         Me.MouseButtonsComboBox.Size = New System.Drawing.Size(165, 21)
         Me.MouseButtonsComboBox.TabIndex = 15
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(9, 79)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(76, 13)
         Me.label3.TabIndex = 14
         Me.label3.Text = "Mouse Button:"
         ' 
         ' ActionDisplayNameTextBox
         ' 
         Me.ActionDisplayNameTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.ActionDisplayNameTextBox.Location = New System.Drawing.Point(89, 48)
         Me.ActionDisplayNameTextBox.Name = "ActionDisplayNameTextBox"
         Me.ActionDisplayNameTextBox.Size = New System.Drawing.Size(165, 20)
         Me.ActionDisplayNameTextBox.TabIndex = 13
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(9, 51)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(75, 13)
         Me.label2.TabIndex = 12
         Me.label2.Text = "Display Name:"
         ' 
         ' ActionComboBox
         ' 
         Me.ActionComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.ActionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.ActionComboBox.FormattingEnabled = True
         Me.ActionComboBox.Location = New System.Drawing.Point(89, 21)
         Me.ActionComboBox.Name = "ActionComboBox"
         Me.ActionComboBox.Size = New System.Drawing.Size(165, 21)
         Me.ActionComboBox.TabIndex = 9
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(10, 23)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(73, 13)
         Me.label1.TabIndex = 8
         Me.label1.Text = "Select Action:"
         ' 
         ' ToolStripButtonsGroupBox
         ' 
         Me.ToolStripButtonsGroupBox.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.ToolStripButtonsGroupBox.Controls.Add(Me.AlternativeImageButton)
         Me.ToolStripButtonsGroupBox.Controls.Add(Me.AltImagePictureBox)
         Me.ToolStripButtonsGroupBox.Controls.Add(Me.label4)
         Me.ToolStripButtonsGroupBox.Controls.Add(Me.BrowseButton)
         Me.ToolStripButtonsGroupBox.Controls.Add(Me.FeautreIdTextBox)
         Me.ToolStripButtonsGroupBox.Controls.Add(Me.label6)
         Me.ToolStripButtonsGroupBox.Controls.Add(Me.ImagePictureBox)
         Me.ToolStripButtonsGroupBox.Controls.Add(Me.label5)
         Me.ToolStripButtonsGroupBox.Location = New System.Drawing.Point(12, 131)
         Me.ToolStripButtonsGroupBox.Name = "ToolStripButtonsGroupBox"
         Me.ToolStripButtonsGroupBox.Size = New System.Drawing.Size(291, 203)
         Me.ToolStripButtonsGroupBox.TabIndex = 9
         Me.ToolStripButtonsGroupBox.TabStop = False
         Me.ToolStripButtonsGroupBox.Text = "ToolStrip Buttons:"
         ' 
         ' BrowseButton
         ' 
         Me.BrowseButton.Location = New System.Drawing.Point(179, 52)
         Me.BrowseButton.Name = "BrowseButton"
         Me.BrowseButton.Size = New System.Drawing.Size(75, 23)
         Me.BrowseButton.TabIndex = 19
         Me.BrowseButton.Text = "Browse..."
         Me.BrowseButton.UseVisualStyleBackColor = True
         ' 
         ' FeautreIdTextBox
         ' 
         Me.FeautreIdTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.FeautreIdTextBox.Location = New System.Drawing.Point(89, 22)
         Me.FeautreIdTextBox.Name = "FeautreIdTextBox"
         Me.FeautreIdTextBox.Size = New System.Drawing.Size(165, 20)
         Me.FeautreIdTextBox.TabIndex = 18
         ' 
         ' label6
         ' 
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(13, 25)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(60, 13)
         Me.label6.TabIndex = 17
         Me.label6.Text = "Feature ID:"
         ' 
         ' ImagePictureBox
         ' 
         Me.ImagePictureBox.Location = New System.Drawing.Point(108, 52)
         Me.ImagePictureBox.Name = "ImagePictureBox"
         Me.ImagePictureBox.Size = New System.Drawing.Size(64, 64)
         Me.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
         Me.ImagePictureBox.TabIndex = 16
         Me.ImagePictureBox.TabStop = False
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(13, 52)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(76, 13)
         Me.label5.TabIndex = 15
         Me.label5.Text = "Default Image:"
         ' 
         ' AddActionButton
         ' 
         Me.AddActionButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
         Me.AddActionButton.Location = New System.Drawing.Point(12, 341)
         Me.AddActionButton.Name = "AddActionButton"
         Me.AddActionButton.Size = New System.Drawing.Size(75, 23)
         Me.AddActionButton.TabIndex = 10
         Me.AddActionButton.Text = "Add"
         Me.AddActionButton.UseVisualStyleBackColor = True
         ' 
         ' RemoveActionButton
         ' 
         Me.RemoveActionButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
         Me.RemoveActionButton.Location = New System.Drawing.Point(91, 341)
         Me.RemoveActionButton.Name = "RemoveActionButton"
         Me.RemoveActionButton.Size = New System.Drawing.Size(75, 23)
         Me.RemoveActionButton.TabIndex = 11
         Me.RemoveActionButton.Text = "Remove"
         Me.RemoveActionButton.UseVisualStyleBackColor = True
         ' 
         ' CloseButton
         ' 
         Me.CloseButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.CloseButton.Location = New System.Drawing.Point(229, 341)
         Me.CloseButton.Name = "CloseButton"
         Me.CloseButton.Size = New System.Drawing.Size(75, 23)
         Me.CloseButton.TabIndex = 13
         Me.CloseButton.Text = "Close"
         Me.CloseButton.UseVisualStyleBackColor = True
         ' 
         ' AlternativeImageButton
         ' 
         Me.AlternativeImageButton.Location = New System.Drawing.Point(179, 125)
         Me.AlternativeImageButton.Name = "AlternativeImageButton"
         Me.AlternativeImageButton.Size = New System.Drawing.Size(75, 23)
         Me.AlternativeImageButton.TabIndex = 22
         Me.AlternativeImageButton.Text = "Browse..."
         Me.AlternativeImageButton.UseVisualStyleBackColor = True
         ' 
         ' AltImagePictureBox
         ' 
         Me.AltImagePictureBox.Location = New System.Drawing.Point(108, 125)
         Me.AltImagePictureBox.Name = "AltImagePictureBox"
         Me.AltImagePictureBox.Size = New System.Drawing.Size(64, 64)
         Me.AltImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
         Me.AltImagePictureBox.TabIndex = 21
         Me.AltImagePictureBox.TabStop = False
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(13, 125)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(92, 13)
         Me.label4.TabIndex = 20
         Me.label4.Text = "Alternative Image:"
         ' 
         ' errorProvider1
         ' 
         Me.errorProvider1.ContainerControl = Me
         ' 
         ' ActionsEditorDialog
         ' 
         Me.AcceptButton = Me.CloseButton
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(310, 375)
         Me.Controls.Add(Me.CloseButton)
         Me.Controls.Add(Me.RemoveActionButton)
         Me.Controls.Add(Me.AddActionButton)
         Me.Controls.Add(Me.ToolStripButtonsGroupBox)
         Me.Controls.Add(Me.groupBox1)
         Me.Name = "ActionsEditorDialog"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.Text = "Actions Editor Dialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ToolStripButtonsGroupBox.ResumeLayout(False)
         Me.ToolStripButtonsGroupBox.PerformLayout()
         CType(Me.ImagePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.AltImagePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private groupBox1 As System.Windows.Forms.GroupBox
      Private MouseButtonsComboBox As System.Windows.Forms.ComboBox
      Private label3 As System.Windows.Forms.Label
      Private ActionDisplayNameTextBox As System.Windows.Forms.TextBox
      Private label2 As System.Windows.Forms.Label
      Private ActionComboBox As System.Windows.Forms.ComboBox
      Private label1 As System.Windows.Forms.Label
      Private ToolStripButtonsGroupBox As System.Windows.Forms.GroupBox
      Private label5 As System.Windows.Forms.Label
      Private ImagePictureBox As System.Windows.Forms.PictureBox
      Private FeautreIdTextBox As System.Windows.Forms.TextBox
      Private label6 As System.Windows.Forms.Label
      Private AddActionButton As System.Windows.Forms.Button
      Private RemoveActionButton As System.Windows.Forms.Button
      Private CloseButton As System.Windows.Forms.Button
      Private BrowseButton As System.Windows.Forms.Button
      Private AlternativeImageButton As System.Windows.Forms.Button
      Private AltImagePictureBox As System.Windows.Forms.PictureBox
      Private label4 As System.Windows.Forms.Label
      Private errorProvider1 As System.Windows.Forms.ErrorProvider

   End Class
End Namespace