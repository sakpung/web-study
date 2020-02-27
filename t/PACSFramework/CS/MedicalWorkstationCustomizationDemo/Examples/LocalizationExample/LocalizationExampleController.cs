// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Workstation.UI;
using Leadtools.Medical.Workstation.UI.Factory;
using Leadtools.Medical.Workstation;
using System.IO;
using Leadtools.Medical.Workstation.Loader;
using Leadtools.Medical.Workstation.Interfaces.Views;

namespace Leadtools.Demos.Workstation.Customized
{
   class LocalizationExampleController : ExamplesControllerBase
   {
      public LocalizationExampleController ( ) 
      {
         
      }
      
      protected override void RegisterExampleMenu ( DesignToolStripMenuItem exampleItem ) 
      {
         DesignToolStripMenuItem languageItem ;
         
         
         languageItem        = new DesignToolStripMenuItem ( CustomMenuItemFeatureProperties.LanguageItemProperty ) ;
         _languageEnglishItem = new DesignToolStripMenuItem ( CustomMenuItemFeatureProperties.EnglishLanguageItemProperty ) ;
         _languageSpanishItem = new DesignToolStripMenuItem ( CustomMenuItemFeatureProperties.SpanishLanguageItemProperty ) ;
         
         languageItem.DropDownItems.Add ( _languageEnglishItem ) ;
         languageItem.DropDownItems.Add ( _languageSpanishItem ) ;
         
         exampleItem.DropDownItems.Add ( languageItem ) ;
         
         _languageEnglishItem.Checked = true ;
      }

      protected override void RegisterExampleCommands ( WorkstationContainer viewerContainer )
      {
         __ViewerContainer = viewerContainer ;
         
         InitializeLanguages ( viewerContainer ) ;
         
         ChangeWorkstationLanguageCommand englishCommand ;
         ChangeWorkstationLanguageCommand spansihCommand ;
      
         englishCommand = new ChangeWorkstationLanguageCommand ( CustomWorkstationFeatures.EnglishLangFeatureId, 
                                                                 viewerContainer, 
                                                                 English ) ;
                                                          
         spansihCommand = new ChangeWorkstationLanguageCommand ( CustomWorkstationFeatures.SpanishLangFeatureId, 
                                                                 viewerContainer, 
                                                                 Spanish ) ;
         
         viewerContainer.FeaturesFactory.RegisterCommand ( englishCommand ) ;
         viewerContainer.FeaturesFactory.RegisterCommand ( spansihCommand ) ;
         
         viewerContainer.EventBroker.FeatureExecuted += new EventHandler<DataEventArgs<string>> ( EventBroker_FeatureExecuted ) ;
      }

      private void InitializeLanguages ( WorkstationContainer viewerContainer )
      {
         English = new WorkstationLanguageResources ( ) ;
         Spanish = new WorkstationLanguageResources ( ) ;
         
         English.ToolBarStream  = new MemoryStream ( ) ;
         English.MessagesStream = new MemoryStream ( ) ;
         English.LoaderSteeam = new MemoryStream ( ) ;
         English.ActionsNameStream = new MemoryStream ( ) ;
         Spanish.ToolBarStream = new MemoryStream ( Encoding.UTF8.GetBytes ( Leadtools.Demos.Workstation.Customized.Properties.Resources.Toolstrip_Spanish ) ) ;
         Spanish.MessagesStream = new MemoryStream ( Encoding.UTF8.GetBytes ( Leadtools.Demos.Workstation.Customized.Properties.Resources.Messages_Spanish ) ) ;
         Spanish.LoaderSteeam = new MemoryStream ( Encoding.UTF8.GetBytes ( Leadtools.Demos.Workstation.Customized.Properties.Resources.StatusMessages_Spanish ) ) ;
         Spanish.ActionsNameStream = new MemoryStream ( Encoding.UTF8.GetBytes ( Leadtools.Demos.Workstation.Customized.Properties.Resources.actionName_Spanish ) ) ;
         
         WorkstationMessages.SaveMessages ( English.MessagesStream ) ;
         ToolStripMenuProperties.SaveStrings ( English.ToolBarStream ) ;
         LoaderStatusMessage.Save ( English.LoaderSteeam ) ;
         
         viewerContainer.State.GetMouseButtonActionDisplayNameStream ( English.ActionsNameStream ) ;
      }
      
      void EventBroker_FeatureExecuted ( object sender, DataEventArgs<string> e )
      {
         if ( e.Data == CustomWorkstationFeatures.EnglishLangFeatureId ) 
         {
            WorkstationUIFactory.Instance.RegisterWorkstationView <IWorkstationCinePlayerView> ( typeof (CinePlayer)) ;
            
            __ViewerContainer.State.ActiveWorkstation.RefreshMouseActionsStatusLabels ( ) ;
            
            _languageEnglishItem.Checked = true ;
            _languageSpanishItem.Checked = false ;
         }
         else if ( e.Data == CustomWorkstationFeatures.SpanishLangFeatureId ) 
         {
            WorkstationUIFactory.Instance.RegisterWorkstationView <IWorkstationCinePlayerView> ( typeof (TranslatedCinePlayer)) ;
            
            __ViewerContainer.State.ActiveWorkstation.RefreshMouseActionsStatusLabels ( ) ;
            
            _languageEnglishItem.Checked = false ;
            _languageSpanishItem.Checked = true ;
         }
      }

      protected override string ExampleName
      {
         get { return "Localization" ; }
      }

      protected override string ExampleDescription
      {
         get 
         { 
            return @"This example will show you how to translate all the Workstation text into another language. The text includes toolbar/menus text, messages displayed by the Workstation Viewer, status strip information…

Beside the text displayed by the Workstation, the dialogs will need to be translated by inheriting from the original dialog and translating the text on the controls. 
As an example for that, the Cine Player Dialog has been translated to show you how to perform this task. To show the Cine Player dialog, load a series then click on the Cine Player button on the Workstation toolbar.
" ;
         }
      }
      
      public WorkstationLanguageResources English
      {
         get ;
         private set ;
      }
      
      public WorkstationLanguageResources Spanish
      {
         get ;
         private set ;
      }
      
      private WorkstationContainer __ViewerContainer
      {
         get ;
         set ;
      }
      
      DesignToolStripMenuItem _languageEnglishItem ;
      DesignToolStripMenuItem _languageSpanishItem ;
   }
}
