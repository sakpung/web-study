// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using System.Collections.Specialized;

namespace Leadtools.Medical.Winforms
{
   public abstract class LocalAuditLogQueue
   {
      static OrderedDictionary _audits = new OrderedDictionary ( ) ;
      static object _lock = new object ( ) ;
      
      public static void AddAuditMessage ( int id, string message ) 
      {
         lock ( _lock ) 
         {
            if ( _audits.Contains ( id ) )
            {
               _audits.Remove ( id ) ;
            }
            
            _audits.Add ( id, message ) ;
         }
      }
      
      public static void FlushLogs ( Logger logger, string user ) 
      {
         lock ( _lock ) 
         {
            while ( _audits.Count != 0 )
            {
               DicomLogEntry logEntry = new DicomLogEntry ( ) ;
               
               logEntry.ClientAETitle = user ;
               logEntry.Description   = _audits [ 0 ].ToString ( ) ;
               logEntry.LogType       = LogType.Audit ;
               
               logger.Log ( logEntry ) ;
               
               _audits.RemoveAt ( 0 ) ;
            }
         }
      }
      
      public static void Clear ( ) 
      {
         lock ( _lock ) 
         {
            _audits.Clear ( ) ;
         }
      }
   }
}
