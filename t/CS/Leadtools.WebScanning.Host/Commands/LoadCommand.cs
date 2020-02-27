// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Net;
using Leadtools.Codecs;
using Leadtools.Services.Twain;
using Leadtools.WebScanning.Host;

namespace Leadtools.WebScanning.Commands
{
   /// <summary>
   /// Custom user command implementation for loading the specified Uri, and append the loaded pages to the current scanning session.
   /// </summary>
   public class LoadCommand
   {
      /// <summary>
      /// Run the load command.
      /// </summary>
      /// <param name="id">Scanning session id.</param>
      /// <param name="service">Twain scanning service handle.</param>
      /// <param name="args">Load command arguments.</param>
      public static void Run(string id, TwainScanningService service, LoadCommandArgs args)
      {
         if (args.Uri == null)
            throw new ArgumentNullException("Uri");
         if (args.StartPage < 0)
            throw new ArgumentOutOfRangeException("StartPage", "must be a value greater than or equal to 1");

         if (args.Resolution < 0)
            throw new ArgumentOutOfRangeException("Resolution", "must be a value greater than or equals to 0");

         // Force the uri to be fully qualified, reject everything else for security reasons
         if (args.Uri.IsFile || args.Uri.IsUnc)
            throw new ArgumentException("URL cannot be local file or UNC path.");

         // Use a temp file, much faster than calling Load/Info from a URI directly
         // In a production service, you might want to create a caching mechanism
         string tempFile = Path.GetTempFileName();

         try
         {
            // Download the file
            using (WebClient client = new WebClient())
               client.DownloadFile(args.Uri, tempFile);

            using (RasterCodecs codecs = new RasterCodecs())
            {
               DemoUtils.InitCodecs(codecs, args.Resolution);

               CodecsImageInfo info = codecs.GetInformation(tempFile, true);

               if ((args.EndPage < 0) || (args.EndPage > info.TotalPages))
                  args.EndPage = info.TotalPages;

               for (int pageNumber = args.StartPage; pageNumber <= args.EndPage; pageNumber++)
               {
                  using (RasterImage image = codecs.Load(tempFile, args.BitsPerPixel, CodecsLoadByteOrder.BgrOrGray, pageNumber, pageNumber))
                  {
                     service.AddPage(id, image);
                  }
               }
            }
         }
         finally
         {
            if (File.Exists(tempFile))
            {
               try
               {
                  File.Delete(tempFile);
               }
               catch
               {
                  // Do nothing.
               }
            }
         }
      }
   }

   /// <summary>
   /// Custom Load command arguments.
   /// </summary>
   public class LoadCommandArgs
   {
      public Uri Uri;
      public int StartPage;
      public int EndPage;
      public int Resolution;
      public int BitsPerPixel;

      private LoadCommandArgs()
      {
      }

      public static LoadCommandArgs FromJSON(string json)
      {
         LoadCommandArgs loadArgs = new LoadCommandArgs();

         loadArgs.Uri = new Uri(DemoUtils.JsonStringToString(json, "uri"));
         loadArgs.StartPage = DemoUtils.JsonStringToInteger(json, "startPage");
         loadArgs.EndPage = DemoUtils.JsonStringToInteger(json, "endPage");
         loadArgs.Resolution = DemoUtils.JsonStringToInteger(json, "resolution");
         loadArgs.BitsPerPixel = DemoUtils.JsonStringToInteger(json, "bitsPerPixel");

         return loadArgs;
      }
   }
}
