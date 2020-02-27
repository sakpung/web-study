namespace MainDemo
{
   partial class CommandProgressDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandProgressDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._progressBarCommand = new System.Windows.Forms.ProgressBar();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _progressBarCommand
         // 
         resources.ApplyResources(this._progressBarCommand, "_progressBarCommand");
         this._progressBarCommand.Name = "_progressBarCommand";
         // 
         // CommandProgressDialog
         // 
         this.AcceptButton = this._btnCancel;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._progressBarCommand);
         this.Controls.Add(this._btnCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CommandProgressDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.CommandProgressDialog_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.ProgressBar _progressBarCommand;
   }
}