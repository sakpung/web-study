using Leadtools.Medical.Winforms.SecurityOptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leadtools.Medical.Security.AddIn
{
   public partial class SecurityConfigurationDialog : Form
   {
      public SecurityConfigurationDialog()
      {
         InitializeComponent();

         _securityOptionsPresenter.SettingsChanged += _securityOptionsPresenter_SettingsChanged;
         buttonSave.Enabled = false;
      }

      private void _securityOptionsPresenter_SettingsChanged(object sender, EventArgs e)
      {
         buttonSave.Enabled = true;;
      }

      public SecurityOptionsView securityOptionsView
      {
         get
         {
            return securityOptionsView1;
         }
      }

      SecurityOptionsPresenter _securityOptionsPresenter = new SecurityOptionsPresenter();
      public SecurityOptionsPresenter SecurityOptionsPresenter
      {
         get
         {
            return _securityOptionsPresenter;
         }
      }

      private void buttonSave_Click(object sender, EventArgs e)
      {
         _securityOptionsPresenter.SaveOptions();
         buttonSave.Enabled = false;
      }
   }
}
