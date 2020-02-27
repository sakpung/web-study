namespace DocumentCleanupDemo
{
    partial class ViewerForm
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private void InitializeComponent()
        {
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerForm));
           this.SuspendLayout();
           // 
           // ViewerForm
           // 
           this.ClientSize = new System.Drawing.Size(900, 464);
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.Name = "ViewerForm";
           this.ResumeLayout(false);

        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>       

        #endregion
    }
}