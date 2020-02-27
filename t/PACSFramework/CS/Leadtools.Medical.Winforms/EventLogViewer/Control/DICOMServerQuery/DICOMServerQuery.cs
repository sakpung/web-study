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
   class DICOMServerQuery : System.Windows.Forms.UserControl
   {
      #region Public
         
         #region Methods
         
            public DICOMServerQuery ( )
            {
               try
               {
                  InitializeComponent ( ) ;

                  Init ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            
         #endregion
         
         #region Properties
         
            public QueryFilterType SelectedQueryFilter
            {
               get
               {
                  try
                  {
                     QueryFilterType CurrentQueryType ;
                     
                     
                     CurrentQueryType = QueryFilterType.None ;
                     
                     if ( chkLastLogs.Checked ) 
                     {
                        CurrentQueryType |= QueryFilterType.LastEntry ;
                     }
                     
                     
                     if ( chkType.Checked ) 
                     {
                        CurrentQueryType |= QueryFilterType.Type ;
                     }
                     
                     
                     if ( chkDate.Checked ) 
                     {
                        DateRangeFilter.RangeFilterType DateRangeFilterTypeEnum ;
                        
                        
                        CurrentQueryType |= QueryFilterType.Date ;
                        
                        DateRangeFilterTypeEnum = ctlRangeFilter.SelectedDateFilter ;
                        
                        switch ( DateRangeFilterTypeEnum )
                        {
                           case DateRangeFilter.RangeFilterType.Months:
                           {
                              CurrentQueryType |= QueryFilterType.DateMonths ;
                           }
                           
                              break ;
                           
                           case DateRangeFilter.RangeFilterType.Days:
                           {
                              CurrentQueryType |= QueryFilterType.DateDays ;
                           }
                           
                              break ;
                           
                           
                           case DateRangeFilter.RangeFilterType.DateRange:
                           {
                              CurrentQueryType |= QueryFilterType.DateRange ;
                           }
                           
                              break ;
                           
                           default:
                           {
                              throw new Exception ( Constants.Messages.Exception.RangeFilterTypeError ) ;
                           }
                        }
                     }
                     
                     
                     
                     if ( chkClientAETitle.Checked ) 
                     {
                        CurrentQueryType |= QueryFilterType.ClientAETitle ;
                     }
                     
                     
                     if ( chkClientHostAddress.Checked ) 
                     {
                        CurrentQueryType |= QueryFilterType.ClientHostAddress ;
                     }
                     
                     
                     if ( chkClientPort.Checked ) 
                     {
                        CurrentQueryType |= QueryFilterType.ClientPort ;
                     }
                     
                     
                     if ( chkServerAETitle.Checked ) 
                     {
                        CurrentQueryType |= QueryFilterType.ServerAETitle ;
                     }
                     
                     
                     if ( chkServerIPAddress.Checked ) 
                     {
                        CurrentQueryType |= QueryFilterType.ServerIPAddress ;
                     }

                     if ( chkServerPort.Checked ) 
                     {
                        CurrentQueryType |= QueryFilterType.ServerPort ;
                     }
                     
                     if ( commandCheckBox.Checked ) 
                     {
                        CurrentQueryType |= QueryFilterType.Command ;
                     }
                     
                     return CurrentQueryType ;
                  }
                  catch ( Exception exception )
                  {
                     System.Diagnostics.Debug.Assert ( false ) ;
                     
                     throw exception ;
                  }
               }
            }
            
            
            public int LastLogs
            {
               get
               {
                  if ( chkLastLogs.Checked ) 
                  {
                     return ( int ) spnLastEntry.Value ;
                  }
                  else
                  {
                     return 0 ;
                  }
               }
            } 
            
            
            public string Type
            {
               get
               {
                  if ( chkType.Checked ) 
                  {
                     return ctlcmbType.Text ;
                  }
                  else
                  {
                     return null ;
                  }
               }
            }
            
            
            public string Command
            {
               get
               {
                  if ( commandCheckBox.Checked ) 
                  {
                     return CommandCheckedComboBox.Text ;
                  }
                  else
                  {
                     return null ;
                  }
               }
            }
            
            
            public string DateMonths
            {
               get
               {
                  if ( chkDate.Checked ) 
                  {
                     if ( ctlRangeFilter.SelectedDateFilter == DateRangeFilter.RangeFilterType.Months )
                     {
                        return ctlRangeFilter.LastMonths ;  
                     }
                  }
                  
                  return null ;
               }
            }
            
            
            public string DateDays
            {
               get
               {
                  if ( chkDate.Checked ) 
                  {
                     if ( ctlRangeFilter.SelectedDateFilter == DateRangeFilter.RangeFilterType.Days )
                     {
                        return ctlRangeFilter.LastDays ;  
                     }
                  }
                  
                  return null ;
               }
            }
            
            
            public string DateRangeFrom
            {
               get
               {
                  if ( chkDate.Checked ) 
                  {
                     if ( ctlRangeFilter.SelectedDateFilter == DateRangeFilter.RangeFilterType.DateRange )
                     {
                        return ctlRangeFilter.DateRangeFrom ;  
                     }
                  }
                  
                  return null ;
               }
            }
            
            
            public string DateRangeTo
            {
               get
               {
                  if ( chkDate.Checked ) 
                  {
                     if ( ctlRangeFilter.SelectedDateFilter == DateRangeFilter.RangeFilterType.DateRange )
                     {
                        return ctlRangeFilter.DateRangeTo ;  
                     }
                  }
                  
                  return null ;
               }
            }
            
            
            public string ClientAETitle
            {
               get
               {
                  if ( chkClientAETitle.Checked ) 
                  {
                     return txtClientAETitle.Text ;
                  }
                  else
                  {
                     return null ;
                  }
               }
            }
            
            
            public string ClientHostAddress
            {
               get
               {
                  if ( chkClientHostAddress.Checked ) 
                  {
                     return txtClientHostAddress.Text ;
                  }
                  else
                  {
                     return null ;
                  }
               }
            }
            
            
            public string ClientPort
            {
               get
               {
                  if ( chkClientPort.Checked ) 
                  {
                     return txtClientPort.Text ;
                  }
                  else
                  {
                     return null ;
                  }
               }
            }
            
            
            public string ServerAETitle
            {
               get
               {
                  if ( chkServerAETitle.Checked ) 
                  {
                     return txtServerAETitle.Text ;
                  }
                  else
                  {
                     return null ;
                  }
               }
            }
            
            
            public string ServerIPAddress
            {
               get
               {
                  if ( chkServerIPAddress.Checked ) 
                  {
                     return txtServerIPAddress.Text ;
                  }
                  else
                  {
                     return null ;
                  }
               }
            }
            
            
            public string ServerPort
            {
               get
               {
                  if ( chkServerPort.Checked ) 
                  {
                     return txtServerPort.Text ;
                  }
                  else
                  {
                     return null ;
                  }
               }
            }
                  
                  
            
            public object TypeDataSource
            {
               get
               {
                  return ctlcmbType.DataSource ;
               }
               
               
               set
               {
                  ctlcmbType.DataSource = value ;
               }
            } 
            
            
            public string TypeDisplayMember
            {
               get
               {
                  return ctlcmbType.DisplayMember ;
               }
                     
                     
               set
               {
                  ctlcmbType.DisplayMember = value ;
               }
            } 
            
            public object CommandDataSource
            {
               get
               {
                  return CommandCheckedComboBox.DataSource ;
               }
               
               
               set
               {
                  CommandCheckedComboBox.DataSource = value ;
               }
            } 
            
            
            public string CommandDisplayMember
            {
               get
               {
                  return CommandCheckedComboBox.DisplayMember ;
               }
                     
                     
               set
               {
                  CommandCheckedComboBox.DisplayMember = value ;
               }
            } 
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
         
            [FlagsAttribute]
            public enum QueryFilterType
            {
               None = 0,
               LastEntry = 1,
               Type = 2,
               Date = 4,
               ServerAETitle = 8,
               ServerIPAddress = 16,
               ServerPort = 32,
               ClientAETitle = 64,
               ClientHostAddress = 128,
               ClientPort = 256,
               DateMonths = 512,
               DateDays = 1024,
               DateRange = 2048,
               Command = 4096
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
               this.grpGeneral = new System.Windows.Forms.GroupBox();
               this.commandCheckBox = new System.Windows.Forms.CheckBox();
               this.chkLastLogs = new System.Windows.Forms.CheckBox();
               this.chkType = new System.Windows.Forms.CheckBox();
               this.spnLastEntry = new System.Windows.Forms.NumericUpDown();
               this.lblLogs = new System.Windows.Forms.Label();
               this.grpDate = new System.Windows.Forms.GroupBox();
               this.chkDate = new System.Windows.Forms.CheckBox();
               this.grpClientsServer = new System.Windows.Forms.GroupBox();
               this.grpServer = new System.Windows.Forms.GroupBox();
               this.txtServerIPAddress = new System.Windows.Forms.TextBox();
               this.txtServerPort = new System.Windows.Forms.TextBox();
               this.txtServerAETitle = new System.Windows.Forms.TextBox();
               this.chkServerPort = new System.Windows.Forms.CheckBox();
               this.chkServerIPAddress = new System.Windows.Forms.CheckBox();
               this.chkServerAETitle = new System.Windows.Forms.CheckBox();
               this.grpClient = new System.Windows.Forms.GroupBox();
               this.txtClientPort = new System.Windows.Forms.TextBox();
               this.txtClientHostAddress = new System.Windows.Forms.TextBox();
               this.txtClientAETitle = new System.Windows.Forms.TextBox();
               this.chkClientPort = new System.Windows.Forms.CheckBox();
               this.chkClientHostAddress = new System.Windows.Forms.CheckBox();
               this.chkClientAETitle = new System.Windows.Forms.CheckBox();
               this.ctlRangeFilter = new Leadtools.Medical.Winforms.Control.DateRangeFilter();
               this.CommandCheckedComboBox = new Leadtools.Medical.Winforms.Control.CheckedComboBox();
               this.ctlcmbType = new Leadtools.Medical.Winforms.Control.CheckedComboBox();
               this.grpGeneral.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.spnLastEntry)).BeginInit();
               this.grpDate.SuspendLayout();
               this.grpClientsServer.SuspendLayout();
               this.grpServer.SuspendLayout();
               this.grpClient.SuspendLayout();
               this.SuspendLayout();
               // 
               // grpGeneral
               // 
               this.grpGeneral.Controls.Add(this.CommandCheckedComboBox);
               this.grpGeneral.Controls.Add(this.commandCheckBox);
               this.grpGeneral.Controls.Add(this.chkLastLogs);
               this.grpGeneral.Controls.Add(this.chkType);
               this.grpGeneral.Controls.Add(this.ctlcmbType);
               this.grpGeneral.Controls.Add(this.spnLastEntry);
               this.grpGeneral.Controls.Add(this.lblLogs);
               this.grpGeneral.Location = new System.Drawing.Point(8, 8);
               this.grpGeneral.Name = "grpGeneral";
               this.grpGeneral.Size = new System.Drawing.Size(297, 100);
               this.grpGeneral.TabIndex = 0;
               this.grpGeneral.TabStop = false;
               this.grpGeneral.Text = "General";
               // 
               // commandCheckBox
               // 
               this.commandCheckBox.Location = new System.Drawing.Point(9, 70);
               this.commandCheckBox.Name = "commandCheckBox";
               this.commandCheckBox.Size = new System.Drawing.Size(80, 24);
               this.commandCheckBox.TabIndex = 4;
               this.commandCheckBox.Text = "&Command:";
               // 
               // chkLastLogs
               // 
               this.chkLastLogs.Checked = true;
               this.chkLastLogs.CheckState = System.Windows.Forms.CheckState.Checked;
               this.chkLastLogs.Location = new System.Drawing.Point(9, 19);
               this.chkLastLogs.Name = "chkLastLogs";
               this.chkLastLogs.Size = new System.Drawing.Size(49, 24);
               this.chkLastLogs.TabIndex = 0;
               this.chkLastLogs.Text = "&Last";
               // 
               // chkType
               // 
               this.chkType.Location = new System.Drawing.Point(9, 45);
               this.chkType.Name = "chkType";
               this.chkType.Size = new System.Drawing.Size(55, 24);
               this.chkType.TabIndex = 3;
               this.chkType.Text = "T&ype:";
               // 
               // spnLastEntry
               // 
               this.spnLastEntry.Location = new System.Drawing.Point(93, 19);
               this.spnLastEntry.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
               this.spnLastEntry.Name = "spnLastEntry";
               this.spnLastEntry.Size = new System.Drawing.Size(80, 20);
               this.spnLastEntry.TabIndex = 1;
               this.spnLastEntry.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
               // 
               // lblLogs
               // 
               this.lblLogs.Location = new System.Drawing.Point(181, 19);
               this.lblLogs.Name = "lblLogs";
               this.lblLogs.Size = new System.Drawing.Size(95, 20);
               this.lblLogs.TabIndex = 2;
               this.lblLogs.Text = "log(s)";
               // 
               // grpDate
               // 
               this.grpDate.Controls.Add(this.ctlRangeFilter);
               this.grpDate.Location = new System.Drawing.Point(8, 114);
               this.grpDate.Name = "grpDate";
               this.grpDate.Size = new System.Drawing.Size(297, 152);
               this.grpDate.TabIndex = 2;
               this.grpDate.TabStop = false;
               // 
               // chkDate
               // 
               this.chkDate.Location = new System.Drawing.Point(16, 110);
               this.chkDate.Name = "chkDate";
               this.chkDate.Size = new System.Drawing.Size(51, 24);
               this.chkDate.TabIndex = 1;
               this.chkDate.Text = "&Date";
               // 
               // grpClientsServer
               // 
               this.grpClientsServer.Controls.Add(this.grpServer);
               this.grpClientsServer.Controls.Add(this.grpClient);
               this.grpClientsServer.Location = new System.Drawing.Point(313, 8);
               this.grpClientsServer.Name = "grpClientsServer";
               this.grpClientsServer.Size = new System.Drawing.Size(346, 258);
               this.grpClientsServer.TabIndex = 3;
               this.grpClientsServer.TabStop = false;
               this.grpClientsServer.Text = "Clients/Server";
               // 
               // grpServer
               // 
               this.grpServer.Controls.Add(this.txtServerIPAddress);
               this.grpServer.Controls.Add(this.txtServerPort);
               this.grpServer.Controls.Add(this.txtServerAETitle);
               this.grpServer.Controls.Add(this.chkServerPort);
               this.grpServer.Controls.Add(this.chkServerIPAddress);
               this.grpServer.Controls.Add(this.chkServerAETitle);
               this.grpServer.Location = new System.Drawing.Point(9, 134);
               this.grpServer.Name = "grpServer";
               this.grpServer.Size = new System.Drawing.Size(327, 105);
               this.grpServer.TabIndex = 1;
               this.grpServer.TabStop = false;
               this.grpServer.Text = "Server";
               // 
               // txtServerIPAddress
               // 
               this.txtServerIPAddress.Location = new System.Drawing.Point(98, 42);
               this.txtServerIPAddress.Name = "txtServerIPAddress";
               this.txtServerIPAddress.Size = new System.Drawing.Size(219, 20);
               this.txtServerIPAddress.TabIndex = 6;
               // 
               // txtServerPort
               // 
               this.txtServerPort.Location = new System.Drawing.Point(98, 72);
               this.txtServerPort.Name = "txtServerPort";
               this.txtServerPort.Size = new System.Drawing.Size(219, 20);
               this.txtServerPort.TabIndex = 5;
               // 
               // txtServerAETitle
               // 
               this.txtServerAETitle.Location = new System.Drawing.Point(98, 13);
               this.txtServerAETitle.MaxLength = 16;
               this.txtServerAETitle.Name = "txtServerAETitle";
               this.txtServerAETitle.Size = new System.Drawing.Size(219, 20);
               this.txtServerAETitle.TabIndex = 1;
               // 
               // chkServerPort
               // 
               this.chkServerPort.Location = new System.Drawing.Point(10, 68);
               this.chkServerPort.Name = "chkServerPort";
               this.chkServerPort.Size = new System.Drawing.Size(48, 24);
               this.chkServerPort.TabIndex = 4;
               this.chkServerPort.Text = "&Port:";
               // 
               // chkServerIPAddress
               // 
               this.chkServerIPAddress.Location = new System.Drawing.Point(10, 42);
               this.chkServerIPAddress.Name = "chkServerIPAddress";
               this.chkServerIPAddress.Size = new System.Drawing.Size(89, 24);
               this.chkServerIPAddress.TabIndex = 2;
               this.chkServerIPAddress.Text = "IP Addre&ss:";
               // 
               // chkServerAETitle
               // 
               this.chkServerAETitle.Location = new System.Drawing.Point(10, 16);
               this.chkServerAETitle.Name = "chkServerAETitle";
               this.chkServerAETitle.Size = new System.Drawing.Size(74, 24);
               this.chkServerAETitle.TabIndex = 0;
               this.chkServerAETitle.Text = "A&E Title:";
               // 
               // grpClient
               // 
               this.grpClient.Controls.Add(this.txtClientPort);
               this.grpClient.Controls.Add(this.txtClientHostAddress);
               this.grpClient.Controls.Add(this.txtClientAETitle);
               this.grpClient.Controls.Add(this.chkClientPort);
               this.grpClient.Controls.Add(this.chkClientHostAddress);
               this.grpClient.Controls.Add(this.chkClientAETitle);
               this.grpClient.Location = new System.Drawing.Point(9, 22);
               this.grpClient.Name = "grpClient";
               this.grpClient.Size = new System.Drawing.Size(327, 105);
               this.grpClient.TabIndex = 0;
               this.grpClient.TabStop = false;
               this.grpClient.Text = "Clients";
               // 
               // txtClientPort
               // 
               this.txtClientPort.Location = new System.Drawing.Point(112, 72);
               this.txtClientPort.Name = "txtClientPort";
               this.txtClientPort.Size = new System.Drawing.Size(205, 20);
               this.txtClientPort.TabIndex = 5;
               // 
               // txtClientHostAddress
               // 
               this.txtClientHostAddress.Location = new System.Drawing.Point(112, 45);
               this.txtClientHostAddress.Name = "txtClientHostAddress";
               this.txtClientHostAddress.Size = new System.Drawing.Size(205, 20);
               this.txtClientHostAddress.TabIndex = 3;
               // 
               // txtClientAETitle
               // 
               this.txtClientAETitle.Location = new System.Drawing.Point(112, 16);
               this.txtClientAETitle.MaxLength = 16;
               this.txtClientAETitle.Name = "txtClientAETitle";
               this.txtClientAETitle.Size = new System.Drawing.Size(205, 20);
               this.txtClientAETitle.TabIndex = 1;
               // 
               // chkClientPort
               // 
               this.chkClientPort.Location = new System.Drawing.Point(10, 71);
               this.chkClientPort.Name = "chkClientPort";
               this.chkClientPort.Size = new System.Drawing.Size(48, 24);
               this.chkClientPort.TabIndex = 4;
               this.chkClientPort.Text = "P&ort:";
               // 
               // chkClientHostAddress
               // 
               this.chkClientHostAddress.Location = new System.Drawing.Point(10, 45);
               this.chkClientHostAddress.Name = "chkClientHostAddress";
               this.chkClientHostAddress.Size = new System.Drawing.Size(102, 24);
               this.chkClientHostAddress.TabIndex = 2;
               this.chkClientHostAddress.Text = "&Host Address:";
               // 
               // chkClientAETitle
               // 
               this.chkClientAETitle.Location = new System.Drawing.Point(10, 19);
               this.chkClientAETitle.Name = "chkClientAETitle";
               this.chkClientAETitle.Size = new System.Drawing.Size(74, 24);
               this.chkClientAETitle.TabIndex = 0;
               this.chkClientAETitle.Text = "AE &Title:";
               // 
               // ctlRangeFilter
               // 
               this.ctlRangeFilter.DateControlFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
               this.ctlRangeFilter.Location = new System.Drawing.Point(8, 17);
               this.ctlRangeFilter.Name = "ctlRangeFilter";
               this.ctlRangeFilter.Size = new System.Drawing.Size(258, 130);
               this.ctlRangeFilter.TabIndex = 0;
               // 
               // CommandCheckedComboBox
               // 
               this.CommandCheckedComboBox.ColumnDelimeter = '\0';
               this.CommandCheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
               this.CommandCheckedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.CommandCheckedComboBox.Location = new System.Drawing.Point(93, 72);
               this.CommandCheckedComboBox.Name = "CommandCheckedComboBox";
               this.CommandCheckedComboBox.Size = new System.Drawing.Size(183, 21);
               this.CommandCheckedComboBox.TabIndex = 5;
               // 
               // ctlcmbType
               // 
               this.ctlcmbType.ColumnDelimeter = '\0';
               this.ctlcmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
               this.ctlcmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.ctlcmbType.Location = new System.Drawing.Point(93, 47);
               this.ctlcmbType.Name = "ctlcmbType";
               this.ctlcmbType.Size = new System.Drawing.Size(183, 21);
               this.ctlcmbType.TabIndex = 4;
               // 
               // DICOMServerQuery
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
               this.Controls.Add(this.grpClientsServer);
               this.Controls.Add(this.chkDate);
               this.Controls.Add(this.grpDate);
               this.Controls.Add(this.grpGeneral);
               this.Name = "DICOMServerQuery";
               this.Size = new System.Drawing.Size(665, 273);
               this.grpGeneral.ResumeLayout(false);
               ((System.ComponentModel.ISupportInitialize)(this.spnLastEntry)).EndInit();
               this.grpDate.ResumeLayout(false);
               this.grpClientsServer.ResumeLayout(false);
               this.grpServer.ResumeLayout(false);
               this.grpServer.PerformLayout();
               this.grpClient.ResumeLayout(false);
               this.grpClient.PerformLayout();
               this.ResumeLayout(false);

            }
                  
                  
            private void Init ( )
            {
               try
               {
                  InitCommandTypeCheckedCombo ( ) ;

                  spnLastEntry.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                                  chkLastLogs,
                                                  Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ;
                                                   
                  ctlcmbType.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                                chkType,
                                                Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ; 
                                                
                  CommandCheckedComboBox.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                                            commandCheckBox,
                                                            Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ; 
                                                
                  ctlRangeFilter.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                                    chkDate,
                                                    Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ; 
                                             
                  txtClientAETitle.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                                      chkClientAETitle,
                                                      Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ; 
                                                      
                  txtClientHostAddress.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                                          chkClientHostAddress,
                                                          Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ; 
                                                         
                  txtClientPort.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                                   chkClientPort,
                                                   Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ; 
                                                      
                  txtServerAETitle.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                                      chkServerAETitle,
                                                      Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ; 
                                                      
                  txtServerIPAddress.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                                        chkServerIPAddress,
                                                        Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ; 
                                                      
                  txtServerPort.DataBindings.Add ( Constants.BindingInfo.PropertyName.SystemGUI.ENABLED,
                                                   chkServerPort,
                                                   Constants.BindingInfo.PropertyName.SystemGUI.CHECKED ) ; 

                                                   
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }


            private void InitCommandTypeCheckedCombo ( ) 
            {
               try
               {
                  
               
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
            
         #endregion
         
         #region Data Members
         
            private System.ComponentModel.Container components = null ;
            private System.Windows.Forms.CheckBox chkLastLogs ;
            private System.Windows.Forms.CheckBox chkType ;
            private System.Windows.Forms.NumericUpDown spnLastEntry ;
            private System.Windows.Forms.GroupBox grpGeneral ;
            private System.Windows.Forms.Label lblLogs ;
            private System.Windows.Forms.GroupBox grpDate ;
            private System.Windows.Forms.CheckBox chkDate ;
            private Leadtools.Medical.Winforms.Control.CheckedComboBox ctlcmbType ;
            private System.Windows.Forms.GroupBox grpClientsServer ;
            private System.Windows.Forms.GroupBox grpClient ;
            private System.Windows.Forms.CheckBox chkClientAETitle ;
            private System.Windows.Forms.CheckBox chkClientHostAddress ;
            private System.Windows.Forms.CheckBox chkClientPort ;
            private System.Windows.Forms.TextBox txtClientAETitle ;
            private System.Windows.Forms.TextBox txtClientHostAddress ;
            private System.Windows.Forms.GroupBox grpServer ;
            private System.Windows.Forms.TextBox txtServerAETitle ;
            private System.Windows.Forms.CheckBox chkServerPort ;
            private System.Windows.Forms.CheckBox chkServerIPAddress ;
            private System.Windows.Forms.CheckBox chkServerAETitle ;
            private System.Windows.Forms.TextBox txtClientPort ;
            private System.Windows.Forms.TextBox txtServerPort ;
            private System.Windows.Forms.TextBox txtServerIPAddress;
            private CheckBox commandCheckBox;
            private CheckedComboBox CommandCheckedComboBox;
            private DateRangeFilter ctlRangeFilter ;
            
         #endregion
         
         #region Data Types Definition
         
            public class Constants
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
                     
               public class Messages
               {
                  public class Exception
                  {
                     public const string RangeFilterTypeError = "Not supported date range filter type." ;
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
