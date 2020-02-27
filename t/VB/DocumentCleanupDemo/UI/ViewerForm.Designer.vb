Imports Microsoft.VisualBasic
Imports System
Namespace DocumentCleanupDemo
	Public Partial Class ViewerForm
		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		'protected override void Dispose(bool disposing)
		'{
		'    if (disposing && (components != null))
		'    {
		'        components.Dispose();
		'    }
		'    base.Dispose(disposing);
		'}

		Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewerForm))
         Me.SuspendLayout()
         '
         'ViewerForm
         '
         Me.ClientSize = New System.Drawing.Size(1002, 511)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Name = "ViewerForm"
         Me.ResumeLayout(False)

      End Sub


		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>       

		#End Region
	End Class
End Namespace