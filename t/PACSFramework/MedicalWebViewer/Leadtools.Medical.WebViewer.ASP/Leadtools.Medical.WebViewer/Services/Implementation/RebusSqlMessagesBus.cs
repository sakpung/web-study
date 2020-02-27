using System;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;
using Rebus.Config;
using Rebus.Activation;
using Rebus.Routing.TypeBased;
using System.Linq;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   public class RebusSqlMessagesBus : IMessagesBus
   {
      public string ConnectionStringOrName { get; private set; }
      public string TableName { get; private set; }
      public int MaxNumberOfMsg { get; set; }
      public int TimeOut { get; set; }//milliseconds
      public int Expiry { get; set; }//seconds

      public RebusSqlMessagesBus (string connectionStringOrName)
      {
         ConnectionStringOrName = connectionStringOrName;
         TableName = "Messages";
         MaxNumberOfMsg = 3;
         TimeOut = 500;//milliseconds
         Expiry = 30;//seconds
      }

      private bool _disposed = false;
      ~RebusSqlMessagesBus ()
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

      public async Task SendSingle(string to, object obj)
      {
         var json = JsonConvert.SerializeObject(obj);

         using (var adapter = new BuiltinHandlerActivator())
         {
            Configure.With(adapter)
                .Logging(l => l.None())
                .Transport(t => t.UseSqlServerAsOneWayClient(ConnectionStringOrName, TableName))
                .Routing(r => r.TypeBased().Map<string>(to))
                .Start();
            
            var headers = new Dictionary<string, string>
            {
               {Rebus.Messages.Headers.SentTime, DateTime.Now.ToString()},
            };

            await adapter.Bus.Send(json, headers);
         }
      }

      private bool IsExpired(Dictionary<string, string> headers)
      {
         string dts;
         if(headers.TryGetValue(Rebus.Messages.Headers.SentTime, out dts))
         {
            DateTime dt;
            if(DateTime.TryParse(dts, out dt))
            {
               var span = DateTime.Now - dt;
               return span > TimeSpan.FromSeconds(Expiry);
            }
         }
         return false;
      }

      public Task<List<T>> GetMany<T>(string to)
      {
         var cte = new CountdownEvent(MaxNumberOfMsg);

         using (var adapter = new BuiltinHandlerActivator())
         {
            var messages = new ConcurrentQueue<T>();

            adapter.Handle<string>(async (bus, context, msg) =>
            {
               if (cte.IsSet)
               {
                  await bus.DeferLocal(TimeSpan.FromMilliseconds(100), msg);
               }
               else
               {
                  cte.Signal();
                  if (!IsExpired(context.Headers))
                  {
                     messages.Enqueue(JsonConvert.DeserializeObject<T>(msg));
                  }
                  await Task.FromResult<object>(null);
               }
            });

            Configure.With(adapter)
                .Logging(l => l.None())
                .Transport(t => t.UseSqlServer(ConnectionStringOrName, TableName, to))
                .Options(o =>
                {
                   o.SetNumberOfWorkers(1);
                   o.SetMaxParallelism(1);
                })
                .Start();

            var result = cte.Wait(500);

            return Task.FromResult(messages.ToList());
         }
      }

      public async Task Drain(string to)
      {
         try
         {
            var timeLock = new object();
            var time = DateTime.Now;

            using (var adapter = new BuiltinHandlerActivator())
            {
               adapter.Handle<string>(async (bus, msg) =>
               {
                  lock (timeLock)
                  {  
                     time = DateTime.Now;
                  }
                  await Task.FromResult<object>(null);
               });
               Configure.With(adapter)
                   .Logging(l => l.None())
                   .Transport(t => t.UseSqlServer(ConnectionStringOrName, TableName, to))
                   .Options(o =>
                   {
                      o.SetNumberOfWorkers(10);
                      o.SetMaxParallelism(10);
                   })
                   .Start();

               time = DateTime.Now;
               TimeSpan span;
               
               do
               {
                  await Task.Delay(50);
                  //await Task.Delay(TimeSpan.FromMilliseconds(TimeOut));
                  
                  lock (timeLock)
                  {
                     span = DateTime.Now - time;                     
                  }
               }
               while (span.TotalMilliseconds < TimeOut);               
            }
         }
         catch
         {
            //ignored
         }
      }
            
      public Task<T> GetStatus<T>(string id)
      {
         T status = default(T);
         var ev = new AutoResetEvent(false);

         using (var adapter = new BuiltinHandlerActivator())
         {
            adapter.Handle<string>(async (bus, context, msg) =>
            {
               status = JsonConvert.DeserializeObject<T>(msg);

               //if (!IsExpired(context.Headers))
               //{
               //   await bus.DeferLocal(TimeSpan.FromMilliseconds(1), msg);
               //}

               ev.Set();
               
               await Task.FromResult<object>(null);
            });

            Configure.With(adapter)
                .Logging(l => l.None())
                .Transport(t => t.UseSqlServer(ConnectionStringOrName, TableName, id))
                .Options(o =>
                {
                   o.SetNumberOfWorkers(1);
                })
                .Start();
            
            var result = ev.WaitOne(TimeOut);
         }

         return Task.FromResult(status);
      }
      
      public async Task SetStatus(string id, object status)
      {
         //await Drain(id);
         await SendSingle(id, status);
      }
   }
}