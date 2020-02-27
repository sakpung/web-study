Imports Microsoft.VisualBasic
Imports System

Partial Public Class UpdateZonesControl
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
      Me._characterFiltersGroupBox = New System.Windows.Forms.GroupBox()
      Me._plusCheckBox = New System.Windows.Forms.CheckBox()
      Me._miscellaneousCheckBox = New System.Windows.Forms.CheckBox()
      Me._punctuationCheckBox = New System.Windows.Forms.CheckBox()
      Me._lowercaseCheckBox = New System.Windows.Forms.CheckBox()
      Me._uppercaseCheckBox = New System.Windows.Forms.CheckBox()
      Me._digitCheckBox = New System.Windows.Forms.CheckBox()
      Me._propertiesGroupBox = New System.Windows.Forms.GroupBox()
      Me._zoneTextDirectionComboBox = New System.Windows.Forms.ComboBox()
      Me._zoneTextDirectionLabel = New System.Windows.Forms.Label()
      Me._zoneViewPerspectiveComboBox = New System.Windows.Forms.ComboBox()
      Me._zoneViewPerspectiveLabel = New System.Windows.Forms.Label()
      Me._omrStatusLabel = New System.Windows.Forms.Label()
      Me._omrLabel = New System.Windows.Forms.Label()
      Me._typeComboBox = New System.Windows.Forms.ComboBox()
      Me._typeLabel = New System.Windows.Forms.Label()
      Me._languageComboBox = New System.Windows.Forms.ComboBox()
      Me._languageLabel = New System.Windows.Forms.Label()
      Me._areaGroupBox = New System.Windows.Forms.GroupBox()
      Me._heightTextBox = New System.Windows.Forms.TextBox()
      Me._heightLabel = New System.Windows.Forms.Label()
      Me._widthTextBox = New System.Windows.Forms.TextBox()
      Me._widthLabel = New System.Windows.Forms.Label()
      Me._topTextBox = New System.Windows.Forms.TextBox()
      Me._topLabel = New System.Windows.Forms.Label()
      Me._leftTextBox = New System.Windows.Forms.TextBox()
      Me._leftLabel = New System.Windows.Forms.Label()
      Me._nameGroupBox = New System.Windows.Forms.GroupBox()
      Me._nameTextBox = New System.Windows.Forms.TextBox()
      Me._characterFiltersGroupBox.SuspendLayout()
      Me._propertiesGroupBox.SuspendLayout()
      Me._areaGroupBox.SuspendLayout()
      Me._nameGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_characterFiltersGroupBox
      '
      Me._characterFiltersGroupBox.Controls.Add(Me._plusCheckBox)
      Me._characterFiltersGroupBox.Controls.Add(Me._miscellaneousCheckBox)
      Me._characterFiltersGroupBox.Controls.Add(Me._punctuationCheckBox)
      Me._characterFiltersGroupBox.Controls.Add(Me._lowercaseCheckBox)
      Me._characterFiltersGroupBox.Controls.Add(Me._uppercaseCheckBox)
      Me._characterFiltersGroupBox.Controls.Add(Me._digitCheckBox)
      Me._characterFiltersGroupBox.Location = New System.Drawing.Point(291, 182)
      Me._characterFiltersGroupBox.Name = "_characterFiltersGroupBox"
      Me._characterFiltersGroupBox.Size = New System.Drawing.Size(305, 100)
      Me._characterFiltersGroupBox.TabIndex = 11
      Me._characterFiltersGroupBox.TabStop = False
      Me._characterFiltersGroupBox.Text = "&Character filters:"
      '
      '_plusCheckBox
      '
      Me._plusCheckBox.AutoSize = True
      Me._plusCheckBox.Location = New System.Drawing.Point(146, 70)
      Me._plusCheckBox.Name = "_plusCheckBox"
      Me._plusCheckBox.Size = New System.Drawing.Size(46, 17)
      Me._plusCheckBox.TabIndex = 5
      Me._plusCheckBox.Text = "Plus"
      Me._plusCheckBox.UseVisualStyleBackColor = True
      '         Me._plusCheckBox.CheckedChanged += New System.EventHandler(Me._characterFiltersCheckBox_CheckedChanged);
      '
      '_miscellaneousCheckBox
      '
      Me._miscellaneousCheckBox.AutoSize = True
      Me._miscellaneousCheckBox.Location = New System.Drawing.Point(27, 70)
      Me._miscellaneousCheckBox.Name = "_miscellaneousCheckBox"
      Me._miscellaneousCheckBox.Size = New System.Drawing.Size(93, 17)
      Me._miscellaneousCheckBox.TabIndex = 4
      Me._miscellaneousCheckBox.Text = "Miscellaneous"
      Me._miscellaneousCheckBox.UseVisualStyleBackColor = True
      '         Me._miscellaneousCheckBox.CheckedChanged += New System.EventHandler(Me._characterFiltersCheckBox_CheckedChanged);
      '
      '_punctuationCheckBox
      '
      Me._punctuationCheckBox.AutoSize = True
      Me._punctuationCheckBox.Location = New System.Drawing.Point(146, 45)
      Me._punctuationCheckBox.Name = "_punctuationCheckBox"
      Me._punctuationCheckBox.Size = New System.Drawing.Size(83, 17)
      Me._punctuationCheckBox.TabIndex = 3
      Me._punctuationCheckBox.Text = "Punctuation"
      Me._punctuationCheckBox.UseVisualStyleBackColor = True
      '         Me._punctuationCheckBox.CheckedChanged += New System.EventHandler(Me._characterFiltersCheckBox_CheckedChanged);
      '
      '_lowercaseCheckBox
      '
      Me._lowercaseCheckBox.AutoSize = True
      Me._lowercaseCheckBox.Location = New System.Drawing.Point(27, 45)
      Me._lowercaseCheckBox.Name = "_lowercaseCheckBox"
      Me._lowercaseCheckBox.Size = New System.Drawing.Size(78, 17)
      Me._lowercaseCheckBox.TabIndex = 2
      Me._lowercaseCheckBox.Text = "Lowercase"
      Me._lowercaseCheckBox.UseVisualStyleBackColor = True
      '         Me._lowercaseCheckBox.CheckedChanged += New System.EventHandler(Me._characterFiltersCheckBox_CheckedChanged);
      '
      '_uppercaseCheckBox
      '
      Me._uppercaseCheckBox.AutoSize = True
      Me._uppercaseCheckBox.Location = New System.Drawing.Point(146, 20)
      Me._uppercaseCheckBox.Name = "_uppercaseCheckBox"
      Me._uppercaseCheckBox.Size = New System.Drawing.Size(78, 17)
      Me._uppercaseCheckBox.TabIndex = 1
      Me._uppercaseCheckBox.Text = "Uppercase"
      Me._uppercaseCheckBox.UseVisualStyleBackColor = True
      '         Me._uppercaseCheckBox.CheckedChanged += New System.EventHandler(Me._characterFiltersCheckBox_CheckedChanged);
      '
      '_digitCheckBox
      '
      Me._digitCheckBox.AutoSize = True
      Me._digitCheckBox.Location = New System.Drawing.Point(27, 20)
      Me._digitCheckBox.Name = "_digitCheckBox"
      Me._digitCheckBox.Size = New System.Drawing.Size(47, 17)
      Me._digitCheckBox.TabIndex = 0
      Me._digitCheckBox.Text = "Digit"
      Me._digitCheckBox.UseVisualStyleBackColor = True
      '         Me._digitCheckBox.CheckedChanged += New System.EventHandler(Me._characterFiltersCheckBox_CheckedChanged);
      '
      '_propertiesGroupBox
      '
      Me._propertiesGroupBox.Controls.Add(Me._zoneTextDirectionComboBox)
      Me._propertiesGroupBox.Controls.Add(Me._zoneTextDirectionLabel)
      Me._propertiesGroupBox.Controls.Add(Me._zoneViewPerspectiveComboBox)
      Me._propertiesGroupBox.Controls.Add(Me._zoneViewPerspectiveLabel)
      Me._propertiesGroupBox.Controls.Add(Me._omrStatusLabel)
      Me._propertiesGroupBox.Controls.Add(Me._omrLabel)
      Me._propertiesGroupBox.Controls.Add(Me._typeComboBox)
      Me._propertiesGroupBox.Controls.Add(Me._typeLabel)
      Me._propertiesGroupBox.Controls.Add(Me._languageComboBox)
      Me._propertiesGroupBox.Controls.Add(Me._languageLabel)
      Me._propertiesGroupBox.Location = New System.Drawing.Point(291, 3)
      Me._propertiesGroupBox.Name = "_propertiesGroupBox"
      Me._propertiesGroupBox.Size = New System.Drawing.Size(305, 170)
      Me._propertiesGroupBox.TabIndex = 10
      Me._propertiesGroupBox.TabStop = False
      Me._propertiesGroupBox.Text = "&Properties:"
      '
      '_zoneTextDirectionComboBox
      '
      Me._zoneTextDirectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._zoneTextDirectionComboBox.FormattingEnabled = True
      Me._zoneTextDirectionComboBox.Location = New System.Drawing.Point(139, 110)
      Me._zoneTextDirectionComboBox.Name = "_zoneTextDirectionComboBox"
      Me._zoneTextDirectionComboBox.Size = New System.Drawing.Size(149, 21)
      Me._zoneTextDirectionComboBox.TabIndex = 11
      '
      '_zoneTextDirectionLabel
      '
      Me._zoneTextDirectionLabel.AutoSize = True
      Me._zoneTextDirectionLabel.Location = New System.Drawing.Point(24, 113)
      Me._zoneTextDirectionLabel.Name = "_zoneTextDirectionLabel"
      Me._zoneTextDirectionLabel.Size = New System.Drawing.Size(74, 13)
      Me._zoneTextDirectionLabel.TabIndex = 10
      Me._zoneTextDirectionLabel.Text = "Te&xt direction:"
      '
      '_zoneViewPerspectiveComboBox
      '
      Me._zoneViewPerspectiveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._zoneViewPerspectiveComboBox.FormattingEnabled = True
      Me._zoneViewPerspectiveComboBox.Location = New System.Drawing.Point(139, 83)
      Me._zoneViewPerspectiveComboBox.Name = "_zoneViewPerspectiveComboBox"
      Me._zoneViewPerspectiveComboBox.Size = New System.Drawing.Size(149, 21)
      Me._zoneViewPerspectiveComboBox.TabIndex = 9
      '
      '_zoneViewPerspectiveLabel
      '
      Me._zoneViewPerspectiveLabel.AutoSize = True
      Me._zoneViewPerspectiveLabel.Location = New System.Drawing.Point(24, 86)
      Me._zoneViewPerspectiveLabel.Name = "_zoneViewPerspectiveLabel"
      Me._zoneViewPerspectiveLabel.Size = New System.Drawing.Size(91, 13)
      Me._zoneViewPerspectiveLabel.TabIndex = 8
      Me._zoneViewPerspectiveLabel.Text = "&View perspective:"
      '
      '_omrStatusLabel
      '
      Me._omrStatusLabel.Location = New System.Drawing.Point(136, 138)
      Me._omrStatusLabel.Name = "_omrStatusLabel"
      Me._omrStatusLabel.Size = New System.Drawing.Size(152, 13)
      Me._omrStatusLabel.TabIndex = 7
      '
      '_omrLabel
      '
      Me._omrLabel.AutoSize = True
      Me._omrLabel.Location = New System.Drawing.Point(24, 138)
      Me._omrLabel.Name = "_omrLabel"
      Me._omrLabel.Size = New System.Drawing.Size(68, 13)
      Me._omrLabel.TabIndex = 6
      Me._omrLabel.Text = "OMR Status:"
      '
      '_typeComboBox
      '
      Me._typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._typeComboBox.FormattingEnabled = True
      Me._typeComboBox.Location = New System.Drawing.Point(139, 29)
      Me._typeComboBox.Name = "_typeComboBox"
      Me._typeComboBox.Size = New System.Drawing.Size(149, 21)
      Me._typeComboBox.TabIndex = 1
      '         Me._typeComboBox.SelectedIndexChanged += New System.EventHandler(Me._propertiesComboBox_SelectedIndexChanged);
      '
      '_typeLabel
      '
      Me._typeLabel.AutoSize = True
      Me._typeLabel.Location = New System.Drawing.Point(24, 32)
      Me._typeLabel.Name = "_typeLabel"
      Me._typeLabel.Size = New System.Drawing.Size(34, 13)
      Me._typeLabel.TabIndex = 0
      Me._typeLabel.Text = "T&ype:"
      '
      '_languageComboBox
      '
      Me._languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._languageComboBox.FormattingEnabled = True
      Me._languageComboBox.Location = New System.Drawing.Point(139, 56)
      Me._languageComboBox.Name = "_languageComboBox"
      Me._languageComboBox.Size = New System.Drawing.Size(149, 21)
      Me._languageComboBox.TabIndex = 1
      '
      '_languageLabel
      '
      Me._languageLabel.AutoSize = True
      Me._languageLabel.Location = New System.Drawing.Point(24, 59)
      Me._languageLabel.Name = "_languageLabel"
      Me._languageLabel.Size = New System.Drawing.Size(58, 13)
      Me._languageLabel.TabIndex = 0
      Me._languageLabel.Text = "Lan&guage:"
      '
      '_areaGroupBox
      '
      Me._areaGroupBox.Controls.Add(Me._heightTextBox)
      Me._areaGroupBox.Controls.Add(Me._heightLabel)
      Me._areaGroupBox.Controls.Add(Me._widthTextBox)
      Me._areaGroupBox.Controls.Add(Me._widthLabel)
      Me._areaGroupBox.Controls.Add(Me._topTextBox)
      Me._areaGroupBox.Controls.Add(Me._topLabel)
      Me._areaGroupBox.Controls.Add(Me._leftTextBox)
      Me._areaGroupBox.Controls.Add(Me._leftLabel)
      Me._areaGroupBox.Location = New System.Drawing.Point(3, 92)
      Me._areaGroupBox.Name = "_areaGroupBox"
      Me._areaGroupBox.Size = New System.Drawing.Size(273, 97)
      Me._areaGroupBox.TabIndex = 8
      Me._areaGroupBox.TabStop = False
      Me._areaGroupBox.Text = "&Area (in pixels):"
      '
      '_heightTextBox
      '
      Me._heightTextBox.Location = New System.Drawing.Point(186, 60)
      Me._heightTextBox.Name = "_heightTextBox"
      Me._heightTextBox.Size = New System.Drawing.Size(69, 20)
      Me._heightTextBox.TabIndex = 7
      '
      '_heightLabel
      '
      Me._heightLabel.AutoSize = True
      Me._heightLabel.Location = New System.Drawing.Point(137, 63)
      Me._heightLabel.Name = "_heightLabel"
      Me._heightLabel.Size = New System.Drawing.Size(41, 13)
      Me._heightLabel.TabIndex = 6
      Me._heightLabel.Text = "&Height:"
      '
      '_widthTextBox
      '
      Me._widthTextBox.Location = New System.Drawing.Point(62, 60)
      Me._widthTextBox.Name = "_widthTextBox"
      Me._widthTextBox.Size = New System.Drawing.Size(69, 20)
      Me._widthTextBox.TabIndex = 5
      '
      '_widthLabel
      '
      Me._widthLabel.AutoSize = True
      Me._widthLabel.Location = New System.Drawing.Point(17, 63)
      Me._widthLabel.Name = "_widthLabel"
      Me._widthLabel.Size = New System.Drawing.Size(38, 13)
      Me._widthLabel.TabIndex = 4
      Me._widthLabel.Text = "&Width:"
      '
      '_topTextBox
      '
      Me._topTextBox.Location = New System.Drawing.Point(186, 34)
      Me._topTextBox.Name = "_topTextBox"
      Me._topTextBox.Size = New System.Drawing.Size(69, 20)
      Me._topTextBox.TabIndex = 3
      '
      '_topLabel
      '
      Me._topLabel.AutoSize = True
      Me._topLabel.Location = New System.Drawing.Point(137, 37)
      Me._topLabel.Name = "_topLabel"
      Me._topLabel.Size = New System.Drawing.Size(29, 13)
      Me._topLabel.TabIndex = 2
      Me._topLabel.Text = "&Top:"
      '
      '_leftTextBox
      '
      Me._leftTextBox.Location = New System.Drawing.Point(62, 34)
      Me._leftTextBox.Name = "_leftTextBox"
      Me._leftTextBox.Size = New System.Drawing.Size(69, 20)
      Me._leftTextBox.TabIndex = 1
      '
      '_leftLabel
      '
      Me._leftLabel.AutoSize = True
      Me._leftLabel.Location = New System.Drawing.Point(17, 37)
      Me._leftLabel.Name = "_leftLabel"
      Me._leftLabel.Size = New System.Drawing.Size(28, 13)
      Me._leftLabel.TabIndex = 0
      Me._leftLabel.Text = "&Left:"
      '
      '_nameGroupBox
      '
      Me._nameGroupBox.Controls.Add(Me._nameTextBox)
      Me._nameGroupBox.Location = New System.Drawing.Point(3, 3)
      Me._nameGroupBox.Name = "_nameGroupBox"
      Me._nameGroupBox.Size = New System.Drawing.Size(273, 74)
      Me._nameGroupBox.TabIndex = 7
      Me._nameGroupBox.TabStop = False
      Me._nameGroupBox.Text = "&Name:"
      '
      '_nameTextBox
      '
      Me._nameTextBox.Location = New System.Drawing.Point(22, 29)
      Me._nameTextBox.Name = "_nameTextBox"
      Me._nameTextBox.Size = New System.Drawing.Size(233, 20)
      Me._nameTextBox.TabIndex = 0
      '
      'UpdateZonesControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._characterFiltersGroupBox)
      Me.Controls.Add(Me._propertiesGroupBox)
      Me.Controls.Add(Me._areaGroupBox)
      Me.Controls.Add(Me._nameGroupBox)
      Me.Name = "UpdateZonesControl"
      Me.Size = New System.Drawing.Size(605, 288)
      Me._characterFiltersGroupBox.ResumeLayout(False)
      Me._characterFiltersGroupBox.PerformLayout()
      Me._propertiesGroupBox.ResumeLayout(False)
      Me._propertiesGroupBox.PerformLayout()
      Me._areaGroupBox.ResumeLayout(False)
      Me._areaGroupBox.PerformLayout()
      Me._nameGroupBox.ResumeLayout(False)
      Me._nameGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _characterFiltersGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _plusCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _miscellaneousCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _punctuationCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _lowercaseCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _uppercaseCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _digitCheckBox As System.Windows.Forms.CheckBox
   Private _propertiesGroupBox As System.Windows.Forms.GroupBox
   Private _omrStatusLabel As System.Windows.Forms.Label
   Private _omrLabel As System.Windows.Forms.Label
   Private WithEvents _typeComboBox As System.Windows.Forms.ComboBox
   Private _typeLabel As System.Windows.Forms.Label
   Private WithEvents _languageComboBox As System.Windows.Forms.ComboBox
   Private _languageLabel As System.Windows.Forms.Label
   Private _areaGroupBox As System.Windows.Forms.GroupBox
   Private _heightTextBox As System.Windows.Forms.TextBox
   Private _heightLabel As System.Windows.Forms.Label
   Private _widthTextBox As System.Windows.Forms.TextBox
   Private _widthLabel As System.Windows.Forms.Label
   Private _topTextBox As System.Windows.Forms.TextBox
   Private _topLabel As System.Windows.Forms.Label
   Private _leftTextBox As System.Windows.Forms.TextBox
   Private _leftLabel As System.Windows.Forms.Label
   Private _nameGroupBox As System.Windows.Forms.GroupBox
   Private _nameTextBox As System.Windows.Forms.TextBox
   Private WithEvents _zoneTextDirectionComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _zoneTextDirectionLabel As System.Windows.Forms.Label
   Private WithEvents _zoneViewPerspectiveComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _zoneViewPerspectiveLabel As System.Windows.Forms.Label
End Class
