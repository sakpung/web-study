' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools
Imports Leadtools.Jpeg2000

'Namespace JPXDemo
'
' Save List and Composite List Structure...
'
Public Structure ListItem
   Public Name As String
   Public Image As RasterImage

   Public Overrides Function ToString() As String
      Return Name
   End Function

   Public Sub New(ByVal _name As String, ByVal _image As RasterImage)
      Name = _name
      Image = _image
   End Sub
End Structure

' 
'  Append GML Structure
' 
Public Structure GMLListItem
   Public Label As String
   Public Name As String
   Public GMLElement As GmlElement

   Public Overrides Function ToString() As String
      Return Name
   End Function

   Public Sub New(ByVal _label As String, ByVal _name As String, ByVal _gmlElement As GmlElement)
      Label = _label
      Name = _name
      GMLElement = _gmlElement
   End Sub
End Structure

' 
'  Get File Information Dialog Structures...
' 
Public Structure FileInformationSortStructure
   Public type As Integer
   Public offset As Integer
   Public size As Integer
End Structure

Public Structure JPXFileInfoStructure
   Public fileName As String
   Public fileInformation As Jpeg2000FileInformation
   Public prepared As Boolean
   Public boxes() As FileInformationSortStructure
   Public boxesNumber As Integer
   Public groups() As FileInformationSortStructure
   Public groupsNumber As Integer
   Public totalSize As Integer
End Structure

' 
'  Fragment Jpx Dialog Structure...
' 
Public Structure FragmentJpxStructure
   Public inJPG2FileName As String
   Public outJPG2FileName As String
   Public streamFileName As String
End Structure

' 
'  Extract Frames Dialog Structure...
' 
Public Structure ExtractFrameStructure
   Public inJPG2FileName As String
   Public outJPG2FileName As String
End Structure

' 
'  Save Animation Settings Structure...
' 
Public Structure SaveAnimationSettings
   Public jPG2FileName As String
   Public animationWidth As Integer
   Public animationHeight As Integer
   Public animationLoop As Boolean
   Public animationDelay As Integer
End Structure

' 
'  Digital Signature Structure...
' 
Public Structure DigitalSignatureStructure
   Public jPG2FileName As String
   Public signatureType As Integer
   Public pointerType As Integer
   Public offset As Integer
   Public length As Integer
   Public data() As Byte
End Structure

' 
'  Read Box Structure...
' 
Public Structure ReadBoxCommonStructure
   Public dialogName As String
   Public jPG2FileName As String
   Public data() As Byte
   Public boxType As Jpeg2000BoxType
End Structure

' 
'  Append GML Structure...
' 
Public Structure AppendGMLStructure
   Public jPG2FileName As String
   Public xMLFileName As String
   Public gMLData As GmlData
End Structure

' 
'  Binary Fitler Structure
' 
Public Structure AppendCommonStructure
   Public dialogName As String
   Public jPG2FileName As String
   Public type As UuidId
   Public data() As Byte
End Structure

