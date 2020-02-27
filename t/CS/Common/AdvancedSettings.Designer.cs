namespace FormsDemo
{
   partial class AdvancedSettings
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedSettings));
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this._chkCompareAllPages = new System.Windows.Forms.CheckBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.label4 = new System.Windows.Forms.Label();
         this._chkOCRManager = new System.Windows.Forms.CheckBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._chkDefaultObjectManager = new System.Windows.Forms.CheckBox();
         this._chkBarcodeManager = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox2.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         resources.ApplyResources(this.btnOK, "btnOK");
         this.btnOK.Name = "btnOK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         resources.ApplyResources(this.btnCancel, "btnCancel");
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // _chkCompareAllPages
         // 
         resources.ApplyResources(this._chkCompareAllPages, "_chkCompareAllPages");
         this._chkCompareAllPages.Checked = true;
         this._chkCompareAllPages.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkCompareAllPages.Name = "_chkCompareAllPages";
         this._chkCompareAllPages.UseVisualStyleBackColor = true;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Controls.Add(this._chkCompareAllPages);
         resources.ApplyResources(this.groupBox2, "groupBox2");
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.TabStop = false;
         // 
         // label4
         // 
         resources.ApplyResources(this.label4, "label4");
         this.label4.Name = "label4";
         // 
         // _chkOCRManager
         // 
         resources.ApplyResources(this._chkOCRManager, "_chkOCRManager");
         this._chkOCRManager.Checked = true;
         this._chkOCRManager.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkOCRManager.Name = "_chkOCRManager";
         this._chkOCRManager.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._chkDefaultObjectManager);
         this.groupBox1.Controls.Add(this._chkBarcodeManager);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this._chkOCRManager);
         resources.ApplyResources(this.groupBox1, "groupBox1");
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.TabStop = false;
         // 
         // _chkDefaultObjectManager
         // 
         resources.ApplyResources(this._chkDefaultObjectManager, "_chkDefaultObjectManager");
         this._chkDefaultObjectManager.Checked = true;
         this._chkDefaultObjectManager.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkDefaultObjectManager.Name = "_chkDefaultObjectManager";
         this._chkDefaultObjectManager.UseVisualStyleBackColor = true;
         // 
         // _chkBarcodeManager
         // 
         resources.ApplyResources(this._chkBarcodeManager, "_chkBarcodeManager");
         this._chkBarcodeManager.Checked = true;
         this._chkBarcodeManager.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkBarcodeManager.Name = "_chkBarcodeManager";
         this._chkBarcodeManager.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // AdvancedSettings
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AdvancedSettings";
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.CheckBox _chkCompareAllPages;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.CheckBox _chkOCRManager;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.CheckBox _chkDefaultObjectManager;
      private System.Windows.Forms.CheckBox _chkBarcodeManager;
   }
}