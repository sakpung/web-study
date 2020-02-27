// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Annotations.Engine;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using Leadtools.Annotations.WinForms;

namespace Leadtools.Annotations.Rendering
{
   public class AnnRichTextObjectRenderer : AnnRectangleObjectRenderer
   {
      private InternalRichTextEdit _richTextBox;

      internal class InternalRichTextEdit : RichTextBox
      {
         private const double anInch = 14.4;

         override protected CreateParams CreateParams
         {
            get
            {
               CreateParams cp = base.CreateParams;

               cp.ExStyle |= 0x20;

               return cp;
            }
         }

         public static int Print(RichTextBox richTextBox, PrintPageEventArgs e)
         {
            //Calculate the area to render and print
            Win32.RECT rectToPrint;
            rectToPrint.top = (int)(e.MarginBounds.Top * anInch);
            rectToPrint.bottom = (int)(e.MarginBounds.Bottom * anInch);
            rectToPrint.left = (int)(e.MarginBounds.Left * anInch);
            rectToPrint.right = (int)(e.MarginBounds.Right * anInch);

            //Calculate the size of the page
            Win32.RECT rectPage;
            rectPage.top = (int)(e.PageBounds.Top * anInch);
            rectPage.bottom = (int)(e.PageBounds.Bottom * anInch);
            rectPage.left = (int)(e.PageBounds.Left * anInch);
            rectPage.right = (int)(e.PageBounds.Right * anInch);

            IntPtr hdc = e.Graphics.GetHdc();

            Win32.FORMATRANGE fmtRange;
            fmtRange.chrg.cpMax = richTextBox.SelectionLength > 0 ? richTextBox.SelectionLength + richTextBox.SelectionLength : -1;				//Indicate character from to character to 
            fmtRange.chrg.cpMin = richTextBox.SelectionLength > 0 ? richTextBox.SelectionStart : 0;
            fmtRange.hdc = hdc;                    //Use the same DC for measuring and rendering
            fmtRange.hdcTarget = hdc;              //Point at printer hDC
            fmtRange.rc = rectToPrint;             //Indicate the area on page to print
            fmtRange.rcPage = rectPage;            //Indicate size of page

            IntPtr res = IntPtr.Zero;

            IntPtr wparam = IntPtr.Zero;
            wparam = new IntPtr(1);

            //Get the pointer to the FORMATRANGE structure in memory
            IntPtr lparam = IntPtr.Zero;
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));
            Marshal.StructureToPtr(fmtRange, lparam, false);

            //Send the rendered data for printing 
            res = SafeNativeMethods.SendMessage(richTextBox.Handle, Win32.EM_FORMATRANGE, wparam, lparam);

            //Free the block of memory allocated
            Marshal.FreeCoTaskMem(lparam);

            //Release the device context handle obtained by a previous call
            e.Graphics.ReleaseHdc(hdc);

            //Return last + 1 character printer
            return res.ToInt32();
         }

         //protected override bool ProcessCmdKey(ref Message m, Keys keyData)
         //{
         //   MessageBox.Show("hi");
         //   return base.ProcessCmdKey(ref m, keyData);
         //}
      }
      public override void Render(AnnContainerMapper mapper, AnnObject annObject)
      {
         if (mapper == null) ExceptionHelper.ArgumentNullException("mapper");
         if (annObject == null) ExceptionHelper.ArgumentNullException("annObject");

         base.Render(mapper, annObject);
         AnnRichTextObject annRichTextObject = annObject as AnnRichTextObject;
         if (annRichTextObject != null && !String.IsNullOrEmpty(annRichTextObject.Rtf))
         {
            AnnWinFormsRenderingEngine engine = RenderingEngine as AnnWinFormsRenderingEngine;
            if (engine != null && engine.Context != null)
            {
               AnnRectangleObject tempRect = new AnnRectangleObject();
               tempRect.Points.Clear();
               foreach (LeadPointD pt in GetRenderPoints(mapper, annRichTextObject))
                  tempRect.Points.Add(pt);

               double rotation = tempRect.Angle;
               if (rotation == 180)
               {
                  rotation = 0;
               }

               LeadRectD boundsPixels = tempRect.Rect.Clone();
               AnnContainerMapper identityMapper = mapper.Clone();
               identityMapper.UpdateTransform(LeadMatrix.Identity);
               identityMapper.MapResolutions(mapper.SourceDpiX,mapper.SourceDpiY,mapper.SourceDpiX,mapper.SourceDpiY);
               boundsPixels = identityMapper.RectFromContainerCoordinates(boundsPixels, annRichTextObject.FixedStateOperations);
               if (tempRect.Stroke != null)
               {
                  boundsPixels.Inflate(-tempRect.Stroke.StrokeThickness.Value, -tempRect.Stroke.StrokeThickness.Value);
               }

               string rtf = annRichTextObject.Rtf;
               IntPtr hemfDC;
               if (_richTextBox == null)
               {
                  _richTextBox = new InternalRichTextEdit();
               }

               try
               {
                  _richTextBox.Rtf = rtf;
               }
               catch
               {
                  using (RichTextBox richTextBox = new RichTextBox())
                  {
                     richTextBox.Text = rtf;
                     annRichTextObject.Rtf = richTextBox.Rtf;
                     _richTextBox.Rtf = richTextBox.Rtf;
                  }
               }

               Graphics graphics = engine.Context;
               double dpiX = 96;
               double dpiY = 96;

               _richTextBox.Location = new Point((int)boundsPixels.Location.X, (int)boundsPixels.Location.Y);
               _richTextBox.Size = new Size((int)boundsPixels.Size.Width, (int)boundsPixels.Size.Height);
               IntPtr hdc = graphics.GetHdc();

               Win32.RECT rc = new Win32.RECT();

               rc.left = _richTextBox.ClientRectangle.Left;
               rc.top = _richTextBox.ClientRectangle.Top;
               rc.right = (int)boundsPixels.Width;
               rc.bottom = (int)boundsPixels.Height;

               int iWidthMM = SafeNativeMethods.GetDeviceCaps(hdc, Win32.HORZSIZE);
               int iHeightMM = SafeNativeMethods.GetDeviceCaps(hdc, Win32.VERTSIZE);
               int iWidthPels = SafeNativeMethods.GetDeviceCaps(hdc, Win32.HORZRES);
               int iHeightPels = SafeNativeMethods.GetDeviceCaps(hdc, Win32.VERTRES);

               rc.left = (rc.left * iWidthMM * 100) / iWidthPels;
               rc.top = (rc.top * iHeightMM * 100) / iHeightPels;
               rc.right = (rc.right * iWidthMM * 100) / iWidthPels;
               rc.bottom = (rc.bottom * iHeightMM * 100) / iHeightPels;

               hemfDC = SafeNativeMethods.CreateEnhMetaFile(hdc, null, ref rc, null);

               Win32.RECT emfRect = new Win32.RECT();
               emfRect.right = (int)boundsPixels.Width;
               emfRect.bottom = (int)boundsPixels.Height;

               IntPtr brush = SafeNativeMethods.GetStockObject(5);
               SafeNativeMethods.SetBkMode(hemfDC, 1);
               SafeNativeMethods.FillRect(hemfDC, ref emfRect, brush);
               SafeNativeMethods.DeleteObject(brush);

               Print(_richTextBox, _richTextBox.ClientRectangle, hemfDC, (int)dpiX, (int)dpiY, false);
               IntPtr hemf = SafeNativeMethods.CloseEnhMetaFile(hemfDC);

               using (Metafile metaFile = new Metafile(hemf, true))
               {
                  graphics.ReleaseHdc();
                  GraphicsState state = graphics.Save();

                  //the mapper transform dosent contain dpi effect so we will add dpi effect .
                  LeadMatrix matrix = mapper.Transform;
                  //add dpi effect to the transform
                  matrix.Scale((float)(mapper.TargetDpiX / mapper.SourceDpiX), (float)(mapper.TargetDpiY / mapper.SourceDpiY));

                  if ((annRichTextObject.FixedStateOperations & AnnFixedStateOperations.Scrolling) == AnnFixedStateOperations.Scrolling)
                  {
                     matrix.Translate(-matrix.OffsetX, -matrix.OffsetY);
                  }

                  if ((annRichTextObject.FixedStateOperations & AnnFixedStateOperations.Zooming) == AnnFixedStateOperations.Zooming)
                  {
                     double offsetX = matrix.OffsetX;
                     double offsetY = matrix.OffsetY;
                     double scaleX = 1.0;
                     double scaleY = 1.0;
                     if (matrix.M11 != 0 && matrix.M22 != 0)
                     {
                        scaleX = 1.0 / Math.Abs(matrix.M11);
                        scaleY = 1.0 / Math.Abs(matrix.M22);
                     }

                     matrix.Scale(scaleX, scaleY);
                  }

                  using (Matrix transform = new Matrix((float)matrix.M11, (float)matrix.M12, (float)matrix.M21, (float)matrix.M22, (float)matrix.OffsetX, (float)matrix.OffsetY))
                  {
                     graphics.MultiplyTransform(transform);
                     graphics.DrawImage(metaFile, new Point((int)boundsPixels.Left, (int)boundsPixels.Top));
                  }
                  graphics.Restore(state);
               }
            }

            //EndDraw(graphics, gState);
         }
      }

      internal static void Print(RichTextBox textBox, RectangleF bounds, IntPtr hDC, int dpiX, int dpiY, bool measureOnly)
      {
         int screenPixelsX = SafeNativeMethods.GetDeviceCaps(hDC, Win32.HORZRES);
         int screenPixelsY = SafeNativeMethods.GetDeviceCaps(hDC, Win32.VERTRES);
         int pixelsPerInchX = dpiX;
         int pixelsPerInchY = dpiY;

         // Fill in the FORMATRANGE struct
         Win32.FORMATRANGE fr;

         fr.hdc = fr.hdcTarget = hDC;
         fr.chrg.cpMin = 0;
         fr.chrg.cpMax = -1;

         int left = (int)(bounds.Left * 1440 / pixelsPerInchX);
         int top = (int)(bounds.Top * 1440 / pixelsPerInchY);
         int right = (int)(bounds.Right * 1440 / pixelsPerInchX);
         int bottom = (int)(bounds.Bottom * 1440 / pixelsPerInchY);

         fr.rc = new Win32.RECT();

         fr.rc.left = left;
         fr.rc.top = top;
         fr.rc.right = right;
         fr.rc.bottom = bottom;

         fr.rcPage = fr.rc;

         fr.rcPage.left = 0; //3000;  // 1440 TWIPS = 1 inch.
         fr.rcPage.top = 0;//3000;
         fr.rcPage.right = screenPixelsX / pixelsPerInchX * 1440;
         fr.rcPage.bottom = screenPixelsY / pixelsPerInchY * 1440;

         // Non-Zero wParam means render, Zero means measure
         IntPtr wParam = (measureOnly ? new IntPtr(0) : new IntPtr(1));

         // Allocate memory for the FORMATRANGE struct and
         // copy the contents of our struct to this memory
         IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr));
         Marshal.StructureToPtr(fr, lParam, false);

         // Send the actual Win32 message
         IntPtr res = SafeNativeMethods.SendMessage(textBox.Handle, Win32.EM_FORMATRANGE, wParam, lParam);

         // Free allocated memory
         Marshal.FreeCoTaskMem(lParam);
      }

      internal static void Print(RichTextBox textBox, PrintPageEventArgs e)
      {
         InternalRichTextEdit.Print(textBox, e);
      }
   }
}
