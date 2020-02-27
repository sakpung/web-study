// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Document.Service.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace Leadtools.Document.Service.Document
{
   [DataContract]
   public class LEADDocument
   {
      public const string MetadataKey_IsLinearized = "isLinearized";
      public const string PostUpload_LinearizePdfMinimumLength = "PostUpload_LinearizePdfMinimumLength";

      [DataMember(Name = "documentId")]
      public string DocumentId;

      [DataMember(Name = "name")]
      public string Name;

      [DataMember(Name = "mimeType")]
      public string MimeType;

      [DataMember(Name = "userId")]
      public string UserId;

      [DataMember(Name = "documentType")]
      public string DocumentType;

      [DataMember(Name = "viewOptions")]
      public DocumentViewOptions ViewOptions;

      [DataMember(Name = "fileLength")]
      public long FileLength;

      [DataMember(Name = "isEncrypted")]
      public bool IsEncrypted;

      [DataMember(Name = "isDecrypted")]
      public bool IsDecrypted;

      [DataMember(Name = "format")]
      public RasterImageFormat Format;

      [DataMember(Name = "metadata")]
      public Dictionary<string, string> Metadata;

      [DataMember(Name = "uri")]
      public Uri Uri;

      [DataMember(Name = "isReadOnly")]
      public bool IsReadOnly;

      [DataMember(Name = "isStructureSupported")]
      public bool IsStructureSupported;

      [DataMember(Name = "structure")]
      public DocumentStructure Structure;

      [DataMember(Name = "images")]
      public DocumentImages Images;

      [DataMember(Name = "text")]
      public DocumentText Text;

      [DataMember(Name = "history")]
      public DocumentHistory History;

      [DataMember(Name = "annotations")]
      public DocumentAnnotations Annotations;

      [DataMember(Name = "pages")]
      public DocumentPages Pages;

      [DataMember(Name = "documents")]
      public DocumentDocuments Documents;

      public const double UnitsPerInch = 720.0;

      public static int DocumentToPixels(double resolution, double value)
      {
         if (LeadDoubleTools.IsZero(resolution))
            resolution = 96.0;

         return (int)((value / UnitsPerInch) * resolution + 0.5);
      }

      public static double PixelsToDocument(double resolution, int value)
      {
         if (LeadDoubleTools.IsZero(resolution))
            resolution = 96.0;

         return value * UnitsPerInch / resolution;
      }

      public LeadPoint PointToPixels(LeadPoint value)
      {
         if (value.IsEmpty)
            return LeadPoint.Empty;

         var resolution = this.Pages.DefaultResolution;
         return LeadPoint.Create(DocumentToPixels(resolution, value.X), DocumentToPixels(resolution, value.Y));
      }

      public LeadPoint PointToDocument(LeadPoint value)
      {
         var resolution = this.Pages.DefaultResolution;
         return LeadPoint.Create(PixelsToDocument(resolution, (int)value.X), PixelsToDocument(resolution, (int)value.Y));
      }

      public LeadSize SizeToPixels(LeadSize value)
      {
         if (value.IsEmpty)
            return LeadSize.Empty;

         var resolution = this.Pages.DefaultResolution;
         return LeadSize.Create(DocumentToPixels(resolution, value.Width), DocumentToPixels(resolution, value.Height));
      }

      public LeadSize SizeToDocument(LeadSize value)
      {
         var resolution = this.Pages.DefaultResolution;
         return LeadSize.Create(PixelsToDocument(resolution, (int)value.Width), PixelsToDocument(resolution, (int)value.Height));
      }

      public LeadRect RectToPixels(LeadRect value)
      {
         if (value.IsEmpty)
            return LeadRect.Empty;

         var resolution = this.Pages.DefaultResolution;
         return LeadRect.FromLTRB(
            DocumentToPixels(resolution, value.Left),
            DocumentToPixels(resolution, value.Top),
            DocumentToPixels(resolution, value.Right),
            DocumentToPixels(resolution, value.Bottom));
      }

      public LeadRect RectToDocument(LeadRect value)
      {
         var resolution = this.Pages.DefaultResolution;
         return LeadRect.FromLTRB(
            PixelsToDocument(resolution, (int)value.Left),
            PixelsToDocument(resolution, (int)value.Top),
            PixelsToDocument(resolution, (int)value.Right),
            PixelsToDocument(resolution, (int)value.Bottom));
      }

      public static LEADDocument FromJSON(object jsonObject)
      {
         return Parse(jsonObject);
      }

      public static LEADDocument FromJSON(string json)
      {
         dynamic result = JsonConvert.DeserializeObject(json);
         return Parse(result);
      }

      private static LEADDocument Parse(dynamic result)
      {
         var document = new LEADDocument();
         document.DocumentId = result.values.documentId;
         document.Name = result.values.name;
         document.FileLength = result.values.fileLength;
         document.MimeType = result.values.mimeType;
         document.UserId = result.values.userId;
         document.DocumentType = result.values.documentType;
         document.IsEncrypted = result.values.isEncrypted;
         document.IsDecrypted = result.values.isDecrypted;
         document.Format = (RasterImageFormat)result.values.format;
         document.Uri = result.values.uri;
         document.IsReadOnly = result.values.isReadOnly;
         document.IsStructureSupported = result.values.isStructureSupported;

         // Metadata
         var metadata = result.metadata.ToObject<Dictionary<string, string>>();
         document.Metadata = new Dictionary<string, string>();
         foreach (var item in metadata)
         {
            document.Metadata.Add(item.Key, item.Value);
         }

         // Structure
         if (document.IsStructureSupported)
         {
            document.Structure = new DocumentStructure();
            document.Structure.IsParsed = result.values.isStructureParsed;
         }

         // Images
         document.Images = new DocumentImages();
         document.Images.IsSvgSupported = result.values.isSvgSupported;
         document.Images.IsSvgViewingPreferred = result.values.isSvgViewingPreferred;
         document.Images.IsResolutionsSupported = result.values.isResolutionsSupported;
         document.Images.DefaultBitsPerPixel = result.values.defaultBitsPerPixel;
         document.Images.MaximumImagePixelSize = result.values.maximumImagePixelSize;
         document.Images.ThumbnailPixelSize = LeadSize.FromJSON(result.values.thumbnailPixelSize.ToString(Formatting.None));
         document.Images.UnembedSvgImages = result.values.unembedSvgImages;

         // Text
         document.Text = new DocumentText();
         document.Text.TextExtractionMode = (DocumentTextExtractionMode)result.values.textExtractionMode;
         document.Text.ImagesRecognitionMode = (DocumentTextImagesRecognitionMode)result.values.imagesRecognitionMode;
         document.Text.AutoParseLinks = result.values.autoParseLinks;
         document.Text.ParseBookmarks = result.values.parseBookmarks;
         document.Text.ParsePageLinks = result.values.parsePageLinks;

         // History
         document.History = new DocumentHistory();
         document.History.AutoUpdateHistory = result.values.autoUpdateHistory;

         // Annotations
         document.Annotations = new DocumentAnnotations();
         var redactionOptions = new DocumentRedactionOptions();
         redactionOptions.ViewOptions = new ViewRedactionOptions();
         redactionOptions.ConvertOptions = new ConvertRedactionOptions();

         document.Annotations.RedactionOptions = redactionOptions;
         if (result.values.redactionOptions != null)
         {
            if (result.values.redactionOptions.viewOptions != null)
            {
               document.Annotations.RedactionOptions.ViewOptions.Mode = result.values.redactionOptions.viewOptions.mode;
               document.Annotations.RedactionOptions.ViewOptions.ReplaceCharacter = result.values.redactionOptions.viewOptions.replaceCharacter;
               document.Annotations.RedactionOptions.ViewOptions.IntersectionPercentage = result.values.redactionOptions.viewOptions.intersectionPercentage;
            }

            if (result.values.redactionOptions.convertOptions != null)
            {
               document.Annotations.RedactionOptions.ConvertOptions.Mode = result.values.redactionOptions.convertOptions.mode;
               document.Annotations.RedactionOptions.ConvertOptions.ReplaceCharacter = result.values.redactionOptions.convertOptions.replaceCharacter;
               document.Annotations.RedactionOptions.ConvertOptions.IntersectionPercentage = result.values.redactionOptions.convertOptions.intersectionPercentage;
            }
         }

         // View commands
         if (result.values.viewOptions != null)
         {
            document.ViewOptions = new DocumentViewOptions();
            document.ViewOptions.ViewLayout = result.values.viewOptions.viewLayout;
            document.ViewOptions.AnnotationsUserMode = result.values.viewOptions.annotationsUserMode;
            document.ViewOptions.PageNumber = result.values.viewOptions.pageNumber;
            document.ViewOptions.ViewZoomPercent = result.values.viewOptions.viewZoomPercent;
            document.ViewOptions.ViewScrollOffset = LeadPoint.FromJSON(result.values.viewOptions.viewScrollOffset.ToString(Formatting.None));
            document.ViewOptions.ViewSizeMode = result.values.viewOptions.viewSizeMode;
            document.ViewOptions.ViewItemType = result.values.viewOptions.viewItemType;
            document.ViewOptions.LoadAnnotations = result.values.viewOptions.loadAnnotations;
            document.ViewOptions.LoadThumbnails = result.values.viewOptions.loadThumbnails;
            document.ViewOptions.LoadBookmarks = result.values.viewOptions.loadBookmarks;
            var commandTokens = result.values.viewOptions.viewCommands as IEnumerable<dynamic>;
            if (commandTokens != null)
            {
               foreach (dynamic commandToken in commandTokens)
               {
                  var command = new DocumentViewCommand();
                  command.Command = commandToken.command;
                  command.Parameters = commandToken.parameters;
                  document.ViewOptions.ViewCommands.Add(command);
               }
            }
         }

         // Documents
         document.Documents = null;
         var documentTokens = result.documents as IEnumerable<dynamic>;
         if (documentTokens != null)
         {
            foreach (dynamic documentToken in documentTokens)
            {
               string childDocumentId = documentToken.values.documentId;

               if (document.Documents == null)
                  document.Documents = new DocumentDocuments();

               document.Documents.Add(childDocumentId);
            }
         }

         // Pages
         document.Pages = new DocumentPages();
         document.Pages.OriginalFirstPageNumber = result.values.originalFirstPageNumber;
         document.Pages.OriginalLastPageNumber = result.values.originalLastPageNumber;
         document.Pages.OriginalPageCount = result.values.originalPageCount;
         document.Pages.DefaultResolution = result.values.defaultResolution;
         document.Pages.DefaultPageSize = LeadSize.FromJSON(result.values.defaultPageSize.ToString(Formatting.None));

         var pageTokens = result.pages as IEnumerable<dynamic>;
         if (pageTokens != null)
         {
            foreach (dynamic pageToken in pageTokens)
            {
               DocumentPage page = new DocumentPage();
               page.DocumentId = pageToken.values.documentId;
               page.PageNumber = pageToken.values.pageNumber;
               page.Size = LeadSize.FromJSON(pageToken.values.size.ToString(Formatting.None));
               page.Resolution = pageToken.values.resolution;
               page.OriginalPageNumber = pageToken.values.originalPageNumber;
               page.IsDeleted = pageToken.values.isDeleted;
               page.IsImageModified = pageToken.values.isImageModified;
               page.IsSvgBackImageModified = pageToken.values.isSvgBackImageModified;
               page.IsThumbnailModified = pageToken.values.isThumbnailModified;
               page.IsSvgModified = pageToken.values.isSvgModified;
               page.IsTextModified = pageToken.values.isTextModified;
               page.IsAnnotationsModified = pageToken.values.isAnnotationsModified;
               page.IsLinksModified = pageToken.values.isLinksModified;
               //page.Links;
               page.IsViewPerspectiveModified = pageToken.values.isViewPerspectiveModified;
               page.ViewPerspective = (RasterViewPerspective)pageToken.values.viewPerspective;

               document.Pages.Add(page);
            }
         }

         return document;
      }

      private const string _leadCacheScheme = @"leadcache";

      public static bool IsUploadDocumentUri(Uri uri)
      {
         return uri != null && string.Compare(uri.Scheme, _leadCacheScheme, StringComparison.OrdinalIgnoreCase) == 0;
      }

      public static string ParseUploadedDocumentId(Uri uri)
      {
         return uri != null ? uri.Host : null;
      }

      public static Uri MakeUploadedDocumentUri(string data)
      {
         return new Uri(_leadCacheScheme + "://" + data);
      }

      public static bool IsUplodedDocumentUri(string value)
      {
         return value != null && value.StartsWith(_leadCacheScheme + "://");
      }

      public DocumentDescriptor CreateDocumentDescriptor()
      {
         var desc = new DocumentDescriptor();
         desc.DocumentId = this.DocumentId;
         desc.Name = this.Name;
         desc.UserId = this.UserId;
         desc.IsReadOnly = this.IsReadOnly;
         desc.MimeType = this.MimeType;
         desc.DefaultPageSize = this.Pages.DefaultPageSize;
         desc.DefaultResolution = this.Pages.DefaultResolution;
         desc.DefaultBitsPerPixel = this.Images.DefaultBitsPerPixel;
         desc.MaximumImagePixelSize = this.Images.MaximumImagePixelSize;
         desc.ThumbnailPixelSize = this.Images.ThumbnailPixelSize;
         desc.UnembedSvgImages = this.Images.UnembedSvgImages;
         desc.DocumentType = this.DocumentType;
         desc.IsStructureSupported = this.IsStructureSupported;
         if (this.Structure != null)
            desc.IsStructureParsed = this.Structure.IsParsed;
         else
            desc.IsStructureParsed = false;
         desc.IsSvgSupported = this.Images.IsSvgSupported;
         desc.IsSvgViewingPreferred = this.Images.IsSvgViewingPreferred;
         desc.IsResolutionsSupported = this.Images.IsResolutionsSupported;
         desc.TextExtractionMode = this.Text.TextExtractionMode;
         desc.ImagesRecognitionMode = this.Text.ImagesRecognitionMode;
         desc.AutoParseLinks = this.Text.AutoParseLinks;
         desc.ParseBookmarks = this.Text.ParseBookmarks;
         desc.ParsePageLinks = this.Text.ParsePageLinks;

         var javaScriptSerializer = new JavaScriptSerializer();
         desc.Metadata = javaScriptSerializer.Serialize(this.Metadata);
         if (desc.Metadata == null)
            desc.Metadata = string.Empty;

         var pageCount = this.Pages.Count;
         var pageDescs = new DocumentPageDescriptor[pageCount];
         for (var pageNumber = 1; pageNumber <= pageCount; pageNumber++)
         {
            DocumentPage page = this.Pages[pageNumber - 1];
            DocumentPageDescriptor pageDesc = new DocumentPageDescriptor();
            pageDesc.DocumentId = page.DocumentId;
            pageDesc.PageNumber = page.PageNumber;
            pageDesc.OriginalPageNumber = page.OriginalPageNumber;
            pageDesc.Size = page.Size;
            pageDesc.Resolution = page.Resolution;
            pageDesc.ViewPerspective = page.ViewPerspective;
            pageDesc.IsDeleted = page.IsDeleted;
            pageDescs[pageNumber - 1] = pageDesc;
         }

         desc.Pages = pageDescs;
         desc.ViewOptions = this.ViewOptions;
         desc.RedactionOptions = this.Annotations.RedactionOptions;
         return desc;
      }
   }
}
