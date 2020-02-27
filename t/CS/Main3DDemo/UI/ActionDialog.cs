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

using Leadtools.Medical3D;
using Leadtools.MedicalViewer;

namespace Main3DDemo
{
    public partial class ActionDialog : Form
    {
        #region // This method add a key list to the specified combo box
        public void AddKeysToCombo(ComboBox keyComboBox, Keys currentKey)
        {
            Keys[] keys =
         {
            Keys.None,
            Keys.Space,
            Keys.PageUp,
            Keys.PageDown,
            Keys.End,
            Keys.Home,
            Keys.Left,
            Keys.Up,
            Keys.Right,
            Keys.Down,
            Keys.PrintScreen,
            Keys.Insert,
            Keys.Delete,
            Keys.D0,
            Keys.D1,
            Keys.D2,
            Keys.D3,
            Keys.D4,
            Keys.D5,
            Keys.D6,
            Keys.D7,
            Keys.D8,
            Keys.D9,
            Keys.A,
            Keys.B,
            Keys.C,
            Keys.D,
            Keys.E,
            Keys.F,
            Keys.G,
            Keys.H,
            Keys.I,
            Keys.J,
            Keys.K,
            Keys.L,
            Keys.M,
            Keys.N,
            Keys.O,
            Keys.P,
            Keys.Q,
            Keys.R,
            Keys.S,
            Keys.T,
            Keys.U,
            Keys.V,
            Keys.W,
            Keys.X,
            Keys.Y,
            Keys.Z,
            Keys.NumPad0,
            Keys.NumPad1,
            Keys.NumPad2,
            Keys.NumPad3,
            Keys.NumPad4,
            Keys.NumPad5,
            Keys.NumPad6,
            Keys.NumPad7,
            Keys.NumPad8,
            Keys.NumPad9,
            Keys.Multiply,
            Keys.Add,
            Keys.Subtract,
            Keys.Decimal,
            Keys.F1,
            Keys.F2,
            Keys.F3,
            Keys.F4,
            Keys.F5,
            Keys.F6,
            Keys.F7,
            Keys.F8,
            Keys.F9,
            Keys.F10,
            Keys.F11,
            Keys.F12
         };

            foreach (Keys key in keys)
                keyComboBox.Items.Add(key);

            keyComboBox.SelectedIndex = keyComboBox.Items.IndexOf(currentKey);
        }
        #endregion

        private MedicalViewer _viewer;
        private Medical3DContainer container;
        private Medical3DActionType type;

        void SetModifier(ComboBox comboBox, Keys modifier)
        {
            switch(modifier)
            {
                case Keys.None:
                    comboBox.SelectedIndex = 0;
                    break;
                case Keys.Alt:
                    comboBox.SelectedIndex = 1;
                    break;
                case Keys.Shift:
                    comboBox.SelectedIndex = 2;
                    break;
                case Keys.Control:
                    comboBox.SelectedIndex = 3;
                    break;
            }
        }

        Keys GetModifier()
        {
            switch (_cmbModifier.SelectedIndex)
            {
                case 0:
                    return Keys.None;
                case 1:
                    return Keys.Alt;
                case 2:
                    return Keys.Shift;
                case 3:
                    return Keys.Control;
            }
            return Keys.None;
        }


        public ActionDialog()
        {
            InitializeComponent();
        }

       public ActionDialog(MedicalViewer viewer, Medical3DContainer Medical3DContainer, Medical3DActionType actionType)
        {
            InitializeComponent();
            _viewer = viewer;
            container = Medical3DContainer;
            type = actionType;

            switch(type)
            {
                case Medical3DActionType.MoveObject:
                    Text = "Move Object Action";
                    _cmbButton.SelectedIndex = (int)container.MoveObject.Button;
                    _textBoxSensitivity.Value =  (int)container.MoveObject.Sensitivity;
                    SetModifier(_cmbModifier, container.MoveObject.Modifier);
                    break;
                case Medical3DActionType.RotateObject:
                    Text = "Rotate Object Action";
                    _cmbButton.SelectedIndex = (int)container.RotateObject.Button;
                    _textBoxSensitivity.Value = (int)container.RotateObject.Sensitivity;
                    SetModifier(_cmbModifier, container.RotateObject.Modifier);
                    break;
                case Medical3DActionType.ScaleObject:
                    Text = "Scale Object Action";
                    _cmbButton.SelectedIndex = (int)container.ScaleObject.Button;
                    _textBoxSensitivity.Value = (int)container.ScaleObject.Sensitivity;
                    SetModifier(_cmbModifier, container.ScaleObject.Modifier);
                    break;
                case Medical3DActionType.MoveCamera:
                    Text = "Move Camera Action";
                    _cmbButton.SelectedIndex = (int)container.MoveCamera.Button;
                    _textBoxSensitivity.Value = (int)container.MoveCamera.Sensitivity;
                    SetModifier(_cmbModifier, container.MoveCamera.Modifier);
                    break;
                case Medical3DActionType.RotateCamera:
                    Text = "Rotate Camera Action";
                    _cmbButton.SelectedIndex = (int)container.RotateCamera.Button;
                    _textBoxSensitivity.Value = (int)container.RotateCamera.Sensitivity;
                    SetModifier(_cmbModifier, container.RotateCamera.Modifier);
                    break;
                case Medical3DActionType.ZoomCamera:
                    Text = "Zoom Camera Action";
                    _cmbButton.SelectedIndex = (int)container.ZoomCamera.Button;
                    _textBoxSensitivity.Value = (int)container.ZoomCamera.Sensitivity;
                    SetModifier(_cmbModifier, container.ZoomCamera.Modifier);
                    break;
                case Medical3DActionType.MovePlane:
                    Text = "Move Plane Action";
                    _cmbButton.SelectedIndex = (int)container.MovePlane.Button;
                    _textBoxSensitivity.Value = (int)container.MovePlane.Sensitivity;
                    SetModifier(_cmbModifier, container.MovePlane.Modifier);
                    break;
                case Medical3DActionType.RotatePlane:
                    Text = "Rotate Plane Action";
                    _cmbButton.SelectedIndex = (int)container.RotatePlane.Button;
                    _textBoxSensitivity.Value = (int)container.RotatePlane.Sensitivity;
                    SetModifier(_cmbModifier, container.RotatePlane.Modifier);
                    break;
                case Medical3DActionType.WindowLevel:
                    Text = "Window Level Action";
                    _cmbButton.SelectedIndex = (int)container.WindowLevel.Button;
                    _textBoxSensitivity.Value = (int)container.WindowLevel.Sensitivity;
                    SetModifier(_cmbModifier, container.WindowLevel.Modifier);
                    break;
            }
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case Medical3DActionType.MoveObject:
                    container.MoveObject.Set((Medical3DMouseButtons)_cmbButton.SelectedIndex, GetModifier());
                    container.MoveObject.Sensitivity = _textBoxSensitivity.Value;
                    break;
                case Medical3DActionType.RotateObject:
                    container.RotateObject.Set((Medical3DMouseButtons)_cmbButton.SelectedIndex, GetModifier());
                    container.RotateObject.Sensitivity = _textBoxSensitivity.Value;
                    break;
                case Medical3DActionType.ScaleObject:
                    container.ScaleObject.Set((Medical3DMouseButtons)_cmbButton.SelectedIndex, GetModifier());
                    container.ScaleObject.Sensitivity = _textBoxSensitivity.Value;
                    break;
                case Medical3DActionType.MoveCamera:
                    container.MoveCamera.Set((Medical3DMouseButtons)_cmbButton.SelectedIndex, GetModifier());
                    container.MoveCamera.Sensitivity = _textBoxSensitivity.Value;
                    break;
                case Medical3DActionType.RotateCamera:
                    container.RotateCamera.Set((Medical3DMouseButtons)_cmbButton.SelectedIndex, GetModifier());
                    container.RotateCamera.Sensitivity = _textBoxSensitivity.Value;
                    break;
                case Medical3DActionType.ZoomCamera:
                    container.ZoomCamera.Set((Medical3DMouseButtons)_cmbButton.SelectedIndex, GetModifier());
                    container.ZoomCamera.Sensitivity = _textBoxSensitivity.Value;
                    break;
                case Medical3DActionType.MovePlane:
                    container.MovePlane.Set((Medical3DMouseButtons)_cmbButton.SelectedIndex, GetModifier());
                    container.MovePlane.Sensitivity = _textBoxSensitivity.Value;
                    break;
                case Medical3DActionType.RotatePlane:
                    container.RotatePlane.Set((Medical3DMouseButtons)_cmbButton.SelectedIndex, GetModifier());
                    container.RotatePlane.Sensitivity = _textBoxSensitivity.Value;
                    break;
                case Medical3DActionType.WindowLevel:
                    container.WindowLevel.Set((Medical3DMouseButtons)_cmbButton.SelectedIndex, GetModifier());
                    container.WindowLevel.Sensitivity = _textBoxSensitivity.Value;
                    break;
            }
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
