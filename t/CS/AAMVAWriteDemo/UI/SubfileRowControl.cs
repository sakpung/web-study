using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Barcode;

namespace AAMVAWriteDemo
{
   public partial class SubfileRowControl : UserControl
   {

      private AAMVASubfileType _subfileType;
      public AAMVASubfileType SubfileType
      {
         get
         {
            return _subfileType;
         }
         set
         {
            _subfileType = value;
            switch(value)
            {
               case AAMVASubfileType.DL:
                  _textBoxSubfileType.Text = "DL";
                  _labelSubfileType.Text = "Driver's License";
                  break;
               case AAMVASubfileType.ID:
                  _textBoxSubfileType.Text = "ID";
                  _labelSubfileType.Text = "ID";
                  break;
               case AAMVASubfileType.JurisdictionSpecific:
                  string abbr = AAMVAID.LookupStateAbbreviation(_jurisdiction);
                  if (abbr != null)
                  {
                     _textBoxSubfileType.Text = "Z" + abbr[0];
                     _labelSubfileType.Text = "Jurisdiction-Specific";
                  }
                  else
                  {
                     _textBoxSubfileType.Text = "ZX";
                     _labelSubfileType.Text = "Jurisdiction-Specific";
                  }
                  break;

            }
         }
      }

      private AAMVAJurisdiction _jurisdiction;
      public AAMVAJurisdiction Jurisdiction
      {
         get
         {
            return _jurisdiction;
         }
         set
         {
            _jurisdiction = value;
         }
      }


      private int _subfileIndex;
      public int SubfileIndex
      {
         get
         {
            return _subfileIndex;
         }
         set
         {
            _subfileIndex = value;
         }
      }

      public MainForm ParentMainForm { get; set; }

      public SubfileRowControl()
      {
         InitializeComponent();
      }

      private void _btnDelete_Click(object sender, EventArgs e)
      {
         ParentMainForm.RemoveSubfile(_subfileIndex);
      }

      private void _btnEdit_Click(object sender, EventArgs e)
      {
         ParentMainForm.OpenEditSubfileDialog(_subfileIndex, EditSubfileDialog.EditMode.Edit);
      }
   }
}
