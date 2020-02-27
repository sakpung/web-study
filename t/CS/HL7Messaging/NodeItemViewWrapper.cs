// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml;
using Leadtools.Medical.HL7.V2x.Models;

namespace HL7Messaging
{
   [TypeConverter(typeof(NodeItemViewWrapperConverter))]
   class NodeItemViewWrapper
   {
      private readonly NodeItemView node;
      public NodeItemViewWrapper(NodeItemView node) { this.node = node; }
      class NodeItemViewWrapperConverter : ExpandableObjectConverter
      {
         public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
         {
            List<PropertyDescriptor> props = new List<PropertyDescriptor>();
            
            foreach (NodeItemView child in ((NodeItemViewWrapper)value).node)
            {
               props.Add(new NodeItemViewWrapperPropertyDescriptor(child));
            }
            return new PropertyDescriptorCollection(props.ToArray(), true);
         }
         public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
         {
            return destinationType == typeof(string)
                ? ((NodeItemViewWrapper)value).node.Value
                : base.ConvertTo(context, culture, value, destinationType);
         }
      }
      class NodeItemViewWrapperPropertyDescriptor : PropertyDescriptor
      {
         private static readonly Attribute[] nix = new Attribute[0];
         private readonly NodeItemView node;
         public NodeItemViewWrapperPropertyDescriptor(NodeItemView node)
            : base(GetName(node), nix)
         {
            this.node = node;
         }
         static string GetName(NodeItemView node)
         {
            return node.Name;           
         }
         public override bool ShouldSerializeValue(object component)
         {
            return false;
         }
         public override void SetValue(object component, object value)
         {
            //update model-view
            node.Value = (string)value;

            //also the model
            IField f = (IField)node.Tag;
            if (null != f)
            {
               f.Value = (string)value;
               ((MessageModel)node.Model).FireChanged();
            }            
         }
         protected override void OnValueChanged(Object component, EventArgs e)
         {
            base.OnValueChanged(component, e);
         }
         public override bool CanResetValue(object component)
         {
            return !IsReadOnly;
         }
         public override void ResetValue(object component)
         {
            SetValue(component, "");
         }
         public override Type PropertyType
         {
            get
            {
               if (node.NodeType=="field")
               {
                  return typeof(string);
               }
               else
               {
                  return typeof(NodeItemViewWrapper);
               }
            }
         }
         public override bool IsReadOnly
         {
            get
            {
               return false;
            }
         }
         public override object GetValue(object component)
         {
            if (node.NodeType=="field")
            {
               return node.Value;
            }
            else
            {
               return new NodeItemViewWrapper(node);
            }
         }
         public override Type ComponentType
         {
            get { return typeof(NodeItemViewWrapper); }
         }
      }
   }
}
