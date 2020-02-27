// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Logging;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;
using Leadtools.Dicom.Scu.Common;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

namespace Leadtools.Medical.Rules.AddIn.Common
{
   public class Utils
   {
      public const string CONNECT_REQUEST_SENT = "[Rules] Attempt to connect to server.";
      public const string CONNECT_RESPONSE_RECEIVED = "[Rules] Sucessfully connected to server.";
      public const string CONNECT_RESPONSE_RECEIVED_FAILURE = "[Rules] Failure to connect to server.^{0}";
      public const string ASSOCIATE_REQUEST_SENT = "[Rules] Associate request sent.^{0}";
      public const string ASSOCIATE_REQUEST_REJECTED = "[Rules] Association request rejected.^{0}";
      public const string ASSOCIATE_REQUEST_ACCEPTED = "[Rules] Association request accepted.";
      public const string RELEASE_REQUEST_SENT = "[Rules] Release request sent.";
      public const string RELEASE_RESPONSE_RECEIVED = "[Rules] Release response received.";

      public static void LogEvent(LogType type, MessageDirection messageDirection, string description,
                                  DicomCommandType command, DicomDataSet dataset,
                                  DicomConnection Client, SerializableDictionary<string, object> customInformation)
      {
         try
         {
            string ae = Client.AETitle;
            DicomNet net = Client as DicomNet;
            SerializableDictionary<string, object> logCustomInformation = DicomLogEntry.CustomInformationDicomMessage;

            if (customInformation != null)
            {
               logCustomInformation = new SerializableDictionary<string, object>();
               foreach (KeyValuePair<string, object> kvp in customInformation)
               {
                  logCustomInformation.Add(kvp.Key, kvp.Value);
               }
               logCustomInformation.Add(DicomLogEntry.DicomMessageKey, DicomLogEntry.DicomMessageValue);
            }

            Logger.Global.Log("Rules", Client.CurrentScp.AETitle, Client.CurrentScp.PeerAddress.ToString(),
                              Client.CurrentScp.Port, net.IsAssociated() ? net.Association.Calling : ae,
                              net.HostAddress != null ? net.HostAddress.ToString() : string.Empty,
                              net.IsConnected() ? net.HostPort : -1, command, DateTime.Now, type,
                              messageDirection, description, dataset, logCustomInformation);
         }
         catch (Exception exception)
         {
            Logger.Global.Exception("Rules", exception);
         }
      }

      public static T LoadFromXml<T>(string filename)
      {
         T obj = default(T);

         using (Stream file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
         {
            XmlSerializer s = new XmlSerializer(typeof(T));

            obj = (T)s.Deserialize(file);
            file.Close();
         }
         return obj;
      }

      /// <summary>
      /// Returns true if the specified file is a valid .NET assembly.
      /// </summary>
      /// <param name="file">The path to the file to check.</param>
      /// <returns>True if the specified path points to a valid .NET assembly, otherwise false.</returns>
      /// <remarks>
      /// More information on this algorithm can be found here http://geekswithblogs.net/rupreet/archive/2005/11/02/58873.aspx
      /// </remarks>
      public static bool IsDotNetAssembly(string file)
      {
         uint peHeader;
         uint peHeaderSignature;
         ushort machine;
         ushort sections;
         uint timestamp;
         uint pSymbolTable;
         uint noOfSymbol;
         ushort optionalHeaderSize;
         ushort characteristics;
         ushort dataDictionaryStart;
         uint[] dataDictionaryRVA = new uint[16];
         uint[] dataDictionarySize = new uint[16];

         //get the input stream
         Stream fs = new FileStream(@file, FileMode.Open, FileAccess.Read);

         try
         {
            BinaryReader reader = new BinaryReader(fs);

            //PE Header starts @ 0x3C (60). Its a 4 byte header.
            fs.Position = 0x3C;
            peHeader = reader.ReadUInt32();
            if (peHeader > fs.Length)
            {
               fs.Close();
               return false;
            }

            //Moving to PE Header start location...
            fs.Position = peHeader;
            peHeaderSignature = reader.ReadUInt32();
            //We can also show all these value, but we will be       
            //limiting to the CLI header test.
            machine = reader.ReadUInt16();
            sections = reader.ReadUInt16();
            timestamp = reader.ReadUInt32();
            if (timestamp == 0)
            {
               fs.Close();
               return false;
            }
            pSymbolTable = reader.ReadUInt32();
            noOfSymbol = reader.ReadUInt32();
            optionalHeaderSize = reader.ReadUInt16();
            characteristics = reader.ReadUInt16();
            /*
                Now we are at the end of the PE Header and from here, the
                PE Optional Headers starts...
                To go directly to the datadictionary, we'll increase the      
                stream’s current position to with 96 (0x60). 96 because,
                28 for Standard fields
                68 for NT-specific fields
                From here DataDictionary starts...and its of total 128 bytes. DataDictionay has 16 directories in total,
                doing simple maths 128/16 = 8.
                So each directory is of 8 bytes.
             
                In this 8 bytes, 4 bytes is of RVA and 4 bytes of Size.
                btw, the 15th directory consist of CLR header! if its 0, its not a CLR file :)

                */
            dataDictionaryStart = Convert.ToUInt16(Convert.ToUInt16(fs.Position) + 0x60);
            fs.Position = dataDictionaryStart;
            for (int i = 0; i < 15; i++)
            {
               dataDictionaryRVA[i] = reader.ReadUInt32();
               dataDictionarySize[i] = reader.ReadUInt32();
            }
            if (dataDictionaryRVA[14] == 0)
            {
               fs.Close();
               return false;
            }
            else
            {
               fs.Close();
               return true;
            }
         }
         catch (Exception)
         {
            return false;
         }
         finally
         {
            fs.Close();
         }
      }      

      public static bool IsSequence(long tag)
      {
         DicomTag dcmTag = DicomTagTable.Instance.Find(tag);

         if (dcmTag != null && dcmTag.VR == DicomVRType.SQ)
         {
            return true;
         }
         return false;
      }
   }
}
