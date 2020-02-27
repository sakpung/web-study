// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace RasterizeDocumentDemo.Tools
{
   // Used as an item for listbox and combobox controls
   class ValueNameItem<T>
   {
      private T _value;

      // The item value
      public T Value
      {
         get { return _value; }
         set { _value = value; }
      }

      // The item name
      private string _name;

      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      public ValueNameItem(T value, string name)
      {
         _value = value;
         _name = name;
      }

      public override string ToString()
      {
         return _name;
      }

      // Return the selected item from a list
      public static object SelectItem(T value, System.Collections.IEnumerable items)
      {
         foreach(ValueNameItem<T> item in items)
         {
            if(item.Value.Equals(value))
               return item;
         }

         return null;
      }

      public static T GetSelectedItem(object item)
      {
         return (item as ValueNameItem<T>).Value;
      }
   }
}
