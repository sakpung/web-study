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
using Leadtools.Dicom.Common.DataTypes;

namespace DicomDemo
{
    public partial class DicomEditor : Form
    {       
        private List<long> _Excluded = new List<long>();
        private DicomDataSet _Dataset;
        private DicomEditableObject _EditableDicom = new DicomEditableObject();
        private Action<BeforeAddElementEventArgs> OnCheckProperty;

        private object _Data;

        public object Data
        {
            get { return _Data; }           
        }

        private long _DefaultTag = -1;

        public long DefaultTag
        {
            get { return _DefaultTag; }
            set { _DefaultTag = value; }
        }

        public DicomEditor(List<long> excluded)
        {
            InitializeComponent();            
            _Excluded.AddRange(excluded);            
        }        

        void OnBeforeElementAdd(object sender, BeforeAddElementEventArgs e)
        {
            if (OnCheckProperty != null)
            {
                OnCheckProperty(e);
            }
        }

        public DialogResult Edit<T>(IWin32Window owner, ref T Data, Action<BeforeAddElementEventArgs> checkDelegate)
        {
            DialogResult result;

            OnCheckProperty = checkDelegate;
            _EditableDicom.BeforeAddElement += new EventHandler<BeforeAddElementEventArgs>(OnBeforeElementAdd);
            _Data = Data;
            result =  ShowDialog(owner);
            if (result == DialogResult)
                Data = (T)_Data;
            return result;
        }

        private void DicomEditor_Load(object sender, EventArgs e)
        {                        
            _Dataset = new DicomDataSet();
            _Dataset.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ExplicitVRLittleEndian);
            _Dataset.Set(new BeforeAddTagDelegate(OnBeforeAdd), _Data);
            _EditableDicom.DefaultTag = _DefaultTag;
            _EditableDicom.DataSet = _Dataset;
            propertyGridDataset.SelectedObject = _EditableDicom;
        }

        private bool OnBeforeAdd(LinkedList<long> parent, object data, long tag)
        {
            //if (tag == DicomTag.CodeValue)
            //    System.Diagnostics.Debugger.Break();
            return _Excluded.Contains(tag);
        }

        private void DicomEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _Data = Activator.CreateInstance(_Data.GetType());
                _EditableDicom.DataSet.Get(_Data);
            }
        }
    }
}
