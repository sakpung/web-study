// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;

namespace CCOWClientParticipationDemo.CCOW
{
    public class ContextEventArgs : EventArgs
    {
        private int _ContextCoupon;

        public int ContextCoupon
        {
            get { return _ContextCoupon; }           
        }

        private string _Reason = string.Empty;

        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
            }
        }

        private string _Decision = string.Empty;

        public string Decision
        {
            get
            {
                return _Decision;
            }
            set
            {
                _Decision = value;
            }
        }

        public ContextEventArgs(int contextCoupon)
        {
            _ContextCoupon = contextCoupon;
        }
    }
}
