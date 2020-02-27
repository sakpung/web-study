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

namespace GrayScaleDemo
{
    public partial class AnisotropicDiffusionDialog : Form
    {
        private static int _iterations;
        private static int _smoothing ;
        private static float _timeStep;
        private static float _minVariation ;
        private static float _maxVariation;
        private static float _edgeHeight ;
        private static int _update ;

        public int Iterations;
        public int Smoothing;
        public float TimeStep;
        public float MinVariation;
        public float MaxVariation;
        public float EdgeHeight;
        public int nUpdate;

        public AnisotropicDiffusionDialog()
        {
            InitializeComponent();
        }

        private void AnisotropicDiffusionDialog_Load(object sender, EventArgs e)
        {
             AnisotropicDiffusionCommand cmd = new AnisotropicDiffusionCommand();
             _iterations = cmd.Iterations;
             _smoothing = cmd.Smoothing;
             _timeStep = cmd.TimeStep;
             _minVariation = cmd.MinVariation;
             _maxVariation = cmd.MaxVariation;
             _edgeHeight = cmd.EdgeHeight;
             _update = cmd.Update;

            try
            {
                Iterations = _iterations;
                Smoothing = _smoothing;
                TimeStep = _timeStep  *100;
                MinVariation = _minVariation*100;
                MaxVariation = _maxVariation*100;
                EdgeHeight = _edgeHeight*100;
                nUpdate = _update;

                _numIterations.Value = Iterations;
                _numSmoothing.Value = Smoothing;
                _numTimeStep.Value = (decimal)TimeStep;
                _numMinVariation.Value = (decimal)MinVariation;
                _numMaxVariation.Value = (decimal)MaxVariation;
                _numEdgeHeight.Value = (decimal)EdgeHeight;
                _numUpdate.Value = nUpdate;
            }
            catch (Exception /*ex*/)
            {
            }
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Iterations = (int)_numIterations.Value  ;
            Smoothing = (int)_numSmoothing.Value ;
            TimeStep = (float)_numTimeStep.Value / 100;
            MinVariation = (float)_numMinVariation.Value / 100;
            MaxVariation = (float)_numMaxVariation.Value / 100;
            EdgeHeight = (float)_numEdgeHeight.Value / 100;
            nUpdate = (int)_numUpdate.Value;

            _iterations = Iterations;
            _smoothing = Smoothing;
            _timeStep = TimeStep ;
            _minVariation = MinVariation;
            _maxVariation = MaxVariation;
            _edgeHeight = EdgeHeight;
            _update = nUpdate;
        }

        private void _numIterations_ValueChanged(object sender, EventArgs e)
        {
            if (_numUpdate.Value > _numIterations.Value)
                _numUpdate.Value = _numIterations.Value;

            _numUpdate.Maximum = _numIterations.Value;
        }


    }
}
