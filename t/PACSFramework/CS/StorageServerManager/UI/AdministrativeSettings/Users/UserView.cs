// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.Winforms;

namespace Leadtools.Demos.StorageServer.UI
{  
   public partial class UserView : UserControl
   {
      private UsersAccountView _UsersAccounts;

      public UsersAccountView UsersAccounts
      {
         get { return _UsersAccounts; }         
      }

      public UserView()
      {
         InitializeComponent();

         _UsersAccounts = new UsersAccountView();
         _UsersAccounts.Dock = DockStyle.Fill;
         Controls.Add(_UsersAccounts);
         _UsersAccounts.ValueChanged += new EventHandler(_UsersAccounts_ValueChanged);
      }

      void _UsersAccounts_ValueChanged(object sender, EventArgs e)
      {
         if (SettingsChanged != null)
         {
            SettingsChanged(sender, e);
         }
      }

      public event EventHandler SettingsChanged;


   }
}
