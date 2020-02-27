' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO
Imports System.Windows.Forms

Namespace Leadtools.Demos
    Public Class ActiveScenario
        Public Property Filename() As String
            Get
                Return m_Filename
            End Get
            Set(ByVal value As String)
                m_Filename = Value
            End Set
        End Property
        Private m_Filename As String

        <XmlIgnore()> _
        Public Property Scenario() As Scenario
            Get
                Return m_Scenario
            End Get
            Set(ByVal value As Scenario)
                m_Scenario = Value
            End Set
        End Property
        Private m_Scenario As Scenario

        Public Sub New()
            Filename = String.Empty
        End Sub

        Public Shared Function Load() As ActiveScenario
            Dim serializer As New XmlSerializer(GetType(ActiveScenario))
            Dim filename As String = CCOWUtils.GetActiveScenarioFilename()
            Dim settings As ActiveScenario = Nothing

            If File.Exists(filename) Then
                settings = Deserialize(Of ActiveScenario)(filename)
            End If

            If settings Is Nothing Then
                settings = New ActiveScenario()
                settings.Filename = Application.StartupPath & "\P1_Default.scn"
            End If

            If Not String.IsNullOrEmpty(settings.Filename) Then
                settings.Scenario = Deserialize(Of Scenario)(settings.Filename)
            End If

            Return settings
        End Function

        Private Shared Function Deserialize(Of T)(ByVal filename As String) As T
            Dim serializer As New XmlSerializer(GetType(T))
            Dim serObject As T = Nothing

            If File.Exists(filename) Then
                Using stream As New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)
                    Try
                        serObject = CType(serializer.Deserialize(stream), T)
                        stream.Close()
                    Catch e As Exception
                        Console.WriteLine(e.Message)
                    End Try
                End Using
            End If

            If serObject Is Nothing Then
                serObject = Nothing
            End If
            Return serObject
        End Function

        Public Sub Save()
            Dim serializer As New XmlSerializer(GetType(ActiveScenario))
            Dim filename As String = CCOWUtils.GetActiveScenarioFilename()

            Using writer As TextWriter = New StreamWriter(filename)
                Try
                    serializer.Serialize(writer, Me)
                    writer.Close()
                Catch
                End Try
            End Using
        End Sub
    End Class
End Namespace
