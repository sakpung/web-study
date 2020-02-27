// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DicomDemo
{
    public class MyListView : ListView
    {       
        private List<ListViewItem> _StartedMPPS = new List<ListViewItem>();

        public List<ListViewItem> StartedMPPS
        {
            get { return _StartedMPPS; }
            set { _StartedMPPS = value; }
        }        
    }
}
