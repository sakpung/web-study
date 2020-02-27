// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.InteropServices;
using Leadtools.Ccow.Web;

namespace Leadtools.Ccow.WebAgents
{
    [Guid("3E1163EA-917F-461a-BF03-300179247903")]
    [ProgId("CCOW.MappingAgent_User")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class UserMappingAgent: WebContextAgent
   {
      private ICcowServiceLocator _serviceLocator;
      public override ICcowServiceLocator Service { get { return _serviceLocator; } }
      public UserMappingAgent()
      {
         _serviceLocator = new ServiceLocator("UserMappingAgent");
      }
   }
}
