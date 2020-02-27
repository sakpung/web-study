// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms
{
   public class ConnectionInformation
   {

      public ConnectionInformation()
      {
         _sqlFiles = new List<SqlFileInformation>();
         _canConnect = false;
         _isSqlCe = false;
      }

      private bool _isSqlCe;
      private string _friendlyName;
      private string _connectionString;
      private string _sqlServerVersion;
      private string _sqlDataSource;
      private string _ssqlDatabase;
      private string _computerName;
      private bool _canConnect;
      private string _errorString;

      private List<SqlFileInformation> _sqlFiles;

      public string FriendlyName
      {
         get { return _friendlyName; }
         set { _friendlyName = value; }
      }

      public string ConnectionString
      {
         get { return _connectionString; }
         set { _connectionString = value; }
      }

      public string SqlServerVersion
      {
         get { return _sqlServerVersion; }
         set { _sqlServerVersion = value; }
      }

      public string SqlDataSource
      {
         get { return _sqlDataSource; }
         set { _sqlDataSource = value; }
      }

      public string SsqlDatabase
      {
         get { return _ssqlDatabase; }
         set { _ssqlDatabase = value; }
      }


      public string ComputerName
      {
         get { return _computerName; }
         set { _computerName = value; }
      }

      public List<SqlFileInformation> SqlFiles
      {
         get { return _sqlFiles; }
         set { _sqlFiles = value; }
      }

      public bool CanConnect
      {
         get { return _canConnect; }
         set { _canConnect = value; }
      }

      public string ErrorString
      {
         get { return _errorString; }
         set { _errorString = value; }
      }

      public bool IsSqlCe
      {
         get { return _isSqlCe; }
         set { _isSqlCe = value; }
      }

   }

   public class SqlFileInformation
   {
      private string _name;
      private string _fileid;
      private string _filename;
      private string _filegroup;
      private string _size;
      private string _maxSize;
      private string _growth;
      private string _usage;

      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      public string FileId
      {
         get { return _fileid; }
         set { _fileid = value; }
      }

      public string FileName
      {
         get { return _filename; }
         set { _filename = value; }
      }

      public string FileGroup
      {
         get { return _filegroup; }
         set { _filegroup = value; }
      }

      public string Size
      {
         get { return _size; }
         set { _size = value; }
      }

      public string MaxSize
      {
         get { return _maxSize; }
         set { _maxSize = value; }
      }

      public string Growth
      {
         get { return _growth; }
         set { _growth = value; }
      }

      public string Usage
      {
         get { return _usage; }
         set { _usage = value; }
      }
      
   }
}
