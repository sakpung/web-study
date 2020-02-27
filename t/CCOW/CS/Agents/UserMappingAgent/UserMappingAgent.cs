// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Ccow;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Leadtools.Demos;

namespace Leadtools.UserMapping.Agent
{
    [Guid("3E1163EA-917F-461a-BF03-300179247903")]
    [ProgId("CCOW.MappingAgent_User")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class UserMappingAgent : IContextAgent
    {
        public string InstallLocation
        {
            get
            {
                string regKey = string.Empty;
                string location = string.Empty;

                regKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{5ADEDEED-1ED0-40F7-88A7-C6D485CDBDBD}";
                if (regKey.Length != 0)
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(regKey);

                    if (key != null)
                    {
                        object value = key.GetValue("InstallLocation");

                        key.Close();
                        if (value != null)
                            location = value.ToString();
                    }
                }

                if (location == string.Empty)
                {
                    location = System.Windows.Forms.Application.StartupPath;
                }
                return location;
            }
        }

        public string ContextChangesPending(int agentCoupon, IContextManager contextManager, object itemNames, object itemValues, int contextCoupon, string managerSignature, ref int outAgentCoupon, ref object outitemNames, ref object outitemValues, ref int outContextCoupon, ref string agentSignature, ref string decision, ref string reason)
        {
            ActiveScenario scenario = ActiveScenario.Load();

            if (scenario != null)
            {
                string[] names = (string[])itemNames;
                 object[] values = (object[])itemValues;
                 string user = string.Empty;

                 for (int i = 0; i < names.Length; i++)
                 {
                     ContextItem item = new ContextItem(names[i], values[i]);

                     if (item.Name.ToLower() == "logon" && item.Role.ToLower() == "id" && item.Subject.ToLower() == "user")
                     {
                         //
                         // Found user name.
                         //
                         user = item.Value.ToString();
                         break;
                     }
                 }

                 if (!string.IsNullOrEmpty(user))
                 {
                     Subject userSubject = new Subject("User");
                     MasterUser mu = GetMasterUser(scenario.Scenario, user);

                     if (mu != null)
                     {
                         foreach (ApplicationUser au in mu.ApplicationUsers)
                         {
                             ContextItem item = new ContextItem("User.Id.Logon." + au.ApplicationName);

                             item.Value = string.IsNullOrEmpty(user) ? string.Empty : au.LogonName;
                             userSubject.Items.Add(item);
                         }
                     }

                     outitemNames = userSubject.ToItemNameArray();
                     outitemValues = userSubject.ToItemValueArray();
                 }
            }           
            return "valid";
        }

        private MasterUser GetMasterUser(Scenario scenario, string username)
        {
            MasterUser mu = null;

            foreach (MasterUser user in scenario.MasterUserIndex)
            {
                if (user.Username.ToLower() == username.ToLower())
                {
                    mu = user;
                    break;
                }
            }

            if (mu == null)
            {
                foreach (MasterUser user in scenario.MasterUserIndex)
                {
                    foreach (ApplicationUser a in user.ApplicationUsers)
                    {
                        if (a.LogonName == username.ToLower())
                        {
                            mu = user;
                            break;
                        }
                    }
                }
            }

            return mu;
        }

        public void Ping()
        {
        }
    }
}
