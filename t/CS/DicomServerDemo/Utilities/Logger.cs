// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for Logger.
   /// </summary>
   public static class Logger
   {
      private static ListView lv;
      private static Color _ActionColor = Color.Blue;
      private static bool _disableLogging = false;

      public static Color ActionColor
      {
         get
         {
            return _ActionColor;
         }
         set
         {
            _ActionColor = value;
         }
      }

      public static bool DisableLogging
      {
         get
         {
            return _disableLogging;
         }
         set
         {
            _disableLogging = value;
         }
      }

      public static void Initialize(ListView logger)
      {
         lv = logger;
      }

      public static void Log(string action, string text)
      {
         if (_disableLogging == false)
         {
            ListViewItem item;
            ListViewItem.ListViewSubItem subItem;

            item = lv.Items.Add(action);
            item.ForeColor = _ActionColor;
            item.UseItemStyleForSubItems = false;

            subItem = item.SubItems.Add(text);
            subItem.ForeColor = Color.Black;

            lv.EnsureVisible(item.Index);
         }
      }

      public static void Log(string action, string text, object tag)
      {
         if (_disableLogging == false)
         {
            ListViewItem item;
            ListViewItem.ListViewSubItem subItem;

            item = lv.Items.Add(action);
            item.ForeColor = _ActionColor;
            item.UseItemStyleForSubItems = false;

            if (tag.ToString().Length > 0)
            {
               item.Tag = tag;
               item.ImageIndex = 0;
            }

            subItem = item.SubItems.Add(text);
            subItem.ForeColor = Color.Black;

            lv.EnsureVisible(item.Index);
         }
      }
   }
}
