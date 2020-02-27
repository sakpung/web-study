// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CCOWDashboard
{
    public class RichTextBoxExtended : RichTextBox
    {
		[ StructLayout( LayoutKind.Sequential )]
		private struct CHARFORMAT2_STRUCT
		{
			public UInt32	cbSize; 
			public UInt32   dwMask; 
			public UInt32   dwEffects; 
			public Int32    yHeight; 
			public Int32    yOffset; 
			public Int32	crTextColor; 
			public byte     bCharSet; 
			public byte     bPitchAndFamily; 
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
			public char[]   szFaceName; 
			public UInt16	wWeight;
			public UInt16	sSpacing;
			public int		crBackColor; // Color.ToArgb() -> int
			public int		lcid;
			public int		dwReserved;
			public Int16	sStyle;
			public Int16	wKerning;
			public byte		bUnderlineType;
			public byte		bAnimation;
			public byte		bRevAuthor;
			public byte		bReserved1;
		}

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

		private const int WM_USER			 = 0x0400;
		private const int EM_GETCHARFORMAT	 = WM_USER+58;
		private const int EM_SETCHARFORMAT	 = WM_USER+68;

		private const int SCF_SELECTION	= 0x0001;
		private const int SCF_WORD		= 0x0002;
		private const int SCF_ALL		= 0x0004;
		
		private const UInt32 CFE_LINK		= 0x0020;		
		private const UInt32 CFM_LINK		= 0x00000020;

        public RichTextBoxExtended()
		{
			DetectUrls = false;
		}		
		
		public void InsertLink(string text)
		{
			InsertLink(text, SelectionStart);
		}
		
		public void InsertLink(string text, int position)
		{
			if (position < 0 || position > Text.Length)
				throw new ArgumentOutOfRangeException("position");

			SelectionStart = position;
			SelectedText = text;
			Select(position, text.Length);
			SetSelectionLink(true);
			Select(position + text.Length, 0);
		}					
		
		public void SetSelectionLink(bool link)
		{
			SetSelectionStyle(CFM_LINK, link ? CFE_LINK : 0);
		}
		
		public int GetSelectionLink()
		{
			return GetSelectionStyle(CFM_LINK, CFE_LINK);
		}


		private void SetSelectionStyle(UInt32 mask, UInt32 effect)
		{
			CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
			cf.cbSize = (UInt32)Marshal.SizeOf(cf);
			cf.dwMask = mask;
			cf.dwEffects = effect;

			IntPtr wpar = new IntPtr(SCF_SELECTION);
			IntPtr lpar = Marshal.AllocCoTaskMem( Marshal.SizeOf( cf ) ); 
			Marshal.StructureToPtr(cf, lpar, false);

			IntPtr res = SendMessage(Handle, EM_SETCHARFORMAT, wpar, lpar);

			Marshal.FreeCoTaskMem(lpar);
		}

		private int GetSelectionStyle(UInt32 mask, UInt32 effect)
		{
			CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
			cf.cbSize = (UInt32)Marshal.SizeOf(cf);
			cf.szFaceName = new char[32];

			IntPtr wpar = new IntPtr(SCF_SELECTION);
			IntPtr lpar = 	Marshal.AllocCoTaskMem( Marshal.SizeOf( cf ) ); 
			Marshal.StructureToPtr(cf, lpar, false);

			IntPtr res = SendMessage(Handle, EM_GETCHARFORMAT, wpar, lpar);

			cf = (CHARFORMAT2_STRUCT)Marshal.PtrToStructure(lpar, typeof(CHARFORMAT2_STRUCT));

			int state;
			
			if ((cf.dwMask & mask) == mask) 
			{
				if ((cf.dwEffects & effect) == effect)
					state = 1;
				else
					state = 0;
			}
			else
			{
				state = -1;
			}
			
			Marshal.FreeCoTaskMem(lpar);
			return state;
		}
    }
}
