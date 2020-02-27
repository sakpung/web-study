namespace OcrDemo
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
         this._cancelButton = new System.Windows.Forms.Button();
         this._zonesLabel = new System.Windows.Forms.Label();
         this._okButton = new System.Windows.Forms.Button();
         this._pnlContainer = new System.Windows.Forms.Panel();
         this._btnDeleteZone = new System.Windows.Forms.Button();
         this._btnAddZone = new System.Windows.Forms.Button();
         this._btnClearZones = new System.Windows.Forms.Button();
         this._btnInvertSelection = new System.Windows.Forms.Button();
         this._lbZonesList = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(745, 272);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 10;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _zonesLabel
         // 
         this._zonesLabel.AutoSize = true;
         this._zonesLabel.Location = new System.Drawing.Point(12, 9);
         this._zonesLabel.Name = "_zonesLabel";
         this._zonesLabel.Size = new System.Drawing.Size(40, 13);
         this._zonesLabel.TabIndex = 0;
         this._zonesLabel.Text = "&Zones:";
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(664, 272);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 9;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         // 
         // _pnlContainer
         // 
         this._pnlContainer.Location = new System.Drawing.Point(222, 12);
         this._pnlContainer.Name = "_pnlContainer";
         this._pnlContainer.Size = new System.Drawing.Size(600, 223);
         this._pnlContainer.TabIndex = 8;
         // 
         // _btnDeleteZone
         // 
         this._btnDeleteZone.Location = new System.Drawing.Point(117, 241);
         this._btnDeleteZone.Name = "_btnDeleteZone";
         this._btnDeleteZone.Size = new System.Drawing.Size(90, 23);
         this._btnDeleteZone.TabIndex = 5;
         this._btnDeleteZone.Text = "&Delete";
         this._btnDeleteZone.UseVisualStyleBackColor = true;
         this._btnDeleteZone.Click += new System.EventHandler(this._btnDeleteZone_Click);
         // 
         // _btnAddZone
         // 
         this._btnAddZone.Location = new System.Drawing.Point(15, 241);
         this._btnAddZone.Name = "_btnAddZone";
         this._btnAddZone.Size = new System.Drawing.Size(90, 23);
         this._btnAddZone.TabIndex = 4;
         this._btnAddZone.Text = "&Add";
         this._btnAddZone.UseVisualStyleBackColor = true;
         this._btnAddZone.Click += new System.EventHandler(this._btnAddZone_Click);
         // 
         // _btnClearZones
         // 
         this._btnClearZones.Location = new System.Drawing.Point(15, 270);
         this._btnClearZones.Name = "_btnClearZones";
         this._btnClearZones.Size = new System.Drawing.Size(90, 23);
         this._btnClearZones.TabIndex = 6;
         this._btnClearZones.Text = "&Clear";
         this._btnClearZones.UseVisualStyleBackColor = true;
         this._btnClearZones.Click += new System.EventHandler(this._btnClearZones_Click);
         // 
         // _btnInvertSelection
         // 
         this._btnInvertSelection.Location = new System.Drawing.Point(117, 270);
         this._btnInvertSelection.Name = "_btnInvertSelection";
         this._btnInvertSelection.Size = new System.Drawing.Size(90, 23);
         this._btnInvertSelection.TabIndex = 15;
         this._btnInvertSelection.Text = "I&nvert selection";
         this._btnInvertSelection.UseVisualStyleBackColor = true;
         this._btnInvertSelection.Click += new System.EventHandler(this._btnInvertSelection_Click);
         // 
         // _lbZonesList
         // 
         this._lbZonesList.FormattingEnabled = true;
         this._lbZonesList.Location = new System.Drawing.Point(15, 25);
         this._lbZonesList.Name = "_lbZonesList";
         this._lbZonesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
         this._lbZonesList.Size = new System.Drawing.Size(192, 212);
         this._lbZonesList.TabIndex = 16;
         this._lbZonesList.SelectedIndexChanged += new System.EventHandler(this._lbZonesList_SelectedIndexChanged);
         // 
         // ZonePropertiesDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(832, 303);
         this.Controls.Add(this._lbZonesList);
         this.Controls.Add(this._btnInvertSelection);
         this.Controls.Add(this._btnClearZones);
         this.Controls.Add(this._btnAddZone);
         this.Controls.Add(this._btnDeleteZone);
         this.Controls.Add(this._pnlContainer);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._zonesLabel);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ZonePropertiesDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Update Zones";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Label _zonesLabel;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Panel _pnlContainer;
      private System.Windows.Forms.Button _btnDeleteZone;
      private System.Windows.Forms.Button _btnAddZone;
      private System.Windows.Forms.Button _btnClearZones;
      private System.Windows.Forms.Button _btnInvertSelection;
      private System.Windows.Forms.ListBox _lbZonesList;
   }
}