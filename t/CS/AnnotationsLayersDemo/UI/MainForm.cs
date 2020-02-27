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
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.WinForms;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Annotations.Engine;
using System.Xml;
using Leadtools.Annotations.Designers;
using Leadtools.Annotations.Rendering;

namespace AnnotationsLayersDemo
{
   public partial class MainForm : Form
   {
      LayerNode _containerNode = null;
      LayerContextMenu _layerContextMenu = new LayerContextMenu();
      private AnnAutomationManager _automationManager;
      AutomationManagerHelper _managerHelper = null;
      AutomationImageViewer _imageViewer = null;
      AnnAutomation _automation = null;

      public MainForm()
      {
         InitializeComponent();
         Text = "LEADTOOLS C# Annotations Layers Demo";
      }

      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         StartupMessageBox startupMsgBox = new StartupMessageBox("CSAnnotationsLayersDemo");
         if (startupMsgBox.ShowStartUpDialog)
            startupMsgBox.ShowDialog();

         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Document.ToString()), "Warning");
            return;
         }

         Application.EnableVisualStyles();
         Application.DoEvents();

         Application.Run(new MainForm());
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            _automationManager = AnnAutomationManager.Create(new AnnWinFormsRenderingEngine());

            _automationManager.RedactionRealizePassword = string.Empty;
            _automationManager.CreateDefaultObjects();

            _managerHelper = new AutomationManagerHelper(_automationManager);
            _managerHelper.CreateToolBar();
            FlipReverseText(_automationManager.RenderingEngine, true);

            _managerHelper.ToolBar.Dock = DockStyle.Right;
            _managerHelper.ToolBar.AutoSize = false;
            _managerHelper.ToolBar.Width = 100;
            _managerHelper.ToolBar.Appearance = ToolBarAppearance.Normal;
            this.Controls.Add(_managerHelper.ToolBar);
            _managerHelper.ToolBar.BringToFront();

            _imageViewer = new AutomationImageViewer();
            _imageViewer.KeyDown += new KeyEventHandler(_imageViewer_KeyDown);
            _imageViewer.Dock = DockStyle.Fill;
            this.Controls.Add(_imageViewer);
            _imageViewer.BringToFront();

            AutomationInteractiveMode automationInteractiveMode = new AutomationInteractiveMode();
            automationInteractiveMode.MouseButtons = MouseButtons.Left | MouseButtons.Right;
            _imageViewer.InteractiveModes.Add(automationInteractiveMode);

            _imageViewer.UseDpi = false;

            _imageViewer.Zoom(Leadtools.Controls.ControlSizeMode.FitWidth, 1, LeadPoint.Empty);
            _imageViewer.ImageHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
            _imageViewer.ImageBorderColor = Color.Black;
            _imageViewer.BorderStyle = BorderStyle.Fixed3D;
            _imageViewer.ImageBorderThickness = 1;

            using (RasterCodecs codec = new RasterCodecs())
            {
               _imageViewer.Image = codec.Load(DemosGlobal.ImagesFolder + @"\ocr1.tif");
               _imageViewer.AutomationDataProvider = new RasterImageAutomationDataProvider(_imageViewer.Image);
            }

            _automation = new AnnAutomation(_automationManager, _imageViewer);

            // Update the container size
            _automation.Container.Size = _automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(_imageViewer.Image.ImageWidth, _imageViewer.Image.ImageHeight));

            _automation.EditText += new EventHandler<AnnEditTextEventArgs>(automation_EditText);
            _automation.OnShowContextMenu += new EventHandler<AnnAutomationEventArgs>(automation_OnShowContextMenu);
            _automation.OnShowObjectProperties += new EventHandler<AnnAutomationEventArgs>(automation_OnShowObjectProperties);
            _automation.LockObject += new EventHandler<AnnLockObjectEventArgs>(automation_LockObject);
            _automation.UnlockObject += new EventHandler<AnnLockObjectEventArgs>(automation_UnlockObject);
            _automation.SetCursor += new EventHandler<AnnCursorEventArgs>(automation_SetCursor);
            _automation.RestoreCursor += new EventHandler(automation_RestoreCursor);

            _automation.Active = true;

            _tvLayers.BeginUpdate();
            _tvLayers.HideSelection = false;
            AnnLayer layer = AnnLayer.Create("Container");
            AnnObjectCollection children = _automation.Container.Children;
            foreach (AnnObject annObject in children)
            {
               layer.Children.Add(annObject);
            }

            _containerNode = new LayerNode(layer, null, false);
            _containerNode.Tag = "Container";

            _tvLayers.Nodes.Add(_containerNode);
            _tvLayers.EndUpdate();
            CreateDefaultLayers();
            OnResize(EventArgs.Empty);
         }

         base.OnLoad(e);
      }

      void FlipReverseText(AnnRenderingEngine engine, bool enable)
      {
         foreach (AnnObjectRenderer renderer in engine.Renderers.Values)
         {
            AnnTextObjectRenderer annTextObjectRenderer = renderer as AnnTextObjectRenderer;
            if (annTextObjectRenderer != null)
            {
               annTextObjectRenderer.FlipReverseText = enable;
            }
         }
      }

      void automation_EditText(object sender, AnnEditTextEventArgs e)
      {
         TextBox text = new TextBox();
         Rectangle rc = new Rectangle((int)e.Bounds.Left, (int)e.Bounds.Top, (int)e.Bounds.Width, (int)e.Bounds.Height);
         rc.Inflate(12, 12);
         text.Location = rc.Location;
         text.Size = rc.Size;
         text.AutoSize = false;
         text.Tag = e.TextObject;
         text.Text = e.TextObject.Text;
         text.ForeColor = Color.FromName((e.TextObject.TextForeground as AnnSolidColorBrush).Color);
         text.Font = AnnWinFormsRenderingEngine.ToFont(e.TextObject.Font);
         text.WordWrap = false;
         text.AcceptsReturn = true;
         text.Multiline = true;
         text.Tag = e.TextObject;

         text.LostFocus += new EventHandler(text_LostFocus);
         _imageViewer.Controls.Add(text);
         text.Focus();
         text.SelectAll();
      }

      void RemoveText()
      {
         if (_imageViewer != null && _imageViewer.Controls != null)
         {
            foreach (Control control in _imageViewer.Controls)
            {
               if (control is TextBox)
               {
                  AnnTextObject textObject = control.Tag as AnnTextObject;
                  if (textObject != null)
                  {
                     textObject.Text = control.Text;
                  }

                  control.LostFocus -= new EventHandler(text_LostFocus);
                  _imageViewer.Controls.Remove(control);
               }
            }
         }
      }

      void text_LostFocus(object sender, EventArgs e)
      {
         RemoveText();
      }

      void _viewer_TransformChanged(object sender, EventArgs e)
      {
         RemoveText();
      }

      static AnnHiliteObject CreateHilite(LeadRectD rect)
      {
         AnnHiliteObject annHiliteObject = new AnnHiliteObject();
         annHiliteObject.Rect = rect;

         return annHiliteObject;
      }

      AnnRectangleObject CreateRectangle(LeadRectD rect, AnnBrush brush, AnnLayer layer)
      {
         AnnRectangleObject annRectObject = new AnnRectangleObject();
         annRectObject.Rect = rect;
         annRectObject.Fill = brush;
         annRectObject.Stroke.Stroke = AnnSolidColorBrush.Create("yellow");
         _automation.Container.Children.Add(annRectObject);
         layer.Children.Add(annRectObject);

         return annRectObject;
      }

      AnnLayer CreateLayer(string layerName)
      {
         AnnLayer layer = AnnLayer.Create(layerName);
         _automation.Container.Layers.Add(layer);
         _containerNode.Nodes.Add(new LayerNode(layer, _layerContextMenu));

         return layer;
      }

      void CreateDefaultLayers()
      {
         string[] layers = new string[] { "Red", "Green", "Blue" };

         LeadRectD rect = new LeadRectD(LeadPointD.Create(860, 700), LeadPointD.Create(5200, 1850));
         foreach (string layer in layers)
         {
            CreateRectangle(rect, AnnSolidColorBrush.Create(layer), CreateLayer(string.Format("{0} Layer", layer)));
            rect.Offset(360, 360);
         }
      }

      void _imageViewer_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Delete)
         {
            if (_automation != null)
            {
               _automation.DeleteSelectedObjects();
            }
         }
      }

      public LayerNode GetSelectedNode()
      {
         return _tvLayers.SelectedNode as LayerNode;
      }

      protected override void OnResize(EventArgs e)
      {
         RemoveText();
         base.OnResize(e);
      }

      void automation_SetCursor(object sender, AnnCursorEventArgs e)
      {
         Cursor newCursor = null;

         switch (e.DesignerType)
         {
            case AnnDesignerType.Draw:
               {
                  AnnAutomationObject annAutomationObject = _automationManager.FindObjectById(e.Id);
                  if (annAutomationObject != null && annAutomationObject.UserData != null)
                  {
                     newCursor = annAutomationObject.DrawCursor as Cursor;
                  }
               }
               break;

            case AnnDesignerType.Edit:
               {
                  if (e.IsRotateCenter)
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.RotateCenterControlPoint];
                  else if (e.IsRotateGripper)
                  {
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.RotateGripperControlPoint];
                  }
                  else if (e.ThumbIndex < 0)
                  {
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.SelectedObject];
                  }
                  else
                  {
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.ControlPoint];
                  }

               }
               break;

            case AnnDesignerType.Run:
               {
                  newCursor = AutomationManagerHelper.AutomationCursors[CursorType.Run];
               }
               break;

            default:
               newCursor = AutomationManagerHelper.AutomationCursors[CursorType.SelectObject];
               break;

         }

         if (_imageViewer.Cursor != newCursor)
            _imageViewer.Cursor = newCursor;
      }

      void automation_RestoreCursor(object sender, EventArgs e)
      {
         if (_imageViewer.Cursor != Cursors.Default)
            _imageViewer.Cursor = Cursors.Default;
      }

      void automation_OnShowContextMenu(object sender, AnnAutomationEventArgs e)
      {
         AnnObject annEditObject = _automation.CurrentEditObject;
         if (e != null)
         {
            AnnAutomationObject annAutomationObject = e.Object;
            if (annAutomationObject != null)
            {
               _imageViewer.AutomationInvalidate(LeadRectD.Empty);

               ContextMenu contextMenu = annAutomationObject.ContextMenu as ContextMenu;
               if (annAutomationObject != null && contextMenu != null)
               {
                  ObjectContextMenu menu = annAutomationObject.ContextMenu as ObjectContextMenu;
                  AnnLayer layer = annEditObject.Layer;
                  if (menu != null)
                  {
                     if (layer != null && !layer.IsVisible)
                        return;

                     menu.Automation = sender as AnnAutomation;
                     contextMenu.Show(this, _imageViewer.PointToClient(Cursor.Position));
                  }
               }
            }
         }
         else
         {
            ManagerContextMenu defaultMenu = new ManagerContextMenu();
            defaultMenu.Automation = sender as AnnAutomation;
            defaultMenu.Show(this, _imageViewer.PointToClient(Cursor.Position));
         }
      }

      void automation_OnShowObjectProperties(object sender, AnnAutomationEventArgs e)
      {
         using (var dlg = new AutomationUpdateObjectDialog())
         {
            var automation = _automation;

            if (automation.CurrentEditObject != null)
            {
               // If text, hide the note
               if (automation.CurrentEditObject.Id == AnnObject.TextObjectId)
               {
                  // if text object, we cannot do that. Ignore, the EditText will fire
                  dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Content, false);
               }
            }

            dlg.Automation = automation;

            try
            {
               dlg.ShowDialog(this);
               e.Cancel = !dlg.IsModified;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }
      }

      void automation_UnlockObject(object sender, AnnLockObjectEventArgs e)
      {
         AutomationPasswordDialog passwordDialog = new AutomationPasswordDialog();
         if (passwordDialog.ShowDialog(this) == DialogResult.OK)
         {
            e.Object.Unlock(passwordDialog.Password);
            if (e.Object.IsLocked)
            {
               MessageBox.Show("You've entered an invalid password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }
         else
            e.Cancel = true;
      }

      void automation_LockObject(object sender, AnnLockObjectEventArgs e)
      {
         AutomationPasswordDialog passwordDialog = new AutomationPasswordDialog();
         passwordDialog.Lock = true;
         if (passwordDialog.ShowDialog(this) == DialogResult.OK)
         {
            e.Object.Lock(passwordDialog.Password);
         }
         else
            e.Cancel = true;
      }

      private void _tvLayers_MouseUp(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            // Point where the mouse is clicked.
            Point point = new Point(e.X, e.Y);

            // Get the node that the user has clicked.
            LayerNode node = _tvLayers.GetNodeAt(point) as LayerNode;
            if (node != null)
            {
               _layerContextMenu.Attach(node, _automation);
               _layerContextMenu.Show(this, point);
            }
         }
      }

      private void _miSave_Click(object sender, EventArgs e)
      {
         using (SaveFileDialog saveFileDialog = new SaveFileDialog())
         {
            saveFileDialog.Filter = "Annotations File|*.xml";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
               AnnCodecs codecs = new AnnCodecs();
               codecs.Save(saveFileDialog.FileName, _automation.Container, AnnFormat.Annotations, 1);
            }
         }
      }

      private void _tvLayers_AfterCheck(object sender, TreeViewEventArgs e)
      {
         LayerNode node = e.Node as LayerNode;

         if (e.Action != TreeViewAction.Unknown && node != null)
         {
            if (node == _containerNode)
            {
               _automation.Container.IsVisible = node.Checked;
            }
            else
            {
               if (node.Layer != null)
               {
                  node.Layer.IsVisible = node.Checked;
               }
            }

            AnnEditDesigner editDesigner = _automation.CurrentDesigner as AnnEditDesigner;
            if (editDesigner != null)
            {
               editDesigner.End();
            }
            _automation.Invalidate(LeadRectD.Empty);
         }
      }

      private void _miLoad_Click(object sender, EventArgs e)
      {
         AnnContainer container = _automation.Container;
         AnnCodecs codecs = new AnnCodecs();

         using (OpenFileDialog openFileDialog = new OpenFileDialog())
         {
            openFileDialog.Filter = "Annotations File|*.xml";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
               AnnContainer tmpContainer = null;
               try
               {
                  tmpContainer = codecs.Load(openFileDialog.FileName, 1);
               }
               catch
               {
                  Messager.ShowError(this, "Invalid Annotation File");
               }

               if (tmpContainer != null)
               {
                  _automation.SelectLayer(null);
                  container.Children.Clear();
                  container.Layers.Clear();

                  container.SelectionObject.SelectedObjects.Clear();
                  foreach (AnnObject annObject in tmpContainer.Children)
                  {
                     container.Children.Add(annObject);
                  }

                  AnnLayerCollection tmpLayers = tmpContainer.Layers;
                  AnnLayerCollection containerLayers = _containerNode.Layer.Layers;
                  containerLayers.Clear();
                  foreach (AnnLayer layer in tmpLayers)
                  {
                     container.Layers.Add(layer);
                  }

                  _tvLayers.BeginUpdate();
                  _tvLayers.Nodes.Clear();
                  _containerNode.Nodes.Clear();
                  _tvLayers.Nodes.Add(_containerNode);
                  AddLayersNodes(container.Layers, _containerNode);
                  _tvLayers.EndUpdate();

                  _automation.Invalidate(LeadRectD.Empty);
               }
            }

         }
      }

      private void AddLayerNode(AnnLayer layer, LayerNode parent)
      {
         LayerNode layerNode = new LayerNode(layer, _layerContextMenu);
         parent.Nodes.Add(layerNode);
         AddLayersNodes(layer.Layers, layerNode);
      }

      private void AddLayersNodes(AnnLayerCollection layers, LayerNode parent)
      {
         if (layers != null && layers.Count > 0)
         {
            foreach (AnnLayer layer in layers)
            {
               AddLayerNode(layer, parent);
            }
         }
      }

      private void _tvLayers_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
      {
         LayerNode node = e.Node as LayerNode;

         if (node != null)
         {
            if (node != _containerNode)
               _automation.SelectLayer(node.Layer);
            else
               _automation.SelectLayer(null);
         }
      }

      private void _miHelpAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Annotations Layers", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void CleanUp(bool disposing)
      {
         if (disposing)
         {
            if (_imageViewer != null)
               _imageViewer.Dispose();

            if (_managerHelper != null)
               _managerHelper.Dispose();
         }
      }
   }
}
