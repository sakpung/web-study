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

namespace MedicalViewerLayoutDemo
{
   public partial class CounterDialog : Form
   {

      private MainForm myOwner;
      private int imageIndex;

      public CounterDialog(MainForm owner, RasterCodecs codecs)
      {
         myOwner = owner;
         imageIndex = 0;
         codecs.LoadPage += new EventHandler<CodecsPageEventArgs>(codecs_LoadPage);
         InitializeComponent();
         _lblCounter.Text = "Loading Image";
      }

      void codecs_LoadPage(object sender, CodecsPageEventArgs e)
      {
         if (e.State == CodecsPageEventState.After)
         {
            _lblCounter.Text = "Loading Image ( " + (imageIndex + 1) + " )   Page " + e.Page.ToString() + " / " + e.PageCount.ToString();
            _lblCounter.Invalidate();
            _lblCounter.Update();

            int percentage = (e.Page * 100 / e.PageCount);
            if (percentage == 100)
            {
               imageIndex = imageIndex + 1;
               percentage = 0;
            }

            _progress.Value = (imageIndex * 100 + percentage) / myOwner.Images;
            if (imageIndex == myOwner.Images)
               this.Close();
         }
         myOwner.Invalidate();
         myOwner.Update();
      }
   }
}
