// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Leadtools.Medical.Winforms
{
   public partial class StorageClassesTabControl : UserControl
   {
      public StorageClassesTabControl()
      {
         InitializeComponent();
      }

      private PresentationContextList _presentationContextList;

      public PresentationContextList PresentationContextList
      {
         get { return _presentationContextList; }
         set { _presentationContextList = value; }
      }
      
      public event EventHandler SettingsChanged;
      
      public void Initialize()
      {
         _storageClassControl = new StorageClassesControl(StorageClassesControlType.StorageClasses);
         _storageClassControl.PresentationContextList = _presentationContextList;
         _storageClassControl.Initialize();
         _storageClassControl.Dock = DockStyle.Fill;
         tabPageStorageClass.Controls.Add(_storageClassControl);

         _transferSyntaxControl = new StorageClassesControl(StorageClassesControlType.TransferSyntax);
         _transferSyntaxControl.PresentationContextList = _presentationContextList;
         _transferSyntaxControl.Initialize();
         _transferSyntaxControl.Dock = DockStyle.Fill;
         tabPageTransferSyntax.Controls.Add(_transferSyntaxControl);

         _storageClassControl.SettingsChanged += new EventHandler(OnSettingsChanged);
         _transferSyntaxControl.SettingsChanged += new EventHandler(OnSettingsChanged);
      }

      public void Reset()
      {
         _storageClassControl.PresentationContextList = _presentationContextList;
         _storageClassControl.Initialize();

         _transferSyntaxControl.PresentationContextList = _presentationContextList;
         _transferSyntaxControl.Initialize();
      }

      private void OnSettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (SettingsChanged != null)
            {
               SettingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }
      
      public bool IsDirty
      {
         get
         {
            return _storageClassControl.IsDirty || _transferSyntaxControl.IsDirty ;
         }
      }
      
      private StorageClassesControl _storageClassControl;
      private StorageClassesControl _transferSyntaxControl;

      internal void ChangesCommited ( )
      {
         _storageClassControl.ChangesCommited ( ) ;
         _transferSyntaxControl.ChangesCommited ( ) ;
      }
   }
}
