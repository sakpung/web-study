' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Printing

Imports Leadtools.Printer

Partial Public Class FrmSpecifications : Inherits Form
   Private _paperIds As List(Of Integer) = New List(Of Integer)()
   Private _printDocument As PrintDocument
   Private _specifications As PrinterSpecifications

#Region "Windows Form Designer generated code"
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSpecifications))
      Me._grpPaperSize = New System.Windows.Forms.GroupBox()
      Me._lblpaperInfo = New System.Windows.Forms.Label()
      Me._radioCentimeters = New System.Windows.Forms.RadioButton()
      Me._radioInches = New System.Windows.Forms.RadioButton()
      Me._txtHeight = New System.Windows.Forms.TextBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me._txtWidth = New System.Windows.Forms.TextBox()
      Me._lblPaperSize = New System.Windows.Forms.Label()
      Me._cmbPaperSize = New System.Windows.Forms.ComboBox()
      Me._grpOrientation = New System.Windows.Forms.GroupBox()
      Me._rdLandscape = New System.Windows.Forms.RadioButton()
      Me._rdPortrait = New System.Windows.Forms.RadioButton()
      Me._grpMargins = New System.Windows.Forms.GroupBox()
      Me._cmbEmulatePrinter = New System.Windows.Forms.ComboBox()
      Me._lblEmulatePrinter = New System.Windows.Forms.Label()
      Me._grpGraphics = New System.Windows.Forms.GroupBox()
      Me._txtCustomQuality = New System.Windows.Forms.TextBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me._cmbPrintQuality = New System.Windows.Forms.ComboBox()
      Me._lblResolution = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnRestoreDefault = New System.Windows.Forms.Button()
      Me.label2 = New System.Windows.Forms.Label()
      Me._grpPaperSize.SuspendLayout()
      Me._grpOrientation.SuspendLayout()
      Me._grpMargins.SuspendLayout()
      Me._grpGraphics.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _grpPaperSize
      ' 
      Me._grpPaperSize.Controls.Add(Me._lblpaperInfo)
      Me._grpPaperSize.Controls.Add(Me._radioCentimeters)
      Me._grpPaperSize.Controls.Add(Me._radioInches)
      Me._grpPaperSize.Controls.Add(Me._txtHeight)
      Me._grpPaperSize.Controls.Add(Me.label1)
      Me._grpPaperSize.Controls.Add(Me._txtWidth)
      Me._grpPaperSize.Controls.Add(Me._lblPaperSize)
      Me._grpPaperSize.Controls.Add(Me._cmbPaperSize)
      Me._grpPaperSize.Location = New System.Drawing.Point(4, 3)
      Me._grpPaperSize.Name = "_grpPaperSize"
      Me._grpPaperSize.Size = New System.Drawing.Size(204, 86)
      Me._grpPaperSize.TabIndex = 0
      Me._grpPaperSize.TabStop = False
      Me._grpPaperSize.Text = "Paper Si&ze"
      ' 
      ' _lblpaperInfo
      ' 
      Me._lblpaperInfo.AutoSize = True
      Me._lblpaperInfo.Location = New System.Drawing.Point(5, 56)
      Me._lblpaperInfo.Name = "_lblpaperInfo"
      Me._lblpaperInfo.Size = New System.Drawing.Size(0, 13)
      Me._lblpaperInfo.TabIndex = 7
      ' 
      ' _radioCentimeters
      ' 
      Me._radioCentimeters.AutoSize = True
      Me._radioCentimeters.Location = New System.Drawing.Point(85, 97)
      Me._radioCentimeters.Name = "_radioCentimeters"
      Me._radioCentimeters.Size = New System.Drawing.Size(73, 17)
      Me._radioCentimeters.TabIndex = 6
      Me._radioCentimeters.TabStop = True
      Me._radioCentimeters.Text = "Millimeters"
      Me._radioCentimeters.UseVisualStyleBackColor = True
      Me._radioCentimeters.Visible = False
      ' 
      ' _radioInches
      ' 
      Me._radioInches.AutoSize = True
      Me._radioInches.Location = New System.Drawing.Point(11, 97)
      Me._radioInches.Name = "_radioInches"
      Me._radioInches.Size = New System.Drawing.Size(57, 17)
      Me._radioInches.TabIndex = 5
      Me._radioInches.TabStop = True
      Me._radioInches.Text = "Inches"
      Me._radioInches.UseVisualStyleBackColor = True
      Me._radioInches.Visible = False
      ' 
      ' _txtHeight
      ' 
      Me._txtHeight.Location = New System.Drawing.Point(85, 94)
      Me._txtHeight.Name = "_txtHeight"
      Me._txtHeight.Size = New System.Drawing.Size(100, 20)
      Me._txtHeight.TabIndex = 4
      Me._txtHeight.Visible = False
      '		 Me._txtHeight.Leave += New System.EventHandler(Me._txtHeight_Leave);
      '		 Me._txtHeight.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._txtBox_KeyPress);
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(5, 97)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(76, 13)
      Me.label1.TabIndex = 3
      Me.label1.Text = "Custom Height"
      Me.label1.Visible = False
      ' 
      ' _txtWidth
      ' 
      Me._txtWidth.Location = New System.Drawing.Point(87, 94)
      Me._txtWidth.Name = "_txtWidth"
      Me._txtWidth.Size = New System.Drawing.Size(100, 20)
      Me._txtWidth.TabIndex = 2
      Me._txtWidth.Visible = False
      '		 Me._txtWidth.Leave += New System.EventHandler(Me._txtWidth_Leave);
      '		 Me._txtWidth.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._txtBox_KeyPress);
      ' 
      ' _lblPaperSize
      ' 
      Me._lblPaperSize.AutoSize = True
      Me._lblPaperSize.Location = New System.Drawing.Point(7, 97)
      Me._lblPaperSize.Name = "_lblPaperSize"
      Me._lblPaperSize.Size = New System.Drawing.Size(73, 13)
      Me._lblPaperSize.TabIndex = 1
      Me._lblPaperSize.Text = "Custom Width"
      Me._lblPaperSize.Visible = False
      ' 
      ' _cmbPaperSize
      ' 
      Me._cmbPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbPaperSize.FormattingEnabled = True
      Me._cmbPaperSize.Items.AddRange(New Object() {"Letter", "Legal", "A4", "C Sheet", "D Sheet", "E Sheet", "Letter Small", "Tabloid", "Ledger", "Statement", "Executive", "A3 Sheet", "A4 Small Sheet", "A5 Sheet", "B5 Sheet", "Folio", "Quarto", "Note", "#9 Envelope", "#10 Envelope", "#11 Envelope", "#12 Envelope", "#14 Envelope", "DL Envelope", "C5 Envelope", "C3 Envelope", "C4 Envelope", "C6 Envelope", "C65 Envelope", "B4 Envelope", "B5 Envelope", "B6 Envelope", "Italy Envelope", "Envelope Monarch", "6 3/4 Envelope", "US Std Fanfold", "German Std Fanfold", "German Legal Fanfold"})
      Me._cmbPaperSize.Location = New System.Drawing.Point(8, 18)
      Me._cmbPaperSize.Name = "_cmbPaperSize"
      Me._cmbPaperSize.Size = New System.Drawing.Size(177, 21)
      Me._cmbPaperSize.TabIndex = 0
      '		 Me._cmbPaperSize.SelectedIndexChanged += New System.EventHandler(Me._cmbPaperSize_SelectedIndexChanged);
      ' 
      ' _grpOrientation
      ' 
      Me._grpOrientation.Controls.Add(Me._rdLandscape)
      Me._grpOrientation.Controls.Add(Me._rdPortrait)
      Me._grpOrientation.Location = New System.Drawing.Point(214, 3)
      Me._grpOrientation.Name = "_grpOrientation"
      Me._grpOrientation.Size = New System.Drawing.Size(152, 86)
      Me._grpOrientation.TabIndex = 1
      Me._grpOrientation.TabStop = False
      Me._grpOrientation.Text = "&Orientation"
      ' 
      ' _rdLandscape
      ' 
      Me._rdLandscape.AutoSize = True
      Me._rdLandscape.Location = New System.Drawing.Point(6, 56)
      Me._rdLandscape.Name = "_rdLandscape"
      Me._rdLandscape.Size = New System.Drawing.Size(78, 17)
      Me._rdLandscape.TabIndex = 2
      Me._rdLandscape.TabStop = True
      Me._rdLandscape.Text = "&Landscape"
      Me._rdLandscape.UseVisualStyleBackColor = True
      ' 
      ' _rdPortrait
      ' 
      Me._rdPortrait.AutoSize = True
      Me._rdPortrait.Location = New System.Drawing.Point(6, 22)
      Me._rdPortrait.Name = "_rdPortrait"
      Me._rdPortrait.Size = New System.Drawing.Size(58, 17)
      Me._rdPortrait.TabIndex = 1
      Me._rdPortrait.TabStop = True
      Me._rdPortrait.Text = "&Portrait"
      Me._rdPortrait.UseVisualStyleBackColor = True
      ' 
      ' _grpMargins
      ' 
      Me._grpMargins.Controls.Add(Me._cmbEmulatePrinter)
      Me._grpMargins.Controls.Add(Me._lblEmulatePrinter)
      Me._grpMargins.Location = New System.Drawing.Point(4, 95)
      Me._grpMargins.Name = "_grpMargins"
      Me._grpMargins.Size = New System.Drawing.Size(362, 50)
      Me._grpMargins.TabIndex = 2
      Me._grpMargins.TabStop = False
      Me._grpMargins.Text = "&Margins"
      ' 
      ' _cmbEmulatePrinter
      ' 
      Me._cmbEmulatePrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbEmulatePrinter.FormattingEnabled = True
      Me._cmbEmulatePrinter.Location = New System.Drawing.Point(119, 18)
      Me._cmbEmulatePrinter.Name = "_cmbEmulatePrinter"
      Me._cmbEmulatePrinter.Size = New System.Drawing.Size(213, 21)
      Me._cmbEmulatePrinter.TabIndex = 3
      ' 
      ' _lblEmulatePrinter
      ' 
      Me._lblEmulatePrinter.AutoSize = True
      Me._lblEmulatePrinter.Location = New System.Drawing.Point(8, 21)
      Me._lblEmulatePrinter.Name = "_lblEmulatePrinter"
      Me._lblEmulatePrinter.Size = New System.Drawing.Size(81, 13)
      Me._lblEmulatePrinter.TabIndex = 2
      Me._lblEmulatePrinter.Text = "&Emulate Printer:"
      ' 
      ' _grpGraphics
      ' 
      Me._grpGraphics.Controls.Add(Me.label2)
      Me._grpGraphics.Controls.Add(Me._txtCustomQuality)
      Me._grpGraphics.Controls.Add(Me.label3)
      Me._grpGraphics.Controls.Add(Me._cmbPrintQuality)
      Me._grpGraphics.Controls.Add(Me._lblResolution)
      Me._grpGraphics.Location = New System.Drawing.Point(4, 151)
      Me._grpGraphics.Name = "_grpGraphics"
      Me._grpGraphics.Size = New System.Drawing.Size(362, 79)
      Me._grpGraphics.TabIndex = 3
      Me._grpGraphics.TabStop = False
      Me._grpGraphics.Text = "&Graphics"
      ' 
      ' _txtCustomQuality
      ' 
      Me._txtCustomQuality.Location = New System.Drawing.Point(119, 46)
      Me._txtCustomQuality.Name = "_txtCustomQuality"
      Me._txtCustomQuality.Size = New System.Drawing.Size(56, 20)
      Me._txtCustomQuality.TabIndex = 5
      '		 Me._txtCustomQuality.Leave += New System.EventHandler(Me._txtCustomQuality_Leave);
      '		 Me._txtCustomQuality.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._txtBox_KeyPress);
      ' 
      ' label3
      ' 
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(8, 49)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(95, 13)
      Me.label3.TabIndex = 4
      Me.label3.Text = "Custom Resolution"
      ' 
      ' _cmbPrintQuality
      ' 
      Me._cmbPrintQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbPrintQuality.FormattingEnabled = True
      Me._cmbPrintQuality.Items.AddRange(New Object() {"Draft (96 DPI)", "Low (150 DPI)", "Medium (300 DPI)", "High (600 DPI)", "Custom"})
      Me._cmbPrintQuality.Location = New System.Drawing.Point(119, 19)
      Me._cmbPrintQuality.Name = "_cmbPrintQuality"
      Me._cmbPrintQuality.Size = New System.Drawing.Size(213, 21)
      Me._cmbPrintQuality.TabIndex = 4
      '		 Me._cmbPrintQuality.SelectedIndexChanged += New System.EventHandler(Me._cmbPrintQuality_SelectedIndexChanged);
      ' 
      ' _lblResolution
      ' 
      Me._lblResolution.AutoSize = True
      Me._lblResolution.Location = New System.Drawing.Point(8, 23)
      Me._lblResolution.Name = "_lblResolution"
      Me._lblResolution.Size = New System.Drawing.Size(63, 13)
      Me._lblResolution.TabIndex = 0
      Me._lblResolution.Text = "Print Quality"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(291, 236)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 8
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '		 Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
      ' 
      ' _btnOk
      ' 
      Me._btnOk.Location = New System.Drawing.Point(210, 236)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 7
      Me._btnOk.Text = "Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      '		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
      ' 
      ' _btnRestoreDefault
      ' 
      Me._btnRestoreDefault.Location = New System.Drawing.Point(4, 236)
      Me._btnRestoreDefault.Name = "_btnRestoreDefault"
      Me._btnRestoreDefault.Size = New System.Drawing.Size(106, 23)
      Me._btnRestoreDefault.TabIndex = 6
      Me._btnRestoreDefault.Text = "&Restore Default"
      Me._btnRestoreDefault.UseVisualStyleBackColor = True
      '		 Me._btnRestoreDefault.Click += New System.EventHandler(Me._btnRestoreDefault_Click);
      ' 
      ' label2
      ' 
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(178, 50)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(79, 13)
      Me.label2.TabIndex = 6
      Me.label2.Text = "(50 - 1600) DPI"
      ' 
      ' FrmSpecifications
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(371, 266)
      Me.Controls.Add(Me._btnRestoreDefault)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._grpGraphics)
      Me.Controls.Add(Me._grpMargins)
      Me.Controls.Add(Me._grpOrientation)
      Me.Controls.Add(Me._grpPaperSize)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FrmSpecifications"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Printer Options"
      Me._grpPaperSize.ResumeLayout(False)
      Me._grpPaperSize.PerformLayout()
      Me._grpOrientation.ResumeLayout(False)
      Me._grpOrientation.PerformLayout()
      Me._grpMargins.ResumeLayout(False)
      Me._grpMargins.PerformLayout()
      Me._grpGraphics.ResumeLayout(False)
      Me._grpGraphics.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _grpPaperSize As System.Windows.Forms.GroupBox
   Private _grpOrientation As System.Windows.Forms.GroupBox
   Private _grpMargins As System.Windows.Forms.GroupBox
   Private _grpGraphics As System.Windows.Forms.GroupBox
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _cmbEmulatePrinter As System.Windows.Forms.ComboBox
   Private _lblEmulatePrinter As System.Windows.Forms.Label
   Private WithEvents _cmbPrintQuality As System.Windows.Forms.ComboBox
   Private _lblResolution As System.Windows.Forms.Label
   Private WithEvents _btnRestoreDefault As System.Windows.Forms.Button
   Private _lblPaperSize As System.Windows.Forms.Label
   Private WithEvents _cmbPaperSize As System.Windows.Forms.ComboBox
   Private _rdLandscape As System.Windows.Forms.RadioButton
   Private _rdPortrait As System.Windows.Forms.RadioButton
   Private _radioCentimeters As System.Windows.Forms.RadioButton
   Private _radioInches As System.Windows.Forms.RadioButton
   Private WithEvents _txtHeight As System.Windows.Forms.TextBox
   Private label1 As System.Windows.Forms.Label
   Private WithEvents _txtWidth As System.Windows.Forms.TextBox
   Private WithEvents _txtCustomQuality As System.Windows.Forms.TextBox
   Private label3 As System.Windows.Forms.Label
   Private _lblpaperInfo As System.Windows.Forms.Label
   Private label2 As System.Windows.Forms.Label
#End Region

#Region "Constructor..."
   Public Sub New(ByVal specifications As PrinterSpecifications, ByVal printDocument As PrintDocument)
      InitializeComponent()

      _printDocument = printDocument
      _specifications = specifications

      If specifications Is Nothing Then
         Return
      End If

      For Each size As PaperSize In _printDocument.DefaultPageSettings.PrinterSettings.PaperSizes
         _paperIds.Add(size.RawKind)

         If size.RawKind = specifications.PaperID Then
            _cmbPaperSize.SelectedIndex = _paperIds.IndexOf(size.RawKind)
         End If
      Next size

      Dim installedPrinters As String() = New String(PrinterSettings.InstalledPrinters.Count - 1) {}
      PrinterSettings.InstalledPrinters.CopyTo(installedPrinters, 0)
      _cmbEmulatePrinter.Items.AddRange(installedPrinters)

      _txtWidth.Text = specifications.PaperWidth.ToString()
      _txtHeight.Text = specifications.PaperHeight.ToString()

      _radioInches.Checked = specifications.DimensionsInInches
      _radioCentimeters.Checked = Not specifications.DimensionsInInches

      _rdPortrait.Checked = specifications.PortraitOrient
      _rdLandscape.Checked = Not specifications.PortraitOrient

      _cmbEmulatePrinter.Text = specifications.MarginsPrinter

      _txtCustomQuality.Text = "50"

      Select Case specifications.PrintQuality
         Case -1
            _cmbPrintQuality.SelectedIndex = 0

         Case -2
            _cmbPrintQuality.SelectedIndex = 1

         Case -3
            _cmbPrintQuality.SelectedIndex = 2

         Case -4
            _cmbPrintQuality.SelectedIndex = 3

         Case Else
            _cmbPrintQuality.SelectedIndex = 4
            _txtCustomQuality.Text = specifications.PrintQuality.ToString()
      End Select
   End Sub
#End Region

#Region "Properties..."
   Public ReadOnly Property PaperID() As Integer
      Get
         Return _paperIds(_cmbPaperSize.SelectedIndex)
      End Get
   End Property

   Public ReadOnly Property PaperSizeName() As String
      Get
         Return _cmbPaperSize.Text
      End Get
   End Property

   Public ReadOnly Property PaperWidth() As Double
      Get
         Dim Value As Double = Convert.ToDouble(_txtWidth.Text)

         If _radioCentimeters.Checked Then
            Value = Value / 2.54
         End If

         Return Value
      End Get
   End Property

   Public ReadOnly Property PaperHeight() As Double
      Get
         Dim Value As Double = Convert.ToDouble(_txtHeight.Text)

         If _radioCentimeters.Checked Then
            Value = Value / 2.54
         End If

         Return Value
      End Get
   End Property

   Public ReadOnly Property InInches() As Boolean
      Get
         Return _radioInches.Checked
      End Get
   End Property

   Public ReadOnly Property Portrait() As Boolean
      Get
         Return _rdPortrait.Checked
      End Get
   End Property

   Public ReadOnly Property MarginsPrinter() As String
      Get
         Return _cmbEmulatePrinter.Text
      End Get
   End Property

   Public ReadOnly Property PrintQuality() As Integer
      Get
         Select Case _cmbPrintQuality.SelectedIndex
            Case 0
               Return -1

            Case 1
               Return -2

            Case 2
               Return -3

            Case 3
               Return -4

            Case Else
               Return Convert.ToInt32(_txtCustomQuality.Text)
         End Select
      End Get
   End Property

#End Region

   Private Sub _cmbPaperSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbPaperSize.SelectedIndexChanged
      If _cmbPaperSize.SelectedIndex < _printDocument.DefaultPageSettings.PrinterSettings.PaperSizes.Count Then
         Dim width As Double = CDbl(_printDocument.DefaultPageSettings.PrinterSettings.PaperSizes(_cmbPaperSize.SelectedIndex).Width) / 100.0
         Dim height As Double = CDbl(_printDocument.DefaultPageSettings.PrinterSettings.PaperSizes(_cmbPaperSize.SelectedIndex).Height) / 100.0
         _lblpaperInfo.Text = width.ToString() & " x " & height.ToString() & " Inches"
      End If
   End Sub

   Private Sub _cmbPrintQuality_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbPrintQuality.SelectedIndexChanged
      _txtCustomQuality.Enabled = (_cmbPrintQuality.SelectedIndex = 4)
   End Sub

   Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
      DialogResult = DialogResult.OK
   End Sub

   Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
      DialogResult = DialogResult.Cancel
   End Sub

   Private Sub _txtBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _txtHeight.KeyPress, _txtWidth.KeyPress, _txtCustomQuality.KeyPress
      If (Not Char.IsDigit(e.KeyChar)) AndAlso (Not Char.IsControl(e.KeyChar)) Then
         e.Handled = True
      End If
   End Sub

   Private Sub _txtCustomQuality_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _txtCustomQuality.Leave
      Try
         If _txtCustomQuality.Text.Length = 0 Then
            _txtCustomQuality.Text = "0"
         End If

         Dim value As Integer = Convert.ToInt32(_txtCustomQuality.Text)
         If value < 50 OrElse value > 1600 Then
            MessageBox.Show(Me, "Custom resolution values should be between 50 and 1600.")
            _txtCustomQuality.Focus()
         End If
      Catch e1 As OverflowException
         MessageBox.Show(Me, "Custom resolution values should be between 50 and 1600.")
         _txtCustomQuality.Focus()
      End Try
   End Sub

   Private Sub _txtWidth_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _txtWidth.Leave
      Try
         If _txtWidth.Text.Length = 0 Then
            _txtWidth.Text = "0"
         End If

         Dim value As Integer = Convert.ToInt32(_txtWidth.Text)
      Catch e1 As OverflowException
         MessageBox.Show(Me, "Value is too large.")
         _txtWidth.Focus()
      End Try
   End Sub

   Private Sub _txtHeight_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _txtHeight.Leave
      Try
         If _txtHeight.Text.Length = 0 Then
            _txtHeight.Text = "0"
         End If

         Dim value As Integer = Convert.ToInt32(_txtHeight.Text)
      Catch e1 As OverflowException
         MessageBox.Show(Me, "Value is too large.")
         _txtHeight.Focus()
      End Try
   End Sub

   Private Sub _btnRestoreDefault_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnRestoreDefault.Click
      For Each size As PaperSize In _printDocument.DefaultPageSettings.PrinterSettings.PaperSizes
         _paperIds.Add(size.RawKind)

         If size.RawKind = _specifications.PaperID Then
            _cmbPaperSize.SelectedIndex = _paperIds.IndexOf(size.RawKind)
         End If
      Next size

      _txtWidth.Text = _specifications.PaperWidth.ToString()
      _txtHeight.Text = _specifications.PaperHeight.ToString()

      _radioInches.Checked = _specifications.DimensionsInInches
      _radioCentimeters.Checked = Not _specifications.DimensionsInInches

      _rdPortrait.Checked = _specifications.PortraitOrient
      _rdLandscape.Checked = Not _specifications.PortraitOrient

      _cmbEmulatePrinter.Text = _specifications.MarginsPrinter

      _txtCustomQuality.Text = "50"

      Select Case _specifications.PrintQuality
         Case -1
            _cmbPrintQuality.SelectedIndex = 0

         Case -2
            _cmbPrintQuality.SelectedIndex = 1

         Case -3
            _cmbPrintQuality.SelectedIndex = 2

         Case -4
            _cmbPrintQuality.SelectedIndex = 3

         Case Else
            _cmbPrintQuality.SelectedIndex = 4
            _txtCustomQuality.Text = _specifications.PrintQuality.ToString()
      End Select
   End Sub
End Class
