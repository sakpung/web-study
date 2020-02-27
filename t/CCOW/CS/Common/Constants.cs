// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Leadtools.Demos
{
    public class Constants
    {        
        public static string InstallLocation
        {
            get
            {
                string regKey = string.Empty;
                string location = string.Empty;

                regKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{5ADEDEED-1ED0-40F7-88A7-C6D485CDBDBD}";
                if (regKey.Length != 0)
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(regKey);

                    if (key != null)
                    {
                        object value = key.GetValue("InstallLocation");

                        key.Close();
                        if (value != null)
                            location = value.ToString();
                    }
                }

                if (location == string.Empty)
                {
                    location = System.Windows.Forms.Application.StartupPath;
                }
                return location;
            }
        }
    }
}
