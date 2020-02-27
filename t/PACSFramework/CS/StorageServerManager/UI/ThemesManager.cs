// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Leadtools.Demos.StorageServer.UI
{
   class ThemesManager
   {
      public static void ApplyTheme ( Control control ) 
      {
         control.BackColor = Color.FromArgb ( 237, 239, 244 ) ;
         
         if ( control is GroupBox )
         {
            control.ForeColor = Color.DarkBlue ;
         }
         else
         {
            control.ForeColor = Color.Black ;
         }
         
         if ( control is Button ) 
         {
            ( ( Button ) control ).FlatStyle = FlatStyle.Flat ;
         }
         
         if ( control is DataGridView )
         {
            DataGridView grdView = (DataGridView) control ;
            
            grdView.BackgroundColor = Color.SlateGray ;
            grdView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells ;
         }
         
         foreach ( Control child in control.Controls )
         {
            ApplyTheme ( child ) ;
         }
      }
   }
}
