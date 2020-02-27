// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

using Leadtools.Medical3D;

namespace Main3DDemo
{
    public partial class CheckUtilityDialog : Form
    {
        public CheckUtilityDialog(Form parent)
        {
            InitializeComponent();

            Cursor oldCursor = null;
            if (parent != null)
            {
               oldCursor = parent.Cursor;
               parent.Cursor = Cursors.WaitCursor;
            }

            _lblDirectXVersion.Text = Medical3DEngine.DirectXVersion.ToString();
            _lblDirectXVersionAvailable.Checked = Medical3DEngine.IsValidDirectXVersion ;
            _lblVertexShaderAvailable.Checked = Medical3DEngine.VertexShaderAvailable ;
            _lblPixelShaderAvailable.Checked = Medical3DEngine.PixelShaderAvailable;
            _lblDedicatedGPU.Text = Medical3DEngine.DedicatedGPUMemorySize.ToString();
            _lblSharedGPU.Text = Medical3DEngine.SharedGPUMemorySize.ToString();
            _lblMaximum2D.Text = Medical3DEngine.Maximum2DTextureDimension.ToString();
            _lblMaximum3D.Text = Medical3DEngine.Maximum3DTextureDimension.ToString();
            _lblHardwareShaderAvailable.Checked = Medical3DEngine.HardwareShaderAvailable;
            _lblTexturing.Checked = Medical3DEngine.TexturingAvailable;
            _lblBackBuffer.Checked = Medical3DEngine.TexturingBackBufferAvailable;
            _lblBlending.Checked = Medical3DEngine.BlendingAvailable;
            _lblDepthOperation.Checked = Medical3DEngine.ZOperationAvailable;

            _lblDirectXVersionSuccess.Checked = Medical3DEngine.IsValidDirectXVersion;
            _lblPixelShaderSuccess.Checked = Medical3DEngine.PixelShaderAvailable;
            _lblVertexShaderSuccess.Checked = Medical3DEngine.VertexShaderAvailable;


           if (parent != null)
              parent.Cursor = oldCursor;
        }
    }

    public class CheckLabel : Label
    {
        bool _isChecked = false;

        public bool Checked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            if (_isChecked)
            {
                e.Graphics.FillRectangle(Brushes.LightGreen, this.ClientRectangle);
                e.Graphics.DrawString("Yes", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(Width / 2, Height / 2), stringFormat);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Red, this.ClientRectangle);
                e.Graphics.DrawString("NO", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(Width / 2, Height / 2), stringFormat);
            }

            base.OnPaint(e);
        }
    }

}
