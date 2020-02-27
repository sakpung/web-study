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
using Leadtools.Demos;
using Leadtools.Forms.Recognition;
using Leadtools.Forms.Processing;

namespace FormsDemo
{
   public partial class DetailedCharacterResults : Form
   {
      public DetailedCharacterResults(FormField field)
      {
         InitializeComponent();         
         
         if (field is TextFormField)
         {
            for (int i = 0; i < ((field as TextFormField).Result as TextFormFieldResult).Characters.Count; i++)
            {
               string[] row = new string[5];
               row[0] = ((field as TextFormField).Result as TextFormFieldResult).Characters[i].Code.ToString();
               row[1] = ((field as TextFormField).Result as TextFormFieldResult).Characters[i].GuessCode2.ToString();
               row[2] = ((field as TextFormField).Result as TextFormFieldResult).Characters[i].FontStyle.ToString();
               row[3] = ((field as TextFormField).Result as TextFormFieldResult).Characters[i].FontSize.ToString();
               row[4] = ((field as TextFormField).Result as TextFormFieldResult).Characters[i].Bounds.ToString();
               _charResults.Rows.Add(row);
            }
         }
         else if (field is UnStructuredTextFormField)
         {
            for (int i = 0; i < ((field as UnStructuredTextFormField).Result as TextFormFieldResult).Characters.Count; i++)
            {
               string[] row = new string[5];
               row[0] = ((field as UnStructuredTextFormField).Result as TextFormFieldResult).Characters[i].Code.ToString();
               row[1] = ((field as UnStructuredTextFormField).Result as TextFormFieldResult).Characters[i].GuessCode2.ToString();
               row[2] = ((field as UnStructuredTextFormField).Result as TextFormFieldResult).Characters[i].FontStyle.ToString();
               row[3] = ((field as UnStructuredTextFormField).Result as TextFormFieldResult).Characters[i].FontSize.ToString();
               row[4] = ((field as UnStructuredTextFormField).Result as TextFormFieldResult).Characters[i].Bounds.ToString();
               _charResults.Rows.Add(row);
            }
         }
         else if (field is OmrFormField)
         {
            for (int i = 0; i < ((field as OmrFormField).Result as OmrFormFieldResult).Characters.Count; i++)
            {
               string[] row = new string[5];
               row[0] = ((field as OmrFormField).Result as OmrFormFieldResult).Characters[i].Code.ToString();
               row[1] = ((field as OmrFormField).Result as OmrFormFieldResult).Characters[i].GuessCode2.ToString();
               row[2] = ((field as OmrFormField).Result as OmrFormFieldResult).Characters[i].FontStyle.ToString();
               row[3] = ((field as OmrFormField).Result as OmrFormFieldResult).Characters[i].FontSize.ToString();
               row[4] = ((field as OmrFormField).Result as OmrFormFieldResult).Characters[i].Bounds.ToString();
               _charResults.Rows.Add(row);
            }
         }
#if LEADTOOLS_V20_OR_LATER
         else if (field is OmrAnswerAreaField)
         {
            if(_charResults.Columns.Count == 5)
            {
               _charResults.Columns[0].HeaderText = "Field";
               _charResults.Columns[1].HeaderText = "Type";
               _charResults.Columns[2].HeaderText = "Result";
               _charResults.Columns[3].HeaderText = "Confidence";
               _charResults.Columns[4].HeaderText = "Bounding Rectangle";
            }
            

            for (int i = 0; i < (field as OmrAnswerAreaField).Answers.Count; i++)
            {
               string[] row = new string[5];
               row[0] = ((field as OmrAnswerAreaField).Answers[i] as SingleSelectionField).Name;
               row[1] = "SingleSelectionField";
               row[2] = ((field as OmrAnswerAreaField).Answers[i].Result as OmrFormFieldResult).Text;
               row[3] = ((field as OmrAnswerAreaField).Answers[i].Result as OmrFormFieldResult).AverageConfidence.ToString();
               row[4] = (field as OmrAnswerAreaField).Answers[i].Bounds.ToString(); 
               _charResults.Rows.Add(row);
            }
         }
#endif //#if LEADTOOLS_V20_OR_LATER
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.OK;
      }
   }
}
