Partial Class DocumentConverterDocumentControl
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
         CleanUp()

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
      Me._inputDocumentGroupBox = New System.Windows.Forms.GroupBox()
      Me._lastPageCheckBox = New System.Windows.Forms.CheckBox()
      Me._toPageNumericUpDown = New System.Windows.Forms.NumericUpDown()
      Me._toPageLabel = New System.Windows.Forms.Label()
      Me._firstPageCheckBox = New System.Windows.Forms.CheckBox()
      Me._fromPageNumericUpDown = New System.Windows.Forms.NumericUpDown()
      Me._fromPageLabel = New System.Windows.Forms.Label()
      Me._inputAnnotationsModeComboBox = New System.Windows.Forms.ComboBox()
      Me._inputAnnotationsModeLabel = New System.Windows.Forms.Label()
      Me._inputAnnotationsFileBrowseButton = New System.Windows.Forms.Button()
      Me._inputAnnotationsFileTextBox = New System.Windows.Forms.TextBox()
      Me._inputAnnotationsFileLabel = New System.Windows.Forms.Label()
      Me._inputDocumentPagesLabel = New System.Windows.Forms.Label()
      Me._inputDocumentFileBrowseButton = New System.Windows.Forms.Button()
      Me._inputDocumentFileTextBox = New System.Windows.Forms.TextBox()
      Me._inputDocumentFileLabel = New System.Windows.Forms.Label()
      Me._outputDocumentGroupBox = New System.Windows.Forms.GroupBox()
      Me._outputFormatPanel = New System.Windows.Forms.Panel()
      Me._rasterImageFormatComboBox = New System.Windows.Forms.ComboBox()
      Me._outputFormatComboBox = New System.Windows.Forms.ComboBox()
      Me._outputFormatLabel = New System.Windows.Forms.Label()
      Me._outputAnnotationsModeComboBox = New System.Windows.Forms.ComboBox()
      Me._outputAnnotationsModeLabel = New System.Windows.Forms.Label()
      Me._outputAnnotationsFileBrowseButton = New System.Windows.Forms.Button()
      Me._outputAnnotationsFileTextBox = New System.Windows.Forms.TextBox()
      Me._outputAnnotationsFileLabel = New System.Windows.Forms.Label()
      Me._outputDocumentFileBrowseButton = New System.Windows.Forms.Button()
      Me._outputDocumentFileTextBox = New System.Windows.Forms.TextBox()
      Me._outputDocumentFileLabel = New System.Windows.Forms.Label()
      Me._disabledPagesLabel = New System.Windows.Forms.Label()
      Me._inputDocumentGroupBox.SuspendLayout()
      CType(Me._toPageNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._fromPageNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._outputDocumentGroupBox.SuspendLayout()
      Me._outputFormatPanel.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _inputDocumentGroupBox
      ' 
      Me._inputDocumentGroupBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._inputDocumentGroupBox.Controls.Add(Me._disabledPagesLabel)
      Me._inputDocumentGroupBox.Controls.Add(Me._lastPageCheckBox)
      Me._inputDocumentGroupBox.Controls.Add(Me._toPageNumericUpDown)
      Me._inputDocumentGroupBox.Controls.Add(Me._toPageLabel)
      Me._inputDocumentGroupBox.Controls.Add(Me._firstPageCheckBox)
      Me._inputDocumentGroupBox.Controls.Add(Me._fromPageNumericUpDown)
      Me._inputDocumentGroupBox.Controls.Add(Me._fromPageLabel)
      Me._inputDocumentGroupBox.Controls.Add(Me._inputAnnotationsModeComboBox)
      Me._inputDocumentGroupBox.Controls.Add(Me._inputAnnotationsModeLabel)
      Me._inputDocumentGroupBox.Controls.Add(Me._inputAnnotationsFileBrowseButton)
      Me._inputDocumentGroupBox.Controls.Add(Me._inputAnnotationsFileTextBox)
      Me._inputDocumentGroupBox.Controls.Add(Me._inputAnnotationsFileLabel)
      Me._inputDocumentGroupBox.Controls.Add(Me._inputDocumentPagesLabel)
      Me._inputDocumentGroupBox.Controls.Add(Me._inputDocumentFileBrowseButton)
      Me._inputDocumentGroupBox.Controls.Add(Me._inputDocumentFileTextBox)
      Me._inputDocumentGroupBox.Controls.Add(Me._inputDocumentFileLabel)
      Me._inputDocumentGroupBox.Location = New System.Drawing.Point(12, 12)
      Me._inputDocumentGroupBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._inputDocumentGroupBox.Name = "_inputDocumentGroupBox"
      Me._inputDocumentGroupBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._inputDocumentGroupBox.Size = New System.Drawing.Size(928, 220)
      Me._inputDocumentGroupBox.TabIndex = 0
      Me._inputDocumentGroupBox.TabStop = False
      Me._inputDocumentGroupBox.Text = "&Input document"
      ' 
      ' _lastPageCheckBox
      ' 
      Me._lastPageCheckBox.AutoSize = True
      Me._lastPageCheckBox.Location = New System.Drawing.Point(555, 91)
      Me._lastPageCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._lastPageCheckBox.Name = "_lastPageCheckBox"
      Me._lastPageCheckBox.Size = New System.Drawing.Size(106, 24)
      Me._lastPageCheckBox.TabIndex = 9
      Me._lastPageCheckBox.Text = "&Last page"
      Me._lastPageCheckBox.UseVisualStyleBackColor = True
      ' 
      ' _toPageNumericUpDown
      ' 
      Me._toPageNumericUpDown.Location = New System.Drawing.Point(458, 89)
      Me._toPageNumericUpDown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._toPageNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._toPageNumericUpDown.Name = "_toPageNumericUpDown"
      Me._toPageNumericUpDown.Size = New System.Drawing.Size(88, 26)
      Me._toPageNumericUpDown.TabIndex = 8
      Me._toPageNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
      ' 
      ' _toPageLabel
      ' 
      Me._toPageLabel.AutoSize = True
      Me._toPageLabel.Location = New System.Drawing.Point(420, 92)
      Me._toPageLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._toPageLabel.Name = "_toPageLabel"
      Me._toPageLabel.Size = New System.Drawing.Size(27, 20)
      Me._toPageLabel.TabIndex = 7
      Me._toPageLabel.Text = "t&o:"
      ' 
      ' _firstPageCheckBox
      ' 
      Me._firstPageCheckBox.AutoSize = True
      Me._firstPageCheckBox.Location = New System.Drawing.Point(303, 91)
      Me._firstPageCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._firstPageCheckBox.Name = "_firstPageCheckBox"
      Me._firstPageCheckBox.Size = New System.Drawing.Size(106, 24)
      Me._firstPageCheckBox.TabIndex = 6
      Me._firstPageCheckBox.Text = "&First page"
      Me._firstPageCheckBox.UseVisualStyleBackColor = True
      ' 
      ' _fromPageNumericUpDown
      ' 
      Me._fromPageNumericUpDown.Location = New System.Drawing.Point(204, 88)
      Me._fromPageNumericUpDown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._fromPageNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._fromPageNumericUpDown.Name = "_fromPageNumericUpDown"
      Me._fromPageNumericUpDown.Size = New System.Drawing.Size(88, 26)
      Me._fromPageNumericUpDown.TabIndex = 5
      Me._fromPageNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
      ' 
      ' _fromPageLabel
      ' 
      Me._fromPageLabel.AutoSize = True
      Me._fromPageLabel.Location = New System.Drawing.Point(150, 91)
      Me._fromPageLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._fromPageLabel.Name = "_fromPageLabel"
      Me._fromPageLabel.Size = New System.Drawing.Size(45, 20)
      Me._fromPageLabel.TabIndex = 4
      Me._fromPageLabel.Text = "f&rom:"
      ' 
      ' _inputAnnotationsModeComboBox
      ' 
      Me._inputAnnotationsModeComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._inputAnnotationsModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._inputAnnotationsModeComboBox.FormattingEnabled = True
      Me._inputAnnotationsModeComboBox.Items.AddRange(New Object() {"Do not import annotations", "Import the annotations embedded in the document (if found)", "Import from an external file"})
      Me._inputAnnotationsModeComboBox.Location = New System.Drawing.Point(150, 128)
      Me._inputAnnotationsModeComboBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._inputAnnotationsModeComboBox.Name = "_inputAnnotationsModeComboBox"
      Me._inputAnnotationsModeComboBox.Size = New System.Drawing.Size(712, 28)
      Me._inputAnnotationsModeComboBox.TabIndex = 11
      ' 
      ' _inputAnnotationsModeLabel
      ' 
      Me._inputAnnotationsModeLabel.AutoSize = True
      Me._inputAnnotationsModeLabel.Location = New System.Drawing.Point(40, 132)
      Me._inputAnnotationsModeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._inputAnnotationsModeLabel.Name = "_inputAnnotationsModeLabel"
      Me._inputAnnotationsModeLabel.Size = New System.Drawing.Size(99, 20)
      Me._inputAnnotationsModeLabel.TabIndex = 10
      Me._inputAnnotationsModeLabel.Text = "&Annotations:"
      ' 
      ' _inputAnnotationsFileBrowseButton
      ' 
      Me._inputAnnotationsFileBrowseButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._inputAnnotationsFileBrowseButton.Location = New System.Drawing.Point(872, 165)
      Me._inputAnnotationsFileBrowseButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._inputAnnotationsFileBrowseButton.Name = "_inputAnnotationsFileBrowseButton"
      Me._inputAnnotationsFileBrowseButton.Size = New System.Drawing.Size(45, 35)
      Me._inputAnnotationsFileBrowseButton.TabIndex = 14
      Me._inputAnnotationsFileBrowseButton.Text = "..."
      Me._inputAnnotationsFileBrowseButton.UseVisualStyleBackColor = True
      ' 
      ' _inputAnnotationsFileTextBox
      ' 
      Me._inputAnnotationsFileTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._inputAnnotationsFileTextBox.Location = New System.Drawing.Point(150, 169)
      Me._inputAnnotationsFileTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._inputAnnotationsFileTextBox.Name = "_inputAnnotationsFileTextBox"
      Me._inputAnnotationsFileTextBox.Size = New System.Drawing.Size(712, 26)
      Me._inputAnnotationsFileTextBox.TabIndex = 13
      ' 
      ' _inputAnnotationsFileLabel
      ' 
      Me._inputAnnotationsFileLabel.AutoSize = True
      Me._inputAnnotationsFileLabel.Location = New System.Drawing.Point(16, 174)
      Me._inputAnnotationsFileLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._inputAnnotationsFileLabel.Name = "_inputAnnotationsFileLabel"
      Me._inputAnnotationsFileLabel.Size = New System.Drawing.Size(123, 20)
      Me._inputAnnotationsFileLabel.TabIndex = 12
      Me._inputAnnotationsFileLabel.Text = "A&nnotations file:"
      ' 
      ' _inputDocumentPagesLabel
      ' 
      Me._inputDocumentPagesLabel.AutoSize = True
      Me._inputDocumentPagesLabel.Location = New System.Drawing.Point(80, 91)
      Me._inputDocumentPagesLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._inputDocumentPagesLabel.Name = "_inputDocumentPagesLabel"
      Me._inputDocumentPagesLabel.Size = New System.Drawing.Size(58, 20)
      Me._inputDocumentPagesLabel.TabIndex = 3
      Me._inputDocumentPagesLabel.Text = "&Pages:"
      ' 
      ' _inputDocumentFileBrowseButton
      ' 
      Me._inputDocumentFileBrowseButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._inputDocumentFileBrowseButton.Location = New System.Drawing.Point(872, 40)
      Me._inputDocumentFileBrowseButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._inputDocumentFileBrowseButton.Name = "_inputDocumentFileBrowseButton"
      Me._inputDocumentFileBrowseButton.Size = New System.Drawing.Size(45, 35)
      Me._inputDocumentFileBrowseButton.TabIndex = 2
      Me._inputDocumentFileBrowseButton.Text = "..."
      Me._inputDocumentFileBrowseButton.UseVisualStyleBackColor = True
      ' 
      ' _inputDocumentFileTextBox
      ' 
      Me._inputDocumentFileTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._inputDocumentFileTextBox.Location = New System.Drawing.Point(150, 43)
      Me._inputDocumentFileTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._inputDocumentFileTextBox.Name = "_inputDocumentFileTextBox"
      Me._inputDocumentFileTextBox.Size = New System.Drawing.Size(712, 26)
      Me._inputDocumentFileTextBox.TabIndex = 1
      ' 
      ' _inputDocumentFileLabel
      ' 
      Me._inputDocumentFileLabel.AutoSize = True
      Me._inputDocumentFileLabel.Location = New System.Drawing.Point(28, 48)
      Me._inputDocumentFileLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._inputDocumentFileLabel.Name = "_inputDocumentFileLabel"
      Me._inputDocumentFileLabel.Size = New System.Drawing.Size(111, 20)
      Me._inputDocumentFileLabel.TabIndex = 0
      Me._inputDocumentFileLabel.Text = "&Document file:"
      ' 
      ' _outputDocumentGroupBox
      ' 
      Me._outputDocumentGroupBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._outputDocumentGroupBox.Controls.Add(Me._outputFormatPanel)
      Me._outputDocumentGroupBox.Controls.Add(Me._outputFormatComboBox)
      Me._outputDocumentGroupBox.Controls.Add(Me._outputFormatLabel)
      Me._outputDocumentGroupBox.Controls.Add(Me._outputAnnotationsModeComboBox)
      Me._outputDocumentGroupBox.Controls.Add(Me._outputAnnotationsModeLabel)
      Me._outputDocumentGroupBox.Controls.Add(Me._outputAnnotationsFileBrowseButton)
      Me._outputDocumentGroupBox.Controls.Add(Me._outputAnnotationsFileTextBox)
      Me._outputDocumentGroupBox.Controls.Add(Me._outputAnnotationsFileLabel)
      Me._outputDocumentGroupBox.Controls.Add(Me._outputDocumentFileBrowseButton)
      Me._outputDocumentGroupBox.Controls.Add(Me._outputDocumentFileTextBox)
      Me._outputDocumentGroupBox.Controls.Add(Me._outputDocumentFileLabel)
      Me._outputDocumentGroupBox.Location = New System.Drawing.Point(12, 242)
      Me._outputDocumentGroupBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._outputDocumentGroupBox.Name = "_outputDocumentGroupBox"
      Me._outputDocumentGroupBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._outputDocumentGroupBox.Size = New System.Drawing.Size(928, 222)
      Me._outputDocumentGroupBox.TabIndex = 1
      Me._outputDocumentGroupBox.TabStop = False
      Me._outputDocumentGroupBox.Text = "&Output document"
      ' 
      ' _outputFormatPanel
      ' 
      Me._outputFormatPanel.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._outputFormatPanel.Controls.Add(Me._rasterImageFormatComboBox)
      Me._outputFormatPanel.Location = New System.Drawing.Point(340, 40)
      Me._outputFormatPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._outputFormatPanel.Name = "_outputFormatPanel"
      Me._outputFormatPanel.Size = New System.Drawing.Size(524, 37)
      Me._outputFormatPanel.TabIndex = 2
      ' 
      ' _rasterImageFormatComboBox
      ' 
      Me._rasterImageFormatComboBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me._rasterImageFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._rasterImageFormatComboBox.FormattingEnabled = True
      Me._rasterImageFormatComboBox.Location = New System.Drawing.Point(0, 0)
      Me._rasterImageFormatComboBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._rasterImageFormatComboBox.Name = "_rasterImageFormatComboBox"
      Me._rasterImageFormatComboBox.Size = New System.Drawing.Size(524, 28)
      Me._rasterImageFormatComboBox.TabIndex = 0
      ' 
      ' _outputFormatComboBox
      ' 
      Me._outputFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._outputFormatComboBox.FormattingEnabled = True
      Me._outputFormatComboBox.Items.AddRange(New Object() {"Document", "Raster"})
      Me._outputFormatComboBox.Location = New System.Drawing.Point(150, 42)
      Me._outputFormatComboBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._outputFormatComboBox.Name = "_outputFormatComboBox"
      Me._outputFormatComboBox.Size = New System.Drawing.Size(180, 28)
      Me._outputFormatComboBox.TabIndex = 1
      ' 
      ' _outputFormatLabel
      ' 
      Me._outputFormatLabel.AutoSize = True
      Me._outputFormatLabel.Location = New System.Drawing.Point(76, 46)
      Me._outputFormatLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._outputFormatLabel.Name = "_outputFormatLabel"
      Me._outputFormatLabel.Size = New System.Drawing.Size(64, 20)
      Me._outputFormatLabel.TabIndex = 0
      Me._outputFormatLabel.Text = "For&mat:"
      ' 
      ' _outputAnnotationsModeComboBox
      ' 
      Me._outputAnnotationsModeComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._outputAnnotationsModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._outputAnnotationsModeComboBox.FormattingEnabled = True
      Me._outputAnnotationsModeComboBox.Items.AddRange(New Object() {"Do not export any annotations", "Export to an external file", "Overlay (works with Raster formats only)", "Embed into the output document (works with PDF and TIF files only)"})
      Me._outputAnnotationsModeComboBox.Location = New System.Drawing.Point(150, 128)
      Me._outputAnnotationsModeComboBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._outputAnnotationsModeComboBox.Name = "_outputAnnotationsModeComboBox"
      Me._outputAnnotationsModeComboBox.Size = New System.Drawing.Size(712, 28)
      Me._outputAnnotationsModeComboBox.TabIndex = 7
      ' 
      ' _outputAnnotationsModeLabel
      ' 
      Me._outputAnnotationsModeLabel.AutoSize = True
      Me._outputAnnotationsModeLabel.Location = New System.Drawing.Point(40, 132)
      Me._outputAnnotationsModeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._outputAnnotationsModeLabel.Name = "_outputAnnotationsModeLabel"
      Me._outputAnnotationsModeLabel.Size = New System.Drawing.Size(99, 20)
      Me._outputAnnotationsModeLabel.TabIndex = 6
      Me._outputAnnotationsModeLabel.Text = "Annotat&ions:"
      ' 
      ' _outputAnnotationsFileBrowseButton
      ' 
      Me._outputAnnotationsFileBrowseButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._outputAnnotationsFileBrowseButton.Location = New System.Drawing.Point(872, 166)
      Me._outputAnnotationsFileBrowseButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._outputAnnotationsFileBrowseButton.Name = "_outputAnnotationsFileBrowseButton"
      Me._outputAnnotationsFileBrowseButton.Size = New System.Drawing.Size(45, 35)
      Me._outputAnnotationsFileBrowseButton.TabIndex = 10
      Me._outputAnnotationsFileBrowseButton.Text = "..."
      Me._outputAnnotationsFileBrowseButton.UseVisualStyleBackColor = True
      ' 
      ' _outputAnnotationsFileTextBox
      ' 
      Me._outputAnnotationsFileTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._outputAnnotationsFileTextBox.Location = New System.Drawing.Point(150, 169)
      Me._outputAnnotationsFileTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._outputAnnotationsFileTextBox.Name = "_outputAnnotationsFileTextBox"
      Me._outputAnnotationsFileTextBox.Size = New System.Drawing.Size(712, 26)
      Me._outputAnnotationsFileTextBox.TabIndex = 9
      ' 
      ' _outputAnnotationsFileLabel
      ' 
      Me._outputAnnotationsFileLabel.AutoSize = True
      Me._outputAnnotationsFileLabel.Location = New System.Drawing.Point(16, 174)
      Me._outputAnnotationsFileLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._outputAnnotationsFileLabel.Name = "_outputAnnotationsFileLabel"
      Me._outputAnnotationsFileLabel.Size = New System.Drawing.Size(123, 20)
      Me._outputAnnotationsFileLabel.TabIndex = 8
      Me._outputAnnotationsFileLabel.Text = "Annotations fil&e:"
      ' 
      ' _outputDocumentFileBrowseButton
      ' 
      Me._outputDocumentFileBrowseButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._outputDocumentFileBrowseButton.Location = New System.Drawing.Point(872, 83)
      Me._outputDocumentFileBrowseButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._outputDocumentFileBrowseButton.Name = "_outputDocumentFileBrowseButton"
      Me._outputDocumentFileBrowseButton.Size = New System.Drawing.Size(45, 35)
      Me._outputDocumentFileBrowseButton.TabIndex = 5
      Me._outputDocumentFileBrowseButton.Text = "..."
      Me._outputDocumentFileBrowseButton.UseVisualStyleBackColor = True
      ' 
      ' _outputDocumentFileTextBox
      ' 
      Me._outputDocumentFileTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._outputDocumentFileTextBox.Location = New System.Drawing.Point(150, 86)
      Me._outputDocumentFileTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._outputDocumentFileTextBox.Name = "_outputDocumentFileTextBox"
      Me._outputDocumentFileTextBox.Size = New System.Drawing.Size(712, 26)
      Me._outputDocumentFileTextBox.TabIndex = 4
      ' 
      ' _outputDocumentFileLabel
      ' 
      Me._outputDocumentFileLabel.AutoSize = True
      Me._outputDocumentFileLabel.Location = New System.Drawing.Point(28, 91)
      Me._outputDocumentFileLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._outputDocumentFileLabel.Name = "_outputDocumentFileLabel"
      Me._outputDocumentFileLabel.Size = New System.Drawing.Size(111, 20)
      Me._outputDocumentFileLabel.TabIndex = 3
      Me._outputDocumentFileLabel.Text = "Do&cument file:"
      ' 
      ' _disabledPagesLabel
      ' 
      Me._disabledPagesLabel.AutoSize = True
      Me._disabledPagesLabel.Location = New System.Drawing.Point(669, 83)
      Me._disabledPagesLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._disabledPagesLabel.Name = "_disabledPagesLabel"
      Me._disabledPagesLabel.Size = New System.Drawing.Size(191, 40)
      Me._disabledPagesLabel.TabIndex = 15
      Me._disabledPagesLabel.Text = "Disabled pages are not" & Microsoft.VisualBasic.Constants.vbCrLf & "included in the conversion"
      ' 
      ' DocumentConverterDocumentControl
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0F, 20.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._outputDocumentGroupBox)
      Me.Controls.Add(Me._inputDocumentGroupBox)
      Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.Name = "DocumentConverterDocumentControl"
      Me.Size = New System.Drawing.Size(960, 492)
      Me._inputDocumentGroupBox.ResumeLayout(False)
      Me._inputDocumentGroupBox.PerformLayout()
      CType(Me._toPageNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._fromPageNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      Me._outputDocumentGroupBox.ResumeLayout(False)
      Me._outputDocumentGroupBox.PerformLayout()
      Me._outputFormatPanel.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _inputDocumentGroupBox As System.Windows.Forms.GroupBox
   Private _inputDocumentFileLabel As System.Windows.Forms.Label
   Private WithEvents _inputDocumentFileTextBox As System.Windows.Forms.TextBox
   Private WithEvents _inputDocumentFileBrowseButton As System.Windows.Forms.Button
   Private _inputDocumentPagesLabel As System.Windows.Forms.Label
   Private _inputAnnotationsFileLabel As System.Windows.Forms.Label
   Private WithEvents _inputAnnotationsFileBrowseButton As System.Windows.Forms.Button
   Private WithEvents _inputAnnotationsFileTextBox As System.Windows.Forms.TextBox
   Private _inputAnnotationsModeLabel As System.Windows.Forms.Label
   Private WithEvents _inputAnnotationsModeComboBox As System.Windows.Forms.ComboBox
   Private _outputDocumentGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _outputAnnotationsModeComboBox As System.Windows.Forms.ComboBox
   Private _outputAnnotationsModeLabel As System.Windows.Forms.Label
   Private WithEvents _outputAnnotationsFileBrowseButton As System.Windows.Forms.Button
   Private WithEvents _outputAnnotationsFileTextBox As System.Windows.Forms.TextBox
   Private _outputAnnotationsFileLabel As System.Windows.Forms.Label
   Private WithEvents _outputDocumentFileBrowseButton As System.Windows.Forms.Button
   Private WithEvents _outputDocumentFileTextBox As System.Windows.Forms.TextBox
   Private _outputDocumentFileLabel As System.Windows.Forms.Label
   Private _outputFormatLabel As System.Windows.Forms.Label
   Private WithEvents _outputFormatComboBox As System.Windows.Forms.ComboBox
   Private _outputFormatPanel As System.Windows.Forms.Panel
   Private WithEvents _rasterImageFormatComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _firstPageCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _fromPageNumericUpDown As System.Windows.Forms.NumericUpDown
   Private _fromPageLabel As System.Windows.Forms.Label
   Private WithEvents _lastPageCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _toPageNumericUpDown As System.Windows.Forms.NumericUpDown
   Private _toPageLabel As System.Windows.Forms.Label
   Private _disabledPagesLabel As System.Windows.Forms.Label
End Class
