Imports Microsoft.VisualBasic
Partial Class DocumentFormatOptionsDialog
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(disposing As Boolean)
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentFormatOptionsDialog))
      Me._okButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._optionsTabControl = New System.Windows.Forms.TabControl()
      Me._ldOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._ldOptionsNoteLabel = New System.Windows.Forms.Label()
      Me._emfOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._emfOptionsNoteLabel = New System.Windows.Forms.Label()
      Me._pdfOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._pdfLinearizedCheckBox = New System.Windows.Forms.CheckBox()
      Me._pdfAdvanctionOptionsButton = New System.Windows.Forms.Button()
      Me._pdfImageOverTextCheckBox = New System.Windows.Forms.CheckBox()
      Me._pdfDocumentTypeComboBox = New System.Windows.Forms.ComboBox()
      Me._pdfDocumentTypeLabel = New System.Windows.Forms.Label()
      Me._docOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._docOptionsDescriptionLabel = New System.Windows.Forms.Label()
      Me._docFramedCheckBox = New System.Windows.Forms.CheckBox()
      Me._rtfOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._rtfOptionsDescriptionLabel = New System.Windows.Forms.Label()
      Me._rtfFramedCheckBox = New System.Windows.Forms.CheckBox()
      Me._htmlOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._htmlBackgroundColorButton = New System.Windows.Forms.Button()
      Me._htmlBackgroundColorValueLabel = New System.Windows.Forms.Label()
      Me._htmlBackgroundColorLabel = New System.Windows.Forms.Label()
      Me._htmlUseBackgroundColorCheckBox = New System.Windows.Forms.CheckBox()
      Me._htmlEmbedFontModeComboBox = New System.Windows.Forms.ComboBox()
      Me._htmlEmbedFontModeLabel = New System.Windows.Forms.Label()
      Me._textOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._textFormattedCheckBox = New System.Windows.Forms.CheckBox()
      Me._textAddPageBreakCheckBox = New System.Windows.Forms.CheckBox()
      Me._textAddPageNumberCheckBox = New System.Windows.Forms.CheckBox()
      Me._textDocumentTypeComboBox = New System.Windows.Forms.ComboBox()
      Me._textDocumentTypeLabel = New System.Windows.Forms.Label()
      Me._docxOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._docxOptionsDescriptionLabel = New System.Windows.Forms.Label()
      Me._docxFramedCheckBox = New System.Windows.Forms.CheckBox()
      Me._altoXmlOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._altoXmlShowGlyphVariantsCheckBox = New System.Windows.Forms.CheckBox()
      Me._altoXmlShowGlyphInfoCheckBox = New System.Windows.Forms.CheckBox()
      Me._altoXmlPlainTextCheckBox = New System.Windows.Forms.CheckBox()
      Me._altoXmlSortCheckBox = New System.Windows.Forms.CheckBox()
      Me._altoXmlApplicationDescriptionTextBox = New System.Windows.Forms.TextBox()
      Me._altoXmlApplicationDescriptionLabel = New System.Windows.Forms.Label()
      Me._altoXmlSoftwareNameTextBox = New System.Windows.Forms.TextBox()
      Me._altoXmlSoftwareNameLabel = New System.Windows.Forms.Label()
      Me._altoXmlSoftwareCreatorTextBox = New System.Windows.Forms.TextBox()
      Me._altoXmlSoftwareCreatorLabel = New System.Windows.Forms.Label()
      Me._altoXmlFileNameTextBox = New System.Windows.Forms.TextBox()
      Me._altoXmlFileNameLabel = New System.Windows.Forms.Label()
      Me._altoXmlIndentationTextBox = New System.Windows.Forms.TextBox()
      Me._altoXmlIndentationLabel = New System.Windows.Forms.Label()
      Me._altoXmlFormattedCheckBox = New System.Windows.Forms.CheckBox()
      Me._emptyOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._emptyOptionsLabel = New System.Windows.Forms.Label()
      Me._altoXmlMeasurementUnitComboBox = New System.Windows.Forms.ComboBox()
      Me._altoXmlMeasurementUnitLabel = New System.Windows.Forms.Label()
      Me._optionsTabControl.SuspendLayout()
      Me._ldOptionsTabPage.SuspendLayout()
      Me._emfOptionsTabPage.SuspendLayout()
      Me._pdfOptionsTabPage.SuspendLayout()
      Me._docOptionsTabPage.SuspendLayout()
      Me._rtfOptionsTabPage.SuspendLayout()
      Me._htmlOptionsTabPage.SuspendLayout()
      Me._textOptionsTabPage.SuspendLayout()
      Me._docxOptionsTabPage.SuspendLayout()
      Me._altoXmlOptionsTabPage.SuspendLayout()
      Me._emptyOptionsTabPage.SuspendLayout()
      Me.SuspendLayout()
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(620, 18)
      Me._okButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(112, 35)
      Me._okButton.TabIndex = 0
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(620, 63)
      Me._cancelButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(112, 35)
      Me._cancelButton.TabIndex = 1
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      '_optionsTabControl
      '
      Me._optionsTabControl.Controls.Add(Me._ldOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._emfOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._pdfOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._docOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._rtfOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._htmlOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._textOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._docxOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._altoXmlOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._emptyOptionsTabPage)
      Me._optionsTabControl.Location = New System.Drawing.Point(18, 18)
      Me._optionsTabControl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._optionsTabControl.Name = "_optionsTabControl"
      Me._optionsTabControl.SelectedIndex = 0
      Me._optionsTabControl.Size = New System.Drawing.Size(564, 507)
      Me._optionsTabControl.TabIndex = 2
      '
      '_ldOptionsTabPage
      '
      Me._ldOptionsTabPage.Controls.Add(Me._ldOptionsNoteLabel)
      Me._ldOptionsTabPage.Location = New System.Drawing.Point(4, 29)
      Me._ldOptionsTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._ldOptionsTabPage.Name = "_ldOptionsTabPage"
      Me._ldOptionsTabPage.Size = New System.Drawing.Size(556, 474)
      Me._ldOptionsTabPage.TabIndex = 7
      Me._ldOptionsTabPage.Text = "LTD Options"
      Me._ldOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_ldOptionsNoteLabel
      '
      Me._ldOptionsNoteLabel.AutoSize = True
      Me._ldOptionsNoteLabel.Location = New System.Drawing.Point(33, 18)
      Me._ldOptionsNoteLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._ldOptionsNoteLabel.Name = "_ldOptionsNoteLabel"
      Me._ldOptionsNoteLabel.Size = New System.Drawing.Size(505, 200)
      Me._ldOptionsNoteLabel.TabIndex = 1
      Me._ldOptionsNoteLabel.Text = resources.GetString("_ldOptionsNoteLabel.Text")
      '
      '_emfOptionsTabPage
      '
      Me._emfOptionsTabPage.Controls.Add(Me._emfOptionsNoteLabel)
      Me._emfOptionsTabPage.Location = New System.Drawing.Point(4, 29)
      Me._emfOptionsTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._emfOptionsTabPage.Name = "_emfOptionsTabPage"
      Me._emfOptionsTabPage.Size = New System.Drawing.Size(556, 418)
      Me._emfOptionsTabPage.TabIndex = 6
      Me._emfOptionsTabPage.Text = "EMF options"
      Me._emfOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_emfOptionsNoteLabel
      '
      Me._emfOptionsNoteLabel.AutoSize = True
      Me._emfOptionsNoteLabel.Location = New System.Drawing.Point(20, 23)
      Me._emfOptionsNoteLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._emfOptionsNoteLabel.Name = "_emfOptionsNoteLabel"
      Me._emfOptionsNoteLabel.Size = New System.Drawing.Size(473, 60)
      Me._emfOptionsNoteLabel.TabIndex = 0
      Me._emfOptionsNoteLabel.Text = "Note that the EMF format does not support multiple-pages, hence" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "when saving a mu" &
    "lti-page document to EMF the result is the last" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "page only."
      '
      '_pdfOptionsTabPage
      '
      Me._pdfOptionsTabPage.Controls.Add(Me._pdfLinearizedCheckBox)
      Me._pdfOptionsTabPage.Controls.Add(Me._pdfAdvanctionOptionsButton)
      Me._pdfOptionsTabPage.Controls.Add(Me._pdfImageOverTextCheckBox)
      Me._pdfOptionsTabPage.Controls.Add(Me._pdfDocumentTypeComboBox)
      Me._pdfOptionsTabPage.Controls.Add(Me._pdfDocumentTypeLabel)
      Me._pdfOptionsTabPage.Location = New System.Drawing.Point(4, 29)
      Me._pdfOptionsTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._pdfOptionsTabPage.Name = "_pdfOptionsTabPage"
      Me._pdfOptionsTabPage.Size = New System.Drawing.Size(556, 418)
      Me._pdfOptionsTabPage.TabIndex = 0
      Me._pdfOptionsTabPage.Text = "PDF options"
      Me._pdfOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_pdfLinearizedCheckBox
      '
      Me._pdfLinearizedCheckBox.AutoSize = True
      Me._pdfLinearizedCheckBox.Location = New System.Drawing.Point(190, 146)
      Me._pdfLinearizedCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._pdfLinearizedCheckBox.Name = "_pdfLinearizedCheckBox"
      Me._pdfLinearizedCheckBox.Size = New System.Drawing.Size(221, 24)
      Me._pdfLinearizedCheckBox.TabIndex = 4
      Me._pdfLinearizedCheckBox.Text = "Fast web view (Linearized)"
      Me._pdfLinearizedCheckBox.UseVisualStyleBackColor = True
      '
      '_pdfAdvanctionOptionsButton
      '
      Me._pdfAdvanctionOptionsButton.Location = New System.Drawing.Point(190, 68)
      Me._pdfAdvanctionOptionsButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._pdfAdvanctionOptionsButton.Name = "_pdfAdvanctionOptionsButton"
      Me._pdfAdvanctionOptionsButton.Size = New System.Drawing.Size(338, 35)
      Me._pdfAdvanctionOptionsButton.TabIndex = 2
      Me._pdfAdvanctionOptionsButton.Text = "Advanced Options..."
      Me._pdfAdvanctionOptionsButton.UseVisualStyleBackColor = True
      '
      '_pdfImageOverTextCheckBox
      '
      Me._pdfImageOverTextCheckBox.AutoSize = True
      Me._pdfImageOverTextCheckBox.Location = New System.Drawing.Point(190, 112)
      Me._pdfImageOverTextCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._pdfImageOverTextCheckBox.Name = "_pdfImageOverTextCheckBox"
      Me._pdfImageOverTextCheckBox.Size = New System.Drawing.Size(144, 24)
      Me._pdfImageOverTextCheckBox.TabIndex = 3
      Me._pdfImageOverTextCheckBox.Text = "Image over text"
      Me._pdfImageOverTextCheckBox.UseVisualStyleBackColor = True
      '
      '_pdfDocumentTypeComboBox
      '
      Me._pdfDocumentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._pdfDocumentTypeComboBox.FormattingEnabled = True
      Me._pdfDocumentTypeComboBox.Location = New System.Drawing.Point(190, 26)
      Me._pdfDocumentTypeComboBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._pdfDocumentTypeComboBox.Name = "_pdfDocumentTypeComboBox"
      Me._pdfDocumentTypeComboBox.Size = New System.Drawing.Size(336, 28)
      Me._pdfDocumentTypeComboBox.TabIndex = 1
      '
      '_pdfDocumentTypeLabel
      '
      Me._pdfDocumentTypeLabel.AutoSize = True
      Me._pdfDocumentTypeLabel.Location = New System.Drawing.Point(27, 31)
      Me._pdfDocumentTypeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._pdfDocumentTypeLabel.Name = "_pdfDocumentTypeLabel"
      Me._pdfDocumentTypeLabel.Size = New System.Drawing.Size(121, 20)
      Me._pdfDocumentTypeLabel.TabIndex = 0
      Me._pdfDocumentTypeLabel.Text = "Document type:"
      '
      '_docOptionsTabPage
      '
      Me._docOptionsTabPage.Controls.Add(Me._docOptionsDescriptionLabel)
      Me._docOptionsTabPage.Controls.Add(Me._docFramedCheckBox)
      Me._docOptionsTabPage.Location = New System.Drawing.Point(4, 29)
      Me._docOptionsTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._docOptionsTabPage.Name = "_docOptionsTabPage"
      Me._docOptionsTabPage.Size = New System.Drawing.Size(556, 418)
      Me._docOptionsTabPage.TabIndex = 1
      Me._docOptionsTabPage.Text = "DOC options"
      Me._docOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_docOptionsDescriptionLabel
      '
      Me._docOptionsDescriptionLabel.Location = New System.Drawing.Point(26, 62)
      Me._docOptionsDescriptionLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._docOptionsDescriptionLabel.Name = "_docOptionsDescriptionLabel"
      Me._docOptionsDescriptionLabel.Size = New System.Drawing.Size(508, 88)
      Me._docOptionsDescriptionLabel.TabIndex = 7
      Me._docOptionsDescriptionLabel.Text = resources.GetString("_docOptionsDescriptionLabel.Text")
      '
      '_docFramedCheckBox
      '
      Me._docFramedCheckBox.AutoSize = True
      Me._docFramedCheckBox.Location = New System.Drawing.Point(30, 31)
      Me._docFramedCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._docFramedCheckBox.Name = "_docFramedCheckBox"
      Me._docFramedCheckBox.Size = New System.Drawing.Size(111, 24)
      Me._docFramedCheckBox.TabIndex = 5
      Me._docFramedCheckBox.Text = "Frame text"
      Me._docFramedCheckBox.UseVisualStyleBackColor = True
      '
      '_rtfOptionsTabPage
      '
      Me._rtfOptionsTabPage.Controls.Add(Me._rtfOptionsDescriptionLabel)
      Me._rtfOptionsTabPage.Controls.Add(Me._rtfFramedCheckBox)
      Me._rtfOptionsTabPage.Location = New System.Drawing.Point(4, 29)
      Me._rtfOptionsTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._rtfOptionsTabPage.Name = "_rtfOptionsTabPage"
      Me._rtfOptionsTabPage.Size = New System.Drawing.Size(556, 418)
      Me._rtfOptionsTabPage.TabIndex = 2
      Me._rtfOptionsTabPage.Text = "RTF options"
      Me._rtfOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_rtfOptionsDescriptionLabel
      '
      Me._rtfOptionsDescriptionLabel.Location = New System.Drawing.Point(26, 62)
      Me._rtfOptionsDescriptionLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._rtfOptionsDescriptionLabel.Name = "_rtfOptionsDescriptionLabel"
      Me._rtfOptionsDescriptionLabel.Size = New System.Drawing.Size(508, 88)
      Me._rtfOptionsDescriptionLabel.TabIndex = 8
      Me._rtfOptionsDescriptionLabel.Text = resources.GetString("_rtfOptionsDescriptionLabel.Text")
      '
      '_rtfFramedCheckBox
      '
      Me._rtfFramedCheckBox.AutoSize = True
      Me._rtfFramedCheckBox.Location = New System.Drawing.Point(30, 31)
      Me._rtfFramedCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._rtfFramedCheckBox.Name = "_rtfFramedCheckBox"
      Me._rtfFramedCheckBox.Size = New System.Drawing.Size(111, 24)
      Me._rtfFramedCheckBox.TabIndex = 6
      Me._rtfFramedCheckBox.Text = "Frame text"
      Me._rtfFramedCheckBox.UseVisualStyleBackColor = True
      '
      '_htmlOptionsTabPage
      '
      Me._htmlOptionsTabPage.Controls.Add(Me._htmlBackgroundColorButton)
      Me._htmlOptionsTabPage.Controls.Add(Me._htmlBackgroundColorValueLabel)
      Me._htmlOptionsTabPage.Controls.Add(Me._htmlBackgroundColorLabel)
      Me._htmlOptionsTabPage.Controls.Add(Me._htmlUseBackgroundColorCheckBox)
      Me._htmlOptionsTabPage.Controls.Add(Me._htmlEmbedFontModeComboBox)
      Me._htmlOptionsTabPage.Controls.Add(Me._htmlEmbedFontModeLabel)
      Me._htmlOptionsTabPage.Location = New System.Drawing.Point(4, 29)
      Me._htmlOptionsTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._htmlOptionsTabPage.Name = "_htmlOptionsTabPage"
      Me._htmlOptionsTabPage.Size = New System.Drawing.Size(556, 418)
      Me._htmlOptionsTabPage.TabIndex = 3
      Me._htmlOptionsTabPage.Text = "HTML options"
      Me._htmlOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_htmlBackgroundColorButton
      '
      Me._htmlBackgroundColorButton.Location = New System.Drawing.Point(273, 102)
      Me._htmlBackgroundColorButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._htmlBackgroundColorButton.Name = "_htmlBackgroundColorButton"
      Me._htmlBackgroundColorButton.Size = New System.Drawing.Size(42, 35)
      Me._htmlBackgroundColorButton.TabIndex = 12
      Me._htmlBackgroundColorButton.Text = "..."
      Me._htmlBackgroundColorButton.UseVisualStyleBackColor = True
      '
      '_htmlBackgroundColorValueLabel
      '
      Me._htmlBackgroundColorValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._htmlBackgroundColorValueLabel.Location = New System.Drawing.Point(189, 102)
      Me._htmlBackgroundColorValueLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._htmlBackgroundColorValueLabel.Name = "_htmlBackgroundColorValueLabel"
      Me._htmlBackgroundColorValueLabel.Size = New System.Drawing.Size(74, 34)
      Me._htmlBackgroundColorValueLabel.TabIndex = 11
      '
      '_htmlBackgroundColorLabel
      '
      Me._htmlBackgroundColorLabel.AutoSize = True
      Me._htmlBackgroundColorLabel.Location = New System.Drawing.Point(21, 109)
      Me._htmlBackgroundColorLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._htmlBackgroundColorLabel.Name = "_htmlBackgroundColorLabel"
      Me._htmlBackgroundColorLabel.Size = New System.Drawing.Size(137, 20)
      Me._htmlBackgroundColorLabel.TabIndex = 10
      Me._htmlBackgroundColorLabel.Text = "Background color:"
      '
      '_htmlUseBackgroundColorCheckBox
      '
      Me._htmlUseBackgroundColorCheckBox.AutoSize = True
      Me._htmlUseBackgroundColorCheckBox.Location = New System.Drawing.Point(189, 65)
      Me._htmlUseBackgroundColorCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._htmlUseBackgroundColorCheckBox.Name = "_htmlUseBackgroundColorCheckBox"
      Me._htmlUseBackgroundColorCheckBox.Size = New System.Drawing.Size(190, 24)
      Me._htmlUseBackgroundColorCheckBox.TabIndex = 9
      Me._htmlUseBackgroundColorCheckBox.Text = "Use background color"
      Me._htmlUseBackgroundColorCheckBox.UseVisualStyleBackColor = True
      '
      '_htmlEmbedFontModeComboBox
      '
      Me._htmlEmbedFontModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._htmlEmbedFontModeComboBox.FormattingEnabled = True
      Me._htmlEmbedFontModeComboBox.Location = New System.Drawing.Point(189, 28)
      Me._htmlEmbedFontModeComboBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._htmlEmbedFontModeComboBox.Name = "_htmlEmbedFontModeComboBox"
      Me._htmlEmbedFontModeComboBox.Size = New System.Drawing.Size(336, 28)
      Me._htmlEmbedFontModeComboBox.TabIndex = 8
      '
      '_htmlEmbedFontModeLabel
      '
      Me._htmlEmbedFontModeLabel.AutoSize = True
      Me._htmlEmbedFontModeLabel.Location = New System.Drawing.Point(32, 29)
      Me._htmlEmbedFontModeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._htmlEmbedFontModeLabel.Name = "_htmlEmbedFontModeLabel"
      Me._htmlEmbedFontModeLabel.Size = New System.Drawing.Size(140, 20)
      Me._htmlEmbedFontModeLabel.TabIndex = 7
      Me._htmlEmbedFontModeLabel.Text = "Embed font mode:"
      '
      '_textOptionsTabPage
      '
      Me._textOptionsTabPage.Controls.Add(Me._textFormattedCheckBox)
      Me._textOptionsTabPage.Controls.Add(Me._textAddPageBreakCheckBox)
      Me._textOptionsTabPage.Controls.Add(Me._textAddPageNumberCheckBox)
      Me._textOptionsTabPage.Controls.Add(Me._textDocumentTypeComboBox)
      Me._textOptionsTabPage.Controls.Add(Me._textDocumentTypeLabel)
      Me._textOptionsTabPage.Location = New System.Drawing.Point(4, 29)
      Me._textOptionsTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._textOptionsTabPage.Name = "_textOptionsTabPage"
      Me._textOptionsTabPage.Size = New System.Drawing.Size(556, 418)
      Me._textOptionsTabPage.TabIndex = 4
      Me._textOptionsTabPage.Text = "Text options"
      Me._textOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_textFormattedCheckBox
      '
      Me._textFormattedCheckBox.AutoSize = True
      Me._textFormattedCheckBox.Location = New System.Drawing.Point(192, 138)
      Me._textFormattedCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._textFormattedCheckBox.Name = "_textFormattedCheckBox"
      Me._textFormattedCheckBox.Size = New System.Drawing.Size(109, 24)
      Me._textFormattedCheckBox.TabIndex = 19
      Me._textFormattedCheckBox.Text = "Formatted"
      Me._textFormattedCheckBox.UseVisualStyleBackColor = True
      '
      '_textAddPageBreakCheckBox
      '
      Me._textAddPageBreakCheckBox.AutoSize = True
      Me._textAddPageBreakCheckBox.Location = New System.Drawing.Point(192, 103)
      Me._textAddPageBreakCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._textAddPageBreakCheckBox.Name = "_textAddPageBreakCheckBox"
      Me._textAddPageBreakCheckBox.Size = New System.Drawing.Size(148, 24)
      Me._textAddPageBreakCheckBox.TabIndex = 18
      Me._textAddPageBreakCheckBox.Text = "Add page break"
      Me._textAddPageBreakCheckBox.UseVisualStyleBackColor = True
      '
      '_textAddPageNumberCheckBox
      '
      Me._textAddPageNumberCheckBox.AutoSize = True
      Me._textAddPageNumberCheckBox.Location = New System.Drawing.Point(192, 68)
      Me._textAddPageNumberCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._textAddPageNumberCheckBox.Name = "_textAddPageNumberCheckBox"
      Me._textAddPageNumberCheckBox.Size = New System.Drawing.Size(162, 24)
      Me._textAddPageNumberCheckBox.TabIndex = 17
      Me._textAddPageNumberCheckBox.Text = "Add page number"
      Me._textAddPageNumberCheckBox.UseVisualStyleBackColor = True
      '
      '_textDocumentTypeComboBox
      '
      Me._textDocumentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._textDocumentTypeComboBox.FormattingEnabled = True
      Me._textDocumentTypeComboBox.Location = New System.Drawing.Point(192, 26)
      Me._textDocumentTypeComboBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._textDocumentTypeComboBox.Name = "_textDocumentTypeComboBox"
      Me._textDocumentTypeComboBox.Size = New System.Drawing.Size(336, 28)
      Me._textDocumentTypeComboBox.TabIndex = 14
      '
      '_textDocumentTypeLabel
      '
      Me._textDocumentTypeLabel.AutoSize = True
      Me._textDocumentTypeLabel.Location = New System.Drawing.Point(27, 31)
      Me._textDocumentTypeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._textDocumentTypeLabel.Name = "_textDocumentTypeLabel"
      Me._textDocumentTypeLabel.Size = New System.Drawing.Size(121, 20)
      Me._textDocumentTypeLabel.TabIndex = 13
      Me._textDocumentTypeLabel.Text = "Document type:"
      '
      '_docxOptionsTabPage
      '
      Me._docxOptionsTabPage.Controls.Add(Me._docxOptionsDescriptionLabel)
      Me._docxOptionsTabPage.Controls.Add(Me._docxFramedCheckBox)
      Me._docxOptionsTabPage.Location = New System.Drawing.Point(4, 29)
      Me._docxOptionsTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._docxOptionsTabPage.Name = "_docxOptionsTabPage"
      Me._docxOptionsTabPage.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._docxOptionsTabPage.Size = New System.Drawing.Size(556, 418)
      Me._docxOptionsTabPage.TabIndex = 8
      Me._docxOptionsTabPage.Text = "DOCX options"
      Me._docxOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_docxOptionsDescriptionLabel
      '
      Me._docxOptionsDescriptionLabel.Location = New System.Drawing.Point(26, 62)
      Me._docxOptionsDescriptionLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._docxOptionsDescriptionLabel.Name = "_docxOptionsDescriptionLabel"
      Me._docxOptionsDescriptionLabel.Size = New System.Drawing.Size(508, 88)
      Me._docxOptionsDescriptionLabel.TabIndex = 7
      Me._docxOptionsDescriptionLabel.Text = resources.GetString("_docxOptionsDescriptionLabel.Text")
      '
      '_docxFramedCheckBox
      '
      Me._docxFramedCheckBox.AutoSize = True
      Me._docxFramedCheckBox.Location = New System.Drawing.Point(30, 31)
      Me._docxFramedCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._docxFramedCheckBox.Name = "_docxFramedCheckBox"
      Me._docxFramedCheckBox.Size = New System.Drawing.Size(111, 24)
      Me._docxFramedCheckBox.TabIndex = 6
      Me._docxFramedCheckBox.Text = "&Frame text"
      Me._docxFramedCheckBox.UseVisualStyleBackColor = True
      '
      '_altoXmlOptionsTabPage
      '
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlMeasurementUnitComboBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlMeasurementUnitLabel)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlShowGlyphVariantsCheckBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlShowGlyphInfoCheckBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlPlainTextCheckBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlSortCheckBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlApplicationDescriptionTextBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlApplicationDescriptionLabel)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlSoftwareNameTextBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlSoftwareNameLabel)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlSoftwareCreatorTextBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlSoftwareCreatorLabel)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlFileNameTextBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlFileNameLabel)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlIndentationTextBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlIndentationLabel)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlFormattedCheckBox)
      Me._altoXmlOptionsTabPage.Location = New System.Drawing.Point(4, 29)
      Me._altoXmlOptionsTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlOptionsTabPage.Name = "_altoXmlOptionsTabPage"
      Me._altoXmlOptionsTabPage.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlOptionsTabPage.Size = New System.Drawing.Size(556, 474)
      Me._altoXmlOptionsTabPage.TabIndex = 9
      Me._altoXmlOptionsTabPage.Text = "ALTOXML options"
      Me._altoXmlOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_altoXmlShowGlyphVariantsCheckBox
      '
      Me._altoXmlShowGlyphVariantsCheckBox.AutoSize = True
      Me._altoXmlShowGlyphVariantsCheckBox.Location = New System.Drawing.Point(28, 404)
      Me._altoXmlShowGlyphVariantsCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlShowGlyphVariantsCheckBox.Name = "_altoXmlShowGlyphVariantsCheckBox"
      Me._altoXmlShowGlyphVariantsCheckBox.Size = New System.Drawing.Size(175, 24)
      Me._altoXmlShowGlyphVariantsCheckBox.TabIndex = 16
      Me._altoXmlShowGlyphVariantsCheckBox.Text = "Show glyph variants"
      Me._altoXmlShowGlyphVariantsCheckBox.UseVisualStyleBackColor = True
      '
      '_altoXmlShowGlyphInfoCheckBox
      '
      Me._altoXmlShowGlyphInfoCheckBox.AutoSize = True
      Me._altoXmlShowGlyphInfoCheckBox.Location = New System.Drawing.Point(28, 366)
      Me._altoXmlShowGlyphInfoCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlShowGlyphInfoCheckBox.Name = "_altoXmlShowGlyphInfoCheckBox"
      Me._altoXmlShowGlyphInfoCheckBox.Size = New System.Drawing.Size(146, 24)
      Me._altoXmlShowGlyphInfoCheckBox.TabIndex = 15
      Me._altoXmlShowGlyphInfoCheckBox.Text = "Show glyph info"
      Me._altoXmlShowGlyphInfoCheckBox.UseVisualStyleBackColor = True
      '
      '_altoXmlPlainTextCheckBox
      '
      Me._altoXmlPlainTextCheckBox.AutoSize = True
      Me._altoXmlPlainTextCheckBox.Location = New System.Drawing.Point(28, 327)
      Me._altoXmlPlainTextCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlPlainTextCheckBox.Name = "_altoXmlPlainTextCheckBox"
      Me._altoXmlPlainTextCheckBox.Size = New System.Drawing.Size(99, 24)
      Me._altoXmlPlainTextCheckBox.TabIndex = 14
      Me._altoXmlPlainTextCheckBox.Text = "Plain text"
      Me._altoXmlPlainTextCheckBox.UseVisualStyleBackColor = True
      '
      '_altoXmlSortCheckBox
      '
      Me._altoXmlSortCheckBox.AutoSize = True
      Me._altoXmlSortCheckBox.Location = New System.Drawing.Point(28, 289)
      Me._altoXmlSortCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlSortCheckBox.Name = "_altoXmlSortCheckBox"
      Me._altoXmlSortCheckBox.Size = New System.Drawing.Size(65, 24)
      Me._altoXmlSortCheckBox.TabIndex = 13
      Me._altoXmlSortCheckBox.Text = "Sort"
      Me._altoXmlSortCheckBox.UseVisualStyleBackColor = True
      '
      '_altoXmlApplicationDescriptionTextBox
      '
      Me._altoXmlApplicationDescriptionTextBox.Location = New System.Drawing.Point(207, 177)
      Me._altoXmlApplicationDescriptionTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlApplicationDescriptionTextBox.Name = "_altoXmlApplicationDescriptionTextBox"
      Me._altoXmlApplicationDescriptionTextBox.Size = New System.Drawing.Size(316, 26)
      Me._altoXmlApplicationDescriptionTextBox.TabIndex = 9
      '
      '_altoXmlApplicationDescriptionLabel
      '
      Me._altoXmlApplicationDescriptionLabel.AutoSize = True
      Me._altoXmlApplicationDescriptionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlApplicationDescriptionLabel.Location = New System.Drawing.Point(24, 181)
      Me._altoXmlApplicationDescriptionLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._altoXmlApplicationDescriptionLabel.Name = "_altoXmlApplicationDescriptionLabel"
      Me._altoXmlApplicationDescriptionLabel.Size = New System.Drawing.Size(172, 20)
      Me._altoXmlApplicationDescriptionLabel.TabIndex = 8
      Me._altoXmlApplicationDescriptionLabel.Text = "Application description:"
      '
      '_altoXmlSoftwareNameTextBox
      '
      Me._altoXmlSoftwareNameTextBox.Location = New System.Drawing.Point(207, 137)
      Me._altoXmlSoftwareNameTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlSoftwareNameTextBox.Name = "_altoXmlSoftwareNameTextBox"
      Me._altoXmlSoftwareNameTextBox.Size = New System.Drawing.Size(316, 26)
      Me._altoXmlSoftwareNameTextBox.TabIndex = 7
      '
      '_altoXmlSoftwareNameLabel
      '
      Me._altoXmlSoftwareNameLabel.AutoSize = True
      Me._altoXmlSoftwareNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlSoftwareNameLabel.Location = New System.Drawing.Point(24, 141)
      Me._altoXmlSoftwareNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._altoXmlSoftwareNameLabel.Name = "_altoXmlSoftwareNameLabel"
      Me._altoXmlSoftwareNameLabel.Size = New System.Drawing.Size(121, 20)
      Me._altoXmlSoftwareNameLabel.TabIndex = 6
      Me._altoXmlSoftwareNameLabel.Text = "Software name:"
      '
      '_altoXmlSoftwareCreatorTextBox
      '
      Me._altoXmlSoftwareCreatorTextBox.Location = New System.Drawing.Point(207, 97)
      Me._altoXmlSoftwareCreatorTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlSoftwareCreatorTextBox.Name = "_altoXmlSoftwareCreatorTextBox"
      Me._altoXmlSoftwareCreatorTextBox.Size = New System.Drawing.Size(316, 26)
      Me._altoXmlSoftwareCreatorTextBox.TabIndex = 5
      '
      '_altoXmlSoftwareCreatorLabel
      '
      Me._altoXmlSoftwareCreatorLabel.AutoSize = True
      Me._altoXmlSoftwareCreatorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlSoftwareCreatorLabel.Location = New System.Drawing.Point(24, 101)
      Me._altoXmlSoftwareCreatorLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._altoXmlSoftwareCreatorLabel.Name = "_altoXmlSoftwareCreatorLabel"
      Me._altoXmlSoftwareCreatorLabel.Size = New System.Drawing.Size(131, 20)
      Me._altoXmlSoftwareCreatorLabel.TabIndex = 4
      Me._altoXmlSoftwareCreatorLabel.Text = "Software creator:"
      '
      '_altoXmlFileNameTextBox
      '
      Me._altoXmlFileNameTextBox.Location = New System.Drawing.Point(207, 57)
      Me._altoXmlFileNameTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlFileNameTextBox.Name = "_altoXmlFileNameTextBox"
      Me._altoXmlFileNameTextBox.Size = New System.Drawing.Size(316, 26)
      Me._altoXmlFileNameTextBox.TabIndex = 3
      '
      '_altoXmlFileNameLabel
      '
      Me._altoXmlFileNameLabel.AutoSize = True
      Me._altoXmlFileNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlFileNameLabel.Location = New System.Drawing.Point(24, 61)
      Me._altoXmlFileNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._altoXmlFileNameLabel.Name = "_altoXmlFileNameLabel"
      Me._altoXmlFileNameLabel.Size = New System.Drawing.Size(82, 20)
      Me._altoXmlFileNameLabel.TabIndex = 2
      Me._altoXmlFileNameLabel.Text = "File name:"
      '
      '_altoXmlIndentationTextBox
      '
      Me._altoXmlIndentationTextBox.Location = New System.Drawing.Point(207, 249)
      Me._altoXmlIndentationTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlIndentationTextBox.Name = "_altoXmlIndentationTextBox"
      Me._altoXmlIndentationTextBox.Size = New System.Drawing.Size(316, 26)
      Me._altoXmlIndentationTextBox.TabIndex = 12
      '
      '_altoXmlIndentationLabel
      '
      Me._altoXmlIndentationLabel.AutoSize = True
      Me._altoXmlIndentationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlIndentationLabel.Location = New System.Drawing.Point(56, 253)
      Me._altoXmlIndentationLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._altoXmlIndentationLabel.Name = "_altoXmlIndentationLabel"
      Me._altoXmlIndentationLabel.Size = New System.Drawing.Size(94, 20)
      Me._altoXmlIndentationLabel.TabIndex = 11
      Me._altoXmlIndentationLabel.Text = "Indentation:"
      '
      '_altoXmlFormattedCheckBox
      '
      Me._altoXmlFormattedCheckBox.AutoSize = True
      Me._altoXmlFormattedCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlFormattedCheckBox.Location = New System.Drawing.Point(28, 223)
      Me._altoXmlFormattedCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlFormattedCheckBox.Name = "_altoXmlFormattedCheckBox"
      Me._altoXmlFormattedCheckBox.Size = New System.Drawing.Size(109, 24)
      Me._altoXmlFormattedCheckBox.TabIndex = 10
      Me._altoXmlFormattedCheckBox.Text = "Formatted"
      Me._altoXmlFormattedCheckBox.UseVisualStyleBackColor = True
      '
      '_emptyOptionsTabPage
      '
      Me._emptyOptionsTabPage.Controls.Add(Me._emptyOptionsLabel)
      Me._emptyOptionsTabPage.Location = New System.Drawing.Point(4, 29)
      Me._emptyOptionsTabPage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._emptyOptionsTabPage.Name = "_emptyOptionsTabPage"
      Me._emptyOptionsTabPage.Size = New System.Drawing.Size(556, 418)
      Me._emptyOptionsTabPage.TabIndex = 10
      Me._emptyOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_emptyOptionsLabel
      '
      Me._emptyOptionsLabel.AutoSize = True
      Me._emptyOptionsLabel.Location = New System.Drawing.Point(21, 26)
      Me._emptyOptionsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._emptyOptionsLabel.Name = "_emptyOptionsLabel"
      Me._emptyOptionsLabel.Size = New System.Drawing.Size(235, 20)
      Me._emptyOptionsLabel.TabIndex = 2
      Me._emptyOptionsLabel.Text = "This format has no extra options"
      '
      '_altoXmlMeasurementUnitComboBox
      '
      Me._altoXmlMeasurementUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._altoXmlMeasurementUnitComboBox.FormattingEnabled = True
      Me._altoXmlMeasurementUnitComboBox.Location = New System.Drawing.Point(207, 16)
      Me._altoXmlMeasurementUnitComboBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._altoXmlMeasurementUnitComboBox.Name = "_altoXmlMeasurementUnitComboBox"
      Me._altoXmlMeasurementUnitComboBox.Size = New System.Drawing.Size(316, 28)
      Me._altoXmlMeasurementUnitComboBox.TabIndex = 1
      '
      '_altoXmlMeasurementUnitLabel
      '
      Me._altoXmlMeasurementUnitLabel.AutoSize = True
      Me._altoXmlMeasurementUnitLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlMeasurementUnitLabel.Location = New System.Drawing.Point(24, 23)
      Me._altoXmlMeasurementUnitLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me._altoXmlMeasurementUnitLabel.Name = "_altoXmlMeasurementUnitLabel"
      Me._altoXmlMeasurementUnitLabel.Size = New System.Drawing.Size(141, 20)
      Me._altoXmlMeasurementUnitLabel.TabIndex = 0
      Me._altoXmlMeasurementUnitLabel.Text = "Measurement unit:"
      '
      'DocumentFormatOptionsDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(748, 541)
      Me.Controls.Add(Me._optionsTabControl)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DocumentFormatOptionsDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "DocumentFormatOptionsDialog"
      Me._optionsTabControl.ResumeLayout(False)
      Me._ldOptionsTabPage.ResumeLayout(False)
      Me._ldOptionsTabPage.PerformLayout()
      Me._emfOptionsTabPage.ResumeLayout(False)
      Me._emfOptionsTabPage.PerformLayout()
      Me._pdfOptionsTabPage.ResumeLayout(False)
      Me._pdfOptionsTabPage.PerformLayout()
      Me._docOptionsTabPage.ResumeLayout(False)
      Me._docOptionsTabPage.PerformLayout()
      Me._rtfOptionsTabPage.ResumeLayout(False)
      Me._rtfOptionsTabPage.PerformLayout()
      Me._htmlOptionsTabPage.ResumeLayout(False)
      Me._htmlOptionsTabPage.PerformLayout()
      Me._textOptionsTabPage.ResumeLayout(False)
      Me._textOptionsTabPage.PerformLayout()
      Me._docxOptionsTabPage.ResumeLayout(False)
      Me._docxOptionsTabPage.PerformLayout()
      Me._altoXmlOptionsTabPage.ResumeLayout(False)
      Me._altoXmlOptionsTabPage.PerformLayout()
      Me._emptyOptionsTabPage.ResumeLayout(False)
      Me._emptyOptionsTabPage.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _cancelButton As System.Windows.Forms.Button
   Private _optionsTabControl As System.Windows.Forms.TabControl
   Private _ldOptionsTabPage As System.Windows.Forms.TabPage
   Private _ldOptionsNoteLabel As System.Windows.Forms.Label
   Private _emfOptionsTabPage As System.Windows.Forms.TabPage
   Private _emfOptionsNoteLabel As System.Windows.Forms.Label
   Private _pdfOptionsTabPage As System.Windows.Forms.TabPage
   Private WithEvents _pdfImageOverTextCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _pdfDocumentTypeComboBox As System.Windows.Forms.ComboBox
   Private _pdfDocumentTypeLabel As System.Windows.Forms.Label
   Private _docOptionsTabPage As System.Windows.Forms.TabPage
   Private _docFramedCheckBox As System.Windows.Forms.CheckBox
   Private _rtfOptionsTabPage As System.Windows.Forms.TabPage
   Private _rtfFramedCheckBox As System.Windows.Forms.CheckBox
   Private _htmlOptionsTabPage As System.Windows.Forms.TabPage
   Private WithEvents _htmlBackgroundColorButton As System.Windows.Forms.Button
   Private _htmlBackgroundColorValueLabel As System.Windows.Forms.Label
   Private _htmlBackgroundColorLabel As System.Windows.Forms.Label
   Private WithEvents _htmlUseBackgroundColorCheckBox As System.Windows.Forms.CheckBox
   Private _htmlEmbedFontModeComboBox As System.Windows.Forms.ComboBox
   Private _htmlEmbedFontModeLabel As System.Windows.Forms.Label
   Private _textOptionsTabPage As System.Windows.Forms.TabPage
   Private _textFormattedCheckBox As System.Windows.Forms.CheckBox
   Private _textAddPageBreakCheckBox As System.Windows.Forms.CheckBox
   Private _textAddPageNumberCheckBox As System.Windows.Forms.CheckBox
   Private _textDocumentTypeComboBox As System.Windows.Forms.ComboBox
   Private _textDocumentTypeLabel As System.Windows.Forms.Label
   Private WithEvents _pdfAdvanctionOptionsButton As System.Windows.Forms.Button
   Private _docOptionsDescriptionLabel As System.Windows.Forms.Label
   Private _rtfOptionsDescriptionLabel As System.Windows.Forms.Label
   Private _docxOptionsTabPage As System.Windows.Forms.TabPage
   Private _docxOptionsDescriptionLabel As System.Windows.Forms.Label
   Private _docxFramedCheckBox As System.Windows.Forms.CheckBox
   Private _altoXmlOptionsTabPage As System.Windows.Forms.TabPage
   Private _altoXmlApplicationDescriptionTextBox As System.Windows.Forms.TextBox
   Private _altoXmlApplicationDescriptionLabel As System.Windows.Forms.Label
   Private _altoXmlSoftwareNameTextBox As System.Windows.Forms.TextBox
   Private _altoXmlSoftwareNameLabel As System.Windows.Forms.Label
   Private _altoXmlSoftwareCreatorTextBox As System.Windows.Forms.TextBox
   Private _altoXmlSoftwareCreatorLabel As System.Windows.Forms.Label
   Private _altoXmlFileNameTextBox As System.Windows.Forms.TextBox
   Private _altoXmlFileNameLabel As System.Windows.Forms.Label
   Private _altoXmlIndentationTextBox As System.Windows.Forms.TextBox
   Private _altoXmlIndentationLabel As System.Windows.Forms.Label
   Private WithEvents _altoXmlFormattedCheckBox As System.Windows.Forms.CheckBox
   Private _emptyOptionsTabPage As System.Windows.Forms.TabPage
   Private _emptyOptionsLabel As System.Windows.Forms.Label
   Private WithEvents _pdfLinearizedCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _altoXmlShowGlyphVariantsCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _altoXmlShowGlyphInfoCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _altoXmlPlainTextCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents _altoXmlSortCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _altoXmlMeasurementUnitComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _altoXmlMeasurementUnitLabel As System.Windows.Forms.Label
End Class
