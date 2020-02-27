' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Configuration
Imports System.Configuration
Imports System.Threading
Imports System.ServiceModel.Description
Imports System.Security.Cryptography.X509Certificates
Imports System.Reflection
Imports System.Globalization
Imports System.ServiceModel.Channels

Namespace Leadtools.Demos
   Public Class CustomChannelFactory(Of T)
	   Inherits ChannelFactory(Of T)
	  Private _ConfigurationFileName As String
	  Private Shared _ReaderWriterLock As New ReaderWriterLock()
	  Private Shared _Groups As New Dictionary(Of String, ServiceModelSectionGroup)()

	  Public Sub New(ByVal endpointConfigurationName As String, ByVal configurationFileName As String)
		  MyBase.New(GetType(T))
		 _ConfigurationFileName = configurationFileName
		 InitializeEndpoint(endpointConfigurationName, Nothing)
	  End Sub

	  Protected Overrides Overloads Sub ApplyConfiguration(ByVal endpointConfigurationName As String)
		 If String.IsNullOrEmpty(_ConfigurationFileName) Then
			Return
		 End If

		 Dim serviceModeGroup As ServiceModelSectionGroup = GetGroup(_ConfigurationFileName)

		 LoadChannelBehaviors(Endpoint, endpointConfigurationName, serviceModeGroup)
	  End Sub

	  Private Shared Function GetGroup(ByVal configurationFileName As String) As ServiceModelSectionGroup
		 Dim group As ServiceModelSectionGroup = New ServiceModelSectionGroup()

		 ' Get a read lock while we access the cache collection
		 _ReaderWriterLock.AcquireReaderLock(-1)
		 Try
			' Check to see if we already have a group for the given configuration
			If _Groups.TryGetValue(configurationFileName, group) Then
			   ' We found group so return it and we are done
			   Return group
			End If
		 Finally
			' always release the lock safely
			_ReaderWriterLock.ReleaseReaderLock()
		 End Try

		 ' if we get here, we couldn't get a group so we need to create one
		 ' this will involve modifying the collection so we need a write lock
		 _ReaderWriterLock.AcquireWriterLock(-1)
		 Try
			' check an open group wasn't created on another thread while we were
			' acquiring the writer lock
			If _Groups.TryGetValue(configurationFileName, group) Then
			   ' we found a group so return it and we are done
			   Return group
			End If

			Dim executionFileMap As ExeConfigurationFileMap = New ExeConfigurationFileMap With {.ExeConfigFilename = configurationFileName}

			Dim config As Configuration = ConfigurationManager.OpenMappedExeConfiguration(executionFileMap, ConfigurationUserLevel.None)
			group = ServiceModelSectionGroup.GetSectionGroup(config)

			' store it in the cache
			_Groups.Add(configurationFileName, group)

			Return group
		 Finally
			' always release the writer lock!
			_ReaderWriterLock.ReleaseWriterLock()
		 End Try
	  End Function

	  Public Function LoadChannelBehaviors(ByVal serviceEndpoint As ServiceEndpoint, ByVal configurationName As String, ByVal serviceModeGroup As ServiceModelSectionGroup) As ServiceEndpoint
		 Dim isWildcard As Boolean = String.Equals(configurationName, "*", StringComparison.Ordinal)
		 Dim provider As ChannelEndpointElement = LookupChannel(serviceModeGroup, configurationName, serviceEndpoint.Contract.ConfigurationName, isWildcard)

		 If provider Is Nothing Then
			Return Nothing
		 End If

		 If serviceEndpoint.Binding Is Nothing Then
			serviceEndpoint.Binding = LookupBinding(serviceModeGroup, provider.Binding, provider.BindingConfiguration)
		 End If

		 If serviceEndpoint.Address Is Nothing Then
			serviceEndpoint.Address = New EndpointAddress(provider.Address, LookupIdentity(provider.Identity), provider.Headers.Headers)
		 End If

		 If serviceEndpoint.Behaviors.Count = 0 AndAlso (Not String.IsNullOrEmpty(provider.BehaviorConfiguration)) Then
			LoadBehaviors(serviceModeGroup, provider.BehaviorConfiguration, serviceEndpoint)
		 End If

		 serviceEndpoint.Name = provider.Contract

		 Return serviceEndpoint
	  End Function

	  Private Function LookupChannel(ByVal serviceModeGroup As ServiceModelSectionGroup, ByVal configurationName As String, ByVal contractName As String, ByVal wildcard As Boolean) As ChannelEndpointElement
		 For Each endpoint As ChannelEndpointElement In serviceModeGroup.Client.Endpoints
			If endpoint.Contract = contractName AndAlso (endpoint.Name = configurationName OrElse wildcard) Then
			   Return endpoint
			End If
		 Next endpoint

		 Return Nothing
	  End Function

	  Private Function LookupBinding(ByVal group As ServiceModelSectionGroup, ByVal bindingName As String, ByVal configurationName As String) As Binding
		 Dim bindingElementCollection As BindingCollectionElement = group.Bindings(bindingName)
		 If bindingElementCollection.ConfiguredBindings.Count = 0 Then
			Return Nothing
		 End If

		 Dim bindingConfigurationElement As IBindingConfigurationElement = bindingElementCollection.ConfiguredBindings.First(Function(item) item.Name = configurationName)

		 Dim binding As Binding = GetBinding(bindingConfigurationElement)
		 If bindingConfigurationElement IsNot Nothing Then
			bindingConfigurationElement.ApplyConfiguration(binding)
		 End If

		 Return binding
	  End Function

	  Private Function LookupIdentity(ByVal element As IdentityElement) As EndpointIdentity
		 Dim identity As EndpointIdentity = Nothing
		 Dim properties As PropertyInformationCollection = element.ElementInformation.Properties

		 If properties("userPrincipalName").ValueOrigin <> PropertyValueOrigin.Default Then
			Return EndpointIdentity.CreateUpnIdentity(element.UserPrincipalName.Value)
		 End If

		 If properties("servicePrincipalName").ValueOrigin <> PropertyValueOrigin.Default Then
			Return EndpointIdentity.CreateSpnIdentity(element.ServicePrincipalName.Value)
		 End If

		 If properties("dns").ValueOrigin <> PropertyValueOrigin.Default Then
			Return EndpointIdentity.CreateDnsIdentity(element.Dns.Value)
		 End If

		 If properties("rsa").ValueOrigin <> PropertyValueOrigin.Default Then
			Return EndpointIdentity.CreateRsaIdentity(element.Rsa.Value)
		 End If

		 If properties("certificate").ValueOrigin <> PropertyValueOrigin.Default Then
			Dim supportingCertificates As New X509Certificate2Collection()
			supportingCertificates.Import(Convert.FromBase64String(element.Certificate.EncodedValue))
			If supportingCertificates.Count = 0 Then
			   Throw New InvalidOperationException("UnableToLoadCertificateIdentity")
			End If

			Dim primaryCertificate As X509Certificate2 = supportingCertificates(0)
			supportingCertificates.RemoveAt(0)
			Return EndpointIdentity.CreateX509CertificateIdentity(primaryCertificate, supportingCertificates)
		 End If

		 Return identity
	  End Function

	  Private Shared Sub LoadBehaviors(ByVal group As ServiceModelSectionGroup, ByVal behaviorConfiguration As String, ByVal serviceEndpoint As ServiceEndpoint)
		 Dim behaviorElement As EndpointBehaviorElement = group.Behaviors.EndpointBehaviors(behaviorConfiguration)

		 For i As Integer = 0 To behaviorElement.Count - 1
			Dim behaviorExtension As BehaviorExtensionElement = behaviorElement(i)
			Dim extension As Object = behaviorExtension.GetType().InvokeMember("CreateBehavior", BindingFlags.InvokeMethod Or BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, behaviorExtension, Nothing, CultureInfo.InvariantCulture)
			If extension IsNot Nothing Then
			   serviceEndpoint.Behaviors.Add(CType(extension, IEndpointBehavior))
			End If
		 Next i
	  End Sub

	  Private Function GetBinding(ByVal configurationElement As IBindingConfigurationElement) As Binding
		 If TypeOf configurationElement Is NetTcpBindingElement Then
			Return New NetTcpBinding()
		 End If

		 If TypeOf configurationElement Is NetMsmqBindingElement Then
			Return New NetMsmqBinding()
		 End If

		 If TypeOf configurationElement Is BasicHttpBindingElement Then
			Return New BasicHttpBinding()
		 End If

		 If TypeOf configurationElement Is NetNamedPipeBindingElement Then
			Return New NetNamedPipeBinding()
		 End If

		 If TypeOf configurationElement Is NetPeerTcpBindingElement Then
			Return New NetPeerTcpBinding()
		 End If

		 If TypeOf configurationElement Is WSDualHttpBindingElement Then
			Return New WSDualHttpBinding()
		 End If

		 If TypeOf configurationElement Is WSHttpBindingElement Then
			Return New WSHttpBinding()
		 End If

		 If TypeOf configurationElement Is WSFederationHttpBindingElement Then
			Return New WSFederationHttpBinding()
		 End If

		 If TypeOf configurationElement Is CustomBindingElement Then
			Return New CustomBinding()
		 End If

		 Return Nothing
	  End Function
   End Class
End Namespace
