' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization

Imports Leadtools.Caching
Imports Leadtools.Document.Viewer

' Demo preferences and global settings
' Can be loaded/saved from %LocalApplicationData%\DocumentViewerDemo.xml
<Serializable()> _
Public Structure Preferences
   ' Directory where cache is stored
   Public CacheDir As String

   ' Last successful document file and annotations we opened, so we-try to re-open in the demo
   Public LastDocumentFileName As String
   Public LastAnnotationsFileName As String
   Public LastFileLoadEmbeddedAnnotations As Boolean
   Public LastDocumentFirstPageNumber As Integer
   Public LastDocumentLastPageNumber As Integer
   ' Last successful document URL we opened, so we-try to re-open in the demo
   Public LastDocumentUri As String
   Public LastDocumentUriFirstPageNumber As Integer
   Public LastDocumentUriLastPageNumber As Integer
   Public LastAnnotationsUri As String
   Public LastUriLoadEmbeddedAnnotations As Boolean
   ' Preferred item type
   Public PreferredItemType As DocumentViewerItemType
   ' Show the operations output window
   Public ShowOperations As Boolean
   ' Show the text indicators on thumbnails and viewer
   Public ShowTextIndicators As Boolean
   ' Automatically get the text of the document when needed
   Public AutoGetText As Boolean
   ' Enable annotations tool-tips
   Public EnableTooltips As Boolean
   ' Enable inertia-scroll
   Public EnableInertiaScroll As Boolean

   Public Shared ReadOnly Property [Default]() As Preferences
      Get
         Dim result As Preferences = New Preferences()

         ' Default directory to store the cache items
         result.CacheDir = Path.Combine(DemosGlobal.ImagesFolder, "cache")
         result.AutoGetText = True
         result.ShowOperations = True
         result.ShowTextIndicators = True
         result.EnableTooltips = True
         result.EnableInertiaScroll = True
         Return result
      End Get
   End Property

   Public Shared ReadOnly Property FileName() As String
      Get
         Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DocumentViewerDemo.xml")
      End Get
   End Property

   Private Shared _serializer As XmlSerializer

   ' Load the preferences from local application data, if not found or error, returns default preferences
   Public Shared Function Load() As Preferences
      Try
         Dim _file As String = FileName
         If File.Exists(_file) Then

            Dim reader As XmlTextReader = New XmlTextReader(_file)
            Try
               Return CType(_serializer.Deserialize(reader), Preferences)
            Finally
               CType(reader, IDisposable).Dispose()
            End Try
         End If
      Catch
      End Try

      Return Preferences.Default
   End Function

   ' Save the preferences to local application data
   Public Sub Save()
      Try
         Dim file As String = FileName

         Dim writer As XmlTextWriter = New XmlTextWriter(file, Encoding.Unicode)
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
      _serializer = New XmlSerializer(GetType(Preferences))
   End Sub
End Structure
