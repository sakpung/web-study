// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Workstation.UI;

namespace Leadtools.Demos.Workstation.Customized
{
   class UIElementKeys
   {
      public const string WorkstastionControl = "WorkstastionControl" ;
      public const string ExamplesMenuStrip   = "MainMenuStrip" ;
      public const string ExamplesDescription = "ExamplesDescription" ;
   }
   
   static class CustomMenuItemFeatureProperties
   {
      static CustomMenuItemFeatureProperties ( ) 
      {
         LoadDicomDirItemProperty       = new WorkstationMenuProperties ( "Load DICOMDIR..." ) ;
         LanguageItemProperty           = new WorkstationMenuProperties ( "Language" ) ;
         EnglishLanguageItemProperty    = new WorkstationMenuProperties ( "English" ) ;
         SpanishLanguageItemProperty    = new WorkstationMenuProperties ( "Spanish" ) ;
         ToggelToolbarItemProperty      = new WorkstationMenuProperties ( "Toggle 3D Toolbar" ) ;
         PlugCustomWindowLevelControlProperty = new WorkstationMenuProperties ( "Plug Custom Window Level Control" ) ;
         PlugOrigWindowLevelControlProperty   = new WorkstationMenuProperties ( "Plug Original Window Level Dialog" ) ;
         CreateFeaturesEventsViewItemProperty = new WorkstationMenuProperties ( "Show Features Events View" ) ;
         ShowCustomizeActionViewProperty      = new WorkstationMenuProperties ( "Show Customize Actions View" ) ;
         
         LoadDicomDirItemProperty.FeatureId    = CustomWorkstationFeatures.LoadDicomDirSeriesFeatureId ;
         EnglishLanguageItemProperty.FeatureId = CustomWorkstationFeatures.EnglishLangFeatureId ;
         SpanishLanguageItemProperty.FeatureId = CustomWorkstationFeatures.SpanishLangFeatureId ;
         ToggelToolbarItemProperty.FeatureId   = CustomWorkstationFeatures.ToggleToolBarFeatureId ;
         
         PlugCustomWindowLevelControlProperty.FeatureId = CustomWorkstationFeatures.PlugCustomWindowLevelControlFeatureId ;
         PlugOrigWindowLevelControlProperty.FeatureId   = CustomWorkstationFeatures.PlugOrigWindowLevelControlFeatureId ;
         CreateFeaturesEventsViewItemProperty.FeatureId = CustomWorkstationFeatures.FeaturesEventsViewFeatureId ;
         ShowCustomizeActionViewProperty.FeatureId      = CustomWorkstationFeatures.ShowCustomizeActionsViewFeatureId ;
      }
      
      public static WorkstationMenuProperties LoadDicomDirItemProperty ;
      public static WorkstationMenuProperties LanguageItemProperty ;
      public static WorkstationMenuProperties EnglishLanguageItemProperty ;
      public static WorkstationMenuProperties SpanishLanguageItemProperty ;
      public static WorkstationMenuProperties ToggelToolbarItemProperty ;
      public static WorkstationMenuProperties CreateFeaturesEventsViewItemProperty ;
      public static WorkstationMenuProperties PlugCustomWindowLevelControlProperty ;
      public static WorkstationMenuProperties PlugOrigWindowLevelControlProperty ;
      public static WorkstationMenuProperties ShowCustomizeActionViewProperty ;
   }
   
   public class CustomWorkstationFeatures
   {
      public const string EnglishLangFeatureId            = "EnglishLang" ;
      public const string SpanishLangFeatureId            = "SpanishLang" ;
      public const string ToggleToolBarFeatureId          = "ToggleToolBar" ;
      public const string LoadDicomDirSeriesFeatureId     = "LoadDicomDirSeries" ;
      public const string FeaturesEventsViewFeatureId     = "FeaturesEventsView" ;
      public const string PlugCustomWindowLevelControlFeatureId = "PlugCustomWindowLevelControl" ;
      public const string PlugOrigWindowLevelControlFeatureId   = "PlugOriginalWindowLevelControl" ;
      public const string ShowCustomizeActionsViewFeatureId     = "ShowCustomizeActionsView" ;
      public const string ToggleLoadSeriesItem                  = "ToggleLoadSeriesItem" ;
   }
}
