' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class GeneralSettingsPresenter
      Private Function GetAddIns() As String()

#If LEADTOOLS_V19_OR_LATER Then
         Dim addIns() As String = _
            { _
               "Leadtools.Medical.AutoCopy.AddIn.dll", _
               "Leadtools.Medical.PatientUpdater.AddIn.dll", _
               "Leadtools.Medical.Storage.Addins.dll", _
               "Leadtools.Medical.Forwarder.AddIn.dll", _
               "Leadtools.Medical.Rules.AddIn.dll", _
               "Leadtools.Medical.ExternalStore.Addin.dll", _
               "EsuApiLib.dll", _
               "Leadtools.Medical.ExternalStore.Atmos.Addin.dll", _
               "Leadtools.Medical.ExternalStore.Azure.Addin.dll", _
               "Leadtools.Medical.ExternalStore.Sample.Addin.dll", _
               "Leadtools.Medical.HL7PatientUpdate.AddIn.dll" _
            }
#Else
          Dim addIns() As String = _
               { _
                  "Leadtools.Medical.AutoCopy.AddIn.dll", _
                  "Leadtools.Medical.PatientUpdater.AddIn.dll", _
                  "Leadtools.Medical.Storage.Addins.dll", _
                  "Leadtools.Medical.Forwarder.AddIn.dll", _
                  "Leadtools.Medical.Rules.AddIn.dll" _
               }
#End If

         Return addIns
      End Function

      Private Function GetConfigurationAddIns() As String()
         Return New String() {"Leadtools.Medical.Ae.Configuration.dll", "Leadtools.Medical.Logging.Addin.dll", "Leadtools.Medical.License.Configuration.dll"}
      End Function
   End Class
End Namespace
