Imports Microsoft.VisualBasic

Partial Class DocumentFormatOptionsControl
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

#Region "Component Designer generated code"

   ''' <summary> 
   ''' Required method for Designer support - do not modify 
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentFormatOptionsControl))
      Me._optionsTabControl = New System.Windows.Forms.TabControl()
      Me._emfOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._emfOptionsNoteLabel = New System.Windows.Forms.Label()
      Me._pdfOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._pdfLinearizedCheckBox = New System.Windows.Forms.CheckBox()
      Me._pdfAdvanctionOptionsButton = New System.Windows.Forms.Button()
      Me._pdfImageOverTextCheckBox = New System.Windows.Forms.CheckBox()
      Me._pdfDocumentTypeComboBox = New System.Windows.Forms.ComboBox()
      Me._pdfDocumentTypeLabel = New System.Windows.Forms.Label()
      Me._docOptionsTabPage = New System.Windows.Forms.TabPage()
      Me.label2 = New System.Windows.Forms.Label()
      Me._cbFramedDoc = New System.Windows.Forms.CheckBox()
      Me._rtfOptionsTabPage = New System.Windows.Forms.TabPage()
      Me.label3 = New System.Windows.Forms.Label()
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
      Me._xpsOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._xpsOptionsNoteLabel = New System.Windows.Forms.Label()
      Me._docxOptionsTabPage = New System.Windows.Forms.TabPage()
      Me.label4 = New System.Windows.Forms.Label()
      Me._cbFramedDocX = New System.Windows.Forms.CheckBox()
      Me._xlsOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._xlsOptionsNoteLabel = New System.Windows.Forms.Label()
      Me._altoXmlOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._altoXmlShowGlyphVariantsCheckBox = New System.Windows.Forms.CheckBox()
      Me._altoXmlShowGlyphInfoCheckBox = New System.Windows.Forms.CheckBox()
      Me._altoXmlPlainTextCheckBox = New System.Windows.Forms.CheckBox()
      Me._altoXmlSortCheckBox = New System.Windows.Forms.CheckBox()
      Me._altoXmlMeasurementUnit = New System.Windows.Forms.ComboBox()
      Me.label5 = New System.Windows.Forms.Label()
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
      Me._ltdOptionsTabPage = New System.Windows.Forms.TabPage()
      Me._ltfOptionsNoteLabel = New System.Windows.Forms.Label()
      Me._formatComboBox = New System.Windows.Forms.ComboBox()
      Me._formatLabel = New System.Windows.Forms.Label()
      Me._optionsTabControl.SuspendLayout()
      Me._emfOptionsTabPage.SuspendLayout()
      Me._pdfOptionsTabPage.SuspendLayout()
      Me._docOptionsTabPage.SuspendLayout()
      Me._rtfOptionsTabPage.SuspendLayout()
      Me._htmlOptionsTabPage.SuspendLayout()
      Me._textOptionsTabPage.SuspendLayout()
      Me._xpsOptionsTabPage.SuspendLayout()
      Me._docxOptionsTabPage.SuspendLayout()
      Me._xlsOptionsTabPage.SuspendLayout()
      Me._altoXmlOptionsTabPage.SuspendLayout()
      Me._ePubOptionsTabPage.SuspendLayout()
      Me._mobOptionsTabPage.SuspendLayout()
      Me._svgOptionsTabPage.SuspendLayout()
      Me._ltdOptionsTabPage.SuspendLayout()
      Me.SuspendLayout()
      '
      '_optionsTabControl
      '
      Me._optionsTabControl.Controls.Add(Me._emfOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._pdfOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._docOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._rtfOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._htmlOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._textOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._xpsOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._docxOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._xlsOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._altoXmlOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._ePubOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._mobOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._svgOptionsTabPage)
      Me._optionsTabControl.Controls.Add(Me._ltdOptionsTabPage)
      Me._optionsTabControl.Location = New System.Drawing.Point(6, 33)
      Me._optionsTabControl.Name = "_optionsTabControl"
      Me._optionsTabControl.SelectedIndex = 0
      Me._optionsTabControl.Size = New System.Drawing.Size(376, 323)
      Me._optionsTabControl.TabIndex = 15
      '
      '_emfOptionsTabPage
      '
      Me._emfOptionsTabPage.Controls.Add(Me._emfOptionsNoteLabel)
      Me._emfOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._emfOptionsTabPage.Name = "_emfOptionsTabPage"
      Me._emfOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._emfOptionsTabPage.TabIndex = 6
      Me._emfOptionsTabPage.Text = "EMF options"
      Me._emfOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_emfOptionsNoteLabel
      '
      Me._emfOptionsNoteLabel.AutoSize = True
      Me._emfOptionsNoteLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
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
      Me._pdfOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._pdfOptionsTabPage.TabIndex = 0
      Me._pdfOptionsTabPage.Text = "PDF options"
      Me._pdfOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_pdfLinearizedCheckBox
      '
      Me._pdfLinearizedCheckBox.AutoSize = True
      Me._pdfLinearizedCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._pdfLinearizedCheckBox.Location = New System.Drawing.Point(127, 95)
      Me._pdfLinearizedCheckBox.Name = "_pdfLinearizedCheckBox"
      Me._pdfLinearizedCheckBox.Size = New System.Drawing.Size(154, 17)
      Me._pdfLinearizedCheckBox.TabIndex = 4
      Me._pdfLinearizedCheckBox.Text = "Fast web view (Linearized)"
      Me._pdfLinearizedCheckBox.UseVisualStyleBackColor = True
      '
      '_pdfAdvanctionOptionsButton
      '
      Me._pdfAdvanctionOptionsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
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
      Me._pdfImageOverTextCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
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
      Me._pdfDocumentTypeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._pdfDocumentTypeLabel.Location = New System.Drawing.Point(18, 20)
      Me._pdfDocumentTypeLabel.Name = "_pdfDocumentTypeLabel"
      Me._pdfDocumentTypeLabel.Size = New System.Drawing.Size(84, 13)
      Me._pdfDocumentTypeLabel.TabIndex = 0
      Me._pdfDocumentTypeLabel.Text = "Document type:"
      '
      '_docOptionsTabPage
      '
      Me._docOptionsTabPage.Controls.Add(Me.label2)
      Me._docOptionsTabPage.Controls.Add(Me._cbFramedDoc)
      Me._docOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._docOptionsTabPage.Name = "_docOptionsTabPage"
      Me._docOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._docOptionsTabPage.TabIndex = 1
      Me._docOptionsTabPage.Text = "DOC options"
      Me._docOptionsTabPage.UseVisualStyleBackColor = True
      '
      'label2
      '
      Me.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.label2.Location = New System.Drawing.Point(20, 40)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(339, 57)
      Me.label2.TabIndex = 5
      Me.label2.Text = resources.GetString("label2.Text")
      '
      '_cbFramedDoc
      '
      Me._cbFramedDoc.AutoSize = True
      Me._cbFramedDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._cbFramedDoc.Location = New System.Drawing.Point(20, 20)
      Me._cbFramedDoc.Name = "_cbFramedDoc"
      Me._cbFramedDoc.Size = New System.Drawing.Size(62, 17)
      Me._cbFramedDoc.TabIndex = 4
      Me._cbFramedDoc.Text = "&Framed"
      Me._cbFramedDoc.UseVisualStyleBackColor = True
      '
      '_rtfOptionsTabPage
      '
      Me._rtfOptionsTabPage.Controls.Add(Me.label3)
      Me._rtfOptionsTabPage.Controls.Add(Me._cbFramedRtf)
      Me._rtfOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._rtfOptionsTabPage.Name = "_rtfOptionsTabPage"
      Me._rtfOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._rtfOptionsTabPage.TabIndex = 2
      Me._rtfOptionsTabPage.Text = "RTF options"
      Me._rtfOptionsTabPage.UseVisualStyleBackColor = True
      '
      'label3
      '
      Me.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.label3.Location = New System.Drawing.Point(20, 40)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(339, 57)
      Me.label3.TabIndex = 5
      Me.label3.Text = resources.GetString("label3.Text")
      '
      '_cbFramedRtf
      '
      Me._cbFramedRtf.AutoSize = True
      Me._cbFramedRtf.ImeMode = System.Windows.Forms.ImeMode.NoControl
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
      Me._htmlOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._htmlOptionsTabPage.TabIndex = 3
      Me._htmlOptionsTabPage.Text = "HTML options"
      Me._htmlOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_htmlBackgroundColorButton
      '
      Me._htmlBackgroundColorButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._htmlBackgroundColorButton.Location = New System.Drawing.Point(181, 67)
      Me._htmlBackgroundColorButton.Name = "_htmlBackgroundColorButton"
      Me._htmlBackgroundColorButton.Size = New System.Drawing.Size(28, 23)
      Me._htmlBackgroundColorButton.TabIndex = 12
      Me._htmlBackgroundColorButton.Text = "..."
      Me._htmlBackgroundColorButton.UseVisualStyleBackColor = True
      '
      '_htmlBackgroundColorValueLabel
      '
      Me._htmlBackgroundColorValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._htmlBackgroundColorValueLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._htmlBackgroundColorValueLabel.Location = New System.Drawing.Point(125, 67)
      Me._htmlBackgroundColorValueLabel.Name = "_htmlBackgroundColorValueLabel"
      Me._htmlBackgroundColorValueLabel.Size = New System.Drawing.Size(50, 23)
      Me._htmlBackgroundColorValueLabel.TabIndex = 11
      '
      '_htmlBackgroundColorLabel
      '
      Me._htmlBackgroundColorLabel.AutoSize = True
      Me._htmlBackgroundColorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._htmlBackgroundColorLabel.Location = New System.Drawing.Point(13, 71)
      Me._htmlBackgroundColorLabel.Name = "_htmlBackgroundColorLabel"
      Me._htmlBackgroundColorLabel.Size = New System.Drawing.Size(93, 13)
      Me._htmlBackgroundColorLabel.TabIndex = 10
      Me._htmlBackgroundColorLabel.Text = "Background color:"
      '
      '_htmlUseBackgroundColorCheckBox
      '
      Me._htmlUseBackgroundColorCheckBox.AutoSize = True
      Me._htmlUseBackgroundColorCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._htmlUseBackgroundColorCheckBox.Location = New System.Drawing.Point(125, 43)
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
      Me._htmlEmbedFontModeComboBox.Location = New System.Drawing.Point(125, 18)
      Me._htmlEmbedFontModeComboBox.Name = "_htmlEmbedFontModeComboBox"
      Me._htmlEmbedFontModeComboBox.Size = New System.Drawing.Size(225, 21)
      Me._htmlEmbedFontModeComboBox.TabIndex = 8
      '
      '_htmlEmbedFontModeLabel
      '
      Me._htmlEmbedFontModeLabel.AutoSize = True
      Me._htmlEmbedFontModeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._htmlEmbedFontModeLabel.Location = New System.Drawing.Point(20, 20)
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
      Me._textOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._textOptionsTabPage.TabIndex = 4
      Me._textOptionsTabPage.Text = "Text options"
      Me._textOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_textFormattedCheckBox
      '
      Me._textFormattedCheckBox.AutoSize = True
      Me._textFormattedCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
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
      Me._textAddPageBreakCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
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
      Me._textAddPageNumberCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
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
      Me._textDocumentTypeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._textDocumentTypeLabel.Location = New System.Drawing.Point(18, 20)
      Me._textDocumentTypeLabel.Name = "_textDocumentTypeLabel"
      Me._textDocumentTypeLabel.Size = New System.Drawing.Size(84, 13)
      Me._textDocumentTypeLabel.TabIndex = 13
      Me._textDocumentTypeLabel.Text = "Document type:"
      '
      '_xpsOptionsTabPage
      '
      Me._xpsOptionsTabPage.Controls.Add(Me._xpsOptionsNoteLabel)
      Me._xpsOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._xpsOptionsTabPage.Name = "_xpsOptionsTabPage"
      Me._xpsOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._xpsOptionsTabPage.TabIndex = 7
      Me._xpsOptionsTabPage.Text = "XPS options"
      Me._xpsOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_xpsOptionsNoteLabel
      '
      Me._xpsOptionsNoteLabel.AutoSize = True
      Me._xpsOptionsNoteLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._xpsOptionsNoteLabel.Location = New System.Drawing.Point(21, 16)
      Me._xpsOptionsNoteLabel.Name = "_xpsOptionsNoteLabel"
      Me._xpsOptionsNoteLabel.Size = New System.Drawing.Size(163, 13)
      Me._xpsOptionsNoteLabel.TabIndex = 3
      Me._xpsOptionsNoteLabel.Text = "No extra options for this format."
      '
      '_docxOptionsTabPage
      '
      Me._docxOptionsTabPage.Controls.Add(Me.label4)
      Me._docxOptionsTabPage.Controls.Add(Me._cbFramedDocX)
      Me._docxOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._docxOptionsTabPage.Name = "_docxOptionsTabPage"
      Me._docxOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._docxOptionsTabPage.TabIndex = 8
      Me._docxOptionsTabPage.Text = "DOCX options"
      Me._docxOptionsTabPage.UseVisualStyleBackColor = True
      '
      'label4
      '
      Me.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.label4.Location = New System.Drawing.Point(20, 40)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(339, 57)
      Me.label4.TabIndex = 5
      Me.label4.Text = resources.GetString("label4.Text")
      '
      '_cbFramedDocX
      '
      Me._cbFramedDocX.AutoSize = True
      Me._cbFramedDocX.ImeMode = System.Windows.Forms.ImeMode.NoControl
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
      Me._xlsOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._xlsOptionsTabPage.TabIndex = 7
      Me._xlsOptionsTabPage.Text = "XLS options"
      Me._xlsOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_xlsOptionsNoteLabel
      '
      Me._xlsOptionsNoteLabel.AutoSize = True
      Me._xlsOptionsNoteLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._xlsOptionsNoteLabel.Location = New System.Drawing.Point(21, 16)
      Me._xlsOptionsNoteLabel.Name = "_xlsOptionsNoteLabel"
      Me._xlsOptionsNoteLabel.Size = New System.Drawing.Size(163, 13)
      Me._xlsOptionsNoteLabel.TabIndex = 3
      Me._xlsOptionsNoteLabel.Text = "No extra options for this format."
      '
      '_altoXmlOptionsTabPage
      '
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlShowGlyphVariantsCheckBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlShowGlyphInfoCheckBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlPlainTextCheckBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlSortCheckBox)
      Me._altoXmlOptionsTabPage.Controls.Add(Me._altoXmlMeasurementUnit)
      Me._altoXmlOptionsTabPage.Controls.Add(Me.label5)
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
      Me._altoXmlOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._altoXmlOptionsTabPage.TabIndex = 9
      Me._altoXmlOptionsTabPage.Text = "ALTOXML options"
      Me._altoXmlOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_altoXmlShowGlyphVariantsCheckBox
      '
      Me._altoXmlShowGlyphVariantsCheckBox.AutoSize = True
      Me._altoXmlShowGlyphVariantsCheckBox.Location = New System.Drawing.Point(21, 270)
      Me._altoXmlShowGlyphVariantsCheckBox.Name = "_altoXmlShowGlyphVariantsCheckBox"
      Me._altoXmlShowGlyphVariantsCheckBox.Size = New System.Drawing.Size(123, 17)
      Me._altoXmlShowGlyphVariantsCheckBox.TabIndex = 43
      Me._altoXmlShowGlyphVariantsCheckBox.Text = "Show glyph variants"
      Me._altoXmlShowGlyphVariantsCheckBox.UseVisualStyleBackColor = True
      '
      '_altoXmlShowGlyphInfoCheckBox
      '
      Me._altoXmlShowGlyphInfoCheckBox.AutoSize = True
      Me._altoXmlShowGlyphInfoCheckBox.Location = New System.Drawing.Point(21, 245)
      Me._altoXmlShowGlyphInfoCheckBox.Name = "_altoXmlShowGlyphInfoCheckBox"
      Me._altoXmlShowGlyphInfoCheckBox.Size = New System.Drawing.Size(102, 17)
      Me._altoXmlShowGlyphInfoCheckBox.TabIndex = 42
      Me._altoXmlShowGlyphInfoCheckBox.Text = "Show glyph info"
      Me._altoXmlShowGlyphInfoCheckBox.UseVisualStyleBackColor = True
      '
      '_altoXmlPlainTextCheckBox
      '
      Me._altoXmlPlainTextCheckBox.AutoSize = True
      Me._altoXmlPlainTextCheckBox.Location = New System.Drawing.Point(21, 220)
      Me._altoXmlPlainTextCheckBox.Name = "_altoXmlPlainTextCheckBox"
      Me._altoXmlPlainTextCheckBox.Size = New System.Drawing.Size(71, 17)
      Me._altoXmlPlainTextCheckBox.TabIndex = 41
      Me._altoXmlPlainTextCheckBox.Text = "Plain text"
      Me._altoXmlPlainTextCheckBox.UseVisualStyleBackColor = True
      '
      '_altoXmlSortCheckBox
      '
      Me._altoXmlSortCheckBox.AutoSize = True
      Me._altoXmlSortCheckBox.Location = New System.Drawing.Point(21, 195)
      Me._altoXmlSortCheckBox.Name = "_altoXmlSortCheckBox"
      Me._altoXmlSortCheckBox.Size = New System.Drawing.Size(46, 17)
      Me._altoXmlSortCheckBox.TabIndex = 40
      Me._altoXmlSortCheckBox.Text = "Sort"
      Me._altoXmlSortCheckBox.UseVisualStyleBackColor = True
      '
      '_altoXmlMeasurementUnit
      '
      Me._altoXmlMeasurementUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._altoXmlMeasurementUnit.FormattingEnabled = True
      Me._altoXmlMeasurementUnit.Location = New System.Drawing.Point(140, 124)
      Me._altoXmlMeasurementUnit.Name = "_altoXmlMeasurementUnit"
      Me._altoXmlMeasurementUnit.Size = New System.Drawing.Size(212, 21)
      Me._altoXmlMeasurementUnit.TabIndex = 39
      '
      'label5
      '
      Me.label5.AutoSize = True
      Me.label5.Location = New System.Drawing.Point(21, 127)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(98, 13)
      Me.label5.TabIndex = 38
      Me.label5.Text = "Measurement Unit:"
      '
      '_altoXmlApplicationDescriptionTextBox
      '
      Me._altoXmlApplicationDescriptionTextBox.Location = New System.Drawing.Point(140, 96)
      Me._altoXmlApplicationDescriptionTextBox.Name = "_altoXmlApplicationDescriptionTextBox"
      Me._altoXmlApplicationDescriptionTextBox.Size = New System.Drawing.Size(212, 20)
      Me._altoXmlApplicationDescriptionTextBox.TabIndex = 21
      '
      '_altoXmlApplicationDescriptionLabel
      '
      Me._altoXmlApplicationDescriptionLabel.AutoSize = True
      Me._altoXmlApplicationDescriptionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlApplicationDescriptionLabel.Location = New System.Drawing.Point(18, 99)
      Me._altoXmlApplicationDescriptionLabel.Name = "_altoXmlApplicationDescriptionLabel"
      Me._altoXmlApplicationDescriptionLabel.Size = New System.Drawing.Size(118, 13)
      Me._altoXmlApplicationDescriptionLabel.TabIndex = 20
      Me._altoXmlApplicationDescriptionLabel.Text = "Application description:"
      '
      '_altoXmlSoftwareNameTextBox
      '
      Me._altoXmlSoftwareNameTextBox.Location = New System.Drawing.Point(140, 70)
      Me._altoXmlSoftwareNameTextBox.Name = "_altoXmlSoftwareNameTextBox"
      Me._altoXmlSoftwareNameTextBox.Size = New System.Drawing.Size(212, 20)
      Me._altoXmlSoftwareNameTextBox.TabIndex = 19
      '
      '_altoXmlSoftwareNameLabel
      '
      Me._altoXmlSoftwareNameLabel.AutoSize = True
      Me._altoXmlSoftwareNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlSoftwareNameLabel.Location = New System.Drawing.Point(18, 73)
      Me._altoXmlSoftwareNameLabel.Name = "_altoXmlSoftwareNameLabel"
      Me._altoXmlSoftwareNameLabel.Size = New System.Drawing.Size(84, 13)
      Me._altoXmlSoftwareNameLabel.TabIndex = 18
      Me._altoXmlSoftwareNameLabel.Text = "Software name:"
      '
      '_altoXmlSoftwareCreatorTextBox
      '
      Me._altoXmlSoftwareCreatorTextBox.Location = New System.Drawing.Point(140, 44)
      Me._altoXmlSoftwareCreatorTextBox.Name = "_altoXmlSoftwareCreatorTextBox"
      Me._altoXmlSoftwareCreatorTextBox.Size = New System.Drawing.Size(212, 20)
      Me._altoXmlSoftwareCreatorTextBox.TabIndex = 17
      '
      '_altoXmlSoftwareCreatorLabel
      '
      Me._altoXmlSoftwareCreatorLabel.AutoSize = True
      Me._altoXmlSoftwareCreatorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlSoftwareCreatorLabel.Location = New System.Drawing.Point(18, 47)
      Me._altoXmlSoftwareCreatorLabel.Name = "_altoXmlSoftwareCreatorLabel"
      Me._altoXmlSoftwareCreatorLabel.Size = New System.Drawing.Size(93, 13)
      Me._altoXmlSoftwareCreatorLabel.TabIndex = 16
      Me._altoXmlSoftwareCreatorLabel.Text = "Software creator:"
      '
      '_altoXmlFileNameTextBox
      '
      Me._altoXmlFileNameTextBox.Location = New System.Drawing.Point(140, 18)
      Me._altoXmlFileNameTextBox.Name = "_altoXmlFileNameTextBox"
      Me._altoXmlFileNameTextBox.Size = New System.Drawing.Size(212, 20)
      Me._altoXmlFileNameTextBox.TabIndex = 15
      '
      '_altoXmlFileNameLabel
      '
      Me._altoXmlFileNameLabel.AutoSize = True
      Me._altoXmlFileNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlFileNameLabel.Location = New System.Drawing.Point(18, 21)
      Me._altoXmlFileNameLabel.Name = "_altoXmlFileNameLabel"
      Me._altoXmlFileNameLabel.Size = New System.Drawing.Size(56, 13)
      Me._altoXmlFileNameLabel.TabIndex = 14
      Me._altoXmlFileNameLabel.Text = "File name:"
      '
      '_altoXmlIndentationTextBox
      '
      Me._altoXmlIndentationTextBox.Location = New System.Drawing.Point(140, 167)
      Me._altoXmlIndentationTextBox.Name = "_altoXmlIndentationTextBox"
      Me._altoXmlIndentationTextBox.Size = New System.Drawing.Size(212, 20)
      Me._altoXmlIndentationTextBox.TabIndex = 13
      '
      '_altoXmlIndentationLabel
      '
      Me._altoXmlIndentationLabel.AutoSize = True
      Me._altoXmlIndentationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlIndentationLabel.Location = New System.Drawing.Point(39, 170)
      Me._altoXmlIndentationLabel.Name = "_altoXmlIndentationLabel"
      Me._altoXmlIndentationLabel.Size = New System.Drawing.Size(67, 13)
      Me._altoXmlIndentationLabel.TabIndex = 12
      Me._altoXmlIndentationLabel.Text = "Indentation:"
      '
      '_altoXmlFormattedCheckBox
      '
      Me._altoXmlFormattedCheckBox.AutoSize = True
      Me._altoXmlFormattedCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._altoXmlFormattedCheckBox.Location = New System.Drawing.Point(21, 150)
      Me._altoXmlFormattedCheckBox.Name = "_altoXmlFormattedCheckBox"
      Me._altoXmlFormattedCheckBox.Size = New System.Drawing.Size(76, 17)
      Me._altoXmlFormattedCheckBox.TabIndex = 11
      Me._altoXmlFormattedCheckBox.Text = "&Formatted"
      Me._altoXmlFormattedCheckBox.UseVisualStyleBackColor = True
      '
      '_ePubOptionsTabPage
      '
      Me._ePubOptionsTabPage.Controls.Add(Me._ePubOptionsNoteLabel)
      Me._ePubOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._ePubOptionsTabPage.Name = "_ePubOptionsTabPage"
      Me._ePubOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._ePubOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._ePubOptionsTabPage.TabIndex = 10
      Me._ePubOptionsTabPage.Text = "ePub options"
      Me._ePubOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_ePubOptionsNoteLabel
      '
      Me._ePubOptionsNoteLabel.AutoSize = True
      Me._ePubOptionsNoteLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._ePubOptionsNoteLabel.Location = New System.Drawing.Point(23, 17)
      Me._ePubOptionsNoteLabel.Name = "_ePubOptionsNoteLabel"
      Me._ePubOptionsNoteLabel.Size = New System.Drawing.Size(163, 13)
      Me._ePubOptionsNoteLabel.TabIndex = 4
      Me._ePubOptionsNoteLabel.Text = "No extra options for this format."
      '
      '_mobOptionsTabPage
      '
      Me._mobOptionsTabPage.Controls.Add(Me._mobOptionsNoteLabel)
      Me._mobOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._mobOptionsTabPage.Name = "_mobOptionsTabPage"
      Me._mobOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._mobOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._mobOptionsTabPage.TabIndex = 11
      Me._mobOptionsTabPage.Text = "Mob options"
      Me._mobOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_mobOptionsNoteLabel
      '
      Me._mobOptionsNoteLabel.AutoSize = True
      Me._mobOptionsNoteLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._mobOptionsNoteLabel.Location = New System.Drawing.Point(24, 17)
      Me._mobOptionsNoteLabel.Name = "_mobOptionsNoteLabel"
      Me._mobOptionsNoteLabel.Size = New System.Drawing.Size(163, 13)
      Me._mobOptionsNoteLabel.TabIndex = 4
      Me._mobOptionsNoteLabel.Text = "No extra options for this format."
      '
      '_svgOptionsTabPage
      '
      Me._svgOptionsTabPage.Controls.Add(Me._svgOptionsNoteLabel)
      Me._svgOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._svgOptionsTabPage.Name = "_svgOptionsTabPage"
      Me._svgOptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me._svgOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._svgOptionsTabPage.TabIndex = 12
      Me._svgOptionsTabPage.Text = "Svg options"
      Me._svgOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_svgOptionsNoteLabel
      '
      Me._svgOptionsNoteLabel.AutoSize = True
      Me._svgOptionsNoteLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._svgOptionsNoteLabel.Location = New System.Drawing.Point(25, 17)
      Me._svgOptionsNoteLabel.Name = "_svgOptionsNoteLabel"
      Me._svgOptionsNoteLabel.Size = New System.Drawing.Size(163, 13)
      Me._svgOptionsNoteLabel.TabIndex = 4
      Me._svgOptionsNoteLabel.Text = "No extra options for this format."
      '
      '_ltdOptionsTabPage
      '
      Me._ltdOptionsTabPage.Controls.Add(Me._ltfOptionsNoteLabel)
      Me._ltdOptionsTabPage.Location = New System.Drawing.Point(4, 22)
      Me._ltdOptionsTabPage.Name = "_ltdOptionsTabPage"
      Me._ltdOptionsTabPage.Size = New System.Drawing.Size(368, 297)
      Me._ltdOptionsTabPage.TabIndex = 13
      Me._ltdOptionsTabPage.Text = "LTD options"
      Me._ltdOptionsTabPage.UseVisualStyleBackColor = True
      '
      '_ltfOptionsNoteLabel
      '
      Me._ltfOptionsNoteLabel.AutoSize = True
      Me._ltfOptionsNoteLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._ltfOptionsNoteLabel.Location = New System.Drawing.Point(3, 13)
      Me._ltfOptionsNoteLabel.Name = "_ltfOptionsNoteLabel"
      Me._ltfOptionsNoteLabel.Size = New System.Drawing.Size(343, 39)
      Me._ltfOptionsNoteLabel.TabIndex = 3
      Me._ltfOptionsNoteLabel.Text = "LTD is the LEAD Temporary Document Format. This format creates a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "temporary file" &
    " on disk that can later be converted to any of the other " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "formats supported by " &
    "the LEADTOOLS Document Writers."
      '
      '_formatComboBox
      '
      Me._formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._formatComboBox.FormattingEnabled = True
      Me._formatComboBox.Location = New System.Drawing.Point(51, 6)
      Me._formatComboBox.Name = "_formatComboBox"
      Me._formatComboBox.Size = New System.Drawing.Size(331, 21)
      Me._formatComboBox.TabIndex = 14
      '
      '_formatLabel
      '
      Me._formatLabel.AutoSize = True
      Me._formatLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._formatLabel.Location = New System.Drawing.Point(3, 9)
      Me._formatLabel.Name = "_formatLabel"
      Me._formatLabel.Size = New System.Drawing.Size(45, 13)
      Me._formatLabel.TabIndex = 13
      Me._formatLabel.Text = "Format:"
      '
      'DocumentFormatOptionsControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._optionsTabControl)
      Me.Controls.Add(Me._formatComboBox)
      Me.Controls.Add(Me._formatLabel)
      Me.Name = "DocumentFormatOptionsControl"
      Me.Size = New System.Drawing.Size(387, 363)
      Me._optionsTabControl.ResumeLayout(False)
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
      Me._ltdOptionsTabPage.ResumeLayout(False)
      Me._ltdOptionsTabPage.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _optionsTabControl As System.Windows.Forms.TabControl
   Private _emfOptionsTabPage As System.Windows.Forms.TabPage
   Private _emfOptionsNoteLabel As System.Windows.Forms.Label
   Private _pdfOptionsTabPage As System.Windows.Forms.TabPage
   Private WithEvents _pdfAdvanctionOptionsButton As System.Windows.Forms.Button
   Private WithEvents _pdfImageOverTextCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _pdfDocumentTypeComboBox As System.Windows.Forms.ComboBox
   Private _pdfDocumentTypeLabel As System.Windows.Forms.Label
   Private _docOptionsTabPage As System.Windows.Forms.TabPage
   Private label2 As System.Windows.Forms.Label
   Private _cbFramedDoc As System.Windows.Forms.CheckBox
   Private _rtfOptionsTabPage As System.Windows.Forms.TabPage
   Private label3 As System.Windows.Forms.Label
   Private _cbFramedRtf As System.Windows.Forms.CheckBox
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
   Private _xpsOptionsTabPage As System.Windows.Forms.TabPage
   Private _xpsOptionsNoteLabel As System.Windows.Forms.Label
   Private _docxOptionsTabPage As System.Windows.Forms.TabPage
   Private label4 As System.Windows.Forms.Label
   Private _cbFramedDocX As System.Windows.Forms.CheckBox
   Private _xlsOptionsTabPage As System.Windows.Forms.TabPage
   Private _xlsOptionsNoteLabel As System.Windows.Forms.Label
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
   Private _ePubOptionsTabPage As System.Windows.Forms.TabPage
   Private _ePubOptionsNoteLabel As System.Windows.Forms.Label
   Private _mobOptionsTabPage As System.Windows.Forms.TabPage
   Private _mobOptionsNoteLabel As System.Windows.Forms.Label
   Private _svgOptionsTabPage As System.Windows.Forms.TabPage
   Private _svgOptionsNoteLabel As System.Windows.Forms.Label
   Private _ltdOptionsTabPage As System.Windows.Forms.TabPage
   Private _ltfOptionsNoteLabel As System.Windows.Forms.Label
   Private WithEvents _formatComboBox As System.Windows.Forms.ComboBox
   Private _formatLabel As System.Windows.Forms.Label
   Private WithEvents _pdfLinearizedCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _altoXmlShowGlyphVariantsCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _altoXmlShowGlyphInfoCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _altoXmlPlainTextCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents _altoXmlSortCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _altoXmlMeasurementUnit As System.Windows.Forms.ComboBox
   Private WithEvents label5 As System.Windows.Forms.Label
End Class