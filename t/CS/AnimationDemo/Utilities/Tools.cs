// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

using Leadtools;

namespace AnimationDemo
{
   public sealed class Tools
   {
      private Tools( )
      {
      }

      public static void FillComboBoxWithEnum(ComboBox theComboBox, Type theType, object defaultSelected)
      {
         FillComboBoxWithEnum(theComboBox, theType, defaultSelected, null);
      }

      public static void FillComboBoxWithEnum(ComboBox theComboBox, Type theType, object defaultSelected, object[] doNotAdd)
      {
         string itemName;
         Array a = Enum.GetValues(theType);
         foreach(object i in a)
         {
            bool add = true;

            if(doNotAdd != null)
            {
               for(int j = 0; j < doNotAdd.Length && add; j++)
               {
                  if((int)i == (int)doNotAdd[j])
                     add = false;
               }
            }

            if(add)
            {
               itemName = Constants.GetNameFromValue(theType, i);
               theComboBox.Items.Add(itemName);
               if(string.Compare(Constants.GetNameFromValue(theType, defaultSelected), itemName) == 0)
                  theComboBox.SelectedItem = itemName;
            }
         }

         if(theComboBox.SelectedItem == null)
            theComboBox.SelectedIndex = 0;
      }

      public static bool ShowColorDialog(IWin32Window owner, ref RasterColor color)
      {
         ColorDialog dlg = new ColorDialog();
         dlg.AllowFullOpen = true;
         dlg.AnyColor = true;
         dlg.Color = Leadtools.Demos.Converters.ToGdiPlusColor(color);
         DialogResult res = dlg.ShowDialog(owner);
         if(res == DialogResult.OK)
            color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color);

         return res == DialogResult.OK;
      }

      public static bool CanDrop(IDataObject data)
      {
         return data.GetDataPresent(DataFormats.Text) || data.GetDataPresent(DataFormats.FileDrop);
      }

      public static string[] GetDropFiles(IDataObject data)
      {
         if(data.GetDataPresent(DataFormats.Text))
         {
            string[] files = new string[1];
            files[0] = data.GetData(DataFormats.Text) as string;
            return files;
         }
         else if(data.GetDataPresent(DataFormats.FileDrop))
         {
            string[] files = data.GetData(DataFormats.FileDrop) as string[];
            return files;
         }

         return null;
      }
   }
}
