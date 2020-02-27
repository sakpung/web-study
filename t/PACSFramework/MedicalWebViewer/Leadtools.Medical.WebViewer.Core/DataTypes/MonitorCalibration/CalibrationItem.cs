// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    [DataContract]
   public class CalibrationItem
   {
      private string _CalibrationTime;

        [DataMember]
      public string CalibrationTime
      {
         get
         {
            return _CalibrationTime;
         }
         set
         {
             _CalibrationTime = value;
         }
      }

      private string _Username;

        [DataMember]
      public string Username
      {
         get
         {
            return _Username;
         }
         set
         {
             _Username = value;
         }
      }

      private string _Workstation;

        [DataMember]
      public string Workstation
      {
         get
         {
            return _Workstation;
         }
         set
         {
             _Workstation = value;
         }
      }

      private string _Comments;

        [DataMember]
      public string Comments
      {
         get
         {
            return _Comments;
         }
         set
         {
             _Comments = value;
         }
      }

      public CalibrationItem()
      {         
      }

      public CalibrationItem(DateTime calibrationtime, string username, string workstation, string comments)
          : this()
      {
         _CalibrationTime = calibrationtime.ToString();
         _Username = username;
         _Workstation = workstation;
         _Comments = comments;
      }
   }
}
