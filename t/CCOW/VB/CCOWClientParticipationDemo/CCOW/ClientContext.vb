' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Ccow
Imports Leadtools.Demos
Imports Leadtools.Ccow.UI
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Collections.Specialized

Namespace CCOWClientParticipationDemo.CCOW
    Public Class ClientContext : Implements IContextParticipant
        Private _ContextManager As IContextManager = Nothing
        Private _ParticipantCoupon As Integer = -1000
        Private _Access As List(Of String) = New List(Of String)()
        Private _MainForm As MainForm = Nothing

        Private _Passcode As String = "E9CA399D-F0EF-4DAE-BEB3-8037862513CE"

        Public Event JoinedContext As EventHandler
        Public Event LeftContext As EventHandler
        Public Event Pinged As EventHandler

        Public ReadOnly Property ParticipantCoupon() As Integer
            Get
                Return _ParticipantCoupon
            End Get
        End Property

        Public ReadOnly Property Passcode() As String
            Get
                Return _Passcode
            End Get
        End Property

        Public ReadOnly Property PublicKey() As String
            Get
                If Not _KeyContainer Is Nothing Then
                    Return Utils.BinaryEncode(_KeyContainer.GetPublicKey())
                End If
                Return String.Empty
            End Get
        End Property

        Public ReadOnly Property Joined() As Boolean
            Get
                Return _ParticipantCoupon <> -1000
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

        Public ReadOnly Property LastCoupon() As Integer
            Get
                If _ContextManager Is Nothing Then
                    Return 0
                End If

                Return _ContextManager.MostRecentContextCoupon
            End Get
        End Property

        Public Event Terminated As EventHandler

        Private Sub OnTerminated()
            If Not TerminatedEvent Is Nothing Then
                RaiseEvent Terminated(Me, EventArgs.Empty)
            End If
        End Sub

        Public Event ChangesAccepted As EventHandler(Of ContextEventArgs)

        Private Sub OnChangesAccepted(ByVal coupon As Integer)
            If Not ChangesAcceptedEvent Is Nothing Then
                RaiseEvent ChangesAccepted(Me, New ContextEventArgs(coupon))
            End If
        End Sub

        Public Event ChangesCanceled As EventHandler(Of ContextEventArgs)

        Private Sub OnChangesCanceled(ByVal coupon As Integer)
            If Not ChangesCanceledEvent Is Nothing Then
                RaiseEvent ChangesCanceled(Me, New ContextEventArgs(coupon))
            End If
        End Sub

        Public Event ChangesPending As EventHandler(Of ContextEventArgs)

        Private Function OnChangesPending(ByVal coupon As Integer, ByRef reason As String) As String
            Dim decision As String = "accept"

            If Not ChangesPendingEvent Is Nothing Then
                Dim e As ContextEventArgs = New ContextEventArgs(coupon)

                RaiseEvent ChangesPending(Me, e)
                reason = e.Reason
                decision = e.Decision
            End If
            Return decision
        End Function

        Public Sub New(ByVal ApplicationName As String, ByVal mainform As MainForm)
            _ContextManager = Utils.COMCreateObject(Of IContextManager)("CCOW.ContextManager")
            _KeyContainer = New KeyContainer(ApplicationName)
            _MainForm = mainform
        End Sub

        Public Sub Join(ByVal ApplicationName As String, ByVal survey As Boolean)
            _ParticipantCoupon = _ContextManager.JoinCommonContext(Me, ApplicationName, survey, True)
            RaiseEvent JoinedContext(Me, EventArgs.Empty)
        End Sub

        Public Sub Leave()
            If _ParticipantCoupon <> -1000 Then
                _ContextManager.LeaveCommonContext(_ParticipantCoupon)
                _ParticipantCoupon = -1000
                RaiseEvent LeftContext(Me, EventArgs.Empty)
            End If
        End Sub

        Public Sub Suspend()
            Try
                _MainForm.Log("=> SuspendParticipation({0})", _ParticipantCoupon)
                _ContextManager.SuspendParticipation(_ParticipantCoupon)
                _Suspended = True

            Catch e As Exception
                Throw e
            End Try
        End Sub

        Public Sub [Resume](ByVal wait As Boolean)
            Try
                _MainForm.Log("=> ResumeParticipation({0},{1})", _ParticipantCoupon, wait)
                _ContextManager.ResumeParticipation(_ParticipantCoupon, wait)
                _Suspended = False
            Catch e As Exception
                Throw e
            End Try
        End Sub

        Private Function IsSecurityAny(ByVal s As Subject) As Boolean
            If _Access.Count = 0 Then
                Return False
            End If

            Dim index As Integer = _Access.IndexOf(s.Name)

            If index <> -1 Then
                Return _Access(index + 1).ToLower() = "any"
            End If

            Return False
        End Function

        Public Sub SetSecure(ByVal s As Subject)
            Try
                Dim secure As ISecureContextData = Access(Of ISecureContextData)()
                Dim v As List(Of String) = New List(Of String)()
                Dim names As String() = s.ToItemNameArray()
                Dim values As Object() = s.ToItemValueArray()
                Dim reasons As Object
                Dim decision As String = "accept", appSignature As String = String.Empty
                Dim transaction As Integer
                Dim noContinue As Boolean = True, disconnect As Boolean = False

                _MainForm.Log("=> StartContextChanges({0}) (Secure)", _ParticipantCoupon)
                transaction = _ContextManager.StartContextChanges(_ParticipantCoupon)
                _MainForm.Log("     Received transaction coupon: {0}", transaction)
                Dim i As Integer = 0
                Do While i < names.Length
                    v.Add(values(i).ToString())
                    i += 1
                Loop

                appSignature = _ParticipantCoupon.ToString() & String.Join("", names) + String.Join("", v.ToArray()) + transaction.ToString()
                appSignature = CreateSignature(appSignature)
                _MainForm.Log("=> SetItemValues([{0}],[{1}],{2},{3},{4})", _ParticipantCoupon, String.Join(",", names), String.Join(",", Array.ConvertAll(Of Object, String)(values, New Converter(Of Object, String)(AddressOf Convert))), transaction, appSignature)
                secure.SetItemValues(_ParticipantCoupon, names, values, transaction, appSignature)
                _MainForm.Log("=> EndContextChanges({0},ref noContinue) (Secure)", transaction)
                reasons = _ContextManager.EndContextChanges(transaction, noContinue)

                '
                ' If any application responded that they cannot apply the change we need to display
                ' a dialog that displays the reasons for the problems.
                '
                If (Not reasons Is Nothing AndAlso (CType(reasons, String())).Length > 0) OrElse noContinue Then
                    Dim pd As ProblemDialog = New ProblemDialog(CType(reasons, String()), noContinue)
                    Dim result As DialogResult

                    result = pd.ShowDialog()
                    If noContinue Then
                        decision = "cancel"
                    End If
                    If result = System.Windows.Forms.DialogResult.OK Then
                        decision = "accept"
                    ElseIf result = DialogResult.Cancel Then
                        decision = "cancel"
                    Else
                        decision = "cancel"
                        disconnect = True
                    End If
                End If

                _MainForm.Log("=> PublishChangesDecision({0},{1})", transaction, decision)
                _ContextManager.PublishChangesDecision(transaction, decision)
                If disconnect Then
                    Leave()
                End If
            Catch e As Exception
                Messager.ShowError(Nothing, e)
            End Try
        End Sub

        Public Function Convert(ByVal o As Object) As String
            If Not o Is Nothing Then
                Return o.ToString()
            Else
                Return String.Empty
            End If
        End Function

        Public Sub [Set](ByVal subject As Subject)
            If (Not IsSecurityAny(subject)) Then
                SetSecure(subject)
                Return
            End If

            Try
                Dim data As IContextData = Access(Of IContextData)()
                Dim noContinue As Boolean = True
                Dim reasons As Object
                Dim decision As String = "accept"
                Dim disconnect As Boolean = False
                Dim transaction As Integer

                _MainForm.Log("=> StartContextChanges({0})", _ParticipantCoupon)
                transaction = _ContextManager.StartContextChanges(_ParticipantCoupon)
                _MainForm.Log("     Received transaction coupon: {0}", transaction)
                _MainForm.Log("=> SetItemValues([{0}],[{1}],{2},{3})", _ParticipantCoupon, String.Join(",", subject.ToItemNameArray()), String.Join(",", Array.ConvertAll(Of Object, String)(subject.ToItemValueArray(), New Converter(Of Object, String)(AddressOf Convert))), transaction)
                data.SetItemValues(_ParticipantCoupon, subject.ToItemNameArray(), subject.ToItemValueArray(), transaction)
                _MainForm.Log("=> EndContextChanges({0},ref noContinue)", transaction)
                reasons = _ContextManager.EndContextChanges(transaction, noContinue)

                '
                ' If any application responded that they cannot apply the change we need to display
                ' a dialog that displays the reasons for the problems.
                '
                If (Not reasons Is Nothing AndAlso (CType(reasons, String())).Length > 0) OrElse noContinue Then
                    Dim pd As ProblemDialog = New ProblemDialog(CType(reasons, String()), noContinue)
                    Dim result As DialogResult

                    result = pd.ShowDialog()
                    If noContinue Then
                        decision = "cancel"
                    End If
                    If result = System.Windows.Forms.DialogResult.OK Then
                        decision = "accept"
                    ElseIf result = DialogResult.Cancel Then
                        decision = "cancel"
                    Else
                        decision = "cancel"
                        disconnect = True
                    End If
                End If

                _MainForm.Log("=> PublishChangesDecision({0},{1})", transaction, decision)
                _ContextManager.PublishChangesDecision(transaction, decision)
                If disconnect Then
                    Leave()
                End If
            Catch e As Exception
                Throw e
            End Try
        End Sub

        Public Function Access(Of T)() As T
            Return CType(_ContextManager, T)
        End Function

        Public Function IsUserContextSet() As Boolean
            If _ContextManager.MostRecentContextCoupon <> 0 Then
                Dim item As ContextItem = New ContextItem("User.id.logon." & MainForm.Suffix)
                Dim user As String = GetItemValue(item, False, _ContextManager.MostRecentContextCoupon)

                Return Not String.IsNullOrEmpty(user)
            End If
            Return False
        End Function

        Public Function IsUserLoggedIn() As Boolean
            Dim data As IContextData = Access(Of IContextData)()
            Dim currentUser As Boolean = False

            If Not data Is Nothing Then
                Dim contextData As Object = New String() {"User.Id.Logon"}

                contextData = data.GetItemValues(contextData, False, -100)
            End If
            Return currentUser
        End Function

        Public Function GetAuthenticationData(ByVal user As String) As String
            Dim repository As IAuthenticationRepository = Utils.COMCreateObject(Of IAuthenticationRepository)("CCOW.AuthenticationRepository")
            Dim data As String = String.Empty

            If Not repository Is Nothing Then
                Dim coupon As Integer = repository.Connect(MainForm.ApplicationName)

                If coupon <> 0 Then
                    Try
                        Dim sb As ISecureBinding = TryCast(repository, ISecureBinding)

                        If Not sb Is Nothing Then
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

            If Not repository Is Nothing Then
                Dim coupon As Integer = repository.Connect(MainForm.ApplicationName)

                If coupon <> 0 Then
                    Try
                        Dim sb As ISecureBinding = TryCast(repository, ISecureBinding)

                        If Not sb Is Nothing Then
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

            _MainForm.Log("=> InitializeBinding({0},{1},{2}) (Authentication Repository)", coupon, Leadtools.Ccow.Constants.PassCodeNames, Leadtools.Ccow.Constants.PassCodeValues)
            mac = sb.InitializeBinding(coupon, Leadtools.Ccow.Constants.PassCodeNames, Leadtools.Ccow.Constants.PassCodeValues, contextPublicKey)
            _MainForm.Log("=> Verify mac. Returned Public Key: {0}", contextPublicKey)
            hash = Utils.BinaryEncode(Utils.Hash(contextPublicKey & Passcode))
            If mac.ToLower() <> hash.ToLower() Then
                _MainForm.Log("     Failed to verify authentication repository.")
                Return
            End If

            '
            ' Create participant hash and finalize binding
            '
            hash = Utils.BinaryEncode(Utils.Hash(PublicKey + Passcode))
            _MainForm.Log("=> FinalizeBinding({0},{1},{2}) (Authentication Repository)", coupon, PublicKey, hash.ToLower())
            sb.FinalizeBinding(coupon, PublicKey, hash.ToLower())
        End Sub

      Public Sub SecureBind(ByRef failedToVerify As Boolean)
         Dim mac As String = String.Empty
         Dim contextPublicKey As String = String.Empty
         Dim hash As String = String.Empty
         Dim sb As ISecureBinding = Access(Of ISecureBinding)()         
         Dim access_Renamed As Object = Nothing

         failedToVerify = False
         _MainForm.Log("=> InitializeBinding({0},{1},{2}) (Context Manager)", _ParticipantCoupon, Leadtools.Ccow.Constants.PassCodeNames, Leadtools.Ccow.Constants.PassCodeValues)
         mac = sb.InitializeBinding(_ParticipantCoupon, Leadtools.Ccow.Constants.PassCodeNames, Leadtools.Ccow.Constants.PassCodeValues, contextPublicKey)
         _MainForm.Log("=> Verify mac. Returned Public Key: {0}", contextPublicKey)
         hash = Utils.BinaryEncode(Utils.Hash(contextPublicKey & Passcode))
         If mac.ToLower() <> hash.ToLower() Then
            _MainForm.Log("     Failed to verify context manager")
            MainForm.UserLink = False
            failedToVerify = True
            Return
         End If

         '
         ' Create participant hash and finalize binding
         '
         hash = Utils.BinaryEncode(Utils.Hash(PublicKey + Passcode))
         _MainForm.Log("=> FinalizeBinding({0},{1},{2}) (Authentication Repository)", _ParticipantCoupon, PublicKey, hash.ToLower())
         access_Renamed = sb.FinalizeBinding(_ParticipantCoupon, PublicKey, hash.ToLower())
         If Not access_Renamed Is Nothing Then
            Dim a As String() = CType(access_Renamed, String())

            Dim i As Integer = 0
            Do While i < a.Length
               _MainForm.Log("     {0}" & vbTab & "{1}", a(i), a(i + 1))
               i += 2
            Loop
         End If
         _Access.AddRange(CType(access_Renamed, String()))
      End Sub

        Public Function Login(<System.Runtime.InteropServices.Out()> ByRef user As String) As Boolean
            Dim loggedIn As Boolean = False
            Dim action As IContextAction = Access(Of IContextAction)()
            Dim itemNames As Object = New String() {"AuthenticateUser.In.ExpectedUserLogOn"}
            Dim itemValues As Object = New String(0) {}
            Dim actionCoupon As Integer = Leadtools.Ccow.Constants.AuthenticateUserActionAgent
            Dim appSignature As String = _ParticipantCoupon.ToString() & (CType(itemNames, String()))(0).ToString()

            action.Perform(_ParticipantCoupon, itemNames, itemValues, CreateSignature(appSignature), actionCoupon, itemNames, itemValues)

            user = String.Empty
            If Not itemNames Is Nothing Then
                Dim names As String() = CType(itemNames, String())
                Dim values As Object() = CType(itemValues, Object())

                Dim i As Integer = 0
                Do While i < names.Length
                    Dim item As ContextItem = New ContextItem(names(i), values(i))

                    If item.Subject.ToLower() = "authenticateuser" AndAlso item.Role.ToLower() = "ou" AndAlso item.Name.ToLower() = "status" Then
                        loggedIn = item.Value.ToString() = "Pass"
                        If (Not loggedIn) Then
                            Exit Do
                        End If
                    End If

                    If item.Subject.ToLower() = "user" AndAlso item.Role.ToLower() = "id" AndAlso item.Name.ToLower() = "logon" AndAlso item.Suffix.ToLower() = MainForm.Suffix.ToLower() Then
                        user = item.Value.ToString()
                    End If
                    i += 1
                Loop
            End If

            Return loggedIn
        End Function

        Public Function IsSetting(ByVal subject As String, ByVal name As String, ByVal coupon As Integer) As Boolean
            Dim context As IContextData = Access(Of IContextData)()
            Dim user As String = String.Empty

            If Not context Is Nothing Then
                Dim data As Object = context.GetItemNames(coupon)

                If Not data Is Nothing AndAlso data.GetType() Is GetType(String()) AndAlso (CType(data, String())).Length > 0 Then
                    Dim names As String() = CType(data, String())

                    data = Nothing
                    For Each n As String In names
                        Dim item As ContextItem = New ContextItem(n)

                        If item.Subject.ToLower() = subject.ToLower() AndAlso item.Name.ToLower() = name.ToLower() Then
                            Return True
                        End If
                    Next n
                End If
            End If
            Return False
        End Function

        Public Function GetCurrentUser() As String
            Dim context As IContextData = Access(Of IContextData)()
            Dim user As String = String.Empty

            If Not context Is Nothing Then
                Dim data As Object = context.GetItemNames(_ContextManager.MostRecentContextCoupon)

                If Not data Is Nothing AndAlso data.GetType() Is GetType(String()) AndAlso (CType(data, String())).Length > 0 Then
                    Dim names As String() = CType(data, String())

                    data = Nothing
                    For Each name As String In names
                        Dim item As ContextItem = New ContextItem(name)

                        If item.Suffix.ToLower() = MainForm.Suffix.ToLower() AndAlso item.Subject.ToLower() = "user" AndAlso item.Name.ToLower() = "logon" AndAlso item.Role.ToLower() = "id" Then
                            data = New String() {item.ToString()}
                            Exit For
                        End If
                    Next name

                    If Not data Is Nothing Then
                        data = context.GetItemValues(data, False, _ContextManager.MostRecentContextCoupon)
                        If Not data Is Nothing AndAlso data.GetType() Is GetType(Object()) Then
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

            If Not context Is Nothing Then
                Dim s As Subject = New Subject(item.Subject)
                Dim data As Object = Nothing

                s.Items.Add(item)
                data = context.GetItemValues(s.ToItemNameArray(), onlyChanges, coupon)
                If Not data Is Nothing AndAlso data.GetType() Is GetType(Object()) Then
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

            If Not filter Is Nothing Then
                filter.SetSubjectsOfInterest(_ParticipantCoupon, filters)
            End If
        End Sub

        Public Function GetCurrentContext() As NameValueCollection
            Dim context As NameValueCollection = New NameValueCollection()
            Dim data As IContextData = Access(Of IContextData)()

            If Not data Is Nothing AndAlso _ContextManager.MostRecentContextCoupon <> 0 Then
                Dim contextData As Object = Nothing

                _MainForm.Log("=> GetItemNames({0})", _ContextManager.MostRecentContextCoupon)
                contextData = data.GetItemNames(_ContextManager.MostRecentContextCoupon)
                If contextData.GetType() Is GetType(String()) AndAlso (CType(contextData, String())).Length > 0 Then
                    Dim names As String() = CType(contextData, String())

                    _MainForm.Log("     Available Item Names")
                    For Each name As String In names
                        _MainForm.Log("          " & name)
                    Next name

                    _MainForm.Log("=> GetItemValues([{0}],false,{1})", String.Join(",", names), _ContextManager.MostRecentContextCoupon)
                    contextData = data.GetItemValues(contextData, False, _ContextManager.MostRecentContextCoupon)
                    If contextData.GetType() Is GetType(Object()) Then
                        Dim values As Object() = CType(contextData, Object())

                        Dim i As Integer = 0
                        Do While i < values.Length
                            context.Add(values(i).ToString(), values(i + 1).ToString())
                            _MainForm.Log("          {0} ({1})", values(i), values(i + 1).ToString())
                            i += 2
                        Loop
                    End If
                End If
            End If

            Return context
        End Function

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
            RaiseEvent Pinged(Me, EventArgs.Empty)
        End Sub

#End Region
    End Class
End Namespace
