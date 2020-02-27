// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;

namespace PdfCompDemo
{
   /// <summary>
   /// Summary description for PdfAdvancedOptions.
   /// </summary>
   internal class PdfAdvancedOptions
   {
      // Advance Setting
      private int _oneBitComboSel;
      private int _twoBitComboSel;
      private int _pictComboSel;
      private int _qFactor;
      private int _segmentationComboSel;
      private bool _checkBackground;

      public PdfAdvancedOptions( )
      {
         _oneBitComboSel = 5;
         _twoBitComboSel = 0;
         _pictComboSel = 2;
         _qFactor = 50;
         _segmentationComboSel = 1;
         _checkBackground = false;
      }
      // Advance Setting

      public int OneBitComboSel
      {
         get
         {
            return _oneBitComboSel;
         }
         set
         {
            _oneBitComboSel = value;
         }
      }

      public int TwoBitComboSel
      {
         get
         {
            return _twoBitComboSel;
         }
         set
         {
            _twoBitComboSel = value;
         }
      }


      public int PictComboSel
      {
         get
         {
            return _pictComboSel;
         }
         set
         {
            _pictComboSel = value;
         }
      }


      public int QFactor
      {
         get
         {
            return _qFactor;
         }
         set
         {
            _qFactor = value;
         }
      }

      public int SegmentationComboSel
      {
         get
         {
            return _segmentationComboSel;
         }
         set
         {
            _segmentationComboSel = value;
         }
      }


      public bool CheckBackground
      {
         get
         {
            return _checkBackground;
         }
         set
         {
            _checkBackground = value;
         }
      }
   }
}
