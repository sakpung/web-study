// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Leadtools.Demos
{
    [Serializable]
    public class Scenario
    {
        public string Description { get; set; }        
        public List<MasterUser> MasterUserIndex { get; set; }        
        public List<MasterPatient> MasterPatientIndex { get; set; }
        public List<CCOWApplication> Applications { get; set; }
        [XmlIgnore]
        public string Filename { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Description))
                return Description;

            return "No Description Provided";
        }

        public static List<Scenario> LoadScenarios()
        {
            List<Scenario> scenarios = new List<Scenario>();

            foreach (string file in Directory.GetFiles(Application.StartupPath, "*.scn"))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Scenario));

                    using (StreamReader reader = new StreamReader(file))
                    {
                        Scenario scenario = null;
                        
                        scenario = serializer.Deserialize(reader) as Scenario;
                        scenario.Filename = file;
                        scenarios.Add(scenario);
                        reader.Close();
                    }
                }
                catch { }
            }

            return scenarios;
        }        
    }

    [Serializable]    
    public class User
    {        
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool DomainLogin { get; set; }
        public string Domain { get; set; }        

        public User()
        {
            DomainLogin = false;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Username))
                return Username;

            return string.Empty;
        }
    }

    [Serializable]    
    public class MasterUser : User
    {
        public List<ApplicationUser> ApplicationUsers { get; set; }

        public override string ToString()
        {            
            if (!string.IsNullOrEmpty(Username))
                return Username;

            return string.Empty;
        }
    }

    [Serializable]
    public class ApplicationUser
    {
        public string LogonName { get; set; }
        public string ApplicationName { get; set; }
    }  

    [Serializable]
    public class Patient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Sex { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class MasterPatient : Patient
    {
        public List<ApplicationPatient> ApplicationPatients { get; set; }
    }

    [Serializable]
    public class ApplicationPatient
    {
        public string ApplicationName { get; set; }
        public string PatientId { get; set; }
    }    

    [Serializable]
    public class CCOWApplication
    {
        public string Name { get; set; }
        public string Suffix { get; set; }
        public List<User> Users { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
