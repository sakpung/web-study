// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrintToPACSDemo.UI
{
   public partial class FrmUsage : Form
   {
      public FrmUsage()
      {
         InitializeComponent();
      }

      private void FrmUsage2_Load(object sender, EventArgs e)
      {
         richTextBox1.Rtf = RTFConstants.RtfFiles[5];
      }

      private void label_MouseLeave(object sender, EventArgs e)
      {
         richTextBox1.Rtf = RTFConstants.RtfFiles[5];
      }

      private void label_MouseEnter(object sender, EventArgs e)
      {
         int iList = int.Parse(((Control)sender).Tag.ToString());
         richTextBox1.Rtf = RTFConstants.RtfFiles[iList];
      }
   }

   static class RTFConstants
   {

      public static List<string> RtfFiles = new List<string>();
      static RTFConstants()
      {
         RtfFiles.Add(@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}{\f2\fnil\fcharset2 Symbol;}}
\viewkind4\uc1\pard\sl360\slmult1\lang9\b\f0\fs24 Capture Options: \f1\fs22\par
\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sl276\slmult1 Virtual Printer Driver \b0 - capture the print output from any Windows application \par
\b{\pntext\f2\'B7\tab}Twain\b0 - scan images from TWAIN device \par
\b{\pntext\f2\'B7\tab}WIA \b0 - capture images from digital devices and media using WIA interface \par
\b{\pntext\f2\'B7\tab}Screen Capture \b0 - Capture any object or Windows or selected area or full screen \par
\b{\pntext\f2\'B7\tab}File Interface\b0 - Import from over 150+ image file formats or PDF \par
\b{\pntext\f2\'B7\tab}Manually Entry\b0 - manually enter the required information  \par
}
"
            );
         RtfFiles.Add(@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}{\f2\fnil\fcharset2 Symbol;}}
{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sl360\slmult1\lang9\b\f0\fs24 Output DICOM Storage Object Options as: \f1\fs22\par
\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sl276\slmult1\b0 Secondary Capture Image Storage   \par
{\pntext\f2\'B7\tab}Multi-frame  Secondary Capture Grayscale Byte Image Storage \par
{\pntext\f2\'B7\tab}Multi-frame  Secondary Capture True Color Image Storage\par
{\pntext\f2\'B7\tab}DICOM Encapsulated PDF \b\par
}
 ");

         RtfFiles.Add(@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}{\f2\fnil\fcharset2 Symbol;}}
{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sl360\slmult1\lang9\b\f0\fs24 DICOM patient/study Metadata collection options:\f1\fs22\par
\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sl276\slmult1 Modality Work-list (MWL) \b0 - Query work-list server for scheduled work item and patient/study information. \par
\b{\pntext\f2\'B7\tab}Query PACS \b0\endash  query for existing studies on PACS and associate the newly captured image(s) to existing patient or study. \par
{\pntext\f2\'B7\tab}Import the patient/study information from \b existing local DICOM file \b0 on disk    DICOM Encapsulated PDF \b\par
}
 ");
         RtfFiles.Add(@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}{\f2\fnil\fcharset2 Symbol;}}
{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sl360\slmult1\lang9\b\f0\fs24 Compression Option:\b0\f1\fs22\par
\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sl276\slmult1 Lossy JPEG   \b\par
\b0{\pntext\f2\'B7\tab}Lossless JPEG \b\par
\b0{\pntext\f2\'B7\tab}Lossless JPEG 2000 \b\par
\b0{\pntext\f2\'B7\tab}Lossy JPEG 2000 \b\par
\b0{\pntext\f2\'B7\tab}Uncompressed\b\par
\pard\li90\sl276\slmult1\par
\i Note: This configuration is under the option dialog.\i0\par
}
 ");
         RtfFiles.Add(@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}{\f2\fnil\fcharset2 Symbol;}}
{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\sl360\slmult1\lang9\b\f0\fs24 Export Options:\b0\f1\fs22\par
\pard{\pntext\f2\'B7\tab}{\*\pn\pnlvlblt\pnf2\pnindent0{\pntxtb\'B7}}\fi-360\li720\sl276\slmult1 Save to local folder as DICOM file. \b\par
\b0{\pntext\f2\'B7\tab}Store to PACS via DICOM message \b\par
}
 ");
         RtfFiles.Add(@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\froman\fprq2\fcharset0 Times New Roman;}{\f1\fnil\fcharset0 Calibri;}}
{\colortbl ;\red0\green77\blue187;}
{\*\generator Msftedit 5.41.21.2509;}\viewkind4\uc1\pard\ul\b\f0\fs28 PrintToPACS:\par
\par
\pard\li270\ulnone\b0\f1\fs24 This utility allows user to capture images and documents in many different ways, associate the captured data to studies on PACS and store the data to PACS as secondary capture or DICOM Encapsulated PDF. \f0\par
\f1\par
\pard\sa200\sl276\slmult1 Note: Move the mouse over the \cf1\b\i blue labels\i0  \cf0\b0 for viewing the underline features.\lang9\fs22\par
}
 ");
      }
   }
}
