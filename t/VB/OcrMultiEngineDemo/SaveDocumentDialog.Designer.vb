Namespace OcrMultiEngineDemo
   Partial Class SaveDocumentDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveDocumentDialog))
         Me._okButton = New System.Windows.Forms.Button()
         Me._cancelButton = New System.Windows.Forms.Button()
         Me._outputGroupBox = New System.Windows.Forms.GroupBox()
         Me._optionsTabControl = New System.Windows.Forms.TabControl()
         Me._ldOptionsTabPage = New System.Windows.Forms.TabPage()
         Me._ltfOptionsNoteLabel = New System.Windows.Forms.Label()
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
         Me.label1 = New System.Windows.Forms.Label()
         Me._cbFramedDoc = New System.Windows.Forms.CheckBox()
         Me._rtfOptionsTabPage = New System.Windows.Forms.TabPage()
         Me.label2 = New System.Windows.Forms.Label()
         Me._cbFramedRtf = New System.Windows.Forms.CheckBox()
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
         Me._userOptionsTabPage = New System.Windows.Forms.TabPage()
         Me._userFormatNameComboBox = New System.Windows.Forms.ComboBox()
         Me._userFormatNameLabel = New System.Windows.Forms.Label()
         Me._xpsOptionsTabPage = New System.Windows.Forms.TabPage()
         Me.label4 = New System.Windows.Forms.Label()
         Me._docxOptionsTabPage = New System.Windows.Forms.TabPage()
         Me.label3 = New System.Windows.Forms.Label()
         Me._cbFramedDocX = New System.Windows.Forms.CheckBox()
         Me._xlsOptionsTabPage = New System.Windows.Forms.TabPage()
         Me._xlsOptionsNoteLabel = New System.Windows.Forms.Label()
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
         Me._ePubOptionsTabPage = New System.Windows.Forms.TabPage()
         Me._ePubOptionsNoteLabel = New System.Windows.Forms.Label()
         Me._mobOptionsTabPage = New System.Windows.Forms.TabPage()
         Me._mobOptionsNoteLabel = New System.Windows.Forms.Label()
         Me._svgOptionsTabPage = New System.Windows.Forms.TabPage()
         Me._svgOptionsNoteLabel = New System.Windows.Forms.Label()
         Me._formatComboBox = New System.Windows.Forms.ComboBox()
         Me._formatLabel = New System.Windows.Forms.Label()
         Me._browseButton = New System.Windows.Forms.Button()
         Me._fileNameTextBox = New System.Windows.Forms.TextBox()
         Me._fileNameLabel = New System.Windows.Forms.Label()
         Me._xpsOptionsNoteLabel = New System.Windows.Forms.Label()
         Me._viewDocumentCheckBox = New System.Windows.Forms.CheckBox()
         Me._altoXmlMeasurementUnit = New System.Windows.Forms.ComboBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me._outputGroupBox.SuspendLayout()
         Me._optionsTabControl.SuspendLayout()
         Me._ldOptionsTabPage.SuspendLayout()
         Me._emfOptionsTabPage.SuspendLayout()
         Me._pdfOptionsTabPage.SuspendLayout()
         Me._docOptionsTabPage.SuspendLayout()
         Me._rtfOptionsTabPage.SuspendLayout()
         Me._htmlOptionsTabPage.SuspendLayout()
         Me._textOptionsTabPage.SuspendLayout()
         Me._userOptionsTabPage.SuspendLayout()
         Me._xpsOptionsTabPage.SuspendLayout()
         Me._docxOptionsTabPage.SuspendLayout()
         Me._xlsOptionsTabPage.SuspendLayout()
         Me._altoXmlOptionsTabPage.SuspendLayout()
         Me._ePubOptionsTabPage.SuspendLayout()
         Me._mobOptionsTabPage.SuspendLayout()
         Me._svgOptionsTabPage.SuspendLayout()
         Me.SuspendLayout()
         '
         '_okButton
         '
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._okButton.Location = New System.Drawing.Point(452, 23)
         Me._okButton.Name = "_okButton"
         Me._okButton.Size = New System.Drawing.Size(75, 23)
         Me._okButton.TabIndex = 3
         Me._okButton.Text = "OK"
         Me._okButton.UseVisualStyleBackColor = True
         '
         '_cancelButton
         '
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._cancelButton.Location = New System.Drawing.Point(452, 52)
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.Size = New System.Drawing.Size(75, 23)
         Me._cancelButton.TabIndex = 4
         Me._cancelButton.Text = "Cancel"
         Me._cancelButton.UseVisualStyleBackColor = True
         '
         '_outputGroupBox
         '
         Me._outputGroupBox.Controls.Add(Me._optionsTabControl)
         Me._outputGroupBox.Controls.Add(Me._formatComboBox)
         Me._outputGroupBox.Controls.Add(Me._formatLabel)
         Me._outputGroupBox.Controls.Add(Me._browseButton)
         Me._outputGroupBox.Controls.Add(Me._fileNameTextBox)
         Me._outputGroupBox.Controls.Add(Me._fileNameLabel)
         Me._outputGroupBox.Location = New System.Drawing.Point(12, 12)
         Me._outputGroupBox.Name = "_outputGroupBox"
         Me._outputGroupBox.Size = New System.Drawing.Size(423, 432)
         Me._outputGroupBox.TabIndex = 0
         Me._outputGroupBox.TabStop = False
         Me._outputGroupBox.Text = "Output:"
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
         Me._optionsTabControl.Controls.Add(Me._userOptionsTabPage)
         Me._optionsTabControl.Controls.Add(Me._xpsOptionsTabPage)
         Me._optionsTabControl.Controls.Add(Me._docxOptionsTabPage)
         Me._optionsTabControl.Controls.Add(Me._xlsOptionsTabPage)
         Me._optionsTabControl.Controls.Add(Me._altoXmlOptionsTabPage)
         Me._optionsTabControl.Controls.Add(Me._ePubOptionsTabPage)
         Me._optionsTabControl.Controls.Add(Me._mobOptionsTabPage)
         Me._optionsTabControl.Controls.Add(Me._svgOptionsTabPage)
         Me._optionsTabControl.Location = New System.Drawing.Point(22, 96)
         Me._optionsTabControl.Name = "_optionsTabControl"
         Me._optionsTabControl.SelectedIndex = 0
         Me._optionsTabControl.Size = New System.Drawing.Size(376, 330)
         Me._optionsTabControl.TabIndex = 5
         '
         '_ldOptionsTabPage
         '
         Me._ldOptionsTabPage.Controls.Add(Me._ltfOptionsNoteLabel)
         Me._ldOptionsTabPage.Controls.Add(Me._ldOptionsNoteLabel)
         Me._ldOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._ldOptionsTabPage.Name = "_ldOptionsTabPage"
         Me._ldOptionsTabPage.Size = New System.Drawing.Size(368, 304)
         Me._ldOptionsTabPage.TabIndex = 7
         Me._ldOptionsTabPage.Text = "LTD Options"
         Me._ldOptionsTabPage.UseVisualStyleBackColor = True
         '
         '_ltfOptionsNoteLabel
         '
         Me._ltfOptionsNoteLabel.AutoSize = True
         Me._ltfOptionsNoteLabel.Location = New System.Drawing.Point(3, 12)
         Me._ltfOptionsNoteLabel.Name = "_ltfOptionsNoteLabel"
         Me._ltfOptionsNoteLabel.Size = New System.Drawing.Size(341, 130)
         Me._ltfOptionsNoteLabel.TabIndex = 2
         Me._ltfOptionsNoteLabel.Text = resources.GetString("_ltfOptionsNoteLabel.Text")
         '
         '_ldOptionsNoteLabel
         '
         Me._ldOptionsNoteLabel.AutoSize = True
         Me._ldOptionsNoteLabel.Location = New System.Drawing.Point(22, 12)
         Me._ldOptionsNoteLabel.Name = "_ldOptionsNoteLabel"
         Me._ldOptionsNoteLabel.Size = New System.Drawing.Size(0, 13)
         Me._ldOptionsNoteLabel.TabIndex = 1
         '
         '_emfOptionsTabPage
         '
         Me._emfOptionsTabPage.Controls.Add(Me._emfOptionsNoteLabel)
         Me._emfOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._emfOptionsTabPage.Name = "_emfOptionsTabPage"
         Me._emfOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._emfOptionsTabPage.TabIndex = 6
         Me._emfOptionsTabPage.Text = "EMF options"
         Me._emfOptionsTabPage.UseVisualStyleBackColor = True
         '
         '_emfOptionsNoteLabel
         '
         Me._emfOptionsNoteLabel.AutoSize = True
         Me._emfOptionsNoteLabel.Location = New System.Drawing.Point(13, 15)
         Me._emfOptionsNoteLabel.Name = "_emfOptionsNoteLabel"
         Me._emfOptionsNoteLabel.Size = New System.Drawing.Size(323, 39)
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
         Me._pdfOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._pdfOptionsTabPage.Name = "_pdfOptionsTabPage"
         Me._pdfOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._pdfOptionsTabPage.TabIndex = 0
         Me._pdfOptionsTabPage.Text = "PDF options"
         Me._pdfOptionsTabPage.UseVisualStyleBackColor = True
         '
         '_pdfLinearizedCheckBox
         '
         Me._pdfLinearizedCheckBox.AutoSize = True
         Me._pdfLinearizedCheckBox.Location = New System.Drawing.Point(127, 95)
         Me._pdfLinearizedCheckBox.Name = "_pdfLinearizedCheckBox"
         Me._pdfLinearizedCheckBox.Size = New System.Drawing.Size(154, 17)
         Me._pdfLinearizedCheckBox.TabIndex = 4
         Me._pdfLinearizedCheckBox.Text = "Fast web view (Linearized)"
         Me._pdfLinearizedCheckBox.UseVisualStyleBackColor = True
         '
         '_pdfAdvanctionOptionsButton
         '
         Me._pdfAdvanctionOptionsButton.Location = New System.Drawing.Point(127, 44)
         Me._pdfAdvanctionOptionsButton.Name = "_pdfAdvanctionOptionsButton"
         Me._pdfAdvanctionOptionsButton.Size = New System.Drawing.Size(225, 23)
         Me._pdfAdvanctionOptionsButton.TabIndex = 2
         Me._pdfAdvanctionOptionsButton.Text = "Advanced Options..."
         Me._pdfAdvanctionOptionsButton.UseVisualStyleBackColor = True
         '
         '_pdfImageOverTextCheckBox
         '
         Me._pdfImageOverTextCheckBox.AutoSize = True
         Me._pdfImageOverTextCheckBox.Location = New System.Drawing.Point(127, 73)
         Me._pdfImageOverTextCheckBox.Name = "_pdfImageOverTextCheckBox"
         Me._pdfImageOverTextCheckBox.Size = New System.Drawing.Size(104, 17)
         Me._pdfImageOverTextCheckBox.TabIndex = 3
         Me._pdfImageOverTextCheckBox.Text = "Image over text"
         Me._pdfImageOverTextCheckBox.UseVisualStyleBackColor = True
         '
         '_pdfDocumentTypeComboBox
         '
         Me._pdfDocumentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._pdfDocumentTypeComboBox.FormattingEnabled = True
         Me._pdfDocumentTypeComboBox.Location = New System.Drawing.Point(127, 17)
         Me._pdfDocumentTypeComboBox.Name = "_pdfDocumentTypeComboBox"
         Me._pdfDocumentTypeComboBox.Size = New System.Drawing.Size(225, 21)
         Me._pdfDocumentTypeComboBox.TabIndex = 1
         '
         '_pdfDocumentTypeLabel
         '
         Me._pdfDocumentTypeLabel.AutoSize = True
         Me._pdfDocumentTypeLabel.Location = New System.Drawing.Point(18, 20)
         Me._pdfDocumentTypeLabel.Name = "_pdfDocumentTypeLabel"
         Me._pdfDocumentTypeLabel.Size = New System.Drawing.Size(84, 13)
         Me._pdfDocumentTypeLabel.TabIndex = 0
         Me._pdfDocumentTypeLabel.Text = "Document type:"
         '
         '_docOptionsTabPage
         '
         Me._docOptionsTabPage.Controls.Add(Me.label1)
         Me._docOptionsTabPage.Controls.Add(Me._cbFramedDoc)
         Me._docOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._docOptionsTabPage.Name = "_docOptionsTabPage"
         Me._docOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._docOptionsTabPage.TabIndex = 1
         Me._docOptionsTabPage.Text = "DOC options"
         Me._docOptionsTabPage.UseVisualStyleBackColor = True
         '
         'label1
         '
         Me.label1.Location = New System.Drawing.Point(20, 40)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(339, 57)
         Me.label1.TabIndex = 3
         Me.label1.Text = resources.GetString("label1.Text")
         '
         '_cbFramedDoc
         '
         Me._cbFramedDoc.AutoSize = True
         Me._cbFramedDoc.Location = New System.Drawing.Point(20, 20)
         Me._cbFramedDoc.Name = "_cbFramedDoc"
         Me._cbFramedDoc.Size = New System.Drawing.Size(62, 17)
         Me._cbFramedDoc.TabIndex = 2
         Me._cbFramedDoc.Text = "&Framed"
         Me._cbFramedDoc.UseVisualStyleBackColor = True
         '
         '_rtfOptionsTabPage
         '
         Me._rtfOptionsTabPage.Controls.Add(Me.label2)
         Me._rtfOptionsTabPage.Controls.Add(Me._cbFramedRtf)
         Me._rtfOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._rtfOptionsTabPage.Name = "_rtfOptionsTabPage"
         Me._rtfOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._rtfOptionsTabPage.TabIndex = 2
         Me._rtfOptionsTabPage.Text = "RTF options"
         Me._rtfOptionsTabPage.UseVisualStyleBackColor = True
         '
         'label2
         '
         Me.label2.Location = New System.Drawing.Point(20, 40)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(339, 57)
         Me.label2.TabIndex = 5
         Me.label2.Text = resources.GetString("label2.Text")
         '
         '_cbFramedRtf
         '
         Me._cbFramedRtf.AutoSize = True
         Me._cbFramedRtf.Location = New System.Drawing.Point(20, 20)
         Me._cbFramedRtf.Name = "_cbFramedRtf"
         Me._cbFramedRtf.Size = New System.Drawing.Size(62, 17)
         Me._cbFramedRtf.TabIndex = 4
         Me._cbFramedRtf.Text = "&Framed"
         Me._cbFramedRtf.UseVisualStyleBackColor = True
         '
         '_htmlOptionsTabPage
         '
         Me._htmlOptionsTabPage.Controls.Add(Me._htmlBackgroundColorButton)
         Me._htmlOptionsTabPage.Controls.Add(Me._htmlBackgroundColorValueLabel)
         Me._htmlOptionsTabPage.Controls.Add(Me._htmlBackgroundColorLabel)
         Me._htmlOptionsTabPage.Controls.Add(Me._htmlUseBackgroundColorCheckBox)
         Me._htmlOptionsTabPage.Controls.Add(Me._htmlEmbedFontModeComboBox)
         Me._htmlOptionsTabPage.Controls.Add(Me._htmlEmbedFontModeLabel)
         Me._htmlOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._htmlOptionsTabPage.Name = "_htmlOptionsTabPage"
         Me._htmlOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._htmlOptionsTabPage.TabIndex = 3
         Me._htmlOptionsTabPage.Text = "HTML options"
         Me._htmlOptionsTabPage.UseVisualStyleBackColor = True
         '
         '_htmlBackgroundColorButton
         '
         Me._htmlBackgroundColorButton.Location = New System.Drawing.Point(183, 66)
         Me._htmlBackgroundColorButton.Name = "_htmlBackgroundColorButton"
         Me._htmlBackgroundColorButton.Size = New System.Drawing.Size(28, 23)
         Me._htmlBackgroundColorButton.TabIndex = 12
         Me._htmlBackgroundColorButton.Text = "..."
         Me._htmlBackgroundColorButton.UseVisualStyleBackColor = True
         '
         '_htmlBackgroundColorValueLabel
         '
         Me._htmlBackgroundColorValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._htmlBackgroundColorValueLabel.Location = New System.Drawing.Point(127, 66)
         Me._htmlBackgroundColorValueLabel.Name = "_htmlBackgroundColorValueLabel"
         Me._htmlBackgroundColorValueLabel.Size = New System.Drawing.Size(50, 23)
         Me._htmlBackgroundColorValueLabel.TabIndex = 11
         '
         '_htmlBackgroundColorLabel
         '
         Me._htmlBackgroundColorLabel.AutoSize = True
         Me._htmlBackgroundColorLabel.Location = New System.Drawing.Point(15, 71)
         Me._htmlBackgroundColorLabel.Name = "_htmlBackgroundColorLabel"
         Me._htmlBackgroundColorLabel.Size = New System.Drawing.Size(93, 13)
         Me._htmlBackgroundColorLabel.TabIndex = 10
         Me._htmlBackgroundColorLabel.Text = "Background color:"
         '
         '_htmlUseBackgroundColorCheckBox
         '
         Me._htmlUseBackgroundColorCheckBox.AutoSize = True
         Me._htmlUseBackgroundColorCheckBox.Location = New System.Drawing.Point(127, 42)
         Me._htmlUseBackgroundColorCheckBox.Name = "_htmlUseBackgroundColorCheckBox"
         Me._htmlUseBackgroundColorCheckBox.Size = New System.Drawing.Size(129, 17)
         Me._htmlUseBackgroundColorCheckBox.TabIndex = 9
         Me._htmlUseBackgroundColorCheckBox.Text = "Use background color"
         Me._htmlUseBackgroundColorCheckBox.UseVisualStyleBackColor = True
         '
         '_htmlEmbedFontModeComboBox
         '
         Me._htmlEmbedFontModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._htmlEmbedFontModeComboBox.FormattingEnabled = True
         Me._htmlEmbedFontModeComboBox.Location = New System.Drawing.Point(127, 18)
         Me._htmlEmbedFontModeComboBox.Name = "_htmlEmbedFontModeComboBox"
         Me._htmlEmbedFontModeComboBox.Size = New System.Drawing.Size(225, 21)
         Me._htmlEmbedFontModeComboBox.TabIndex = 8
         '
         '_htmlEmbedFontModeLabel
         '
         Me._htmlEmbedFontModeLabel.AutoSize = True
         Me._htmlEmbedFontModeLabel.Location = New System.Drawing.Point(21, 19)
         Me._htmlEmbedFontModeLabel.Name = "_htmlEmbedFontModeLabel"
         Me._htmlEmbedFontModeLabel.Size = New System.Drawing.Size(95, 13)
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
         Me._textOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._textOptionsTabPage.Name = "_textOptionsTabPage"
         Me._textOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._textOptionsTabPage.TabIndex = 4
         Me._textOptionsTabPage.Text = "Text options"
         Me._textOptionsTabPage.UseVisualStyleBackColor = True
         '
         '_textFormattedCheckBox
         '
         Me._textFormattedCheckBox.AutoSize = True
         Me._textFormattedCheckBox.Location = New System.Drawing.Point(128, 90)
         Me._textFormattedCheckBox.Name = "_textFormattedCheckBox"
         Me._textFormattedCheckBox.Size = New System.Drawing.Size(76, 17)
         Me._textFormattedCheckBox.TabIndex = 19
         Me._textFormattedCheckBox.Text = "Formatted"
         Me._textFormattedCheckBox.UseVisualStyleBackColor = True
         '
         '_textAddPageBreakCheckBox
         '
         Me._textAddPageBreakCheckBox.AutoSize = True
         Me._textAddPageBreakCheckBox.Location = New System.Drawing.Point(128, 67)
         Me._textAddPageBreakCheckBox.Name = "_textAddPageBreakCheckBox"
         Me._textAddPageBreakCheckBox.Size = New System.Drawing.Size(102, 17)
         Me._textAddPageBreakCheckBox.TabIndex = 18
         Me._textAddPageBreakCheckBox.Text = "Add page break"
         Me._textAddPageBreakCheckBox.UseVisualStyleBackColor = True
         '
         '_textAddPageNumberCheckBox
         '
         Me._textAddPageNumberCheckBox.AutoSize = True
         Me._textAddPageNumberCheckBox.Location = New System.Drawing.Point(128, 44)
         Me._textAddPageNumberCheckBox.Name = "_textAddPageNumberCheckBox"
         Me._textAddPageNumberCheckBox.Size = New System.Drawing.Size(111, 17)
         Me._textAddPageNumberCheckBox.TabIndex = 17
         Me._textAddPageNumberCheckBox.Text = "Add page number"
         Me._textAddPageNumberCheckBox.UseVisualStyleBackColor = True
         '
         '_textDocumentTypeComboBox
         '
         Me._textDocumentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._textDocumentTypeComboBox.FormattingEnabled = True
         Me._textDocumentTypeComboBox.Location = New System.Drawing.Point(128, 17)
         Me._textDocumentTypeComboBox.Name = "_textDocumentTypeComboBox"
         Me._textDocumentTypeComboBox.Size = New System.Drawing.Size(225, 21)
         Me._textDocumentTypeComboBox.TabIndex = 14
         '
         '_textDocumentTypeLabel
         '
         Me._textDocumentTypeLabel.AutoSize = True
         Me._textDocumentTypeLabel.Location = New System.Drawing.Point(18, 20)
         Me._textDocumentTypeLabel.Name = "_textDocumentTypeLabel"
         Me._textDocumentTypeLabel.Size = New System.Drawing.Size(84, 13)
         Me._textDocumentTypeLabel.TabIndex = 13
         Me._textDocumentTypeLabel.Text = "Document type:"
         '
         '_userOptionsTabPage
         '
         Me._userOptionsTabPage.Controls.Add(Me._userFormatNameComboBox)
         Me._userOptionsTabPage.Controls.Add(Me._userFormatNameLabel)
         Me._userOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._userOptionsTabPage.Name = "_userOptionsTabPage"
         Me._userOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._userOptionsTabPage.TabIndex = 5
         Me._userOptionsTabPage.Text = "Engine formats"
         Me._userOptionsTabPage.UseVisualStyleBackColor = True
         '
         '_userFormatNameComboBox
         '
         Me._userFormatNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._userFormatNameComboBox.FormattingEnabled = True
         Me._userFormatNameComboBox.Location = New System.Drawing.Point(127, 17)
         Me._userFormatNameComboBox.Name = "_userFormatNameComboBox"
         Me._userFormatNameComboBox.Size = New System.Drawing.Size(225, 21)
         Me._userFormatNameComboBox.TabIndex = 4
         '
         '_userFormatNameLabel
         '
         Me._userFormatNameLabel.AutoSize = True
         Me._userFormatNameLabel.Location = New System.Drawing.Point(17, 20)
         Me._userFormatNameLabel.Name = "_userFormatNameLabel"
         Me._userFormatNameLabel.Size = New System.Drawing.Size(74, 13)
         Me._userFormatNameLabel.TabIndex = 3
         Me._userFormatNameLabel.Text = "Format name:"
         '
         '_xpsOptionsTabPage
         '
         Me._xpsOptionsTabPage.Controls.Add(Me.label4)
         Me._xpsOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._xpsOptionsTabPage.Name = "_xpsOptionsTabPage"
         Me._xpsOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._xpsOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._xpsOptionsTabPage.TabIndex = 8
         Me._xpsOptionsTabPage.Text = "XPS options"
         Me._xpsOptionsTabPage.UseVisualStyleBackColor = True
         '
         'label4
         '
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(16, 21)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(163, 13)
         Me.label4.TabIndex = 3
         Me.label4.Text = "No extra options for this format."
         '
         '_docxOptionsTabPage
         '
         Me._docxOptionsTabPage.Controls.Add(Me.label3)
         Me._docxOptionsTabPage.Controls.Add(Me._cbFramedDocX)
         Me._docxOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._docxOptionsTabPage.Name = "_docxOptionsTabPage"
         Me._docxOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._docxOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._docxOptionsTabPage.TabIndex = 9
         Me._docxOptionsTabPage.Text = "DOCX options"
         Me._docxOptionsTabPage.UseVisualStyleBackColor = True
         '
         'label3
         '
         Me.label3.Location = New System.Drawing.Point(20, 40)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(339, 57)
         Me.label3.TabIndex = 5
         Me.label3.Text = resources.GetString("label3.Text")
         '
         '_cbFramedDocX
         '
         Me._cbFramedDocX.AutoSize = True
         Me._cbFramedDocX.Location = New System.Drawing.Point(20, 20)
         Me._cbFramedDocX.Name = "_cbFramedDocX"
         Me._cbFramedDocX.Size = New System.Drawing.Size(62, 17)
         Me._cbFramedDocX.TabIndex = 4
         Me._cbFramedDocX.Text = "&Framed"
         Me._cbFramedDocX.UseVisualStyleBackColor = True
         '
         '_xlsOptionsTabPage
         '
         Me._xlsOptionsTabPage.Controls.Add(Me._xlsOptionsNoteLabel)
         Me._xlsOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._xlsOptionsTabPage.Name = "_xlsOptionsTabPage"
         Me._xlsOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._xlsOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._xlsOptionsTabPage.TabIndex = 8
         Me._xlsOptionsTabPage.Text = "XLS options"
         Me._xlsOptionsTabPage.UseVisualStyleBackColor = True
         '
         '_xlsOptionsNoteLabel
         '
         Me._xlsOptionsNoteLabel.AutoSize = True
         Me._xlsOptionsNoteLabel.Location = New System.Drawing.Point(16, 21)
         Me._xlsOptionsNoteLabel.Name = "_xlsOptionsNoteLabel"
         Me._xlsOptionsNoteLabel.Size = New System.Drawing.Size(163, 13)
         Me._xlsOptionsNoteLabel.TabIndex = 2
         Me._xlsOptionsNoteLabel.Text = "No extra options for this format."
         '
         '_altoXmlOptionsTabPage
         '
         Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlMeasurementUnit)
         Me._altoXmlOptionsTabPage.Controls.Add(Me.label5)
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
         Me._altoXmlOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._altoXmlOptionsTabPage.Name = "_altoXmlOptionsTabPage"
         Me._altoXmlOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._altoXmlOptionsTabPage.Size = New System.Drawing.Size(368, 304)
         Me._altoXmlOptionsTabPage.TabIndex = 10
         Me._altoXmlOptionsTabPage.Text = "ALTOXML options"
         Me._altoXmlOptionsTabPage.UseVisualStyleBackColor = True
         '
         '_altoXmlShowGlyphVariantsCheckBox
         '
         Me._altoXmlShowGlyphVariantsCheckBox.AutoSize = True
         Me._altoXmlShowGlyphVariantsCheckBox.Location = New System.Drawing.Point(21, 274)
         Me._altoXmlShowGlyphVariantsCheckBox.Name = "_altoXmlShowGlyphVariantsCheckBox"
         Me._altoXmlShowGlyphVariantsCheckBox.Size = New System.Drawing.Size(123, 17)
         Me._altoXmlShowGlyphVariantsCheckBox.TabIndex = 29
         Me._altoXmlShowGlyphVariantsCheckBox.Text = "Show glyph variants"
         Me._altoXmlShowGlyphVariantsCheckBox.UseVisualStyleBackColor = True
         '
         '_altoXmlShowGlyphInfoCheckBox
         '
         Me._altoXmlShowGlyphInfoCheckBox.AutoSize = True
         Me._altoXmlShowGlyphInfoCheckBox.Location = New System.Drawing.Point(21, 249)
         Me._altoXmlShowGlyphInfoCheckBox.Name = "_altoXmlShowGlyphInfoCheckBox"
         Me._altoXmlShowGlyphInfoCheckBox.Size = New System.Drawing.Size(102, 17)
         Me._altoXmlShowGlyphInfoCheckBox.TabIndex = 28
         Me._altoXmlShowGlyphInfoCheckBox.Text = "Show glyph info"
         Me._altoXmlShowGlyphInfoCheckBox.UseVisualStyleBackColor = True
         '
         '_altoXmlPlainTextCheckBox
         '
         Me._altoXmlPlainTextCheckBox.AutoSize = True
         Me._altoXmlPlainTextCheckBox.Location = New System.Drawing.Point(21, 224)
         Me._altoXmlPlainTextCheckBox.Name = "_altoXmlPlainTextCheckBox"
         Me._altoXmlPlainTextCheckBox.Size = New System.Drawing.Size(71, 17)
         Me._altoXmlPlainTextCheckBox.TabIndex = 27
         Me._altoXmlPlainTextCheckBox.Text = "Plain text"
         Me._altoXmlPlainTextCheckBox.UseVisualStyleBackColor = True
         '
         '_altoXmlSortCheckBox
         '
         Me._altoXmlSortCheckBox.AutoSize = True
         Me._altoXmlSortCheckBox.Location = New System.Drawing.Point(21, 199)
         Me._altoXmlSortCheckBox.Name = "_altoXmlSortCheckBox"
         Me._altoXmlSortCheckBox.Size = New System.Drawing.Size(46, 17)
         Me._altoXmlSortCheckBox.TabIndex = 26
         Me._altoXmlSortCheckBox.Text = "Sort"
         Me._altoXmlSortCheckBox.UseVisualStyleBackColor = True
         '
         '_altoXmlApplicationDescriptionTextBox
         '
         Me._altoXmlApplicationDescriptionTextBox.Location = New System.Drawing.Point(140, 93)
         Me._altoXmlApplicationDescriptionTextBox.Name = "_altoXmlApplicationDescriptionTextBox"
         Me._altoXmlApplicationDescriptionTextBox.Size = New System.Drawing.Size(212, 20)
         Me._altoXmlApplicationDescriptionTextBox.TabIndex = 21
         '
         '_altoXmlApplicationDescriptionLabel
         '
         Me._altoXmlApplicationDescriptionLabel.AutoSize = True
         Me._altoXmlApplicationDescriptionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._altoXmlApplicationDescriptionLabel.Location = New System.Drawing.Point(18, 96)
         Me._altoXmlApplicationDescriptionLabel.Name = "_altoXmlApplicationDescriptionLabel"
         Me._altoXmlApplicationDescriptionLabel.Size = New System.Drawing.Size(118, 13)
         Me._altoXmlApplicationDescriptionLabel.TabIndex = 20
         Me._altoXmlApplicationDescriptionLabel.Text = "Application description:"
         '
         '_altoXmlSoftwareNameTextBox
         '
         Me._altoXmlSoftwareNameTextBox.Location = New System.Drawing.Point(140, 67)
         Me._altoXmlSoftwareNameTextBox.Name = "_altoXmlSoftwareNameTextBox"
         Me._altoXmlSoftwareNameTextBox.Size = New System.Drawing.Size(212, 20)
         Me._altoXmlSoftwareNameTextBox.TabIndex = 19
         '
         '_altoXmlSoftwareNameLabel
         '
         Me._altoXmlSoftwareNameLabel.AutoSize = True
         Me._altoXmlSoftwareNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._altoXmlSoftwareNameLabel.Location = New System.Drawing.Point(18, 70)
         Me._altoXmlSoftwareNameLabel.Name = "_altoXmlSoftwareNameLabel"
         Me._altoXmlSoftwareNameLabel.Size = New System.Drawing.Size(84, 13)
         Me._altoXmlSoftwareNameLabel.TabIndex = 18
         Me._altoXmlSoftwareNameLabel.Text = "Software name:"
         '
         '_altoXmlSoftwareCreatorTextBox
         '
         Me._altoXmlSoftwareCreatorTextBox.Location = New System.Drawing.Point(140, 41)
         Me._altoXmlSoftwareCreatorTextBox.Name = "_altoXmlSoftwareCreatorTextBox"
         Me._altoXmlSoftwareCreatorTextBox.Size = New System.Drawing.Size(212, 20)
         Me._altoXmlSoftwareCreatorTextBox.TabIndex = 17
         '
         '_altoXmlSoftwareCreatorLabel
         '
         Me._altoXmlSoftwareCreatorLabel.AutoSize = True
         Me._altoXmlSoftwareCreatorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._altoXmlSoftwareCreatorLabel.Location = New System.Drawing.Point(18, 44)
         Me._altoXmlSoftwareCreatorLabel.Name = "_altoXmlSoftwareCreatorLabel"
         Me._altoXmlSoftwareCreatorLabel.Size = New System.Drawing.Size(93, 13)
         Me._altoXmlSoftwareCreatorLabel.TabIndex = 16
         Me._altoXmlSoftwareCreatorLabel.Text = "Software creator:"
         '
         '_altoXmlFileNameTextBox
         '
         Me._altoXmlFileNameTextBox.Location = New System.Drawing.Point(140, 15)
         Me._altoXmlFileNameTextBox.Name = "_altoXmlFileNameTextBox"
         Me._altoXmlFileNameTextBox.Size = New System.Drawing.Size(212, 20)
         Me._altoXmlFileNameTextBox.TabIndex = 15
         '
         '_altoXmlFileNameLabel
         '
         Me._altoXmlFileNameLabel.AutoSize = True
         Me._altoXmlFileNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._altoXmlFileNameLabel.Location = New System.Drawing.Point(18, 18)
         Me._altoXmlFileNameLabel.Name = "_altoXmlFileNameLabel"
         Me._altoXmlFileNameLabel.Size = New System.Drawing.Size(56, 13)
         Me._altoXmlFileNameLabel.TabIndex = 14
         Me._altoXmlFileNameLabel.Text = "File name:"
         '
         '_altoXmlIndentationTextBox
         '
         Me._altoXmlIndentationTextBox.Location = New System.Drawing.Point(140, 170)
         Me._altoXmlIndentationTextBox.Name = "_altoXmlIndentationTextBox"
         Me._altoXmlIndentationTextBox.Size = New System.Drawing.Size(212, 20)
         Me._altoXmlIndentationTextBox.TabIndex = 24
         '
         '_altoXmlIndentationLabel
         '
         Me._altoXmlIndentationLabel.AutoSize = True
         Me._altoXmlIndentationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._altoXmlIndentationLabel.Location = New System.Drawing.Point(39, 173)
         Me._altoXmlIndentationLabel.Name = "_altoXmlIndentationLabel"
         Me._altoXmlIndentationLabel.Size = New System.Drawing.Size(67, 13)
         Me._altoXmlIndentationLabel.TabIndex = 23
         Me._altoXmlIndentationLabel.Text = "Indentation:"
         '
         '_altoXmlFormattedCheckBox
         '
         Me._altoXmlFormattedCheckBox.AutoSize = True
         Me._altoXmlFormattedCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me._altoXmlFormattedCheckBox.Location = New System.Drawing.Point(21, 153)
         Me._altoXmlFormattedCheckBox.Name = "_altoXmlFormattedCheckBox"
         Me._altoXmlFormattedCheckBox.Size = New System.Drawing.Size(76, 17)
         Me._altoXmlFormattedCheckBox.TabIndex = 22
         Me._altoXmlFormattedCheckBox.Text = "&Formatted"
         Me._altoXmlFormattedCheckBox.UseVisualStyleBackColor = True
         '
         '_ePubOptionsTabPage
         '
         Me._ePubOptionsTabPage.Controls.Add(Me._ePubOptionsNoteLabel)
         Me._ePubOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._ePubOptionsTabPage.Name = "_ePubOptionsTabPage"
         Me._ePubOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._ePubOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._ePubOptionsTabPage.TabIndex = 11
         Me._ePubOptionsTabPage.Text = "ePub options"
         Me._ePubOptionsTabPage.UseVisualStyleBackColor = True
         '
         '_ePubOptionsNoteLabel
         '
         Me._ePubOptionsNoteLabel.AutoSize = True
         Me._ePubOptionsNoteLabel.Location = New System.Drawing.Point(17, 20)
         Me._ePubOptionsNoteLabel.Name = "_ePubOptionsNoteLabel"
         Me._ePubOptionsNoteLabel.Size = New System.Drawing.Size(163, 13)
         Me._ePubOptionsNoteLabel.TabIndex = 3
         Me._ePubOptionsNoteLabel.Text = "No extra options for this format."
         '
         '_mobOptionsTabPage
         '
         Me._mobOptionsTabPage.Controls.Add(Me._mobOptionsNoteLabel)
         Me._mobOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._mobOptionsTabPage.Name = "_mobOptionsTabPage"
         Me._mobOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._mobOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._mobOptionsTabPage.TabIndex = 12
         Me._mobOptionsTabPage.Text = "Mob options"
         Me._mobOptionsTabPage.UseVisualStyleBackColor = True
         '
         '_mobOptionsNoteLabel
         '
         Me._mobOptionsNoteLabel.AutoSize = True
         Me._mobOptionsNoteLabel.Location = New System.Drawing.Point(17, 21)
         Me._mobOptionsNoteLabel.Name = "_mobOptionsNoteLabel"
         Me._mobOptionsNoteLabel.Size = New System.Drawing.Size(163, 13)
         Me._mobOptionsNoteLabel.TabIndex = 3
         Me._mobOptionsNoteLabel.Text = "No extra options for this format."
         '
         '_svgOptionsTabPage
         '
         Me._svgOptionsTabPage.Controls.Add(Me._svgOptionsNoteLabel)
         Me._svgOptionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._svgOptionsTabPage.Name = "_svgOptionsTabPage"
         Me._svgOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._svgOptionsTabPage.Size = New System.Drawing.Size(368, 271)
         Me._svgOptionsTabPage.TabIndex = 13
         Me._svgOptionsTabPage.Text = "Svg options"
         Me._svgOptionsTabPage.UseVisualStyleBackColor = True
         '
         '_svgOptionsNoteLabel
         '
         Me._svgOptionsNoteLabel.AutoSize = True
         Me._svgOptionsNoteLabel.Location = New System.Drawing.Point(17, 21)
         Me._svgOptionsNoteLabel.Name = "_svgOptionsNoteLabel"
         Me._svgOptionsNoteLabel.Size = New System.Drawing.Size(163, 13)
         Me._svgOptionsNoteLabel.TabIndex = 3
         Me._svgOptionsNoteLabel.Text = "No extra options for this format."
         '
         '_formatComboBox
         '
         Me._formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._formatComboBox.FormattingEnabled = True
         Me._formatComboBox.Location = New System.Drawing.Point(82, 62)
         Me._formatComboBox.Name = "_formatComboBox"
         Me._formatComboBox.Size = New System.Drawing.Size(316, 21)
         Me._formatComboBox.TabIndex = 4
         '
         '_formatLabel
         '
         Me._formatLabel.AutoSize = True
         Me._formatLabel.Location = New System.Drawing.Point(20, 65)
         Me._formatLabel.Name = "_formatLabel"
         Me._formatLabel.Size = New System.Drawing.Size(45, 13)
         Me._formatLabel.TabIndex = 3
         Me._formatLabel.Text = "Format:"
         '
         '_browseButton
         '
         Me._browseButton.Location = New System.Drawing.Point(371, 30)
         Me._browseButton.Name = "_browseButton"
         Me._browseButton.Size = New System.Drawing.Size(27, 23)
         Me._browseButton.TabIndex = 2
         Me._browseButton.Text = "..."
         Me._browseButton.UseVisualStyleBackColor = True
         '
         '_fileNameTextBox
         '
         Me._fileNameTextBox.Location = New System.Drawing.Point(82, 32)
         Me._fileNameTextBox.Name = "_fileNameTextBox"
         Me._fileNameTextBox.Size = New System.Drawing.Size(283, 20)
         Me._fileNameTextBox.TabIndex = 1
         '
         '_fileNameLabel
         '
         Me._fileNameLabel.AutoSize = True
         Me._fileNameLabel.Location = New System.Drawing.Point(20, 35)
         Me._fileNameLabel.Name = "_fileNameLabel"
         Me._fileNameLabel.Size = New System.Drawing.Size(56, 13)
         Me._fileNameLabel.TabIndex = 0
         Me._fileNameLabel.Text = "File name:"
         '
         '_xpsOptionsNoteLabel
         '
         Me._xpsOptionsNoteLabel.AutoSize = True
         Me._xpsOptionsNoteLabel.Location = New System.Drawing.Point(16, 21)
         Me._xpsOptionsNoteLabel.Name = "_xpsOptionsNoteLabel"
         Me._xpsOptionsNoteLabel.Size = New System.Drawing.Size(163, 13)
         Me._xpsOptionsNoteLabel.TabIndex = 2
         Me._xpsOptionsNoteLabel.Text = "No extra options for this format."
         '
         '_viewDocumentCheckBox
         '
         Me._viewDocumentCheckBox.AutoSize = True
         Me._viewDocumentCheckBox.Location = New System.Drawing.Point(34, 450)
         Me._viewDocumentCheckBox.Name = "_viewDocumentCheckBox"
         Me._viewDocumentCheckBox.Size = New System.Drawing.Size(151, 17)
         Me._viewDocumentCheckBox.TabIndex = 30
         Me._viewDocumentCheckBox.Text = "View document after save"
         Me._viewDocumentCheckBox.UseVisualStyleBackColor = True
         '
         '_altoXmlMeasurementUnit
         '
         Me._altoXmlMeasurementUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._altoXmlMeasurementUnit.FormattingEnabled = True
         Me._altoXmlMeasurementUnit.Location = New System.Drawing.Point(140, 124)
         Me._altoXmlMeasurementUnit.Name = "_altoXmlMeasurementUnit"
         Me._altoXmlMeasurementUnit.Size = New System.Drawing.Size(212, 21)
         Me._altoXmlMeasurementUnit.TabIndex = 37
         '
         'label5
         '
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(21, 127)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(98, 13)
         Me.label5.TabIndex = 36
         Me.label5.Text = "Measurement Unit:"
         '
         'SaveDocumentDialog
         '
         Me.AcceptButton = Me._okButton
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.ClientSize = New System.Drawing.Size(537, 474)
         Me.Controls.Add(Me._viewDocumentCheckBox)
         Me.Controls.Add(Me._outputGroupBox)
         Me.Controls.Add(Me._cancelButton)
         Me.Controls.Add(Me._okButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SaveDocumentDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Save Document"
         Me._outputGroupBox.ResumeLayout(False)
         Me._outputGroupBox.PerformLayout()
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
         Me._userOptionsTabPage.ResumeLayout(False)
         Me._userOptionsTabPage.PerformLayout()
         Me._xpsOptionsTabPage.ResumeLayout(False)
         Me._xpsOptionsTabPage.PerformLayout()
         Me._docxOptionsTabPage.ResumeLayout(False)
         Me._docxOptionsTabPage.PerformLayout()
         Me._xlsOptionsTabPage.ResumeLayout(False)
         Me._xlsOptionsTabPage.PerformLayout()
         Me._altoXmlOptionsTabPage.ResumeLayout(False)
         Me._altoXmlOptionsTabPage.PerformLayout()
         Me._ePubOptionsTabPage.ResumeLayout(False)
         Me._ePubOptionsTabPage.PerformLayout()
         Me._mobOptionsTabPage.ResumeLayout(False)
         Me._mobOptionsTabPage.PerformLayout()
         Me._svgOptionsTabPage.ResumeLayout(False)
         Me._svgOptionsTabPage.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents _okButton As System.Windows.Forms.Button
      Private WithEvents _cancelButton As System.Windows.Forms.Button
      Private WithEvents _outputGroupBox As System.Windows.Forms.GroupBox
      Private WithEvents _formatComboBox As System.Windows.Forms.ComboBox
      Private WithEvents _formatLabel As System.Windows.Forms.Label
      Private WithEvents _browseButton As System.Windows.Forms.Button
      Private WithEvents _fileNameTextBox As System.Windows.Forms.TextBox
      Private WithEvents _fileNameLabel As System.Windows.Forms.Label
      Private WithEvents _viewDocumentCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _optionsTabControl As System.Windows.Forms.TabControl
      Private WithEvents _ldOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _ltfOptionsNoteLabel As System.Windows.Forms.Label
      Private WithEvents _ldOptionsNoteLabel As System.Windows.Forms.Label
      Private WithEvents _emfOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _emfOptionsNoteLabel As System.Windows.Forms.Label
      Private WithEvents _pdfOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _pdfAdvanctionOptionsButton As System.Windows.Forms.Button
      Private WithEvents _pdfImageOverTextCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _pdfDocumentTypeComboBox As System.Windows.Forms.ComboBox
      Private WithEvents _pdfDocumentTypeLabel As System.Windows.Forms.Label
      Private WithEvents _docOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _rtfOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _htmlOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _htmlBackgroundColorButton As System.Windows.Forms.Button
      Private WithEvents _htmlBackgroundColorValueLabel As System.Windows.Forms.Label
      Private WithEvents _htmlBackgroundColorLabel As System.Windows.Forms.Label
      Private WithEvents _htmlUseBackgroundColorCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _htmlEmbedFontModeComboBox As System.Windows.Forms.ComboBox
      Private WithEvents _htmlEmbedFontModeLabel As System.Windows.Forms.Label
      Private WithEvents _textOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _textFormattedCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _textAddPageBreakCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _textAddPageNumberCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _textDocumentTypeComboBox As System.Windows.Forms.ComboBox
      Private WithEvents _textDocumentTypeLabel As System.Windows.Forms.Label
      Private WithEvents _userOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _userFormatNameComboBox As System.Windows.Forms.ComboBox
      Private WithEvents _userFormatNameLabel As System.Windows.Forms.Label
      Private WithEvents _xpsOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _docxOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _xpsOptionsNoteLabel As System.Windows.Forms.Label
      Private WithEvents _xlsOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _xlsOptionsNoteLabel As System.Windows.Forms.Label
      Private WithEvents label1 As System.Windows.Forms.Label
      Private WithEvents _cbFramedDoc As System.Windows.Forms.CheckBox
      Private WithEvents label2 As System.Windows.Forms.Label
      Private WithEvents _cbFramedRtf As System.Windows.Forms.CheckBox
      Private WithEvents label4 As System.Windows.Forms.Label
      Private WithEvents label3 As System.Windows.Forms.Label
      Private WithEvents _cbFramedDocX As System.Windows.Forms.CheckBox
      Friend WithEvents _altoXmlOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _altoXmlApplicationDescriptionTextBox As System.Windows.Forms.TextBox
      Private WithEvents _altoXmlApplicationDescriptionLabel As System.Windows.Forms.Label
      Private WithEvents _altoXmlSoftwareNameTextBox As System.Windows.Forms.TextBox
      Private WithEvents _altoXmlSoftwareNameLabel As System.Windows.Forms.Label
      Private WithEvents _altoXmlSoftwareCreatorTextBox As System.Windows.Forms.TextBox
      Private WithEvents _altoXmlSoftwareCreatorLabel As System.Windows.Forms.Label
      Private WithEvents _altoXmlFileNameTextBox As System.Windows.Forms.TextBox
      Private WithEvents _altoXmlFileNameLabel As System.Windows.Forms.Label
      Private WithEvents _altoXmlIndentationTextBox As System.Windows.Forms.TextBox
      Private WithEvents _altoXmlIndentationLabel As System.Windows.Forms.Label
      Private WithEvents _altoXmlFormattedCheckBox As System.Windows.Forms.CheckBox
      Friend WithEvents _ePubOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _ePubOptionsNoteLabel As System.Windows.Forms.Label
      Friend WithEvents _mobOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _mobOptionsNoteLabel As System.Windows.Forms.Label
      Friend WithEvents _svgOptionsTabPage As System.Windows.Forms.TabPage
      Private WithEvents _svgOptionsNoteLabel As System.Windows.Forms.Label
      Private WithEvents _pdfLinearizedCheckBox As CheckBox
      Private WithEvents _altoXmlShowGlyphVariantsCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _altoXmlShowGlyphInfoCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _altoXmlPlainTextCheckBox As System.Windows.Forms.CheckBox
      Friend WithEvents _altoXmlSortCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _altoXmlMeasurementUnit As ComboBox
      Private WithEvents label5 As Label
   End Class
End Namespace