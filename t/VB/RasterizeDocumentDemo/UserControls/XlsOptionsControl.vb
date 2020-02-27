' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs

Public Class XlsOptionsControl
   Implements IOptionsUserControl

   ''' <summary>
   ''' Called by the owner to initialize
   ''' </summary>
   Public Sub SetData(ByVal rasterCodecsInstance As RasterCodecs) Implements IOptionsUserControl.SetData
      ' Set the state of the controls

      Dim xlsLoadOptions As CodecsXlsLoadOptions = rasterCodecsInstance.Options.Xls.Load

      _multiPageSheetCheckBox.Checked = xlsLoadOptions.MultiPageSheet
   End Sub

   ''' <summary>
   ''' Called by the owner to get the data
   ''' </summary>
   Public Function GetData(ByVal rasterCodecsInstance As RasterCodecs) As Boolean Implements IOptionsUserControl.GetData
      Dim xlsLoadOptions As CodecsXlsLoadOptions = rasterCodecsInstance.Options.Xls.Load

      ' Get the XLS load settings
      xlsLoadOptions.MultiPageSheet = _multiPageSheetCheckBox.Checked

      Return True
   End Function

   Private Sub _resetToDefaultsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _resetToDefaultsButton.Click
      _multiPageSheetCheckBox.Checked = False
   End Sub
End Class
