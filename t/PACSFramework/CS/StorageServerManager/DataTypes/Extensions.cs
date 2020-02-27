// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Leadtools.Demos.StorageServer
{
   public static class Extensions
   {
      public const int WM_SETREDRAW = 0x000B;

      [DllImport("USER32.DLL")]
      public static extern IntPtr SendMessage(IntPtr hwnd,int wMsg,int wParam,IntPtr lParam);

      public static T Clone<T>(this T obj)
      {
         using (var ms = new MemoryStream())
         {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;

            return (T)formatter.Deserialize(ms);
         }
      }

      public static SecureString ToSecureString(this string password)
      {
         char[] passwordChars;
         SecureString secure;


         passwordChars = password.ToCharArray();
         secure = new SecureString();

         foreach (char c in passwordChars)
         {
            secure.AppendChar(c);
         }

         secure.MakeReadOnly();

         return secure;
      }

      public static IEnumerable<Type> Implements<T>(this Assembly assembly)
      {
         Type itype = typeof(T);

         return assembly.GetTypes().Where(type => itype.IsAssignableFrom(type));
      }

      public static void UncheckAll(this ListView listview)
      {
         foreach (ListViewItem item in listview.CheckedItems)
            item.Checked = false;
      }

      public static void CheckAll(this ListView listview)
      {
         foreach (ListViewItem item in listview.Items)
            item.Checked = true;
      }

      public static void SetForeColor(this ListView listview, Color color)
      {
         foreach (ListViewItem item in listview.Items)
            item.ForeColor = color;
      }

      public static void Freeze(this Control control)
      {
         try
         {
            SendMessage(control.Handle,WM_SETREDRAW,0,IntPtr.Zero);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      public static void UnFreeze(this Control control)
      {
         try
         {
            SendMessage(control.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      public static bool Contains(this string source, string toCheck, StringComparison comp)
      {
         return source.IndexOf(toCheck, comp) >= 0;
      }

      public static string GetDisplayName(this UI.AdministrativeSettings.Users.UsersSource.UsersRow user)
      {
         string displayName = user.UserName;
         if (!string.IsNullOrEmpty(user.FriendlyName))
         {
            displayName = user.FriendlyName;
         }
         return displayName;
      }
      }
}
