' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.UI
   <System.Flags()> _
   Public Enum Corners
      None = 0
      TopLeft = 1
      TopRight = 2
      BottomLeft = 4
      BottomRight = 8
      All = TopLeft Or TopRight Or BottomLeft Or BottomRight
   End Enum
End Namespace
