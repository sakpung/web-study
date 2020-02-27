' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs

Public Class DocOptionsControl
    Implements IOptionsUserControl

    Private _fontSize As Integer

    ''' <summary>
    ''' Called by the owner to initialize
    ''' </summary>
    Public Sub SetData(ByVal rasterCodecsInstance As RasterCodecs) Implements IOptionsUserControl.SetData
        ' First fill the controls with possible values
        _bitDepthComboBox.Items.Add(New ValueNameItem(Of Integer)(1, "1 bits per pixel"))
        _bitDepthComboBox.Items.Add(New ValueNameItem(Of Integer)(4, "4 bits per pixel"))
        _bitDepthComboBox.Items.Add(New ValueNameItem(Of Integer)(8, "8 bits per pixel"))
        _bitDepthComboBox.Items.Add(New ValueNameItem(Of Integer)(24, "24 bits per pixel"))

        ' Now set the state of the controls
        Dim docLoadOptions As CodecsDocLoadOptions = rasterCodecsInstance.Options.Doc.Load
        _bitDepthComboBox.SelectedItem = ValueNameItem(Of Integer).SelectItem(docLoadOptions.BitsPerPixel, _bitDepthComboBox.Items)
    End Sub

    ''' <summary>
    ''' Called by the owner to get the data
    ''' </summary>
    Public Function GetData(ByVal rasterCodecsInstance As RasterCodecs) As Boolean Implements IOptionsUserControl.GetData
        Dim docLoadOptions As CodecsDocLoadOptions = rasterCodecsInstance.Options.Doc.Load

        ' Get the Doc load settings
        docLoadOptions.BitsPerPixel = ValueNameItem(Of Integer).GetSelectedItem(_bitDepthComboBox.SelectedItem)

        Return True
    End Function

   Private Sub _resetToDefaultsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _resetToDefaultsButton.Click
      _bitDepthComboBox.SelectedItem = ValueNameItem(Of Integer).SelectItem(24, _bitDepthComboBox.Items)
   End Sub
End Class
