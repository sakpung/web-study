// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Ccow;
using System.Runtime.InteropServices;
using Leadtools.Demos;

namespace Leadtools.PatientMapping.Agent
{
    [Guid("41F35C5E-F008-417a-B5AA-65030F8C8C72")]
    [ProgId("CCOW.MappingAgent_Patient")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class PatientMappingAgent : IContextAgent
    {        
        public string ContextChangesPending(int agentCoupon, IContextManager contextManager, object itemNames, object itemValues, int contextCoupon, string managerSignature, ref int outAgentCoupon, ref object outitemNames, ref object outitemValues, ref int outContextCoupon, ref string agentSignature, ref string decision, ref string reason)
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
                    MasterPatient mp = GetMasterPatient(scenario.Scenario,patient);
                    
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
                    outitemValues = patientSubject.ToItemValueArray();
                }
            }            
            return "valid";
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

        public void Ping()
        {
        }
    }
}
