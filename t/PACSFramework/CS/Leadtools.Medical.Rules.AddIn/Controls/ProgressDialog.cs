// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Leadtools.Medical.Rules.AddIn
{
    public class ProgressDialog : IDisposable
    {        
        private IProgressDialog _ProgressDialog = null;

        private string _Title = string.Empty;
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                _Title = value;
                if (_ProgressDialog != null)
                {
                    _ProgressDialog.SetTitle(_Title);
                }
            }
        }

        private string _CancelMessage = string.Empty;
        public string CancelMessage
        {
            get
            {
                return _CancelMessage;
            }
            set
            {
                _CancelMessage = value;
                if (_ProgressDialog != null)
                {
                    _ProgressDialog.SetCancelMsg(_CancelMessage, null);
                }
            }
        }

        private string _Line1 = string.Empty;
        public string Line1
        {
            get
            {
                return _Line1;
            }
            set
            {
                _Line1 = value;
                if (_ProgressDialog != null)
                {
                    _ProgressDialog.SetLine(1, _Line1, false, IntPtr.Zero);
                }
            }
        }

        private string _Line2 = string.Empty;
        public string Line2
        {
            get
            {
                return _Line2;
            }
            set
            {
                _Line2 = value;
                if (_ProgressDialog != null)
                {
                    _ProgressDialog.SetLine(2, _Line2, false, IntPtr.Zero);
                }
            }
        }

        private string _Line3 = string.Empty;
        public string Line3
        {
            get
            {
                return _Line3;
            }
            set
            {
                _Line3 = value;
                if (_ProgressDialog != null)
                {
                    _ProgressDialog.SetLine(3, _Line3, false, IntPtr.Zero);
                }
            }
        }

        private uint _Progress = 0;
        
        public uint Progress
        {
            get
            {
                return _Progress;
            }
            set
            {
                _Progress = value;
                if (_ProgressDialog != null)
                {
                    _ProgressDialog.SetProgress(_Progress, _MaxProgress);
                }
            }
        }

        private uint _MaxProgress = 100;
       
        public uint MaxProgress
        {
            get
            {
                return _MaxProgress;
            }
            set
            {
                _MaxProgress = value;
                if (_ProgressDialog != null)
                {
                    _ProgressDialog.SetProgress(_Progress, _MaxProgress);
                }
            }
        }

        public bool IsCancelled
        {
            get
            {
                if (_ProgressDialog != null)
                {
                    return _ProgressDialog.HasUserCancelled();
                }
                else
                    return false;
            }
        }

        public ProgressDialog()
        {
        }

        public void Close()
        {
            if (_ProgressDialog != null)
            {
                _ProgressDialog.StopProgressDialog();
                _ProgressDialog = null;
            }
        }

        
        public void ShowDialog(IWin32Window Parent,DialogFlags flags)
        {
            if (_ProgressDialog == null)
            {
                _ProgressDialog = (IProgressDialog)new ProgressDialogClass();

                _ProgressDialog.SetTitle(this._Title);
                _ProgressDialog.SetCancelMsg(this._CancelMessage, null);
                _ProgressDialog.SetLine(1, this._Line1, false, IntPtr.Zero);
                _ProgressDialog.SetLine(2, this._Line2, false, IntPtr.Zero);
                _ProgressDialog.SetLine(3, this._Line3, false, IntPtr.Zero);                

                _ProgressDialog.StartProgressDialog(Parent.Handle, null,flags, IntPtr.Zero);
            }
        }


        #region IDisposable Members

        public void Dispose()
        {
            if (_ProgressDialog != null)
            {
                _ProgressDialog.StopProgressDialog();
            }
        }

        #endregion
    }
}
