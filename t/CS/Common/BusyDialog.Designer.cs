namespace FormsDemo
{
   partial class BusyDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusyDialog));
         this._lblFormName = new System.Windows.Forms.Label();
         this._lblLabel1 = new System.Windows.Forms.Label();
         this._lblLabel2 = new System.Windows.Forms.Label();
         this._progressBar = new System.Windows.Forms.ProgressBar();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lblFormName
         // 
         resources.ApplyResources(this._lblFormName, "_lblFormName");
         this._lblFormName.Name = "_lblFormName";
         // 
         // _lblLabel1
         // 
         resources.ApplyResources(this._lblLabel1, "_lblLabel1");
         this._lblLabel1.Name = "_lblLabel1";
         // 
         // _lblLabel2
         // 
         resources.ApplyResources(this._lblLabel2, "_lblLabel2");
         this._lblLabel2.Name = "_lblLabel2";
         // 
         // _progressBar
         // 
         resources.ApplyResources(this._progressBar, "_progressBar");
         this._progressBar.Name = "_progressBar";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // BusyDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ControlBox = false;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._progressBar);
         this.Controls.Add(this._lblLabel2);
         this.Controls.Add(this._lblLabel1);
         this.Controls.Add(this._lblFormName);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BusyDialog";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblFormName;
      private System.Windows.Forms.Label _lblLabel1;
      private System.Windows.Forms.Label _lblLabel2;
      private System.Windows.Forms.ProgressBar _progressBar;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}