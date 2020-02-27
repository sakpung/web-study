using Leadtools.Medical.Winforms.Control;
using Leadtools.Medical.Rules.AddIn.Properties;
using ScintillaNET;
namespace Leadtools.Medical.Rules.AddIn
{
    partial class RuleEditorUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleEditorUserControl));
           this.groupBoxRules = new System.Windows.Forms.GroupBox();
           this.listViewRules = new Leadtools.Medical.Winforms.Control.ExtendedListView();
           this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
           this.Priority = new System.Windows.Forms.ColumnHeader();
           this.columnHeaderEvent = new System.Windows.Forms.ColumnHeader();
           this.Active = new System.Windows.Forms.ColumnHeader();
           this.toolStrip = new System.Windows.Forms.ToolStrip();
           this.toolStripButtonAddRule = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonDeleteRule = new System.Windows.Forms.ToolStripButton();
           this.toolStripAssemblies = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
           this.toolStripTextBoxAE = new System.Windows.Forms.ToolStripTextBox();
           this.groupBoxRuleDefinition = new System.Windows.Forms.GroupBox();
           this.panelEditor = new System.Windows.Forms.Panel();
           this.toolStripCompile = new System.Windows.Forms.ToolStrip();
           this.toolStripButtonExpand = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonCut = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonPaste = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripTextBoxSearch = new ScintillaNET.ToolStripIncrementalSearcher();
           this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonCheck = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonScriptAssemblies = new System.Windows.Forms.ToolStripButton();
           this.panel1 = new System.Windows.Forms.Panel();
           this.checkBoxActive = new System.Windows.Forms.CheckBox();
           this.comboBoxEvent = new System.Windows.Forms.ComboBox();
           this.numericUpDownPriority = new System.Windows.Forms.NumericUpDown();
           this.label3 = new System.Windows.Forms.Label();
           this.label2 = new System.Windows.Forms.Label();
           this.textBoxName = new System.Windows.Forms.TextBox();
           this.label1 = new System.Windows.Forms.Label();
           this.panel2 = new System.Windows.Forms.Panel();
           this.labelParameters = new System.Windows.Forms.Label();
           this.groupBoxRules.SuspendLayout();
           this.toolStrip.SuspendLayout();
           this.groupBoxRuleDefinition.SuspendLayout();
           this.toolStripCompile.SuspendLayout();
           this.panel1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriority)).BeginInit();
           this.panel2.SuspendLayout();
           this.SuspendLayout();
           // 
           // groupBoxRules
           // 
           this.groupBoxRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.groupBoxRules.Controls.Add(this.listViewRules);
           this.groupBoxRules.Controls.Add(this.toolStrip);
           this.groupBoxRules.Location = new System.Drawing.Point(4, 4);
           this.groupBoxRules.Name = "groupBoxRules";
           this.groupBoxRules.Size = new System.Drawing.Size(609, 178);
           this.groupBoxRules.TabIndex = 0;
           this.groupBoxRules.TabStop = false;
           this.groupBoxRules.Text = "Rules";
           // 
           // listViewRules
           // 
           this.listViewRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.Priority,
            this.columnHeaderEvent,
            this.Active});
           this.listViewRules.Dock = System.Windows.Forms.DockStyle.Fill;
           this.listViewRules.FullRowSelect = true;
           this.listViewRules.HideSelection = false;
           this.listViewRules.Location = new System.Drawing.Point(3, 41);
           this.listViewRules.MultiSelect = false;
           this.listViewRules.Name = "listViewRules";
           this.listViewRules.Size = new System.Drawing.Size(603, 134);
           this.listViewRules.TabIndex = 1;
           this.listViewRules.UseCompatibleStateImageBehavior = false;
           this.listViewRules.View = System.Windows.Forms.View.Details;
           this.listViewRules.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewRules_DrawColumnHeader);
           this.listViewRules.ItemDeselecting += new Leadtools.Medical.Winforms.Control.ExtendedListView.ItemDeselectingEventHandler(this.listViewRules_ItemDeselecting);
           this.listViewRules.SelectedIndexChanged += new System.EventHandler(this.listViewRules_SelectedIndexChanged);
           this.listViewRules.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewRules_KeyDown);
           this.listViewRules.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listViewRules_DrawSubItem);
           // 
           // columnHeaderName
           // 
           this.columnHeaderName.Text = "Name";
           this.columnHeaderName.Width = 150;
           // 
           // Priority
           // 
           this.Priority.Text = "Priority";
           // 
           // columnHeaderEvent
           // 
           this.columnHeaderEvent.Text = " Event";
           this.columnHeaderEvent.Width = 150;
           // 
           // Active
           // 
           this.Active.Text = "Active";
           this.Active.Width = 75;
           // 
           // toolStrip
           // 
           this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
           this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddRule,
            this.toolStripButtonDeleteRule,
            this.toolStripAssemblies,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.toolStripTextBoxAE});
           this.toolStrip.Location = new System.Drawing.Point(3, 16);
           this.toolStrip.Name = "toolStrip";
           this.toolStrip.Size = new System.Drawing.Size(603, 25);
           this.toolStrip.Stretch = true;
           this.toolStrip.TabIndex = 0;
           this.toolStrip.Text = "toolStrip1";
           // 
           // toolStripButtonAddRule
           // 
           this.toolStripButtonAddRule.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddRule.Image")));
           this.toolStripButtonAddRule.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonAddRule.Name = "toolStripButtonAddRule";
           this.toolStripButtonAddRule.Size = new System.Drawing.Size(75, 22);
           this.toolStripButtonAddRule.Text = "&Add Rule";
           this.toolStripButtonAddRule.ToolTipText = "Add Rule";
           this.toolStripButtonAddRule.Click += new System.EventHandler(this.toolStripButtonAddRule_Click);
           // 
           // toolStripButtonDeleteRule
           // 
           this.toolStripButtonDeleteRule.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteRule.Image")));
           this.toolStripButtonDeleteRule.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonDeleteRule.Name = "toolStripButtonDeleteRule";
           this.toolStripButtonDeleteRule.Size = new System.Drawing.Size(60, 22);
           this.toolStripButtonDeleteRule.Text = "&Delete";
           this.toolStripButtonDeleteRule.ToolTipText = "Delete Rule";
           this.toolStripButtonDeleteRule.Click += new System.EventHandler(this.toolStripButtonDeleteRule_Click);
           // 
           // toolStripAssemblies
           // 
           this.toolStripAssemblies.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
           this.toolStripAssemblies.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAssemblies.Image")));
           this.toolStripAssemblies.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripAssemblies.Name = "toolStripAssemblies";
           this.toolStripAssemblies.Size = new System.Drawing.Size(84, 22);
           this.toolStripAssemblies.Text = "References";
           this.toolStripAssemblies.ToolTipText = "Global Assemblies";
           this.toolStripAssemblies.Click += new System.EventHandler(this.toolStripAssemblies_Click);
           // 
           // toolStripSeparator4
           // 
           this.toolStripSeparator4.Name = "toolStripSeparator4";
           this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
           // 
           // toolStripLabel1
           // 
           this.toolStripLabel1.Name = "toolStripLabel1";
           this.toolStripLabel1.Size = new System.Drawing.Size(50, 22);
           this.toolStripLabel1.Text = "AE Title:";
           // 
           // toolStripTextBoxAE
           // 
           this.toolStripTextBoxAE.Name = "toolStripTextBoxAE";
           this.toolStripTextBoxAE.Size = new System.Drawing.Size(100, 25);
           // 
           // groupBoxRuleDefinition
           // 
           this.groupBoxRuleDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.groupBoxRuleDefinition.Controls.Add(this.panelEditor);
           this.groupBoxRuleDefinition.Controls.Add(this.toolStripCompile);
           this.groupBoxRuleDefinition.Controls.Add(this.panel1);
           this.groupBoxRuleDefinition.Controls.Add(this.panel2);
           this.groupBoxRuleDefinition.Location = new System.Drawing.Point(7, 189);
           this.groupBoxRuleDefinition.Name = "groupBoxRuleDefinition";
           this.groupBoxRuleDefinition.Size = new System.Drawing.Size(603, 324);
           this.groupBoxRuleDefinition.TabIndex = 1;
           this.groupBoxRuleDefinition.TabStop = false;
           this.groupBoxRuleDefinition.Text = "Rule Definition";
           // 
           // panelEditor
           // 
           this.panelEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
           this.panelEditor.Dock = System.Windows.Forms.DockStyle.Fill;
           this.panelEditor.Location = new System.Drawing.Point(3, 96);
           this.panelEditor.Name = "panelEditor";
           this.panelEditor.Size = new System.Drawing.Size(597, 189);
           this.panelEditor.TabIndex = 2;
           // 
           // toolStripCompile
           // 
           this.toolStripCompile.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
           this.toolStripCompile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonExpand,
            this.toolStripSeparator5,
            this.toolStripButtonPrint,
            this.toolStripSeparator2,
            this.toolStripButtonCut,
            this.toolStripButtonCopy,
            this.toolStripButtonPaste,
            this.toolStripSeparator1,
            this.toolStripButtonUndo,
            this.toolStripButtonRedo,
            this.toolStripSeparator3,
            this.toolStripTextBoxSearch,
            this.toolStripSeparator6,
            this.toolStripButtonCheck,
            this.toolStripButtonScriptAssemblies});
           this.toolStripCompile.Location = new System.Drawing.Point(3, 69);
           this.toolStripCompile.Name = "toolStripCompile";
           this.toolStripCompile.Size = new System.Drawing.Size(597, 27);
           this.toolStripCompile.TabIndex = 1;
           this.toolStripCompile.Text = "Check syntax";
           // 
           // toolStripButtonExpand
           // 
           this.toolStripButtonExpand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonExpand.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.Detach;
           this.toolStripButtonExpand.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonExpand.Name = "toolStripButtonExpand";
           this.toolStripButtonExpand.Size = new System.Drawing.Size(23, 24);
           this.toolStripButtonExpand.Text = "Expand editor";
           this.toolStripButtonExpand.Click += new System.EventHandler(this.toolStripButtonExpand_Click);
           // 
           // toolStripSeparator5
           // 
           this.toolStripSeparator5.Name = "toolStripSeparator5";
           this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
           // 
           // toolStripButtonPrint
           // 
           this.toolStripButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonPrint.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.printer;
           this.toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonPrint.Name = "toolStripButtonPrint";
           this.toolStripButtonPrint.Size = new System.Drawing.Size(23, 24);
           this.toolStripButtonPrint.Text = "Print";
           this.toolStripButtonPrint.Click += new System.EventHandler(this.toolStripButtonPrint_Click);
           // 
           // toolStripSeparator2
           // 
           this.toolStripSeparator2.Name = "toolStripSeparator2";
           this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
           // 
           // toolStripButtonCut
           // 
           this.toolStripButtonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonCut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCut.Image")));
           this.toolStripButtonCut.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonCut.Name = "toolStripButtonCut";
           this.toolStripButtonCut.Size = new System.Drawing.Size(23, 24);
           this.toolStripButtonCut.Text = "toolStripButtonCut";
           this.toolStripButtonCut.ToolTipText = "Cut";
           this.toolStripButtonCut.Click += new System.EventHandler(this.toolStripButtonCut_Click);
           // 
           // toolStripButtonCopy
           // 
           this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopy.Image")));
           this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonCopy.Name = "toolStripButtonCopy";
           this.toolStripButtonCopy.Size = new System.Drawing.Size(23, 24);
           this.toolStripButtonCopy.Text = "toolStripButtonCopy";
           this.toolStripButtonCopy.ToolTipText = "Copy";
           this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
           // 
           // toolStripButtonPaste
           // 
           this.toolStripButtonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPaste.Image")));
           this.toolStripButtonPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonPaste.Name = "toolStripButtonPaste";
           this.toolStripButtonPaste.Size = new System.Drawing.Size(23, 24);
           this.toolStripButtonPaste.Text = "toolStripButton";
           this.toolStripButtonPaste.ToolTipText = "Paste";
           this.toolStripButtonPaste.Click += new System.EventHandler(this.toolStripButtonPaste_Click);
           // 
           // toolStripSeparator1
           // 
           this.toolStripSeparator1.Name = "toolStripSeparator1";
           this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
           // 
           // toolStripButtonUndo
           // 
           this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUndo.Image")));
           this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonUndo.Name = "toolStripButtonUndo";
           this.toolStripButtonUndo.Size = new System.Drawing.Size(23, 24);
           this.toolStripButtonUndo.Text = "toolStripButton4";
           this.toolStripButtonUndo.ToolTipText = "Undo";
           this.toolStripButtonUndo.Click += new System.EventHandler(this.toolStripButtonUndo_Click);
           // 
           // toolStripButtonRedo
           // 
           this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRedo.Image")));
           this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonRedo.Name = "toolStripButtonRedo";
           this.toolStripButtonRedo.Size = new System.Drawing.Size(23, 24);
           this.toolStripButtonRedo.Text = "toolStripButton5";
           this.toolStripButtonRedo.ToolTipText = "Redo";
           this.toolStripButtonRedo.Click += new System.EventHandler(this.toolStripButtonRedo_Click);
           // 
           // toolStripSeparator3
           // 
           this.toolStripSeparator3.Name = "toolStripSeparator3";
           this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
           // 
           // toolStripTextBoxSearch
           // 
           this.toolStripTextBoxSearch.BackColor = System.Drawing.Color.Transparent;
           this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
           this.toolStripTextBoxSearch.Scintilla = null;
           this.toolStripTextBoxSearch.Size = new System.Drawing.Size(262, 24);
           // 
           // toolStripSeparator6
           // 
           this.toolStripSeparator6.Name = "toolStripSeparator6";
           this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
           // 
           // toolStripButtonCheck
           // 
           this.toolStripButtonCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonCheck.Image = global::Leadtools.Medical.Rules.AddIn.Properties.Resources.Compile;
           this.toolStripButtonCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonCheck.Name = "toolStripButtonCheck";
           this.toolStripButtonCheck.Size = new System.Drawing.Size(23, 24);
           this.toolStripButtonCheck.Text = "toolStripButton1";
           this.toolStripButtonCheck.ToolTipText = "Syntax check";
           this.toolStripButtonCheck.Click += new System.EventHandler(this.toolStripButtonCheck_Click);
           // 
           // toolStripButtonScriptAssemblies
           // 
           this.toolStripButtonScriptAssemblies.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
           this.toolStripButtonScriptAssemblies.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonScriptAssemblies.Image")));
           this.toolStripButtonScriptAssemblies.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonScriptAssemblies.Name = "toolStripButtonScriptAssemblies";
           this.toolStripButtonScriptAssemblies.Size = new System.Drawing.Size(84, 24);
           this.toolStripButtonScriptAssemblies.Text = "References";
           this.toolStripButtonScriptAssemblies.ToolTipText = "Script Assemblies";
           this.toolStripButtonScriptAssemblies.Click += new System.EventHandler(this.toolStripButtonScriptAssemblies_Click);
           // 
           // panel1
           // 
           this.panel1.Controls.Add(this.checkBoxActive);
           this.panel1.Controls.Add(this.comboBoxEvent);
           this.panel1.Controls.Add(this.numericUpDownPriority);
           this.panel1.Controls.Add(this.label3);
           this.panel1.Controls.Add(this.label2);
           this.panel1.Controls.Add(this.textBoxName);
           this.panel1.Controls.Add(this.label1);
           this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
           this.panel1.Location = new System.Drawing.Point(3, 16);
           this.panel1.Name = "panel1";
           this.panel1.Size = new System.Drawing.Size(597, 53);
           this.panel1.TabIndex = 0;
           // 
           // checkBoxActive
           // 
           this.checkBoxActive.AutoSize = true;
           this.checkBoxActive.Location = new System.Drawing.Point(450, 20);
           this.checkBoxActive.Name = "checkBoxActive";
           this.checkBoxActive.Size = new System.Drawing.Size(56, 17);
           this.checkBoxActive.TabIndex = 5;
           this.checkBoxActive.Text = "Active";
           this.checkBoxActive.UseVisualStyleBackColor = true;
           this.checkBoxActive.CheckedChanged += new System.EventHandler(this.checkBoxActive_CheckedChanged);
           // 
           // comboBoxEvent
           // 
           this.comboBoxEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBoxEvent.FormattingEnabled = true;
           this.comboBoxEvent.Location = new System.Drawing.Point(241, 18);
           this.comboBoxEvent.Name = "comboBoxEvent";
           this.comboBoxEvent.Size = new System.Drawing.Size(203, 21);
           this.comboBoxEvent.TabIndex = 4;
           this.comboBoxEvent.SelectionChangeCommitted += new System.EventHandler(this.comboBoxEvent_SelectionChangeCommitted);
           // 
           // numericUpDownPriority
           // 
           this.numericUpDownPriority.Location = new System.Drawing.Point(174, 20);
           this.numericUpDownPriority.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
           this.numericUpDownPriority.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
           this.numericUpDownPriority.Name = "numericUpDownPriority";
           this.numericUpDownPriority.Size = new System.Drawing.Size(58, 20);
           this.numericUpDownPriority.TabIndex = 3;
           this.numericUpDownPriority.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
           this.numericUpDownPriority.ValueChanged += new System.EventHandler(this.numericUpDownPriority_ValueChanged);
           this.numericUpDownPriority.Leave += new System.EventHandler(this.Field_Leave);
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(238, 4);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(38, 13);
           this.label3.TabIndex = 2;
           this.label3.Text = "Event:";
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(171, 4);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(41, 13);
           this.label2.TabIndex = 2;
           this.label2.Text = "Priority:";
           // 
           // textBoxName
           // 
           this.textBoxName.Location = new System.Drawing.Point(7, 21);
           this.textBoxName.Name = "textBoxName";
           this.textBoxName.Size = new System.Drawing.Size(158, 20);
           this.textBoxName.TabIndex = 1;
           this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
           this.textBoxName.Leave += new System.EventHandler(this.Field_Leave);
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(4, 4);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(38, 13);
           this.label1.TabIndex = 0;
           this.label1.Text = "Name:";
           // 
           // panel2
           // 
           this.panel2.Controls.Add(this.labelParameters);
           this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
           this.panel2.Location = new System.Drawing.Point(3, 285);
           this.panel2.Name = "panel2";
           this.panel2.Size = new System.Drawing.Size(597, 36);
           this.panel2.TabIndex = 3;
           // 
           // labelParameters
           // 
           this.labelParameters.Dock = System.Windows.Forms.DockStyle.Fill;
           this.labelParameters.ForeColor = System.Drawing.Color.Red;
           this.labelParameters.Location = new System.Drawing.Point(0, 0);
           this.labelParameters.Name = "labelParameters";
           this.labelParameters.Size = new System.Drawing.Size(597, 36);
           this.labelParameters.TabIndex = 0;
           // 
           // RuleEditorUserControl
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Controls.Add(this.groupBoxRuleDefinition);
           this.Controls.Add(this.groupBoxRules);
           this.Name = "RuleEditorUserControl";
           this.Size = new System.Drawing.Size(616, 516);
           this.groupBoxRules.ResumeLayout(false);
           this.groupBoxRules.PerformLayout();
           this.toolStrip.ResumeLayout(false);
           this.toolStrip.PerformLayout();
           this.groupBoxRuleDefinition.ResumeLayout(false);
           this.groupBoxRuleDefinition.PerformLayout();
           this.toolStripCompile.ResumeLayout(false);
           this.toolStripCompile.PerformLayout();
           this.panel1.ResumeLayout(false);
           this.panel1.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriority)).EndInit();
           this.panel2.ResumeLayout(false);
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRules;
        private ExtendedListView listViewRules;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader Priority;
        private System.Windows.Forms.ColumnHeader Active;
        private System.Windows.Forms.GroupBox groupBoxRuleDefinition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddRule;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteRule;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownPriority;
        private System.Windows.Forms.ColumnHeader columnHeaderEvent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxEvent;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Panel panelEditor;
        private System.Windows.Forms.ToolStrip toolStripCompile;
        private System.Windows.Forms.ToolStripButton toolStripButtonCut;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.ToolStripButton toolStripButtonRedo;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonCheck;
        private System.Windows.Forms.ToolStripButton toolStripAssemblies;
        private System.Windows.Forms.ToolStripButton toolStripButtonScriptAssemblies;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxAE;
        private System.Windows.Forms.ToolStripButton toolStripButtonExpand;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private ToolStripIncrementalSearcher toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelParameters;        
    }
}
