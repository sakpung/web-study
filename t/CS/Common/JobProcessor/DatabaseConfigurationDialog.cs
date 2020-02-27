// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Leadtools.Demos;

namespace Leadtools.Common.JobProcessor
{
    public partial class DatabaseConfigurationDialog
    {
        public string ConnectionString
        {
           get
           {
              return _sqlServerConfiguration.ConnectionString;
           }
           set
           {
              _sqlServerConfiguration.ConnectionString = value;
           }
        }

        public bool Overwrite
        {
            get
            {
                return _sqlServerConfiguration.Overwrite;
            }
        }

        private DbConfigurationMode _mode;

        public DbConfigurationMode Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public DatabaseConfigurationDialog()
        {
            InitializeComponent();
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
           SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(ConnectionString);
           if (string.IsNullOrEmpty(sqlConnectionStringBuilder.DataSource))
           {
              Messager.ShowWarning(this, "Enter an SQL Server name.");

               DialogResult = DialogResult.None ;
           }

           if (string.IsNullOrEmpty(sqlConnectionStringBuilder.InitialCatalog))
           {
               Messager.ShowWarning ( this, "Enter a database name." ) ;

               DialogResult = DialogResult.None ;
           }
        }
    }
}
