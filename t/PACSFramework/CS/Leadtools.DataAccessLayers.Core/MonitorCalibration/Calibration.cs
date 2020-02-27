// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.DataAccessLayers.Core
{
   public class Calibration
   {
      private DateTime _CalibrationTime;

      public DateTime CalibrationTime
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

      public Calibration()
      {         
      }

      public Calibration(DateTime calibrationtime, string username, string workstation, string comments) : this()
      {
          DateTime dt;
         
         _CalibrationTime = calibrationtime;
         _Username = username;
         _Workstation = workstation;
         _Comments = comments;
      }
   }
}
