// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSCustomizingWorklistDAL.DataTypes
{
   public class WorklistDataSource
   {
      public WorklistDataSource ( ) 
      {
         DatabaseTags = new List<DatabaseDicomTags> ( ) ;
      }
      
      public List<DatabaseDicomTags> DatabaseTags { get ; private set ; }
   }
}
