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
using Leadtools.Demos;
using Leadtools.Codecs;
using Leadtools.Medical3D;

namespace Main3DDemo
{
   public partial class CounterDialog : Form
   {
       private int _count;
       private int _currentPercent;
       private bool _loadingObject;
       private int _firstPage;
       private int _seriesIndex;
       private string _loadingText;

       protected override void OnShown(EventArgs e)
       {
          base.OnShown(e);
          Owner.Enabled = false;
       }

       protected override void  OnClosed(EventArgs e)
      {
          base.OnClosed(e);
          Owner.Enabled = true;
      }


       public CounterDialog(Form parent)
       {
           InitializeComponent();
           _loadingObject = true;
           _loadingText = DemosGlobalization.GetResxString(GetType(), "Resx_Creating3DObj");
           Owner = parent;
       }

       public CounterDialog(int count, int seriesIndex, Form parent)
      {
         InitializeComponent();
          Owner = parent;
         _count = count;
         _seriesIndex = seriesIndex;
         _currentPercent = 0;
         _progress.Value = 0;
         _lblCounter.Text = DemosGlobalization.GetResxString(GetType(), "Resx_LoadingImage");
         _loadingObject = false;
         _loadingText = DemosGlobalization.GetResxString(GetType(), "Resx_Creating3DObj");
      }


      public override string Text
      {
         set
         {
            _lblCounter.Text = value;
            _lblCounter.Invalidate();
            _lblCounter.Update();
         }
         get
         {
            if (_lblCounter != null)
               return _lblCounter.Text;

            return null;
         }
      }


      public int Percent
      {
         set
         {
            if (_loadingObject)
            {
               _currentPercent = value;

               _lblCounter.Text = _loadingText + " ( " + value.ToString() + " )%";
            }
            else
            {
               _currentPercent = value * 100 / _count;
               _lblCounter.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Series") + (_seriesIndex + 1).ToString() + DemosGlobalization.GetResxString(GetType(), "Resx_LoadingFrame") + value.ToString() + " / " + _count;
            }

            _lblCounter.Invalidate();
            _lblCounter.Update();

            _progress.Value = _currentPercent;
         }
         get
         {
            return _currentPercent;
         }
      }

      public void UpdatePercent(int percent)
      {

      }

      public int FirstPage
      {
         set
         {
            _firstPage = value;
         }
         get
         {
            return _firstPage;
         }
      }

      public bool LoadingObject
      {
         set
         {
            _loadingObject = value;
         }
         get
         {
            return _loadingObject;
         }
      }

      public string LoadingText
      {
         set
         {
            _loadingText = value;
         }

         get
         {
            return _loadingText;
         }
      }


      public int Count
      {
         set
         {
            _count = value;
         }
         get
         {
            return _count;
         }
      }

   }
}
