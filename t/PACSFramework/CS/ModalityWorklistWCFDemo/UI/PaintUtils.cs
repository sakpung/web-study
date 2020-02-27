// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ModalityWorklistWCFDemo.UI
{
    public static class PaintUtils
    {
        public static void HighlightRequiredFields(Control container, Graphics graphics, Boolean isVisible, Color highlight)
        {
            Rectangle rect = default(Rectangle);
            foreach (Control control in container.Controls)
            {
                if (control.Tag is string && control.Tag.ToString().ToLower() == "required")
                {
                    rect = control.Bounds;
                    rect.Inflate(1, 1);
                    if (isVisible)
                    {
                        ControlPaint.DrawBorder(graphics, rect, highlight, ButtonBorderStyle.Solid);
                    }
                    else
                    {
                        ControlPaint.DrawBorder(graphics, rect, container.BackColor, ButtonBorderStyle.None);
                    }
                }

                if (control.HasChildren)
                {
                    foreach (Control ctrl in control.Controls)
                    {
                        HighlightRequiredFields(ctrl, graphics, isVisible, highlight);
                    }
                }
            }

        }
    }
}
