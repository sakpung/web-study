' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Pdf

Namespace PDFFileDemo
   Partial Public Class InitialViewOptionsControl : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub SetInitialViewOptions(ByVal initialViewOptions As PDFInitialViewOptions, ByVal totalPages As Integer)
         ' Initial View Options
         _pageModeComboBox.Items.Clear()
         Dim a As Array = System.Enum.GetValues(GetType(PDFPageModeType))
         For Each i As PDFPageModeType In a
            _pageModeComboBox.Items.Add(i)
         Next i
         _pageModeComboBox.SelectedItem = initialViewOptions.PageModeType

         _pageLayoutComboBox.Items.Clear()
         a = System.Enum.GetValues(GetType(PDFPageLayoutType))
         For Each i As PDFPageLayoutType In a
            _pageLayoutComboBox.Items.Add(i)
         Next i
         _pageLayoutComboBox.SelectedItem = initialViewOptions.PageLayoutType

         _pageFitTypeComboBox.Items.Clear()
         a = System.Enum.GetValues(GetType(PDFPageFitType))
         For Each i As PDFPageFitType In a
            _pageFitTypeComboBox.Items.Add(i)
         Next i

         Dim predefinedZoomValues As Integer() = {25, 50, 75, 100, 125, 150, 200, 400, 800, 1600, 2400, 3200, 6400}
         For Each i As Integer In predefinedZoomValues
            _pageFitTypeComboBox.Items.Add(String.Format("{0}%", i))
         Next i
         If initialViewOptions.ZoomPercent = 0 Then
            _pageFitTypeComboBox.SelectedItem = initialViewOptions.PageFitType
         Else
            Dim i As Integer = System.Enum.GetValues(GetType(PDFPageFitType)).Length
            Do While i < _pageFitTypeComboBox.Items.Count
               Dim pageFitType As String = CType(IIf(TypeOf _pageFitTypeComboBox.Items(i) Is String, _pageFitTypeComboBox.Items(i), Nothing), String)
               If (Not String.IsNullOrEmpty(pageFitType)) Then
                  Dim value As Double
                  Dim expression As String = New String(pageFitType.Trim().TakeWhile(Function(c) Char.IsDigit(c) OrElse c = "."c).ToArray())
                  If Double.TryParse(expression, value) Then
                     If value = initialViewOptions.ZoomPercent Then
                        _pageFitTypeComboBox.SelectedIndex = i
                        Exit Do
                     End If
                  End If
               End If
               i += 1
            Loop
         End If

         If _pageFitTypeComboBox.SelectedItem Is Nothing Then
            If initialViewOptions.ZoomPercent = 0 Then
               _pageFitTypeComboBox.SelectedIndex = 0
            Else
               _pageFitTypeComboBox.Text = String.Format("{0}%", initialViewOptions.ZoomPercent)
            End If
         End If

         _initialPageNumberEditBox.Text = initialViewOptions.PageNumber.ToString()
         _numberOfPagesLabel.Text = String.Format("of {0}", totalPages)
         _resizeWindowCheckBox.Checked = initialViewOptions.FitWindow
         _centerWindowCheckBox.Checked = initialViewOptions.CenterWindow

         _showDocumentTitleComboBox.Items.Clear()
         _showDocumentTitleComboBox.Items.Add("File Name")
         _showDocumentTitleComboBox.Items.Add("Document Title")
         If (initialViewOptions.DisplayDocTitle) Then
            _showDocumentTitleComboBox.SelectedIndex = 1
         Else
            _showDocumentTitleComboBox.SelectedIndex = 0
         End If
         _hideMenuBarCheckBox.Checked = initialViewOptions.HideMenubar
         _hideToolBarCheckBox.Checked = initialViewOptions.HideToolbar
         _hideWindowControlsCheckBox.Checked = initialViewOptions.HideWindowUI
      End Sub

      Public Sub UpdateInitialViewOptions(ByVal initialViewOptions As PDFInitialViewOptions)
         initialViewOptions.PageModeType = CType(_pageModeComboBox.SelectedItem, PDFPageModeType)
         initialViewOptions.PageLayoutType = CType(_pageLayoutComboBox.SelectedItem, PDFPageLayoutType)
         If _pageFitTypeComboBox.SelectedIndex >= 0 AndAlso _pageFitTypeComboBox.SelectedIndex < System.Enum.GetValues(GetType(PDFPageFitType)).Length Then
            ' Selected item is one of the original enum members, so just use it
            initialViewOptions.PageFitType = CType(_pageFitTypeComboBox.SelectedItem, PDFPageFitType)
            initialViewOptions.ZoomPercent = 0
         Else
            Dim pageFitType As String = _pageFitTypeComboBox.Text
            Dim value As Double
            Dim expression As String = New String(pageFitType.Trim().TakeWhile(Function(c) Char.IsDigit(c) OrElse c = "."c).ToArray())
            If Double.TryParse(expression, value) Then
               initialViewOptions.ZoomPercent = value
            End If
         End If

         Dim val As Integer
         If Integer.TryParse(_initialPageNumberEditBox.Text, val) Then
            initialViewOptions.PageNumber = val
         Else
            initialViewOptions.PageNumber = 1
         End If

         initialViewOptions.FitWindow = _resizeWindowCheckBox.Checked
         initialViewOptions.CenterWindow = _centerWindowCheckBox.Checked
         If (_showDocumentTitleComboBox.SelectedIndex = 1) Then
            initialViewOptions.DisplayDocTitle = True
         Else
            initialViewOptions.DisplayDocTitle = False
         End If
         initialViewOptions.HideMenubar = _hideMenuBarCheckBox.Checked
         initialViewOptions.HideToolbar = _hideToolBarCheckBox.Checked
         initialViewOptions.HideWindowUI = _hideWindowControlsCheckBox.Checked
      End Sub

      Private Sub _hideMenuBarCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles _hideMenuBarCheckBox.CheckedChanged
         ' Hide Window Controls and Hide Menubar doesn't work together even on Adobe Acrobat side, so we will uncheck the other one if one of them is checked
         If (_hideWindowControlsCheckBox.Checked) Then
            RemoveHandler _hideWindowControlsCheckBox.CheckedChanged, AddressOf _hideWindowControlsCheckBox_CheckedChanged
            _hideWindowControlsCheckBox.Checked = False
            AddHandler _hideWindowControlsCheckBox.CheckedChanged, AddressOf _hideWindowControlsCheckBox_CheckedChanged
         End If
      End Sub

      Private Sub _hideWindowControlsCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles _hideWindowControlsCheckBox.CheckedChanged
         ' Hide Window Controls and Hide Menubar doesn't work together even on Adobe Acrobat side, so we will uncheck the other one if one of them is checked
         If (_hideMenuBarCheckBox.Checked) Then
            RemoveHandler _hideMenuBarCheckBox.CheckedChanged, AddressOf _hideMenuBarCheckBox_CheckedChanged
            _hideMenuBarCheckBox.Checked = False
            AddHandler _hideMenuBarCheckBox.CheckedChanged, AddressOf _hideMenuBarCheckBox_CheckedChanged
         End If
      End Sub
   End Class
End Namespace
