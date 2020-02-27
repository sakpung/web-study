Imports Microsoft.VisualBasic
Imports System
Namespace PDFFileDemo
   Public Partial Class SecurityOptionsControl
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

	  #Region "Component Designer generated code"

	  ''' <summary> 
	  ''' Required method for Designer support - do not modify 
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
		 Me._securityOptionsGroupBox = New System.Windows.Forms.GroupBox()
		 Me._ecnryptionModeComboBox = New System.Windows.Forms.ComboBox()
		 Me._encryptionModeLabel = New System.Windows.Forms.Label()
		 Me._assemblyEnabledCheckBox = New System.Windows.Forms.CheckBox()
		 Me._annotationsEnabledCheckBox = New System.Windows.Forms.CheckBox()
		 Me._editEnabledCheckBox = New System.Windows.Forms.CheckBox()
		 Me._copyEnabledCheckBox = New System.Windows.Forms.CheckBox()
		 Me._highQualityPrintEnabledCheckBox = New System.Windows.Forms.CheckBox()
		 Me._printEnabledCheckBox = New System.Windows.Forms.CheckBox()
		 Me._ownerPasswordTextBox = New System.Windows.Forms.TextBox()
		 Me._ownerPasswordLabel = New System.Windows.Forms.Label()
		 Me._userPasswordTextBox = New System.Windows.Forms.TextBox()
		 Me._userPasswordLabel = New System.Windows.Forms.Label()
		 Me._securityOptionsGroupBox.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _securityOptionsGroupBox
		 ' 
		 Me._securityOptionsGroupBox.Controls.Add(Me._ecnryptionModeComboBox)
		 Me._securityOptionsGroupBox.Controls.Add(Me._encryptionModeLabel)
		 Me._securityOptionsGroupBox.Controls.Add(Me._assemblyEnabledCheckBox)
		 Me._securityOptionsGroupBox.Controls.Add(Me._annotationsEnabledCheckBox)
		 Me._securityOptionsGroupBox.Controls.Add(Me._editEnabledCheckBox)
		 Me._securityOptionsGroupBox.Controls.Add(Me._copyEnabledCheckBox)
		 Me._securityOptionsGroupBox.Controls.Add(Me._highQualityPrintEnabledCheckBox)
		 Me._securityOptionsGroupBox.Controls.Add(Me._printEnabledCheckBox)
		 Me._securityOptionsGroupBox.Controls.Add(Me._ownerPasswordTextBox)
		 Me._securityOptionsGroupBox.Controls.Add(Me._ownerPasswordLabel)
		 Me._securityOptionsGroupBox.Controls.Add(Me._userPasswordTextBox)
		 Me._securityOptionsGroupBox.Controls.Add(Me._userPasswordLabel)
		 Me._securityOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
		 Me._securityOptionsGroupBox.Location = New System.Drawing.Point(0, 0)
		 Me._securityOptionsGroupBox.Name = "_securityOptionsGroupBox"
		 Me._securityOptionsGroupBox.Size = New System.Drawing.Size(315, 255)
		 Me._securityOptionsGroupBox.TabIndex = 0
		 Me._securityOptionsGroupBox.TabStop = False
		 Me._securityOptionsGroupBox.Text = "Security options:"
		 ' 
		 ' _ecnryptionModeComboBox
		 ' 
		 Me._ecnryptionModeComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._ecnryptionModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._ecnryptionModeComboBox.FormattingEnabled = True
		 Me._ecnryptionModeComboBox.Location = New System.Drawing.Point(125, 19)
		 Me._ecnryptionModeComboBox.Name = "_ecnryptionModeComboBox"
		 Me._ecnryptionModeComboBox.Size = New System.Drawing.Size(171, 21)
		 Me._ecnryptionModeComboBox.TabIndex = 1
'		 Me._ecnryptionModeComboBox.SelectedIndexChanged += New System.EventHandler(Me._ecnryptionModeComboBox_SelectedIndexChanged);
		 ' 
		 ' _encryptionModeLabel
		 ' 
		 Me._encryptionModeLabel.AutoSize = True
		 Me._encryptionModeLabel.Location = New System.Drawing.Point(30, 22)
		 Me._encryptionModeLabel.Name = "_encryptionModeLabel"
		 Me._encryptionModeLabel.Size = New System.Drawing.Size(89, 13)
		 Me._encryptionModeLabel.TabIndex = 0
		 Me._encryptionModeLabel.Text = "Encryption mode:"
		 ' 
		 ' _assemblyEnabledCheckBox
		 ' 
		 Me._assemblyEnabledCheckBox.AutoSize = True
		 Me._assemblyEnabledCheckBox.Location = New System.Drawing.Point(125, 190)
		 Me._assemblyEnabledCheckBox.Name = "_assemblyEnabledCheckBox"
		 Me._assemblyEnabledCheckBox.Size = New System.Drawing.Size(111, 17)
		 Me._assemblyEnabledCheckBox.TabIndex = 10
		 Me._assemblyEnabledCheckBox.Text = "Assembly enabled"
		 Me._assemblyEnabledCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' _annotationsEnabledCheckBox
		 ' 
		 Me._annotationsEnabledCheckBox.AutoSize = True
		 Me._annotationsEnabledCheckBox.Location = New System.Drawing.Point(125, 144)
		 Me._annotationsEnabledCheckBox.Name = "_annotationsEnabledCheckBox"
		 Me._annotationsEnabledCheckBox.Size = New System.Drawing.Size(123, 17)
		 Me._annotationsEnabledCheckBox.TabIndex = 8
		 Me._annotationsEnabledCheckBox.Text = "Annotations enabled"
		 Me._annotationsEnabledCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' _editEnabledCheckBox
		 ' 
		 Me._editEnabledCheckBox.AutoSize = True
		 Me._editEnabledCheckBox.Location = New System.Drawing.Point(125, 121)
		 Me._editEnabledCheckBox.Name = "_editEnabledCheckBox"
		 Me._editEnabledCheckBox.Size = New System.Drawing.Size(85, 17)
		 Me._editEnabledCheckBox.TabIndex = 7
		 Me._editEnabledCheckBox.Text = "Edit enabled"
		 Me._editEnabledCheckBox.UseVisualStyleBackColor = True
'		 Me._editEnabledCheckBox.CheckedChanged += New System.EventHandler(Me._editEnabledCheckBox_CheckedChanged);
		 ' 
		 ' _copyEnabledCheckBox
		 ' 
		 Me._copyEnabledCheckBox.AutoSize = True
		 Me._copyEnabledCheckBox.Location = New System.Drawing.Point(125, 98)
		 Me._copyEnabledCheckBox.Name = "_copyEnabledCheckBox"
		 Me._copyEnabledCheckBox.Size = New System.Drawing.Size(91, 17)
		 Me._copyEnabledCheckBox.TabIndex = 6
		 Me._copyEnabledCheckBox.Text = "Copy enabled"
		 Me._copyEnabledCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' _highQualityPrintEnabledCheckBox
		 ' 
		 Me._highQualityPrintEnabledCheckBox.AutoSize = True
		 Me._highQualityPrintEnabledCheckBox.Location = New System.Drawing.Point(125, 213)
		 Me._highQualityPrintEnabledCheckBox.Name = "_highQualityPrintEnabledCheckBox"
		 Me._highQualityPrintEnabledCheckBox.Size = New System.Drawing.Size(145, 17)
		 Me._highQualityPrintEnabledCheckBox.TabIndex = 11
		 Me._highQualityPrintEnabledCheckBox.Text = "High quality print enabled"
		 Me._highQualityPrintEnabledCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' _printEnabledCheckBox
		 ' 
		 Me._printEnabledCheckBox.AutoSize = True
		 Me._printEnabledCheckBox.Location = New System.Drawing.Point(125, 167)
		 Me._printEnabledCheckBox.Name = "_printEnabledCheckBox"
		 Me._printEnabledCheckBox.Size = New System.Drawing.Size(88, 17)
		 Me._printEnabledCheckBox.TabIndex = 9
		 Me._printEnabledCheckBox.Text = "Print enabled"
		 Me._printEnabledCheckBox.UseVisualStyleBackColor = True
'		 Me._printEnabledCheckBox.CheckedChanged += New System.EventHandler(Me._printEnabledCheckBox_CheckedChanged);
		 ' 
		 ' _ownerPasswordTextBox
		 ' 
		 Me._ownerPasswordTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._ownerPasswordTextBox.Location = New System.Drawing.Point(125, 72)
		 Me._ownerPasswordTextBox.Name = "_ownerPasswordTextBox"
		 Me._ownerPasswordTextBox.Size = New System.Drawing.Size(171, 20)
		 Me._ownerPasswordTextBox.TabIndex = 5
		 ' 
		 ' _ownerPasswordLabel
		 ' 
		 Me._ownerPasswordLabel.AutoSize = True
		 Me._ownerPasswordLabel.Location = New System.Drawing.Point(30, 75)
		 Me._ownerPasswordLabel.Name = "_ownerPasswordLabel"
		 Me._ownerPasswordLabel.Size = New System.Drawing.Size(89, 13)
		 Me._ownerPasswordLabel.TabIndex = 4
		 Me._ownerPasswordLabel.Text = "Owner password:"
		 ' 
		 ' _userPasswordTextBox
		 ' 
		 Me._userPasswordTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._userPasswordTextBox.Location = New System.Drawing.Point(125, 46)
		 Me._userPasswordTextBox.Name = "_userPasswordTextBox"
		 Me._userPasswordTextBox.Size = New System.Drawing.Size(171, 20)
		 Me._userPasswordTextBox.TabIndex = 3
		 ' 
		 ' _userPasswordLabel
		 ' 
		 Me._userPasswordLabel.AutoSize = True
		 Me._userPasswordLabel.Location = New System.Drawing.Point(39, 49)
		 Me._userPasswordLabel.Name = "_userPasswordLabel"
		 Me._userPasswordLabel.Size = New System.Drawing.Size(80, 13)
		 Me._userPasswordLabel.TabIndex = 2
		 Me._userPasswordLabel.Text = "User password:"
		 ' 
		 ' SecurityOptionsControl
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.Controls.Add(Me._securityOptionsGroupBox)
		 Me.Name = "SecurityOptionsControl"
		 Me.Size = New System.Drawing.Size(315, 255)
		 Me._securityOptionsGroupBox.ResumeLayout(False)
		 Me._securityOptionsGroupBox.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _securityOptionsGroupBox As System.Windows.Forms.GroupBox
	  Private _ownerPasswordTextBox As System.Windows.Forms.TextBox
	  Private _ownerPasswordLabel As System.Windows.Forms.Label
	  Private _userPasswordTextBox As System.Windows.Forms.TextBox
	  Private _userPasswordLabel As System.Windows.Forms.Label
	  Private _encryptionModeLabel As System.Windows.Forms.Label
	  Private _assemblyEnabledCheckBox As System.Windows.Forms.CheckBox
	  Private _annotationsEnabledCheckBox As System.Windows.Forms.CheckBox
	  Private WithEvents _editEnabledCheckBox As System.Windows.Forms.CheckBox
	  Private _copyEnabledCheckBox As System.Windows.Forms.CheckBox
	  Private _highQualityPrintEnabledCheckBox As System.Windows.Forms.CheckBox
	  Private WithEvents _printEnabledCheckBox As System.Windows.Forms.CheckBox
	  Private WithEvents _ecnryptionModeComboBox As System.Windows.Forms.ComboBox
   End Class
End Namespace
