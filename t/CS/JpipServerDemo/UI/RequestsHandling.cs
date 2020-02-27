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
using Leadtools.Demos ;


namespace JpipServerDemo
{
   public partial class RequestsHandling : Form
   {
      List <string>         _ipAddressesList ;
      BindingList <string>  _ipAddressesBinding ;
      
      public RequestsHandling()
      {
         InitializeComponent();

         _ipAddressesList = new List<string> ( ) ;
         
         this.Load += new EventHandler(Requests_Handling_Load);
      }
      
      public RequestsHandling ( string[] ipAddress )
      : this ( ) 
      {
         IpAddresses = ipAddress ;
         
         _ipAddressesList.AddRange ( IpAddresses ) ;
         
         _ipAddressesBinding = new BindingList<string> ( _ipAddressesList ) ;
      }

      void Requests_Handling_Load(object sender, EventArgs e)
      {
         lstAddresses.DataSource = _ipAddressesBinding ;
      }

      public string [ ] IpAddresses ;

      private void btnAdd_Click(object sender, EventArgs e)
      {
         System.Net.IPAddress address ;
         
         
         if ( System.Net.IPAddress.TryParse ( mtxtIpAddress.Text, out address ) )
         {
            _ipAddressesBinding.Add ( address.ToString ( ) ) ;
         }
         else
         {
            Messager.ShowError ( this,
                                 "Invalid IP address format." ) ;
         }
      }

      private void btnRemove_Click(object sender, EventArgs e)
      {
         if ( lstAddresses.SelectedItem != null ) 
         {
            _ipAddressesBinding.Remove ( lstAddresses.SelectedItem.ToString ( ) ) ;
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         IpAddresses = _ipAddressesList.ToArray ( ) ;
      }
   }
}
