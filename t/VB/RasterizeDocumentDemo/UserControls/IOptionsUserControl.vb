' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs

' Used in all the options user controls
Public Interface IOptionsUserControl
   Sub SetData(ByVal rasterCodecsInstance As RasterCodecs)
   Function GetData(ByVal rasterCodecsInstance As RasterCodecs) As Boolean
End Interface
