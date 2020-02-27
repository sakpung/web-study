// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Ccow;
using System.Runtime.InteropServices;
using Leadtools.AuthenticateAction.Agent.UI;
using System.Windows.Forms;
using Leadtools.Demos;

namespace Leadtools.AuthenticateAction.Agent
{
    [Guid("18D0859F-F0AF-470f-8F0D-FF7E7D32F025")]
    [ProgId("CCOW.ActionAgent_AuthenticateUser")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class AuthenticateActionAgent : IContextAgent
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public string ContextChangesPending(int agentCoupon, IContextManager contextManager, object itemNames, object itemValues, int contextCoupon, string managerSignature, ref int outAgentCoupon, ref object outitemNames, ref object outitemValues, ref int outContextCoupon, ref string agentSignature, ref string decision, ref string reason)
        {
            string[] names = (string[])itemNames;
            object[] values = (object[])itemValues;
            Dictionary<string, Subject> subjects = new Dictionary<string, Subject>();
            string suffix = string.Empty;

            if (names.Length != values.Length)
            {                
                throw new COMException(Leadtools.Ccow.Properties.Resources.NameValueCountMismatch, (int)HResult.NameValueCountMismatch);
            }        
           
            for (int i = 0; i < names.Length; i++)
            {
                ContextItem item = new ContextItem(names[i], values[i]);
                Subject subject = null;

                if (subjects.ContainsKey(item.Subject))
                {
                    subject = subjects[item.Subject];
                }
                else
                {
                    subject = new Subject(item.Subject);
                    subjects.Add(item.Subject, subject);
                }

                subject.Items.Add(item);
                if (suffix == string.Empty)
                    suffix = subject.Items[0].Suffix;
            }

            if (subjects.Count == 1)
            {
                string userName, fullName;
                Subject ret = new Subject();

                if(Login(out userName,out fullName))
                {
                    ret.Items.Add(new ContextItem("AuthenticateUser.Ou.Status", "Pass"));
                    ret.Items.Add(new ContextItem("AuthenticateUser.Ou.Logon" + (!string.IsNullOrEmpty(suffix)?suffix:string.Empty), userName));
                    ret.Items.Add(new ContextItem("AuthenticateUser.Ou.Name" + (!string.IsNullOrEmpty(suffix) ? suffix : string.Empty), fullName));
                }
                else
                    ret.Items.Add(new ContextItem("AuthenticateUser.Ou.Status", "Fail"));

                outitemNames = ret.ToItemNameArray();
                outitemValues = ret.ToItemValueArray();
            }

            return string.Empty;
        }

        public void Ping()
        {
        }       

        private bool Login(out string userName,out string fullName)
        {
            LoginDialog dlgLogin = new LoginDialog();
            Win32Window parent = new Win32Window(GetForegroundWindow());
                        
            userName = string.Empty;
            fullName = string.Empty;
            if(dlgLogin.ShowDialog(parent) == DialogResult.OK)
            {
                userName = dlgLogin.Logon;
                fullName = dlgLogin.FullName;
                return true;
            }
            return false;
        }
    }
}
