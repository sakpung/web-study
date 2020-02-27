' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text

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
   ''' Select the region of interest in the image
   ''' </summary>
   RegionMode
   ''' <summary>
   ''' Reads a barcode with current options
   ''' </summary>
   ReadBarcodeMode
   ''' <summary>
   ''' Write new barcode mode
   ''' </summary>
   WriteBarcodeMode
End Enum
