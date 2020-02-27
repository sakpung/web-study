// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DicomDemo
{    
    public class FocusManager
    {
        private List<Control> _Controls = new List<Control>();

        public FocusManager(params Control[] textboxes)
        {
            foreach (Control textbox in textboxes)
            {                
                textbox.KeyDown += new KeyEventHandler(textbox_KeyDown);
                _Controls.Add(textbox);
            }
        }

        void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int index = _Controls.IndexOf(sender as Control);
                bool focused = false;

                while (!focused)
                {
                    Control controlToFocus = (index + 1) == _Controls.Count ? _Controls[0] : _Controls[index + 1];

                    if (controlToFocus.Enabled)
                    {
                        controlToFocus.Focus();
                        break;
                    }

                    index++;
                    if (index == _Controls.Count)
                        index = 0;
                }
            }
        }        
    }
}
