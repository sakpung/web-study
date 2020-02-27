' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports BarcodeMainDemo.Leadtools.Demos

Partial Public Class NewDocumentDialog : Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public DocumentPages As Integer
   Public DocumentBitsPerPixel As Integer
   Public DocumentWidth As Integer
   Public DocumentHeight As Integer
   Public DocumentResolution As Integer

   Private Const _minimumSize As Integer = 10
   Private Const _maximumSize As Integer = 100000

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If (Not DesignMode) Then
         Dim commonResolutions As Integer() = {96, 150, 200, 300, 600}

         For Each commonResolution As Integer In commonResolutions
            _resolutionComboBox.Items.Add(commonResolution)
         Next commonResolution

         ' Sanity
         Dim index As Integer = _resolutionComboBox.Items.IndexOf(DocumentResolution)
         If index = -1 Then
            DocumentResolution = 300
         End If

         If DocumentWidth < _minimumSize OrElse DocumentWidth > _maximumSize Then
            DocumentWidth = CInt(8.5 * DocumentResolution)
         End If

         If DocumentHeight < _minimumSize OrElse DocumentHeight > _maximumSize Then
            DocumentHeight = CInt(11.0 * DocumentResolution)
         End If

         If DocumentPages < 1 OrElse DocumentPages > 1000 Then
            DocumentPages = 1
         End If

         _widthTextBox.Text = DocumentWidth.ToString()
         _heightTextBox.Text = DocumentHeight.ToString()
         _resolutionComboBox.SelectedItem = DocumentResolution
         _pagesNumericUpDown.Value = DocumentPages
         _bitsPerPixelComboBox.SelectedIndex = 0
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _okButton.Click
      If (Not GetValue(_widthTextBox, _minimumSize, _maximumSize, DocumentWidth)) OrElse (Not GetValue(_heightTextBox, _minimumSize, _maximumSize, DocumentHeight)) Then
         DialogResult = DialogResult.None
         Return
      End If

      DocumentResolution = CInt(_resolutionComboBox.SelectedItem)

      DocumentPages = CInt(_pagesNumericUpDown.Value)
      If DocumentPages < 1 OrElse DocumentPages > 100 Then
         MessageBox.Show(Me, DemosGlobalization.GetResxString(Me.GetType(), "Resx_ErrorMessage"), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         DialogResult = DialogResult.None
         Return
      End If

      Select Case _bitsPerPixelComboBox.SelectedIndex
         Case 1
            DocumentBitsPerPixel = 8

         Case 2
            DocumentBitsPerPixel = 24

         Case 3
            DocumentBitsPerPixel = 32

         Case Else
            DocumentBitsPerPixel = 1
      End Select
   End Sub

   Private Function GetValue(ByVal tb As TextBox, ByVal minimumValue As Integer, ByVal maximumValue As Integer, <System.Runtime.InteropServices.Out()> ByRef value As Integer) As Boolean
      If (Not Integer.TryParse(tb.Text, value)) OrElse value < minimumValue OrElse value > maximumValue Then
         tb.SelectAll()
         tb.Focus()
         MessageBox.Show(Me, String.Format(DemosGlobalization.GetResxString(Me.GetType(), "Resx_ErrorMessageValue"), minimumValue, maximumValue), DemosGlobalization.GetResxString(Me.GetType(), "Resx_Error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Return False
      End If

      Return True
   End Function
End Class
