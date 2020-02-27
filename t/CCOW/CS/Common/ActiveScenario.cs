// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace Leadtools.Demos
{    
    public class ActiveScenario
    {
        public string Filename { get; set; }

        [XmlIgnore]
        public Scenario Scenario { get; set; }

        public ActiveScenario()
        {
            Filename = string.Empty;
        }        

        public static ActiveScenario Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ActiveScenario));
            string filename = CCOWUtils.GetActiveScenarioFilename();            
            ActiveScenario settings = null;

            if (File.Exists(filename))
            {
                settings = Deserialize<ActiveScenario>(filename);
            }

            if (settings == null)
            {
                settings = new ActiveScenario();
                settings.Filename = Application.StartupPath + @"\P1_Default.scn";
            }

            if (!string.IsNullOrEmpty(settings.Filename))
            {
                settings.Scenario = Deserialize<Scenario>(settings.Filename);
            }            

            return settings;
        }

        private static T Deserialize<T>(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T serObject = default(T);

            if (File.Exists(filename))
            {
                using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    try
                    {
                        serObject = (T)serializer.Deserialize(stream);
                        stream.Close();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            if (serObject == null)
                serObject = default(T);
            return serObject;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ActiveScenario));
            string filename = CCOWUtils.GetActiveScenarioFilename();

            using (TextWriter writer = new StreamWriter(filename))
            {
                try
                {
                    serializer.Serialize(writer, this);
                    writer.Close();
                }
                catch { }
            }
        }        
    }
}
