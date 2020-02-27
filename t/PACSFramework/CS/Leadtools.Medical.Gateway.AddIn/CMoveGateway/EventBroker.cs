// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;

namespace Leadtools.Medical.Gateway
{
   class ServerEventBroker
   {
      public void PublishEvent <T> ( object publisher, T eventArgs ) where T : EventArgs
      {
         Type argsType = typeof ( T ) ;


         if ( __EventArgsHandlers.ContainsKey ( argsType ) )
         {
            foreach ( EventHandler<T> handler in __EventArgsHandlers [ argsType ].OfType <EventHandler<T>> ( ).ToArray ( ) )
            {
               handler ( publisher, eventArgs ) ;
            }
         }
      }

      public void Subscribe <T> ( EventHandler<T> onEventExecuted ) where T : EventArgs
      {
         Type argsType = typeof ( T ) ;


         if ( !__EventArgsHandlers.ContainsKey ( argsType ) )
         {
            __EventArgsHandlers [ argsType ] = new List<object> ( ) ;
         }
               
         __EventArgsHandlers [ argsType ].Add ( onEventExecuted ) ;
      }

      public void Unsubscribe <T> ( EventHandler<T> onEventExecuted ) where T : EventArgs
      {
         Type argsType = typeof ( T ) ;


         if ( !__EventArgsHandlers.ContainsKey ( argsType ) )
         {
            return ;
         }
               
         __EventArgsHandlers [ argsType ].Remove ( onEventExecuted ) ;
      }

      private ServerEventBroker ( ) 
      {
         __EventArgsHandlers = new Dictionary<Type,List<object>> ( ) ;
      }

      public static ServerEventBroker Instance
      {
         get
         {
            return _instance ;
         }
      }

      static ServerEventBroker ( ) 
      {
         _instance = new ServerEventBroker ( ) ;
      }

      private static ServerEventBroker _instance ;

      private Dictionary <Type,List <object>> __EventArgsHandlers {get ;set ;}
   }
}
