// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.DataContracts;
using System.IO;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Annotations;
using System.Diagnostics;

namespace Leadtools.Medical.WebViewer.Addins
{
   /// <summary>
   ///This class is not used any more in V17.5 and above
   /// </summary>
   public class AnnotationAddin : IAnnotationAddin
   {
      public AnnotationAddin ( IAnnotationsDataAccessAgent annotationsDataAccess, string annotationsSavePath ) 
      {         
         AnnotationsDataAccess = annotationsDataAccess ;
         AnnotationsSavePath   = annotationsSavePath ;
         
         if ( !Directory.Exists ( annotationsSavePath ) )
         {
            Directory.CreateDirectory ( annotationsSavePath ) ;
         }
      }
      
      public string SaveAnnotations ( string seriesInstanceUID, string annotationData, string userData ) 
      {
         string filePath = GetNewFileName ( AnnotationsSavePath ) ;
         
         File.WriteAllText ( filePath, annotationData ) ;
         
         try
         {
            return AnnotationsDataAccess.SaveAnnotations ( seriesInstanceUID, filePath, userData ) ;
         }
         catch 
         {
            File.Delete ( filePath ) ;
            
            throw ;
         }
      }
      
      public Stream GetAnnotations ( string annotationID, string userData ) 
      {
         string filePath = AnnotationsDataAccess.GetAnnotationsFile ( annotationID ) ;
         
         if ( !string.IsNullOrEmpty ( filePath ) && File.Exists ( filePath ) )
         {
            return new MemoryStream ( Encoding.UTF8.GetBytes ( File.ReadAllText ( filePath ) ) ) ;
         }
         else
         {
            throw new FileNotFoundException ( ) ;
         }
      }
      
      public AnnotationIdentifier[] FindSeriesAnnotations ( string seriesInstanceUID, string userData ) 
      {
         return AnnotationsDataAccess.FindSeriesAnnotations ( seriesInstanceUID ) ;
      }
      
      public void DeleteAnnotations ( string annotationID, string userData ) 
      {
         AnnotationsDataAccess.DeleteAnnotations ( annotationID ) ;
      }
      
      private string GetNewFileName ( string dir )
      {
         int    r1, r2 ;
         bool   bGenerateName = true ;
         int    counter = 0 ;
         string csSuffix = "dat" ;
         string prefix   = "ann_" ;
         string fileName = string.Empty ;

         
         while ( bGenerateName && ( counter < short.MaxValue ) )
         {
            counter++ ;
            
            r1 = _rand.Next ( ) ;
            r2 = _rand.Next ( ) ;

            fileName = prefix ;
            
            fileName += ( r2 % 0xfff ).ToString (  ) + ( r1 % 0xfff ).ToString ( ) ;
            
            fileName = Path.ChangeExtension ( fileName, csSuffix ) ;
            
            fileName = Path.Combine ( dir, fileName ) ;

            bGenerateName = File.Exists ( fileName ) ;
         }

         return fileName ;
      }
      
      static Random _rand = new Random ( ) ;
      
      public IAnnotationsDataAccessAgent AnnotationsDataAccess
      {
         get ;
         set ;
      }

      string AnnotationsSavePath 
      {
         get ;
         set ;
      }
   }
}
