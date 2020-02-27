' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class GatewaySettingsPresenter
        Protected Function GetAddIns() As String()
            Dim addIns() As String = {"Leadtools.Medical.AutoCopy.AddIn.dll", "Leadtools.Medical.PatientUpdater.AddIn.dll", "Leadtools.Medical.Storage.Addins.dll", "Leadtools.Medical.Forwarder.AddIn.dll", "Leadtools.Medical.Rules.AddIn.dll", "Leadtools.Medical.ExternalStore.Addin.dll", "EsuApiLib.dll", "Leadtools.Medical.ExternalStore.Atmos.Addin.dll", "Leadtools.Medical.ExternalStore.Azure.Addin.dll", "Leadtools.Medical.ExternalStore.Sample.Addin.dll", "Leadtools.Medical.HL7PatientUpdate.AddIn.dll", "Leadtools.Medical.Security.Addin.dll"}

            Return addIns
        End Function

        Protected Function GetConfigurationAddIns() As String()
         Return New String() {"Leadtools.Medical.Ae.Configuration.dll", "Leadtools.Medical.Logging.AddIn.dll", "Leadtools.Medical.License.Configuration.dll"}
      End Function
   End Class
End Namespace
