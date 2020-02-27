// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections ;
using System.ComponentModel ;
using System.Drawing ;
using System.Data ;
using System.Windows.Forms ;

namespace Leadtools.Medical.Winforms.Control
{
   public class DateRangeFilter : System.Windows.Forms.UserControl
   {
      #region Public
         
         #region Methods
         
            public DateRangeFilter ( )
            {
               try
               {
                  InitializeComponent ( ) ;
               
                  Init ( ) ;
               
                  RegisterEvents ( ) ;  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            
         #endregion
         
         #region Properties
         
            public DateTimePickerFormat DateControlFormat
            {
               get
               {
                  return dtpicFrom.Format ;
               }
               
               set
               {
                  dtpicFrom.Format = value ;
                  dtpicTo.Format   = value ;
               }
            }
         
            public RangeFilterType SelectedDateFilter
            {
               get
               {
                  RangeFilterType ResultFilterTypeEnum ; 
                  
                  
                  ResultFilterTypeEnum = RangeFilterType.Months ; //There is no initial value except that we know that the months check is checked by default
                  
                  if ( rbtnMonths.Checked ) 
                  {
                     ResultFilterTypeEnum = RangeFilterType.Months ;
                  }
                  
                  
                  if ( rbtnDays.Checked ) 
                  {
                     ResultFilterTypeEnum = RangeFilterType.Days ;
                  }
                  
                  
                  if ( rbtnBetween.Checked ) 
                  {
                     ResultFilterTypeEnum = RangeFilterType.DateRange ;
                  }
                  
                  return ResultFilterTypeEnum ;
               }
            }
            
            
            public string LastMonths
            {
               get
               {
                  if ( rbtnMonths.Checked )
                  {
                     return spnMonths.Value.ToString ( ) ;
                  }
                  else
                  {
                     return null ;
                  }
               }
            }
            
            
            public string LastDays
            {
               get
               {
                  if ( rbtnDays.Checked )
                  {
                     return spnDays.Value.ToString ( ) ;
                  }
                  else
                  {
                     return null ;
                  }
               }
            }
            
            
            public string DateRangeFrom
            {
               get
               {
                  if ( rbtnBetween.Checked ) 
                  {
                     if ( dtpicFrom.Checked && dtpicTo.Checked )
                     {
                        return ( dtpicFrom.Value <  dtpicTo.Value ) ? dtpicFrom.Value.ToString ( ) : dtpicTo.Value.ToString ( ) ;
                     }
                     
                     if ( dtpicFrom.Checked )
                     {
                        return dtpicFrom.Value.ToString ( ) ;
                     }
                     else
                     {
                        return string.Empty ;
                     }
                  }
                  
                  return null ;
               }
            }
            
            
            public string DateRangeTo
            {
               get
               {
                  if ( rbtnBetween.Checked ) 
                  {
                     if ( dtpicFrom.Checked && dtpicTo.Checked )
                     {
                        return ( dtpicFrom.Value >  dtpicTo.Value ) ? dtpicFrom.Value.ToString ( ) : dtpicTo.Value.ToString ( ) ;
                     }

                     if ( dtpicTo.Checked )
                     {
                        return dtpicTo.Value.ToString ( ) ;
                     }
                     else
                     {
                        return string.Empty ;
                     }
                  }
                  
                  return null ;
               }
            }
            
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
         
            public enum RangeFilterType
            {
               Months,
               Days,
               DateRange
            }
         
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
         
            protected override void Dispose ( bool disposing )
            {
               if ( disposing )
               {
                  if ( components != null )
                  {
                     components.Dispose ( ) ;
                  }
               }
               
               base.Dispose ( disposing ) ;
            }

            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private void InitializeComponent ( )
            {
               this.rbtnMonths = new System.Windows.Forms.RadioButton();
               this.rbtnDays = new System.Windows.Forms.RadioButton();
               this.rbtnBetween = new System.Windows.Forms.RadioButton();
               this.spnMonths = new System.Windows.Forms.NumericUpDown();
               this.spnDays = new System.Windows.Forms.NumericUpDown();
               this.lblMonths = new System.Windows.Forms.Label();
               this.lblDays = new System.Windows.Forms.Label();
               this.dtpicFrom = new System.Windows.Forms.DateTimePicker();
               this.lblAnd = new System.Windows.Forms.Label();
               this.dtpicTo = new System.Windows.Forms.DateTimePicker();
               ((System.ComponentModel.ISupportInitialize)(this.spnMonths)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.spnDays)).BeginInit();
               this.SuspendLayout();
               // 
               // rbtnMonths
               // 
               this.rbtnMonths.Checked = true;
               this.rbtnMonths.Location = new System.Drawing.Point(4, 8);
               this.rbtnMonths.Name = "rbtnMonths";
               this.rbtnMonths.Size = new System.Drawing.Size(79, 24);
               this.rbtnMonths.TabIndex = 0;
               this.rbtnMonths.TabStop = true;
               this.rbtnMonths.Text = "&In the last";
               // 
               // rbtnDays
               // 
               this.rbtnDays.Location = new System.Drawing.Point(4, 41);
               this.rbtnDays.Name = "rbtnDays";
               this.rbtnDays.Size = new System.Drawing.Size(79, 24);
               this.rbtnDays.TabIndex = 3;
               this.rbtnDays.Text = "I&n the last";
               // 
               // rbtnBetween
               // 
               this.rbtnBetween.AutoSize = true;
               this.rbtnBetween.Location = new System.Drawing.Point(4, 72);
               this.rbtnBetween.Name = "rbtnBetween";
               this.rbtnBetween.Size = new System.Drawing.Size(83, 21);
               this.rbtnBetween.TabIndex = 6;
               this.rbtnBetween.Text = "&Between";
               // 
               // spnMonths
               // 
               this.spnMonths.Location = new System.Drawing.Point(88, 12);
               this.spnMonths.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
               this.spnMonths.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
               this.spnMonths.Name = "spnMonths";
               this.spnMonths.Size = new System.Drawing.Size(56, 22);
               this.spnMonths.TabIndex = 1;
               this.spnMonths.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
               // 
               // spnDays
               // 
               this.spnDays.Location = new System.Drawing.Point(88, 41);
               this.spnDays.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
               this.spnDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
               this.spnDays.Name = "spnDays";
               this.spnDays.Size = new System.Drawing.Size(56, 22);
               this.spnDays.TabIndex = 4;
               this.spnDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
               // 
               // lblMonths
               // 
               this.lblMonths.AutoSize = true;
               this.lblMonths.Location = new System.Drawing.Point(150, 12);
               this.lblMonths.Name = "lblMonths";
               this.lblMonths.Size = new System.Drawing.Size(64, 17);
               this.lblMonths.TabIndex = 2;
               this.lblMonths.Text = "month(s)";
               this.lblMonths.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // lblDays
               // 
               this.lblDays.AutoSize = true;
               this.lblDays.Location = new System.Drawing.Point(152, 41);
               this.lblDays.Name = "lblDays";
               this.lblDays.Size = new System.Drawing.Size(48, 17);
               this.lblDays.TabIndex = 5;
               this.lblDays.Text = "day(s)";
               this.lblDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // dtpicFrom
               // 
               this.dtpicFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                           | System.Windows.Forms.AnchorStyles.Right)));
               this.dtpicFrom.Checked = false;
               this.dtpicFrom.CustomFormat = "dd/MMM/yyy HH:mm:ss tt";
               this.dtpicFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
               this.dtpicFrom.Location = new System.Drawing.Point(88, 72);
               this.dtpicFrom.Name = "dtpicFrom";
               this.dtpicFrom.ShowCheckBox = true;
               this.dtpicFrom.Size = new System.Drawing.Size(168, 22);
               this.dtpicFrom.TabIndex = 7;
               // 
               // lblAnd
               // 
               this.lblAnd.AutoSize = true;
               this.lblAnd.Location = new System.Drawing.Point(20, 101);
               this.lblAnd.Name = "lblAnd";
               this.lblAnd.Size = new System.Drawing.Size(32, 17);
               this.lblAnd.TabIndex = 8;
               this.lblAnd.Text = "and";
               this.lblAnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // dtpicTo
               // 
               this.dtpicTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                           | System.Windows.Forms.AnchorStyles.Right)));
               this.dtpicTo.Checked = false;
               this.dtpicTo.CustomFormat = "dd/MMM/yyy HH:mm:ss tt";
               this.dtpicTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
               this.dtpicTo.Location = new System.Drawing.Point(88, 101);
               this.dtpicTo.Name = "dtpicTo";
               this.dtpicTo.ShowCheckBox = true;
               this.dtpicTo.Size = new System.Drawing.Size(168, 22);
               this.dtpicTo.TabIndex = 9;
               // 
               // DateRangeFilter
               // 
               this.Controls.Add(this.dtpicTo);
               this.Controls.Add(this.lblAnd);
               this.Controls.Add(this.dtpicFrom);
               this.Controls.Add(this.lblDays);
               this.Controls.Add(this.lblMonths);
               this.Controls.Add(this.spnDays);
               this.Controls.Add(this.spnMonths);
               this.Controls.Add(this.rbtnBetween);
               this.Controls.Add(this.rbtnDays);
               this.Controls.Add(this.rbtnMonths);
               this.Name = "DateRangeFilter";
               this.Size = new System.Drawing.Size(259, 130);
               ((System.ComponentModel.ISupportInitialize)(this.spnMonths)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.spnDays)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

            }
            
            
            private void Init ( ) 
            {
               try
               {
                  spnMonths.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                               rbtnMonths,
                                               Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ;
                                               
                                               
                  spnDays.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                             rbtnDays,
                                             Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ;
                                             
                  dtpicFrom.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                               rbtnBetween,
                                               Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ;
                                               
                  dtpicTo.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                             rbtnBetween,
                                             Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ;
                  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void RegisterEvents ( )
            {
               try
               {
                  spnMonths.Validating += new CancelEventHandler ( spnMonths_Validating ) ;
                  spnDays.Validating   += new CancelEventHandler ( spnDays_Validating ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
         #endregion

         #region Properties
            
         #endregion
         
         #region Events
         
            
            private void spnMonths_Validating
            (
               object sender, 
               CancelEventArgs e
            )
            {
               try
               {
                  if ( ( spnMonths.Value < spnMonths.Minimum ) ||
                       ( spnMonths.Value > spnMonths.Maximum ) )
                  {
                     throw new Exception ( "Invalid value." ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void spnDays_Validating
            (
               object sender, 
               CancelEventArgs e
            )
            {
               try
               {
                  if ( ( spnDays.Value < spnDays.Minimum ) ||
                       ( spnDays.Value > spnDays.Maximum ) )
                  {
                     throw new Exception ( "Invalid value." ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
         #endregion
         
         #region Data Members
         
            private System.ComponentModel.Container components = null ;
            
            
            protected System.Windows.Forms.RadioButton rbtnMonths ;
            protected System.Windows.Forms.RadioButton rbtnDays ;
            protected System.Windows.Forms.RadioButton rbtnBetween ;
            protected System.Windows.Forms.NumericUpDown spnMonths ;
            protected System.Windows.Forms.NumericUpDown spnDays ;
            protected System.Windows.Forms.Label lblMonths ;
            protected System.Windows.Forms.Label lblDays ;
            protected System.Windows.Forms.DateTimePicker dtpicFrom ;
            protected System.Windows.Forms.Label lblAnd ;
            protected System.Windows.Forms.DateTimePicker dtpicTo ;
                  
            
         #endregion
      
         #region Data Types Definition
         
            private class Constants
            {
               public class BindingInfo
               {
                  public class PropertyName
                  {
                     public class SystemGUI
                     {
                        public const string TEXT    = "Text" ;
                        public const string CHECKED = "Checked" ;
                        public const string ENABLED = "Enabled" ;
                        public const string VALUE   = "Value" ;
                     }
                  }
               }
            }
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
