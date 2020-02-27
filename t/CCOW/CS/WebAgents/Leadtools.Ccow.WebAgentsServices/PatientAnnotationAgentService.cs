// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using Leadtools.Ccow;
using Leadtools.Ccow.Services;
using Leadtools.Demos;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;

namespace Leadtools.Ccow.WebAgentsServices
{
   public class PatientAnnotationAgentService : CcowContextAgentService
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
                  ContextItem item = null;

                  if (mp.BirthDate.HasValue)
                  {
                     item = new ContextItem("Patient.Co.DateTimeOfBirth", mp.BirthDate.Value.ToShortDateString());
                     patientSubject.Items.Add(item);
                  }

                  item = new ContextItem("Patient.Co.Sex", mp.Sex);
                  patientSubject.Items.Add(item);

                  item = new ContextItem("Patient.Co.PatientName", mp.Name);
                  patientSubject.Items.Add(item);
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
