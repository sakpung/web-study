// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections.Generic ;
using System.Text ;
using System.IO ;
using System.Net ;
using System.Net.Sockets ;
using Leadtools.Jpip.Server ;
using Leadtools.Demos ;


namespace JpipServerDemo
{
   class ImagesEnumerationService
   {
      public event EventHandler ServiceStarted ;
      public event EventHandler ServiceStoped ;
      
      public ImagesEnumerationService ( JpipServer server ) 
      {
         _server     = server ;
         IpAddress   = IPAddress.Parse ( "127.0.0.1" ) ;
         Port        = 49202;
         _started    = false ;
         _extensions = new List<string> ( ) ;
      }
      
      public void Start ( )
      {
         _listner = new HttpListener ( ) ;
         
         
         _listner.Prefixes.Add ( string.Format ( "http://{0}:{1}/", IpAddress, Port ) ) ;
         
         _listner.Start ( ) ;
         
         _started = true ;
         
         _listner.BeginGetContext ( ClientRequestReceived, null ) ;
         
         if ( null != ServiceStarted )
         {
            ServiceStarted ( this, new EventArgs ( ) ) ;
         }
      }
      
      public void Stop ( ) 
      {
         _listner.Stop ( ) ;
         
         _started = false ;
         
         if ( null != ServiceStoped )
         {
            ServiceStoped ( this, new EventArgs ( ) ) ;
         }
      }
      
      
      public List <string> ImagesExtension
      {
         get
         {
            return _extensions ;
         }
      }
      
      public bool Running
      {
         get
         {
            return _started ;
         }
      }
      
      private void ClientRequestReceived ( IAsyncResult ar )
      {
         HttpListenerContext context ; 
         
         
         if  ( null == _listner || !_listner.IsListening ) 
         {
            return ;
         }
         
         try
         {
            context = _listner.EndGetContext ( ar ) ;
         }
         catch
         {
            return ;
         }
         
         try
         {

            string formattedImages ;
            byte [ ] sendBuffer ;
            
            _listner.BeginGetContext ( ClientRequestReceived, null ) ;
            
            formattedImages = GetFormattedServerImagesString ( ) ;
            
            sendBuffer = Encoding.ASCII.GetBytes ( formattedImages ) ;
            
            context.Response.OutputStream.Write ( sendBuffer, 0, sendBuffer.Length ) ;
            
            context.Response.Close ( ) ;
         }
         catch ( Exception )
         {
            if ( null != context ) 
            {
               context.Response.Close ( ) ;
            }
         }
      }
      
      public string GetFormattedServerImagesString ( ) 
      {
         List <string> searchImages ;
         List <string> serverImages ;
         string        serverImageFile ;
         string formattedServerImagesString = string.Empty ;
         
         
         searchImages = new List<string> ( ) ;
         serverImages = new List<string> ( ) ;
         
         foreach ( string extension in ImagesExtension ) 
         {
            searchImages.AddRange ( Directory.GetFiles ( _server.Configuration.ImagesFolder,
                                                         extension, 
                                                         SearchOption.AllDirectories ) ) ;
         }

         foreach ( string file in searchImages )
         {
            serverImageFile = file.Replace ( _server.Configuration.ImagesFolder, 
                                             string.Empty ) ;
            
            serverImageFile = serverImageFile.TrimStart ( '\\' ) ; 
            
            formattedServerImagesString += serverImageFile + ";" ;
         }

         searchImages.Clear ( ) ;
         
         foreach ( KeyValuePair <string, string> aliasFolder in _server.Configuration.AliasFolders )
         {
            if ( !Directory.Exists ( aliasFolder.Value ) )
            {
               continue ;
            }
            
            foreach ( string extension in ImagesExtension ) 
            {
               searchImages.AddRange ( Directory.GetFiles ( aliasFolder.Value,
                                                            extension, 
                                                            SearchOption.AllDirectories ) ) ;
            }
            
            foreach ( string imageFile in searchImages )
            {
               serverImageFile = imageFile.Replace ( aliasFolder.Value, aliasFolder.Key ) ;
               
               serverImageFile = serverImageFile.TrimStart ( '\\' ) ;
               
               formattedServerImagesString += serverImageFile + ";" ;
            }
            
            searchImages.Clear ( ) ;
         }
         
         return formattedServerImagesString.TrimEnd ( ';' ) ;
      }
      
      public IPAddress IpAddress
      {
         get
         {
            return _ipAddress ;
         }
         
         set
         {
            _ipAddress = value ;
         }
      }
      
      public int Port
      {
         get
         {
            return _port ;
         }
      
         set
         {
            _port = value ;
         }
      }
      

      private HttpListener  _listner ;
      JpipServer            _server ;
      private IPAddress     _ipAddress ;
      private int           _port ;
      private volatile bool          _started = false ;
      private List <string> _extensions ;
   }
}
