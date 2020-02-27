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
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Effects;
using Leadtools.Demos;  
  
namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the RemapIntensityCommand

   public partial class RemapIntensityDialog : Form
   {
      private RemapIntensityCommand _RemapIntensityCommand;
      private int[] lut;
      Point[] CurvePoints = new Point[256];
      private int _start, _end;
      
      public RemapIntensityDialog()
      {
         InitializeComponent();
         _RemapIntensityCommand = new RemapIntensityCommand();
         _start = 0;
         _end = 255;

         //Set command default values
         InitializeUI(); 
      }

      public RemapIntensityCommand RemapIntensityCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _RemapIntensityCommand;
         }
         set
         {
            _RemapIntensityCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         string[] names;
         names = Enum.GetNames(typeof(RemapIntensityCommandFlags));
         foreach (string name in names)
         {
            if ((name != "ChangeHighBit") && (name != "Normal"))
            _cmbChannel.Items.Add(name);
         }
         _cmbChannel.SelectedIndex = 0;

         _cmbMapping.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_DecreaseIntensity"));
         _cmbMapping.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_IncreaseIntensity"));
         _cmbMapping.Items.Add(DemosGlobalization.GetResxString(GetType(), "resx_Invert"));

         _cmbMapping.SelectedIndex = 0;
   
         _numStart.Value = _start;  
         _numEnd.Value = _end;  
      }

      private void UpdateCommand()
      {
         _RemapIntensityCommand.Flags = (RemapIntensityCommandFlags)0;
         
         _RemapIntensityCommand.Flags |= TranslateChannel();
         _RemapIntensityCommand.Flags |= RemapIntensityCommandFlags.Normal;  

         _start = Convert.ToInt32(_numStart.Value);
         _end = Convert.ToInt32(_numEnd.Value);
         _RemapIntensityCommand.LookupTable = lut.Clone() as int[]; 
      }

      public RemapIntensityCommandFlags TranslateChannel()
      {
         switch (_cmbChannel.SelectedIndex)
         {
            case 0:
               return RemapIntensityCommandFlags.Master;  
            case 1:
               return RemapIntensityCommandFlags.Red;  
            case 2:
               return RemapIntensityCommandFlags.Green;  
            case 3:
               return RemapIntensityCommandFlags.Blue;  
            default:
               return RemapIntensityCommandFlags.Master;  
         }
      }

      private void _lblGraph_Paint(object sender, PaintEventArgs e)
      {
         Pen DrawPen = new Pen(Brushes.Gray);
         Pen CurvePen = new Pen(Brushes.Black);   

         for (int i = 1; i <= 8; i++)
         {
            e.Graphics.DrawLine(DrawPen, new Point(i * 32, 0), new Point(i * 32, 255));
            e.Graphics.DrawLine(DrawPen, new Point(0, i * 32), new Point(255, i * 32));
         }

         e.Graphics.DrawCurve(CurvePen, CurvePoints);   
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

      private void FillGraph()
      {
         _start = Convert.ToInt32(_numStart.Value);
         _end = Convert.ToInt32(_numEnd.Value);
         lut = new int[256];

         if (_cmbMapping.SelectedItem.ToString() == "Increase Intensity")
         {
            for (int j = 0; j < lut.Length; j++)
               if(j<127)
                  lut[j] = j*2;
               else
                  lut[j] = 255;
         }

         if (_cmbMapping.SelectedItem.ToString() == "Decrease Intensity")
         {
            for (int j = 0; j < lut.Length; j++)
               lut[j] = j/3;            
         }

         if (_cmbMapping.SelectedItem.ToString() == "Invert")
         {
            for (int j = 0; j < lut.Length; j++)
               lut[j] = 255 - j; 
         }


         for (int j = 0; j < lut.Length; j++)
         {
            CurvePoints[j] = new Point(j, 255 - lut[j]);
         }

         _lblGraph.Invalidate();
         _lblGraph.Refresh(); 
 
      }
      private void _cmbMapping_SelectedIndexChanged(object sender, EventArgs e)
      {
         FillGraph();
      }

      private void _numStart_Leave(object sender, EventArgs e)
      {
         Leadtools.Demos.DialogUtilities.NumericOnLeave(sender);   
      }

      private void _numEnd_Leave(object sender, EventArgs e)
      {
         Leadtools.Demos.DialogUtilities.NumericOnLeave(sender);
      }

      private void _numStart_ValueChanged(object sender, EventArgs e)
      {
         FillGraph();
      }

      private void _numEnd_ValueChanged(object sender, EventArgs e)
      {
         FillGraph();
      }

      private void _lblGraph_MouseMove(object sender, MouseEventArgs e)
      {
         _lblXVal.Text = e.X.ToString();
         _lblYVal.Text = e.Y.ToString();
      }
   }

}
