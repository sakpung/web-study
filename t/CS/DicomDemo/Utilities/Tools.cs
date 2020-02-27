// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

using Leadtools;

namespace DicomDemo
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
         //string itemName;
         //Array a = Enum.GetValues(theType);
         //foreach(object i in a)
         //{
         //   bool add = true;

         //   if(doNotAdd != null)
         //   {
         //      for(int j = 0; j < doNotAdd.Length && add; j++)
         //      {
         //         if((int)i == (int)doNotAdd[j])
         //            add = false;
         //      }
         //   }

         //   if(add)
         //   {
         //      itemName = Constants.GetNameFromValue(theType, i);
         //      theComboBox.Items.Add(itemName);
         //      if(string.Compare(Constants.GetNameFromValue(theType, defaultSelected), itemName) == 0)
         //         theComboBox.SelectedItem = itemName;
         //   }
         //}

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

      public static void ShowUidTable()
      {
         UniqueIdentifierDlg dlgUID = new UniqueIdentifierDlg();

         dlgUID.ShowDialog();
      }

      public static void ShowTagTable()
      {
         try
         {
            ElementTagDlg dlgTag = new ElementTagDlg();

            dlgTag.ShowDialog();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
         finally
         {
         }
      }

      public static void ShowIodTable()
      {
         try
         {
            InformationObjectDefinitionDlg dlgIOD = new InformationObjectDefinitionDlg();
            dlgIOD.ShowDialog();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
         finally
         {
         }
      }

      public static void ShowContextGroupTable()
      {
         try
         {
            ContextGroupDlg dlgContext = new ContextGroupDlg();
            dlgContext.ShowDialog();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
         finally
         {
         }
      }
   }

   public static class Extensions
   {
      // converts an enum value to an integer
      public static int ToInt(this Enum enumValue)
      {
         return (int)((object)enumValue);
      }

      // returns true if the flags 'field' has the flag 'value' set
      public static bool IsFlagged(this Enum field, Enum value)
      {
         return (field.ToInt() & value.ToInt()) == value.ToInt();
      }
   }
}
