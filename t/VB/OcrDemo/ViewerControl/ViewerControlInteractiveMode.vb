' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Text

Namespace OcrDemo.ViewerControl
   ''' <summary>
   ''' The current interactive mode (using the mouse on) of the viewer control
   ''' </summary>
   Public Enum ViewerControlInteractiveMode
      ''' <summary>
      ''' None
      ''' </summary>
      SelectMode
      ''' <summary>
      ''' Pan mode
      ''' </summary>
      PanMode
      ''' <summary>
      ''' Zoom to selection mode
      ''' </summary>
      ZoomToSelectionMode
      ''' <summary>
      ''' Draw new zone mode
      ''' </summary>
      DrawZoneMode
   End Enum
End Namespace
