' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Workstation.Commands
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Workstation.Loader

Namespace Leadtools.Demos.Workstation.Customized
   Class ChangeWorkstationLanguageCommand : Inherits WorkstationCommand
      Public Sub New(ByVal featureId As String, ByVal container As WorkstationContainer, ByVal language As WorkstationLanguageResources)
         MyBase.New(featureId, container)
         Me.Language = language
      End Sub

      Protected Overrides Sub DoExecute()
         Language.MessagesStream.Position = 0
         Language.ToolBarStream.Position = 0
         Language.LoaderSteeam.Position = 0
         Language.ActionsNameStream.Position = 0

         WorkstationMessages.LoadMessages(Language.MessagesStream)
         ToolStripMenuProperties.LoadStrings(Language.ToolBarStream)
         LoaderStatusMessage.Load(Language.LoaderSteeam)
         Container.State.SetMouseButtonActionDisplayNameStream(Language.ActionsNameStream)
      End Sub

      Protected Overrides Function DoCanExecute() As Boolean
         Return Not Nothing Is Language
      End Function

      Public Language As WorkstationLanguageResources
   End Class
End Namespace
