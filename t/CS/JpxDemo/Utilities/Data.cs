// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools;
using Leadtools.Jpeg2000;

namespace JPXDemo
{
   //
   // Save List and Composite List Structure...
   //
   public struct ListItem
   {
      public string Name;
      public RasterImage Image;

      public override string ToString()
      {
         return Name;
      }

      public ListItem(string _name, RasterImage _image)
      {
         Name = _name;
         Image = _image;
      }
   }

   //
   // Append GML Structure
   //
   public struct GMLListItem
   {
      public string Label;
      public string Name;
      public GmlElement GMLElement;

      public override string ToString()
      {
         return Name;
      }

      public GMLListItem(string _label, string _name, GmlElement _gmlElement)
      {
         Label = _label;
         Name = _name;
         GMLElement = _gmlElement;
      }
   }

   //
   // Get File Information Dialog Structures...
   //
   public struct FileInformationSortStructure
   {
      public uint type;
      public uint offset;
      public uint size;
   }

   public struct JPXFileInfoStructure
   {
      public string fileName;
      public Jpeg2000FileInformation fileInformation;
      public bool prepared;
      public FileInformationSortStructure[] boxes;
      public uint boxesNumber;
      public FileInformationSortStructure[] groups;
      public uint groupsNumber;
      public uint totalSize;
   }

   //
   // Fragment Jpx Dialog Structure...
   //
   public struct FragmentJpxStructure
   {
      public string inJPG2FileName;
      public string outJPG2FileName;
      public string streamFileName;
   }

   //
   // Extract Frames Dialog Structure...
   //
   public struct ExtractFrameStructure
   {
      public string inJPG2FileName;
      public string outJPG2FileName;
   }

   //
   // Save Animation Settings Structure...
   //
   public struct SaveAnimationSettings
   {
      public string jPG2FileName;
      public uint animationWidth;
      public uint animationHeight;
      public bool animationLoop;
      public uint animationDelay;
   }

   //
   // Digital Signature Structure...
   //
   public struct DigitalSignatureStructure
   {
      public string jPG2FileName;
      public uint signatureType;
      public int pointerType;
      public int offset;
      public int length;
      public byte[] data;
   }

   //
   // Read Box Structure...
   //
   public struct ReadBoxCommonStructure
   {
      public string dialogName;
      public string jPG2FileName;
      public byte[] data;
      public Jpeg2000BoxType boxType;
   }

   //
   // Append GML Structure...
   //
   public struct AppendGMLStructure
   {
      public string jPG2FileName;
      public string xMLFileName;
      public GmlData gMLData;
   }

   //
   // Binary Fitler Structure
   //
   public struct AppendCommonStructure
   {
      public string dialogName;
      public string jPG2FileName;
      public UuidId type;
      public byte[] data;
   }
}
