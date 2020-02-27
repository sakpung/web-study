// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Leadtools;

namespace GrayScaleDemo
{
    public class ViewerImages
    {
        private string _imageName;
        private int _childFormId;
        private RasterImage _image;

        public RasterImage Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        public int ChildFormId
        {
            get { return _childFormId; }
            set { _childFormId = value; }
        }

        public ViewerImages(string name,int id,RasterImage image)
        {
            _imageName = name;
            _childFormId = id;
            _image = image;
        }

    }

}





    
