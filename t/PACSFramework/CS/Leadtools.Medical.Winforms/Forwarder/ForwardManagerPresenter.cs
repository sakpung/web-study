// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom.AddIn.Configuration;
using System.Reflection;
using Leadtools.Logging;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Leadtools.Medical.AeManagement.DataAccessLayer;

namespace Leadtools.Medical.Winforms.Forwarder
{
   public class ForwardManagerPresenter
   {
      private ForwardManagerConfigurationView _View;

      public ForwardManagerConfigurationView View
      {
         get { return _View; }         
      }

      private IAeManagementDataAccessAgent _AccessAgent;
      private AdvancedSettings _Settings;
      private ForwardOptions _Options;

      public const string _addinName = "Forwarder";
      public const string _customDataName = "ForwardOptions";

      public event EventHandler<ForwardMessageEventArgs> Forward;

      protected void OnForward(ForwardMessageEventArgs  e)
      {
         if (Forward != null)
         {            
            Forward(this, e);
         }
      }
#if LEADTOOLS_V18_OR_LATER
      public event EventHandler<EventArgs> CancelForward;

      public event EventHandler<EventArgs> CancelClean;

      protected void OnCancelForward(EventArgs e)
      {
         if (CancelForward != null)
         {
            CancelForward(this, e);
         }
      }

      protected void OnCancelClean(EventArgs e)
      {
         if (CancelClean != null)
         {
            CancelClean(this, e);
         }
      }
#endif // #if LEADTOOLS_V18_OR_LATER

      public event EventHandler<SendMessageEventArgs> Clean;

      protected void OnClean()
      {
         if (Clean != null)
         {
            SendMessageEventArgs e = new SendMessageEventArgs(ForwarderMessage.Clean);

            Clean(this, e);
         }
      }

      public event EventHandler<ResetEventArgs> Reset;

      protected void OnReset(DateTime start, DateTime? end)
      {
         if (Reset != null)
         {
            ResetEventArgs e = new ResetEventArgs(ForwarderMessage.Reset, start, end);

            Reset(this, e);
         }
      }

      public void RunView(ForwardManagerConfigurationView view, AdvancedSettings settings)
      {
         ForwardOptions clonedOptions;

         _View = view;
         _Settings = settings;
         
         if (!DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent>())
         {
            throw new InvalidOperationException(typeof(IAeManagementDataAccessAgent).Name + " is not registered.");
         }

         _AccessAgent = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent>();

         if (settings != null)
         {
            try
            {
               _Options = _Settings.GetAddInCustomData<ForwardOptions>(_addinName, _customDataName);
               if (_Options == null)
               {
                  _Options = new ForwardOptions();
                  _Settings.SetAddInCustomData<ForwardOptions>(_addinName, _customDataName, _Options);
                  _Settings.Save();
               }
            }
            catch (Exception e)
            {
               Logger.Global.Exception("Forwarder", e);
               if (_Options == null)
                  _Options = new ForwardOptions();
            }

            clonedOptions = Clone(_Options);
            _View.Initialize(clonedOptions);
            _View.Enabled = false;
         }
         _View.SetAeTitles(_AccessAgent.GetAeTitles());

         _View.Forward += new EventHandler<ForwardMessageEventArgs>(View_Forward);
         _View.Clean += new EventHandler<SendMessageEventArgs>(View_Clean);
         _View.Reset += new EventHandler<ResetEventArgs>(View_Reset);
         _View.SettingsChanged += new EventHandler(View_SettingsChanged);

#if LEADTOOLS_V18_OR_LATER
         _View.CancelForward +=new EventHandler<EventArgs>(View_CancelForward);
         _View.CancelClean +=new EventHandler<EventArgs>(View_CancelClean);
#endif // #if LEADTOOLS_V18_OR_LATER
         EventBroker.Instance.Subscribe<ClientAddedEventArgs>(new EventHandler<ClientAddedEventArgs>(OnClientAdded));
         EventBroker.Instance.Subscribe<ClientRemovedEventArgs>(new EventHandler<ClientRemovedEventArgs>(OnClientRemoved));
         EventBroker.Instance.Subscribe<ClientUpdatedEventArgs>(new EventHandler<ClientUpdatedEventArgs>(OnClientUpdated));
      }

      public event EventHandler SettingsChanged;

      private void View_SettingsChanged(object sender, EventArgs e)
     {
         try
         {
            if (SettingsChanged != null)
            {
               SettingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      public void UpdateSettings(AdvancedSettings settings)
      {
         ForwardOptions clonedOptions;

         _Settings = settings;

         try
         {
            _Options = _Settings.GetAddInCustomData<ForwardOptions>(_addinName, _customDataName);
            if (_Options == null)
            {
               _Options = new ForwardOptions();
               _Settings.SetAddInCustomData<ForwardOptions>(_addinName, _customDataName, _Options);
               _Settings.Save();
            }
         }
         catch (Exception e)
         {
            Logger.Global.Exception("Forwarder", e);
            if (_Options == null)
               _Options = new ForwardOptions();
         }

         clonedOptions = Clone(_Options);
         _View.Initialize(clonedOptions);
         _View.Enabled = true;

         if(_AccessAgent == null)
            _AccessAgent = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent>();

         _View.SetAeTitles(_AccessAgent.GetAeTitles());
      }

      void View_Forward(object sender, ForwardMessageEventArgs e)
      {
         OnForward(e);
      }

#if LEADTOOLS_V18_OR_LATER
      void View_CancelForward(object sender, EventArgs e)
      {
         OnCancelForward(e);
      }

      void View_CancelClean(object sender, EventArgs e)
      {
         OnCancelClean(e);
      }
#endif // #if LEADTOOLS_V18_OR_LATER
      void View_Clean(object sender, SendMessageEventArgs e)
      {
         OnClean();
      }

      void View_Reset(object sender, ResetEventArgs e)
      {
         OnReset(e.Start, e.End);
      } 

      public void SaveOptions()
      {        
         _View.UpdateSettings();
         if (_Settings != null)
         {
            _Settings.SetAddInCustomData<ForwardOptions>(_addinName, _customDataName, _View.Options);
            _Settings.Save();
         }
         _Options = _View.Options;
      }

      public void CancelOptions()
      {
         _View.Initialize(Clone(_Options));
      }

      public void EnableTools(bool enable)
      {
         _View.EnableTools = enable;
      }

      public ForwardOptions Clone(ForwardOptions options)
      {
         //
         // Don't serialize a null object, simply return the default for that object
         //
         if (Object.ReferenceEquals(options, null))
         {
            return null;
         }

         if (!options.GetType().IsSerializable)
         {
            throw new ArgumentException("The type must be serializable.", "source");
         }

         IFormatter formatter = new BinaryFormatter();
         Stream stream = new MemoryStream();

         using (stream)
         {
            formatter.Serialize(stream, options);
            stream.Seek(0, SeekOrigin.Begin);

            return (ForwardOptions)formatter.Deserialize(stream);
         }        
      }

      private void OnClientAdded(object sender, ClientAddedEventArgs e)
      {
         View.AddAeTitle(e.NewClient);
      }

      private void OnClientRemoved(object sender, ClientRemovedEventArgs e)
      {
         View.RemoveClient(e.Ae);
      }

      private void OnClientUpdated(object sender, ClientUpdatedEventArgs e)
      {
         View.UpdateClient(e.OldAe, e.Client);
      }
   }
}
