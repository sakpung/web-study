' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System
Imports System.ComponentModel

<Serializable()> _
Public Class MyOptions
   Public Sub New()
   End Sub

   <Description("The directory containing the input image files to convert")> _
   Public Property InputFolder() As String
      Get
         Return m_InputFolder
      End Get
      Set(value As String)
         m_InputFolder = value
      End Set
   End Property
   Private m_InputFolder As String

   <Description("Extension to use (wildcards, for example, *.tif). Leave empty to convert all the files in the input directory")> _
   Public Property Extension() As String
      Get
         Return m_Extension
      End Get
      Set(value As String)
         m_Extension = value
      End Set
   End Property
   Private m_Extension As String

   <Description("The directory where the output documents are generated")> _
   Public Property OutputFolder() As String
      Get
         Return m_OutputFolder
      End Get
      Set(value As String)
         m_OutputFolder = value
      End Set
   End Property
   Private m_OutputFolder As String

   <Description("Stop the conversion on first error. Otherwise, continue converting the next input file")> _
   Public Property StopOnFirstError() As Boolean
      Get
         Return m_StopOnFirstError
      End Get
      Set(value As Boolean)
         m_StopOnFirstError = value
      End Set
   End Property
   Private m_StopOnFirstError As Boolean

   Public Function Clone() As MyOptions
      Dim result As MyOptions = New MyOptions()
      result.InputFolder = Me.InputFolder
      result.Extension = Me.Extension
      result.OutputFolder = Me.OutputFolder
      result.StopOnFirstError = Me.StopOnFirstError
      Return result
   End Function

   Public Shared XmlFileName As String

   Private Shared Function GetOutputFileName() As String
      If String.IsNullOrEmpty(XmlFileName) Then
         Throw New InvalidOperationException("Set XmlFileName before calling this method")
      End If

      Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), XmlFileName & Convert.ToString(".xml"))
   End Function

   Private Shared _serializer As New XmlSerializer(GetType(MyOptions))

   ' Load the preferences from local application data, if not found or error, returns default preferences
   Public Shared Function Load() As MyOptions
      Try
         Dim file__1 As String = GetOutputFileName()
         If File.Exists(file__1) Then
            Using reader As XmlTextReader = New XmlTextReader(file__1)
               Return TryCast(_serializer.Deserialize(reader), MyOptions)
            End Using
         End If
      Catch ex As Exception
         Debug.WriteLine(ex.Message)
      End Try

      Return New MyOptions()
   End Function

   ' Save the preferences to local application data
   Public Sub Save()
      Try
         Dim file As String = GetOutputFileName()
         Using writer As XmlTextWriter = New XmlTextWriter(file, Encoding.Unicode)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2
            _serializer.Serialize(writer, Me)
         End Using
      Catch
      End Try
   End Sub
End Class
