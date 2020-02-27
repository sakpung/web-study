' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Ccow
Imports Leadtools.Demos
Imports Leadtools.Ccow.UI
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Namespace Leadtools.Demos
    Public Class ClientContext
        Implements IContextParticipant
        Private _ContextManager As IContextManager = Nothing
        Private _ParticipantCoupon As Integer = -1
        Private _Access As New List(Of String)()

        Private _Passcode As String = String.Empty
        Private _ApplicationName As String = String.Empty
        Private _Form As Form

        Public Event JoinedContext As EventHandler
		Public Event LeftContext As EventHandler

        Public ReadOnly Property Passcode() As String
            Get
                Return _Passcode
            End Get
        End Property

        Public ReadOnly Property PublicKey() As String
            Get
                If _KeyContainer IsNot Nothing Then
                    Return Utils.BinaryEncode(_KeyContainer.GetPublicKey())
                End If
                Return String.Empty
            End Get
        End Property

        Public ReadOnly Property Joined() As Boolean
            Get
                Return _ParticipantCoupon <> -1
            End Get
        End Property

        Private _Suspended As Boolean = False

        Public ReadOnly Property Suspended() As Boolean
            Get
                Return _Suspended
            End Get
        End Property

        Public ReadOnly Property CanPerformAuthenticateAction() As Boolean
            Get
                If _Access.Count = 0 Then
                    Return False
                End If

                Dim index As Integer = _Access.IndexOf("AuthenticateUser")
                If index <> -1 Then
                    Return _Access(index + 1).ToLower() = "set"
                End If
                Return False
            End Get
        End Property

        Public ReadOnly Property CanChangeUser() As Boolean
            Get
                If _Access.Count = 0 Then
                    Return False
                End If

                Dim index As Integer = _Access.IndexOf("User")
                If index <> -1 Then
                    Return _Access(index + 1).ToLower() = "set"
                End If
                Return False
            End Get
        End Property

        Private _KeyContainer As KeyContainer = Nothing

        Public ReadOnly Property KeyContainer() As KeyContainer
            Get
                Return _KeyContainer
            End Get
        End Property
        Public ReadOnly Property IsValid() As Boolean
            Get
                Return _ContextManager IsNot Nothing
            End Get
        End Property

        Public Event Terminated As EventHandler

        Private Sub OnTerminated()
            RaiseEvent Terminated(Me, EventArgs.Empty)
        End Sub

        Public Event ChangesAccepted As EventHandler(Of ContextEventArgs)

        Private Sub OnChangesAccepted(ByVal coupon As Integer)
            RaiseEvent ChangesAccepted(Me, New ContextEventArgs(coupon))
        End Sub

        Public Event ChangesCanceled As EventHandler(Of ContextEventArgs)

        Private Sub OnChangesCanceled(ByVal coupon As Integer)
            RaiseEvent ChangesCanceled(Me, New ContextEventArgs(coupon))
        End Sub

        Public Event ChangesPending As EventHandler(Of ContextEventArgs)

        Private Function OnChangesPending(ByVal coupon As Integer, ByRef reason As String) As String
            Dim decision As String = "accept"
            Dim e As New ContextEventArgs(coupon)

            If Not ChangesPendingEvent Is Nothing Then
                RaiseEvent ChangesPending(Me, e)
                reason = e.Reason
                decision = e.Decision                
            End If
            Return decision
        End Function

        Public Sub New(ByVal ApplicationName As String, ByVal passcode As String, ByVal form As Form)
            _ContextManager = Utils.COMCreateObject(Of IContextManager)("CCOW.ContextManager")
            _KeyContainer = New KeyContainer(ApplicationName)
            _ApplicationName = ApplicationName
            _Passcode = passcode
            _Form = form
        End Sub

        Public Sub Join(ByVal ApplicationName As String, ByVal survey As Boolean)
            _ParticipantCoupon = _ContextManager.JoinCommonContext(Me, ApplicationName, survey, True)
            RaiseEvent JoinedContext(Me, EventArgs.Empty)
        End Sub

        Public Sub Leave()
            If _ParticipantCoupon <> -1 Then
                _ContextManager.LeaveCommonContext(_ParticipantCoupon)
                _ParticipantCoupon = -1
                RaiseEvent LeftContext(Me, EventArgs.Empty)
            End If
        End Sub

        Public Sub Suspend()
            Try
                _ContextManager.SuspendParticipation(_ParticipantCoupon)
                _Suspended = True
            Catch e As Exception
                Messager.ShowError(Nothing, e)
            End Try
        End Sub

        Public Sub [Resume](ByVal wait As Boolean)
            Try
                _ContextManager.ResumeParticipation(_ParticipantCoupon, wait)
                _Suspended = False
            Catch e As Exception
                Messager.ShowError(Nothing, e)
            End Try
        End Sub

        Public Function SetSecure(ByVal s As Subject) As Boolean
            Try
                Dim secure As ISecureContextData = Access(Of ISecureContextData)()
                Dim v As New List(Of String)()
                Dim names As String() = s.ToItemNameArray()
                Dim values As Object() = s.ToItemValueArray()
                Dim reasons As Object
                Dim decision As String = "accept", appSignature As String = String.Empty
                Dim transaction As Integer
                Dim noContinue As Boolean = True, disconnect As Boolean = False

                transaction = _ContextManager.StartContextChanges(_ParticipantCoupon)
                For i As Integer = 0 To names.Length - 1
                    v.Add(values(i).ToString())
                Next

                appSignature = _ParticipantCoupon.ToString() & String.Join("", names) & String.Join("", v.ToArray()) & transaction.ToString()
                appSignature = CreateSignature(appSignature)
                secure.SetItemValues(_ParticipantCoupon, names, values, transaction, appSignature)
                reasons = _ContextManager.EndContextChanges(transaction, noContinue)

                '
                ' If any application responded that they cannot apply the change we need to display
                ' a dialog that displays the reasons for the problems.
                '
                If (reasons IsNot Nothing AndAlso CType(reasons, String()).Length > 0) OrElse noContinue Then
                    Dim pd As New ProblemDialog(CType(reasons, String()), noContinue)
                    Dim result As DialogResult

                    result = pd.ShowDialog()
                    If noContinue Then
                        decision = "cancel"
                    End If
                    If result = DialogResult.OK Then
                        decision = "accept"
                    ElseIf result = DialogResult.Cancel Then
                        decision = "cancel"
                    Else
                        decision = "cancel"
                        disconnect = True
                    End If
                End If

                _ContextManager.PublishChangesDecision(transaction, decision)
                If decision = "accept" Then
                End If

                If disconnect Then
                    Leave()
                End If
            Catch e As Exception
                Messager.ShowError(Nothing, e)
                Return False
            End Try
            Return True
        End Function

        Public Sub [Set](ByVal subject As Subject)
            Try
                Dim data As IContextData = Access(Of IContextData)()
                Dim noContinue As Boolean = True
                Dim reasons As Object
                Dim decision As String = "accept"
                Dim disconnect As Boolean = False
                Dim transaction As Integer

                transaction = _ContextManager.StartContextChanges(_ParticipantCoupon)
                data.SetItemValues(_ParticipantCoupon, subject.ToItemNameArray(), subject.ToItemValueArray(), transaction)
                reasons = _ContextManager.EndContextChanges(transaction, noContinue)

                '
                ' If any application responded that they cannot apply the change we need to display
                ' a dialog that displays the reasons for the problems.
                '
                If (reasons IsNot Nothing AndAlso CType(reasons, String()).Length > 0) OrElse noContinue Then
                    Dim pd As New ProblemDialog(CType(reasons, String()), noContinue)
                    Dim result As DialogResult

                    result = pd.ShowDialog()
                    If noContinue Then
                        decision = "cancel"
                    End If
                    If result = DialogResult.OK Then
                        decision = "accept"
                    ElseIf result = DialogResult.Cancel Then
                        decision = "cancel"
                    Else
                        decision = "cancel"
                        disconnect = True
                    End If
                End If

                _ContextManager.PublishChangesDecision(transaction, decision)
                If disconnect Then
                    Leave()
                End If
            Catch e As Exception
                Messager.ShowError(Nothing, e)
            End Try
        End Sub

        Public Function Access(Of T)() As T
            Return CType(_ContextManager, T)
        End Function

        Public Function IsContextSet(ByVal suffix As String) As Boolean
            If _ContextManager.MostRecentContextCoupon <> 0 Then
                Dim item As New ContextItem("User.id.logon." & suffix)
                Dim user As String = GetItemValue(item, False, _ContextManager.MostRecentContextCoupon)

                Return Not String.IsNullOrEmpty(user)
            End If
            Return False
        End Function

        Public Function IsUserLoggedIn() As Boolean
            Dim data As IContextData = Access(Of IContextData)()
            Dim currentUser As Boolean = False

            If data IsNot Nothing Then
                Dim contextData As Object = New String() {"User.Id.Logon"}

                contextData = data.GetItemValues(contextData, False, -100)
            End If
            Return currentUser
        End Function

        Public Function GetAuthenticationData(ByVal user As String) As String
            Dim repository As IAuthenticationRepository = Utils.COMCreateObject(Of IAuthenticationRepository)("CCOW.AuthenticationRepository")
            Dim data As String = String.Empty

            If repository IsNot Nothing Then
                Dim coupon As Integer = repository.Connect(_ApplicationName)

                If coupon <> 0 Then
                    Try
                        Dim sb As ISecureBinding = TryCast(repository, ISecureBinding)

                        If sb IsNot Nothing Then
                            Dim signature As String = String.Empty

                            SecureBind(coupon, sb)
                            signature = coupon.ToString() & user
                            signature = CreateSignature(signature)
                            repository.GetAuthenticationData(coupon, user, String.Empty, signature, data)
                        End If
                    Catch e As COMException
                        If e.ErrorCode <> CInt(HResult.LogonNotFound) Then
                            Throw e
                        End If
                    Finally
                        repository.Disconnect(coupon)
                    End Try
                End If
            End If
            Return data
        End Function

        Public Sub SetAuthenticationData(ByVal user As String, ByVal password As String)
            Dim repository As IAuthenticationRepository = Utils.COMCreateObject(Of IAuthenticationRepository)("CCOW.AuthenticationRepository")
            Dim data As String = String.Empty

            If repository IsNot Nothing Then
                Dim coupon As Integer = repository.Connect(_ApplicationName)

                If coupon <> 0 Then
                    Try
                        Dim sb As ISecureBinding = TryCast(repository, ISecureBinding)

                        If sb IsNot Nothing Then
                            Dim signature As String = String.Empty

                            SecureBind(coupon, sb)
                            signature = coupon.ToString() & user & password
                            signature = CreateSignature(signature)
                            repository.SetAuthenticationData(coupon, user, String.Empty, password, signature)
                        End If
                    Catch e As COMException
                        If e.ErrorCode <> CInt(HResult.LogonNotFound) Then
                            Throw e
                        End If
                    Finally
                        repository.Disconnect(coupon)
                    End Try
                End If
            End If
        End Sub

        Private Sub SecureBind(ByVal coupon As Integer, ByVal sb As ISecureBinding)
            Dim mac As String = String.Empty
            Dim contextPublicKey As String = String.Empty
            Dim hash As String = String.Empty

            mac = sb.InitializeBinding(coupon, Constants.PassCodeNames, Constants.PassCodeValues, contextPublicKey)
            hash = Utils.BinaryEncode(Utils.Hash(contextPublicKey & Passcode))
            If mac.ToLower() <> hash.ToLower() Then
                Return
            End If

            '
            ' Create participant hash and finalize binding
            '
            hash = Utils.BinaryEncode(Utils.Hash(PublicKey & Passcode))
            sb.FinalizeBinding(coupon, PublicKey, hash.ToLower())
        End Sub

        Public Sub SecureBind()
            Dim mac As String = String.Empty
            Dim contextPublicKey As String = String.Empty
            Dim hash As String = String.Empty
            Dim sb As ISecureBinding = Access(Of ISecureBinding)()
            Dim access__1 As Object = Nothing

            mac = sb.InitializeBinding(_ParticipantCoupon, Constants.PassCodeNames, Constants.PassCodeValues, contextPublicKey)
            hash = Utils.BinaryEncode(Utils.Hash(contextPublicKey & Passcode))
            If mac.ToLower() <> hash.ToLower() Then
                Return
            End If

            '
            ' Create participant hash and finalize binding
            '
            hash = Utils.BinaryEncode(Utils.Hash(PublicKey & Passcode))
            access__1 = sb.FinalizeBinding(_ParticipantCoupon, PublicKey, hash.ToLower())
            _Access.AddRange(CType(access__1, String()))
        End Sub

        Public Function Login(ByVal suffix As String, ByRef user As String, ByRef name As String) As Boolean
            Dim loggedIn As Boolean = False
            Dim action As IContextAction = Access(Of IContextAction)()
            Dim itemNames As Object = New String() {"AuthenticateUser.In.ExpectedUserLogOn"}
            Dim itemValues As Object = New String(0) {}
            Dim actionCoupon As Integer = Constants.AuthenticateUserActionAgent
            Dim appSignature As String = _ParticipantCoupon.ToString() & CType(itemNames, String())(0).ToString()

            action.Perform(_ParticipantCoupon, itemNames, itemValues, CreateSignature(appSignature), actionCoupon, itemNames, _
             itemValues)

            If itemNames IsNot Nothing Then
                Dim names As String() = CType(itemNames, String())
                Dim values As Object() = CType(itemValues, Object())

                For i As Integer = 0 To names.Length - 1
                    Dim item As New ContextItem(names(i), values(i))

                    If item.Subject.ToLower() = "authenticateuser" AndAlso item.Role.ToLower() = "ou" AndAlso item.Name.ToLower() = "status" Then
                        loggedIn = item.Value.ToString() = "Pass"
                        If Not loggedIn Then
                            Exit For
                        End If
                    End If

                    If item.Subject.ToLower() = "authenticateuser" AndAlso item.Role.ToLower() = "ou" AndAlso item.Name.ToLower() = "logon" Then
                        user = item.Value.ToString()
                    End If

                    If item.Subject.ToLower() = "authenticateuser" AndAlso item.Role.ToLower() = "ou" AndAlso item.Name.ToLower() = "name" Then
                        name = item.Value.ToString()
                    End If
                Next
            End If

            Return loggedIn
        End Function

        Public Function IsSetting(ByVal subject As String, ByVal name As String, ByVal coupon As Integer) As Boolean
            Dim context As IContextData = Access(Of IContextData)()
            Dim user As String = String.Empty

            If context IsNot Nothing Then
                Dim data As Object = context.GetItemNames(coupon)

                If data IsNot Nothing AndAlso data.[GetType]() Is GetType(String()) AndAlso CType(data, String()).Length > 0 Then
                    Dim names As String() = CType(data, String())

                    data = Nothing
                    For Each n As String In names
                        Dim item As New ContextItem(n)

                        If item.Subject.ToLower() = subject.ToLower() AndAlso item.Name.ToLower() = name.ToLower() Then
                            Return True
                        End If
                    Next
                End If
            End If
            Return False
        End Function

        Public Function GetCurrentUser(ByVal suffix As String) As String
            Dim context As IContextData = Access(Of IContextData)()
            Dim user As String = String.Empty

            If context IsNot Nothing Then
                Dim data As Object = context.GetItemNames(_ContextManager.MostRecentContextCoupon)

                If data IsNot Nothing AndAlso data.[GetType]() Is GetType(String()) AndAlso CType(data, String()).Length > 0 Then
                    Dim names As String() = CType(data, String())

                    data = Nothing
                    For Each name As String In names
                        Dim item As New ContextItem(name)

                        If item.Suffix.ToLower() = suffix AndAlso item.Subject.ToLower() = "user" AndAlso item.Name.ToLower() = "logon" AndAlso item.Role.ToLower() = "id" Then
                            data = New String() {item.ToString()}
                            Exit For
                        End If
                    Next

                    If data IsNot Nothing Then
                        data = context.GetItemValues(data, False, _ContextManager.MostRecentContextCoupon)
                        If data IsNot Nothing AndAlso data.[GetType]() Is GetType(Object()) Then
                            Dim values As Object() = CType(data, Object())

                            If values.Length = 2 Then
                                user = values(1).ToString()
                            End If
                        End If
                    End If
                End If
            End If
            Return user
        End Function

        Public Function GetItemValue(ByVal item As ContextItem, ByVal onlyChanges As Boolean, ByVal coupon As Integer) As String
            Dim context As IContextData = Access(Of IContextData)()

            If coupon = -1 Then
                coupon = _ContextManager.MostRecentContextCoupon
            End If

            If context IsNot Nothing Then
                Dim s As New Subject(item.Subject)
                Dim data As Object = Nothing

                s.Items.Add(item)
                data = context.GetItemValues(s.ToItemNameArray(), onlyChanges, coupon)
                If data IsNot Nothing AndAlso data.[GetType]() Is GetType(Object()) Then
                    Dim info As Object() = CType(data, Object())

                    If info.Length = 2 Then
                        Return info(1).ToString()
                    End If
                End If
            End If

            Return String.Empty
        End Function

        Public Sub SetFilter(ByVal ParamArray filters As String())
            Dim filter As IContextFilter = Access(Of IContextFilter)()

            If filter IsNot Nothing Then
                filter.SetSubjectsOfInterest(_ParticipantCoupon, filters)
            End If
        End Sub

        Private Function CreateSignature(ByVal messageDigest As String) As String
            Dim signature As Byte() = _KeyContainer.Sign(messageDigest)

            Return Utils.BinaryEncode(signature)
        End Function

#Region "IContextParticipant Members"

        Public Sub CommonContextTerminated() Implements IContextParticipant.CommonContextTerminated
            OnTerminated()
        End Sub

        Public Sub ContextChangesAccepted(ByVal contextCoupon As Integer) Implements IContextParticipant.ContextChangesAccepted
            OnChangesAccepted(contextCoupon)
        End Sub

        Public Sub ContextChangesCanceled(ByVal contextCoupon As Integer) Implements IContextParticipant.ContextChangesCanceled
            OnChangesCanceled(contextCoupon)
        End Sub

        Public Function ContextChangesPending(ByVal contextCoupon As Integer, ByRef reason As String) As String Implements IContextParticipant.ContextChangesPending
            Return OnChangesPending(contextCoupon, reason)
        End Function

        Public Sub Ping() Implements IContextParticipant.Ping
        End Sub

#End Region
    End Class
End Namespace
