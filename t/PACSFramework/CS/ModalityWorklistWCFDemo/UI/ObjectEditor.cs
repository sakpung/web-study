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
using ModalityWorklistWCFDemo.Broker;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ModalityWorklistWCFDemo.Properties;
using System.Reflection;
using System.ComponentModel.Design;

namespace ModalityWorklistWCFDemo.UI
{
    public partial class ObjectEditor<T> : Form where T: class
    {        
        private T _EditObject;

        public T EditObject
        {
            get { return _EditObject; }
            set 
            { 
               _EditObject = value;               
            }
        }

        public ObjectEditor(T sequence, string description)
        {
            InitializeComponent();
            _EditObject = Copy(sequence);
            if (_EditObject == null)
                _EditObject = Activator.CreateInstance<T>();            

            propertyGridEditObject.SelectedObject = _EditObject;                       
            Icon = Resources.LvSample;
            labelDescription.Text = description;
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
    }
}
