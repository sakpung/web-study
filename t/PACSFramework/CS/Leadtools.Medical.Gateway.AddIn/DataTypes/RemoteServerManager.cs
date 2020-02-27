// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Common;

namespace Leadtools.Medical.Gateway.CFindAddin.DataTypes
{
   class GatewayServersManager
   {
      public GatewayServersManager ( GatewayServer gateway ) 
      {
         Init ( gateway ) ;
      }
      
      public void Reset ( GatewayServer gateway )
      {
         Init ( gateway ) ;
      }

      public AeInfo GetRemoteServer ( ) 
      {
         if ( Servers.Count == 0 )
         {
            return null ;
         }
         else
         {
            if ( __CurrentServerIndex != 0 )
            {
               if ( __CurrentServerUsage >= NumberOfTimesToUseSecondaryServer ) 
               {
                  SetPrimaryServer ( ) ;
               }
               
               __CurrentServerUsage++ ;
            }
            
            return Servers [ __CurrentServerIndex ] ;
         }
      }

      public void SetRemoteServerConnectionFailure ( )
      {
         SetNextServer ( ) ;
      }

      public GatewayServer Gateway
      {
         get ;
         private set ;
      }
      
      public List<AeInfo> Servers
      {
         get 
         {
            if ( null != Gateway )
            {
               return Gateway.RemoteServers ;
            }
            else
            {
               return null ;
            }
         }
         
      }
      
      public int NumberOfTimesToUseSecondaryServer
      {
         get 
         {
            if ( null != Gateway )
            {
               return Gateway.NumberOfTimesToUseSecondaryServer ;
            }
            else
            {
               return 0 ;
            }
         }
         
         set 
         {
            if ( null != Gateway )
            {
               Gateway.NumberOfTimesToUseSecondaryServer = value ;
            }
            else
            {
               throw new InvalidOperationException ( "No Gateway available." ) ;
            }
         }
      }
      
      private void Init ( GatewayServer gateway )
      {
         Gateway                           = gateway ;
         
         __CurrentServerIndex = 0 ;
         __CurrentServerUsage = 0 ;
      }
      
      private void SetPrimaryServer ( )
      {
         __CurrentServerUsage = 0 ;
         __CurrentServerIndex = 0 ;
      }
      
      private void SetNextServer ( )
      {
         if ( __CurrentServerIndex < Servers.Count - 1 )
         {
            __CurrentServerIndex++ ;
         }
         else
         {
            __CurrentServerIndex = 0 ;
         }
            
         __CurrentServerUsage = 0 ;
      }
      
      private int __CurrentServerIndex
      {
         get ;
         set ;
      }
      
      private int __CurrentServerUsage
      {
         get ;
         set ;
      }
   }
}
