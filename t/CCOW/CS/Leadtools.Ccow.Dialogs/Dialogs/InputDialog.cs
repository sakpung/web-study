// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

namespace Leadtools.Ccow.Dialogs
{
   public partial class InputDialog : Form
   {
      private string _Prompt;

      public string Prompt
      {
         get { return _Prompt; }
         set { _Prompt = value; }
      }

      private string _Title;

      public string Title
      {
         get { return _Title; }
         set { _Title = value; }
      }

      private string _DefaultValue;

      public string DefaultValue
      {
         get { return _DefaultValue; }
         set { _DefaultValue = value; }
      }

      public string Response
      {
         get
         {
            return textBoxResponse.Text;
         }
      }

      public InputDialog()
      {
         InitializeComponent();
      }

      private void InputDialog_Load(object sender, EventArgs e)
      {
         textBoxResponse.Text = _DefaultValue;
         Text = _Title;
         labelPrompt.Text = _Prompt;
      }

      private void InputDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
      }
   }
}
