// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;


#region Original Code By
// Stephen Toub
// stoub@microsoft.com
//
// FlaggedEnumEditor.cs
// UITypeEditor for flag enumerations
//
// July 26th, 2002
// v1.0.0
//
// To Use:
// [Editor(typeof(FlaggedEnumEditor), typeof(UITypeEditor))]
// public SomeFlaggedEnum ExampleProperty { get { return _theEnum; } set { _theEnum = value; } }
#endregion

namespace Leadtools.AddIn.Security
{
   public sealed class WrappedEnumAttribute : System.Attribute
   {
      public WrappedEnumAttribute(Type enumType)
      {
         if (enumType.IsEnum)
         {
            this.enumType = enumType;
         }
         else
         {
            throw new ArgumentException("enumType must of a type of enum", "enumType");
         }
      }
      public Type EnumType
      {
         get
         {
            return enumType;
         }
      }
      private Type enumType;
   }


   /// <summary>Editor for flag enumerations.</summary>
   public class FlaggedEnumEditor : UITypeEditor
   {
      #region Construction
      /// <summary>Initialize the editor.</summary>
      public FlaggedEnumEditor() { }
      #endregion

      private bool OneBitSet(int n)
      {
         if (n == 0)
            return false;
         else
            return ((n - 1) & n) == 0;
      }

      #region Editing Values
      /// <summary>Edits the specified object's value using the editor style indicated by GetEditStyle.</summary>
      /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
      /// <param name="provider">An IServiceProvider that this editor can use to obtain services.</param>
      /// <param name="value">The object to edit.</param>
      /// <returns>The new value of the object.</returns>
      public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
      {

         // Make sure the context and the property are valid.
         Boolean propertyValid = false;
         Type t = null;
         Type propType = null;
         Int32 currentValue = -1;

         if (context != null && context.Instance != null && context.PropertyDescriptor != null && provider != null)
         {
            propType = context.PropertyDescriptor.PropertyType;
            // when the property is directly an enum, this is easy
            if (propType.IsEnum)
            {
               t = propType;
               currentValue = (Int32)value;
               propertyValid = true;
               // otherwise it should be a string property wrapping a flagged enum property
               // a developer would do this for asp.net controls, because the asp.net page compiler doesn't support flagged enum values
            }
            else if (propType == typeof(String))
            {
               WrappedEnumAttribute wrappedType = context.PropertyDescriptor.Attributes[typeof(WrappedEnumAttribute)] as WrappedEnumAttribute;
               if (wrappedType != null && wrappedType.EnumType != null && wrappedType.EnumType.IsEnum)
               {
                  t = wrappedType.EnumType;
                  currentValue = (Int32)Enum.Parse(t, value.ToString(), true);
                  propertyValid = true;
               }
            }
         }
         if (propertyValid)
         {
            // Create the listbox for display
            CheckedListBox listBox = new CheckedListBox();
            listBox.CheckOnClick = true;
            // Get the editor used to display the list box
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            // Get all of the names in the enum and use them to populate the listbox.
            foreach (string enumName in (string[])Enum.GetNames(t))
            {
               // We add the enum name, but only check it if it is selected.
               int nValue = (int)Enum.Parse(t, enumName);
               if (nValue != 0)
               {
                  bool isChecked = (currentValue & nValue) == nValue;
                  listBox.Items.Add(enumName, isChecked);
               }
            }
            // Display the list box
            edSvc.DropDownControl(listBox);
            // Get all selected values
            int enumIntValue = 0;
            foreach (string str in listBox.CheckedItems) enumIntValue |= (int)Enum.Parse(t, str);
            if (propType.IsEnum)
            {
               // Return the new enum
               return Enum.ToObject(t, enumIntValue);
            }
            else
            {
               // return a string representation of the value
               return Enum.ToObject(t, enumIntValue).ToString();
            }
         }
         // Something went wrong; just return the original value
         return value;
      }
      /// <summary>Gets the editor style used by the EditValue method.</summary>
      /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
      /// <returns>A UITypeEditorEditStyle value that indicates the style of editor used by EditValue.</returns>
      public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
      {
         // The listbox is a drop down control.
         if (context != null && context.Instance != null)
         {
            return UITypeEditorEditStyle.DropDown;
         }
         return base.GetEditStyle(context);
      }
      #endregion
   }
}

