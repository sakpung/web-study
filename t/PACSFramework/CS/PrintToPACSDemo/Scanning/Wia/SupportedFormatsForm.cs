// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos;
using Leadtools.Wia;

namespace PrintToPACSDemo
{
   public partial class SupportedFormatsForm : Form
   {
      public SupportedFormatsForm()
      {
         InitializeComponent();
      }

      private void SupportedFormatsForm_Load(object sender, EventArgs e)
      {
         // Add the list view columns.
         _lvFormats.Columns.Add("Transfer Mode (TYMED)", 130, HorizontalAlignment.Left);
         _lvFormats.Columns.Add("Format Name", 80, HorizontalAlignment.Left);
         _lvFormats.Columns.Add("Format GUID", 210, HorizontalAlignment.Left);

         try
         {
            FrmMain._formatsList.Clear();

            // Enable the EnumFormats event.
            FrmMain._wiaSession.EnumFormatsEvent += new EventHandler<Leadtools.Wia.WiaEnumFormatsEventArgs>(_wiaSession_EnumFormatsEvent);

            // enumerate the selected WIA item capabilities.
            FrmMain._wiaSession.EnumFormats(FrmMain._enumeratedItemsList[FrmMain._selectedItemIndex], 0);

            // Disable the EnumFormats event.
            FrmMain._wiaSession.EnumFormatsEvent -= new EventHandler<Leadtools.Wia.WiaEnumFormatsEventArgs>(_wiaSession_EnumFormatsEvent);

            // Loop through the formats array adding them to the formats list.
            foreach (MyFormat i in FrmMain._formatsList)
            {
               ListViewItem item;

               item = _lvFormats.Items.Add(i.TransferModeString);

               item.SubItems.Add(i.FormatName);
               item.SubItems.Add(i.FormatCLSID);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      void _wiaSession_EnumFormatsEvent(object sender, Leadtools.Wia.WiaEnumFormatsEventArgs e)
      {
         if (e.FormatsCount > 0)
         {
            MyFormat myFormat = MyFormat.Empty;
            myFormat.Format = WiaSession.GetFormatGuid(e.Format);
            myFormat.FormatCLSID = myFormat.Format.ToString();
            myFormat.FormatName = e.Format.ToString();
            myFormat.TransferMode = e.TransferMode;
            myFormat.TransferModeString = e.TransferMode.ToString();

            FrmMain._formatsList.Add(myFormat);
         }
      }
   }
}
