// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Leadtools.Demos
{
    public class LoginHeaderPanel : Panel
    {
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            using (LinearGradientBrush brush = new LinearGradientBrush(Bounds, Color.LightBlue, Color.Blue, LinearGradientMode.Horizontal))
            {
                pevent.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }
    }
}
