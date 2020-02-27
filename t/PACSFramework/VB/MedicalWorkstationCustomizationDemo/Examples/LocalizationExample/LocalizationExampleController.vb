' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Workstation.UI.Factory
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical.Workstation.Loader
Imports Leadtools.Medical.Workstation.Interfaces.Views

Namespace Leadtools.Demos.Workstation.Customized
   Class LocalizationExampleController : Inherits ExamplesControllerBase
      Public Sub New()

      End Sub

      Protected Overrides Sub RegisterExampleMenu(ByVal exampleItem As DesignToolStripMenuItem)
         Dim languageItem As DesignToolStripMenuItem


         languageItem = New DesignToolStripMenuItem(CustomMenuItemFeatureProperties.LanguageItemProperty)
         _languageEnglishItem = New DesignToolStripMenuItem(CustomMenuItemFeatureProperties.EnglishLanguageItemProperty)
         _languageSpanishItem = New DesignToolStripMenuItem(CustomMenuItemFeatureProperties.SpanishLanguageItemProperty)

         languageItem.DropDownItems.Add(_languageEnglishItem)
         languageItem.DropDownItems.Add(_languageSpanishItem)

         exampleItem.DropDownItems.Add(languageItem)

         _languageEnglishItem.Checked = True
      End Sub

      Protected Overrides Sub RegisterExampleCommands(ByVal viewerContainer As WorkstationContainer)
         __ViewerContainer = viewerContainer

         InitializeLanguages(viewerContainer)

         Dim englishCommand As ChangeWorkstationLanguageCommand
         Dim spansihCommand As ChangeWorkstationLanguageCommand

         englishCommand = New ChangeWorkstationLanguageCommand(CustomWorkstationFeatures.EnglishLangFeatureId, viewerContainer, English)

         spansihCommand = New ChangeWorkstationLanguageCommand(CustomWorkstationFeatures.SpanishLangFeatureId, viewerContainer, Spanish)

         viewerContainer.FeaturesFactory.RegisterCommand(englishCommand)
         viewerContainer.FeaturesFactory.RegisterCommand(spansihCommand)

         AddHandler viewerContainer.EventBroker.FeatureExecuted, AddressOf EventBroker_FeatureExecuted
      End Sub

      Private Sub InitializeLanguages(ByVal viewerContainer As WorkstationContainer)
         English = New WorkstationLanguageResources()
         Spanish = New WorkstationLanguageResources()

         English.ToolBarStream = New MemoryStream()
         English.MessagesStream = New MemoryStream()
         English.LoaderSteeam = New MemoryStream()
         English.ActionsNameStream = New MemoryStream()
         Spanish.ToolBarStream = New MemoryStream(Encoding.UTF8.GetBytes(Resources.Toolstrip_Spanish))
         Spanish.MessagesStream = New MemoryStream(Encoding.UTF8.GetBytes(Resources.Messages_Spanish))
         Spanish.LoaderSteeam = New MemoryStream(Encoding.UTF8.GetBytes(Resources.StatusMessages_Spanish))
         Spanish.ActionsNameStream = New MemoryStream(Encoding.UTF8.GetBytes(Resources.actionName_Spanish))

         WorkstationMessages.SaveMessages(English.MessagesStream)
         ToolStripMenuProperties.SaveStrings(English.ToolBarStream)
         LoaderStatusMessage.Save(English.LoaderSteeam)

         viewerContainer.State.GetMouseButtonActionDisplayNameStream(English.ActionsNameStream)
      End Sub


      Private Sub EventBroker_FeatureExecuted(ByVal sender As Object, ByVal e As DataEventArgs(Of String))
         If e.Data = CustomWorkstationFeatures.EnglishLangFeatureId Then
            WorkstationUIFactory.Instance.RegisterWorkstationView(Of IWorkstationCinePlayerView)(GetType(CinePlayer))

            __ViewerContainer.State.ActiveWorkstation.RefreshMouseActionsStatusLabels()

            _languageEnglishItem.Checked = True
            _languageSpanishItem.Checked = False
         ElseIf e.Data = CustomWorkstationFeatures.SpanishLangFeatureId Then
            WorkstationUIFactory.Instance.RegisterWorkstationView(Of IWorkstationCinePlayerView)(GetType(TranslatedCinePlayer))

            __ViewerContainer.State.ActiveWorkstation.RefreshMouseActionsStatusLabels()

            _languageEnglishItem.Checked = False
            _languageSpanishItem.Checked = True
         End If
      End Sub

      Protected Overrides ReadOnly Property ExampleName() As String
         Get
            Return "Localization"
         End Get
      End Property

      Protected Overrides ReadOnly Property ExampleDescription() As String
         Get
            Return "This example will show you how to translate all the Workstation text into another language. The text includes toolbar/menus text, messages displayed by the Workstation Viewer, status strip information… Beside the text displayed by the Workstation, the dialogs will need to be translated by inheriting from the original dialog and translating the text on the controls. As an example for that, the Cine Player Dialog has been translated to show you how to perform this task. To show the Cine Player dialog, load a series then click on the Cine Player button on the Workstation toolbar."
         End Get
      End Property

      Public English As WorkstationLanguageResources
      Public Spanish As WorkstationLanguageResources
      Private __ViewerContainer As WorkstationContainer
      Dim _languageEnglishItem As DesignToolStripMenuItem
      Dim _languageSpanishItem As DesignToolStripMenuItem
   End Class
End Namespace
