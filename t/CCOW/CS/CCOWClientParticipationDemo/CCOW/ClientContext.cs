// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Ccow;
using Leadtools.Demos;
using Leadtools.Ccow.UI;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

namespace CCOWClientParticipationDemo.CCOW
{
    public class ClientContext : IContextParticipant
    {
        private IContextManager _ContextManager = null;
        private int _ParticipantCoupon = -1000;
        private List<string> _Access = new List<string>();
        private MainForm _MainForm = null;

        private string _Passcode = "E9CA399D-F0EF-4DAE-BEB3-8037862513CE";

        public event EventHandler JoinedContext = delegate { };
        public event EventHandler LeftContext = delegate { };
        public event EventHandler Pinged = delegate { };        

        public int ParticipantCoupon
        {
            get
            {
                return _ParticipantCoupon;
            }
        }

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
                return _ParticipantCoupon != -1000;
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

        public int LastCoupon
        {
            get
            {
                if (_ContextManager == null)
                    return 0;

                return _ContextManager.MostRecentContextCoupon;
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

        public ClientContext(string ApplicationName,MainForm mainform)
        {
            _ContextManager = Utils.COMCreateObject<IContextManager>("CCOW.ContextManager");
            _KeyContainer = new KeyContainer(ApplicationName);
            _MainForm = mainform;
        }

        public void Join(string ApplicationName, bool survey)
        {
            _ParticipantCoupon = _ContextManager.JoinCommonContext(this, ApplicationName, survey, true);
            JoinedContext(this, EventArgs.Empty);            
        }

        public void Leave()
        {
            if (_ParticipantCoupon != -1000)
            {
                _ContextManager.LeaveCommonContext(_ParticipantCoupon);
                _ParticipantCoupon = -1000;
                LeftContext(this, EventArgs.Empty);
            }
        }

        public void Suspend()
        {
            try
            {
                _MainForm.Log("=> SuspendParticipation({0})", _ParticipantCoupon);
                _ContextManager.SuspendParticipation(_ParticipantCoupon);
                _Suspended = true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Resume(bool wait)
        {
            try
            {
                _MainForm.Log("=> ResumeParticipation({0},{1})", _ParticipantCoupon,wait);
                _ContextManager.ResumeParticipation(_ParticipantCoupon, wait);
                _Suspended = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool IsSecurityAny(Subject s)
        {
            if (_Access.Count == 0)
                return false;

            int index = _Access.IndexOf(s.Name);

            if (index != -1)
            {
                return _Access[index + 1].ToLower() == "any";
            }

            return false;
        }

        public void SetSecure(Subject s)
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

                _MainForm.Log("=> StartContextChanges({0}) (Secure)",_ParticipantCoupon);
                transaction = _ContextManager.StartContextChanges(_ParticipantCoupon);
                _MainForm.Log("     Received transaction coupon: {0}", transaction);
                for (int i = 0; i < names.Length; i++)
                {
                    v.Add(values[i].ToString());
                }

                appSignature = _ParticipantCoupon.ToString() + string.Join("", names) +
                              string.Join("", v.ToArray()) + transaction.ToString();
                appSignature = CreateSignature(appSignature);
                _MainForm.Log("=> SetItemValues([{0}],[{1}],{2},{3},{4})",_ParticipantCoupon,string.Join(",",names),
                              string.Join(",", Array.ConvertAll<object, string>(values, new Converter<object, string>(Convert))), transaction, appSignature);
                secure.SetItemValues(_ParticipantCoupon, names, values, transaction, appSignature);
                _MainForm.Log("=> EndContextChanges({0},ref noContinue) (Secure)", transaction);
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

                _MainForm.Log("=> PublishChangesDecision({0},{1})", transaction,decision);
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

        public string Convert(object o)
        {
            return o != null ? o.ToString() : string.Empty;
        }

        public void Set(Subject subject)
        {
            if (!IsSecurityAny(subject))
            {
                SetSecure(subject);
                return;
            }

            try
            {
                IContextData data = Access<IContextData>();
                bool noContinue = true;
                object reasons;
                string decision = "accept";
                bool disconnect = false;
                int transaction;

                _MainForm.Log("=> StartContextChanges({0})", _ParticipantCoupon);
                transaction = _ContextManager.StartContextChanges(_ParticipantCoupon);
                _MainForm.Log("     Received transaction coupon: {0}", transaction);
                _MainForm.Log("=> SetItemValues([{0}],[{1}],{2},{3})", _ParticipantCoupon, string.Join(",", subject.ToItemNameArray()),
                              string.Join(",", Array.ConvertAll<object, string>(subject.ToItemValueArray(), new Converter<object, string>(Convert))), transaction);
                data.SetItemValues(_ParticipantCoupon, subject.ToItemNameArray(), subject.ToItemValueArray(), transaction);
                _MainForm.Log("=> EndContextChanges({0},ref noContinue)", transaction);
                reasons = _ContextManager.EndContextChanges(transaction, ref noContinue);

                //
                // If any application responded that they cannot apply the change we need to display
                // a dialog that displays the reasons for the problems.
                //
                if ((reasons != null && ((string[])reasons).Length > 0) || noContinue)
                {
                    ProblemDialog pd = new ProblemDialog((string[])reasons, noContinue);

                   DialogResult result = pd.ShowDialog();
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

                _MainForm.Log("=> PublishChangesDecision({0},{1})", transaction, decision);
                _ContextManager.PublishChangesDecision(transaction, decision);
                if (disconnect)
                {
                    Leave();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T Access<T>()
        {
            return (T)_ContextManager;
        }

        public bool IsUserContextSet()
        {
            if (_ContextManager.MostRecentContextCoupon != 0)
            {
                ContextItem item = new ContextItem("User.id.logon." + MainForm.Suffix);
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
                int coupon = repository.Connect(MainForm.ApplicationName);

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

            if (repository != null)
            {
                int coupon = repository.Connect(MainForm.ApplicationName);

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

            _MainForm.Log("=> InitializeBinding({0},{1},{2}) (Authentication Repository)", coupon, Constants.PassCodeNames, Constants.PassCodeValues);
            mac = sb.InitializeBinding(coupon, Constants.PassCodeNames, Constants.PassCodeValues, ref contextPublicKey);
            _MainForm.Log("=> Verify mac. Returned Public Key: {0}",contextPublicKey);
            hash = Utils.BinaryEncode(Utils.Hash(contextPublicKey + Passcode));
            if (mac.ToLower() != hash.ToLower())
            {
                _MainForm.Log("     Failed to verify authentication repository.");
                return;
            }

            //
            // Create participant hash and finalize binding
            //
            hash = Utils.BinaryEncode(Utils.Hash(PublicKey + Passcode));
            _MainForm.Log("=> FinalizeBinding({0},{1},{2}) (Authentication Repository)", coupon, PublicKey, hash.ToLower());
            sb.FinalizeBinding(coupon, PublicKey, hash.ToLower());            
        }

        public void SecureBind(ref bool failedVerify)
        {
            string mac = string.Empty;
            string contextPublicKey = string.Empty;
            string hash = string.Empty;
            ISecureBinding sb = Access<ISecureBinding>();
            object access = null;

            failedVerify = false;
            _MainForm.Log("=> InitializeBinding({0},{1},{2}) (Context Manager)", _ParticipantCoupon, Constants.PassCodeNames, Constants.PassCodeValues);
            mac = sb.InitializeBinding(_ParticipantCoupon, Constants.PassCodeNames, Constants.PassCodeValues, ref contextPublicKey);
            _MainForm.Log("=> Verify mac. Returned Public Key: {0}", contextPublicKey);
            hash = Utils.BinaryEncode(Utils.Hash(contextPublicKey + Passcode));
            if (mac.ToLower() != hash.ToLower())
            {
                _MainForm.Log("     Failed to verify context manager");
                MainForm.UserLink = false;
                failedVerify = true;
                return;
            }

            //
            // Create participant hash and finalize binding
            //
            hash = Utils.BinaryEncode(Utils.Hash(PublicKey + Passcode));
            _MainForm.Log("=> FinalizeBinding({0},{1},{2}) (Authentication Repository)", _ParticipantCoupon, PublicKey, hash.ToLower());
            access = sb.FinalizeBinding(_ParticipantCoupon, PublicKey, hash.ToLower());
            if (access != null)
            {
                string[] a = (string[])access;

                for (int i = 0; i < a.Length; i += 2)
                {
                    _MainForm.Log("     {0}\t{1}", a[i], a[i + 1]);
                }
            }            
            _Access.AddRange((string[])access);
        }

        public bool Login(out string user)
        {
            bool loggedIn = false;
            IContextAction action = Access<IContextAction>();
            object itemNames = new string[] {"AuthenticateUser.In.ExpectedUserLogOn"};
            object itemValues = new string[1];
            int actionCoupon = Constants.AuthenticateUserActionAgent;
            string appSignature = _ParticipantCoupon.ToString() + ((string[])itemNames)[0].ToString();

            action.Perform(_ParticipantCoupon, itemNames, itemValues, CreateSignature(appSignature), 
                           ref actionCoupon,ref itemNames, ref itemValues);

            user = string.Empty;
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

                    if (item.Subject.ToLower() == "user" && item.Role.ToLower() == "id"
                        && item.Name.ToLower() == "logon" && item.Suffix.ToLower()==MainForm.Suffix.ToLower())
                    {
                        user = item.Value.ToString();
                    }
                }                
            }

            return loggedIn;
        }

        public bool IsSetting(string subject, string name,int coupon)
        {
            IContextData context = Access<IContextData>();

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

        public string GetCurrentUser()
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

                        if (item.Suffix.ToLower() == MainForm.Suffix.ToLower() && item.Subject.ToLower() == "user" &&
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

        public NameValueCollection GetCurrentContext()
        {
            NameValueCollection context = new NameValueCollection();
            IContextData data = Access<IContextData>();
            
            if (data != null && _ContextManager.MostRecentContextCoupon!=0)
            {
                object contextData = null;

                _MainForm.Log("=> GetItemNames({0})", _ContextManager.MostRecentContextCoupon);
                contextData = data.GetItemNames(_ContextManager.MostRecentContextCoupon);
                if (contextData.GetType() == typeof(string[]) && ((string[])contextData).Length > 0)
                {
                    string[] names = (string[])contextData;

                    _MainForm.Log("     Available Item Names");
                    foreach (string name in names)
                    {
                        _MainForm.Log("          " + name);
                    }

                    _MainForm.Log("=> GetItemValues([{0}],false,{1})", string.Join(",", names), _ContextManager.MostRecentContextCoupon);
                    contextData = data.GetItemValues(contextData, false, _ContextManager.MostRecentContextCoupon);
                    if (contextData.GetType() == typeof(object[]))
                    {
                        object[] values = (object[])contextData;

                        for (int i = 0; i < values.Length; i += 2)
                        {
                            context.Add(values[i].ToString(), values[i+1].ToString());
                            _MainForm.Log("          {0} ({1})",values[i],values[i+1].ToString());
                        }
                    }
                }
            }

            return context;
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
            Pinged(this, EventArgs.Empty);
        }

        #endregion
    }
}
