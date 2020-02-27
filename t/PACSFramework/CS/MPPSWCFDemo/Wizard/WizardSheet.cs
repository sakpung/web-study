// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Leadtools.Demos;

namespace Leadtools.Wizard
{
    public partial class WizardSheet : UserControl
    {
        #region Public

        #region Methods

        public WizardSheet()
        {
            try
            {
                InitializeComponent();

                Init();

                RegisterEvents();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        public void SetActivePage(int pageIndex)
        {
            try
            {
                WizardPage page;

                if (pageIndex < 0 || pageIndex >= Pages.Count)
                {
                    throw new ArgumentOutOfRangeException("pageIndex");
                }

                page = Pages[pageIndex];

                SetActivePage(page);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        public void Reset()
        {
            foreach (WizardPage page in Pages)
            {
                page.OnReset();
            }
        }

        #endregion

        #region Properties

        public WizardPagesCollection Pages
        {
            get
            {
                return m_pages;
            }

            private set
            {
                m_pages = value;
            }
        }

        public Button NextButton
        {
           get
           {
              return btnNext;
           }
        }

        #endregion

        private string _Option1Caption = string.Empty;

        public string Option1Caption
        {
            get { return buttonOption1.Text; }
            set { buttonOption1.Text = value; }
        }


        #region Events

        public event EventHandler<WizardPageEventArgs> NextPage;
        public event EventHandler<WizardPageEventArgs> PreviousPage;
        public event EventHandler<WizardPageEventArgs> WizardInstalling;
        public event EventHandler<WizardPageEventArgs> WizardUninstalling;
        public event CancelEventHandler WizardFinished;
        public event CancelEventHandler WizardCanceled;
        public event EventHandler About = delegate { };

        #endregion

        #region Data Types Definition

        [Flags]
        public enum WizardButtons
        {
            None = 0,
            Back = 1,
            Next = 2,
            Finish = 4,
            Cancel = 8,
            About = 16, 
            Option1 = 32,
        }

        #endregion

        #region Callbacks

        #endregion

        #endregion

        #region Protected

        #region Methods

        protected void OnNextPage(WizardPageEventArgs wnea)
        {
            if (null != NextPage)
            {
                NextPage(this, wnea);
            }
        }

        protected void OnPrevioustPage(WizardPageEventArgs wnea)
        {
            if (null != PreviousPage)
            {
                PreviousPage(this, wnea);
            }
        }

        protected void OnWizardFinished(object sender, CancelEventArgs e)
        {
            try
            {
                if (null != WizardFinished)
                {
                    WizardFinished(sender, e);
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        protected void OnWizardCanceled(object sender, CancelEventArgs e)
        {
            try
            {
                if (null != WizardCanceled)
                {
                    WizardCanceled(sender, e);
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        protected void OnWizardInstalling(object sender, WizardPageEventArgs e)
        {
            try
            {
                if (null != WizardInstalling)
                {
                    WizardInstalling(sender, e);
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        protected void OnWizardUninstalling(object sender, WizardPageEventArgs e)
        {
            try
            {
                if (null != WizardUninstalling)
                {
                    WizardUninstalling(sender, e);
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            try
            {
                if (Parent != null && ParentForm != null)
                {
                    ParentForm.AcceptButton = btnNext;
                    ParentForm.CancelButton = btnCancel;
                }

                base.OnParentChanged(e);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        #endregion

        #region Properties

        #endregion

        #region Events

        #endregion

        #region Data Members

        #endregion

        #region Data Types Definition

        #endregion

        #endregion

        #region Private

        #region Methods

        private void Init()
        {
            try
            {
                Pages = new WizardPagesCollection(this);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        private void RegisterEvents()
        {
            try
            {
                this.Load += new EventHandler(WizardSheet_Load);
                btnNext.Click += new EventHandler(btnNext_Click);
                btnBack.Click += new EventHandler(btnBack_Click);
                btnFinish.Click += new EventHandler(btnFinish_Click);
                btnCancel.Click += new EventHandler(btnCancel_Click);
                buttonOption1.Click += new EventHandler(buttonOption1_Click);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }       

        private void ResizeToFit()
        {
            try
            {
                Size maxPageSize;
                Size extraSize;
                Size newSize;


                maxPageSize = new Size(pnlButtons.Width, 0);

                foreach (WizardPage page in Pages)
                {
                    if (page.Width > maxPageSize.Width)
                    {
                        maxPageSize.Width = page.Width;
                    }

                    if (page.Height > maxPageSize.Height)
                    {
                        maxPageSize.Height = page.Height;
                    }
                }

                foreach (WizardPage page in Pages)
                {
                    page.Size = maxPageSize;
                    page.Dock = DockStyle.Fill;
                }

                extraSize = this.Size;

                extraSize -= pnlPages.Size;

                newSize = maxPageSize + extraSize;

                this.Size = newSize;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        private void SetActivePage(WizardPage newPage)
        {
            try
            {
                WizardPage oldActivePage;
                WizardCancelEventArgs e;


                oldActivePage = __ActivePage;

                if (!pnlPages.Controls.Contains(newPage))
                {
                    pnlPages.Controls.Add(newPage);
                }

                newPage.Visible = true;
                newPage.Dock = DockStyle.Fill;

                if (oldActivePage != null)
                {
                    oldActivePage.Visible = false;
                }

                __ActivePage = newPage;

                e = new WizardCancelEventArgs();
                e.PreviousPage = oldActivePage;

                newPage.OnSetActive(this, e);

                if (e.Cancel)
                {
                    newPage.Visible = false;

                    __ActivePage = oldActivePage;
                }

                foreach (WizardPage page in Pages)
                {
                    if (page != __ActivePage)
                    {
                        page.Visible = false;
                    }
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }

        }        

        #endregion

        #region Properties


        private WizardPage __ActivePage;

        public WizardPage ActivePage
        {
            get
            {
                return __ActivePage;
            }
        }

        #endregion

        #region Events

        void WizardSheet_Load(object sender, EventArgs e)
        {
            try
            {
                if (Pages.Count != 0)
                {
                    ResizeToFit();

                    SetActivePage(0);
                }
                else
                {
                    SetWizardButtons(WizardButtons.None);
                }

                if (this.ParentForm != null)
                {
                    this.ParentForm.Activate();
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                WizardPageEventArgs wnea;               

                wnea = new WizardPageEventArgs(__ActivePage);
                if (__ActivePage != null)
                {
                    int index = Pages.IndexOf(__ActivePage);

                    if (index < Pages.Count - 1)
                        wnea.NewPage = Pages[index + 1];
                }

                OnNextPage(wnea);

                if (!wnea.Cancel)
                {
                    __ActivePage.OnWizardNext(this, wnea);

                    if (!wnea.Cancel)
                    {
                        if (null != wnea.NewPage)
                        {
                            wnea.NewPage.ParentWizard = this;
                            wnea.NewPage.PreviousPage = __ActivePage;

                            SetActivePage(wnea.NewPage);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                WizardPageEventArgs wnea;


                wnea = new WizardPageEventArgs(__ActivePage);

                wnea.NewPage = __ActivePage.PreviousPage;

                OnPrevioustPage(wnea);

                if (!wnea.Cancel)
                {
                    __ActivePage.OnWizardBack(this, wnea);

                    if (!wnea.Cancel)
                    {
                        if (null != wnea.NewPage)
                        {
                            wnea.NewPage.ParentWizard = this;

                            SetActivePage(wnea.NewPage);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }


        void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                CancelEventArgs cea;


                cea = new CancelEventArgs(false);

                __ActivePage.OnWizardFinish(this, cea);                

                if(!cea.Cancel)
                    OnWizardFinished(this, cea);

                if (!cea.Cancel)
                {                    
                    Application.Exit(cea);
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CancelEventArgs cea;


                cea = new CancelEventArgs(false);

                __ActivePage.OnWizardCancel(this, cea);

                OnWizardCanceled(this, cea);

                if (!cea.Cancel)
                {
                    Application.Exit(cea);

                    return;

                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.Assert(false, exception.Message);

                throw;
            }
            finally
            {                
            }
        }

        void buttonOption1_Click(object sender, EventArgs e)
        {
            try
            {
                __ActivePage.OnOptionButton1(sender, e);
            }
            catch (Exception exception)
            {
                Debug.Assert(false, exception.Message);
                throw;
            }
        }

        #endregion

        #region Data Members

        private WizardPagesCollection m_pages;        

        #endregion

        #region Data Types Definition

        #endregion

        #endregion

        #region internal

        #region Methods

        internal void SetWizardButtons(WizardButtons buttons)
        {
            // The Back button is simple.
            btnBack.Enabled = ((buttons & WizardButtons.Back) != 0);
            btnCancel.Enabled = ((buttons & WizardButtons.Cancel) != 0);

            {
                btnFinish.Visible = ((buttons & WizardButtons.Finish) != 0);
                btnFinish.Enabled = ((buttons & WizardButtons.Finish) != 0);

                btnNext.Visible = true;
                btnNext.Enabled = ((buttons & WizardButtons.Next) != 0);                

                buttonAbout.Visible = ((buttons & WizardButtons.About) != 0);
                buttonAbout.Enabled = ((buttons & WizardButtons.About) != 0);

                buttonOption1.Visible = ((buttons & WizardButtons.Option1) != 0);
                buttonOption1.Enabled = ((buttons & WizardButtons.Option1) != 0);

                btnNext.NotifyDefault(true);
            }
        }

        #endregion

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            About(this, EventArgs.Empty);
        }

        private void buttonShowHelp_Click(object sender, EventArgs e)
        {
           bool bHelpFound = true;
           try
           {
#if (LTV20_CONFIG)
              //DemosGlobal.LaunchHelp2("WCF.Topics.LEADTOOLSModalityWorklistWCFandMPPSWCF 20");
              Process.Start("https://www.leadtools.com/help/leadtools/v20/dh/to/leadtools-modality-worklist-wcf-and-mpps-wcf.html");
#elif (LTV19_CONFIG)
              DemosGlobal.LaunchHelp2("WCF.Topics.LEADTOOLSModalityWorklistWCFandMPPSWCF 19");
#elif (LTV18_CONFIG)
              DemosGlobal.LaunchHelp2("WCF.Topics.LEADTOOLSModalityWorklistWCFandMPPSWCF 18");
#elif (LTV175_CONFIG)
              DemosGlobal.LaunchHelp2("WCF.Topics.LEADTOOLSModalityWorklistWCFandMPPSWCF 175");
#else
            DemosGlobal.LaunchHelp2("WCF.Topics.LEADTOOLSModalityWorklistWCFandMPPSWCF");
#endif
           }
           catch (Exception)
           {
              bHelpFound = false;
           }
           finally
           {
              if (!bHelpFound)
                 Messager.ShowWarning(this, "Help failed to load.");
           }

        } 

        #region Properties

        #endregion

        #region Events

        #endregion

        #region Data Types Definition

        #endregion

        #region Callbacks

        #endregion

        #endregion
    }
}
