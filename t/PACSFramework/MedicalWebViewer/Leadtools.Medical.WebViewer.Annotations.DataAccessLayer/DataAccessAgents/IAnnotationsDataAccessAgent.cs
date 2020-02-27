// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer;
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;

namespace Leadtools.Medical.WebViewer.Annotations
{
   public interface IAnnotationsDataAccessAgent
   {
      string SaveAnnotations ( string seriesInstanceUID, string filePath, string userData ) ;
      
      string GetAnnotationsFile ( string annotationID ) ;
      
      AnnotationIdentifier[] FindSeriesAnnotations ( string seriesInstanceUID ) ;
      
      void DeleteAnnotations ( string annotationID ) ;
   }
}
