// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace JobProcessorServerConfigDemo
{
   class WorkerHelper
   {
      static public List<WorkerData> LoadWorkerData(string workerConfigPath)
      {
         //Load Workers.xml
         XmlDocument xDoc = new XmlDocument();
         xDoc.Load(workerConfigPath);

         List<WorkerData> workerDataList = new List<WorkerData>();
         XmlNodeList workerNodes = xDoc.SelectNodes("//Workers/Worker");
         //Enumerate workers
         foreach (XmlNode workerNode in workerNodes)
         {
            WorkerData workerData = new WorkerData();

            //Load Name.
            workerData.Name = workerNode.Attributes["Name"] != null ? workerNode.Attributes["Name"].Value : String.Empty;

            //Load NewJobCheckPeriod. Use default of 5
            workerData.NewJobCheckPeriod = LoadIntAttribute(workerNode, "NewJobCheckPeriod", 5);

            //Load job types
            workerData.JobTypes = LoadJobTypes(workerNode);

            //Add worker data to list
            workerDataList.Add(workerData);
         }

         return workerDataList;
      }

      static private List<JobType> LoadJobTypes(XmlNode workerNode)
      {
         List<JobType> jobTypeList = new List<JobType>();
         XmlNodeList jobTypeNodes = workerNode.SelectNodes("./JobTypes/JobType");

         //Enumerate job types
         foreach (XmlNode jobTypeNode in jobTypeNodes)
         {
            JobType jobType = new JobType();

            //Load Name.
            jobType.Name = jobTypeNode.Attributes["Name"] != null ? jobTypeNode.Attributes["Name"].Value : String.Empty;

            //Load MaxNumberOfJobs. Use default of 1
            jobType.MaxNumberOfJobs = LoadIntAttribute(jobTypeNode, "MaxNumberOfJobs", 1);

            //Load CPUThreshold. Use default of 80
            jobType.CPUThreshold = LoadIntAttribute(jobTypeNode, "CpuThreshold", 80);

            //Load UseCpuThreshold. Use default of false
            jobType.UseCpuThreshold = LoadBoolAttribute(jobTypeNode, "UseCpuThreshold", false);

            //Load ProgressRate. Use default of 10
            jobType.ProgressRate = LoadIntAttribute(jobTypeNode, "ProgressRate", 10);

            //Load AssumeHangAfter. Use default of 60
            jobType.AssumeHangAfter = LoadIntAttribute(jobTypeNode, "AssumeHangAfter", 60);

            //Load Attempts. Use default of 3
            jobType.Attempts = LoadIntAttribute(jobTypeNode, "Attempts", 3);

            //Add job type data to list
            jobTypeList.Add(jobType);
         }

         return jobTypeList;
      }

      static private int LoadIntAttribute(XmlNode xmlNode, string attributeName, int defaultValue)
      {
         if (xmlNode.Attributes[attributeName] != null)
            Int32.TryParse(xmlNode.Attributes[attributeName].Value, out defaultValue);
         return defaultValue;
      }

      static private bool LoadBoolAttribute(XmlNode xmlNode, string attributeName, bool defaultValue)
      {
         if (xmlNode.Attributes[attributeName] != null)
            Boolean.TryParse(xmlNode.Attributes[attributeName].Value, out defaultValue);
         return defaultValue;
      }

      static public void SaveWorkerData(string workerConfigPath, List<WorkerData> workerDataList)
      {
         XmlDocument xDoc = new XmlDocument();

         // Create root element
         XmlElement root = xDoc.CreateElement("Workers");
         xDoc.AppendChild(root);

         foreach (WorkerData workerData in workerDataList)
         {
            //Create worker node
            XmlElement workerNode = xDoc.CreateElement("Worker");
            workerNode.SetAttribute("Name", workerData.Name);
            workerNode.SetAttribute("NewJobCheckPeriod", workerData.NewJobCheckPeriod.ToString());

            //Create job types node
            XmlElement jobTypesNode = xDoc.CreateElement("JobTypes");
            foreach (JobType jobType in workerData.JobTypes)
            {
               //Create job type node
               XmlElement jobTypeNode = xDoc.CreateElement("JobType");
               jobTypeNode.SetAttribute("Name", jobType.Name);
               jobTypeNode.SetAttribute("MaxNumberOfJobs", jobType.MaxNumberOfJobs.ToString());
               jobTypeNode.SetAttribute("AssumeHangAfter", jobType.AssumeHangAfter.ToString());
               jobTypeNode.SetAttribute("Attempts", jobType.Attempts.ToString());
               jobTypeNode.SetAttribute("CpuThreshold", jobType.CPUThreshold.ToString());
               jobTypeNode.SetAttribute("ProgressRate", jobType.ProgressRate.ToString());
               jobTypeNode.SetAttribute("UseCpuThreshold", jobType.UseCpuThreshold.ToString());

               jobTypesNode.AppendChild(jobTypeNode);
            }

            workerNode.AppendChild(jobTypesNode);
            root.AppendChild(workerNode);
         }

         //Save the profile
         xDoc.Save(workerConfigPath);
      }
   }
}
