// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Leadtools.Codecs;

namespace SvgDemo
{
   public partial class PropertiesDialog : Form
   {
      public LoadSvgProperties Properties;
      public string Message;

      public PropertiesDialog()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            _messageLabel.Text = string.Format("Set the options to use when loading files as SVG.{0}These options will be used when loading a new document.", Environment.NewLine);
            _propertyGrid.SelectedObject = this.Properties;
         }

         base.OnLoad(e);
      }
   }

   public class LoadSvgProperties
   {
      public bool DropImages { get; set; }
      public bool DropShapes { get; set; }
      public bool DropText { get; set; }

      public LoadSvgProperties(CodecsLoadSvgOptions options)
      {
         DropImages = options.DropImages;
         DropShapes = options.DropShapes;
         DropText = options.DropText;
      }

      public void UpdateCodecsLoadSvgOptions(CodecsLoadSvgOptions options)
      {
         options.DropImages = DropImages;
         options.DropShapes = DropShapes;
         options.DropText = DropText;
      }
   }
}
