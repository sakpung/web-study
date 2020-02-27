// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace SharePointDemo
{
   // A dictionary that holds the icon and description for file types
   internal class FileTypeDictionary
   {
      // Each file type has a description and an image (index into the image list)
      internal struct MyFileType
      {
         public string Description;
         public int ImageIndex;
      }

      // The image list to hold the icons into
      private ImageList _imageList;
      // A dictionary of FileType based on "Extension"
      private Dictionary<string, MyFileType> _fileTypes;

      public FileTypeDictionary(ImageList il)
      {
         _imageList = il;
         _fileTypes = new Dictionary<string, MyFileType>();
      }

      // Interop

      [Flags]
      private enum SHGFI
      {
         None = 0x000,
         SHGFI_SMALLICON = 0x001,
         SHGFI_USEFILEATTRIBUTES = 0x010,
         SHGFI_ICON = 0x100,
         SHGFI_TYPENAME = 0x400
      }

      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      private struct SHFILEINFO
      {
         public IntPtr hIcon;
         public int iIcon;
         public int dwAttributes;
         [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
         public string szDisplayName;
         [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
         public string szTypeName;
      }

      [DllImport("shell32.dll")]
      private static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, SHGFI uFlags);

      public void Add(string extension)
      {
         // Add the following extension properties into the internal
         // dictionary. If it is already there, we will not do anything

         if(_fileTypes.ContainsKey(extension))
            return;

         // Not found, get the file info for this extension from the system

         // Get a dummy file name
         string dummyFileName = Path.ChangeExtension(@"C:\Dummy", extension);

         SHFILEINFO shinfo = new SHFILEINFO();
         SHGFI flags = SHGFI.SHGFI_ICON | SHGFI.SHGFI_SMALLICON | SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_TYPENAME;
         IntPtr ret = SHGetFileInfo(dummyFileName, 0, ref shinfo, Marshal.SizeOf(shinfo), flags);

         // The icon is returned in the hIcon member of the shinfo struct.
         MyFileType fileType = new MyFileType();

         if(ret != IntPtr.Zero)
         {
            fileType.Description= shinfo.szTypeName;

            if(shinfo.hIcon != IntPtr.Zero)
            {
               _imageList.Images.Add(Icon.FromHandle(shinfo.hIcon));
               fileType.ImageIndex = _imageList.Images.Count - 1;
            }
            else
               fileType.ImageIndex = -1;
         }
         else
         {
            fileType.Description = "Unknown";
            fileType.ImageIndex = -1;
         }

         // Add it to the dictionary
         _fileTypes.Add(extension, fileType);
      }

      public string GetDescription(string extension)
      {
         // Return the description
         if(_fileTypes.ContainsKey(extension))
            return _fileTypes[extension].Description;
         else
            return string.Empty;
      }

      public int GetImageIndex(string extension)
      {
         // Return the description
         if(_fileTypes.ContainsKey(extension))
            return _fileTypes[extension].ImageIndex;
         else
            return -1;
      }
   }
}
