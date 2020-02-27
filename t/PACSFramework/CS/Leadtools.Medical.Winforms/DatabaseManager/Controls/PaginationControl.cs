// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Leadtools.Medical.Winforms
{
   public partial class PaginationControl : UserControl
   {

      private System.Windows.Forms.TextBox tbHiddenPageSize;

      public PaginationControl()
      {
         InitializeComponent();

         lblPageSize.AutoSize = false;
         lblPageSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

         MinPageSize = 1;
         MaxPageSize = 10000;
         numericUpDownPageSize.TextChanged += NumericUpDownPageSize_TextChanged;

         tbHiddenPageSize = new TextBox();
         tbHiddenPageSize.ReadOnly= true;
         tbHiddenPageSize.Location = numericUpDownPageSize.Location;
         tbHiddenPageSize.Size = numericUpDownPageSize.Size;
         tbHiddenPageSize.Visible = true;

         Controls.Add(tbHiddenPageSize);

         PageSizeReadOnly = true;
      }

      private void NumericUpDownPageSize_TextChanged(object sender, EventArgs e)
      {
         tbHiddenPageSize.Text = numericUpDownPageSize.Value.ToString();
         if (PageSizeChanged != null)
         {
            PageSizeChanged(sender, e);
         }
      }

      public event EventHandler PageSizeChanged;

      public void EnableItems(bool enable)
      {
         this.btnFirst.Enabled = (enable && PageNumber > 1);
         this.btnPrevious.Enabled = (enable && PageNumber > 1);
         this.btnNext.Enabled = (enable && (PageNumber < MaxPageNumber));
         this.btnLast.Enabled = (enable && (PageNumber < MaxPageNumber));

         this.lblStatus.Enabled = enable;

         this.btnGotoPage.Enabled = enable;
         this.updownPageNumber.Enabled = enable;
      }

      public event EventHandler FillClicked;
      public event EventHandler FirstClicked;
      public event EventHandler PreviousClicked;
      public event EventHandler NextClicked;
      public event EventHandler LastClicked;
      public event EventHandler GotoPageClicked;

      public decimal PageNumberIncrement
      {
         get { return updownPageNumber.Increment;}
         set { updownPageNumber.Increment = value;}
      }

      public int PageSize
      {
         get { return Decimal.ToInt32(numericUpDownPageSize.Value); }
         set { numericUpDownPageSize.Value = value; }
      }

      public int PageNumber
      {
         get { return Convert.ToInt32(this.updownPageNumber.Value); }
         set { updownPageNumber.Value = value; }
      }

      public int MinPageNumber
      {
         get { return Convert.ToInt32(this.updownPageNumber.Minimum); }
         set { updownPageNumber.Minimum = value; }
      }

      public int MaxPageNumber
      {
         get { return Convert.ToInt32(this.updownPageNumber.Maximum); }
         set { updownPageNumber.Maximum = value; }
      }

      public string Status
      {
         get { return lblStatus.Text; }
         set { lblStatus.Text = value; }
      }
      
      public string PageSizeLabel
      {
         get { return lblPageSize.Text; }
         set { lblPageSize.Text = value;}
      }
      
      public void UpdateStatus()
      {
         Status = string.Format("{0} / {1}", PageNumber, MaxPageNumber);
      }

      private void btnFillGrid_Click(object sender, EventArgs e)
      {
         if (FillClicked != null)
         {
            FillClicked(sender, e);
         }
      }

      private void btnFirst_Click(object sender, EventArgs e)
      {
         if (FirstClicked != null)
         {
            FirstClicked(sender, e);
         }
      }

      private void btnPrevious_Click(object sender, EventArgs e)
      {
         if (PreviousClicked != null)
         {
            PreviousClicked(sender, e);
         }
      }

      private void btnNext_Click(object sender, EventArgs e)
      {
         if (NextClicked != null)
         {
            NextClicked(sender, e);
         }
      }

      private void btnLast_Click(object sender, EventArgs e)
      {
         if (LastClicked != null)
         {
            LastClicked(sender, e);
         }
      }

      private void btnGotoPage_Click(object sender, EventArgs e)
      {
         if (GotoPageClicked != null)
         {
            GotoPageClicked(sender, e);
         }
      }

      public bool PageSizeReadOnly
      {
         get
         {
            return numericUpDownPageSize.ReadOnly;
         }
         set
         {
            // Hide the numericUpDown arrows if readonly
            // Show the arrows otherwise
            bool readOnly = value;
            numericUpDownPageSize.ReadOnly = readOnly;

            // If readonly, hide the numeric updown and show a textbox
            // This is achieves the same effect as hiding the arrows of the NumericUpDown
            tbHiddenPageSize.Visible = readOnly;
            numericUpDownPageSize.Visible = !readOnly;
         }
      }
      
      public int MinPageSize
      {
         get
         {
            return Decimal.ToInt32(numericUpDownPageSize.Minimum);
         }
         set
         {
            numericUpDownPageSize.Minimum = value;
         }
      }

      public int MaxPageSize
      {
         get
         {
            return Decimal.ToInt32(numericUpDownPageSize.Maximum);
         }
         set
         {
            numericUpDownPageSize.Maximum = value;
         }
      }

   }
}
