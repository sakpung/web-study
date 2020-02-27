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

using Leadtools.Demos;
using Leadtools.MedicalViewer;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing;

namespace MedicalViewerDemo
{
    public partial class ModifyStent : Form
    {
        private MedicalViewerMultiCell _cell;
        private bool[] _frameEnabled;
        private MainForm _form;
        private bool _firstTime;

        public ModifyStent(MedicalViewerMultiCell cell, StentEnhancementCommand stentCommand, MainForm form)
        {
            _firstTime = true;
            _cell = (MedicalViewerMultiCell) cell;
            _form = form;

            _frameEnabled = _form.FrameEnabled;

            
            InitializeComponent();
        }

        private void ModifyStent_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= _cell.Image.PageCount; i++)
                _cbFrames.Items.Add("Frame " + i.ToString(), _frameEnabled[i-1]);
        }

        private void _cbFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            _firstTime = false;
            _cell.ActiveSubCell = _cbFrames.SelectedIndex;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _cbFrames_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if(!_firstTime)
            {

                if(_form.StentCommand != null)
                {
                    if (!(e.CurrentValue == CheckState.Checked))
                    {
                        _form.StentCommand.SelectFrame(_cell.Image, e.Index);
                    }
                    else
                    {
                        _form.StentCommand.UnSelectFrame(_cell.Image, e.Index);

                    }

                    _form.ApplyEnhancements(_form.StentCommand.EnhancedImage);
                    _cell.Invalidate();
                }

            }

        }

        private void ModifyStent_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form._modifyStentDlg = null;
            _cell = null;
            _frameEnabled = null;
            _form = null;
            _firstTime = true;
        }
    }
}
