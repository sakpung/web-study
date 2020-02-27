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

using Leadtools.Demos;
using Leadtools;
using Leadtools.ImageProcessing.Color;

namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the IntensityDetectCommand

   public partial class IntensityDetectDialog : Form
   {
      private static bool _firstTimer = true;
      private static int _initialLow;
      private static int _initialHigh;
      private static RasterColor _initialInColor;
      private static RasterColor _initialOutColor;
      private static IntensityDetectCommandFlags _initialChannel;
      private ChannelType[] _channels;

      public int Low;
      public int High;
      public RasterColor InColor;
      public RasterColor OutColor;
      public IntensityDetectCommandFlags Channel;

      private struct ChannelType
      {
         public string Name;
         public IntensityDetectCommandFlags Flags;

         public ChannelType(string n, IntensityDetectCommandFlags f)
         {
            Name = n;
            Flags = f;
         }

         public override string ToString()
         {
            return Name;
         }
      }


      public IntensityDetectDialog()
      {
         InitializeComponent();

         _channels = new ChannelType[] {
            new ChannelType(DemosGlobalization.GetResxString(GetType(), "resx_Master"), IntensityDetectCommandFlags.Master),
            new ChannelType(DemosGlobalization.GetResxString(GetType(), "resx_Master"), IntensityDetectCommandFlags.Master),
            new ChannelType(DemosGlobalization.GetResxString(GetType(), "resx_Red"), IntensityDetectCommandFlags.Red),
            new ChannelType(DemosGlobalization.GetResxString(GetType(), "resx_Green"), IntensityDetectCommandFlags.Green),
            new ChannelType(DemosGlobalization.GetResxString(GetType(), "resx_Blue"), IntensityDetectCommandFlags.Blue),
            new ChannelType(DemosGlobalization.GetResxString(GetType(), "resx_RedAndGreen"), IntensityDetectCommandFlags.Red | IntensityDetectCommandFlags.Green),
            new ChannelType(DemosGlobalization.GetResxString(GetType(), "resx_RedAndBlue"), IntensityDetectCommandFlags.Red | IntensityDetectCommandFlags.Blue),
            new ChannelType(DemosGlobalization.GetResxString(GetType(), "resx_GreenAndBlue"), IntensityDetectCommandFlags.Green | IntensityDetectCommandFlags.Blue),
            new ChannelType(DemosGlobalization.GetResxString(GetType(), "resx_RedGreenBlue"), IntensityDetectCommandFlags.Red | IntensityDetectCommandFlags.Green | IntensityDetectCommandFlags.Blue)};
      }

      private void IntensityDetectDialog_Load(object sender, System.EventArgs e)
      {
         //Set command default values

         if (_firstTimer)
         {
            _firstTimer = false;
            IntensityDetectCommand command = new IntensityDetectCommand();
            _initialLow = 128;
            _initialHigh = 255;

            if (_initialLow >= _initialHigh)
               _initialHigh = _initialLow + 1;

            _initialInColor = command.InColor;
            _initialOutColor = command.OutColor;
            _initialChannel = command.Channel;
         }

         Low = _initialLow;
         High = _initialHigh;
         InColor = _initialInColor;
         OutColor = _initialOutColor;
         Channel = _initialChannel;

         _numLow.Value = Low;
         _numHigh.Value = High;

         foreach (ChannelType i in _channels)
         {
            _cbChannel.Items.Add(i);
            if (i.Flags == Channel)
               _cbChannel.SelectedItem = i;
         }

         if (_cbChannel.SelectedItem == null)
            _cbChannel.SelectedIndex = 0;
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _pnlInColor_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         e.Graphics.FillRectangle(new SolidBrush(Leadtools.Demos.Converters.ToGdiPlusColor(InColor)), _pnlInColor.ClientRectangle);
      }

      private void _pnlOutColor_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         e.Graphics.FillRectangle(new SolidBrush(Leadtools.Demos.Converters.ToGdiPlusColor(OutColor)), _pnlOutColor.ClientRectangle);
      }

      private void _btnInColor_Click(object sender, System.EventArgs e)
      {
         ColorDialog dlg = new ColorDialog();
         dlg.AllowFullOpen = true;
         dlg.AnyColor = true;
         DialogResult res = dlg.ShowDialog(this);
         if (res == DialogResult.OK)
            InColor = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color);
         _pnlInColor.Refresh();
      }

      private void _btnOutColor_Click(object sender, System.EventArgs e)
      {
         ColorDialog dlg = new ColorDialog();
         dlg.AllowFullOpen = true;
         dlg.AnyColor = true;
         DialogResult res = dlg.ShowDialog(this);
         if (res == DialogResult.OK)
            OutColor = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color);
         _pnlOutColor.Refresh();
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         //Update command values
         if (_numLow.Value >= _numHigh.Value)
         {
            Messager.ShowWarning(this, _lblMsg.Text);
            DialogResult = DialogResult.None;
            return;
         }

         Low = (int)_numLow.Value;
         High = (int)_numHigh.Value;

         ChannelType ct = (ChannelType)_cbChannel.SelectedItem;
         Channel = ct.Flags;

         _initialLow = Low;
         _initialHigh = High;
         _initialInColor = InColor;
         _initialOutColor = OutColor;
         _initialChannel = 0;
      }

      private void EnableColorItems(bool enable)
      {
         _lblInColor.Enabled = enable;
         _pnlInColor.Enabled = enable;
         _btnInColor.Enabled = enable;

         _lblOutColor.Enabled = enable;
         _pnlOutColor.Enabled = enable;
         _btnOutColor.Enabled = enable;

      }

      private void _cbChannel_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         bool enable;

         ChannelType ct = (ChannelType)_cbChannel.SelectedItem;

         enable = (ct.Flags != IntensityDetectCommandFlags.Master);
         EnableColorItems(enable);
      }
   }
}
