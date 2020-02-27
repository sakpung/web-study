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

namespace Leadtools.Wizard.Pages
{
   public partial class InternalTemplatePage : InternalPage
   {
      public InternalTemplatePage()
      {
         InitializeComponent();
      }
      
      public static Image BannerIcon
      {
         get
         {
            return _bannerIcon ;
         }
         
         set
         {
            _bannerIcon = value ;
         }
      }

      public override void OnSetActive(object sender, WizardCancelEventArgs e)
      {
         try
         {
            base.OnSetActive ( sender, e )  ;
         
            if ( !e.Cancel )
            {
               if ( null == IconPictureBox.Image )
               {
                  if ( null != BannerIcon )
                  {
                     IconPictureBox.Image = BannerIcon ;
                  }
               }
            }
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                           
            throw ;
         }
      }
      
      public static Image _bannerIcon ;
   }
}

