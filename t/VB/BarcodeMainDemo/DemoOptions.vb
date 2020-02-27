' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Imports Leadtools.Barcode


' Current demo options, we can load/save this to disk
<Serializable()> _
Public Structure DemoOptions
   Public ReadOptionsGroupIndex As Integer
   Public ReadOptionsSymbologies As BarcodeSymbology()
   Public WriteOptionsGroupIndex As Integer
   Public WriteOptionsSymbology As BarcodeSymbology
   Public ReadBarcodesWhenOptionsDialogCloses As Boolean
   Public OpenCommonDialogFolder As String
   Public NewDocumentPages As Integer
   Public NewDocumentBitsPerPixel As Integer
   Public NewDocumentWidth As Integer
   Public NewDocumentHeight As Integer
   Public NewDocumentResolution As Integer

   Public Shared ReadOnly Property [Default]() As DemoOptions
      Get
         Dim obj As DemoOptions = New DemoOptions()
         obj.ReadOptionsGroupIndex = 0
         obj.ReadOptionsSymbologies = BarcodeEngine.GetSupportedSymbologies()
         obj.WriteOptionsGroupIndex = 0
         obj.WriteOptionsSymbology = BarcodeSymbology.EAN13
         obj.ReadBarcodesWhenOptionsDialogCloses = True
         obj.NewDocumentPages = 1
         obj.NewDocumentBitsPerPixel = 1
         obj.NewDocumentResolution = 300
         obj.NewDocumentWidth = CInt(8.5 * obj.NewDocumentResolution)
         obj.NewDocumentHeight = CInt(11.0 * obj.NewDocumentResolution)

#If LT_CLICKONCE Then
			obj.OpenCommonDialogFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
#Else
         obj.OpenCommonDialogFolder = DemosGlobal.ImagesFolder
#End If

         Return obj
      End Get
   End Property

   Private Shared ReadOnly Property DataFileName() As String
      Get
         Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BarcodeMainDemo.xml")
      End Get
   End Property

   Private Shared _serializer As XmlSerializer

   Public Shared Function Load() As DemoOptions
      Try
         If File.Exists(DataFileName) Then
            Dim reader As XmlTextReader = New XmlTextReader(DataFileName)
            Try
               Return CType(_serializer.Deserialize(reader), DemoOptions)
            Finally
               CType(reader, IDisposable).Dispose()
            End Try
         Else
            Return DemoOptions.Default
         End If
      Catch
         Return DemoOptions.Default
      End Try
   End Function

   Public Sub Save()
      Try
         Dim writer As XmlTextWriter = New XmlTextWriter(DataFileName, Encoding.Unicode)
         Try
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2
            _serializer.Serialize(writer, Me)
         Finally
            CType(writer, IDisposable).Dispose()
         End Try
      Catch
      End Try
   End Sub
   Shared Sub New()
      _serializer = New XmlSerializer(GetType(DemoOptions))
   End Sub
End Structure
