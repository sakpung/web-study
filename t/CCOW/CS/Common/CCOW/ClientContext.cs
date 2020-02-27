// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Ccow;
using Leadtools.Demos;
using Leadtools.Ccow.UI;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Leadtools.Demos
{
    public class ClientContext : IContextParticipant
    {
        private IContextManager _ContextManager = null;
        private int _ParticipantCoupon = -1;
        private List<string> _Access = new List<string>();

        private string _Passcode = string.Empty;
        private string _ApplicationName = string.Empty;
        private Form _Form;

        public event EventHandler JoinedContext = delegate { };
        public event EventHandler LeftContext = delegate { };

        public string Passcode
        {
            get
            {
                return _Passcode;
            }
        }

        public string PublicKey
        {
            get
            {
                if (_KeyContainer != null)
                    return Utils.BinaryEncode(_KeyContainer.GetPublicKey());
                return string.Empty;
            }
        }

        public bool Joined
        {
            get
            {
                return _ParticipantCoupon != -1;
            }
        }

        private bool _Suspended = false;

        public bool Suspended
        {
            get
            {
                return _Suspended;
            }
        }
        
        public bool CanPerformAuthenticateAction
        {
            get
            {
                if (_Access.Count == 0)
                    return false;

                int index = _Access.IndexOf("AuthenticateUser");
                if (index != -1)
                {
                    return _Access[index+1].ToLower() == "set";
                }
                return false;
            }
        }

        public bool CanChangeUser
        {
            get
            {
                if (_Access.Count == 0)
                    return false;

                int index = _Access.IndexOf("User");
                if (index != -1)
                {
                    return _Access[index + 1].ToLower() == "set";
                }
                return false;
            }
        }

        private KeyContainer _KeyContainer = null;

        public KeyContainer KeyContainer
        {
            get
            {
                return _KeyContainer;
            }
        }
        public bool IsValid
        {
            get
            {
                return _ContextManager != null;
            }
        }

        public event EventHandler Terminated;

        private void OnTerminated()
        {
            if (Terminated != null)
            {
                Terminated(this,EventArgs.Empty);
            }
        }

        public event EventHandler<ContextEventArgs> ChangesAccepted;

        private void OnChangesAccepted(int coupon)
        {
            if (ChangesAccepted != null)
            {
                ChangesAccepted(this, new ContextEventArgs(coupon));
            }
        }

        public event EventHandler<ContextEventArgs> ChangesCanceled;

        private void OnChangesCanceled(int coupon)
        {
            if (ChangesCanceled != null)
            {
                ChangesCanceled(this, new ContextEventArgs(coupon));
            }
        }

        public event EventHandler<ContextEventArgs> ChangesPending;

        private string OnChangesPending(int coupon, ref string reason)
        {
            string decision = "accept";

            if (ChangesPending != null)
            {
                ContextEventArgs e = new ContextEventArgs(coupon);

                ChangesPending(this, e);
                reason = e.Reason;
                decision = e.Decision;
            }
            return decision;
        }

        public ClientContext(string ApplicationName,string passcode,Form form)
        {
            _ContextManager = Utils.COMCreateObject<IContextManager>("CCOW.ContextManager");
            _KeyContainer = new KeyContainer(ApplicationName);
            _ApplicationName = ApplicationName;
            _Passcode = passcode;
            _Form = form;
        }

        public void Join(string ApplicationName, bool survey)
        {
            _ParticipantCoupon = _ContextManager.JoinCommonContext(this, ApplicationName, survey, true);
            JoinedContext(this, EventArgs.Empty);
        }

        public void Leave()
        {
            if (_ParticipantCoupon != -1)
            {
                _ContextManager.LeaveCommonContext(_ParticipantCoupon);
                _ParticipantCoupon = -1;
                LeftContext(this, EventArgs.Empty);
            }
        }

        public void Suspend()
        {
            try
            {
                _ContextManager.SuspendParticipation(_ParticipantCoupon);
                _Suspended = true;
            }
            catch (Exception e)
            {
                Messager.ShowError(null, e);
            }
        }

        public void Resume(bool wait)
        {
            try
            {
                _ContextManager.ResumeParticipation(_ParticipantCoupon, wait);
                _Suspended = false;
            }
            catch (Exception e)
            {
                Messager.ShowError(null, e);
            }
        }

        public bool SetSecure(Subject s)
        {
            try
            {
                ISecureContextData secure = Access<ISecureContextData>();
                List<string> v = new List<string>();
                string[] names = s.ToItemNameArray();
                object[] values = s.ToItemValueArray();
                object reasons;
                string decision = "accept", appSignature = string.Empty;
                int transaction;
                bool noContinue = true, disconnect = false;

                transaction = _ContextManager.StartContextChanges(_ParticipantCoupon);
                for (int i = 0; i < names.Length; i++)
                {
                    v.Add(values[i].ToString());
                }

                appSignature = _ParticipantCoupon.ToString() + string.Join("", names) +
                              string.Join("", v.ToArray()) + transaction.ToString();
                appSignature = CreateSignature(appSignature);
                secure.SetItemValues(_ParticipantCoupon, names, values, transaction, appSignature);
                reasons = _ContextManager.EndContextChanges(transaction, ref noContinue);

                //
                // If any application responded that they cannot apply the change we need to display
                // a dialog that displays the reasons for the problems.
                //
                if ((reasons != null && ((string[])reasons).Length > 0) || noContinue)
                {
                    ProblemDialog pd = new ProblemDialog((string[])reasons, noContinue);
                    DialogResult result;

                    result = pd.ShowDialog();
                    if (noContinue)
                        decision = "cancel";
                    if (result == DialogResult.OK)
                        decision = "accept";
                    else if (result == DialogResult.Cancel)
                        decision = "cancel";
                    else
                    {
                        decision = "cancel";
                        disconnect = true;
                    }
                }

                _ContextManager.PublishChangesDecision(transaction, decision);
                if (decision == "accept")
                {                 
                }

                if (disconnect)
                {
                    Leave();
                }
            }
            catch (Exception e)
            {
                Messager.ShowError(null, e);
                return false;
            }
            return true;
        }

        public void Set(Subject subject)
        {
            try
            {
                IContextData data = Access<IContextData>();
                bool noContinue = true;
                object reasons;
                string decision = "accept";
                bool disconnect = false;
                int transaction;

                transaction = _ContextManager.StartContextChanges(_ParticipantCoupon);
                data.SetItemValues(_ParticipantCoupon, subject.ToItemNameArray(), subject.ToItemValueArray(), transaction);
                reasons = _ContextManager.EndContextChanges(transaction, ref noContinue);

                //
                // If any application responded that they cannot apply the change we need to display
                // a dialog that displays the reasons for the problems.
                //
                if ((reasons != null && ((string[])reasons).Length > 0) || noContinue)
                {
                    ProblemDialog pd = new ProblemDialog((string[])reasons, noContinue);
                    DialogResult result;

                    result = pd.ShowDialog();
                    if (noContinue)
                        decision = "cancel";
                    if (result == DialogResult.OK)
                        decision = "accept";
                    else if (result == DialogResult.Cancel)
                        decision = "cancel";
                    else
                    {
                        decision = "cancel";
                        disconnect = true;
                    }
                }

                _ContextManager.PublishChangesDecision(transaction, decision);
                if (disconnect)
                {
                    Leave();
                }
            }
            catch (Exception e)
            {
                Messager.ShowError(null, e);
            }
        }

        public T Access<T>()
        {
            return (T)_ContextManager;
        }

        public bool IsContextSet(string suffix)
        {
            if (_ContextManager.MostRecentContextCoupon != 0)
            {
                ContextItem item = new ContextItem("User.id.logon." + suffix);
                string user = GetItemValue(item, false, _ContextManager.MostRecentContextCoupon);

                return !string.IsNullOrEmpty(user);
            }
            return false;
        }

        public bool IsUserLoggedIn()
        {
            IContextData data = Access<IContextData>();
            bool currentUser = false;

            if (data != null)
            {
                object contextData = new string[] {"User.Id.Logon"};

                contextData = data.GetItemValues(contextData, false, -100);
            }
            return currentUser;
        }

        public string GetAuthenticationData(string user)
        {
            IAuthenticationRepository repository = Utils.COMCreateObject<IAuthenticationRepository>("CCOW.AuthenticationRepository");
            string data = string.Empty;
            
            if (repository != null)
            {
                int coupon = repository.Connect(_ApplicationName);

                if (coupon != 0)
                {
                    try
                    {
                        ISecureBinding sb = repository as ISecureBinding;

                        if (sb != null)
                        {
                            string signature = string.Empty;

                            SecureBind(coupon, sb);
                            signature = coupon.ToString() + user;
                            signature = CreateSignature(signature);
                            repository.GetAuthenticationData(coupon, user, string.Empty, signature, out data);
                        }
                    }
                    catch (COMException e)
                    {
                        if (e.ErrorCode != (int)HResult.LogonNotFound)
                        {
                            throw e;
                        }
                    }
                    finally
                    {
                        repository.Disconnect(coupon);
                    }
                }
            }
            return data;
        }

        public void SetAuthenticationData(string user,string password)
        {
            IAuthenticationRepository repository = Utils.COMCreateObject<IAuthenticationRepository>("CCOW.AuthenticationRepository");
            string data = string.Empty;

            if (repository != null)
            {
                int coupon = repository.Connect(_ApplicationName);

                if (coupon != 0)
                {
                    try
                    {
                        ISecureBinding sb = repository as ISecureBinding;

                        if (sb != null)
                        {
                            string signature = string.Empty;

                            SecureBind(coupon, sb);
                            signature = coupon.ToString() + user + password;
                            signature = CreateSignature(signature);
                            repository.SetAuthenticationData(coupon, user, string.Empty, password,signature);
                        }
                    }
                    catch (COMException e)
                    {
                        if (e.ErrorCode != (int)HResult.LogonNotFound)
                        {
                            throw e;
                        }
                    }
                    finally
                    {
                        repository.Disconnect(coupon);
                    }
                }
            }
        }

        private void SecureBind(int coupon,ISecureBinding sb)
        {
            string mac = string.Empty;
            string contextPublicKey = string.Empty;
            string hash = string.Empty;                        

            mac = sb.InitializeBinding(coupon, Constants.PassCodeNames, Constants.PassCodeValues, ref contextPublicKey);
            hash = Utils.BinaryEncode(Utils.Hash(contextPublicKey + Passcode));
            if (mac.ToLower() != hash.ToLower())
            {
                return;
            }

            //
            // Create participant hash and finalize binding
            //
            hash = Utils.BinaryEncode(Utils.Hash(PublicKey + Passcode));
            sb.FinalizeBinding(coupon, PublicKey, hash.ToLower());            
        }

        public void SecureBind()
        {
            string mac = string.Empty;
            string contextPublicKey = string.Empty;
            string hash = string.Empty;
            ISecureBinding sb = Access<ISecureBinding>();
            object access = null;
            
            mac = sb.InitializeBinding(_ParticipantCoupon, Constants.PassCodeNames, Constants.PassCodeValues, ref contextPublicKey);           
            hash = Utils.BinaryEncode(Utils.Hash(contextPublicKey + Passcode));
            if (mac.ToLower() != hash.ToLower())
            {                
                return;
            }

            //
            // Create participant hash and finalize binding
            //
            hash = Utils.BinaryEncode(Utils.Hash(PublicKey + Passcode));            
            access = sb.FinalizeBinding(_ParticipantCoupon, PublicKey, hash.ToLower());
            _Access.AddRange((string[])access);
        }

        public bool Login(string suffix,ref string user,ref string name)
        {
            bool loggedIn = false;
            IContextAction action = Access<IContextAction>();
            object itemNames = new string[] {"AuthenticateUser.In.ExpectedUserLogOn"};
            object itemValues = new string[1];
            int actionCoupon = Constants.AuthenticateUserActionAgent;
            string appSignature = _ParticipantCoupon.ToString() + ((string[])itemNames)[0].ToString();

            action.Perform(_ParticipantCoupon, itemNames, itemValues, CreateSignature(appSignature), 
                           ref actionCoupon,ref itemNames, ref itemValues);
            
            if (itemNames != null)
            {
                string[] names = (string[])itemNames;
                object[] values = (object[])itemValues;                

                for(int i=0;i<names.Length;i++)
                {
                    ContextItem item = new ContextItem(names[i],values[i]);
                    
                    if (item.Subject.ToLower() == "authenticateuser" && item.Role.ToLower()=="ou" 
                        && item.Name.ToLower()=="status")
                    {
                        loggedIn = item.Value.ToString() == "Pass";
                        if (!loggedIn)
                            break;
                    }

                    if (item.Subject.ToLower() == "authenticateuser" && item.Role.ToLower() == "ou"
                        && item.Name.ToLower() == "logon")
                    {
                        user = item.Value.ToString();
                    }

                    if (item.Subject.ToLower() == "authenticateuser" && item.Role.ToLower() == "ou"
                       && item.Name.ToLower() == "name")
                    {
                        name = item.Value.ToString();
                    }
                }                
            }

            return loggedIn;
        }

        public bool IsSetting(string subject, string name,int coupon)
        {
            IContextData context = Access<IContextData>();
            string user = string.Empty;

            if (context != null)
            {
                object data = context.GetItemNames(coupon);

                if (data != null && data.GetType() == typeof(string[]) && ((string[])data).Length > 0)
                {
                    string[] names = (string[])data;

                    data = null;
                    foreach (string n in names)
                    {
                        ContextItem item = new ContextItem(n);

                        if (item.Subject.ToLower() == subject.ToLower() && item.Name.ToLower() == name.ToLower())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public string GetCurrentUser(string suffix)
        {
            IContextData context = Access<IContextData>();
            string user = string.Empty;

            if (context != null)
            {
                object data = context.GetItemNames(_ContextManager.MostRecentContextCoupon);

                if (data != null && data.GetType() == typeof(string[]) && ((string[])data).Length > 0)
                {
                    string[] names = (string[])data;

                    data = null;
                    foreach (string name in names)
                    {
                        ContextItem item = new ContextItem(name);

                        if (item.Suffix.ToLower() == suffix && item.Subject.ToLower() == "user" &&
                           item.Name.ToLower() == "logon" && item.Role.ToLower() == "id")
                        {
                            data = new string[] { item.ToString() };
                            break;
                        }
                    }

                    if (data != null)
                    {
                        data = context.GetItemValues(data, false, _ContextManager.MostRecentContextCoupon);
                        if (data != null && data.GetType() == typeof(object[]))
                        {
                            object[] values = (object[])data;

                            if(values.Length == 2)
                                user = values[1].ToString();
                        }
                    }
                }
            }
            return user;
        }

        public string GetItemValue(ContextItem item,bool onlyChanges, int coupon)
        {
            IContextData context = Access<IContextData>();

            if (coupon == -1)
                coupon = _ContextManager.MostRecentContextCoupon;

            if (context != null)
            {
                Subject s = new Subject(item.Subject);
                object data = null;

                s.Items.Add(item);
                data = context.GetItemValues(s.ToItemNameArray(), onlyChanges, coupon);
                if (data != null && data.GetType() == typeof(object[]))
                {
                    object[] info = (object[])data;

                    if (info.Length == 2)
                        return info[1].ToString();
                }
            }

            return string.Empty;
        }

        public void SetFilter(params string[] filters)
        {
            IContextFilter filter = Access<IContextFilter>();

            if (filter != null)
            {
                filter.SetSubjectsOfInterest(_ParticipantCoupon, filters);
            }
        }

        private string CreateSignature(string messageDigest)
        {
            byte[] signature = _KeyContainer.Sign(messageDigest);

            return Utils.BinaryEncode(signature);
        }

        #region IContextParticipant Members

        public void CommonContextTerminated()
        {
            OnTerminated();
        }

        public void ContextChangesAccepted(int contextCoupon)
        {
            OnChangesAccepted(contextCoupon);
        }

        public void ContextChangesCanceled(int contextCoupon)
        {
            OnChangesCanceled(contextCoupon);
        }

        public string ContextChangesPending(int contextCoupon, ref string reason)
        {
            return OnChangesPending(contextCoupon, ref reason);
        }

        public void Ping()
        {            
        }

        #endregion
    }
}
