// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.WinForms;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Leadtools.Annotations.WinForms
{
   // Provides custom filters for the OpenFileDialog to show supported audio formats only.
   public class WavFileNameEditor : FileNameEditor
   {
      protected override void InitializeDialog(OpenFileDialog openFileDialog)
      {
         if (openFileDialog == null) throw new ArgumentNullException("openFileDialog");

         base.InitializeDialog(openFileDialog);
         openFileDialog.Filter = "Mp3 files(*.mp3)|*.mp3";
      }
   }

   // Provides custom filters for the OpenFileDialog to show supported media formats.
   public class MediaFileNameEditor : FileNameEditor
   {
      protected override void InitializeDialog(OpenFileDialog openFileDialog)
      {
         if (openFileDialog == null) throw new ArgumentNullException("openFileDialog");

         base.InitializeDialog(openFileDialog);

         string filters = "Mp4 files(*.mp4)|*.mp4";
         openFileDialog.Filter = filters;
      }
   }

   public class FillEditor : UITypeEditor
   {
      public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
      {
         return UITypeEditorEditStyle.Modal;
      }
      public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
      {
         IWindowsFormsEditorService svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

         AnnObject annObj = (context.Instance as AutomationObjectDescriptor).Object;

         if (svc != null && annObj != null)
         {
            using (FillDialog fillDialog = new FillDialog(annObj.Fill))
            {
               if (svc.ShowDialog(fillDialog) == DialogResult.OK)
               {
                  if (annObj is AnnHiliteObject)
                  {
                     if(fillDialog.Fill is AnnSolidColorBrush)
                        (annObj as AnnHiliteObject).HiliteColor = (fillDialog.Fill as AnnSolidColorBrush).Color;
                     else if (fillDialog.Fill is AnnHatchBrush)
                        (annObj as AnnHiliteObject).HiliteColor = (fillDialog.Fill as AnnHatchBrush).BackgroundColor;
                  }
                  
                  annObj.Fill = fillDialog.Fill;
               }
            }
         }
         return value; // can also replace the wrapper object here
      }
   }
}
