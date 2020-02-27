' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs

Public Class RtfOptionsControl
   Implements IOptionsUserControl

   ''' <summary>
   ''' Called by the owner to initialize
   ''' </summary>
   Public Sub SetData(ByVal rasterCodecsInstance As RasterCodecs) Implements IOptionsUserControl.SetData
      ' Set the state of the controls

      Dim rtfLoadOptions As CodecsRtfLoadOptions = rasterCodecsInstance.Options.Rtf.Load

      _backColorPanel.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(rtfLoadOptions.BackColor)
   End Sub

   ''' <summary>
   ''' Called by the owner to get the data
   ''' </summary>
   Public Function GetData(ByVal rasterCodecsInstance As RasterCodecs) As Boolean Implements IOptionsUserControl.GetData
      Dim rtfLoadOptions As CodecsRtfLoadOptions = rasterCodecsInstance.Options.Rtf.Load

      ' Get the RTF load settings
      rtfLoadOptions.BackColor = Leadtools.Demos.Converters.FromGdiPlusColor(_backColorPanel.BackColor)

      Return True
   End Function

   Private Sub _backColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _backColorButton.Click
      Using dlg As New ColorDialog()
         dlg.Color = _backColorPanel.BackColor
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _backColorPanel.BackColor = dlg.Color
         End If
      End Using
   End Sub

   Private Sub _resetToDefaultsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _resetToDefaultsButton.Click
      _backColorPanel.BackColor = Color.White
   End Sub
End Class
