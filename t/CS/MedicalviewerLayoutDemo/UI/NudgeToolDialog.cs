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

using Leadtools.MedicalViewer;

namespace MedicalViewerLayoutDemo
{
   public partial class NudgeToolDialog : Form
   {
      MedicalViewerActionType _type;

      MedicalViewerNudgeToolShape _shapeType;
      public MedicalViewerNudgeToolShape Type
      {
         get
         {
            if (_rdoRectangle.Checked)
               return MedicalViewerNudgeToolShape.Rectangle;
            if (_rdoEllipse.Checked)
               return MedicalViewerNudgeToolShape.Ellipse;
            if (_rdoSlash.Checked)
               return MedicalViewerNudgeToolShape.Slash;

            return MedicalViewerNudgeToolShape.BackSlash;
         }

         set
         {
            _shapeType = value;
            if (value == MedicalViewerNudgeToolShape.Rectangle)
               _rdoRectangle.Checked = true;
            if (value == MedicalViewerNudgeToolShape.Ellipse)
               _rdoEllipse.Checked = true;
            if (value == MedicalViewerNudgeToolShape.Slash)
               _rdoSlash.Checked = true;
            if (value == MedicalViewerNudgeToolShape.BackSlash)
               _rdoBackSlash.Checked = true;
         }
      }

      public NudgeToolDialog(MainForm owner, MedicalViewerActionType actionType)
      {
         InitializeComponent();
         _type = actionType;
        if (_type == MedicalViewerActionType.ShrinkTool)
            Text = "Shrink Tool Dialog";
        else
            Text = "Nudge Tool Dialog";

         MedicalViewerNudgeTool nudgeToolProperties = (MedicalViewerNudgeTool)owner.Viewer.GetActionProperties(_type);
         
         _txtHeight.Text = nudgeToolProperties.Height.ToString();
         _txtWidth.Text = nudgeToolProperties.Width.ToString();
         Type = nudgeToolProperties.Shape;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         MedicalViewerNudgeTool nudgeToolProperties = (MedicalViewerNudgeTool)((MainForm)this.Owner).Viewer.GetActionProperties(_type);

         nudgeToolProperties.Width = Convert.ToInt32(_txtWidth.Text);
         nudgeToolProperties.Height = Convert.ToInt32(_txtHeight.Text);
         nudgeToolProperties.Shape = Type;

         ((MainForm)this.Owner).Viewer.SetActionProperties(_type, nudgeToolProperties);

         this.Close();
      }

   }
}
