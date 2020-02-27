// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace Leadtools.Medical.WebViewer
{
   class NotToStringContractResolver : DefaultContractResolver//CamelCasePropertyNamesContractResolver
   {
      protected override JsonContract CreateContract(Type objectType)
      {
         JsonContract contract = base.CreateContract(objectType);
         if (objectType != typeof(string) && (contract is JsonStringContract))
         {
            // We don't want a string contract unless the objectType was actually a string
            return base.CreateObjectContract(objectType);
         }
         return base.CreateContract(objectType);
      }
   }

   public class NullJsonHandler : DelegatingHandler
   {
      protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
      {
         var response = await base.SendAsync(request, cancellationToken);
         if (response.Content == null)
         {
            //response.Content = new StringContent("{}");//empty object
            response.Content = new StringContent("");//empty
         }
         else if (response.Content is ObjectContent)
         {
            var objectContent = (ObjectContent)response.Content;
            if (objectContent.Value == null)
            {
               //response.Content = new StringContent("{}");//empty object
               response.Content = new StringContent("");
            }

         }
         return response;
      }
   }

   
   public static class WebApiConfig
   {
      public static void Register(HttpConfiguration config)
      {         
         // enable CORS
         var cors = new EnableCorsAttribute("*", "*", "*");
         config.EnableCors(cors);
         
         // Web API routes
         config.MapHttpAttributeRoutes();

         config.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: "api/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
         );

         // Modify the JSON serializer
         // Makes property names lowercase on serialization, and makes sure objects
         // like LeadRectD and LeadSizeD aren't serialized from their "toString" method.
         config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new NotToStringContractResolver();

         // Intercept Send() for empty object/strings, send "" instead of null
         // this is to be compatible with the old wcf service, null is not handled correctly in the web client
         config.MessageHandlers.Add(new NullJsonHandler());

         //some types that have converters assigned to them will result in a failure serializing from a JSON string, 
         //this happens when using [Newtonsoft.Json] library
         //we override these converters (to string) by JsonConverter:
         
         //1. inject some kernel related types
         TypeDescriptor.AddAttributes(typeof(LeadPointD), new TypeConverterAttribute(typeof(JsonConverter)));
         TypeDescriptor.AddAttributes(typeof(LeadRectD), new TypeConverterAttribute(typeof(JsonConverter)));
         TypeDescriptor.AddAttributes(typeof(LeadSizeD), new TypeConverterAttribute(typeof(JsonConverter)));

         //2. inject all types under "Leadtools.Dicom.Common.DataTypes" namespace
         //e.g. CodeSequence, NominalScreenDefinition
         //anything that uses [TypeConverter(typeof(ExpandableObjectConverter))]
         {
             var dc = Assembly.Load("Leadtools.Dicom.Common");
             var q = from t in dc.GetTypes() where t.IsClass && t.Namespace == "Leadtools.Dicom.Common.DataTypes" select t;
             q.ToList().ForEach(t => TypeDescriptor.AddAttributes(t, new TypeConverterAttribute(typeof(JsonConverter))));
         }

         //3. alternatively you may inject individual ones 
         //TypeDescriptor.AddAttributes(typeof(Leadtools.Dicom.Common.DataTypes.CodeSequence), new TypeConverterAttribute(typeof(JsonConverter)));
         //TypeDescriptor.AddAttributes(typeof(Leadtools.Dicom.Common.DataTypes.NominalScreenDefinition), new TypeConverterAttribute(typeof(JsonConverter)));
        }
   }
}
