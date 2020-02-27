// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Data ;
using System.Drawing ;
using System.Text ;
using System.Windows.Forms ;
using Leadtools.Demos ;


namespace JpipServerDemo
{
   public partial class ImagesEnumerationServiceDlg : Form
   {
      ImagesEnumerationService _enumerationService ;
      
      public ImagesEnumerationServiceDlg ( )
      {
         InitializeComponent ( ) ;
      }
      
      internal ImagesEnumerationServiceDlg 
      ( 
         ImagesEnumerationService enumerationService 
      ) : this ( ) 
      {
         _enumerationService = enumerationService ;
         
         Init ( ) ;

         this.Load += new EventHandler(ImagesEnumerationServiceDlg_Load);
         this.FormClosing += new FormClosingEventHandler(ImagesEnumerationServiceDlg_FormClosing);
      }

      void ImagesEnumerationServiceDlg_Load(object sender, EventArgs e)
      {
         if ( null != _enumerationService )
         {
            _enumerationService.ServiceStarted += new EventHandler(_enumerationService_ServiceStarted);
            _enumerationService.ServiceStoped += new EventHandler(_enumerationService_ServiceStoped);
         }
      }

      void ImagesEnumerationServiceDlg_FormClosing(object sender, FormClosingEventArgs e)
      {
         if ( null != _enumerationService )
         {
            _enumerationService.ServiceStarted -= new EventHandler(_enumerationService_ServiceStarted);
            _enumerationService.ServiceStoped  -= new EventHandler(_enumerationService_ServiceStoped);
         }
      }

      void _enumerationService_ServiceStoped(object sender, EventArgs e)
      {
         UpdateUIEnablesState ( ) ;
      }

      void _enumerationService_ServiceStarted(object sender, EventArgs e)
      {
         txtIpAddress.Text = _enumerationService.IpAddress.ToString ( ) ;
         
         UpdateUIEnablesState ( ) ;
      }
      
      private void Init ( ) 
      {
         try
         {
            txtIpAddress.Text = _enumerationService.IpAddress.ToString ( ) ;
            mtxtPort.Text     = _enumerationService.Port.ToString ( ) ;
            
            UpdateUIEnablesState ( ) ;
            
            InitExtensions ( ) ;

         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }
      
      private void UpdateUIEnablesState ( ) 
      {
         grpExten.Enabled     = !_enumerationService.Running ;
         mtxtPort.Enabled     = !_enumerationService.Running ;
         btnStart.Enabled     = !_enumerationService.Running ;
         btnStop.Enabled      = _enumerationService.Running ;
      }


      private void InitExtensions ( ) 
      {
         DisableCheckChangedEvent ( ) ;
         
         txtExtensions.TextChanged -= new EventHandler ( txtExtensions_TextChanged ) ;
         
         foreach ( string extension in _enumerationService.ImagesExtension )
         {
            if ( extension.ToLower ( ) == chkJ2kExt.Tag.ToString ( ) )
            {
               chkJ2kExt.Checked = true ;
            }
            
            if ( extension.ToLower ( ) == chkJpxExt.Tag.ToString ( ) )
            {
               chkJpxExt.Checked = true ;
            }
            
            if ( extension.ToLower ( ) == chkJp2Ext.Tag.ToString ( ) )
            {
               chkJp2Ext.Checked = true ;
            }
            
            txtExtensions.Text += extension + ";" ;
         }
         
         txtExtensions.Text = txtExtensions.Text.TrimEnd ( ';' ) ;
         
         txtExtensions.TextChanged += new EventHandler ( txtExtensions_TextChanged ) ;
         
         EnableCheckChangedEvent ( ) ;
      }

      private void chkJ2kExt_CheckedChanged ( object sender, EventArgs e )
      {
         try
         {
            CheckBox currentCheck ;
            
            
            txtExtensions.TextChanged -= new EventHandler ( txtExtensions_TextChanged ) ;
            
            currentCheck = ( CheckBox ) sender ;
            
            if ( currentCheck.Checked )
            {
               if ( !txtExtensions.Text.Contains ( currentCheck.Tag.ToString ( ) ) )
               {
                  txtExtensions.Text = currentCheck.Tag.ToString ( ) + ";" + txtExtensions.Text ;
               }
            }
            else
            {
               txtExtensions.Text = txtExtensions.Text.Replace ( currentCheck.Tag.ToString ( ), string.Empty ) ;
            }
            
            txtExtensions.Text = txtExtensions.Text.Replace ( ";;", ";" ) ;
            
            txtExtensions.Text = txtExtensions.Text.Trim ( ';' ) ;
            
            txtExtensions.TextChanged += new EventHandler ( txtExtensions_TextChanged ) ;
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }

      }

      private void txtExtensions_TextChanged(object sender, EventArgs e)
      {
         DisableCheckChangedEvent ( ) ;
         
         string [ ] extensions ;
         bool j2k ;
         bool jp2 ;
         bool jpx ;
         
         
         extensions = txtExtensions.Text.Split ( ';' ) ;
         j2k        = false ;
         jp2        = false ;
         jpx        = false ;
         
         foreach ( string extension in extensions )
         {
            if ( extension.ToLower ( ) == chkJ2kExt.Tag.ToString ( ) )
            {
               j2k = true ;
            }
            
            if ( extension.ToLower ( ) == chkJp2Ext.Tag.ToString ( ) )
            {
               jp2 = true ;
            }
            
            if ( extension.ToLower ( ) == chkJpxExt.Tag.ToString ( ) )
            {
               jpx = true ;
            }
         }
         
         chkJ2kExt.Checked = j2k ;
         chkJp2Ext.Checked = jp2 ;
         chkJpxExt.Checked = jpx ;
         
         EnableCheckChangedEvent ( ) ;
      }
      
      private void DisableCheckChangedEvent ( ) 
      {
         chkJpxExt.CheckedChanged -= new EventHandler ( chkJ2kExt_CheckedChanged ) ;
         chkJp2Ext.CheckedChanged -= new EventHandler ( chkJ2kExt_CheckedChanged ) ;
         chkJ2kExt.CheckedChanged -= new EventHandler ( chkJ2kExt_CheckedChanged ) ;

      }
      
      private void EnableCheckChangedEvent ( ) 
      {
         chkJpxExt.CheckedChanged += new EventHandler ( chkJ2kExt_CheckedChanged ) ;
         chkJp2Ext.CheckedChanged += new EventHandler ( chkJ2kExt_CheckedChanged ) ;
         chkJ2kExt.CheckedChanged += new EventHandler ( chkJ2kExt_CheckedChanged ) ;
      }

      private void btnStart_Click(object sender, EventArgs e)
      {
         try
         {
            _enumerationService.Port = int.Parse ( mtxtPort.Text ) ;
            
            _enumerationService.ImagesExtension.Clear ( ) ;
            
            _enumerationService.ImagesExtension.AddRange ( txtExtensions.Text.Split ( ';' ) ) ;
           
            _enumerationService.Start ( ) ;
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void btnStop_Click(object sender, EventArgs e)
      {
         try
         {
            _enumerationService.Stop ( ) ;
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         this.Close ( ) ;
      }
   }
}
