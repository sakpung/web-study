namespace OcrMultiEngineDemo
{
   partial class ZonePropertiesDialog
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
         if(disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZonePropertiesDialog));
          this._cancelButton = new System.Windows.Forms.Button();
          this._zonesLabel = new System.Windows.Forms.Label();
          this._okButton = new System.Windows.Forms.Button();
          this._pnlContainer = new System.Windows.Forms.Panel();
          this._tvZonesList = new System.Windows.Forms.TreeView();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this._btnClearZones = new System.Windows.Forms.Button();
          this._btnAddZone = new System.Windows.Forms.Button();
          this._btnDeleteZone = new System.Windows.Forms.Button();
          this._cellsGroupBox = new System.Windows.Forms.GroupBox();
          this._btnClearCells = new System.Windows.Forms.Button();
          this._btnDetectCells = new System.Windows.Forms.Button();
          this.groupBox1.SuspendLayout();
          this._cellsGroupBox.SuspendLayout();
          this.SuspendLayout();
          // 
          // _cancelButton
          // 
          this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._cancelButton, "_cancelButton");
          this._cancelButton.Name = "_cancelButton";
          this._cancelButton.UseVisualStyleBackColor = true;
          // 
          // _zonesLabel
          // 
          resources.ApplyResources(this._zonesLabel, "_zonesLabel");
          this._zonesLabel.Name = "_zonesLabel";
          // 
          // _okButton
          // 
          this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
          resources.ApplyResources(this._okButton, "_okButton");
          this._okButton.Name = "_okButton";
          this._okButton.UseVisualStyleBackColor = true;
          this._okButton.Click += new System.EventHandler(this._okButton_Click);
          // 
          // _pnlContainer
          // 
          resources.ApplyResources(this._pnlContainer, "_pnlContainer");
          this._pnlContainer.Name = "_pnlContainer";
          // 
          // _tvZonesList
          // 
          this._tvZonesList.FullRowSelect = true;
          this._tvZonesList.HideSelection = false;
          resources.ApplyResources(this._tvZonesList, "_tvZonesList");
          this._tvZonesList.Name = "_tvZonesList";
          this._tvZonesList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._tvZonesList_AfterSelect);
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this._btnClearZones);
          this.groupBox1.Controls.Add(this._btnAddZone);
          this.groupBox1.Controls.Add(this._btnDeleteZone);
          resources.ApplyResources(this.groupBox1, "groupBox1");
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.TabStop = false;
          // 
          // _btnClearZones
          // 
          resources.ApplyResources(this._btnClearZones, "_btnClearZones");
          this._btnClearZones.Name = "_btnClearZones";
          this._btnClearZones.UseVisualStyleBackColor = true;
          this._btnClearZones.Click += new System.EventHandler(this._btnClearZones_Click);
          // 
          // _btnAddZone
          // 
          resources.ApplyResources(this._btnAddZone, "_btnAddZone");
          this._btnAddZone.Name = "_btnAddZone";
          this._btnAddZone.UseVisualStyleBackColor = true;
          this._btnAddZone.Click += new System.EventHandler(this._btnAddZone_Click);
          // 
          // _btnDeleteZone
          // 
          resources.ApplyResources(this._btnDeleteZone, "_btnDeleteZone");
          this._btnDeleteZone.Name = "_btnDeleteZone";
          this._btnDeleteZone.UseVisualStyleBackColor = true;
          this._btnDeleteZone.Click += new System.EventHandler(this._btnDeleteZone_Click);
          // 
          // _cellsGroupBox
          // 
          this._cellsGroupBox.Controls.Add(this._btnClearCells);
          this._cellsGroupBox.Controls.Add(this._btnDetectCells);
          resources.ApplyResources(this._cellsGroupBox, "_cellsGroupBox");
          this._cellsGroupBox.Name = "_cellsGroupBox";
          this._cellsGroupBox.TabStop = false;
          // 
          // _btnClearCells
          // 
          resources.ApplyResources(this._btnClearCells, "_btnClearCells");
          this._btnClearCells.Name = "_btnClearCells";
          this._btnClearCells.UseVisualStyleBackColor = true;
          this._btnClearCells.Click += new System.EventHandler(this._btnClearCells_Click);
          // 
          // _btnDetectCells
          // 
          resources.ApplyResources(this._btnDetectCells, "_btnDetectCells");
          this._btnDetectCells.Name = "_btnDetectCells";
          this._btnDetectCells.UseVisualStyleBackColor = true;
          this._btnDetectCells.Click += new System.EventHandler(this._btnDetectCells_Click);
          // 
          // ZonePropertiesDialog
          // 
          this.AcceptButton = this._okButton;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._cancelButton;
          this.Controls.Add(this._cellsGroupBox);
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this._tvZonesList);
          this.Controls.Add(this._pnlContainer);
          this.Controls.Add(this._cancelButton);
          this.Controls.Add(this._zonesLabel);
          this.Controls.Add(this._okButton);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ZonePropertiesDialog";
          this.ShowInTaskbar = false;
          this.groupBox1.ResumeLayout(false);
          this._cellsGroupBox.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Label _zonesLabel;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Panel _pnlContainer;
      private System.Windows.Forms.TreeView _tvZonesList;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button _btnClearZones;
      private System.Windows.Forms.Button _btnAddZone;
      private System.Windows.Forms.Button _btnDeleteZone;
      private System.Windows.Forms.GroupBox _cellsGroupBox;
      private System.Windows.Forms.Button _btnClearCells;
      private System.Windows.Forms.Button _btnDetectCells;
   }
}