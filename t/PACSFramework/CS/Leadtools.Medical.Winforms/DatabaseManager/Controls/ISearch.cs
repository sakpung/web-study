// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer;

namespace Leadtools.Medical.Winforms.DatabaseManager.Controls
{
   interface ISearch
   {
      void PrepareSearchDefault(MatchingParameterCollection matchingCollection);

      void EnableItems(bool enable);

      void Clear();

      void RegisterEvents();

      void Initialize();
   }
}
