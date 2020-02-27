// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using System.Reflection;

namespace Leadtools.Annotations.WinForms
{
   public class CustomPropertyDescriptor : PropertyDescriptor
   {
      Type _type;
      string _category;
      PropertyInfo _info;
      object _instance;
      string _displayName;
      TypeConverter _converter;

      public CustomPropertyDescriptor(PropertyInfo info, object instance, string displayName, string category)
         : base(info.Name, null)
      {
         _type = info.PropertyType;
         _info = info;
         _category = category;
         _instance = instance;
         _displayName = displayName;

         _converter = null;
      }

      public CustomPropertyDescriptor(PropertyInfo info, object instance, string displayName, string category, Attribute[] attributes, Type typeOfConverter)
         : base(info.Name, attributes)
      {
         _type = info.PropertyType;
         _info = info;
         _category = category;
         _instance = instance;
         _displayName = displayName;

         _converter = (TypeConverter)Activator.CreateInstance(typeOfConverter);
      }

      public CustomPropertyDescriptor(string displayName, string value, string category)
         : base(displayName, null)
      {
         _category = category;
         _defaultValue = value;
         _resetValue = false;
         _type = typeof(string);
         _displayName = displayName;
      }

      public CustomPropertyDescriptor(PropertyInfo info, object instance, string displayName, string category, Attribute[] attributes, Type typeOfConverter, object defaultValue)
         : base(info.Name, attributes)
      {
         _type = info.PropertyType;
         _info = info;
         _category = category;
         _instance = instance;
         _displayName = displayName;
         _defaultValue = defaultValue;
         _resetValue = true;

         if (typeOfConverter != null)
            _converter = (TypeConverter)Activator.CreateInstance(typeOfConverter, _defaultValue);
      }

      public override bool ShouldSerializeValue(object component)
      {
         return false;
      }

      public override void SetValue(object component, object value)
      {
         if (_info != null)
         {
            if (_converter != null)
            {
               _info.SetValue(_instance, _converter.ConvertTo(value, _type), null);
            }
            else
            {
               _info.SetValue(_instance, value, null);
            }
         }
      }

      public override object GetValue(object component)
      {
         if (_info != null)
         {
            if (_converter != null)
            {
               return _converter.ConvertFrom(_info.GetValue(_instance, null));
            }
            else
            {
               return _info.GetValue(_instance, null);
            }
         }
         else
            return _defaultValue;
      }

      private bool _resetValue = false;

      private object _defaultValue;

      public object DefaultValue
      {
         get { return _defaultValue; }
         set { _defaultValue = value; }
      }

      public override bool CanResetValue(object component)
      {
         return _resetValue;
      }

      public override bool IsReadOnly
      {
         get
         {
            bool readOnly = true;
            if (_info != null)
               readOnly = !_info.CanWrite;

            return readOnly;
         }
      }

      public override void ResetValue(object component)
      {
         _info.SetValue(_instance, _defaultValue, null);
      }

      public override Type PropertyType
      {
         get { return _type; }
      }

      public override Type ComponentType
      {
         get { return _type; }
      }

      public override string Category
      {
         get
         {
            return _category;
         }
      }

      public override string DisplayName
      {
         get
         {
            return _displayName;
         }
      }
   }
}
