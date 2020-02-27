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

using Leadtools;
using Leadtools.Codecs;
using Leadtools.MedicalViewer;

namespace MedicalViewerDemo
{
   public partial class CounterDialog : Form
   {

      private MainForm myOwner;
      private int imageIndex;

      public CounterDialog(MainForm owner, RasterCodecs codecs)
      {
         myOwner = owner;
         imageIndex = 0;
         if (codecs != null)
            codecs.LoadPage += new EventHandler<CodecsPageEventArgs>(codecs_LoadPage);
         InitializeComponent();
         _lblCounter.Text = "Loading Image";
      }

      public void UpdateCounterPercent(int currentPage, int total, int firstPage, bool invalidate)
      {
         _lblCounter.Text = "Loading Image ( " + (imageIndex + 1) + " )   Page " + currentPage.ToString() + " / " + (total + firstPage - 1).ToString();
         _lblCounter.Invalidate();
         _lblCounter.Update();

         int percentage = ((currentPage - firstPage + 1)  * 100 / total);
         if (percentage == 100)
         {
            imageIndex = imageIndex + 1;
            percentage = 0;
         }

         _progress.Value = (imageIndex * 100 + percentage) / myOwner.Images;
         if (imageIndex == myOwner.Images)
            this.Close();

         if (invalidate)
         {
            myOwner.Invalidate();
            myOwner.Update();
         }
      }

      void codecs_LoadPage(object sender, CodecsPageEventArgs e)
      {
         if (e.State == CodecsPageEventState.After)
         {
            UpdateCounterPercent(e.Image.Page, e.Image.PageCount, 1, false);
         }
         myOwner.Invalidate();
         myOwner.Update();
      }
   }
}
