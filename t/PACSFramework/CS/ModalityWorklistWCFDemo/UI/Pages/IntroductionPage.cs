// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Wizard;
using Leadtools.Wizard.Pages;

namespace ModalityWorklistWCFDemo.UI.Pages
{
    public partial class IntroductionPage : WelcomeTemplatePage
    {       
        public IntroductionPage()
        {
            InitializeComponent();
        }

        public override void OnSetActive(object sender, WizardCancelEventArgs e)
        {
            base.OnSetActive(sender, e);            
        }       
    }
}
