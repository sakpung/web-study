// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using MS.WindowsAPICodePack.Internal;
using System.Diagnostics;

namespace DicomDemo.Utils
{
    public static class TaskDialogHelper
    {
        public const string APPLICATION_TITLE = "LEADTOOLS High Level DICOM Patient Updater Demo";

        /// <summary>
        /// Display "Vista-style" Task Dialog or fallback MessageBox() on pre-Vista machines.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="dialogTitle"></param>
        /// <param name="instruction"></param>
        /// <param name="body"></param>
        /// <param name="footer"></param>
        /// <param name="buttons"></param>
        /// <param name="mainIcon"></param>
        /// <param name="footerIcon"></param>
        /// <returns></returns>
        public static TaskDialogResult ShowMessageBox(IWin32Window owner,
                                                 string dialogTitle,
                                                 string instruction,
                                                 string body,
                                                 string footer,
                                                 TaskDialogStandardButtons buttons,
                                                 TaskDialogStandardIcon mainIcon,
                                                 TaskDialogStandardIcon? footerIcon)
        {
            TaskDialogResult result = TaskDialogResult.Ok;
            if (CoreHelpers.RunningOnVista) // or greater
            {
                var dialog = new TaskDialog();

                dialog.Cancelable = true;
                dialog.Caption = dialogTitle;
                if (footerIcon.HasValue)
                    dialog.FooterIcon = footerIcon.Value;
                dialog.FooterText = footer;
                dialog.HyperlinksEnabled = true;
                dialog.HyperlinkClick += new EventHandler<TaskDialogHyperlinkClickedEventArgs>(dialog_HyperlinkClick);
                dialog.Icon = mainIcon;
                dialog.InstructionText = instruction;
                dialog.StandardButtons = buttons;
                dialog.Text = body;
                dialog.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandContent;
                dialog.StartupLocation = TaskDialogStartupLocation.CenterOwner;
                if (owner != null)
                    dialog.OwnerWindowHandle = owner.Handle;

                return dialog.Show();
            }

            // XP or less
            MessageBoxButtons stdButtons = MessageBoxButtons.OK;
            if ((buttons &
                (TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No)) ==
                (TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No))
                stdButtons = MessageBoxButtons.YesNo;
            else if ((buttons &
                (TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No | TaskDialogStandardButtons.Cancel)) ==
                (TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No | TaskDialogStandardButtons.Cancel))
                stdButtons = MessageBoxButtons.YesNoCancel;
            else if ((buttons &
                (TaskDialogStandardButtons.Ok | TaskDialogStandardButtons.Cancel)) ==
                (TaskDialogStandardButtons.Ok | TaskDialogStandardButtons.Cancel))
                stdButtons = MessageBoxButtons.OKCancel;
            else if ((buttons &
                (TaskDialogStandardButtons.Ok | TaskDialogStandardButtons.Close)) ==
                (TaskDialogStandardButtons.Ok | TaskDialogStandardButtons.Close))
                stdButtons = MessageBoxButtons.OK;
            else if ((buttons &
                (TaskDialogStandardButtons.Retry | TaskDialogStandardButtons.Cancel)) ==
                (TaskDialogStandardButtons.Retry | TaskDialogStandardButtons.Cancel))
                stdButtons = MessageBoxButtons.RetryCancel;

            MessageBoxIcon stdIcon = MessageBoxIcon.None;

            if (mainIcon == TaskDialogStandardIcon.Information)
                stdIcon = MessageBoxIcon.Information;
            else if (mainIcon == TaskDialogStandardIcon.Error)
                stdIcon = MessageBoxIcon.Error;
            else if (mainIcon == TaskDialogStandardIcon.Warning)
                stdIcon = MessageBoxIcon.Warning;
            else if (mainIcon == TaskDialogStandardIcon.None)
                stdIcon = MessageBoxIcon.None;

            DialogResult stdResult = MessageBox.Show(owner,
                instruction + Environment.NewLine + body,
                APPLICATION_TITLE + " - " + dialogTitle,
                stdButtons,
                stdIcon);

            if (stdResult == DialogResult.OK)
                result = TaskDialogResult.Ok;
            else if (stdResult == DialogResult.Yes)
                result = TaskDialogResult.Yes;
            else if (stdResult == DialogResult.No)
                result = TaskDialogResult.No;
            else if (stdResult == DialogResult.Cancel)
                result = TaskDialogResult.Cancel;
            else if (stdResult == DialogResult.Retry)
                result = TaskDialogResult.Retry;

            return result;
        }

        static void dialog_HyperlinkClick(object sender, TaskDialogHyperlinkClickedEventArgs e)
        {
            try
            {
                // Launch the application associated with http links
                Process.Start(e.LinkText);
            }
            catch (Exception)
            {
                ShowMessageBox(null, "Error", "Could not activate link",
                               "Could not activate hyperlink, if this is a URL, try visiting the website manually.",
                               null, TaskDialogStandardButtons.Ok, TaskDialogStandardIcon.Error, null);
            }
        }
    }
}
