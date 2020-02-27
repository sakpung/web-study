// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Leadtools.DicomDemos
{
    public class TextBoxTraceListener : TraceListener
    {
        private RichTextBox _TextBox = null;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr window, int message, int wparam, int lparam);
        public const int WM_VSCROLL = 0x115;
        public const int SB_BOTTOM = 7;

        public delegate void AddTextDelegate(string text);

        public TextBoxTraceListener(RichTextBox textbox)
        {
            _TextBox = textbox;
        }        

        public override void WriteLine(string message)
        { 
            if(_TextBox.InvokeRequired)
            {
                _TextBox.Invoke(new AddTextDelegate(WriteLine), message);
                return;
            }

            Color oldColor = _TextBox.SelectionColor;
            string[] lines = message.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            _TextBox.SelectionLength = 0;
            _TextBox.SelectionStart = _TextBox.Text.Length;
            _TextBox.SelectionColor = Color.Green;
            _TextBox.SelectionFont = new Font(_TextBox.SelectionFont, FontStyle.Bold);

            _TextBox.AppendText(lines[0]);
            _TextBox.SelectionFont = new Font(_TextBox.SelectionFont, FontStyle.Regular);          
            for (int i = 1; i < lines.Length - 1; i++)
            {
                _TextBox.AppendText(lines[i]);
                SendMessage(_TextBox.Handle, WM_VSCROLL, SB_BOTTOM, 0);
            }
            _TextBox.AppendText("\r\n");
            _TextBox.SelectionColor = oldColor;
        }

        public override void Write(string message)
        {
            WriteLine(message);
        }
    }
}
