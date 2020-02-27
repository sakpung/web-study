' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms

Imports Leadtools

Public NotInheritable Class Tools
   Private Sub New()
   End Sub

   Public Shared Sub FillComboBoxWithEnum(ByVal theComboBox As ComboBox, ByVal theType As Type, ByVal defaultSelected As Object)
      FillComboBoxWithEnum(theComboBox, theType, defaultSelected, Nothing)
   End Sub

   Public Shared Sub FillComboBoxWithEnum(ByVal theComboBox As ComboBox, ByVal theType As Type, ByVal defaultSelected As Object, ByVal doNotAdd() As Object)
      Dim itemName As String
      Dim a As Array = System.Enum.GetValues(theType)
      Dim i As Object
      For Each i In a
         Dim add As Boolean = True

         If Not (doNotAdd Is Nothing) Then
            Dim j As Integer = 0
            While (j < doNotAdd.Length AndAlso add)
               If (CType(i, Integer) = CType(doNotAdd(j), Integer)) Then
                  add = False
               End If
               j = j + 1
            End While
         End If

         If (add) Then
            itemName = Constants.GetNameFromValue(theType, i)
            theComboBox.Items.Add(itemName)
            If (String.Compare(Constants.GetNameFromValue(theType, defaultSelected), itemName) = 0) Then
               theComboBox.SelectedItem = itemName
            End If
         End If
      Next

      If (theComboBox.SelectedItem Is Nothing) Then
         theComboBox.SelectedIndex = 0
      End If
   End Sub

   Public Shared Function ShowColorDialog(ByVal owner As IWin32Window, ByRef color As RasterColor) As Boolean
      Dim dlg As ColorDialog = New ColorDialog
      dlg.AllowFullOpen = True
      dlg.AnyColor = True
      dlg.Color = Leadtools.Demos.Converters.ToGdiPlusColor(color)
      Dim res As DialogResult = dlg.ShowDialog(owner)
      If (res = DialogResult.OK) Then
         color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color)
      End If

      Return res = DialogResult.OK
   End Function

   Public Shared Function CanDrop(ByVal data As IDataObject) As Boolean
      Return data.GetDataPresent(DataFormats.Text) OrElse data.GetDataPresent(DataFormats.FileDrop)
   End Function

   Public Shared Function GetDropFiles(ByVal data As IDataObject) As String()
      If (data.GetDataPresent(DataFormats.Text)) Then
         Dim files(0) As String
         files(0) = CType(data.GetData(DataFormats.Text), String)
         Return files
      ElseIf (data.GetDataPresent(DataFormats.FileDrop)) Then
         Dim files() As String
         files = CType(data.GetData(DataFormats.FileDrop), String())
         Return files
      End If
      Return Nothing
   End Function
End Class
