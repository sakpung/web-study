// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Data;

namespace Leadtools.Demos.Database
{
   /// <summary>
   /// Summary description for DBBase.
   /// </summary>
   public class DBBase
   {
      protected DataSet ds = new DataSet("DICOMSVR");
      protected string dbFileName;

      public int Count
      {
         get
         {
            return ds.Tables[0].Rows.Count;
         }
      }

      public DataSet DB
      {
         get
         {
            return ds;
         }
      }

      public DBBase( )
      {
         //
         // TODO: Add constructor logic here
         //
      }

      protected bool LoadDatabase( )
      {
         bool loaded = true;

         try
         {
            ds.ReadXml(dbFileName);
         }
         catch
         {
            loaded = false;
         }
         return loaded;
      }

      public bool Save( )
      {
         bool ret = false;

         try
         {
            ds.WriteXml(dbFileName, XmlWriteMode.WriteSchema);
            ret = true;
         }
         catch
         {
         }
         return ret;
      }
   }
}
