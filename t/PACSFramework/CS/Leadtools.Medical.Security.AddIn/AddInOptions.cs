using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Medical.Winforms.SecurityOptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leadtools.Medical.Security.AddIn
{
   public class AddInOptions : MarshalByRefObject, IAddInOptions
   {
      public string Text
      {
         get
         {
            return "DICOM Security";
         }
      }

      public AddInImage Image
      {
         get
         {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
               Properties.Resources.Lock_Icon_32.Save(ms, ImageFormat.Png);
               ms.Position = 0;
               return new Bitmap(ms);
            }
         }

      }

      private void InitializeSecurityOptionsView(string ServerDirectory, SecurityOptionsView securityOptionsView, SecurityOptionsPresenter securityOptionsPresenter)
      {
         if (!string.IsNullOrEmpty(ServerDirectory))
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServerDirectory);

            securityOptionsPresenter.RunView(securityOptionsView, settings);
         }
         else
         {
            securityOptionsPresenter.RunView(securityOptionsView, null);
         }
      }

      public void Configure(IWin32Window Parent, ServerSettings Settings, string ServerDirectory)
      {
         SecurityConfigurationDialog dlg = new SecurityConfigurationDialog();
         
         InitializeSecurityOptionsView(ServerDirectory, dlg.securityOptionsView, dlg.SecurityOptionsPresenter);

         dlg.ShowDialog();
      }
   }
}
