// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using CCOWAuthenticationDemo.Properties;
using Leadtools;
using Leadtools.Ccow;
using Leadtools.Demos;
#if LEADTOOLS_V19_OR_LATER
using System.Linq;
using Leadtools.Ccow.Server;
using Leadtools.Ccow.Server.Data;
#endif // #if LEADTOOLS_V19_OR_LATER

namespace CCOWAuthenticationDemo
{
    public partial class MainForm : Form
    {
        public const string _ApplicationName = "CCOW Authentication Application";
        public const string _Suffix = "AuthApp";
        private bool _LoggedIn = false;

        private ClientContext _Context = null;
        private const string _Passcode = "5DC2ABCD-A855-4530-BC9C-2F13C58DDC0E";
        public static string _LaunchArgs = string.Empty;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main(string[] args)
            {
                bool createdNew = true;

                using (Mutex mutex = new Mutex(true, "CSCCOWAthenticationDemo", out createdNew))
                {
                    if (createdNew)
                    {
                       if (!Support.SetLicense())
                          return;

                        if (RasterSupport.IsLocked(RasterSupportType.Ccow))
                        {
                            MessageBox.Show("CCOW Support is locked!  Application will exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (args.Length > 0)
                        {
                            _LaunchArgs = string.Join(" ", args);
                        }

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new MainForm());
                    }
                    else
                    {
                        Process current = Process.GetCurrentProcess();

                        foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                        {
                            if (process.Id != current.Id)
                            {
                                SetForegroundWindow(process.MainWindowHandle);
                                break;
                            }
                        }

                    }
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Messager.Caption = "CCOW Sign-On Application";
            Text = "C# " + Messager.Caption;

            labelCurrentUser.Text = string.Empty;
            labelFullName.Text = string.Empty;
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            try
            {
                _Context = new ClientContext(Messager.Caption, _Passcode, this);
                if (_Context.IsValid)
                {
                    _Context.JoinedContext += new EventHandler(Context_JoinedContext);
                    _Context.ChangesAccepted += new EventHandler<ContextEventArgs>(Context_ChangesAccepted);
                    labelCurrentUser.Text = string.Empty;
                    labelFullName.Text = string.Empty;
                    JoinContext();
                    System.Windows.Forms.Application.Idle += new EventHandler(Application_Idle);
                }
                else
                {
                    Messager.ShowError(this, "The Context Manager COM object could not be created.");
                    Close();
                }
            }
            catch (Exception exception)
            {
                Messager.ShowError(this, exception);
                buttonLogon.Enabled = false;
            }
        }

        void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void JoinContext()
        {
            try
            {
                ProgressInfoDialog dlgProgress = new ProgressInfoDialog(this);

                dlgProgress.Title = "Joining Common Context";
                dlgProgress.Description = "Attempting to join common context";
                if (dlgProgress.ShowDialog(() => _Context.Join(_ApplicationName, true)) == DialogResult.OK)
                {
                    _Context.SetFilter("User");
                }
                else
                {
                    if (dlgProgress.Exception != null)
                        throw dlgProgress.Exception;
                }
            }
            catch (Exception e)
            {
                Messager.ShowError(this, e);
                Close();
            }
        }

        #region Context Events

        private void Context_JoinedContext(object sender, EventArgs e)
        {
            SetCCowIcon(ContextState.Linked);
        }

        private void Context_ChangesAccepted(object sender, ContextEventArgs e)
        {
            bool logOff = false;

            if (_Context.IsSetting("user", "logon", e.ContextCoupon))
            {
                ContextItem item = new ContextItem("User.Id.logon." + _Suffix);
                string temp = _Context.GetItemValue(item, false, e.ContextCoupon);

                //
                // Check to see if an application has logged off the user
                //
                if (string.IsNullOrEmpty(temp))
                {
                    logOff = true;
                }
            }
            else
                logOff = true;

            if(logOff)
            {
                Invoke(new MethodInvoker(LogOff));
            }
        }

        #endregion

        private void LogOff()
        {
            buttonLogon.Text = "Logon";
            labelCurrentUser.Text = string.Empty;
            labelFullName.Text = string.Empty;
            _LoggedIn = false;

#if LEADTOOLS_V19_OR_LATER
            if (CheckPatientDependencies())
               this._Context.Leave();
#endif // #if LEADTOOLS_V19_OR_LATER
        }

#if LEADTOOLS_V19_OR_LATER
        static bool CheckPatientDependencies()
        {
           Monitor.Enter(CcowServer.LockObject);
           try
           {
              using (Database db = Leadtools.Ccow.Server.Utils.GetDatabase())
              {
                 CCOWSubject patientSubject = db.CCOWSubject.FirstOrDefault(a => a.Subject.ToLower() == "patient");
                 foreach (CCOWSubjectDependency dp in patientSubject.DependentSubjects)
                 {
                    if (dp.CCOWSubject.Subject.ToLower() == "user")
                       return true;
                 }
              }
           }
           finally
           {
              Monitor.Exit(CcowServer.LockObject);
           }

           return false;
        }
#endif // #if LEADTOOLS_V19_OR_LATER

        private void SetCCowIcon(ContextState state)
        {
            switch (state)
            {
                case ContextState.Broken:
                    pictureBoxCcowStatus.Image = Resources.Broken;
                    //pictureBoxCcowStatus.ToolTipText = "Broken";
                    break;
                case ContextState.Changing:
                    pictureBoxCcowStatus.Image = Resources.Changing;
                    //toolStripStatusLabelConnection.ToolTipText = "Changing";
                    break;
                case ContextState.Linked:
                    pictureBoxCcowStatus.Image = Resources.Linked;
                    //toolStripStatusLabelConnection.ToolTipText = "Linked";
                    break;
            }
        }

        private void Application_Idle(object sender, EventArgs e)
        {            
        }

       private void buttonAbout_Click(object sender, EventArgs e)
        {
            AboutDialog dlgAbout = new AboutDialog(Messager.Caption);

            dlgAbout.ShowDialog(this);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Context != null)
            {
                if (_Context.Joined)
                {
                    ProgressInfoDialog dlgProgress = new ProgressInfoDialog(this);

                    dlgProgress.Title = "Leaving Common Context";
                    dlgProgress.Description = "Attempting to leave common context";
                    try
                    {
                        dlgProgress.ShowDialog(() => _Context.Leave());
                    }
                    catch (Exception ex)
                    {
                        Messager.ShowError(this, ex);
                        e.Cancel = true;
                    }
                }
            }            
        }

        private void buttonLogon_Click(object sender, EventArgs e)
        {
            try
            {
                _Context.SecureBind();
                if (_Context.CanPerformAuthenticateAction)
                {
                    bool success = PerformLogin();

                    if (!string.IsNullOrEmpty(_LaunchArgs) && _LoggedIn && success)
                    {
                        LaunchParticipant();
                        _LaunchArgs = string.Empty;
                    }
                }
                else
                {
                    Messager.ShowInformation(this, _ApplicationName + " can't perform authentication.\r\n" +
                                             "Launch the context manager and add this application to the\r\n" +
                                             "Authenticate-User Action subject");
                }
            }
            catch (Exception exception)
            {
                // 
                // If this fails the application cannot perform a secure bind.  Therefore they will not
                // be able to perform the logon action.
                //
                if (exception is COMException)
                {
                    //
                    // Check to see if the Context Manager server has terminated.
                    //
                    if (exception.Message.Contains("The RPC server is unavailable"))
                    {
                        Messager.Show(this, "Context Manager Server has terminated.  Application can no longer access the context.  The application will restart and try to rejoin the context.",
                                      MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
                        Close();
                        CCOWUtils.Restart();
                    }
                    else
                    {
                        Messager.ShowError(null, exception);
                    }
                }
                else
                    Messager.ShowError(null, exception);
            }
        }

        private void LaunchParticipant()
        {
            string participantFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSCCOWClientParticipationDemo_Original.exe");

            if (!File.Exists(participantFileName))
            {
                participantFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSCCOWClientParticipationDemo.exe");
            }

            if (File.Exists(participantFileName))
            {
                Process process = new Process();
               
                process.StartInfo.FileName = participantFileName;
                process.StartInfo.Arguments = _LaunchArgs;
                process.Start();
            }
            else
            {
                Messager.ShowError(null, "Could not find the CSCCOWClientParticipationDemo");
            }
        }

        private bool PerformLogin()
        {
            if (!_LoggedIn)
            {
                string user = string.Empty;
                string name = string.Empty;

                if (_Context.Login(_Suffix, ref user,ref name))
                {
                    Subject s = new Subject("User");
                    ContextItem item = new ContextItem("User.id.logon." + _Suffix, user);

                    try
                    {
                        s.Items.Add(item);
                        if (_Context.SetSecure(s))
                        {
                            _LoggedIn = true;
                            buttonLogon.Text = "Logout";
                            labelCurrentUser.Text = user;
                            labelFullName.Text = name;
                        }
                    }
                    catch (Exception e)
                    {
                        Messager.ShowError(this, e);
                        return false;
                    }
                }
            }
            else
            {
                Subject userSubject = new Subject("User");
                ContextItem item = new ContextItem("User.Id.logon." + _Suffix, string.Empty);

                userSubject.Items.Add(item);
                _Context.Set(userSubject);
                buttonLogon.Text = "Logon";
                labelCurrentUser.Text = string.Empty;
                labelFullName.Text = string.Empty;  
                _LoggedIn = false;
            }
            return true;
        }

        private void AutoLogOn()
        {
            buttonLogon_Click(buttonLogon, EventArgs.Empty);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //
            // Automatically display the login dialog if we were lauched from a participant application
            //
            if (!string.IsNullOrEmpty(_LaunchArgs))
            {
                BeginInvoke(new MethodInvoker(AutoLogOn));
            }
        }                     
    }
}
