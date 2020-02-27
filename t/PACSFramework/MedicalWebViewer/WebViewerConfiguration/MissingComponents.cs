// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

using Leadtools.Demos;
using System.Reflection;

namespace WebViewerConfiguration
{
    public partial class MissingComponents : Form
    {
        public MissingComponents(String details)
        {
            InitializeComponent();
            lblErrorDetails.Text = details;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public static string BinariesDirectory
        {
            get
            {
                string binaries;

                if (!DemosGlobal.Is64Process())
                {
                    binaries = "Win32";
                }
                else
                {
                    binaries = "x64";
                }

                String InstallDirectory = DemosGlobal.InstallLocation;
                return InstallDirectory + Path.DirectorySeparatorChar + "Bin" + Path.DirectorySeparatorChar + "Dotnet" + Path.DirectorySeparatorChar + binaries;
            }
        }

       private static string _exeDirectory = string.Empty;
       public static string ExeDirectory
       {
          get
          {
            if (string.IsNullOrEmpty(_exeDirectory))
            {
               _exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
             return _exeDirectory;
          }
       }

       private static string MyPathCombine(string p1, string p2, string p3)
       {
          string s = Path.Combine(p1, Path.Combine(p2, p3));
          return s;
       }


        public static void ShowTroubleShootingGuide(string page)
       {
          if (File.Exists(Path.Combine(BinariesDirectory, page)))
          {
             Process.Start(Path.Combine(BinariesDirectory, page));
          }
          else if (File.Exists(Path.Combine(ExeDirectory, page)))
          {
             Process.Start(Path.Combine(ExeDirectory, page));
          }
          else
          {
             Messager.ShowWarning(null, "Couldn't find the troubleshooting guide.");
          }
       }


        public static void ShowInstallationGuide(string page)
        {
         Process.Start("https://www.leadtools.com/support/guides/MedicalWebViewer-IIS-Requirements.pdf");
        }

       private void btnViewGuide_Click(object sender, EventArgs e)
        {

            try
            {
                ShowInstallationGuide("default.htm");
            }
            catch (Exception exception)
            {
                Messager.ShowError(this, exception.Message);
            }

            this.Close();
        }
    }
}
