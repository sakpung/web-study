// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DicomDemo
{
    public partial class ProgressDialog : Form
    {        
        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public string ProgressInfo
        {
            get { return ProgressInfoLabel.Text; }
            set { ProgressInfoLabel.Text = value; }
        }

        private bool _Marquee = true;

        public bool Marquee
        {
            get { return _Marquee; }
            set { _Marquee = value; }
        }

        private Thread _ActionThread;

        public Thread ActionThread
        {
            get { return _ActionThread; }
            set { _ActionThread = value; }
        }

        private Action _Cancel;

        public Action Cancel
        {
            get { return _Cancel; }
            set { _Cancel = value; }
        } 

        public ProgressDialog()
        {
            InitializeComponent();            
        }

        private void ProgressDialog_Load(object sender, EventArgs e)
        {
            if (_Marquee)
            {
                progressBar.MarqueeAnimationSpeed = 30;
                progressBar.Style = ProgressBarStyle.Marquee;
            } 
            Thread dialogThread = new Thread(delegate()
            {
                _ActionThread.Start();
                while (_ActionThread.IsAlive)
                    Thread.Sleep(0);
                SynchronizedInvoke(() => DialogResult = DialogResult.OK);
            });
            dialogThread.Start();
        }

        private void SynchronizedInvoke(MethodInvoker del)
        {
            if (InvokeRequired)
                BeginInvoke(del, null);
            else
                del();
        }

        private void ProgressDialog_Shown(object sender, EventArgs e)
        {
            CancelOperationButton.Enabled = Cancel != null;
        }

        private void CancelOperationButton_Click(object sender, EventArgs e)
        {
            if (Cancel != null)
                Cancel();
        }
    }    
}
