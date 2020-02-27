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
using Leadtools;
using Leadtools.ImageProcessing;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the ChangeViewPerspectiveCommand

   public partial class ChangeViewPerspectiveDialog : Form
   {
      private ChangeViewPerspectiveCommand _ChangeViewPerspectiveCommand;

      public ChangeViewPerspectiveDialog()
      {
         InitializeComponent();
         _ChangeViewPerspectiveCommand = new ChangeViewPerspectiveCommand();

         //Set command default values
         InitializeUI();

      }
      private void InitializeUI()
      {
         string[] names;
         Array numbers;

         names = Enum.GetNames(typeof(RasterViewPerspective));
         numbers = Enum.GetValues(typeof(RasterViewPerspective));

         for (int i = 1; i <= 8; i++)
         {
            _cmbViewPerspective.Items.Add(((RasterViewPerspective)i).ToString());
         }

         _cmbViewPerspective.SelectedIndex = 0;
      }
      public ChangeViewPerspectiveCommand ChangeViewPerspectivecommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _ChangeViewPerspectiveCommand;
         }
         set
         {
            _ChangeViewPerspectiveCommand = value;
            InitializeUI();
         }
      }
      private void UpdateCommand()
      {
         _ChangeViewPerspectiveCommand.ViewPerspective = TranslateViewPerspective();
      }

      public RasterViewPerspective TranslateViewPerspective()
      {
         switch (_cmbViewPerspective.SelectedItem.ToString())
         {
            case "BottomLeft":
               return RasterViewPerspective.BottomLeft;
            case "BottomLeft180":
               return RasterViewPerspective.BottomLeft180;
            case "BottomLeft270":
               return RasterViewPerspective.BottomLeft270;
            case "BottomLeft90":
               return RasterViewPerspective.BottomLeft90;
            case "BottomRight":
               return RasterViewPerspective.BottomRight;
            case "LeftBottom":
               return RasterViewPerspective.LeftBottom;
            case "LeftTop":
               return RasterViewPerspective.LeftTop;
            case "RightBottom":
               return RasterViewPerspective.RightBottom;
            case "RightTop":
               return RasterViewPerspective.RightTop;
            case "TopLeft":
               return RasterViewPerspective.TopLeft;
            case "TopLeft180":
               return RasterViewPerspective.TopLeft180;
            case "TopLeft270":
               return RasterViewPerspective.TopLeft270;
            case "TopLeft90":
               return RasterViewPerspective.TopLeft90;
            case "TopRight":
               return RasterViewPerspective.TopRight;
            default:
               return RasterViewPerspective.TopLeft;
         }
      }

      private void _btnok_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btncancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }
   }
}
