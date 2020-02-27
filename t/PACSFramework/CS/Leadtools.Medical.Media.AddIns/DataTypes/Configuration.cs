// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.Media.AddIns
{
   [Serializable]
   public class MediaAddInConfiguration
   {
      public MediaAddInConfiguration ( ) 
      {
         Folders = new List<string> ( ) ;
         Files   = new List<string> ( ) ;
         
         ViewerSize          = 0 ;
         FilesAndFoldersSize = 0 ;
      }
      
      public MediaAddInConfiguration ( string mediaFolder, string defaultProfile ) 
      : this ( ) 
      {
         MediaFolder    = mediaFolder ;
         DefaultProfile = defaultProfile ;
      }
      
      public string MediaFolder
      {
         get ;
         set ;
      }
      
      public string DefaultProfile
      {
         get ;
         set ;
      }

      public bool ValidateReferencedSopInstances
      {
         get;
         set;
      }
      
      public bool IncludeViewer
      {
         get ;
         set ;
      }
      
      public string AutoRunViewerFile
      {
         get ;
         set ;
      }
      
      public string ViewerDirectory
      {
         get ;
         set ;
      }
      
      public List<string> Folders
      {
         get ;
         set ;
      }
      
      public List<string> Files
      {
         get ;
         set ;
      }
      
      public double ViewerSize
      {
         get ;
         set ;
      }
      
      public double FilesAndFoldersSize
      {
         get ;
         set ;
      }
      
      public void AddViewerAutorunFile ( string fileName )
      {
         AutoRunViewerFile = fileName ;
         
         if ( !Files.Contains ( fileName ) )
         {
            Files.Add ( fileName ) ;
         }
      }
      
      public string RemoveViewerAutorunFile (  )
      {
         string fileName ;
         
         
         fileName = AutoRunViewerFile  ;
         
         if ( !string.IsNullOrEmpty ( fileName ) && Files.Contains ( fileName ) )
         {
            Files.Remove ( fileName ) ;
         }
         
         return fileName ;
      }
   }
}
