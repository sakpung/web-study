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
using System.Runtime.InteropServices;

namespace MedicalViewerDemo
{
    public partial class StentEnhancementDialog : Form
    {
        public bool CancelClicked;
        private MainForm _form;


        private const int SC_CLOSE = 0xF060;
        private const int MF_GRAYED = 0x1;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);

        public void EnableClose(bool isEnable)
        {
           EnableMenuItem(GetSystemMenu(this.Handle, isEnable), SC_CLOSE, MF_GRAYED);
        }

        public StentEnhancementDialog(MainForm form)
        {
            InitializeComponent();
            _form = form;
        }

        public void UpdateProgress(int percent)
        {
            _stentProgressBar.Value = percent;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
           _form._stentDialog_FormClosing(null, null);
           this.Close();
        }

        private void _btnApply_Click(object sender, EventArgs e)
        {
           _btnOk.Enabled = false;
           _btnApply.Enabled = false;
           EnableClose(false);

            _form.ApplyStent();

            _btnOk.Enabled = true;
            _btnApply.Enabled = true;
            EnableClose(true);
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked = true;
        }

        private void StentEnhancementDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form.FinishStentEnhancement();
        }

        private void _btnReset_Click(object sender, EventArgs e)
        {
            _form.ResetRegion();
        }

        public void ResetBtnEnabled(bool value)
        {
            _btnReset.Enabled = value;
        }

        private void _btnResetAvg_Click(object sender, EventArgs e)
        {
            _form.ResetAverage();
        }

        public void ResetAvgEnabled(bool value)
        {
            _btnResetAvg.Enabled = value;
        }
    }
}
