// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Dicom.AddIn.Configuration;
using System.Reflection;
using Leadtools.Logging;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Attributes;
using Leadtools.Dicom.Common.Compare;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.Winforms.ExternalStore
{
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
   public class ExternalStorePresenter
   {
      public ExternalStorePresenter()
      {
         AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
      }

      private ExternalStoreAddinConfigAbstract[] _externalStoreAddinConfigArray;
      private List<Type> _extraTypeList = new List<Type>();

      private string _ServiceDirectory;
      public string ServiceDirectory
      {
         get { return _ServiceDirectory; }
         set
         {
            _ServiceDirectory = value;
            _extraTypeList.Clear();
            _extraTypeList.Add(typeof(Forwarder.Scheduling.Job));
            _externalStoreAddinConfigArray = LoadExternalStoreAddins(this.ServiceDirectory);
         }
      }

      public bool IsDirty
      {
         get
         {
            ExternalStoreOptions tempOptions = _View.UpdateSettings();
            CompareObjects compareObjects = new CompareObjects();
            compareObjects.ElementsToIgnore.Add("JobId");
            compareObjects.ElementsToIgnore.Add("SyncRoot");
            bool isEqual = compareObjects.Compare(tempOptions, _Options);
            
            return !isEqual;
         }
      }


      private ExternalStoreConfigurationView _View;

      public ExternalStoreConfigurationView View
      {
         get { return _View; }
      }

      private AdvancedSettings _Settings;
      private ExternalStoreOptions _Options;

      public const string _Name = "ExternalStore";

      public event EventHandler<ExternalStoreMessageEventArgs> ExternalStore;
      protected void OnExternalStore(ExternalStoreMessageEventArgs e)
      {
         if (ExternalStore != null)
         {
            ExternalStore(this, e);
         }
      }

      public event EventHandler<EventArgs> CancelExternalStore;
      protected void OnCancelExternalStore(EventArgs e)
      {
         if (CancelExternalStore != null)
         {
            CancelExternalStore(this, e);
         }
      }

      public event EventHandler<CleanMessageEventArgs> Clean;
      protected void OnClean(CleanMessageEventArgs e)
      {
         if (Clean != null)
         {
            Clean(this, e);
         }
      }

      public event EventHandler<ResetEventArgs> Reset;
      protected void OnReset(DateTime start, DateTime? end)
      {
         if (Reset != null)
         {
            ResetEventArgs e = new ResetEventArgs(ExternalStoreMessage.Reset, start, end);

            Reset(this, e);
         }
      }

      public event EventHandler<RestoreMessageEventArgs> Restore;
      protected void OnRestore(RestoreMessageEventArgs e)
      {
         if (Restore != null)
         {
            Restore(this, e);
         }
      }

      public event EventHandler<EventArgs> CancelRestore;
      protected void OnCancelRestore(EventArgs e)
      {
         if (CancelRestore != null)
         {
            CancelRestore(this, e);
         }
      }

      public void RunView(ExternalStoreConfigurationView view, AdvancedSettings settings)
      {
         _View = view;
         _Settings = settings;

         if (settings != null)
         {
            try
            {
               _Options = _Settings.GetAddInCustomData<ExternalStoreOptions>(_Name, "ExternalStoreOptions", _extraTypeList.ToArray());
               if (_Options == null)
               {
                  _Options = new ExternalStoreOptions();

                  foreach(ExternalStoreAddinConfigAbstract addinConfig in _externalStoreAddinConfigArray)
                  {
                     ExternalStoreItem item = new ExternalStoreItem();
                     item.ExternalStoreAddinConfig = addinConfig;  // Here you can serialize this yourself
                  }
                  _Settings.SetAddInCustomData<ExternalStoreOptions>(_Name, "ExternalStoreOptions", _Options, _extraTypeList.ToArray());
                  _Settings.Save();
               }
            }
            catch (Exception e)
            {
               Logger.Global.Exception("ExternalStore", e);
               if (_Options == null)
                  _Options = new ExternalStoreOptions();
            }

            ExternalStoreOptions tempOptions = Clone(_Options);

            _View.ExternalStoreAddins = _externalStoreAddinConfigArray;
            _View.Initialize(tempOptions, this.ServiceDirectory);
            _View.Enabled = false;
         }

         _View.ExternalStore += new EventHandler<ExternalStoreMessageEventArgs>(View_ExternalStore);
         _View.CancelExternalStore += new EventHandler<EventArgs>(_View_CancelExternalStore);
         _View.Clean += new EventHandler<CleanMessageEventArgs>(View_Clean);
         _View.Reset += new EventHandler<ResetEventArgs>(View_Reset);
         _View.Restore +=new EventHandler<RestoreMessageEventArgs>(View_Restore);
         _View.CancelRestore += new EventHandler<EventArgs>(_View_CancelRestore);
         _View.SettingsChanged += new EventHandler(View_SettingsChanged);
      }

      private Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
      {
         Assembly[] currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();

         for (int i = 0; i < currentAssemblies.Length; i++)
         {
            AssemblyName name = new AssemblyName(args.Name);

            if (currentAssemblies[i].GetName().Name == name.Name)
            {
               return currentAssemblies[i];
            }
         }

         // If assembly is still not found, check in 'Addins' folder
         if (!string.IsNullOrEmpty(_ServiceDirectory))
         {
            string temp = Path.Combine(_ServiceDirectory, "AddIns");
            string fullpath = Path.Combine(temp, args.Name) + ".dll";
            if (File.Exists(fullpath))
            {
               Assembly assembly = null;
               try
               {
                  assembly = Assembly.LoadFrom(fullpath);
               }
               catch (Exception ex)
               {
                  DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Exception (ExternalStorePresenter.MyResolveEventHandler): " + ex.Message);
               }
               return assembly;

            }
         }
         return null;
      }              

      private void UpdateExternalStoreCleanDelegates()
      {
         ExternalStoreAddinConfigAbstract addin = _View.GetSelectedExternalStoreAddin();
         if (addin != null)
         {
            // TODO update the delegates below
         }
      }

      //void ExternalStorePresenter_Clean(object sender, SendMessageEventArgs e)
      //{
      //   OnClean(
      //}

      //void ExternalStorePresenter_ExternalStore(object sender, ExternalStoreMessageEventArgs e)
      //{
      //   OnExternalStore(e);
      //}

      public event EventHandler SettingsChanged;

      private void View_SettingsChanged(object sender, EventArgs e)
      {
         try
         {
            UpdateExternalStoreCleanDelegates();
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
         _Settings = settings;

         try
         {
            _Options = _Settings.GetAddInCustomData<ExternalStoreOptions>(_Name, "ExternalStoreOptions", _extraTypeList.ToArray());
            if (_Options == null)
            {
               _Options = new ExternalStoreOptions();
               _Settings.SetAddInCustomData<ExternalStoreOptions>(_Name, "ExternalStoreOptions", _Options, _extraTypeList.ToArray());
               _Settings.Save();
            }
         }
         catch (Exception e)
         {
            Logger.Global.Exception("ExternalStore", e);
            if (_Options == null)
               _Options = new ExternalStoreOptions();
         }

         ExternalStoreOptions tempOptions = Clone(_Options);
         _View.ExternalStoreAddins = _externalStoreAddinConfigArray;
         _View.Initialize(tempOptions, ServiceDirectory);
         _View.Enabled = true;
      }

      void View_ExternalStore(object sender, ExternalStoreMessageEventArgs e)
      {
         OnExternalStore(e);
      }

      void _View_CancelExternalStore(object sender, EventArgs e)
      {
         OnCancelExternalStore(e);
      }

      void _View_CancelRestore(object sender, EventArgs e)
      {
         OnCancelRestore(e);
      }

      void View_Clean(object sender, CleanMessageEventArgs e)
      {
         OnClean(e);
      }

      void View_Reset(object sender, ResetEventArgs e)
      {
         OnReset(e.Start, e.End);
      }

      void View_Restore(object sender, RestoreMessageEventArgs e)
      {
         OnRestore(e);
      }

      public static void MyDumpExternalStoreOptions(string prefix, ExternalStoreOptions options)
      {
         ExternalStoreItem item = options.GetCurrentOption();

         if (item != null)
         {
            string s = string.Format("****** '{0}'  \n\tExternalStoreJob '{1}'\n\tCleanJob '{2}'", prefix, (item.ExternalStoreJob != null), (item.CleanJob != null));
            DicomUtilities.DebugString(DebugStringOptions.ShowCounter, s);
         }
      }

      public void SaveOptions()
      {
         _View.UpdateSettings();
         if (_Settings != null)
         {
            _Settings.SetAddInCustomData<ExternalStoreOptions>(_Name, "ExternalStoreOptions", _View.Options, _extraTypeList.ToArray());

            try
            {
               _Settings.Save();
               DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "ExternalStorePresenter::SaveOptions -- _Settings.Save()");
               MyDumpExternalStoreOptions("Saved Options", _View.Options);
            }
            catch (Exception ex)
            {
               DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "ExternalStorePresenter::SaveOptions -- Exception: " + ex.Message);
            }
         }
         _Options = Clone(_View.Options);
         MyDumpExternalStoreOptions("New Options", _Options);
      }

      public void CancelOptions()
      {
         _View.Initialize(Clone(_Options), ServiceDirectory);
      }

      public void EnableTools(bool enable)
      {
         _View.EnableTools = enable;
      }

      public ExternalStoreOptions Clone(ExternalStoreOptions options)
      {
         //
         // Don't serialize a null object, simply return the default for that object
         //
         if (ReferenceEquals(options, null))
         {
            return null;
         }

         if (!options.GetType().IsSerializable)
         {
            throw new ArgumentException(@"The type must be serializable.", "source");
         }

         IFormatter formatter = new BinaryFormatter();
         Stream stream = new MemoryStream();

         using (stream)
         {
            formatter.Serialize(stream, options);
            stream.Seek(0, SeekOrigin.Begin);

            return (ExternalStoreOptions)formatter.Deserialize(stream);
         }
      }

      private Type FileImplementsExternalStoreInterfaces(string fullPath)
      {
         try
         {
            Assembly assembly = Assembly.LoadFrom(fullPath);

            IEnumerable<Type> configurationAttributeTypes = GetTypesWithExternalStoreConfigurationAttribute(assembly);
            foreach (Type t in configurationAttributeTypes)
            {
               _extraTypeList.Add(t);
            }

            Type[] types = assembly.GetExportedTypes();
            Type interfaceCrud = null;
            Type abstractConfig = null;

            Type retType = null;
            foreach (Type t in types)
            {
               // ICrud, IExternalStoreAddinConfig
               if (interfaceCrud == null)
                  interfaceCrud = t.GetInterface("ICrud");

               if (abstractConfig == null)
               {
                  if (t.IsSubclassOf(typeof(ExternalStoreAddinConfigAbstract)))
                  {
                     abstractConfig = t;
                     retType = t;
                     _extraTypeList.Add(t);
                  }
               }
            }
            if (interfaceCrud != null && abstractConfig != null)
               return retType;
         }
         catch (Exception)
         {
            return null;
         }

         return null;
      }

      static IEnumerable<Type> GetTypesWithExternalStoreConfigurationAttribute(Assembly assembly)
      {
         foreach (Type type in assembly.GetTypes())
         {
            if (type.GetCustomAttributes(typeof(ExternalStoreConfigurationAttribute), true).Length > 0)
            {
               yield return type;
            }
         }
      }

      ExternalStoreAddinConfigAbstract[] LoadExternalStoreAddins(string serviceDirectory)
      {
         List<ExternalStoreAddinConfigAbstract> configurations = new List<ExternalStoreAddinConfigAbstract>();
         string addinsDirectory = Path.Combine(serviceDirectory, "Addins");

         string[] files = Directory.GetFiles(addinsDirectory, "*.dll", SearchOption.TopDirectoryOnly);
         foreach (string file in files)
         {
            string fullPath = Path.Combine(addinsDirectory, file);
            Type t = FileImplementsExternalStoreInterfaces(fullPath);
            if (t != null)
            {
               ExternalStoreAddinConfigAbstract externalStoreAddinConfig = Activator.CreateInstance(t) as ExternalStoreAddinConfigAbstract;

               if (externalStoreAddinConfig != null)
               {
                  configurations.Add(externalStoreAddinConfig);
               }
            }
         }
         return configurations.ToArray();
      }

   }
#endif // #if LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE
}

