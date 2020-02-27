// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.InteropServices;
using Leadtools.Ccow.Web;

namespace Leadtools.Ccow.WebAgents
{
   [Guid("41F35C5E-F008-417a-B5AA-65030F8C8C72")]
   [ProgId("CCOW.MappingAgent_Patient")]
   [ClassInterface(ClassInterfaceType.None)]
   [ComVisible(true)]
   public class PatientMappingAgent : WebContextAgent
   {
      private ICcowServiceLocator _serviceLocator;
      public override ICcowServiceLocator Service { get { return _serviceLocator; } }
      public PatientMappingAgent()
      {
         _serviceLocator = new ServiceLocator("PatientMappingAgent");
      }
   }
}
