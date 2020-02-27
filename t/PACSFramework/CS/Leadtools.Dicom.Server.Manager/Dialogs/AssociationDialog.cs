// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.Server.Manager.Properties;

namespace Leadtools.Dicom.Server.Manager.Dialogs
{
    public partial class AssociationDialog : Form
    {
        private ClientInfo Client;

        public AssociationDialog(ClientInfo client)
        {
            InitializeComponent();
            Client = client;
        }

        private void AssociationDialog_Load(object sender, EventArgs e)
        {
            Text = Resources.ViewAssociation + " [" + Client.AETitle + "]";
            textBoxAssociation.Text = Client.Association;
            textBoxAssociation.Select(0, 0);

            labelAssociation.Text = Resources.AssociationLabel;
            buttonOK.Text = Resources.OkText;
            Icon = Resources.ApplicationIcon;
        }
    }
}
