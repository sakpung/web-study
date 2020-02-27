// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Demos.StorageServer.DataTypes
{
   abstract class AuditMessages
   {
      public static readonly Entry UserLogIn                        = new Entry ( 0, "User Log in: {0}" ) ;
      public static readonly Entry UserLogOff                       = new Entry ( 1, "User Log Off: {0}" ) ;
      public static readonly Entry ServerServiceCreated             = new Entry ( 2, "Service Created: Name={0}, AE Title={1}, IP Address={2}, Port={3}" ) ;
      public static readonly Entry ServerServiceDeleted             = new Entry ( 3, "Service Deleted: Name={0}" ) ;
      public static readonly Entry AeTitleChanged                   = new Entry ( 4, "Server AE Title Changed: {0}" ) ;
      public static readonly Entry IpAddressChanged                 = new Entry ( 5, "Server IP Address Changed: {0}" ) ;
      public static readonly Entry PortChanged                      = new Entry ( 6, "Server Port Changed: {0}" ) ;
      public static readonly Entry ImplementationClassUIDChanged    = new Entry ( 7, "Server Implementation Class UID Changed: {0}" ) ;
      public static readonly Entry ImplementationVersionNameChanged = new Entry ( 8, "Server Implementation Version Name Changed: {0}" ) ;
      public static readonly Entry ServiceStartModeChanged          = new Entry ( 9, "Service Start Mode Changed: {0}" ) ;
      public static readonly Entry DicomFileDeleted                 = new Entry ( 10, "DICOM File Deleted: {0}" ) ;
      public static readonly Entry ImageFileDeleted                 = new Entry ( 11, "Image File Deleted: {0}" ) ;
      public static readonly Entry DicomFileImported                = new Entry ( 12, "DICOM File Imported: {0}" ) ;
      public static readonly Entry NewUserAdded                     = new Entry ( 13, "New User Added: {0}" ) ;
      public static readonly Entry UserRemoved                      = new Entry ( 14, "User Removed: {0}" ) ;
      public static readonly Entry UserPasswordChanged              = new Entry ( 15, "User Password Changed: {0}" ) ;
      public static readonly Entry PermissionAdded                  = new Entry ( 16, "User Permission Granted. User: {0}, Permission: {1}" ) ;
      public static readonly Entry PermissionRemoved                = new Entry ( 17, "User Permission Removed. User: {0}, Permission: {1}" ) ;
      public static readonly Entry DeletingDicomFile                = new Entry ( 18, "User {0} requested to delete DICOM files, Reason: {1}" ) ;
      public static readonly Entry EmptyDatabase                    = new Entry ( 19, "User {0} requested to delete all DICOM files, Reason: {1}" ) ;
   }
   
   public struct Entry
   {
      public Entry ( int key, string message ) 
      {
         _key     = key ;
         _message = message ;
      }
      
      public int    Key     { get { return _key ; } } 
      public string Message { get { return _message ; } }
      
      private int    _key     ;
      private string _message ;
   }
}
