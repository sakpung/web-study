// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Leadtools.Medical.Rules.AddIn
{
   public struct Described<T> where T : struct
   {
      private T _Value;

      public Described(T value)
      {
         _Value = value;
      }

      public override string ToString()
      {
         string text = _Value.ToString();
         object[] attr =
                 typeof(T).GetField(text)
                 .GetCustomAttributes(typeof(DescriptionAttribute), false);
         if (attr.Length == 1)
         {
            text = ((DescriptionAttribute)attr[0]).Description;
         }
         return text;
      }

      public static implicit operator Described<T>(T value)
      {
         return new Described<T>(value);
      }

      public static implicit operator T(Described<T> value)
      {
         return value._Value;
      }
   }
}
