// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadtools.Medical.UserManagementDataAccessLayer
{
   public class User
   {
      public User ( string userName ) 
      : this ( userName, false )
      {
      
      }
      
      public User ( string userName, bool isAdmin ) 
      {
         UserName = userName ;
         IsAdmin  = isAdmin ;
      }
      
      public string UserName
      {
         get
         {
            return _userName ;
         }
         
         set
         {
            _userName = value ;
         }
      }
      
      public bool IsAdmin
      {
         get
         {
            return _isAdmin ;
         }
         
         set
         {
            _isAdmin = value ;
         }
      }
      
      string _userName ;
      bool   _isAdmin ;

#if(LEADTOOLS_V175_OR_LATER)
      public DateTime? Expires { get; set; }
#endif

#if(LEADTOOLS_V19_OR_LATER)
      public bool UseCardReader{ get; set;}

      public string FriendlyName { get; set;}

      public string GetDisplayName()
      {
          string displayName = UserName;
         if (!string.IsNullOrEmpty(FriendlyName))
         {
            displayName = FriendlyName;
         }
         return displayName;
      }

      public string UserType{ get; set;}
#endif
   }
}
