' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Microsoft.Win32
Imports System.Xml.Serialization
Imports System.IO
Imports System.Windows.Forms

Namespace Leadtools.Demos
    <Serializable()> _
    Public Class Scenario
        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(ByVal value As String)
                m_Description = Value
            End Set
        End Property
        Private m_Description As String
        Public Property MasterUserIndex() As List(Of MasterUser)
            Get
                Return m_MasterUserIndex
            End Get
            Set(ByVal value As List(Of MasterUser))
                m_MasterUserIndex = Value
            End Set
        End Property
        Private m_MasterUserIndex As List(Of MasterUser)
        Public Property MasterPatientIndex() As List(Of MasterPatient)
            Get
                Return m_MasterPatientIndex
            End Get
            Set(ByVal value As List(Of MasterPatient))
                m_MasterPatientIndex = Value
            End Set
        End Property
        Private m_MasterPatientIndex As List(Of MasterPatient)
        Public Property Applications() As List(Of CCOWApplication)
            Get
                Return m_Applications
            End Get
            Set(ByVal value As List(Of CCOWApplication))
                m_Applications = Value
            End Set
        End Property
        Private m_Applications As List(Of CCOWApplication)
        <XmlIgnore()> _
        Public Property Filename() As String
            Get
                Return m_Filename
            End Get
            Set(ByVal value As String)
                m_Filename = Value
            End Set
        End Property
        Private m_Filename As String

        Public Overrides Function ToString() As String
            If Not String.IsNullOrEmpty(Description) Then
                Return Description
            End If

            Return "No Description Provided"
        End Function

        Public Shared Function LoadScenarios() As List(Of Scenario)
            Dim scenarios As New List(Of Scenario)()

            For Each file As String In Directory.GetFiles(Application.StartupPath, "*.scn")
                Try
                    Dim serializer As New XmlSerializer(GetType(Scenario))

                    Using reader As New StreamReader(file)
                        Dim scenario As Scenario = Nothing

                        scenario = TryCast(serializer.Deserialize(reader), Scenario)
                        scenario.Filename = file
                        scenarios.Add(scenario)
                        reader.Close()
                    End Using
                Catch
                End Try
            Next

            Return scenarios
        End Function
    End Class

    <Serializable()> _
    Public Class User
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = Value
            End Set
        End Property
        Private m_Name As String
        Public Property Username() As String
            Get
                Return m_Username
            End Get
            Set(ByVal value As String)
                m_Username = Value
            End Set
        End Property
        Private m_Username As String
        Public Property Password() As String
            Get
                Return m_Password
            End Get
            Set(ByVal value As String)
                m_Password = Value
            End Set
        End Property
        Private m_Password As String
        Public Property DomainLogin() As Boolean
            Get
                Return m_DomainLogin
            End Get
            Set(ByVal value As Boolean)
                m_DomainLogin = Value
            End Set
        End Property
        Private m_DomainLogin As Boolean
        Public Property Domain() As String
            Get
                Return m_Domain
            End Get
            Set(ByVal value As String)
                m_Domain = Value
            End Set
        End Property
        Private m_Domain As String

        Public Sub New()
            DomainLogin = False
        End Sub

        Public Overrides Function ToString() As String
            If Not String.IsNullOrEmpty(Username) Then
                Return Username
            End If

            Return String.Empty
        End Function
    End Class

    <Serializable()> _
    Public Class MasterUser
        Inherits User
        Public Property ApplicationUsers() As List(Of ApplicationUser)
            Get
                Return m_ApplicationUsers
            End Get
            Set(ByVal value As List(Of ApplicationUser))
                m_ApplicationUsers = Value
            End Set
        End Property
        Private m_ApplicationUsers As List(Of ApplicationUser)

        Public Overrides Function ToString() As String
            If Not String.IsNullOrEmpty(Username) Then
                Return Username
            End If

            Return String.Empty
        End Function
    End Class

    <Serializable()> _
    Public Class ApplicationUser
        Public Property LogonName() As String
            Get
                Return m_LogonName
            End Get
            Set(ByVal value As String)
                m_LogonName = Value
            End Set
        End Property
        Private m_LogonName As String
        Public Property ApplicationName() As String
            Get
                Return m_ApplicationName
            End Get
            Set(ByVal value As String)
                m_ApplicationName = Value
            End Set
        End Property
        Private m_ApplicationName As String
    End Class

    <Serializable()> _
    Public Class Patient
        Public Property Id() As String
            Get
                Return m_Id
            End Get
            Set(ByVal value As String)
                m_Id = Value
            End Set
        End Property
        Private m_Id As String
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = Value
            End Set
        End Property
        Private m_Name As String
        Public Property BirthDate() As System.Nullable(Of DateTime)
            Get
                Return m_BirthDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                m_BirthDate = Value
            End Set
        End Property
        Private m_BirthDate As System.Nullable(Of DateTime)
        Public Property Sex() As String
            Get
                Return m_Sex
            End Get
            Set(ByVal value As String)
                m_Sex = Value
            End Set
        End Property
        Private m_Sex As String

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    Public Class MasterPatient
        Inherits Patient
        Public Property ApplicationPatients() As List(Of ApplicationPatient)
            Get
                Return m_ApplicationPatients
            End Get
            Set(ByVal value As List(Of ApplicationPatient))
                m_ApplicationPatients = Value
            End Set
        End Property
        Private m_ApplicationPatients As List(Of ApplicationPatient)
    End Class

    <Serializable()> _
    Public Class ApplicationPatient
        Public Property ApplicationName() As String
            Get
                Return m_ApplicationName
            End Get
            Set(ByVal value As String)
                m_ApplicationName = Value
            End Set
        End Property
        Private m_ApplicationName As String
        Public Property PatientId() As String
            Get
                Return m_PatientId
            End Get
            Set(ByVal value As String)
                m_PatientId = Value
            End Set
        End Property
        Private m_PatientId As String
    End Class

    <Serializable()> _
    Public Class CCOWApplication
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = Value
            End Set
        End Property
        Private m_Name As String
        Public Property Suffix() As String
            Get
                Return m_Suffix
            End Get
            Set(ByVal value As String)
                m_Suffix = Value
            End Set
        End Property
        Private m_Suffix As String
        Public Property Users() As List(Of User)
            Get
                Return m_Users
            End Get
            Set(ByVal value As List(Of User))
                m_Users = Value
            End Set
        End Property
        Private m_Users As List(Of User)
        Public Property Patients() As List(Of Patient)
            Get
                Return m_Patients
            End Get
            Set(ByVal value As List(Of Patient))
                m_Patients = Value
            End Set
        End Property
        Private m_Patients As List(Of Patient)
    End Class
End Namespace
