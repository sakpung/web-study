using System;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   public class InMemoryMessagesBus : IMessagesBus
   {
      private static ConcurrentDictionary<string, List<string>> CommandsQueue = new ConcurrentDictionary<string, List<string>>();
      private static ConcurrentDictionary<string, Tuple<string, string>> CommandsStatus = new ConcurrentDictionary<string, Tuple<string, string>>();

      public InMemoryMessagesBus()
      {
      }

       private bool _disposed = false;
      ~InMemoryMessagesBus ()
      {
         if (!this._disposed)
         {
            this._disposed = true;
            Dispose();
         }
      }

      public void Dispose()
      {
         if (!this._disposed)
         {
            this._disposed = true;            
            
            GC.SuppressFinalize(this);
         }
      }
      public Task SendSingle(string to, object obj)
      {
         var json = JsonConvert.SerializeObject(obj);

         CommandsQueue.AddOrUpdate(to, 
            (k)=> new List<string>() { json }, 
            (k,v)=> { v.Add(json); return v; });

         return Task.FromResult<string>(null);
      }

      public Task<List<T>> GetMany<T>(string to)
      {
         if (CommandsQueue.ContainsKey(to))
         {
            List<string> obj = null;

            if (CommandsQueue.TryRemove(to, out obj))
            {
               var typed = obj.ConvertAll((val) => JsonConvert.DeserializeObject<T>(val) );
               return Task.FromResult(typed);
            }
         }

         return Task.FromResult<List<T>>(null);
      }

      public Task Drain(string to)
      {
         if (CommandsQueue.ContainsKey(to))
         {
            List<string> obj = null;

            CommandsQueue.TryRemove(to, out obj);
         }

         return Task.FromResult<object>(null);
      }

      private void SetCommandStatus(string id, string status, string message)
      {
      }

      public Task<T> GetStatus<T>(string id)
      {
         Tuple<string, string> status = null;

         CommandsStatus.TryGetValue(id, out status);         

         return Task.FromResult((T)(object)status);
      }

      public Task SetStatus(string id, object status)
      {
         var typ_status = (Tuple<string, string>)status;

         CommandsStatus.AddOrUpdate(id, 
            (k)=> new Tuple<string, string>(typ_status.Item1, typ_status.Item2), 
            (k,v)=> new Tuple<string, string>(typ_status.Item1, typ_status.Item2));

         return Task.FromResult<object>(null);
      }
   }
}