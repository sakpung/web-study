// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Leadtools.Ccow;
using Leadtools.Ccow.Server.Context;

namespace Leadtools.Ccow.Dialogs
{
   public partial class ParticipantDialog : Form
   {
      public ParticipantDialog()
      {
         InitializeComponent();
         ContextManager.NewParticipant += new EventHandler<ParticipantEventArgs>(OnNewParticipant);
         ContextManager.ParticipantLeave += new EventHandler<ParticipantEventArgs>(OnParticipantLeave);
         ContextManager.ContextUpdated += new EventHandler<ContextUpdatedEventArgs>(OnContextUpdated);
         ContextManager.ParticipantStateChange += new EventHandler<ParticipantEventArgs>(OnParticipantStateChange);
         ContextManager.SecureBind += new EventHandler<ParticipantEventArgs>(OnSecureBind);
      }

      private void OnNewParticipant(object sender, ParticipantEventArgs e)
      {
         ListViewItem item = listViewParticipants.Items.Add(e.Participant.ApplicationName);

         item.SubItems.Add(e.Participant.ParticipantCoupon.ToString());
         item.SubItems.Add(e.Participant.Suspended ? "X" : string.Empty);
         item.SubItems.Add(e.Participant.Secure ? "X" : string.Empty);
         item.Tag = e.Participant;
      }

      private void OnParticipantLeave(object sender, ParticipantEventArgs e)
      {
         for (int i = 0; i < listViewParticipants.Items.Count; i++)
         {
            ListViewItem item = listViewParticipants.Items[i];

            if (item.Tag == e.Participant)
            {
               listViewParticipants.Items.Remove(item);
               break;
            }
         }

         if(listViewParticipants.Items.Count == 0)
            listViewContext.Items.Clear();
      }

      private void OnParticipantStateChange(object sender, ParticipantEventArgs e)
      {
         for (int i = 0; i < listViewParticipants.Items.Count; i++)
         {
            ListViewItem item = listViewParticipants.Items[i];

            if (item.Tag == e.Participant)
            {
               item.SubItems[2].Text = e.Participant.Suspended ? "X" : string.Empty;
               break;
            }
         }
      }

      private void OnContextUpdated(object sender, ContextUpdatedEventArgs e)
      {
         listViewContext.Items.Clear();
         foreach (ContextItem c in e.Context)
         {
            ListViewItem item = listViewContext.Items.Add(c.ToString());

            item.SubItems.Add(c.Value.ToString());
            item.Tag = c;
         }
      }

      private void OnSecureBind(object sender, ParticipantEventArgs e)
      {
         for (int i = 0; i < listViewParticipants.Items.Count; i++)
         {
            ListViewItem item = listViewParticipants.Items[i];

            if (item.Tag == e.Participant)
            {
               item.SubItems[3].Text = e.Participant.Secure ? "X" : string.Empty;
               break;
            }
         }
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         Hide();
      }

      private void ParticipantDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (e.CloseReason == CloseReason.UserClosing)
         {
            e.Cancel = true;
            Hide();
         }
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         base.OnFormClosing(e);
      }

      private void ParticipantDialog_Load(object sender, EventArgs e)
      {
         listViewContext.Columns[0].Width = listViewContext.ClientRectangle.Width / 2;
         listViewContext.Columns[1].Width = listViewContext.ClientRectangle.Width / 2;

         listViewParticipants.Columns[0].Width = Convert.ToInt32(listViewParticipants.ClientRectangle.Width * 0.50);
         listViewParticipants.Columns[1].Width = Convert.ToInt32(listViewParticipants.ClientRectangle.Width * 0.16);
         listViewParticipants.Columns[2].Width = Convert.ToInt32(listViewParticipants.ClientRectangle.Width * 0.16);
         listViewParticipants.Columns[3].Width = Convert.ToInt32(listViewParticipants.ClientRectangle.Width * 0.16);
      }

      private void ParticipantDialog_VisibleChanged(object sender, EventArgs e)
      {
         if (Visible)
         {
            try
            {
               foreach (ListViewItem item in listViewParticipants.Items)
               {
                  ContextParticipant participant = item.Tag as ContextParticipant;

                  if (participant != null)
                  {
                     item.SubItems[2].Text = participant.Suspended ? "X" : string.Empty;
                  }
               }
            }
            catch { }
         }
      }
   }
}
