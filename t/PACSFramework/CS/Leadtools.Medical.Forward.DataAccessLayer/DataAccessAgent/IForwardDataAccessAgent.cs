// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.Forward.DataAccessLayer.DataTypes;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.Medical.Forward.DataAccessLayer
{
   public interface IForwardDataAccessAgent
   {
      /// <summary>
      /// Gets the list of images that need to be forwarded.
      /// </summary>
      /// <returns></returns>
      ForwardInstance[] GetForwardList();
      /// <summary>
      /// Sets the instance as forwarded.
      /// </summary>
      /// <param name="sopInstanceUID">The sop instance UID.</param>
      /// <param name="forwardDate">The forward date.</param>
      /// <param name="expireDate">The expire date.</param>
      void SetInstanceForwarded(string sopInstanceUID, DateTime forwardDate, DateTime? expireDate);

      /// <summary>
      /// Gets the list of images to be cleaned.
      /// </summary>
      ForwardInstance[] GetCleanList();

      // Gets the count of images that need to be forwarded
      long GetForwardCount();

      // Gets the count of images that need to be cleaned
      long GetCleanCount();

      // Resets previously forwarded images so they can be forwarded again
      void Reset(DateRange range);

      // Gets the count of images that can be reset
      long GetResetCount(DateRange range);
      
      // Returns 'true' if the sopInstanceUID has already been forwarded; 'false' otherwise
      bool IsForwarded ( string sopInstanceUID ) ;
   }   
}
