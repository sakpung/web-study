// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.InteropServices;
using Leadtools.Ccow.Web;

namespace Leadtools.Ccow.WebAgents
{
    [Guid("03A5ACBC-60E0-4edd-ABD1-7FD364D3D65E")]
    [ProgId("CCOW.AnnotationAgent_User")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class UserAnnotationAgent: WebContextAgent
   {
      private ICcowServiceLocator _serviceLocator;
      public override ICcowServiceLocator Service { get { return _serviceLocator; } }
      public UserAnnotationAgent()
      {
         _serviceLocator = new ServiceLocator("UserAnnotationAgent");
      }
   }
}
