namespace Leadtools.Demos.Workstation.Customized
{
   partial class TranslatedCinePlayer
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
         this.CinePlayerGroupBox.SuspendLayout();
         this.FramesGroupBox.SuspendLayout();
         this.ExtendedParametersGroupBox.SuspendLayout();
         this.PlayerGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FramePerSecondNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.JumpFramesNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // CinePlayerGroupBox
         // 
         this.CinePlayerGroupBox.Size = new System.Drawing.Size(600, 246);
         this.CinePlayerGroupBox.Text = "Reproductor de Cine";
         // 
         // FramesGroupBox
         // 
         this.FramesGroupBox.Location = new System.Drawing.Point(240, 93);
         this.FramesGroupBox.Size = new System.Drawing.Size(352, 143);
         this.FramesGroupBox.Text = "&Imagenes";
         // 
         // ToEndCheckBox
         // 
         this.ToEndCheckBox.Size = new System.Drawing.Size(79, 17);
         this.ToEndCheckBox.Text = "Hasta &Final";
         // 
         // FramesToLabel
         // 
         this.FramesToLabel.Size = new System.Drawing.Size(35, 13);
         this.FramesToLabel.Text = "&Hasta";
         // 
         // FramesFromLabel
         // 
         this.FramesFromLabel.Size = new System.Drawing.Size(38, 13);
         this.FramesFromLabel.Text = "Desde";
         // 
         // JumpFramesLabel
         // 
         this.JumpFramesLabel.Location = new System.Drawing.Point(198, 21);
         this.JumpFramesLabel.Size = new System.Drawing.Size(53, 13);
         this.JumpFramesLabel.Text = "Imagenes";
         // 
         // FramesLabel
         // 
         this.FramesLabel.Size = new System.Drawing.Size(53, 13);
         this.FramesLabel.Text = "&Imagenes";
         // 
         // FramesComboBox
         // 
         this.FramesComboBox.Location = new System.Drawing.Point(65, 18);
         // 
         // ExtendedParametersGroupBox
         // 
         this.ExtendedParametersGroupBox.Size = new System.Drawing.Size(227, 143);
         // 
         // ShowAnnotationChcekBox
         // 
         this.ShowAnnotationChcekBox.Size = new System.Drawing.Size(112, 17);
         this.ShowAnnotationChcekBox.Text = "Mostrar A&notación";
         // 
         // ShowRegionCheckBox
         // 
         this.ShowRegionCheckBox.Size = new System.Drawing.Size(98, 17);
         this.ShowRegionCheckBox.Text = "&Mostrar Región";
         // 
         // AnimateAllSubCellsCheckBox
         // 
         this.AnimateAllSubCellsCheckBox.Size = new System.Drawing.Size(142, 17);
         this.AnimateAllSubCellsCheckBox.Text = "&Animar Todas las Celdas";
         // 
         // InterpolationComboBox
         // 
         this.InterpolationComboBox.Location = new System.Drawing.Point(113, 49);
         // 
         // InterpolationLabel
         // 
         this.InterpolationLabel.Size = new System.Drawing.Size(68, 13);
         this.InterpolationLabel.Text = "&Interpolación";
         // 
         // PlayModeLabel
         // 
         this.PlayModeLabel.Size = new System.Drawing.Size(104, 13);
         this.PlayModeLabel.Text = "&Modo de Reproducir";
         // 
         // PlayerGroupBox
         // 
         this.PlayerGroupBox.Size = new System.Drawing.Size(585, 59);
         this.PlayerGroupBox.Text = "&Reproductor";
         // 
         // FastSpeedLabel
         // 
         this.FastSpeedLabel.Location = new System.Drawing.Point(460, 28);
         this.FastSpeedLabel.Size = new System.Drawing.Size(41, 13);
         this.FastSpeedLabel.Text = "Rápido";
         // 
         // SlowSpeedLabel
         // 
         this.SlowSpeedLabel.Size = new System.Drawing.Size(34, 13);
         this.SlowSpeedLabel.Text = "Lento";
         // 
         // SpeedTrackBar
         // 
         this.SpeedTrackBar.Size = new System.Drawing.Size(312, 39);
         // 
         // CloseDlgButton
         // 
         this.CloseDlgButton.Location = new System.Drawing.Point(584, 0);
         // 
         // FramePerSecondLabel
         // 
         this.FramePerSecondLabel.Location = new System.Drawing.Point(552, 28);
         this.FramePerSecondLabel.Size = new System.Drawing.Size(22, 13);
         this.FramePerSecondLabel.Text = "I/S";
         // 
         // FramePerSecondNumericUpDown
         // 
         this.FramePerSecondNumericUpDown.Location = new System.Drawing.Point(508, 25);
         // 
         // AdvancedChcekBox
         // 
         this.AdvancedChcekBox.Checked = true;
         this.AdvancedChcekBox.CheckState = System.Windows.Forms.CheckState.Checked;
         this.AdvancedChcekBox.Location = new System.Drawing.Point(496, 10);
         this.AdvancedChcekBox.Size = new System.Drawing.Size(74, 17);
         this.AdvancedChcekBox.Text = "Avanzado";
         // 
         // JumpFramesNumericUpDown
         // 
         this.JumpFramesNumericUpDown.Location = new System.Drawing.Point(157, 19);
         // 
         // PlayModeComboBox
         // 
         this.PlayModeComboBox.Location = new System.Drawing.Point(113, 21);
         // 
         // TranslatedCinePlayer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(600, 246);
         this.Name = "TranslatedCinePlayer";
         this.Text = "TranslatedCinePlayer";
         this.CinePlayerGroupBox.ResumeLayout(false);
         this.CinePlayerGroupBox.PerformLayout();
         this.FramesGroupBox.ResumeLayout(false);
         this.FramesGroupBox.PerformLayout();
         this.ExtendedParametersGroupBox.ResumeLayout(false);
         this.ExtendedParametersGroupBox.PerformLayout();
         this.PlayerGroupBox.ResumeLayout(false);
         this.PlayerGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FramePerSecondNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.JumpFramesNumericUpDown)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion
   }
}