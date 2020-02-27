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
using Leadtools.Dicom.Common.Editing;
using Leadtools.Dicom.Common.DataTypes.Modality;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;

namespace DicomDemo
{
    public partial class DicomViewer : Form
    {
        private DicomEditableObject _EditableDicom = new DicomEditableObject();
        private DicomDataSet _Result = null;

        private bool _ModuleView = false;

        public bool ModuleView
        {
            get { return _ModuleView; }
            set 
            {
                if (_ModuleView != value)
                {
                    _ModuleView = value;
                    SetPropertyView();
                }
            }
        }        

        public DicomViewer(DicomDataSet ds)
        {
            InitializeComponent();
            _Result = ds;
            _EditableDicom.BeforeAddElement += new EventHandler<BeforeAddElementEventArgs>(_EditableDicom_BeforeAddElement);
            //_EditableDicom.SetServiceProvider(propertyGridDataset);
        }

        void _EditableDicom_BeforeAddElement(object sender, BeforeAddElementEventArgs e)
        {
            e.Element.Attributes.Add(new ReadOnlyAttribute(true));
        }

        private void DicomViewer_Load(object sender, EventArgs e)
        {
            _EditableDicom.DataSet = _Result;
            propertyGridDataset.SelectedObject = _EditableDicom;
            SetPropertyView();
        }

        private void SetPropertyView()
        {
            propertyGridDataset.PropertySort = _ModuleView == true ? PropertySort.Categorized : PropertySort.NoSort;
        }
    }
}
