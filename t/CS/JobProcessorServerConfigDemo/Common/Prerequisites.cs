// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Reflection;
using System.IO;

namespace JobProcessorServerConfigDemo
{
   class LeadtoolsService
   {
      public string Title;
      public string Name;
      public bool Tested;
      public string Error;
      public string Type;

      public string GetUrl()
      {
         string url = string.Empty;
         if(String.Compare(Type, "Service", false) == 0)
            url = string.Format(@"http://localhost/{0}/{1}", Globals.VirtualDirName, Name);

         if (String.Compare(Type, "CSOcrJobProcessorClientDemo", false) == 0)
            url = string.Format(@"http://localhost/{0}/{1}", "CS" + Globals.OcrJobProcessorClientDemoName, Name);

         if (String.Compare(Type, "CSMultimediaJobProcessorClientDemo", false) == 0)
            url = string.Format(@"http://localhost/{0}/{1}", "CS"+Globals.MultimediaJobProcessorClientDemoName, Name);

         if (String.Compare(Type, "Media", false) == 0)
             url = string.Format(@"http://localhost/{0}", Globals.JobProcessorFiles);

         return url;
      }
   }

   class Prerequisites
   {
      public IList<LeadtoolsService> Services;
      //public IList<string> ServiceConfigFiles;
      public IList<string> X86Assemblies;
      public IList<string> X64Assemblies;

      public Prerequisites()
      {
         // Read the XML file
         string thisPath = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

         string xmlFileName = Path.Combine(thisPath, "JobProcessorServerConfigDemo.xml");
         if (!File.Exists(xmlFileName))
            throw new Exception(string.Format("Could not find the prerequisites file '{0}'", xmlFileName));

         XPathDocument doc = new XPathDocument(xmlFileName);
         XPathNavigator rootNav = doc.CreateNavigator();

         // Read the services
         XPathNodeIterator servicesIter = rootNav.Select(@"items/services/service");
         if (servicesIter.Count == 0)
            throw new Exception(string.Format("Error reading the services section in the prerequisites file '{0}'", xmlFileName));

         Services = new List<LeadtoolsService>();

         while (servicesIter.MoveNext())
         {
            XPathNavigator serviceNav = servicesIter.Current;
            string title = serviceNav.GetAttribute("title", serviceNav.NamespaceURI);
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(serviceNav.Value))
               throw new Exception(string.Format("Error reading the services section in the prerequisites file '{0}'", xmlFileName));

            string type = serviceNav.GetAttribute("Type", serviceNav.NamespaceURI);
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(serviceNav.Value))
               throw new Exception(string.Format("Error reading the services section in the prerequisites file '{0}'", xmlFileName));

            LeadtoolsService service = new LeadtoolsService();
            service.Title = title;
            service.Name = serviceNav.Value;
            service.Tested = false;
            service.Type = type; ;
            service.Error = null;
            Services.Add(service);
         }

         // Read the assemblies
         XPathNodeIterator assembliesIter = rootNav.Select(@"items/assemblies/assembly");
         if (assembliesIter.Count == 0)
            throw new Exception(string.Format("Error reading the assemblies section in the prerequisites file '{0}'", xmlFileName));

         if (!Globals.X86Ok && !Globals.X64Ok)
            throw new Exception("Could not find the path to either of the LEADTOOLS binaries (x86 or x64).");

         if (!Globals.Is64BitOS && !Globals.X86Ok)
            throw new Exception("The LEADTOOLS Win32 (x86) binaries could not be found on this machine. This machine has a 32-bit operating system and does not support hosting the 64-bit version of the LEADTOOLS JobProcessor components.");

         if (Globals.X86Ok)
            X86Assemblies = new List<string>();
         else
            X86Assemblies = null;

         if (Globals.X64Ok)
            X64Assemblies = new List<string>();
         else
            X64Assemblies = null;

         while (assembliesIter.MoveNext())
         {
            XPathNavigator assemblyNav = assembliesIter.Current;
            string assemblyType = assemblyNav.GetAttribute("type", assemblyNav.NamespaceURI);

            if (string.IsNullOrEmpty(assemblyNav.Value) || string.IsNullOrEmpty(assemblyType))
               throw new Exception(string.Format("Error reading the assemblies section in the prerequisites file '{0}'", xmlFileName));

            bool isCDLL = string.Compare(assemblyType, "cdll") == 0;
            string assemblyName = assemblyNav.Value;

            if (isCDLL)
               assemblyName = assemblyName.ToLower();

            if (Globals.X86Ok)
            {
               string assemblyPath = Path.Combine(Globals.AssembliesPathX86, assemblyName);
               X86Assemblies.Add(assemblyPath);
            }

            if (Globals.X64Ok)
            {
               if (isCDLL)
                  assemblyName = assemblyName.Replace("u.dll", "x.dll");

               string assemblyPath = Path.Combine(Globals.AssembliesPathX64, assemblyName);
               X64Assemblies.Add(assemblyPath);
            }
         }
      }
   }
}
