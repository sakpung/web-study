// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.PatientRestrict.AddIn.Common
{
   public class PatientRestrictServerMessage : IProcessServiceMessage
   {
      public bool CanProcess(string MessageId)
      {
         return (
                //  MessageId == MessageNames.IsAddinHealthy ||
                 MessageId == PatientRestrictMessage.SettingsChanged
                 );
      }

      public ServiceMessage Process(ServiceMessage Message)
      {
         ServiceMessage serviceMessage = null;
         switch (Message.Message)
         {
            //case MessageNames.IsAddinHealthy:
            //   serviceMessage = new ServiceMessage();
            //   string error;
            //   serviceMessage.Message = Message.Message;
            //   serviceMessage.Success = CanAccessDatabase(out error);
            //   serviceMessage.Error = error;
            //   break;

            case PatientRestrictMessage.SettingsChanged:
               DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Received 'PatientRestrictMessage.SettingsChanged' Message");
               AdvancedSettings settings = AdvancedSettings.Open(Module.ServiceDirectory);
               Module.ConfigureAddin(settings);
               break;
         }
         return serviceMessage;
      }
   }

   public static class PatientRestrictMessage
   {
      public const string SettingsChanged = "3E7D9C8F-168E-498B-BC81-3CE4C1E0A30B";
   }
}
