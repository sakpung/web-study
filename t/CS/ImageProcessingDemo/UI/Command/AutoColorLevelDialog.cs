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
using Leadtools.Demos;
  
namespace ImageProcessingDemo
{
   //This dialog is used to allow the user to specify values which
   //will be used for the AutoColorLevelCommand
   public partial class AutoColorLevelDialog : Form
   {
      private AutoColorLevelCommand _AutoColorLevelCommand;
      private int _BlackClip, _WhiteClip;

      public AutoColorLevelDialog()
      {
         InitializeComponent();
         _AutoColorLevelCommand = new AutoColorLevelCommand();
         _BlackClip = 50;
         _WhiteClip = 50;
         //Set command default values
         InitializeUI();
 
      }

      public AutoColorLevelCommand AutoColorLevelCommand
      {
         get
         {
            //Update command values
            UpdateCommand();
            return _AutoColorLevelCommand;
         }
         set
         {
            _AutoColorLevelCommand = value;
            InitializeUI();
         }
      }

      private void InitializeUI()
      {
         string[] names;
         names = Enum.GetNames(typeof(AutoColorLevelCommandFlags));
         foreach (string name in names)
         {
            //if(name != "None")
               _cmbFlag.Items.Add(name);
         }
         _cmbFlag.SelectedIndex = 0;

         names = Enum.GetNames(typeof(AutoColorLevelCommandType));
         foreach (string name in names)
         {
            if (name != "None")
               _cmbType.Items.Add(name);
         }
         _cmbType.SelectedIndex = 0;

         _numBlackClip.Value = _BlackClip;
         _numWhiteClip.Value = _WhiteClip;   
      }

      private void UpdateCommand()
      {
         _BlackClip = Convert.ToInt32(_numBlackClip.Value);
         _WhiteClip = Convert.ToInt32(_numWhiteClip.Value);

         _AutoColorLevelCommand.BlackClip = _BlackClip;
         _AutoColorLevelCommand.WhiteClip = _WhiteClip;
         _AutoColorLevelCommand.Flag = TranslateFlag();
         _AutoColorLevelCommand.Type = TranslateType();
      }

      public AutoColorLevelCommandType TranslateType()
      {
         switch (_cmbFlag.SelectedIndex)
         {
            case 0:
               return AutoColorLevelCommandType.Level;  
            case 1:
               return AutoColorLevelCommandType.Contrast;
            case 2:
               return AutoColorLevelCommandType.Intensity;
            default:
               return AutoColorLevelCommandType.Level;
         }
      }

      public AutoColorLevelCommandFlags TranslateFlag()
      {
         switch (_cmbFlag.SelectedIndex)
         {
            case 0:
               return AutoColorLevelCommandFlags.None;
            case 1:
               return AutoColorLevelCommandFlags.NoProcess;
            default:
               return AutoColorLevelCommandFlags.None;
         }
      }

      private void _numBlackClip_ValueChanged(object sender, EventArgs e)
      {
         _tbBlackClip.Value = Convert.ToInt32(_numBlackClip.Value);    
      }

      private void _numWhiteClip_ValueChanged(object sender, EventArgs e)
      {
         _tbWhiteClip.Value = Convert.ToInt32(_numWhiteClip.Value);
      }

      private void _tbBlackClip_Scroll(object sender, EventArgs e)
      {
         _numBlackClip.Value = _tbBlackClip.Value;   
      }

      private void _tbWhiteClip_Scroll(object sender, EventArgs e)
      {
         _numWhiteClip.Value = _tbWhiteClip.Value;   
      }

      private void _numBlackClip_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _numWhiteClip_Leave(object sender, EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
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
   }
}
