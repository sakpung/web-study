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

namespace Leadtools.Medical.Winforms.ClientManager
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
            Text =  "View Association [" + Client.AETitle + "]";
            textBoxAssociation.Text = Client.Association;
            textBoxAssociation.Select(0, 0);           
        }
    }
}
