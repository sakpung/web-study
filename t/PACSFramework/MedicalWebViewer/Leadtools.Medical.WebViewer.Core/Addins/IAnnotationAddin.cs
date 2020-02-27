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

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   /// <summary>
   /// This is not used anymore. Annotations are being saved/load as a presentation state in DICOM DataSet 
   /// </summary>
   public interface IAnnotationAddin
   {
      string SaveAnnotations ( string seriesInstanceUID, string annotationData, string userData ) ;
      
      Stream GetAnnotations ( string annotationID, string userData ) ;
      
      AnnotationIdentifier[] FindSeriesAnnotations ( string seriesInstanceUID, string userData ) ;
      
      void DeleteAnnotations ( string annotationID, string userData ) ;
   }
}
