' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms

Imports Leadtools

Namespace DicomDemo
   Public NotInheritable Class Tools
      Private Sub New()
      End Sub

      Public Shared Sub FillComboBoxWithEnum(ByVal theComboBox As ComboBox, ByVal theType As Type, ByVal defaultSelected As Object)
         FillComboBoxWithEnum(theComboBox, theType, defaultSelected, Nothing)
      End Sub

      Public Shared Sub FillComboBoxWithEnum(ByVal theComboBox As ComboBox, ByVal theType As Type, ByVal defaultSelected As Object, ByVal doNotAdd As Object())
         'string itemName;
         'Array a = Enum.GetValues(theType);
         'foreach(object i in a)
         '{
         '   bool add = true;

         '   if(doNotAdd != null)
         '   {
         '      for(int j = 0; j < doNotAdd.Length && add; j++)
         '      {
         '         if((int)i == (int)doNotAdd[j])
         '            add = false;
         '      }
         '   }

         '   if(add)
         '   {
         '      itemName = Constants.GetNameFromValue(theType, i);
         '      theComboBox.Items.Add(itemName);
         '      if(string.Compare(Constants.GetNameFromValue(theType, defaultSelected), itemName) == 0)
         '         theComboBox.SelectedItem = itemName;
         '   }
         '}

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
         If res = System.Windows.Forms.DialogResult.OK Then
            color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color)
         End If

         Return res = System.Windows.Forms.DialogResult.OK
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

        	  Public Shared Sub ShowUidTable()
		 Dim dlgUID As New UniqueIdentifierDlg()

		 dlgUID.ShowDialog()
	  End Sub

	  Public Shared Sub ShowTagTable()
		 Try
			Dim dlgTag As New ElementTagDlg()

			dlgTag.ShowDialog()
		 Catch exception As Exception
			System.Diagnostics.Debug.Assert(False)

			Throw exception
		 Finally
		 End Try
	  End Sub

	  Public Shared Sub ShowIodTable()
		 Try
			Dim dlgIOD As New InformationObjectDefinitionDlg()
			dlgIOD.ShowDialog()
		 Catch exception As Exception
			System.Diagnostics.Debug.Assert(False)

			Throw exception
		 Finally
		 End Try
	  End Sub

	  Public Shared Sub ShowContextGroupTable()
		 Try
			Dim dlgContext As New ContextGroupDlg()
			dlgContext.ShowDialog()
		 Catch exception As Exception
			System.Diagnostics.Debug.Assert(False)

			Throw exception
		 Finally
		 End Try
	  End Sub
   End Class

   Public Module Extensions
      ' converts an enum value to an integer
      <System.Runtime.CompilerServices.Extension()> _
      Public Function ToInt(ByVal enumValue As System.Enum) As Integer
         Return CInt(Fix(CObj(enumValue)))
      End Function

      ' returns true if the flags 'field' has the flag 'value' set
      <System.Runtime.CompilerServices.Extension()> _
      Public Function IsFlagged(ByVal field As System.Enum, ByVal value As System.Enum) As Boolean
         Return (field.ToInt() And value.ToInt()) = value.ToInt()
      End Function
   End Module
End Namespace
