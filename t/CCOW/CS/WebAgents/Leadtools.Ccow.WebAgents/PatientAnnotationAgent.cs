// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Runtime.InteropServices;
using Leadtools.Ccow.Web;

namespace Leadtools.Ccow.WebAgents
{
   [Guid("A299EE7E-B4DF-4ef8-B641-4B985786A18C")]
   [ProgId("CCOW.AnnotationAgent_Patient")]
   [ClassInterface(ClassInterfaceType.None)]
   [ComVisible(true)]
   public class PatientAnnotationAgent : WebContextAgent
   {
      private ICcowServiceLocator _serviceLocator;
      public override ICcowServiceLocator Service { get { return _serviceLocator; } }
      public PatientAnnotationAgent()
      {
         _serviceLocator = new ServiceLocator("PatientAnnotationAgent");
      }
   }
}
