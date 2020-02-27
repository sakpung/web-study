namespace MainDemo
{
   partial class PanViewerForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanViewerForm));
         this.SuspendLayout();
         // 
         // PanViewerForm
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PanViewerForm";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Closing += new System.ComponentModel.CancelEventHandler(this.PanViewerForm_Closing);
         this.SizeChanged += new System.EventHandler(this.PanViewerForm_SizeChanged);
         this.ResumeLayout(false);

      }

      #endregion
   }
}