' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Windows.Forms

Imports Leadtools
Imports System

Namespace AnimationDemo
   Public NotInheritable Class Tools
      Private Sub New()
      End Sub

      Public Shared Sub FillComboBoxWithEnum(theComboBox As ComboBox, theType As Type, defaultSelected As Object)
         FillComboBoxWithEnum(theComboBox, theType, defaultSelected, Nothing)
      End Sub

      Public Shared Sub FillComboBoxWithEnum(theComboBox As ComboBox, theType As Type, defaultSelected As Object, doNotAdd As Object())
         Dim itemName As String
         Dim a As Array = [Enum].GetValues(theType)
         For Each i As Object In a
            Dim add As Boolean = True

            If doNotAdd IsNot Nothing Then
               Dim j As Integer = 0
               While j < doNotAdd.Length AndAlso add
                  If CInt(i) = CInt(doNotAdd(j)) Then
                     add = False
                  End If
                  j += 1
               End While
            End If

            If add Then
               itemName = Constants.GetNameFromValue(theType, i)
               theComboBox.Items.Add(itemName)
               If String.Compare(Constants.GetNameFromValue(theType, defaultSelected), itemName) = 0 Then
                  theComboBox.SelectedItem = itemName
               End If
            End If
         Next

         If theComboBox.SelectedItem Is Nothing Then
            theComboBox.SelectedIndex = 0
         End If
      End Sub

      Public Shared Function ShowColorDialog(owner As IWin32Window, ByRef color As RasterColor) As Boolean
         Dim dlg As New ColorDialog()
         dlg.AllowFullOpen = True
         dlg.AnyColor = True
         dlg.Color = Leadtools.Demos.Converters.ToGdiPlusColor(color)
         Dim res As DialogResult = dlg.ShowDialog(owner)
         If res = DialogResult.OK Then
            color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color)
         End If

         Return res = DialogResult.OK
      End Function

      Public Shared Function CanDrop(data As IDataObject) As Boolean
         Return data.GetDataPresent(DataFormats.Text) OrElse data.GetDataPresent(DataFormats.FileDrop)
      End Function

      Public Shared Function GetDropFiles(data As IDataObject) As String()
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
