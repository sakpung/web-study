' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Drawing

Namespace Leadtools.Demos
   Public NotInheritable Class Tools
      Private Sub New()
      End Sub

      Public Shared Sub FillComboBoxWithEnum(ByVal theComboBox As ComboBox, ByVal theType As Type, ByVal defaultSelected As Object)
         FillComboBoxWithEnum(theComboBox, theType, defaultSelected, Nothing)
      End Sub

      Public Shared Sub FillComboBoxWithEnum(ByVal theComboBox As ComboBox, ByVal theType As Type, ByVal defaultSelected As Object, ByVal doNotAdd As Object())
         Dim itemName As String
         Dim a As Array = System.Enum.GetValues(theType)
         For Each i As Object In a
            Dim add As Boolean = True

            If Not doNotAdd Is Nothing Then
               Dim j As Integer = 0
               Do While j < doNotAdd.Length AndAlso add
                  If CInt(i) = CInt(doNotAdd(j)) Then
                     add = False
                  End If
                  j += 1
               Loop
            End If

            If add Then
               itemName = Constants.GetNameFromValue(theType, i)
               theComboBox.Items.Add(itemName)
               If String.Compare(Constants.GetNameFromValue(theType, defaultSelected), itemName) = 0 Then
                  theComboBox.SelectedItem = itemName
               End If
            End If
         Next i

         If theComboBox.SelectedItem Is Nothing Then
            theComboBox.SelectedIndex = 0
         End If
      End Sub

      Public Shared Function ShowColorDialog(ByVal owner As IWin32Window, ByRef color As RasterColor) As Boolean
         Dim dlg As ColorDialog = New ColorDialog()
         dlg.AllowFullOpen = True
         dlg.AnyColor = True
         dlg.Color = Leadtools.Demos.Converters.ToGdiPlusColor(color)
         Dim res As DialogResult = dlg.ShowDialog(owner)
         If res = DialogResult.OK Then
            color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color)
         End If

         Return res = DialogResult.OK
      End Function

      Public Shared Function CanDrop(ByVal data As IDataObject) As Boolean
         Return data.GetDataPresent(DataFormats.Text) OrElse data.GetDataPresent(DataFormats.FileDrop)
      End Function

      Public Shared Function GetDropFiles(ByVal data As IDataObject) As String()
         If data.GetDataPresent(DataFormats.Text) Then
            Dim files As String() = New String(0) {}
            files(0) = TryCast(data.GetData(DataFormats.Text), String)
            Return files
         ElseIf data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files As String() = TryCast(data.GetData(DataFormats.FileDrop), String())
            Return files
         End If

         Return Nothing
      End Function
   End Class
End Namespace
