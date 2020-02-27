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
using Leadtools.Forms.Processing;
using Leadtools.Demos;

namespace FormsDemo
{
   public partial class DetailedTableResults : Form
   {
      TableFormField _table;

      public DetailedTableResults(TableFormField table)
      {
         _table = table;
         InitializeComponent();
         _tableResults.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
         _tableResults.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
         foreach(TableColumn column in _table.Columns)
         {
            int index = _tableResults.Columns.Add(column.OcrField.Name, column.OcrField.Name);
            if(column.Alignment==FieldAlignment.Left)
               _tableResults.Columns[index].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleLeft;
            else if(column.Alignment==FieldAlignment.Right)
               _tableResults.Columns[index].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleRight;
            else if(column.Alignment==FieldAlignment.Center)
               _tableResults.Columns[index].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
         }

         TableFormFieldResult results = table.Result as TableFormFieldResult;
         if (results != null)
         {
            for (int i = 0 ; i < results.Rows.Count ; i++)
            {
               TableFormRow row = results.Rows[i];
               _tableResults.Rows.Add();

               int lineCounter = 1;
               for (int j = 0 ; j < row.Fields.Count ; j++)
               {
                  OcrFormField ocrField = row.Fields[j];
                  if (ocrField is TextFormField)
                  {
                     TextFormFieldResult txtResults = ocrField.Result as TextFormFieldResult;
                     _tableResults.Rows[i].Cells[j].Value = txtResults.Text;
                     int counter = 1;
                     
                     if(txtResults.Text!=null)
                        counter += CountCharacterInString(txtResults.Text,'\n');

                     if (counter > lineCounter)
                        lineCounter = counter;

                     _tableResults.Rows[i].Cells[j].Tag = ocrField;
                  }
                  else if (ocrField is OmrFormField)
                  {
                     OmrFormFieldResult omrResults = ocrField.Result as OmrFormFieldResult;
                     _tableResults.Rows[i].Cells[j].Value = omrResults.Text;
                     _tableResults.Rows[i].Cells[j].Tag = ocrField;
                  }
               }

               _tableResults.Rows[i].Height *= lineCounter;
            }
         }
      }

      int CountCharacterInString(String str, char c)
      {
         int counter = 0;
         for (int i = 0; i < counter; i++)
         {
            if (str[i] == c)
               counter++;
         }
         return counter;
      }

      private void _tableResults_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         try
         {
            if (_tableResults.Rows.Count > 0 && _tableResults.SelectedCells.Count == 1)
            {
               OcrFormField field = _tableResults.SelectedCells[0].Tag as OcrFormField;
               
               if (field is TextFormField || field is OmrFormField)
               {
                  DetailedCharacterResults detailedResultsdialog = new DetailedCharacterResults(field);
                  detailedResultsdialog.ShowDialog(this);
               }
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }
   }
}
