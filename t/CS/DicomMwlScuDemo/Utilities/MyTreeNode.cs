// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Leadtools.Dicom;

namespace DicomDemo
{
    public class MyTreeNode : TreeNode
    {
        public DicomDataSet m_DS;
        public DicomIod m_DicomIOD;
        public DicomElement m_Element;

        public MyTreeNode(string s) 
            : base(s)
        {
            m_DS = null;
            m_Element = null;
            m_DicomIOD = null;
        }

        public MyTreeNode(string s, DicomDataSet ds)
            : base(s)
        {
            m_DS = ds;
            m_DicomIOD = null;
            m_Element = null;
        }

        public MyTreeNode(string s, DicomDataSet ds, DicomIod dIod)
            : base(s)
        {
            m_DS = ds;
            m_DicomIOD = dIod;
            m_Element = null;
        }

        public MyTreeNode(string s, DicomDataSet ds, DicomElement de)
            : base(s)
        {
            m_DS = ds;
            m_DicomIOD = null;
            m_Element = de;
        }
    }
}
