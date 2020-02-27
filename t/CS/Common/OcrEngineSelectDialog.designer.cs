namespace Leadtools.Demos
{
   partial class OcrEngineSelectDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OcrEngineSelectDialog));
         this._tcMain = new System.Windows.Forms.TabControl();
         this._tpNoEnginesFound = new System.Windows.Forms.TabPage();
         this._lblNoEnginesFound = new System.Windows.Forms.Label();
         this._tpSelectEngine = new System.Windows.Forms.TabPage();
         this._cbEngineSelection = new System.Windows.Forms.ComboBox();
         this._lblSelectEngine = new System.Windows.Forms.Label();
         this._tpStartEngine = new System.Windows.Forms.TabPage();
         this._lblStatus = new System.Windows.Forms.Label();
         this._lblStartEngine = new System.Windows.Forms.Label();
         this._lbDownload = new System.Windows.Forms.LinkLabel();
         this._lblAllowNoOcr = new System.Windows.Forms.Label();
         this._lblDownload = new System.Windows.Forms.Label();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._tcMain.SuspendLayout();
         this._tpNoEnginesFound.SuspendLayout();
         this._tpSelectEngine.SuspendLayout();
         this._tpStartEngine.SuspendLayout();
         this.SuspendLayout();
         // 
         // _tcMain
         // 
         this._tcMain.Controls.Add(this._tpNoEnginesFound);
         this._tcMain.Controls.Add(this._tpSelectEngine);
         this._tcMain.Controls.Add(this._tpStartEngine);
         resources.ApplyResources(this._tcMain, "_tcMain");
         this._tcMain.Name = "_tcMain";
         this._tcMain.SelectedIndex = 0;
         // 
         // _tpNoEnginesFound
         // 
         this._tpNoEnginesFound.Controls.Add(this._lblNoEnginesFound);
         resources.ApplyResources(this._tpNoEnginesFound, "_tpNoEnginesFound");
         this._tpNoEnginesFound.Name = "_tpNoEnginesFound";
         this._tpNoEnginesFound.UseVisualStyleBackColor = true;
         // 
         // _lblNoEnginesFound
         // 
         resources.ApplyResources(this._lblNoEnginesFound, "_lblNoEnginesFound");
         this._lblNoEnginesFound.Name = "_lblNoEnginesFound";
         // 
         // _tpSelectEngine
         // 
         this._tpSelectEngine.Controls.Add(this._cbEngineSelection);
         this._tpSelectEngine.Controls.Add(this._lblSelectEngine);
         resources.ApplyResources(this._tpSelectEngine, "_tpSelectEngine");
         this._tpSelectEngine.Name = "_tpSelectEngine";
         this._tpSelectEngine.UseVisualStyleBackColor = true;
         // 
         // _cbEngineSelection
         // 
         this._cbEngineSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbEngineSelection.FormattingEnabled = true;
         resources.ApplyResources(this._cbEngineSelection, "_cbEngineSelection");
         this._cbEngineSelection.Name = "_cbEngineSelection";
         // 
         // _lblSelectEngine
         // 
         resources.ApplyResources(this._lblSelectEngine, "_lblSelectEngine");
         this._lblSelectEngine.Name = "_lblSelectEngine";
         // 
         // _tpStartEngine
         // 
         this._tpStartEngine.Controls.Add(this._lblStatus);
         this._tpStartEngine.Controls.Add(this._lblStartEngine);
         resources.ApplyResources(this._tpStartEngine, "_tpStartEngine");
         this._tpStartEngine.Name = "_tpStartEngine";
         this._tpStartEngine.UseVisualStyleBackColor = true;
         // 
         // _lblStatus
         // 
         this._lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
         resources.ApplyResources(this._lblStatus, "_lblStatus");
         this._lblStatus.Name = "_lblStatus";
         // 
         // _lblStartEngine
         // 
         resources.ApplyResources(this._lblStartEngine, "_lblStartEngine");
         this._lblStartEngine.Name = "_lblStartEngine";
         // 
         // _lbDownload
         // 
         resources.ApplyResources(this._lbDownload, "_lbDownload");
         this._lbDownload.Name = "_lbDownload";
         this._lbDownload.TabStop = true;
         this._lbDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._lbDownload_LinkClicked);
         // 
         // _lblAllowNoOcr
         // 
         resources.ApplyResources(this._lblAllowNoOcr, "_lblAllowNoOcr");
         this._lblAllowNoOcr.Name = "_lblAllowNoOcr";
         // 
         // _lblDownload
         // 
         resources.ApplyResources(this._lblDownload, "_lblDownload");
         this._lblDownload.Name = "_lblDownload";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // OcrEngineSelectDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._lblAllowNoOcr);
         this.Controls.Add(this._lblDownload);
         this.Controls.Add(this._lbDownload);
         this.Controls.Add(this._tcMain);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OcrEngineSelectDialog";
         this._tcMain.ResumeLayout(false);
         this._tpNoEnginesFound.ResumeLayout(false);
         this._tpSelectEngine.ResumeLayout(false);
         this._tpSelectEngine.PerformLayout();
         this._tpStartEngine.ResumeLayout(false);
         this._tpStartEngine.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TabControl _tcMain;
      private System.Windows.Forms.TabPage _tpNoEnginesFound;
      private System.Windows.Forms.TabPage _tpSelectEngine;
      private System.Windows.Forms.Label _lblNoEnginesFound;
      private System.Windows.Forms.LinkLabel _lbDownload;
      private System.Windows.Forms.Label _lblAllowNoOcr;
      private System.Windows.Forms.Label _lblDownload;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblSelectEngine;
      private System.Windows.Forms.ComboBox _cbEngineSelection;
      private System.Windows.Forms.TabPage _tpStartEngine;
      private System.Windows.Forms.Label _lblStartEngine;
      private System.Windows.Forms.Label _lblStatus;


   }
}