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
using MPPSWCFDemo.Broker;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MPPSWCFDemo.Properties;
using System.Reflection;
using Leadtools.Demos;

namespace MPPSWCFDemo.UI
{
    public partial class ObjectEditor<T> : Form where T: class
    {
       PropertyInfo _CodeValue;
       PropertyInfo _CodingScheme;

        private T _EditObject;

        public T EditObject
        {
            get { return _EditObject; }
            set 
            { 
               _EditObject = value;
               GetPropertyInfo();
            }
        }

        public ObjectEditor(T sequence, string description)
        {
            InitializeComponent();
            _EditObject = Copy(sequence);
            if (_EditObject == null)
                _EditObject = Activator.CreateInstance<T>();
            GetPropertyInfo();

            propertyGridEditObject.SelectedObject = _EditObject;
            Icon = Resources.LvSample;
            labelDescription.Text = description;
        }

        private void GetPropertyInfo()
        {
           if (_EditObject != null)
           {
              Type type = _EditObject.GetType();

              _CodeValue = type.GetProperty("CodeValue");
              _CodingScheme = type.GetProperty("CodingSchemeDesignator");
           }
        }

        private T Copy(T source)
        {
            if (source == null)
                return null;
            else
            {
                MemoryStream ms = new MemoryStream();
                BinaryFormatter bf = new BinaryFormatter();
                T copy;

                bf.Serialize(ms, source);
                ms.Position = 0;
                copy = bf.Deserialize(ms) as T;
                ms.Close();

                return copy;
            }
        }

        private void propertyGridEditObject_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
           if (e.ChangedItem.PropertyDescriptor.Name == "CodeValue" || e.ChangedItem.PropertyDescriptor.Name == "CodingSchemeDesignator") 
           {
              if(string.IsNullOrEmpty(e.ChangedItem.Value.ToString()))
              {
                 if (e.ChangedItem.PropertyDescriptor.Name == "CodeValue")
                 {
                    Messager.ShowError(this, "Must provide a value for CodeValue.");
                    SetValue(_CodeValue, e.OldValue.ToString());
                 }
                 else
                 {
                    Messager.ShowError(this, "Must provide a value for CodingSchemeDesignator.");
                    SetValue(_CodingScheme, e.OldValue.ToString());
                 }
              }
           }
        }

        private void SetValue(PropertyInfo property, string oldValue)
        {
           if (property != null)
           {
              property.SetValue(propertyGridEditObject.SelectedObject, oldValue, null);
              propertyGridEditObject.Refresh();
           }
        }
    }
}
