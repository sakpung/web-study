// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using System.Threading;

namespace CCOWClientParticipationDemo.UI
{
    public partial class InfoDialog : Form
    {
        private Thread _Thread;
        private IWin32Window _Owner;
        private Exception _Exception;

        public Exception Exception
        {
            get { return _Exception; }            
        }

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
                return labelDescription.Text;
            }
            set
            {
                labelDescription.Text = value;
            }
        }
    
        public InfoDialog(IWin32Window owner)
        {
            InitializeComponent();
            _Owner = owner;
        }

        private void InfoDialog_Shown(object sender, EventArgs e)
        {
            if (_Thread != null)
            {
                _Thread.Start();
            }
        }

        public DialogResult ShowDialog(MethodInvoker action)
        {
            _Thread = new Thread(() =>
            {
                try
                {                    
                    action();
                    DialogResult = DialogResult.OK;
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception e)
                {
                    _Exception = e;
                    Invoke(new MethodInvoker(()=>DialogResult = DialogResult.Cancel));                    
                }
            });
            return ShowDialog(_Owner);
        }

        private void InfoDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_Exception != null && !_Exception.Message.Contains("The RPC server is unavailable"))
            {            
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (_Thread != null)
            {
                _Thread.Abort(); 
                _Thread.Join();                              
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
