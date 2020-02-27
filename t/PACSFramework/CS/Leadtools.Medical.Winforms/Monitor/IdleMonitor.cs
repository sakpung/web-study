// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;

namespace Leadtools.Medical.Winforms.Monitor
{
   public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

   public class IdleMonitor : IDisposable
   {
      [DllImport("user32.dll", CharSet = CharSet.Auto,CallingConvention = CallingConvention.StdCall, SetLastError=true)]
      public static extern int SetWindowsHookEx(int idHook, HookProc lpfn,IntPtr hInstance, int threadId);

      [DllImport("user32.dll", CharSet = CharSet.Auto,CallingConvention = CallingConvention.StdCall)]
      public static extern bool UnhookWindowsHookEx(int idHook);
      
      [DllImport("user32.dll", CharSet = CharSet.Auto,CallingConvention = CallingConvention.StdCall)]
      public static extern int CallNextHookEx(int idHook, int nCode,IntPtr wParam, IntPtr lParam); 

      #region Private Members     

      private System.Threading.Timer _IdleTimer;

      #endregion

      private int _Timeout = 60;
      private int _MouseHook = 0;
      private int _KeyboardHook = 0;
      private HookProc _MouseProc = null;
      private HookProc _KeyboardProc = null;
      private bool _Disposed = false;

      public const int WH_MOUSE = 7;
      public const int WH_KEYBOARD = 2;

      public int Timeout
      {
        get { return _Timeout; }
        set { _Timeout = value; }
      }

      private bool _Active = false;

      public bool Active
      {
         get { return _Active; }
         set 
         { 
            _Active = value;
            if (_IdleTimer != null)
            {
               if (!_Active)
               {
                  _IdleTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
               }
               else
               {
                  _IdleTimer.Change(Timeout * 1000, System.Threading.Timeout.Infinite);
               }
            }
         }
      }

      public event EventHandler IdleTimeout;

      protected void OnIdleTimeout()
      {
         if (IdleTimeout != null)
         {
            IdleTimeout(this, EventArgs.Empty);
         }
      }

      public IdleMonitor()
      {           
         _MouseProc = new HookProc(MouseHookProc);
         _KeyboardProc = new HookProc(KeyboardHookProc);
      }      

      public IdleMonitor(int timeout) : this()
      {
         _Timeout = timeout;
         _IdleTimer = new System.Threading.Timer(IdleTimer_Timeout);
      }

      public void Start()
      {
         ResetIdleTimer();
         _Active = true;
         _IdleTimer = new System.Threading.Timer(IdleTimer_Timeout);         
         _MouseHook = SetWindowsHookEx(WH_MOUSE, _MouseProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
         _KeyboardHook = SetWindowsHookEx(WH_KEYBOARD, _KeyboardProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
         _IdleTimer.Change(Timeout * 1000, System.Threading.Timeout.Infinite);
      }

      public void Stop()
      {
         if (_MouseHook != 0)
         {
            UnhookWindowsHookEx(_MouseHook);
            _MouseHook = 0;
         }

         if (_KeyboardHook != 0)
         {
            UnhookWindowsHookEx(_KeyboardHook);
            _KeyboardHook = 0;
         }
         _Active = false;         
      }

      private void ResetIdleTimer()
      {
         if (_IdleTimer != null)
         {
            _IdleTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            _IdleTimer.Dispose();
         }
      }

      private void IdleTimer_Timeout(object data)
      {
         _IdleTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
         try
         {
            OnIdleTimeout();
         }
         finally
         {
            if (!_Disposed)
            {
               _IdleTimer.Change(Timeout * 1000, System.Threading.Timeout.Infinite);
            }
         }
      }

      public int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
      {
         if (nCode < 0 || !_Active)
         {
            return CallNextHookEx(_MouseHook, nCode, wParam, lParam);
         }
         else
         {
            _IdleTimer.Change(Timeout * 1000, System.Threading.Timeout.Infinite);
            return CallNextHookEx(_MouseHook, nCode, wParam, lParam);
         }
      }

      public int KeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
      {
         if (nCode < 0 || !_Active)
         {
            return CallNextHookEx(_KeyboardHook, nCode, wParam, lParam);
         }
         else
         {
            _IdleTimer.Change(Timeout * 1000, System.Threading.Timeout.Infinite);
            return CallNextHookEx(_KeyboardHook, nCode, wParam, lParam);
         }
      }

      #region IDisposable Members

      public void Dispose()
      {
         _Disposed = true;
         if (_MouseHook != 0)
         {
            UnhookWindowsHookEx(_MouseHook);
            _MouseHook = 0;
         }

         if (_KeyboardHook != 0)
         {
            UnhookWindowsHookEx(_KeyboardHook);
            _KeyboardHook = 0;
         }

         if (_IdleTimer != null)
         {
            _IdleTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            _IdleTimer.Dispose();
         }
      }

      #endregion
   }

   public class BackgroundProcessEventAgs : EventArgs
   {
      public bool Starting { get; set; }

      public BackgroundProcessEventAgs(bool starting)
      {
         Starting = starting;
      }
   }
}
