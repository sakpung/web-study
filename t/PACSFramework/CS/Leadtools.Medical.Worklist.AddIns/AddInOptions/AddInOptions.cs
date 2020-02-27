// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.Worklist.AddIns.Controls;
using Leadtools.Medical.Worklist.AddIns.Configuration;
using Leadtools.Dicom.Scp.Command;
using Leadtools.Medical.Winforms;

namespace Leadtools.Medical.Worklist.AddIns
{
   public class WorklistAddInOptions : MarshalByRefObject, IAddInOptions
   {
      #region IAddInOptions Members

      public void Configure(System.Windows.Forms.IWin32Window Parent, Leadtools.Dicom.AddIn.Common.ServerSettings Settings, string ServerDirectory)
      {
         DatabaseEditorDialog configurationDialog;
         AdvancedSettings addInsSettings;
         WorklistAddInsConfiguration worklistSettings;

         AddInsSession.InitializeLicense();
         if (Settings != null)
         {
            PacsProduct.ServiceName = Settings.ServiceName;
         }
         Leadtools.Dicom.DicomEngine.Startup();

         addInsSettings = AdvancedSettings.Open(ServerDirectory);
         worklistSettings = GetWorklistAddInsSettings(addInsSettings);
         configurationDialog = new DatabaseEditorDialog();

         configurationDialog.AddInsSettings = worklistSettings;

         Leadtools.Demos.Messager.Caption = Text;

         configurationDialog.ShowDialog();

         addInsSettings.Save();

         Leadtools.Dicom.DicomEngine.Shutdown();
      }

      private WorklistAddInsConfiguration GetWorklistAddInsSettings(AdvancedSettings advancedSettings)
      {
         WorklistAddInsConfiguration settings;
         string addInsName;


         addInsName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

         settings = advancedSettings.GetAddInCustomData<WorklistAddInsConfiguration>(addInsName,
                                                                                       WorklistAddInsConfiguration.SectionName);
         if (null == settings)
         {
            settings = new WorklistAddInsConfiguration();

            FillDefaultConfiguration(settings);

            advancedSettings.SetAddInCustomData<WorklistAddInsConfiguration>(addInsName,
                                                                               WorklistAddInsConfiguration.SectionName,
                                                                               settings);

            advancedSettings.Save();
         }

         return settings;
      }

      private void FillDefaultConfiguration(WorklistAddInsConfiguration settings)
      {
         ConfigureNCreateSettings(settings);
         ConfigureMppsNCreateSettings(settings);
         ConfigureNSetSettings(settings);
         ConfigureMppsNSetSettings(settings);
         ConfigureCFindSettings(settings);
         ConfigureMWLFindSettings(settings);
      }

      private void ConfigureMWLFindSettings(WorklistAddInsConfiguration settings)
      {
         MWLCFindCommandConfiguration commandConfig = new MWLCFindCommandConfiguration();


         settings.EliminateCompletedMWL = commandConfig.ExcludeCompletedStatus;
         settings.EliminateDiscontinuedMWL = commandConfig.ExcludeDiscontinuedStatus;
         settings.EliminateInProgressMWL = commandConfig.ExcludeInProgressStatus;
         settings.UseStationAETitleForMatching = commandConfig.LimitMWLResponseToClientStationAE;
         settings.ModaliyWorklistIODPath = commandConfig.ModalityWorklistIODPath;
      }

      private void ConfigureCFindSettings(WorklistAddInsConfiguration settings)
      {
         CFindCommandConfiguration commandConfig = new CFindCommandConfiguration();


         settings.ModalityWorklistValidation.AllowExtraElements = commandConfig.AllowExtraElements;
         settings.ModalityWorklistValidation.AllowMultipleItemsSequence = commandConfig.AllowMultipleItems;
         settings.ModalityWorklistValidation.AllowPrivateElements = commandConfig.AllowPrivateElements;
         settings.ModalityWorklistValidation.AllowZeroItemsSequence = commandConfig.AllowZeroItemCount;
      }

      private void ConfigureMppsNSetSettings(WorklistAddInsConfiguration settings)
      {
         NSetMppsCommandConfiguration commandConfig = new NSetMppsCommandConfiguration();


         settings.ModaliyPerformedProcedureSetIODPath = commandConfig.ModalityPerformedProcedureStepIODPath;
      }

      private void ConfigureNSetSettings(WorklistAddInsConfiguration settings)
      {
         NSetCommandConfiguration commandConfig = new NSetCommandConfiguration();

         settings.ModalityPerformedProcedureSetValidation.AllowExtraElements = commandConfig.AllowExtraElements;
         settings.ModalityPerformedProcedureSetValidation.AllowPrivateElements = commandConfig.AllowPrivateElements;
      }

      private void ConfigureMppsNCreateSettings(WorklistAddInsConfiguration settings)
      {
         NCreateMppsCommandConfiguration commandConfig = new NCreateMppsCommandConfiguration();

         settings.ModaliyPerformedProcedureCreateIODPath = commandConfig.ModalityPerformedProcedureStepIODPath;

         settings.ModalityPerformedProcedureCreateValidation.ValidateRelationalToIHERules = commandConfig.ValidateRelationalAttributesAccordingToIHE;
      }

      private void ConfigureNCreateSettings(WorklistAddInsConfiguration settings)
      {
         NCreateCommandConfiguration commandConfig = new NCreateCommandConfiguration();

         settings.ModalityPerformedProcedureCreateValidation.AllowExtraElements = commandConfig.AllowExtraElements;
         settings.ModalityPerformedProcedureCreateValidation.AllowPrivateElements = commandConfig.AllowPrivateElements;
      }

      public AddInImage Image
      {
         get
         {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
               Leadtools.Medical.Worklist.AddIns.Properties.Resources.modality_list_48.ToBitmap().Save(ms, ImageFormat.Png);

               ms.Position = 0;

               return new Bitmap(ms);
            }
         }
      }

      public string Text
      {
         get
         {
            return "Worklist Configuration";
         }
      }

      #endregion
   }
}
