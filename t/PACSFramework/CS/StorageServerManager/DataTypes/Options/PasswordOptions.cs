// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Demos.StorageServer.DataTypes.Options
{
   [Flags]
   public enum Complexity
   {
      None = 0,
      Lowercase = 1,
      Uppercase = 2,
      Symbol = 4,
      Numbers = 8
   }

   [Serializable]
   public class PasswordOptions : ICloneable
   {
      public Complexity Complexity { get; set; }
      public int MinimumLength { get; set; }
      public int DaysToExpire { get; set; }
      public int MaxPasswordHistory { get; set; }
      public int IdleTimeOut { get; set; }
      public bool EnableIdleTimeout { get; set; }

      public PasswordOptions()
      {
         IdleTimeOut = 60;
         EnableIdleTimeout = true;
      }

      #region ICloneable Members

      public object Clone()
      {
         return this.Clone<PasswordOptions>();
      }

      #endregion
   }
}
