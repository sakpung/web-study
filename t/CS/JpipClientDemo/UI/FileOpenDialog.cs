// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Leadtools.Demos;


namespace JpipClientDemo
{
   public partial class FileOpenDialog : Form
   {
      private string _fileName;
      private string _serviceIPAddress ;
      private int    _servicePortNumber ;

      public FileOpenDialog()
      {
         InitializeComponent();
      }

      public string FileName
      {
         get { return _fileName; }
         set { _fileName = value; }
      }

      public string ServiceIpAddress
      {
         set
         {
            _serviceIPAddress = value ;
         }
         
         get
         {
            return _serviceIPAddress ;
         }
      }
      
      public int ServicePort
      {
         get 
         { 
            return _servicePortNumber ; 
         }
         set 
         { 
            _servicePortNumber = value ;
         }
      }

      private void rbtnFileName_CheckedChanged(object sender, EventArgs e)
      {
         if (rbtnFileName.Checked)
         {
            this.txtFileName.Enabled = true;
            this.pnlEnumerateService.Enabled = false;
            this.btnGetFiles.Enabled         = false ;
         }
         else
         {
            this.txtFileName.Enabled = false;
            this.pnlEnumerateService.Enabled = true;
            this.btnGetFiles.Enabled         = true ;
         }
      }

      private void btnGetFiles_Click(object sender, EventArgs e)
      {
         try
         {
            HttpWebRequest request = ( HttpWebRequest ) HttpWebRequest.Create ( string.Format ( "http://{0}:{1}/", ServiceIpAddress, ServicePort ) ) ;
            
            
            if ( null != request.Proxy ) 
            {
               request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials ;
            }
            
            request.UseDefaultCredentials = true ;

            
            HttpWebResponse response = ( HttpWebResponse ) request.GetResponse ( ) ;
            
            System.IO.Stream receivedStream = response.GetResponseStream ( ) ;
            System.IO.StreamReader reader = new System.IO.StreamReader ( receivedStream ) ;

            Char[] read = new Char[256];
            // Reads 256 characters at a time.    
            int count = reader.Read(read, 0, 256);
            string imageNames = "" ;
            
            while (count > 0)
            {
               // Dumps the 256 characters on a string and displays the string to the console.
               String temp = new String(read, 0, count);
               
               imageNames+= temp ;
               
               count = reader.Read(read, 0, 256);
            }
            
            // Releases the resources of the response.
            response.Close();
            // Releases the resources of the Stream.
            reader.Close();

            
            
            string[] serverSideImageNames = imageNames.Split(';');
            this.lstFiles.Items.Clear();
            foreach (string image in serverSideImageNames)
            {
               this.lstFiles.Items.Add(image);
            }
         }
         catch (Exception exception)
         {
            ShowErrorMessage(this, exception);
         }
      }

      private void txtFileName_TextChanged(object sender, EventArgs e)
      {
         if (txtFileName.Text.Length > 0)
         {
            this.btnOK.Enabled = true;
         }
         else
         {
            this.btnOK.Enabled = false;
         }
      }

      private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (lstFiles.SelectedIndex != -1)
         {
            this.btnOK.Enabled = true;
         }
         else
         {
            this.btnOK.Enabled = false;
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         if (rbtnFileName.Checked)
         {
            FileName = this.txtFileName.Text;
         }
         else
         {
            if (this.lstFiles.SelectedItem != null)
               FileName = this.lstFiles.SelectedItem.ToString();
            else
               FileName = null;
         }
      }

      private void ShowErrorMessage(IWin32Window owner, Exception ex)
      {
         string message;
         message = ex.Message;
         if (ex is System.Net.WebException)
         {
            System.Net.WebException webExc = (System.Net.WebException)ex;
            if ((null != webExc.Response) && (webExc.Response is System.Net.HttpWebResponse))
            {
               System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)webExc.Response;
               message += "\nServer Error:\n" + response.StatusDescription;
            }
         }
         
         Messager.ShowError(owner, message);
      }
   }
}
