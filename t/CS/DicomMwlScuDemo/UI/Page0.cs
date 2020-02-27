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

namespace DicomDemo
{
    public partial class Page0 : UserControl
    {
        private Globals _globals;

        public Page0(ref Globals pGlobals)
        {
            InitializeComponent();

            _globals = pGlobals;
        }

        /*
         * Makes sure that the client timeout amount is reasonable
         */
        private void txtTimeout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int timeout = Convert.ToInt32(txtTimeout.Text);
                if (timeout < 15 || timeout > 120)
                    ((MainForm)ParentForm).btnNext.Enabled = false;
                else
                {
                    ((MainForm)ParentForm).btnNext.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                    ((MainForm)ParentForm).btnNext.Enabled = false;
                else
                    MessageBox.Show(ex.ToString());
            }
        }

        private void Page0_Load(object sender, EventArgs e)
        {
            // Initialize text boxes
            txtTimeout.Text = _globals.m_nTimerMax.ToString();
        }
    }
}
