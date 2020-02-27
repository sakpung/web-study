// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Leadtools.Dicom;
using Leadtools;
using System.IO;
using Leadtools.ImageProcessing;
using Leadtools.Codecs;
using Leadtools.ImageProcessing.Core;
using System.Threading;

namespace CSDicomDirLinqDemo.Utils
{
    public delegate void ReceiveWebRequest(HttpListenerContext Context);

    /// <summary>
    /// Simple web server to display images in a query.
    /// </summary>    
    public class HttpServer
    {
        protected HttpListener Listener;
        protected bool IsStarted = false;
        public event ReceiveWebRequest ReceiveWebRequest;
        private RasterCodecs _Codecs = new RasterCodecs();
        private int _ThumbWidth = 50;
        private int _ThumbHeight = 50;

        public HttpServer()
        {
        }

        public void Start(string UrlBase)
        {
            if (this.IsStarted)
                return;

            if (Listener == null)
            {
                Listener = new HttpListener();
            }

            Listener.Prefixes.Add(UrlBase);
            IsStarted = true;
            Listener.Start();

            IAsyncResult result = Listener.BeginGetContext(new AsyncCallback(WebRequestCallback), Listener);
        }

        public void Stop()
        {
            if (Listener != null)
            {
                Listener.Abort();
                Listener = null;
                IsStarted = false;
            }
        }

        protected void WebRequestCallback(IAsyncResult result)
        {
            if (Listener == null)
                return;

            //
            // Get out the context object
            //
            try
            {
                HttpListenerContext context = this.Listener.EndGetContext(result);

                //
                // Immediately set up the next context
                //
                Listener.BeginGetContext(new AsyncCallback(WebRequestCallback), Listener);
                if (ReceiveWebRequest != null)
                    ReceiveWebRequest(context);

                ProcessRequest(context);
            }
            catch { }
        }

        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="Context">The context.</param>
        protected virtual void ProcessRequest(HttpListenerContext Context)
        {
            using (DicomDataSet ds = new DicomDataSet())
            {
                try
                {
                    string file = Context.Request.QueryString["file"];
                    RasterImage image = null;

                    ds.Load(file, DicomDataSetLoadFlags.None);                    
                    image = ds.GetImage(null, 0, 0, RasterByteOrder.Rgb | RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyModalityLut | DicomGetImageFlags.AutoApplyVoiLut | DicomGetImageFlags.AllowRangeExpansion );
                    if (image != null)
                    {
                        //
                        // resize the image to smaller
                        //
                        MemoryStream stream = new MemoryStream();

                        SizeWithAspect(image);
                        if (image.Signed || image.GrayscaleMode == RasterGrayscaleMode.OrderedInverse)
                        {
                            ConvertSignedToUnsignedCommand cmd = new ConvertSignedToUnsignedCommand(ConvertSignedToUnsignedCommandType.ShiftNegativeToZero);

                            cmd.Run(image);
                        }

                        Monitor.Enter(this);
                        try
                        {
                            _Codecs.Save(image, stream, RasterImageFormat.Jpeg, 8);
                            Context.Response.ContentType = "image/jpeg";
                            Context.Response.ContentLength64 = stream.Length;
                            Context.Response.OutputStream.Write(stream.ToArray(), 0, Convert.ToInt32(stream.Length));
                            Context.Response.OutputStream.Close();
                        }
                        finally
                        {
                            Monitor.Exit(this);
                        }
                    }
                }
                catch { }
            }
        }

        private void SizeWithAspect(RasterImage image)
        {
            int newWidth;
            int newHeight;
            SizeCommand cmd;

            if (image.Height > image.Width)
            {
                newHeight = _ThumbHeight;
                newWidth = Convert.ToInt32(image.Width * _ThumbWidth / image.Height);
            }
            else
            {
                newWidth = _ThumbWidth;
                newHeight = Convert.ToInt32(image.Height * _ThumbHeight / image.Width);
            }
            cmd = new SizeCommand(newWidth, newHeight, RasterSizeFlags.Resample);

            cmd.Run(image);
        }
    }
}
