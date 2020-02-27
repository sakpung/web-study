// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using Leadtools.Annotations.Engine;

namespace Leadtools.Annotations.WinForms
{
   public class Tools
   {
      public const string SeparatorMenuItem = "-";

      public static AnnResources LoadResources()
      {
         var resources = new AnnResources();
         var rubberStampsResources = resources.RubberStamps;
         var imagesResources = resources.Images;
#if (FOR_JAPANESE)
         var resourcePath = "Leadtools.Annotations.WinForms.Resources.StampsJpn";
#else
         var resourcePath = "Leadtools.Annotations.WinForms.Resources.Stamps";
#endif

         rubberStampsResources.Add(AnnRubberStampType.StampApproved, LoadImageFromResource(resourcePath, "Approved.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampAssigned, LoadImageFromResource(resourcePath , "Assigned.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampClient, LoadImageFromResource(resourcePath ,"Client.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampChecked, LoadImageFromResource(resourcePath, "Checked.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampCopy, LoadImageFromResource(resourcePath, "Copy.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampDraft, LoadImageFromResource(resourcePath, "Draft.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampExtended, LoadImageFromResource(resourcePath, "Extended.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampFax, LoadImageFromResource(resourcePath, "Fax.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampFaxed, LoadImageFromResource(resourcePath, "Faxed.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampImportant, LoadImageFromResource(resourcePath, "Important.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampInvoice, LoadImageFromResource(resourcePath, "Invoice.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampNotice, LoadImageFromResource(resourcePath, "Notice.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampPaid, LoadImageFromResource(resourcePath, "Paid.png"));

         rubberStampsResources.Add(AnnRubberStampType.StampOfficial, LoadImageFromResource(resourcePath, "Official.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampOnFile, LoadImageFromResource(resourcePath, "OnFile.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampPassed, LoadImageFromResource(resourcePath, "Passed.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampPending, LoadImageFromResource(resourcePath, "Pending.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampProcessed, LoadImageFromResource(resourcePath, "Processed.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampReceived, LoadImageFromResource(resourcePath, "Received.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampRejected, LoadImageFromResource(resourcePath, "Rejected.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampRelease, LoadImageFromResource(resourcePath, "Release.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampSent, LoadImageFromResource(resourcePath, "Sent.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampShipped, LoadImageFromResource(resourcePath, "Shipped.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampTopSecret, LoadImageFromResource(resourcePath, "TopSecret.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampUrgent, LoadImageFromResource(resourcePath, "Urgent.png"));
         rubberStampsResources.Add(AnnRubberStampType.StampVoid, LoadImageFromResource(resourcePath, "Void.png"));

         resourcePath = "Leadtools.Annotations.WinForms.Resources";
         imagesResources.Add(LoadImageFromResource(resourcePath ,"Point.png"));
         imagesResources.Add(LoadImageFromResource(resourcePath, "Lock.png"));
         imagesResources.Add(LoadImageFromResource(resourcePath, "Hotspot.png"));
         imagesResources.Add(LoadImageFromResource(resourcePath, "Audio.png"));
         imagesResources.Add(LoadImageFromResource(resourcePath, "Video.png"));
         imagesResources.Add(LoadImageFromResource(resourcePath, "EncryptPrimary.png"));
         imagesResources.Add(LoadImageFromResource(resourcePath, "EncryptSecondary.png"));
         imagesResources.Add(LoadImageFromResource(resourcePath, "Content.png"));
         imagesResources.Add(LoadImageFromResource(resourcePath, "StickyNote.png"));

         return resources;
      }

      private static AnnPicture LoadImageFromResource(string path, string resource)
      {
         using (var stream = typeof(Tools).Assembly.GetManifestResourceStream(string.Format("{0}.{1}", path, resource)))
         {
            using (var bitmap = new Bitmap(stream))
            {
               if (resource != "Point.png")
                  bitmap.MakeTransparent(Color.White);
               using (var ms = new MemoryStream())
               {
                  bitmap.Save(ms, ImageFormat.Png);
                  var data = ms.ToArray();
                  return new AnnPicture(data);
               }
            }
         }
      }

      public static Bitmap LoadImageFromResource(Type type, string path, string resource)
      {
         var stream = type.Assembly.GetManifestResourceStream(string.Format("{0}.{1}", path, resource));
         return new Bitmap(stream);
      }
   }
}
