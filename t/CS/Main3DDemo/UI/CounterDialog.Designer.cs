namespace Main3DDemo
{
   partial class CounterDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CounterDialog));
          this._progress = new System.Windows.Forms.ProgressBar();
          this._lblCounter = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // _progress
          // 
          resources.ApplyResources(this._progress, "_progress");
          this._progress.Name = "_progress";
          // 
          // _lblCounter
          // 
          resources.ApplyResources(this._lblCounter, "_lblCounter");
          this._lblCounter.Name = "_lblCounter";
          // 
          // CounterDialog
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this._lblCounter);
          this.Controls.Add(this._progress);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
          this.Name = "CounterDialog";
          this.ShowInTaskbar = false;
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ProgressBar _progress;
      private System.Windows.Forms.Label _lblCounter;
   }
}