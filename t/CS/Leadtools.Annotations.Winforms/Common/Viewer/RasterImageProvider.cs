// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;

using Leadtools.Annotations.Engine;
using Leadtools.Codecs;
using Leadtools.ImageProcessing;

namespace Leadtools.Annotations.WinForms
{
   public class RasterImageAutomationDataProvider : AnnDataProvider
   {
      private RasterImage _image;

      public RasterImage Image
      {
         get { return _image; }
         set { _image = value; }
      }

      private RasterImageAutomationDataProvider() { }

      public RasterImageAutomationDataProvider(RasterImage image)
      {
         _image = image;
      }

      private void ApplyEncryptDecrypt(ScrambleCommandFlags flags, LeadRectD bounds, int key)
      {
         LeadRect rect = bounds.ToLeadRect();

         LeadRect imageRect = LeadRect.Create(0, 0, _image.ImageWidth, _image.ImageHeight);

         flags |= ScrambleCommandFlags.Intersect;

         ScrambleCommand scrambleCommand = new ScrambleCommand(rect, key, flags);
         if (imageRect.Contains(rect))
            scrambleCommand.Run(_image);
      }

      public override void Decrypt(AnnContainer container, LeadRectD bounds, int key)
      {
         ApplyEncryptDecrypt(ScrambleCommandFlags.Decrypt, bounds, key);
      }

      public override void Encrypt(AnnContainer container, LeadRectD bounds, int key)
      {
         ApplyEncryptDecrypt(ScrambleCommandFlags.Encrypt, bounds, key);
      }

      public override void Fill(AnnContainer container, LeadRectD bounds, string color)
      {
         if (_image == null)
            return;

         try
         {
            var fill = new FillCommand(RasterColor.Black);
            LeadRect rect = bounds.ToLeadRect();
            rect = _image.RectangleToImage(RasterViewPerspective.TopLeft, rect);
            _image.AddRectangleToRegion(null, rect, RasterRegionCombineMode.Set);
            fill.Run(_image);
         }
         finally
         {
            _image.MakeRegionEmpty();
         }
      }

      public override byte[] GetImageData(AnnContainer container, LeadRectD bounds)
      {
         if (_image == null)
            return null;

         LeadRect rect = bounds.ToLeadRect();
         rect = _image.RectangleToImage(RasterViewPerspective.TopLeft, rect);

         using (var image = _image.Clone(rect))
         {
            using (var codecs = new RasterCodecs())
            {
               using (var ms = new MemoryStream())
               {
                  codecs.Save(image, ms, RasterImageFormat.Png, Image.BitsPerPixel);

                  return ms.ToArray();
               }
            }
         }
      }

      public override void SetImageData(AnnContainer container, LeadRectD bounds, byte[] data)
      {
         if (_image == null)
            return;

         using (var ms = new MemoryStream(data))
         {
            using (var codecs = new RasterCodecs())
            {
               using (var image = codecs.Load(ms))
               {
                  if (image.ViewPerspective != _image.ViewPerspective)
                     image.ChangeViewPerspective(_image.ViewPerspective);

                  if (image.BitsPerPixel != _image.BitsPerPixel || image.Order != _image.Order)
                  {
                     var palette = _image.GetPalette();
                     var paletteFlags = palette != null ? ColorResolutionCommandPaletteFlags.UsePalette : ColorResolutionCommandPaletteFlags.Optimized;

                     var colorResCommand = new ColorResolutionCommand(
                        ColorResolutionCommandMode.InPlace,
                        _image.BitsPerPixel,
                        _image.Order,
                        RasterDitheringMethod.None,
                        paletteFlags,
                        palette);
                     colorResCommand.Run(image);
                  }

                  var combine = new CombineFastCommand(_image, bounds.ToLeadRect(), LeadPoint.Create(0, 0), CombineFastCommandFlags.SourceCopy);
                  combine.Run(image);
               }
            }
         }
      }
   }
}
