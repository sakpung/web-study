// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Text;
using System.Windows.Forms;
using Leadtools;
using Leadtools.CreditCards;
using LMVCallbackLib;
using System.Drawing;
using System.Threading.Tasks;
using Leadtools.Drawing;

namespace CreditCardCapture
{
   public class Callback : ILMVUserCallback2, IDisposable
   {
      private CreditCardScanner _scanner;
      private RasterImage _image;
      private Control _owner;
      private string _recognizedCardNumber = "";
      private bool _isRecognized = false;
      private bool _threading = false;
      private int _width;
      private int _height;
      private int _bitCount;
      private int _topDown;

      public LeadRect GuideRect;

      public RasterImage Image
      {
         get { return _image; }
         set { _image = value; }
      }

      public Callback(Control owner)
      {
         _owner = owner;
         _scanner = new CreditCardScanner();
      }

      public void ReceiveProc(long pData, int lWidth, int lHeight, int lBitCount, int lSize, int bTopDown)
      {
         if (!_owner.IsDisposed && !_owner.Disposing)
         {
            try
            {
               if (_width != lWidth || _height != lHeight || _bitCount != lBitCount || _topDown != bTopDown)
               {
                  if (_image != null)
                     _image.Dispose();

                  _image = new RasterImage(RasterMemoryFlags.Conventional,
                     lWidth,
                     lHeight,
                     lBitCount,
                     RasterByteOrder.Bgr,
                     bTopDown == 1 ? RasterViewPerspective.TopLeft : RasterViewPerspective.BottomLeft,
                     null,
                     null,
                     lSize);

                  _width = lWidth;
                  _height = lHeight;
                  _bitCount = lBitCount;
                  _topDown = bTopDown;
               }

               _image.Access();
               _image.SetRow(0, new IntPtr(pData), lSize);
               _image.Release();

               Form1 form = _owner as Form1;
               if (form != null)
               {
                  GuideRect = CreditCardScanner.GetGuideFrame(_owner.ClientRectangle.Width, _owner.ClientRectangle.Height, form.CaptureCtrl.Width, form.CaptureCtrl.Height);
                  _owner.Invalidate();
               }

               if (!_isRecognized && _threading == false)
               {
                  byte[] data = new byte[lSize];
                  System.Runtime.InteropServices.Marshal.Copy(new IntPtr(pData), data, 0, lSize);
                  Task processFrame = Task.Factory.StartNew(() => ProcessFrame(data, lWidth, lHeight, bTopDown, lBitCount));
               }

               if (_isRecognized == true)
               {
                  MessageBox.Show(_recognizedCardNumber);
                  _recognizedCardNumber = "";
                  _isRecognized = false;
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }
      }

      private void ProcessFrame(byte[] pData, int lWidth, int lHeight, int bTopDown, int lBitCount)
      {
         try
         {
            _threading = true;

            Frame frame = new Frame();
            frame.Width = lWidth;
            frame.Height = lHeight;
            frame.Orientation = FrameOrientation.LandscapeLeft;
            frame.ImageFormat = lBitCount == 24 ? ImageFormat.BGR888 : ImageFormat.BGR8888;
            frame.ImageData = pData;

            if (bTopDown != 1)
               frame.Height *= -1;

            DetectionInfo detectionInfo = _scanner.ScanFrame(frame);
            if (detectionInfo.Status == ScanFrameStatus.NumbersFound)
            {
               CreditCard creditCard = new CreditCard(detectionInfo);
               StringBuilder sb = new StringBuilder();
               switch (creditCard.CardType)
               {
                  case (CardType.AmericanExpress):
                     sb.Append("Amex Card#: ");
                     break;
                  case (CardType.DinersClub):
                     sb.Append("DinersClub Card#: ");
                     break;
                  case (CardType.Discover):
                     sb.Append("Discover Card#: ");
                     break;
                  case (CardType.JCB):
                     sb.Append("JCB Card#: ");
                     break;
                  case (CardType.MasterCard):
                     sb.Append("MasterCard Card#: ");
                     break;
                  case (CardType.Visa):
                     sb.Append("VISA Card#: ");
                     break;
                  case (CardType.Maestro):
                     sb.Append("Discover Card#: ");
                     break;
                  default:
                     sb.Append("Unknown Card#: ");
                     break;
               }

               for (int i = 0; i < creditCard.CardNumber.Length; i++)
               {
                  if (creditCard.CardNumber.Length == 16)
                  {
                     if ((i % 4) == 0)
                        sb.Append(" ");
                  }
                  else
                  {
                     // American Express cards have 15 digits in the following format:
                     // XXXX XXXXXX XXXXX
                     if (i == 4) { sb.Append(" "); }
                     else if (i == 10) { sb.Append(" "); }
                  }
                  sb.Append(creditCard.CardNumber[i]);
               }
               _scanner.Reset();

               _recognizedCardNumber = sb.ToString();

               _isRecognized = true;
            }
            else
            {
               _isRecognized = false;
            }

            _threading = false;
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }

      #region IDisposable Support
      private bool disposedValue = false; // To detect redundant calls

      protected virtual void Dispose(bool disposing)
      {
         if (!disposedValue)
         {
            if (disposing)
            {
               if (_scanner != null)
                  _scanner.Dispose();
               if (_image != null)
                  _image.Dispose();
            }

            disposedValue = true;
         }
      }

      // This code added to correctly implement the disposable pattern.
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
      #endregion
   }
}
