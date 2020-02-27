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
using Leadtools.ImageProcessing.Effects;
using Leadtools.Demos;

#if ! LEADTOOLS_V17_OR_LATER
using LeadPoint = System.Drawing.Point;
using LeadSize = System.Drawing.Size;
using LeadRect = System.Drawing.Rectangle;
#endif // #if !LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the CombineCommand

   public partial class CombineDialog : Form
   {
      private CombineCommand _CombineCommand;
      private int _X, _Y, _Width, _Height;

      public CombineDialog(RasterImage TempImage)
      {
         InitializeComponent();
         _CombineCommand = new CombineCommand();
         _X = TempImage.Width / 8;
         _Y = TempImage.Height / 8;
         _Width = TempImage.Width;
         _Height = TempImage.Height;

         //Set command default values
         InitializeUI();
      }

      public CombineCommand CombineCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _CombineCommand;
         }
         set
         {
            _CombineCommand = value;
            InitializeUI();
         }
      }
      private void InitializeUI()
      {

         string[] names;

         _cmbSourceRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_SourceNop"));
         _cmbSourceRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_SourceNot"));
         _cmbSourceRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Source0"));
         _cmbSourceRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Source1"));
         _cmbSourceRectangle.SelectedIndex = _cmbSourceRectangle.Items.IndexOf(DemosGlobalization.GetResxString(GetType(), "resx_SourceNop"));

         _cmbDestinationRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_DestinationNop"));
         _cmbDestinationRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_DestinationNot"));
         _cmbDestinationRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Destination0"));
         _cmbDestinationRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Destination1"));
         _cmbDestinationRectangle.SelectedIndex = _cmbDestinationRectangle.Items.IndexOf(DemosGlobalization.GetResxString(GetType(), "resx_DestinationNop"));

         names = Enum.GetNames(typeof(CombineCommandFlags));
         string str = "Operation";
         string str1 = "Absolute";
         foreach (string name in names)
         {
            int index = name.IndexOf(str);
            if (index != -1)
               _cmbOperation.Items.Add(name);
            index = name.IndexOf(str1);
            if (index != -1)
               _cmbOperation.Items.Add(name);

         }
         _cmbOperation.SelectedIndex = _cmbOperation.Items.IndexOf("OperationAnd");

         _cmbResultImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_ResultNop"));
         _cmbResultImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_ResultNot"));
         _cmbResultImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Result0"));
         _cmbResultImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Result1"));
         _cmbResultImageRectangle.SelectedIndex = _cmbResultImageRectangle.Items.IndexOf(DemosGlobalization.GetResxString(GetType(), "resx_ResultNop"));

         _cmbSourceImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_SourceMaster"));
         _cmbSourceImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_SourceRed"));
         _cmbSourceImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_SourceGreen"));
         _cmbSourceImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_SourceBlue"));
         _cmbSourceImageRectangle.SelectedIndex = _cmbSourceImageRectangle.Items.IndexOf(DemosGlobalization.GetResxString(GetType(), "resx_SourceMaster"));

         _cmbDestinationImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_DestinationMaster"));
         _cmbDestinationImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_DestinationRed"));
         _cmbDestinationImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_DestinationGreen"));
         _cmbDestinationImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_DestinationBlue"));
         _cmbDestinationImageRectangle.SelectedIndex = _cmbDestinationImageRectangle.Items.IndexOf(DemosGlobalization.GetResxString(GetType(), "resx_DestinationMaster"));

         _cmbChannelResultImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_ResultMaster"));
         _cmbChannelResultImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_ResultRed"));
         _cmbChannelResultImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_ResultGreen"));
         _cmbChannelResultImageRectangle.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_ResultBlue"));
         _cmbChannelResultImageRectangle.SelectedIndex = _cmbChannelResultImageRectangle.Items.IndexOf(DemosGlobalization.GetResxString(GetType(), "resx_ResultMaster"));

         _numX.Maximum = _Width;
         _numX.Value = _X;

         _numY.Maximum = _Height;
         _numY.Value = _Y;

         _numWidth.Maximum = _Width;
         _numWidth.Value = (int)(_Width / 2);

         _numHeight.Maximum = _Height;
         _numHeight.Value = (int)(_Height / 2);

         _numPointX.Maximum = _Width;

         _numPointY.Maximum = _Height;

      }

      private void UpdateCommand()
      {
         _CombineCommand.Flags = (CombineCommandFlags)0;

         _CombineCommand.Flags |= TranslateSourceRectangle();
         _CombineCommand.Flags |= TranslateDestinationRectangle();
         _CombineCommand.Flags |= TranslateOperation();
         _CombineCommand.Flags |= TranslateResultImageRectangle();
         _CombineCommand.Flags |= TranslateDestinationImageRectangle();
         _CombineCommand.Flags |= TranslateSourceImageRectangle();
         _CombineCommand.Flags |= TranslateChannelResultImageRectangle();

         _CombineCommand.DestinationRectangle = new LeadRect
            ((int)_numX.Value, (int)_numY.Value, (int)_numWidth.Value, (int)_numHeight.Value);

         _CombineCommand.SourcePoint = new LeadPoint
            ((int)_numPointX.Value, (int)_numPointY.Value);
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }

      public CombineCommandFlags TranslateSourceRectangle()
      {
         switch (_cmbSourceRectangle.SelectedIndex)
         {
            case 0:
               return CombineCommandFlags.SourceNop;
            case 1:
               return CombineCommandFlags.SourceNot;
            case 2:
               return CombineCommandFlags.Source0;
            case 3:
               return CombineCommandFlags.Source1;
            default:
               return CombineCommandFlags.SourceNop;

         }
      }
      public CombineCommandFlags TranslateDestinationRectangle()
      {
         switch (_cmbDestinationRectangle.SelectedIndex)
         {
            case 0:
               return CombineCommandFlags.DestinationNop;
            case 1:
               return CombineCommandFlags.DestinationNot;
            case 2:
               return CombineCommandFlags.Destination0;
            case 3:
               return CombineCommandFlags.Destination1;
            default:
               return CombineCommandFlags.DestinationNop;
         }
      }

      public CombineCommandFlags TranslateOperation()
      {
         switch (_cmbOperation.SelectedIndex)
         {
            case 0:
               return CombineCommandFlags.OperationAnd;
            case 1:
               return CombineCommandFlags.OperationOr;
            case 2:
               return CombineCommandFlags.OperationXor;
            case 3:
               return CombineCommandFlags.OperationAdd;
            case 4:
               return CombineCommandFlags.OperationSubtractSource;
            case 5:
               return CombineCommandFlags.OperationSubtractDestination;
            case 6:
               return CombineCommandFlags.OperationMultiply;
            case 7:
               return CombineCommandFlags.OperationDivideSource;
            case 8:
               return CombineCommandFlags.OperationDivideDestination;
            case 9:
               return CombineCommandFlags.OperationAverage;
            case 10:
               return CombineCommandFlags.OperationMinimum;
            case 11:
               return CombineCommandFlags.OperationMaximum;
            case 12:
               return CombineCommandFlags.AbsoluteDifference;
            default:
               return CombineCommandFlags.OperationAnd;
         }
      }

      public CombineCommandFlags TranslateResultImageRectangle()
      {
         switch (_cmbSourceRectangle.SelectedIndex)
         {
            case 0:
               return CombineCommandFlags.ResultNop;
            case 1:
               return CombineCommandFlags.ResultNot;
            case 2:
               return CombineCommandFlags.Result0;
            case 3:
               return CombineCommandFlags.Result1;
            default:
               return CombineCommandFlags.ResultNop;
         }
      }

      public CombineCommandFlags TranslateDestinationImageRectangle()
      {
         switch (_cmbSourceRectangle.SelectedIndex)
         {
            case 0:
               return CombineCommandFlags.DestinationMaster;
            case 1:
               return CombineCommandFlags.DestinationRed;
            case 2:
               return CombineCommandFlags.DestinationGreen;
            case 3:
               return CombineCommandFlags.DestinationBlue;
            default:
               return CombineCommandFlags.DestinationMaster;
         }
      }

      public CombineCommandFlags TranslateSourceImageRectangle()
      {
         switch (_cmbSourceRectangle.SelectedIndex)
         {
            case 0:
               return CombineCommandFlags.SourceMaster;
            case 1:
               return CombineCommandFlags.SourceRed;
            case 2:
               return CombineCommandFlags.SourceGreen;
            case 3:
               return CombineCommandFlags.SourceBlue;
            default:
               return CombineCommandFlags.SourceMaster;
         }
      }

      public CombineCommandFlags TranslateChannelResultImageRectangle()
      {
         switch (_cmbSourceRectangle.SelectedIndex)
         {
            case 0:
               return CombineCommandFlags.ResultMaster;
            case 1:
               return CombineCommandFlags.ResultRed;
            case 2:
               return CombineCommandFlags.ResultGreen;
            case 3:
               return CombineCommandFlags.ResultBlue;
            default:
               return CombineCommandFlags.ResultMaster;
         }
      }

      private void _numX_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numWidth_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numY_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numHeight_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numPointX_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numPointY_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }
   }
}
