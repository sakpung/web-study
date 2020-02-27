// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools;

namespace InteractiveHist
{
   public class UndoRedo
   {
      private const int _maxImages = 10;

      public UndoRedo()
      {
         _imageList = new RasterImage[_maxImages];
      }

      private RasterImage[] _imageList;
      private int _index = -1;
      private int _Counter = 0;

      public int MaxImages
      {
         get
         {
            return _maxImages;
         }
      }

      public RasterImage CurrentImage
      {
         get
         {
            return _imageList[_index];
         }
      }

      public RasterImage GetImage(int index)
      {
         return _imageList[index];
      }

      public int Counter
      {
         get
         {
            return _Counter;
         }
         set
         {
            _Counter = value;
         }
      }

      public int Index
      {
         get
         {
            return _index;
         }
         set
         {
            _index = value;
         }
      }

      public RasterImage[] ImageList
      {
         get
         {
            return _imageList;
         }
         set
         {
            _imageList = value;
         }
      }

      public void AddToUndoList(RasterImage image)
      {
         if (_index < _maxImages - 1)
         {
            _imageList[_index + 1] = image.CloneAll();
            _index++;
            _Counter = _index + 1;
         }
         else
         {
            if (_imageList[0] != null)
               _imageList[0].Dispose();

            int index;
            for (index = 1; index < MaxImages; index++)
               _imageList[index - 1] = _imageList[index];

            _imageList[_index] = image.CloneAll();
            _Counter = _index + 1;
         }
      }
   }
}
