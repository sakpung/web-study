// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.InteropServices;
using Leadtools.Ccow;
using Leadtools.Demos;

namespace Leadtools.UserAnnotation.Agent
{
    [Guid("03A5ACBC-60E0-4edd-ABD1-7FD364D3D65E")]
    [ProgId("CCOW.AnnotationAgent_User")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class UserAnnotationAgent : IContextAgent
    {      
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
                         ContextItem item = new ContextItem("User.Co.Name");

                         item.Value = mu.Name;
                         userSubject.Items.Add(item);
                     }

                     outitemNames = userSubject.ToItemNameArray();
                     outitemValues = userSubject.ToItemValueArray();
                 }
             }            
            return string.Empty;
        }

        public void Ping()
        {
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
    }
}
