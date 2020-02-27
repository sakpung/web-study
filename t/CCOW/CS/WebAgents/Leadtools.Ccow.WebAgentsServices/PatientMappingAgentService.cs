// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using Leadtools.Ccow;
using Leadtools.Ccow.Services;
using Leadtools.Demos;

namespace Leadtools.Ccow.WebAgentsServices
{
   public class PatientMappingAgentService : CcowContextAgentService
   {
      protected override void OnContextChangesPending(int agentCoupon, string contextManager, string[] itemNames, string[] itemValues, int contextCoupon, string managerSignature, ref int outAgentCoupon, ref string[] outitemNames, ref string[] outitemValues, ref int outContextCoupon, ref string agentSignature, ref string decision, ref string reason)
      {
         ActiveScenario scenario = ActiveScenario.Load();

         if (scenario != null)
         {
            string[] names = (string[])itemNames;
            object[] values = (object[])itemValues;
            string patient = string.Empty;

            for (int i = 0; i < names.Length; i++)
            {
               ContextItem item = new ContextItem(names[i], values[i]);

               if (((item.Name.ToLower() == "mpi" || item.Name.ToLower() == "mrn") && item.Role.ToLower() == "id" && item.Subject.ToLower() == "patient"))
               {
                  patient = item.Value.ToString();
               }
            }

            if (!string.IsNullOrEmpty(patient))
            {
               Subject patientSubject = new Subject("Patient");
               MasterPatient mp = GetMasterPatient(scenario.Scenario, patient);

               if (mp != null)
               {
                  ContextItem item = new ContextItem("Patient.Id.MPI");

                  item.Value = mp.Id;
                  patientSubject.Items.Add(item);
                  foreach (ApplicationPatient a in mp.ApplicationPatients)
                  {
                     item = new ContextItem("Patient.Id.MRN." + a.ApplicationName);

                     item.Value = a.PatientId;
                     patientSubject.Items.Add(item);
                  }
               }
               outitemNames = patientSubject.ToItemNameArray();
               List<string> itemsValuesList = new List<string>();
               foreach (object obj in patientSubject.ToItemValueArray())
                  itemsValuesList.Add(obj.ToString());
               outitemValues = itemsValuesList.ToArray();
            }
         }
      }

      private MasterPatient GetMasterPatient(Scenario scenario, string id)
      {
         MasterPatient mp = null;

         foreach (MasterPatient patient in scenario.MasterPatientIndex)
         {
            if (patient.Id.ToLower() == id.ToLower())
            {
               mp = patient;
               break;
            }
         }

         if (mp == null)
         {
            foreach (MasterPatient patient in scenario.MasterPatientIndex)
            {
               foreach (ApplicationPatient p in patient.ApplicationPatients)
               {
                  if (p.PatientId.ToLower() == id.ToLower())
                  {
                     mp = patient;
                     break;
                  }
               }
            }
         }

         return mp;
      }
   }
}
