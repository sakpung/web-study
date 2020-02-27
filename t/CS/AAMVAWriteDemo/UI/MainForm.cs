// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.WinForms;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Barcode;
using System.Text;
using AAMVAWriteDemo;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace AAMVAWriteDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private GroupBox groupBox1;
      private Label _labelJurisdiction;
      private Label _labelIIN;
      private ComboBox _comboBoxJurisdiction;
      private ComboBox _comboBoxVersion;
      private Label _labelVersion;
      private CheckBox _checkBoxIINAuto;
      private TextBox _textBoxIIN;
      private TextBox _textBoxJurisdictionVersion;
      private Label _labelJurisdictionVersion;
      private Button _btnWriteData;
      private Button _btnWriteBarcode;
      private GroupBox groupBox2;
      private Panel _panelSubfiles;
      private TextBox _textBoxNumEntries;
      private Label label3;
      private Button _btnAddSubfile;
      private IContainer components;

      public MainForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         Init();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      public class JurisdictionDatum
      {
         public JurisdictionDatum(string name, AAMVAJurisdiction jurisdiction)
         {
            this.Name = name;
            this.Value = jurisdiction;
         }
         public string Name { get; set; }
         public AAMVAJurisdiction Value { get; set; }
      }

      public class VersionDatum
      {
         public VersionDatum(string name, AAMVAVersion version)
         {
            this.Name = name;
            this.Value = version;
         }
         public string Name { get; set; }
         public AAMVAVersion Value { get; set; }
      }

      public class SubfileTypeDatum
      {
         public SubfileTypeDatum(string name, AAMVASubfileType subfileType)
         {
            this.Name = name;
            this.Value = subfileType;
         }
         public string Name { get; set; }
         public AAMVASubfileType Value { get; set; }
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mmMain = new System.Windows.Forms.MainMenu(this.components);
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._textBoxJurisdictionVersion = new System.Windows.Forms.TextBox();
         this._labelJurisdictionVersion = new System.Windows.Forms.Label();
         this._comboBoxVersion = new System.Windows.Forms.ComboBox();
         this._labelVersion = new System.Windows.Forms.Label();
         this._checkBoxIINAuto = new System.Windows.Forms.CheckBox();
         this._textBoxIIN = new System.Windows.Forms.TextBox();
         this._labelIIN = new System.Windows.Forms.Label();
         this._comboBoxJurisdiction = new System.Windows.Forms.ComboBox();
         this._labelJurisdiction = new System.Windows.Forms.Label();
         this._btnWriteData = new System.Windows.Forms.Button();
         this._btnWriteBarcode = new System.Windows.Forms.Button();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._panelSubfiles = new System.Windows.Forms.Panel();
         this._textBoxNumEntries = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this._btnAddSubfile = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileExit});
         this._miFile.Text = "&File";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 0;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 1;
         this._miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miHelpAbout});
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Index = 0;
         this._miHelpAbout.Text = "&About...";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this._textBoxJurisdictionVersion);
         this.groupBox1.Controls.Add(this._labelJurisdictionVersion);
         this.groupBox1.Controls.Add(this._comboBoxVersion);
         this.groupBox1.Controls.Add(this._labelVersion);
         this.groupBox1.Controls.Add(this._checkBoxIINAuto);
         this.groupBox1.Controls.Add(this._textBoxIIN);
         this.groupBox1.Controls.Add(this._labelIIN);
         this.groupBox1.Controls.Add(this._comboBoxJurisdiction);
         this.groupBox1.Controls.Add(this._labelJurisdiction);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(720, 100);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Header";
         // 
         // _textBoxJurisdictionVersion
         // 
         this._textBoxJurisdictionVersion.Location = new System.Drawing.Point(519, 61);
         this._textBoxJurisdictionVersion.Name = "_textBoxJurisdictionVersion";
         this._textBoxJurisdictionVersion.Size = new System.Drawing.Size(26, 20);
         this._textBoxJurisdictionVersion.TabIndex = 8;
         this._textBoxJurisdictionVersion.Text = "00";
         // 
         // _labelJurisdictionVersion
         // 
         this._labelJurisdictionVersion.AutoSize = true;
         this._labelJurisdictionVersion.Location = new System.Drawing.Point(375, 64);
         this._labelJurisdictionVersion.Name = "_labelJurisdictionVersion";
         this._labelJurisdictionVersion.Size = new System.Drawing.Size(137, 13);
         this._labelJurisdictionVersion.TabIndex = 7;
         this._labelJurisdictionVersion.Text = "Jurisdiction Version Number";
         // 
         // _comboBoxVersion
         // 
         this._comboBoxVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboBoxVersion.FormattingEnabled = true;
         this._comboBoxVersion.Location = new System.Drawing.Point(190, 61);
         this._comboBoxVersion.Name = "_comboBoxVersion";
         this._comboBoxVersion.Size = new System.Drawing.Size(121, 21);
         this._comboBoxVersion.TabIndex = 6;
         // 
         // _labelVersion
         // 
         this._labelVersion.AutoSize = true;
         this._labelVersion.Location = new System.Drawing.Point(6, 64);
         this._labelVersion.Name = "_labelVersion";
         this._labelVersion.Size = new System.Drawing.Size(107, 13);
         this._labelVersion.TabIndex = 5;
         this._labelVersion.Text = "AAMVA CDS Version";
         // 
         // _checkBoxIINAuto
         // 
         this._checkBoxIINAuto.AutoSize = true;
         this._checkBoxIINAuto.Checked = true;
         this._checkBoxIINAuto.CheckState = System.Windows.Forms.CheckState.Checked;
         this._checkBoxIINAuto.Location = new System.Drawing.Point(638, 29);
         this._checkBoxIINAuto.Name = "_checkBoxIINAuto";
         this._checkBoxIINAuto.Size = new System.Drawing.Size(48, 17);
         this._checkBoxIINAuto.TabIndex = 4;
         this._checkBoxIINAuto.Text = "Auto";
         this._checkBoxIINAuto.UseVisualStyleBackColor = true;
         // 
         // _textBoxIIN
         // 
         this._textBoxIIN.BackColor = System.Drawing.SystemColors.Control;
         this._textBoxIIN.Location = new System.Drawing.Point(519, 26);
         this._textBoxIIN.Name = "_textBoxIIN";
         this._textBoxIIN.ReadOnly = true;
         this._textBoxIIN.Size = new System.Drawing.Size(100, 20);
         this._textBoxIIN.TabIndex = 3;
         // 
         // _labelIIN
         // 
         this._labelIIN.AutoSize = true;
         this._labelIIN.Location = new System.Drawing.Point(375, 29);
         this._labelIIN.Name = "_labelIIN";
         this._labelIIN.Size = new System.Drawing.Size(138, 13);
         this._labelIIN.TabIndex = 2;
         this._labelIIN.Text = "Issuer Identification Number";
         // 
         // _comboBoxJurisdiction
         // 
         this._comboBoxJurisdiction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboBoxJurisdiction.FormattingEnabled = true;
         this._comboBoxJurisdiction.Location = new System.Drawing.Point(72, 26);
         this._comboBoxJurisdiction.Name = "_comboBoxJurisdiction";
         this._comboBoxJurisdiction.Size = new System.Drawing.Size(239, 21);
         this._comboBoxJurisdiction.TabIndex = 1;
         // 
         // _labelJurisdiction
         // 
         this._labelJurisdiction.AutoSize = true;
         this._labelJurisdiction.Location = new System.Drawing.Point(7, 29);
         this._labelJurisdiction.Name = "_labelJurisdiction";
         this._labelJurisdiction.Size = new System.Drawing.Size(59, 13);
         this._labelJurisdiction.TabIndex = 0;
         this._labelJurisdiction.Text = "Jurisdiction";
         // 
         // _btnWriteData
         // 
         this._btnWriteData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnWriteData.Location = new System.Drawing.Point(534, 468);
         this._btnWriteData.Name = "_btnWriteData";
         this._btnWriteData.Size = new System.Drawing.Size(88, 23);
         this._btnWriteData.TabIndex = 1;
         this._btnWriteData.Text = "Write Data";
         this._btnWriteData.UseVisualStyleBackColor = true;
         this._btnWriteData.Click += new System.EventHandler(this._btnWriteData_Click);
         // 
         // _btnWriteBarcode
         // 
         this._btnWriteBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnWriteBarcode.Location = new System.Drawing.Point(634, 468);
         this._btnWriteBarcode.Name = "_btnWriteBarcode";
         this._btnWriteBarcode.Size = new System.Drawing.Size(104, 23);
         this._btnWriteBarcode.TabIndex = 2;
         this._btnWriteBarcode.Text = "Write Barcode";
         this._btnWriteBarcode.UseVisualStyleBackColor = true;
         this._btnWriteBarcode.Click += new System.EventHandler(this._btnWriteBarcode_Click);
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this._panelSubfiles);
         this.groupBox2.Controls.Add(this._textBoxNumEntries);
         this.groupBox2.Controls.Add(this.label3);
         this.groupBox2.Controls.Add(this._btnAddSubfile);
         this.groupBox2.Location = new System.Drawing.Point(12, 135);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(720, 327);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Subfiles";
         // 
         // _panelSubfiles
         // 
         this._panelSubfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._panelSubfiles.Location = new System.Drawing.Point(6, 69);
         this._panelSubfiles.Name = "_panelSubfiles";
         this._panelSubfiles.Size = new System.Drawing.Size(708, 252);
         this._panelSubfiles.TabIndex = 3;
         // 
         // _textBoxNumEntries
         // 
         this._textBoxNumEntries.BackColor = System.Drawing.SystemColors.Control;
         this._textBoxNumEntries.Location = new System.Drawing.Point(106, 25);
         this._textBoxNumEntries.Name = "_textBoxNumEntries";
         this._textBoxNumEntries.ReadOnly = true;
         this._textBoxNumEntries.Size = new System.Drawing.Size(21, 20);
         this._textBoxNumEntries.TabIndex = 2;
         this._textBoxNumEntries.Text = "0";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(9, 28);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(91, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "Number of Entries";
         // 
         // _btnAddSubfile
         // 
         this._btnAddSubfile.Location = new System.Drawing.Point(610, 26);
         this._btnAddSubfile.Name = "_btnAddSubfile";
         this._btnAddSubfile.Size = new System.Drawing.Size(75, 23);
         this._btnAddSubfile.TabIndex = 0;
         this._btnAddSubfile.Text = "Add Subfile";
         this._btnAddSubfile.UseVisualStyleBackColor = true;
         this._btnAddSubfile.Click += new System.EventHandler(this._btnAddSubfile_Click);
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(750, 503);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this._btnWriteBarcode);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnWriteData);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(766, 542);
         this.Menu = this._mmMain;
         this.MinimumSize = new System.Drawing.Size(766, 542);
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "AAMVA Write Demo";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);

      }
      #endregion

      public static string InsertSpacesToPascalCaseString(string input)
      {
         StringBuilder sb = new StringBuilder();
         for (int j = 0; j < input.Length; j++)
         {
            if (Char.IsUpper(input[j]) && j != 0)
               sb.Append(' ');
            sb.Append(input[j]);
         }

         return sb.ToString();
      }

      public static string JurisdictionToFriendlyString(AAMVAJurisdiction jurisdiction, bool includeAbbreviationAndCountry)
      {
         //Add spaces
         string enumStrVal = jurisdiction.ToString();
         string spaceString = InsertSpacesToPascalCaseString(enumStrVal);
         StringBuilder sb = new StringBuilder(spaceString);

         if (includeAbbreviationAndCountry)
         {
            string abbr = AAMVAID.LookupStateAbbreviation(jurisdiction);
            AAMVARegion rgn = AAMVAID.LookupRegion(jurisdiction);
            if (abbr != null || rgn != AAMVARegion.Unknown)
            {
               sb.Append(" (");
               if (abbr != null)
                  sb.Append(abbr).Append(", ");


               switch (rgn)
               {
                  case AAMVARegion.UnitedStates:
                     sb.Append("USA)");
                     break;
                  case AAMVARegion.Canada:
                     sb.Append("CAN)");
                     break;
                  case AAMVARegion.Mexico:
                     sb.Append("MEX)");
                     break;
                  case AAMVARegion.Unknown:
                     break;
               }
            }
         }

         return sb.ToString();
      }

      private void Init()
      {

         // Header area

         //Jurisdiction
         AAMVAJurisdiction[] jurisdictions = (AAMVAJurisdiction[])Enum.GetValues(typeof(AAMVAJurisdiction));
         JurisdictionDatum[] _comboBoxDataJurisdiction = new JurisdictionDatum[jurisdictions.Length];
         for (int i = 0; i < jurisdictions.Length; i++)
         {
            _comboBoxDataJurisdiction[i] = new JurisdictionDatum(JurisdictionToFriendlyString(jurisdictions[i], true), jurisdictions[i]);
         }

         //Sort the values
         Array.Sort(_comboBoxDataJurisdiction, (a, b) => String.Compare(a.Name, b.Name));

         _comboBoxJurisdiction.DataSource = _comboBoxDataJurisdiction;
         _comboBoxJurisdiction.DisplayMember = "Name";
         _comboBoxJurisdiction.ValueMember = "Value";
         string iin = AAMVAID.LookupIssuerIdentificationNumber(_comboBoxDataJurisdiction[0].Value);
         _textBoxIIN.Text = iin != null ? iin : "000000";
         _comboBoxJurisdiction.SelectedIndexChanged += _comboBoxJurisdiction_SelectedIndexChanged;

         //IIN
         _checkBoxIINAuto.CheckedChanged += _checkBoxIINAuto_CheckedChanged;
         _textBoxIIN.KeyPress += _textBoxIIN_KeyPress;
         _textBoxIIN.Leave += _textBoxIIN_Leave;

         //Version
         VersionDatum[] versionDataSource = { new VersionDatum("2016", AAMVAVersion.Version2016) };
         _comboBoxVersion.DataSource = versionDataSource;
         _comboBoxVersion.DisplayMember = "Name";
         _comboBoxVersion.ValueMember = "Value";

         //Jurisdiction Version
         _textBoxJurisdictionVersion.KeyPress += _textBoxJurisdictionVersion_KeyPress;
         _textBoxJurisdictionVersion.Leave += _textBoxJurisdictionVersion_Leave;

         _subfiles = new List<SubfileSkeleton>();
         _editIndex = -1;

         DisableWriteButtons();
      }

      private void _textBoxJurisdictionVersion_Leave(object sender, EventArgs e)
      {
         if (_textBoxJurisdictionVersion.Text.Length < 2)
         {
            StringBuilder sb = new StringBuilder(_textBoxJurisdictionVersion.Text);
            for (int i = 0; i < 2 - _textBoxJurisdictionVersion.Text.Length; i++)
            {
               sb.Append('0');
            }
            _textBoxJurisdictionVersion.Text = sb.ToString();
         }
      }

      private void _textBoxJurisdictionVersion_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (_textBoxJurisdictionVersion.Text.Length == 2 && !char.IsControl(e.KeyChar) && _textBoxJurisdictionVersion.SelectedText.Length == 0)
         {
            e.Handled = true;
            System.Media.SystemSounds.Beep.Play();
            return;
         }


         if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
         {
            e.Handled = true;
            System.Media.SystemSounds.Beep.Play();
            return;
         }

      }

      private void _textBoxIIN_Leave(object sender, EventArgs e)
      {
         if (_textBoxIIN.Text.Length < 6)
         {
            StringBuilder sb = new StringBuilder(_textBoxIIN.Text);
            for (int i = 0; i < 6 - _textBoxIIN.Text.Length; i++)
            {
               sb.Append('0');
            }
            _textBoxIIN.Text = sb.ToString();
         }
      }

      private void _textBoxIIN_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (_textBoxIIN.Text.Length == 6 && !char.IsControl(e.KeyChar) && _textBoxIIN.SelectedText.Length == 0)
         {
            e.Handled = true;
            System.Media.SystemSounds.Beep.Play();
            return;
         }

         if (!_checkBoxIINAuto.Checked)
         {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
               e.Handled = true;
               System.Media.SystemSounds.Beep.Play();
               return;
            }
         }
      }

      private void _checkBoxIINAuto_CheckedChanged(object sender, EventArgs e)
      {
         if (_checkBoxIINAuto.Checked)
         {
            _textBoxIIN.ReadOnly = true;
            _textBoxIIN.BackColor = SystemColors.Control;

            AAMVAJurisdiction jurisdiction = (AAMVAJurisdiction)_comboBoxJurisdiction.SelectedValue;
            string iin = AAMVAID.LookupIssuerIdentificationNumber(jurisdiction);
            _textBoxIIN.Text = iin != null ? iin : "000000";
         }
         else
         {
            _textBoxIIN.ReadOnly = false;
            _textBoxIIN.BackColor = Color.White;
         }
      }

      private void _comboBoxJurisdiction_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_checkBoxIINAuto.Checked)
         {
            AAMVAJurisdiction jurisdiction = (AAMVAJurisdiction)_comboBoxJurisdiction.SelectedValue;
            string iin = AAMVAID.LookupIssuerIdentificationNumber(jurisdiction);
            _textBoxIIN.Text = iin != null ? iin : "000000";
         }
      }

      public void OpenEditSubfileDialog(int index, EditSubfileDialog.EditMode mode)
      {
         if(_subfiles[index].SubfileType == AAMVASubfileType.JurisdictionSpecific)
         {
            EditJurisdictionSpecificSubfileDialog dlg = new EditJurisdictionSpecificSubfileDialog(this, (AAMVAJurisdiction)_comboBoxJurisdiction.SelectedValue, _subfiles[index], index, mode);
            dlg.StartPosition = this.StartPosition;
            dlg.ShowDialog(this);
         }
         else
         {
            EditSubfileDialog dlg = new EditSubfileDialog(this, (AAMVAJurisdiction)_comboBoxJurisdiction.SelectedValue, _subfiles[index], index, mode);
            dlg.StartPosition = this.StartPosition;
            dlg.ShowDialog(this);
         }
         
      }


      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Application.Run(new MainForm());
      }

      /// <summary>
      /// Initialize the Application.
      /// </summary>
      private void MainForm_Load(object sender, System.EventArgs e)
      {
         Messager.Caption = "C# AAMVA Write Demo";
         Text = Messager.Caption;
      }

      /// <summary>
      /// Shutdown
      /// </summary>
      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      /// <summary>
      /// show the about dialog
      /// </summary>
      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("AAMVA Write", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void EnableAndVisibleMenu(MenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }

      List<SubfileSkeleton> _subfiles;
      int _editIndex;

      public List<SubfileSkeleton> SubfileSkeletons
      {
         get
         {
            return _subfiles;
         }
      }

      public class SubfileSkeleton
      {
         public string SubfileTypeCode { get; set; }
         public AAMVASubfileType SubfileType { get; set; }
         public IDictionary<string, AAMVADataElement> DataElements { get; set; }
      }

      public int AddSubfile(AAMVASubfileType subfileType, string subfileTypeCode)
      {
         SubfileSkeleton subfileSkeleton = new SubfileSkeleton();
         subfileSkeleton.SubfileType = subfileType;
         subfileSkeleton.SubfileTypeCode = subfileTypeCode;
         subfileSkeleton.DataElements = new Dictionary<string, AAMVADataElement>();
         _subfiles.Add(subfileSkeleton);
         _textBoxNumEntries.Text = _subfiles.Count.ToString();

         SubfileRowControl subfileRow = new SubfileRowControl();
         subfileRow.ParentMainForm = this;
         subfileRow.SubfileIndex = _subfiles.Count - 1;
         subfileRow.Jurisdiction = ((AAMVAJurisdiction)_comboBoxJurisdiction.SelectedValue);
         subfileRow.SubfileType = subfileType;
         subfileRow.Dock = DockStyle.Top;
         _panelSubfiles.Controls.Add(subfileRow);
         _panelSubfiles.Controls.SetChildIndex(subfileRow, 0);
         EnableWriteButtons();
         if(subfileType == AAMVASubfileType.DL || subfileType == AAMVASubfileType.ID)
            DisableJurisdiction();

         //return the index
         return _subfiles.Count - 1;
      }

      public void RemoveSubfile(int subfileIndex)
      {
         SubfileSkeleton skeleton = _subfiles[subfileIndex];
         if(skeleton.SubfileType == AAMVASubfileType.DL || skeleton.SubfileType == AAMVASubfileType.ID)
               EnableJurisdiction();

         for(int i = 0; i < _panelSubfiles.Controls.Count; i++)
         {
            Control ctrl = _panelSubfiles.Controls[i];
            if(ctrl is SubfileRowControl)
            {
               SubfileRowControl row = (SubfileRowControl)ctrl;
               if(skeleton.SubfileType == row.SubfileType)
               {
                  _panelSubfiles.Controls.Remove(row);
               }
            }
         }
         _subfiles.RemoveAt(subfileIndex);
         foreach(Control ctrl in _panelSubfiles.Controls)
         {
            if(ctrl is SubfileRowControl)
            {
               SubfileRowControl row = (SubfileRowControl)ctrl;
               if (row.SubfileIndex >= subfileIndex)
                  row.SubfileIndex--;
            }
         }
         _textBoxNumEntries.Text = _subfiles.Count.ToString();
         if (_subfiles.Count < 1)
            DisableWriteButtons();
      }

      public void SubmitEditSubfile(int subfileIndex, IDictionary<string, AAMVADataElement> dataElements)
      {
         _subfiles[subfileIndex].DataElements.Clear();
         foreach(KeyValuePair<string, AAMVADataElement> kvp in dataElements)
         {
            _subfiles[subfileIndex].DataElements.Add(kvp.Key, kvp.Value);
         }
      }

      public void CancelEditSubfile(int subfileIndex, EditSubfileDialog.EditMode mode)
      {
         if(mode == EditSubfileDialog.EditMode.NewAddition)
         {
            RemoveSubfile(subfileIndex);
         }
      }

      private void _btnAddSubfile_Click(object sender, EventArgs e)
      {
         AddSubfileDialog dlg = new AddSubfileDialog(this, (AAMVAJurisdiction)_comboBoxJurisdiction.SelectedValue);
         dlg.SubfileAdded += (object s, AddSubfileDialog.SubfileAddedEventArgs addSubfileEventArgs) =>
         {
            _editIndex = AddSubfile(addSubfileEventArgs.SubfileType, addSubfileEventArgs.SubfileTypeCode);
         };
         dlg.FormClosed += (object s, FormClosedEventArgs formCloseEventArgs) =>
         {
            AddSubfileDialog frm = (AddSubfileDialog)s;
            if (_editIndex >= 0)
            {
               int temp = _editIndex;
               _editIndex = -1;
               OpenEditSubfileDialog(temp, EditSubfileDialog.EditMode.NewAddition);
            }
            else
            {
               _editIndex = -1;
            }
         };
         dlg.StartPosition = this.StartPosition;
         dlg.ShowDialog(this);
      }

      private AAMVAID BuildID()
      {
         using (AAMVAIDBuilder builder = new AAMVAIDBuilder())
         {
            builder.SetJurisdiction((AAMVAJurisdiction)_comboBoxJurisdiction.SelectedValue, _textBoxIIN.Text)
               .SetVersion(AAMVAVersion.Version2016)
               .SetJurisdictionVersion(_textBoxJurisdictionVersion.Text)
               .SetNumberOfEntries(_subfiles.Count);

            for (int i = 0; i < _subfiles.Count; i++)
            {
               SubfileSkeleton skeleton = _subfiles[i];
               builder.SetSubfileType(i, skeleton.SubfileType, skeleton.SubfileTypeCode);
               if (skeleton.SubfileType == AAMVASubfileType.JurisdictionSpecific)
               {
                  ICollection<string> keys = skeleton.DataElements.Keys;
                  string[] keyArray = keys.ToArray<string>();
                  Array.Sort(keyArray);
                  foreach (string elementID in keyArray)
                  {
                     builder.AddDataElementToSubfile(i, elementID, skeleton.DataElements[elementID].Value);
                  }

               }
               else
               {
                  foreach (KeyValuePair<string, AAMVADataElement> kvp in skeleton.DataElements)
                  {
                     builder.AddDataElementToSubfile(i, kvp.Key, kvp.Value.Value);
                  }
               }
            }
            AAMVAID id = builder.Build();
            return id;
         }
      }

      private void _btnWriteData_Click(object sender, EventArgs e)
      {
         using (AAMVAID id = BuildID())
         {
            if(id != null)
            {
               byte[] data = id.GetBytes();

               SaveFileDialog saveFileDialog = new SaveFileDialog();
               saveFileDialog.Filter = "Text File|*.txt";
               saveFileDialog.Title = "Save AAMVA Barcode Data";
               saveFileDialog.ShowDialog();
               if (saveFileDialog.FileName != "")
               {
                  string fileName = saveFileDialog.FileName;
                  switch (saveFileDialog.FilterIndex)
                  {
                     case 1:
                        System.IO.File.WriteAllBytes(fileName, data);
                        Process.Start(fileName);
                        break;
                  }
               }
            }
         }

      }

      public void EnableJurisdiction()
      {
         _comboBoxJurisdiction.Enabled = true;
         _checkBoxIINAuto.Enabled = true;
         if(!_checkBoxIINAuto.Checked)
         {
            _textBoxIIN.ReadOnly = false;
            _textBoxIIN.BackColor = Color.White;
         }
      }

      public void DisableJurisdiction()
      {
         _comboBoxJurisdiction.Enabled = false;
         _checkBoxIINAuto.Enabled = false;
         _textBoxIIN.ReadOnly = true;
         _textBoxIIN.BackColor = SystemColors.Control;
      }

      public void EnableWriteButtons()
      {
         _btnWriteData.Enabled = true;
         _btnWriteBarcode.Enabled = true;
      }

      public void DisableWriteButtons()
      {
         _btnWriteData.Enabled = false;
         _btnWriteBarcode.Enabled = false;
      }

      private void _btnWriteBarcode_Click(object sender, EventArgs e)
      {
         using (AAMVAID id = BuildID())
         {
            if (id != null)
            {
               byte[] data = id.GetBytes();

               WriteBarcodeForm writeBarcodeForm = new WriteBarcodeForm(data);
               writeBarcodeForm.ShowDialog();
            }
         }
      }
   }
}
