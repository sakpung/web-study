// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Windows.Forms ;

namespace Leadtools.Medical.Winforms.Control
{
      interface ILogViewControl
      {
         event EventHandler DeleteRequest ;
         event EventHandler DetailsRequest ;
         
         void EnableQueryControl ( bool bEnable ) ;
      }
}
