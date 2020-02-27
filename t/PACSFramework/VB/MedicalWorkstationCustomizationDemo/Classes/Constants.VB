' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Workstation.UI

Namespace Leadtools.Demos.Workstation.Customized
   Class UIElementKeys
      Public Const WorkstastionControl As String = "WorkstastionControl"
      Public Const ExamplesMenuStrip As String = "MainMenuStrip"
      Public Const ExamplesDescription As String = "ExamplesDescription"
   End Class

   Class CustomMenuItemFeatureProperties
      Private Sub New()
      End Sub
      Shared Sub New()
         LoadDicomDirItemProperty = New WorkstationMenuProperties("Load DICOMDIR...")
         LanguageItemProperty = New WorkstationMenuProperties("Language")
         EnglishLanguageItemProperty = New WorkstationMenuProperties("English")
         SpanishLanguageItemProperty = New WorkstationMenuProperties("Spanish")
         ToggelToolbarItemProperty = New WorkstationMenuProperties("Toggle 3D Toolbar")
         PlugCustomWindowLevelControlProperty = New WorkstationMenuProperties("Plug Custom Window Level Control")
         PlugOrigWindowLevelControlProperty = New WorkstationMenuProperties("Plug Original Window Level Dialog")
         CreateFeaturesEventsViewItemProperty = New WorkstationMenuProperties("Show Features Events View")
         ShowCustomizeActionViewProperty = New WorkstationMenuProperties("Show Customize Actions View")

         LoadDicomDirItemProperty.FeatureId = CustomWorkstationFeatures.LoadDicomDirSeriesFeatureId
         EnglishLanguageItemProperty.FeatureId = CustomWorkstationFeatures.EnglishLangFeatureId
         SpanishLanguageItemProperty.FeatureId = CustomWorkstationFeatures.SpanishLangFeatureId
         ToggelToolbarItemProperty.FeatureId = CustomWorkstationFeatures.ToggleToolBarFeatureId

         PlugCustomWindowLevelControlProperty.FeatureId = CustomWorkstationFeatures.PlugCustomWindowLevelControlFeatureId
         PlugOrigWindowLevelControlProperty.FeatureId = CustomWorkstationFeatures.PlugOrigWindowLevelControlFeatureId
         CreateFeaturesEventsViewItemProperty.FeatureId = CustomWorkstationFeatures.FeaturesEventsViewFeatureId
         ShowCustomizeActionViewProperty.FeatureId = CustomWorkstationFeatures.ShowCustomizeActionsViewFeatureId
      End Sub

      Public Shared LoadDicomDirItemProperty As WorkstationMenuProperties
      Public Shared LanguageItemProperty As WorkstationMenuProperties
      Public Shared EnglishLanguageItemProperty As WorkstationMenuProperties
      Public Shared SpanishLanguageItemProperty As WorkstationMenuProperties
      Public Shared ToggelToolbarItemProperty As WorkstationMenuProperties
      Public Shared CreateFeaturesEventsViewItemProperty As WorkstationMenuProperties
      Public Shared PlugCustomWindowLevelControlProperty As WorkstationMenuProperties
      Public Shared PlugOrigWindowLevelControlProperty As WorkstationMenuProperties
      Public Shared ShowCustomizeActionViewProperty As WorkstationMenuProperties
   End Class

   Public Class CustomWorkstationFeatures
	  Public Const EnglishLangFeatureId As String = "EnglishLang"
	  Public Const SpanishLangFeatureId As String = "SpanishLang"
	  Public Const ToggleToolBarFeatureId As String = "ToggleToolBar"
	  Public Const LoadDicomDirSeriesFeatureId As String = "LoadDicomDirSeries"
	  Public Const FeaturesEventsViewFeatureId As String = "FeaturesEventsView"
	  Public Const PlugCustomWindowLevelControlFeatureId As String = "PlugCustomWindowLevelControl"
	  Public Const PlugOrigWindowLevelControlFeatureId As String = "PlugOriginalWindowLevelControl"
	  Public Const ShowCustomizeActionsViewFeatureId As String = "ShowCustomizeActionsView"
	  Public Const ToggleLoadSeriesItem As String = "ToggleLoadSeriesItem"
   End Class
End Namespace
