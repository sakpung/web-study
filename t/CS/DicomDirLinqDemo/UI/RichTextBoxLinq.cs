// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace CSLinqDicomDirDemo.UI
{
    public class RichTextBoxLinq : RichTextBox
    {
        private Dictionary<string,Color> _Keywords = new Dictionary<string,Color>() { 
                                                                                        {"from",Color.Blue}, 
                                                                                        {"select",Color.Blue},
                                                                                        {"where",Color.Blue},
                                                                                        {"in",Color.Blue },
                                                                                        {"PatientBase",Color.Green},
                                                                                        {"StudyBase",Color.Green},
                                                                                        {"SeriesBase",Color.Green},
                                                                                        {"ImageBase",Color.Green}
                                                                                    };

        private const int WM_SETREDRAW = 0xB;

        [DllImport("User32")]
        private static extern bool SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
       
        [DllImport("User32.dll")]
        private extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        public RichTextBoxLinq()
            : base()
        {
            TextChanged += new EventHandler(RichTextBoxLinq_TextChanged);
        }

        private void Freeze()
        {
            SendMessage(Handle, WM_SETREDRAW, 0, 0);
        }

        private void Unfreeze()
        {
            SendMessage(Handle, WM_SETREDRAW, 1, 0);
            Invalidate(true);
        }

        void RichTextBoxLinq_TextChanged(object sender, EventArgs e)
        {
            HighLight();
        }       

        public void HighLight()
        {            
            MatchCollection RegExp = null;            
            int startPosition = SelectionStart;            

            Freeze();
            try
            {
                foreach (string keyword in _Keywords.Keys)
                {
                    RegExp = Regex.Matches(Text, @"\b" + keyword + @"\b", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    foreach (Match match in RegExp)
                    {                        
                        try
                        {
                            Select(match.Index, match.Length);
                            SelectionColor = _Keywords[keyword];
                            SelectionStart = startPosition;
                            SelectionColor = Color.Black;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            finally
            {
                Unfreeze();
            }
        }
    }
}
