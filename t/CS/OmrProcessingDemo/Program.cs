using Leadtools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmrProcessingDemo
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {

         if (Leadtools.Demos.Support.SetLicense(false) == false)
         {
            return;
         }

         if (RasterSupport.IsLocked(RasterSupportType.Omr))
         {
            MessageBox.Show("OMR support must be unlocked.  Application will exit.");

            return;
         }

         try
         {
            MainForm.GetOmrEngine();
         }
         catch (Exception)
         {
            MessageBox.Show("Unable to initialize OMR engine.  Application will exit.");

            return;
         }



         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }
   }
}
