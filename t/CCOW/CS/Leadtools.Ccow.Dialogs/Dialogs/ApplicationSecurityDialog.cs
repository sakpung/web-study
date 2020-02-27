// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Windows.Forms;

namespace Leadtools.Ccow.Dialogs
{
   public partial class ApplicationSecurityDialog : Form
   {
      public string Security
      {
         get
         {
            return comboBoxSecurity.Text;
         }
         set
         {
            comboBoxSecurity.Text = value;
         }
      }

      public ApplicationSecurityDialog()
      {
         InitializeComponent();
      }
   }
}
