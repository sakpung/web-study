// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Wado
{
   internal static class RestClient
   {
      internal static async Task<Stream> queryJson(string query_url)
      {
         // Create request to send to QIDO service.
         using (var client = new HttpClient())
         using (var request = new HttpRequestMessage() { RequestUri = new Uri(query_url), Method = HttpMethod.Get })
         {
            // Add accept header to request.
            var accept = new MediaTypeWithQualityHeaderValue(@"application/json");
            request.Headers.Accept.Add(accept);

            // Send request and get response.
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);

            // Check for successful response.
            response.EnsureSuccessStatusCode();

            // Read response.
            var stm = await response.Content.ReadAsStreamAsync();

            return stm;
         }
      }

      /// <summary>
      /// Multipart (application/dicom) query, however returns only the first part
      /// </summary>
      internal static async Task<Stream> queryDicomStream(string query_url)
      {
         using (var client = new HttpClient())
         using (var request = new HttpRequestMessage() { RequestUri = new Uri(query_url), Method = HttpMethod.Get })
         {
            // Add accept header to request.
            var accept = new MediaTypeWithQualityHeaderValue(@"multipart/related");
            accept.Parameters.Add(new NameValueHeaderValue("type", @"""application/dicom"""));

            request.Headers.Accept.Add(accept);

            // Send request and get response.
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);

            // Check for successful response.
            response.EnsureSuccessStatusCode();

            // Read response.
            var provider = new MultipartMemoryStreamProvider();
            await response.Content.ReadAsMultipartAsync(provider);

            // Read contents of response and return as FileStreamResult.
            var stm = await provider.Contents[0].ReadAsStreamAsync();
            return stm;
         }
      }

      /// <summary>
      /// single response (image/*) query
      /// </summary>
      internal static async Task<Stream> queryRenderedDicomFile(string query_url, string mime, Size? size)
      {
         // Keeping it simple -for now- to add a query parameter
         if (size.HasValue)
         {
            query_url += string.Format("?viewport={0},{1},,,,", size.Value.Width, size.Value.Height);
         }

         using (var client = new HttpClient())
         using (var request = new HttpRequestMessage() { RequestUri = new Uri(query_url), Method = HttpMethod.Get })
         {
            // Add accept header to request.
            var accept = new MediaTypeWithQualityHeaderValue(string.IsNullOrEmpty(mime)?"*/*":mime);
            
            request.Headers.Accept.Add(accept);

            // Send request and get response.
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);

            // Check for successful response.
            response.EnsureSuccessStatusCode();

            // Read contents of response and return as FileStreamResult.
            var stm = await response.Content.ReadAsStreamAsync();
            return stm;
         }
      }
   }
}
