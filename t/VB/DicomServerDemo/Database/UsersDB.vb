' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Leadtools.Demos

Namespace Leadtools.Demos.Database
    ''' <summary>
    ''' Holds user info.
    ''' </summary>
    Public Class UserInfo
        Private _AETitle As String
        Private _IPAddress As String
        Friend _Id As String
        Private _Port As Integer
        Private _Timeout As Integer

        Public ReadOnly Property Id() As String
            Get
                Return _Id
            End Get
        End Property

        Public Property AETitle() As String
            Get
                Return _AETitle
            End Get
            Set(ByVal value As String)
                _AETitle = value
            End Set
        End Property

        Public Property IPAddress() As String
            Get
                Return _IPAddress
            End Get
            Set(ByVal value As String)
                _IPAddress = value
            End Set
        End Property

        Public Property Port() As Integer
            Get
                Return _Port
            End Get
            Set(ByVal value As Integer)
                _Port = value
            End Set
        End Property

        Public Property Timeout() As Integer
            Get
                Return _Timeout
            End Get
            Set(ByVal value As Integer)
                _Timeout = value
            End Set
        End Property

        Public Sub New()
        End Sub
    End Class

    ''' <summary>
    ''' Summary description for User.
    ''' </summary>
    Public Class UsersDB : Inherits DBBase
        Public Sub New(ByVal dbFileName As String)
            Me.dbFileName = dbFileName

            If (Not LoadDatabase()) Then
                CreateDatabase()
            End If
        End Sub

        Private Function CreateDatabase() As Boolean
            Dim created As Boolean = True

            Try
                Dim table As DataTable

                table = ds.Tables.Add("Users")
                table.Columns.Add("Id", GetType(String))
                table.Columns.Add("AETitle", GetType(String))
                table.Columns.Add("IPAddress", GetType(String))
                table.Columns.Add("Port", GetType(Integer))
                table.Columns.Add("Timeout", GetType(Integer))

                Save()
            Catch
                created = False
            End Try

            Return created
        End Function

        Public Function AddUser(ByRef user As UserInfo) As Boolean
            Dim added As Boolean = False
            Dim dr As DataRow

            dr = ds.Tables("Users").NewRow()
            If Not dr Is Nothing Then
                Dim id As String = Guid.NewGuid().ToString()

                dr("Id") = id
                dr("AETitle") = user.AETitle
                dr("IPAddress") = user.IPAddress
                dr("Port") = user.Port
                dr("Timeout") = user.Timeout

                ds.Tables("Users").Rows.Add(dr)
                user._Id = id
            End If
            Return added
        End Function

        Public Function LoadUser(ByVal i As Integer) As UserInfo
            Dim user As UserInfo = New UserInfo()
            Dim dr As DataRow

            dr = ds.Tables("Users").Rows(i)
            If Not dr Is Nothing Then
                user._Id = dr("Id").ToString()
                user.AETitle = dr("AETitle").ToString()
                user.IPAddress = dr("IPAddress").ToString()
                user.Port = Convert.ToInt32(dr("Port"))
                user.Timeout = Convert.ToInt32(dr("Timeout"))
            End If

            Return user
        End Function

        Public Function LoadUser(ByVal id As String) As UserInfo
            Dim user As UserInfo = New UserInfo()
            Dim dv As DataView = New DataView(ds.Tables("Users"))
            If Not dv Is Nothing Then
                dv.RowFilter = "Id = '" & id & "'"
                user._Id = dv(0)("Id").ToString()
                user.AETitle = dv(0)("AETitle").ToString()
                user.IPAddress = dv(0)("IPAddress").ToString()
                user.Port = Convert.ToInt32(dv(0)("Port"))
                user.Timeout = Convert.ToInt32(dv(0)("Timeout"))
            End If

            Return user
        End Function

        Public Function LoadUser(ByVal ipAddress As String, ByVal aeTitle As String) As UserInfo
            Dim user As UserInfo = New UserInfo()
            Dim dv As DataView = New DataView(ds.Tables("Users"))
            ipAddress = DemosGlobal.CleanIp(ipAddress)
            If Not dv Is Nothing Then
                Dim filter As String

                filter = "IPAddress = '" & ipAddress & "' "
                filter &= "AND AETitle = '" & aeTitle & "'"
                dv.RowFilter = filter

                user._Id = dv(0)("Id").ToString()
                user.AETitle = dv(0)("AETitle").ToString()
                user.IPAddress = dv(0)("IPAddress").ToString()
                user.Port = Convert.ToInt32(dv(0)("Port"))
                user.Timeout = Convert.ToInt32(dv(0)("Timeout"))
            End If

            Return user
        End Function

        Public Function LoadMoveAE(ByVal aeTitle As String) As UserInfo
            Dim user As UserInfo = New UserInfo()
            Dim dv As DataView = New DataView(ds.Tables("Users"))
            If Not dv Is Nothing Then
                Dim filter As String

                filter = "AETitle = '" & aeTitle & "'"
                dv.RowFilter = filter

                If dv.Count = 0 Then
                    Return Nothing
                End If

                user._Id = dv(0)("Id").ToString()
                user.AETitle = dv(0)("AETitle").ToString()
                user.IPAddress = dv(0)("IPAddress").ToString()
                user.Port = Convert.ToInt32(dv(0)("Port"))
                user.Timeout = Convert.ToInt32(dv(0)("Timeout"))
            End If

            Return user
        End Function

        Public Sub UpdateUser(ByVal user As UserInfo)
            Dim dv As DataView = New DataView(ds.Tables("Users"))

            If Not dv Is Nothing Then
                dv.RowFilter = "Id = '" & user.Id & "'"
                dv(0).BeginEdit()
                dv(0)("AETitle") = user.AETitle
                dv(0)("IPAddress") = user.IPAddress
                dv(0)("Port") = user.Port
                dv(0)("Timeout") = user.Timeout
                dv(0).EndEdit()
            End If
        End Sub

        Public Sub RemoveUser(ByVal id As String)
            Dim dv As DataView = New DataView(ds.Tables("Users"))

            If Not dv Is Nothing Then
                Dim dr As DataRow

                dv.RowFilter = "Id = '" & id & "'"
                dr = dv(0).Row
                If Not dr Is Nothing Then
                    ds.Tables("Users").Rows.Remove(dr)
                End If
            End If
        End Sub

        Public Function FindUser(ByVal ipAddress As String) As Boolean
            Dim dv As New DataView(ds.Tables("Users"))

            If dv IsNot Nothing Then
                ipAddress = DemosGlobal.CleanIp(ipAddress)
                dv.RowFilter = "IPAddress = '" & ipAddress & "'"
                Return dv.Count > 0
            End If
            Return False
        End Function

        Public Function FindUser(ByVal ipAddress As String, ByVal aeTitle As String) As Boolean
            Dim dv As New DataView(ds.Tables("Users"))

            If dv IsNot Nothing Then
                Dim filter As String
                ipAddress = DemosGlobal.CleanIp(ipAddress)
                filter = "IPAddress = '" & ipAddress & "' "
                filter &= "AND AETitle = '" & aeTitle & "'"
                dv.RowFilter = filter
                Return dv.Count > 0
            End If
            Return False
        End Function
    End Class
End Namespace
