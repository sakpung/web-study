// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Data;
using System.Data.SqlClient;

namespace Leadtools.Demos.Database
{
   /// <summary>
   /// Holds user info.
   /// </summary>
   public class UserInfo
   {
      private string _AETitle;
      private string _IPAddress;
      internal string _Id;
      private int _Port;
      private int _Timeout;

      public string Id
      {
         get
         {
            return _Id;
         }
      }

      public string AETitle
      {
         get
         {
            return _AETitle;
         }
         set
         {
            _AETitle = value;
         }
      }

      public string IPAddress
      {
         get
         {
            return _IPAddress;
         }
         set
         {
            _IPAddress = value;
         }
      }

      public int Port
      {
         get
         {
            return _Port;
         }
         set
         {
            _Port = value;
         }
      }

      public int Timeout
      {
         get
         {
            return _Timeout;
         }
         set
         {
            _Timeout = value;
         }
      }

      public UserInfo( )
      {
      }
   }

   /// <summary>
   /// Summary description for User.
   /// </summary>
   public class UsersDB : DBBase
   {
      public UsersDB(string dbFileName)
      {
         this.dbFileName = dbFileName;

         if(!LoadDatabase())
         {
            CreateDatabase();
         }
      }

      private bool CreateDatabase( )
      {
         bool created = true;

         try
         {
            DataTable table;

            table = ds.Tables.Add("Users");
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("AETitle", typeof(string));
            table.Columns.Add("IPAddress", typeof(string));
            table.Columns.Add("Port", typeof(int));
            table.Columns.Add("Timeout", typeof(int));

            Save();
         }
         catch
         {
            created = false;
         }

         return created;
      }

      public bool AddUser(ref UserInfo user)
      {
         bool added = false;
         DataRow dr;

         dr = ds.Tables["Users"].NewRow();
         if(dr != null)
         {
            string id = Guid.NewGuid().ToString();

            dr["Id"] = id;
            dr["AETitle"] = user.AETitle;
            dr["IPAddress"] = user.IPAddress;
            dr["Port"] = user.Port;
            dr["Timeout"] = user.Timeout;

            ds.Tables["Users"].Rows.Add(dr);
            user._Id = id;
         }
         return added;
      }

      public UserInfo LoadUser(int i)
      {
         UserInfo user = new UserInfo();
         DataRow dr;

         dr = ds.Tables["Users"].Rows[i];
         if(dr != null)
         {
            user._Id = dr["Id"].ToString();
            user.AETitle = dr["AETitle"].ToString();
            user.IPAddress = dr["IPAddress"].ToString();
            user.Port = Convert.ToInt32(dr["Port"]);
            user.Timeout = Convert.ToInt32(dr["Timeout"]);
         }

         return user;
      }

      public UserInfo LoadUser(string id)
      {
         UserInfo user = new UserInfo();
         DataView dv = new DataView(ds.Tables["Users"]);
         if(dv != null)
         {
            dv.RowFilter = "Id = '" + id + "'";
            user._Id = dv[0]["Id"].ToString();
            user.AETitle = dv[0]["AETitle"].ToString();
            user.IPAddress = dv[0]["IPAddress"].ToString();
            user.Port = Convert.ToInt32(dv[0]["Port"]);
            user.Timeout = Convert.ToInt32(dv[0]["Timeout"]);
         }

         return user;
      }

      public UserInfo LoadUser(string ipAddress, string aeTitle)
      {
         UserInfo user = new UserInfo();
         DataView dv = new DataView(ds.Tables["Users"]);
         ipAddress = Demos.DemosGlobal.CleanIp(ipAddress);
         if(dv != null)
         {
            string filter;

            filter = "IPAddress = '" + ipAddress + "' ";
            filter += "AND AETitle = '" + aeTitle + "'";
            dv.RowFilter = filter;

            if (dv.Count == 0)
                return null;

            user._Id = dv[0]["Id"].ToString();
            user.AETitle = dv[0]["AETitle"].ToString();
            user.IPAddress = dv[0]["IPAddress"].ToString();
            user.Port = Convert.ToInt32(dv[0]["Port"]);
            user.Timeout = Convert.ToInt32(dv[0]["Timeout"]);
         }

         return user;
      }

       public UserInfo LoadMoveAE(string aeTitle)
       {
           UserInfo user = new UserInfo();
           DataView dv = new DataView(ds.Tables["Users"]);
           if (dv != null)
           {
               string filter;
              
               filter = "AETitle = '" + aeTitle + "'";
               dv.RowFilter = filter;

               if (dv.Count == 0)
                   return null;

               user._Id = dv[0]["Id"].ToString();
               user.AETitle = dv[0]["AETitle"].ToString();
               user.IPAddress = dv[0]["IPAddress"].ToString();
               user.Port = Convert.ToInt32(dv[0]["Port"]);
               user.Timeout = Convert.ToInt32(dv[0]["Timeout"]);
           }

           return user;
       }

      public void UpdateUser(UserInfo user)
      {
         DataView dv = new DataView(ds.Tables["Users"]);

         if(dv != null)
         {
             dv.RowFilter = "Id = '" + user.Id + "'";
             dv[0].BeginEdit();
             dv[0]["AETitle"] = user.AETitle;
             dv[0]["IPAddress"] = user.IPAddress;
             dv[0]["Port"] = user.Port;
             dv[0]["Timeout"] = user.Timeout;
             dv[0].EndEdit();
         }
      }

      public void RemoveUser(string id)
      {
         DataView dv = new DataView(ds.Tables["Users"]);

         if(dv != null)
         {
            DataRow dr;

            dv.RowFilter = "Id = '" + id + "'";
            dr = dv[0].Row;
            if(dr != null)
            {
               ds.Tables["Users"].Rows.Remove(dr);
            }
         }
      }

      public bool FindUser(string ipAddress)
      {
         DataView dv = new DataView(ds.Tables["Users"]);

         if(dv != null)
         {
            ipAddress = Demos.DemosGlobal.CleanIp(ipAddress);
            dv.RowFilter = "IPAddress = '" + ipAddress + "'";
            return dv.Count > 0;
         }
         return false;
      }

      public bool FindUser(string ipAddress, string aeTitle)
      {
         DataView dv = new DataView(ds.Tables["Users"]);

         if(dv != null)
         {
            string filter;
            ipAddress = Demos.DemosGlobal.CleanIp(ipAddress);
            filter = "IPAddress = '" + ipAddress + "' ";
            filter += "AND AETitle = '" + aeTitle + "'";
            dv.RowFilter = filter;
            return dv.Count > 0;
         }
         return false;
      }
   }
}
