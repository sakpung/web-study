// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for WindowLevel.
   /// </summary>
   public class WindowLevel
   {

      bool _WindowLeveling = false;
      RasterImage image;
      Point startPoint;
      double _WindowCenter = 0;
      double _WindowWidth = 0;
      bool _reverseOrder = false;

      public bool WindowLeveling
      {
         get
         {
            return _WindowLeveling;
         }
      }

      public bool ReverseOrder
      {
         get
         {
            return _reverseOrder;
         }
         set
         {
            _reverseOrder = value;
         }
      }

      public double WindowCenter
      {
         get
         {
            return _WindowCenter;
         }
         set
         {
            _WindowCenter = value;
         }
      }

      public double WindowWidth
      {
         get
         {
            return _WindowWidth;
         }
         set
         {
            _WindowWidth = value;
         }
      }

      public WindowLevel( )
      {
         //
         // TODO: Add constructor logic here
         //
      }

      public void Start(RasterImage image, Point point)
      {
         this.image = image;
         startPoint = point;
         _WindowLeveling = true;
      }

      public void Stop(Point point)
      {
         _WindowLeveling = false;

         if(point == startPoint)
         {
            return;
         }

         ApplyWindowLeveling();
      }

      public void Process(Point pt)
      {
         float windowleveldelta = (pt.Y - startPoint.Y);
         float windowwidthdelta = (pt.X - startPoint.X);
         int delta;

         if((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
         {
            const float sensitivity = 0.1f;

            windowleveldelta = windowleveldelta > 0 ? sensitivity : windowleveldelta < 0 ? -sensitivity : 0;
            windowwidthdelta = windowwidthdelta > 0 ? sensitivity : windowwidthdelta < 0 ? -sensitivity : 0;
            delta = 1;
         }
         else
         {
            if(Math.Abs(windowleveldelta) <= 1)
               windowleveldelta = 0;
            if(Math.Abs(windowwidthdelta) <= 1)
               windowwidthdelta = 0;
            delta = 2;
         }

         if(windowleveldelta != 0 || windowwidthdelta != 0)
         {
            _WindowCenter += windowleveldelta * delta;
            _WindowWidth += windowwidthdelta * delta;

            ApplyWindowLeveling();
         }

         startPoint.Y = pt.Y;
         startPoint.X = pt.X;
      }

      public void ApplyWindowLeveling( )
      {
         try
         {
            if(image != null && image.IsGray)
            {
               if(image.MaxValue == 0)
               {
                  MinMaxValuesCommand cmd = new MinMaxValuesCommand();
                  cmd.Run(image);
                  image.MinValue = cmd.MinimumValue;
                  image.MaxValue = cmd.MaximumValue;
               }

               MinMaxValuesCommand minMaxCommand = new MinMaxValuesCommand();

               minMaxCommand.Run(image);
               image.MinValue = minMaxCommand.MinimumValue;
               image.MaxValue = minMaxCommand.MaximumValue;
               ApplyLinearVoiLookupTableCommand voiCommand = new ApplyLinearVoiLookupTableCommand();
               if(ReverseOrder)
               {
                  voiCommand.Flags = VoiLookupTableCommandFlags.ReverseOrder;
               }
               else
               {
                  voiCommand.Flags = VoiLookupTableCommandFlags.None;
               }

               voiCommand.Center = _WindowCenter;
               voiCommand.Width = _WindowWidth;
               voiCommand.Run(image);
            }
         }
         catch
         {
         }
      }
   }
}
