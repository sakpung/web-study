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
   internal class PdfStandardOptions
   {
      private bool _added;
      private bool _NOMRC;
      private int _BKThreshold;
      private int _cleanSize;
      private int _CLRThreshold;
      private int _combThreshold;
      private int _segQuality;
      private int _inputImageComboSel;
      private int _outputImageComboSel;
      private int _pageNumber;

      public PdfStandardOptions( )
      {
         _added = false;
         _NOMRC = false;
         _BKThreshold = 0;
         _cleanSize = 0;
         _CLRThreshold = 0;
         _combThreshold = 0;
         _segQuality = 0;
         _inputImageComboSel = 0;
         _outputImageComboSel = 0;
         _pageNumber = 0;

      }
      public bool Added
      {
         get
         {
            return _added;
         }
         set
         {
            _added = value;
         }
      }

      public bool NOMRC
      {
         get
         {
            return _NOMRC;
         }
         set
         {
            _NOMRC = value;
         }
      }


      public int BKThreshold
      {
         get
         {
            return _BKThreshold;
         }
         set
         {
            _BKThreshold = value;
         }
      }

      public int CleanSize
      {
         get
         {
            return _cleanSize;
         }
         set
         {
            _cleanSize = value;
         }
      }

      public int CLRThreshold
      {
         get
         {
            return _CLRThreshold;
         }
         set
         {
            _CLRThreshold = value;
         }
      }

      public int CombThreshold
      {
         get
         {
            return _combThreshold;
         }
         set
         {
            _combThreshold = value;
         }
      }

      public int SegQuality
      {
         get
         {
            return _segQuality;
         }
         set
         {
            _segQuality = value;
         }
      }

      public int InputImageComboSel
      {
         get
         {
            return _inputImageComboSel;
         }
         set
         {
            _inputImageComboSel = value;
         }
      }

      public int OutputImageComboSel
      {
         get
         {
            return _outputImageComboSel;
         }
         set
         {
            _outputImageComboSel = value;
         }
      }

      public int PageNumber
      {
         get
         {
            return _pageNumber;
         }
         set
         {
            _pageNumber = value;
         }
      }

   }
}
