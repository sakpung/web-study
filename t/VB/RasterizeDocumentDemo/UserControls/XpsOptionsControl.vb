' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs

Public Class XpsOptionsControl
   Implements IOptionsUserControl

   ''' <summary>
   ''' Called by the owner to initialize
   ''' </summary>
   Public Sub SetData(ByVal rasterCodecsInstance As RasterCodecs) Implements IOptionsUserControl.SetData

      ' Set the state of the controls

      Dim xpsLoadOptions As CodecsXpsLoadOptions = rasterCodecsInstance.Options.Xps.Load
   End Sub

   ''' <summary>
   ''' Called by the owner to get the data
   ''' </summary>
   Public Function GetData(ByVal rasterCodecsInstance As RasterCodecs) As Boolean Implements IOptionsUserControl.GetData
      Dim xpsLoadOptions As CodecsXpsLoadOptions = rasterCodecsInstance.Options.Xps.Load

      Return True
   End Function
End Class
