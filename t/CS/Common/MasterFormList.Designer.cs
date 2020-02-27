namespace FormsDemo
{
   partial class MasterFormList
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterFormList));
          this._masterFormList = new System.Windows.Forms.ListBox();
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this.SuspendLayout();
          // 
          // _masterFormList
          // 
          this._masterFormList.FormattingEnabled = true;
          resources.ApplyResources(this._masterFormList, "_masterFormList");
          this._masterFormList.Name = "_masterFormList";
          this._masterFormList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._masterFormList_MouseDoubleClick);
          this._masterFormList.SelectedIndexChanged += new System.EventHandler(this._masterFormList_SelectedIndexChanged);
          // 
          // _btnOk
          // 
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // _btnCancel
          // 
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // MasterFormList
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ControlBox = false;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._masterFormList);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.Name = "MasterFormList";
          this.Load += new System.EventHandler(this.MasterFormList_Load);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListBox _masterFormList;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}