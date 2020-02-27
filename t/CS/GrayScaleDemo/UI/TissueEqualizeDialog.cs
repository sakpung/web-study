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

using Leadtools.ImageProcessing.Core;
using Leadtools.Demos;

namespace GrayScaleDemo
{
    public partial class TissueEqualizeDialog : Form
    {
        private static TissueEqualizeCommandFlags _flags;

        public TissueEqualizeCommandFlags Flags
        {
            get { return TissueEqualizeDialog._flags; }
        }

        public TissueEqualizeDialog()
        {
            InitializeComponent();
        }

        private void TissueEqualizeDialog_Load(object sender, EventArgs e)
        {
          TissueEqualizeCommand cmd = new TissueEqualizeCommand();
          _flags = cmd.Flags;

            switch ((int)_flags)
            {
                case 0x00000001:
                    _rbUseSimplifyOption.Checked = true;
                    break;
                case 0x00000002 :
                    _rbUseIntensifyOption.Checked = true;
                    break;
            }
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            if (_rbUseIntensifyOption.Checked )
                _flags = TissueEqualizeCommandFlags.UseIntensifyOption;
            else 
                _flags = TissueEqualizeCommandFlags.UseSimplifyOption;
        }

    }
}
