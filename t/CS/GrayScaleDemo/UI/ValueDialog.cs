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

namespace GrayScaleDemo
{
    public partial class ValueDialog : Form
    {
        private int _value;
        private TypeConstants _type;
        
        public int Value
        {
            get { return _value; }
        }

        public ValueDialog(TypeConstants type)
        {
            InitializeComponent();
            _type = type;
        }

        public enum TypeConstants
        {
            AddColorToRegion,
            Average,
            Maximum,
            Minimum,
            Median,
            Sharpen,
            Gaussian,
            Contrast,
            Brightness,
            Saturation,
            AutoCrop,
            FastMagicWand
        }

        private struct TypeProp
        {
            public TypeConstants Type;
            public string CaptionName;
            public string ValueName;
            public int InitialValue;
            public int Min;
            public int Max;

            public TypeProp(TypeConstants type, string captionName, string valueName, int initialValue, int min, int max)
            {
                Type = type;
                CaptionName = captionName;
                ValueName = valueName;
                InitialValue = initialValue;
                Min = min;
                Max = max;
            }
        }
        
        private static TypeProp[] _typeProp = new TypeProp[]
        {
         new TypeProp(TypeConstants.AddColorToRegion,"Add Color To Region","Color level",0,0,255),
         new TypeProp(TypeConstants.Average,"Average","Dimension",3,3,255),
         new TypeProp(TypeConstants.Maximum,"Maximum","Sample Size",1,1,32),
         new TypeProp(TypeConstants.Minimum,"Minimum","Sample Size",1,1,32),
         new TypeProp(TypeConstants.Median,"Median","Dimension",2,2,64),
         new TypeProp(TypeConstants.Sharpen,"Sharpen","Sharpness",0,-100,100),
         new TypeProp(TypeConstants.Gaussian,"Gaussian","Radius",1,1,1000),
         new TypeProp(TypeConstants.Contrast,"Contrast","Contrast",0,-1000,1000),
         new TypeProp(TypeConstants.Brightness,"Brightness","Brightness",0,-1000,1000),
         new TypeProp(TypeConstants.Saturation,"Saturation","Change",0,-500,500),
         new TypeProp(TypeConstants.AutoCrop,"Auto Crop","Threshold ",0,0,255),
         new TypeProp(TypeConstants.FastMagicWand,"Fast Magic Wand","Tolerance ",0,0,255),
         new TypeProp(TypeConstants.FastMagicWand,"Border Color level","Border ",0,0,255),
      };

        private void ValueDialog_Load(object sender, EventArgs e)
        {
            TypeProp prop = _typeProp[(int)_type];
            Text = prop.CaptionName;
            _gbOptions.Text = prop.ValueName;
            _numValue.Minimum = prop.Min;
            _numValue.Maximum = prop.Max;
            _numValue.Value = prop.InitialValue;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _value = (int)_numValue.Value;
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
