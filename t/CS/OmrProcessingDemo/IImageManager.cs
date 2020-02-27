using Leadtools;
using Leadtools.Caching;
using Leadtools.Codecs;
using System;
using System.Collections.Generic;
using System.IO;

namespace OmrProcessingDemo
{
   public interface IImageManager
   {
      bool Has(string key);
      void Add(string key, RasterImage image);
      void Add(string key, string path);
      RasterImage Get(string key);
      RasterImage GetPage(string key, int page);
      void Clear();
      void Save();

      // no foreach or getcount
   }

   // This a test image manager, dont use it. only for debugging
   public class MemoryImageManager : IImageManager
   {
      private Dictionary<string, RasterImage> _images = new Dictionary<string, RasterImage>();
      private Dictionary<string, string> _imagePaths = new Dictionary<string, string>();

      public MemoryImageManager()
      {
      }

      public bool Has(string key)
      {
         return _images.ContainsKey(key) || _imagePaths.ContainsKey(key);
      }

      public void Add(string key, RasterImage image)
      {
         Remove(key);

         _images[key] = image != null ? image.Clone() : null;
      }

      public void Add(string key, string path)
      {
         Remove(key);

         _imagePaths[key] = path;
      }

      private void Remove(string key)
      {
         RasterImage oldImage = null;

         if (_images.ContainsKey(key))
         {
            oldImage = _images[key];
            _images.Remove(key);
         }

         if (_imagePaths.ContainsKey(key))
         {
            _imagePaths.Remove(key);
         }

         if (oldImage != null)
            oldImage.Dispose();
      }

      public RasterImage Get(string key)
      {
         if (_images.ContainsKey(key))
         {
            var image = _images[key];
            return image != null ? image.CloneAll() : null;
         }

         if (_imagePaths.ContainsKey(key))
         {
            if (File.Exists(_imagePaths[key]) == false)
            {
               return null;
            }

            using (var codecs = MainForm.GetRasterCodecs())
            {
               codecs.Options.Load.AllPages = true;
               RasterImage image = codecs.Load(_imagePaths[key]);
               image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
               return image;
            }
         }

         return null;
      }

      public RasterImage GetPage(string key, int page)
      {
         if (_images.ContainsKey(key))
         {
            var image = _images[key];

            if (image != null)
            {
               image.Page = page;
               return image.Clone();
            }

            return null;
         }

         if (_imagePaths.ContainsKey(key))
         {
            if (File.Exists(_imagePaths[key]) == false)
            {
               return null;
            }

            using (var codecs = MainForm.GetRasterCodecs())
            {
               codecs.Options.Load.AllPages = true;
               RasterImage image = codecs.Load(_imagePaths[key], page);
               image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
               return image;
            }
         }


         return null;
      }

      public void Clear()
      {
         foreach (var item in _images)
         {
            if (item.Value != null)
               item.Value.Dispose();
         }

         _images.Clear();
         _imagePaths.Clear();
      }

      public void Save()
      {
         // Not implemented
      }
   }

   public class CacheImageManager : IImageManager
   {
      private ObjectCache _cache;
      private string _region;
      private Dictionary<string, string> _imagePaths = new Dictionary<string, string>();

      public string CreateNewImageId()
      {
         return Guid.NewGuid().ToString();
      }

      public CacheImageManager()
      {
         // maybe change the demo to ask for the workspace directory before it starts?
         /*
         string workspaceDir = @"//myworkspace";
         string cacheDir = System.IO.Path.Combine(workspaceDir, "cache");
         CacheImageManager imageManager = new CacheImageManager(cacheDir, "OMR");
         */
      }

      public void Create(string directory, string region)
      {
         if (string.IsNullOrEmpty(region))
            throw new InvalidOperationException("region cannot be null or empty");

         var fileCache = new FileCache();
         fileCache.CacheDirectory = directory;
         _region = region;
         _cache = fileCache;
      }

      public bool Has(string key)
      {
         return (_cache != null && _cache.Contains(key, _region)) || _imagePaths.ContainsKey(key);
      }

      public void Add(string key, RasterImage image)
      {
         if (_cache == null)
            throw new InvalidOperationException("Must call create first");

         Remove(key);

         _cache.Add(key, image, new CacheItemPolicy(), _region);
      }

      public void Add(string key, string path)
      {
         Remove(key);

         _imagePaths[key] = path;
      }

      private void Remove(string key)
      {
         if (_imagePaths.ContainsKey(key))
         {
            _imagePaths.Remove(key);
         }
      }

      public RasterImage Get(string key)
      {
         if (_imagePaths.ContainsKey(key))
         {
            using (var codecs = MainForm.GetRasterCodecs())
            {
               var path = _imagePaths[key];
               RasterImage image = codecs.Load(path, 1);
               image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
               return image;
            }
         }

         if (_cache != null)
            return _cache.Get<RasterImage>(key, _region);

         return null;
      }

      public RasterImage GetPage(string key, int page)
      {
         if (_imagePaths.ContainsKey(key))
         {
            using (var codecs = MainForm.GetRasterCodecs())
            {
               var path = _imagePaths[key];
               RasterImage image = codecs.Load(path, page);
               image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
               return image;
            }
         }

         if (_cache != null)
         {
            RasterImage img = _cache.Get<RasterImage>(key, _region);
            img.Page = page;

            return img;
         }

         return null;
      }

      public void Clear()
      {
         if (_cache != null)
            _cache.DeleteRegion(_region);
         _imagePaths.Clear();
      }

      public void Save()
      {
         if (_cache == null)
            throw new InvalidOperationException("Must call create first");

         if (_imagePaths.Count == 0)
            return;

         using (var codecs = MainForm.GetRasterCodecs())
         {
            foreach (var item in _imagePaths)
            {
               using (var image = codecs.Load(item.Value, 1))
               {
                  image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
                  _cache.Add(item.Key, image, new CacheItemPolicy(), _region);
               }

            }
         }
      }
   }
}
