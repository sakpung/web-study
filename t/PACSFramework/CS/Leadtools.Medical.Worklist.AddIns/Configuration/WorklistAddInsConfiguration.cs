// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Configuration ;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration ;


namespace Leadtools.Medical.Worklist.AddIns.Configuration
{
   public class WorklistAddInsConfiguration : SerializableConfigurationSection
   {
      public const string SectionName                              = "worklistAddInsSettings" ;
      private const string UseStationAETitleForMatchingProperty    = "useStationAETitleForMatching" ;
      private const string LimitNumberOfResponsesProperty          = "limitNumberOfResponses" ;
      private const string NumberOfMatchingResponsesProperty       = "numberOfMatchingResponses" ;
      private const string EliminateInProgressMWLProperty          = "eliminateInProgressMWL" ;
      private const string EliminateCompletedMWLProperty           = "eliminateCompletedMWL" ;
      private const string EliminateDiscontinuedMWLProperty        = "eliminateDiscontinuedMWL" ;
      private const string ModalityWorklistValidationProperty      = "modalityWorklistValidation" ;
      private const string ModalityPerformedProcedureCreateValidationProperty = "modalityPerformedProcedureCreateValidation" ;
      private const string ModalityPerformedProcedureSetValidationProperty    = "modalityPerformedProcedureSetValidation" ;
      private const string ModaliyWorklistIODPathProperty                     = "modaliyWorklistIODPath" ;
      private const string ModaliyPerformedProcedureCreateIODPathProperty     = "modaliyPerformedProcedureCreateIODPath" ;
      private const string ModaliyPerformedProcedureSetIODPathProperty        = "ModaliyPerformedProcedureSetIODPath" ;
      
      
      public static WorklistAddInsConfiguration Instance
      {
         get
         {
            IConfigurationSource configuration = ConfigurationSourceFactory.Create ( ) ;
            
            
            return configuration.GetSection ( SectionName ) as WorklistAddInsConfiguration ;
         }
      }
      
      [ConfigurationProperty(UseStationAETitleForMatchingProperty, IsRequired = false)]
      public bool UseStationAETitleForMatching
      {
         get
         {
            return bool.Parse ( base [ UseStationAETitleForMatchingProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ UseStationAETitleForMatchingProperty ] = value ;
         }
      }
      
      [ConfigurationProperty(LimitNumberOfResponsesProperty, IsRequired= false, DefaultValue= false)]
      public bool LimitNumberOfResponses
      {
         get
         {
            return bool.Parse ( base [ LimitNumberOfResponsesProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ LimitNumberOfResponsesProperty ] = value ;
         }
      }
      
      [ConfigurationProperty(NumberOfMatchingResponsesProperty, IsRequired=false, DefaultValue=500)]
      public int NumberOfMatchingResponses
      {
         get
         {
            return int.Parse ( base [ NumberOfMatchingResponsesProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ NumberOfMatchingResponsesProperty ] = value ;
         }
      }
      
      [ConfigurationProperty(EliminateInProgressMWLProperty, IsRequired = false, DefaultValue=false)]
      public bool EliminateInProgressMWL
      {
         get
         {
            return bool.Parse ( base [ EliminateInProgressMWLProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ EliminateInProgressMWLProperty ] = value ;
         }
      }
      
      [ConfigurationProperty(EliminateCompletedMWLProperty, IsRequired = false, DefaultValue=true)]
      public bool EliminateCompletedMWL
      {
         get
         {
            return bool.Parse ( base [ EliminateCompletedMWLProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ EliminateCompletedMWLProperty ] = value ;
         }
      }
      
      [ConfigurationProperty(EliminateDiscontinuedMWLProperty, IsRequired = false, DefaultValue=true)]
      public bool EliminateDiscontinuedMWL
      {
         get
         {
            return bool.Parse ( base [ EliminateDiscontinuedMWLProperty ].ToString ( ) ) ;
         }
         
         set
         {
            base [ EliminateDiscontinuedMWLProperty ] = value ;
         }
      }
      
      [ConfigurationProperty(ModalityWorklistValidationProperty, IsRequired = false)]
      public ModalityWorklistDataSetValidationElement ModalityWorklistValidation
      {
         get
         {
            return base [ ModalityWorklistValidationProperty ]  as ModalityWorklistDataSetValidationElement ;
         }
      }
      
      [ConfigurationProperty(ModalityPerformedProcedureCreateValidationProperty, IsRequired = false)]
      public ModalityPerformedProcedureCreateDataSetValidationElement ModalityPerformedProcedureCreateValidation
      {
         get
         {
            return base [ ModalityPerformedProcedureCreateValidationProperty ]  as ModalityPerformedProcedureCreateDataSetValidationElement ;
         }
      }
      
      [ConfigurationProperty(ModalityPerformedProcedureSetValidationProperty, IsRequired = false)]
      public DataSetValidationElement ModalityPerformedProcedureSetValidation
      {
         get
         {
            return base [ ModalityPerformedProcedureSetValidationProperty ]  as DataSetValidationElement ;
         }
      }
      
      [ConfigurationProperty(ModaliyWorklistIODPathProperty, IsRequired = false)]
      public string ModaliyWorklistIODPath
      {
         get
         {
            return base [ ModaliyWorklistIODPathProperty ]  as string ;
         }
         
         set
         {
            base [ ModaliyWorklistIODPathProperty ]  = value ;
         }
      }
      
      [ConfigurationProperty(ModaliyPerformedProcedureCreateIODPathProperty, IsRequired = false)]
      public string ModaliyPerformedProcedureCreateIODPath
      {
         get
         {
            return base [ ModaliyPerformedProcedureCreateIODPathProperty ]  as string ;
         }
         
         set
         {
            base [ ModaliyPerformedProcedureCreateIODPathProperty ]  = value ;
         }
      }
      
      [ConfigurationProperty(ModaliyPerformedProcedureSetIODPathProperty, IsRequired = false)]
      public string ModaliyPerformedProcedureSetIODPath
      {
         get
         {
            return base [ ModaliyPerformedProcedureSetIODPathProperty ]  as string ;
         }
         
         set
         {
            base [ ModaliyPerformedProcedureSetIODPathProperty ]  = value ;
         }
      }

      public override bool IsReadOnly()
      {
         return false ;
      }
   }
}
