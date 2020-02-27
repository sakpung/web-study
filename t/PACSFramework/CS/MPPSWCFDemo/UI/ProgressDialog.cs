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

namespace MPPSWCFDemo.UI
{
    public partial class ProgressDialog : Form
    {
        private Thread _ActionThread = null;

        public string Title
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;                
            }
        }

        public string Description
        {
            get
            {
                return labelProgressInfo.Text;
            }
            set
            {
                labelProgressInfo.Text = value;
            }
        }

        public ProgressBarStyle Style
        {
            get
            {
                return progressBar.Style;
            }
            set
            {
                progressBar.Style = Style;
            }
        }

        public int Progress
        {
            get
            {
                return progressBar.Value;
            }
            set
            {
                progressBar.Value = Progress;
            }
        }

        private Action _Action = null;

        public Action Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public bool CanCancel
        {
            get
            {
                return buttonCancel.Enabled;
            }
            set
            {
                buttonCancel.Enabled = false;
            }
        }

        private Exception _Exception;

        public Exception Exception
        {
            get { return _Exception; }            
        }

        public ProgressDialog()
        {
            InitializeComponent();
        }

        private void ProgressDialog_Shown(object sender, EventArgs e)
        {
            if(_Action!=null)
            {
                _ActionThread = new Thread(() =>
                {
                    try
                    {
                        _Action();
                        this.Invoke((Action)(() => DialogResult = DialogResult.OK));
                        return;
                    }
                    catch (ThreadAbortException)
                    {
                        
                    }
                    catch (Exception exception)
                    {
                        _Exception = exception;
                    }
                    this.Invoke((Action)(() => DialogResult = DialogResult.Cancel));
                });
                _ActionThread.Start();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (_ActionThread != null)
            {
                _ActionThread.Abort();
            }
        }
    }
}
