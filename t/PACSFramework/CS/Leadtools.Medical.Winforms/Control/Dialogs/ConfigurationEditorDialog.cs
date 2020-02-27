// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using Leadtools.Dicom;
using Leadtools.Demos;

namespace Leadtools.Medical.Winforms
{
   public partial class ConfigurationEditorDialog : Form
   {
      private bool _Edit = false;
      private DicomDataSet _Dataset = new DicomDataSet();
      long _PreviousCode = -1;

      private string _ConfigurationName;

      public string ConfigurationName
        {
            get { return _ConfigurationName; }
            set { _ConfigurationName = value; }
        }

      private string _DicomTag;

        public string DicomTag
        {
            get { return _DicomTag; }
            set { _DicomTag = value; }
        }

        private object _TagValue;

        public object TagValue
        {
            get { return _TagValue; }
            set { _TagValue = value; }
        }       

         public bool ApplyCondition
         {
            get 
            {
               return ConditionCheckBox.Checked ;
            }
            set
            {
               ConditionCheckBox.Checked = value ;
            }
         }
         
        public ConfigurationEditorDialog ( bool edit )
        {
            InitializeComponent();
            _Edit = edit;
            
            groupBoxBasedOn.Enabled = ConditionCheckBox.Checked ;
            
            Application.Idle += new EventHandler(Application_Idle);
            
            ConditionCheckBox.CheckedChanged += new EventHandler(ConditionCheckBox_CheckedChanged);
        }

        void ConditionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           groupBoxBasedOn.Enabled = ConditionCheckBox.Checked ;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            buttonOK.Enabled = textBoxName.Text.Length > 0 &&
                               ( ( ApplyCondition && comboBoxTags.Text.Length > 0 ) || ! ApplyCondition );
                               
        }

      private void ConfigurationEditorDialog_Load ( object sender, EventArgs e )
      {
         if ( _Edit )
         {
            textBoxName.Text  = _ConfigurationName ;
            comboBoxTags.Text = _DicomTag ;
             
            Text = "Edit Configuration";
             
            if ( ApplyCondition && comboBoxTags.Text.Length > 0 )
            {
               BuildDataSet ( ) ;
            }
         }
         else
         {
            Text = "Add Configuration" ;
         }
         
         LoadTagConstants();
      }

        private void LoadTagConstants()
        {
            comboBoxTags.Items.AddRange(OrientationConfigDialog.Tags.Values.ToArray());
        }

      private void ConfigurationEditorDialog_FormClosing ( object sender, FormClosingEventArgs e )
      {
         try
         {
            if ( DialogResult == DialogResult.OK )
            {
               _ConfigurationName = textBoxName.Text ;
               _DicomTag          = comboBoxTags.Text ;
            }
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void dicomPropertyGrid_BeforeAddElement(object sender, Leadtools.Dicom.Common.Editing.BeforeAddElementEventArgs e)
      {
         try
         {
            e.Element.Attributes.Add ( new DisplayNameAttribute ( "Value" ) ) ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void dicomPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
      {
         try
         {
            _TagValue = e.ChangedItem.Value;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void BuildDataSet ( )
      {
         long     code = -1;
         DicomTag tag = null;
         DicomElement element = null;
         element = _Dataset.FindFirstElement(null, _PreviousCode, false);

         
         code = OrientationConfigDialog.GetTag(comboBoxTags.Text);
         
         if ( code == -1 )
         {
             _Dataset.Reset ( ) ;
             
             dicomPropertyGrid.DataSet = _Dataset;
             
             MessageBox.Show("Invalid Tag", "Error with tag", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
             comboBoxTags.Focus ( ) ;
         }
         else
         {
            if ( element != null && element.Tag != code )
            {
               _TagValue = null;
            }

            _PreviousCode = code;
            
            tag = DicomTagTable.Instance.Find(code);
            
            _Dataset.Reset();
            
            if (_TagValue != null)
            {
                _Dataset.InsertElementAndSetValue(code, _TagValue);
            }
            else
            {
               _Dataset.InsertElement(null, false, code, tag != null ? tag.VR : DicomVRType.UN, tag != null && tag.VR == DicomVRType.SQ, -1);
            }
            
            dicomPropertyGrid.DataSet = _Dataset;
         }
      }

      private void comboBoxTags_Leave(object sender, EventArgs e)
      {
         try
         {
            if ( comboBoxTags.Text.Length > 0 )
            {                
                BuildDataSet();
            }
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }
   }
}
