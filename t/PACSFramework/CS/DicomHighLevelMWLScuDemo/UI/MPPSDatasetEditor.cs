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
using System.Reflection;
using Leadtools.Dicom.Common.DataTypes.Modality;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;

namespace DicomDemo
{
    public partial class MPPSDatasetEditor : Form
    {
        private List<long> _ExcludeList = new List<long>();

        public List<long> ExcludeList
        {
            get { return _ExcludeList; }
            set { _ExcludeList = value; }
        }

        // constants used to hide a checkbox
        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam,IntPtr lParam);

        // struct used to set node properties
        public struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public String lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        private void RemoveNodeCheckBox(TreeNode node)
        {
            TVITEM tvi = new TVITEM();
            IntPtr lparam = IntPtr.Zero;

            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            lparam = Marshal.AllocHGlobal(Marshal.SizeOf(tvi));
            Marshal.StructureToPtr(tvi, lparam, false);
            SendMessage(treeViewDataset.Handle, TVM_SETITEM, IntPtr.Zero, lparam);
        }

        public MPPSDatasetEditor()
        {
            InitializeComponent();
        }

        private void MPPSDatasetEditor_Load(object sender, EventArgs e)
        {
            LoadTree();
        }

        private void LoadTree()
        {
            Type type = typeof(ModalityPerformedProcedureStep);
            TreeNode node = new TreeNode("Modality Performed Procedure Step");
            ModalityPerformedProcedureStep mpps = new ModalityPerformedProcedureStep();

            mpps.ScheduledStepAttributeSequence.Add(new ScheduledStepAttribute());
            mpps.ScheduledStepAttributeSequence[0].RequestedProcedureCodeSequence.Add(new CodeSequence());            
            BuildNode(mpps, type, ref node);
            treeViewDataset.Nodes.Add(node);
            treeViewDataset.ExpandAll();
            RemoveNodeCheckBox(node);
            BuildDataSet();
        }

        private void BuildNode(object data, Type t1, ref TreeNode parentNode)
        {
            string currentElement = string.Empty;

            try
            {
                TreeNode childMain = null;
                TreeNode childProp = null;
                object value = null;

                if (data == null)
                    return;

                PropertyInfo[] props = t1.GetProperties();

                foreach (PropertyInfo prop in props)
                {
                    ElementAttribute[] attribs = prop.GetCustomAttributes(typeof(ElementAttribute), false) as ElementAttribute[];
                    DicomTag tag;
                    DicomVRType vr = DicomVRType.UN;

                    if (attribs == null || attribs.Length == 0)
                        continue;

                    tag = DicomTagTable.Instance.Find(attribs[0].Tag);
                    if (tag != null)
                        vr = tag.VR;

                    if ((attribs[0].Requirement == DicomIodUsageType.Type1MandatoryElement || attribs[0].Requirement == DicomIodUsageType.Type2MandatoryElement) && vr != DicomVRType.SQ)
                        continue;

                    if (!prop.Name.StartsWith("ExtensionData"))
                    {
                        // For exceptions
                        currentElement = GetName(t1) + "." + prop.Name;
                        // Property value
                        value = prop.GetValue(data, null);
                        if (prop.Name.EndsWith("PrimaryID"))
                            parentNode.Text += string.Format(" - [{0}]", value);
                        if (IsGenericType(typeof(List<>), prop.PropertyType))
                        {
                            IList list = (IList)prop.GetValue(data, null);

                            if (list != null)
                            {
                                foreach (object child in list)
                                {
                                    childMain = new TreeNode(string.Format("{0}", prop.Name));
                                    CheckNode(childMain, attribs[0]);
                                    childMain.Tag = attribs[0];
                                    if (attribs[0].Requirement == DicomIodUsageType.Type1MandatoryElement ||
                                       attribs[0].Requirement == DicomIodUsageType.Type2MandatoryElement)
                                    {
                                        childMain.ForeColor = Color.Red;
                                    }

                                    BuildNode(child, child.GetType(), ref childMain);
                                    parentNode.Nodes.Add(childMain);
                                }
                            }
                        }
                        else if (prop.PropertyType.IsClass && prop.PropertyType != typeof(String) && prop.PropertyType != typeof(PersonName))
                        {
                            object child_object;

                            childMain = new TreeNode(prop.Name);
                            childMain.Tag = attribs[0];
                            CheckNode(childMain, attribs[0]);
                            child_object = Convert.ChangeType(value, prop.PropertyType);
                            BuildNode(child_object, prop.PropertyType, ref childMain);
                            parentNode.Nodes.Add(childMain);
                        }
                        else
                        {
                            childProp = new TreeNode(prop.Name);
                            childProp.Tag = attribs[0];
                            CheckNode(childProp, attribs[0]);
                            if (attribs[0].Requirement == DicomIodUsageType.Type1MandatoryElement ||
                                attribs[0].Requirement == DicomIodUsageType.Type2MandatoryElement)
                            {
                                childProp.ForeColor = Color.Red;
                            }
                            parentNode.Nodes.Add(childProp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(currentElement, ex);
            }
        }

        private string GetName(Type t)
        {
            string result = t.ToString();
            if (result.Contains("."))
                result = result.Substring(result.LastIndexOf(".") + 1);
            if (result.EndsWith("[]"))
                result = result.Substring(0, result.Length - 2);
            return result;
        }

        private bool IsGenericType(Type genericType, Type type)
        {
            while (type != null)
            {
                if (type.IsGenericType &&
                    type.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
                type = type.BaseType;
            }
            return false;
        }

        private void CheckNode(TreeNode node, ElementAttribute attrib)
        {
            node.Checked = attrib.Requirement == DicomIodUsageType.Type1MandatoryElement ||
                           attrib.Requirement == DicomIodUsageType.Type2MandatoryElement ||
                           !_ExcludeList.Contains(attrib.Tag);

        }

        private void treeViewDataset_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            ElementAttribute attrib = e.Node.Tag as ElementAttribute;

            if (attrib != null)
            {
                if (attrib.Requirement == DicomIodUsageType.Type1MandatoryElement || attrib.Requirement == DicomIodUsageType.Type2MandatoryElement)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (e.Node.ForeColor == SystemColors.InactiveCaption)
            {
                e.Cancel = true;
                return;
            }
            EnableChildNodes(e.Node, !e.Node.Checked);
        }

        public void EnableChildNodes(TreeNode parent, bool enable)
        {
            if (parent.Nodes.Count > 0)
            {
                foreach (TreeNode node in parent.Nodes)
                {
                    if (!enable)
                        node.ForeColor = SystemColors.InactiveCaption;
                    else
                        node.ForeColor = SystemColors.WindowText;

                    EnableChildNodes(node, enable);
                }
            }
        }

        private bool OnBeforeAdd(LinkedList<long> parent, object data, long tag)
        {
            return _ExcludeList.Contains(tag);
        }

        private void BuildDataSet()
        {
            using (DicomDataSet ds = new DicomDataSet())
            {
                ModalityPerformedProcedureStep mpps = new ModalityPerformedProcedureStep();                
                
                ds.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ExplicitVRLittleEndian);
                ds.Set(new BeforeAddTagDelegate(OnBeforeAdd), mpps);

                treeViewMPPSDataset.BeginUpdate();
                treeViewMPPSDataset.Nodes.Clear();
                try
                {
                    FillTree(ds);
                }
                finally
                {
                    treeViewMPPSDataset.EndUpdate();
                }
            }
        }

        private void FillTree(DicomDataSet ds)
        {
            DicomElement element;

            element = ds.GetFirstElement(null, false, true);
            if (element == null)
            {
                string err = string.Format("Error reading dicom dataset!");

                MessageBox.Show(err, "Error");
                return;
            }

            FillSubTree(ds,element, null);
        }

        void FillSubTree(DicomDataSet ds,DicomElement element, TreeNode ParentNode)
        {
            TreeNode node;
            string name;
            string temp = "";
            DicomTag tag;
            DicomElement tempElement;

            tag = DicomTagTable.Instance.Find(element.Tag);
            if (tag != null)
            {
                name = tag.Name;
            }
            else
                name = "Item";

            long tagValue = 0;

            tagValue = element.Tag;
            temp = string.Format("{0:x4}:{1:x4} - ", tagValue.GetGroup(), tagValue.GetElement());
            temp = temp + name;

            if (ParentNode != null)
            {
                node = ParentNode.Nodes.Add(temp);
            }
            else
            {
                node = treeViewMPPSDataset.Nodes.Add(temp);
            }

            node.Tag = element.Tag;

            if (ds.IsVolatileElement(element))
            {
                node.ForeColor = Color.Red;
            }

            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;

            tempElement = ds.GetChildElement(element, true);
            if (tempElement != null)
            {
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                FillSubTree(ds,tempElement, node);
            }


            tempElement = ds.GetNextElement(element, true, true);
            if (tempElement != null)
            {
                FillSubTree(ds,tempElement, ParentNode);
            }
            else
            {
                element = ds.GetParentElement(element);
            }
        }

        private TreeNode FindDatasetTag(TreeNodeCollection nodes, long tag)
        {

            foreach (TreeNode node in nodes)
            {
                if (node.Tag != null)
                {
                    long dsTag = (long)node.Tag;

                    if (dsTag == tag)
                        return node;
                }

                TreeNode candidate = FindDatasetTag(node.Nodes, tag);

                if (candidate != null)
                    return candidate;
            }

            return null;
        }

        private void treeViewDataset_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ElementAttribute attrib = e.Node.Tag as ElementAttribute;

            if (e.Node.Checked)
            {
                if (_ExcludeList.Contains(attrib.Tag))
                    _ExcludeList.Remove(attrib.Tag);
            }
            else
            {
                _ExcludeList.Add(attrib.Tag);
            }
            BuildDataSet();
            SelectMPPSDatasetNode(e.Node);
        }

        private void SelectMPPSDatasetNode(TreeNode node)
        {
            if (node.IsSelected)
            {
                ElementAttribute attrib = node.Tag as ElementAttribute;

                if (attrib != null)
                {
                    TreeNode datasetNode = FindDatasetTag(treeViewMPPSDataset.Nodes, attrib.Tag);

                    if (datasetNode != null)
                    {
                        treeViewMPPSDataset.SelectedNode = datasetNode;
                        datasetNode.EnsureVisible();
                    }
                }
            }
        }

        private void treeViewDataset_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectMPPSDatasetNode(e.Node);
        }
    }
}
