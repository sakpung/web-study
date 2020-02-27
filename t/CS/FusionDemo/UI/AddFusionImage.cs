// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

using Leadtools.MedicalViewer;
using Leadtools;
using System.Collections.Generic;

using Leadtools.Annotations.Engine;

namespace FusionDemo
{
    public partial class AddFusionImage : Form
    {
        MedicalViewer _viewer;
        MainForm _form;
        List<int> _weightList;
        List<String> _cellFusionPaths;
        List<RasterImage> _images;
        List<FusionData>[] _cellFusionNames;
        MedicalViewerMultiCell _cell = null;

        public AddFusionImage()
        {
            InitializeComponent();
        }

        public AddFusionImage(MedicalViewer viewer, MainForm form)
        {
            _viewer = viewer;
            _form = form;
            _weightList = new List<int>();
            _cellFusionPaths = new List<String>();
            _images = new List<RasterImage>();

            InitializeComponent();
            InitializeFusionList();
            UpdateUI();

            if (_listFusionImages.Items.Count != 0)
            {
                _listFusionImages.SelectedIndex = 0;
                UpdateText();
            }

            this.Shown += new EventHandler(AddFusionImage_Shown);
        }

        ~AddFusionImage()
        {
            this.Shown -= new EventHandler(AddFusionImage_Shown);
        }

        void AddFusionImage_Shown(object sender, EventArgs e)
        {
            _btnAdd.Focus();
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            if (ApplyFusion())
                this.Close();
        }

        private bool ApplyFusion()
        {
            if (GetTotalCount() > 100)
            {
                MessageBox.Show("the weight total for the fused images should not exceed 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {

                int cellIndex = _form.GetFirstSelectedMultiCellIndex();

                if (cellIndex == -1)
                    return false;

                MedicalViewerMultiCell cell = (MedicalViewerMultiCell)_viewer.Cells[cellIndex];
                if (cell == null)
                    return false;

                _cellFusionNames = _form.FusionListNames[cellIndex];

                int subCellIndex = cell.ActiveSubCell;

                if (_form.FusionListNames[cellIndex][subCellIndex] == null)
                    _form.FusionListNames[cellIndex][subCellIndex] = new List<FusionData>();



                int index = 0;

                _form.FusionListNames[cellIndex][subCellIndex].Clear();

                for (index = 0; index < _listFusionImages.Items.Count; index++)
                {
                    _form.FusionListNames[cellIndex][subCellIndex].Add(new FusionData(_cellFusionPaths[index], _listFusionImages.Items[index].ToString(), 0));
                }
            }

            return true;
        }

        private void InitializeFusionList()
        {
            int cellIndex = _form.GetFirstSelectedMultiCellIndex();

            if (cellIndex == -1)
                return;

            _cell = (MedicalViewerMultiCell)_viewer.Cells[cellIndex];
            if (_cell == null)
                return;

            _cellFusionNames = _form.FusionListNames[cellIndex];

            int subCellIndex = _cell.ActiveSubCell;

            if (_cellFusionNames[subCellIndex] == null)
                return;

            int index = 0;

            for (index = 0; index < _cellFusionNames[subCellIndex].Count; index++)
            {
                _listFusionImages.Items.Add(_cellFusionNames[subCellIndex][index].Name);
                _cellFusionPaths.Add(_cellFusionNames[subCellIndex][index].Filename);
                _weightList.Add((int)(_cell.SubCells[subCellIndex].Fusion[index].FusionScale * 100));
                _images.Add(_cell.SubCells[subCellIndex].Fusion[index].FusedImage);
            }
        }

        private void _btnApply_Click(object sender, EventArgs e)
        {
            ApplyFusion();
        }

        private void _btnAdd_Click(object sender, EventArgs e)
        {
            string seriesName;
            string seriesPath;
            RasterImage image = _form.LoadFusionDicom(out seriesName, out seriesPath, this);
            if (image == null)
                return;

            _listFusionImages.Items.Add(seriesName);
            _cellFusionPaths.Add(seriesPath);
            _weightList.Add(_listFusionImages.Items.Count == 1 ? 50 : /*GetFusionDefaultValue()*/0);

            int index = _listFusionImages.Items.Count - 1;

            MedicalViewerFusion fusion = new MedicalViewerFusion();
            fusion.FusedImage = image;
            fusion.FusionScale = _weightList[index] / 100.0f;


            RasterImage virtualImage = _cell.VirtualImage[_cell.ActiveSubCell].Image;

            float fitScaleX = virtualImage.Width * 1.0f / image.Width;
            float fitScaleY = virtualImage.Height * 1.0f / image.Height;

            fusion.DisplayRectangle = new RectangleF(0, 0, fitScaleX, fitScaleY);
            _images.Add(image);

            _cell.SubCells[_cell.ActiveSubCell].Fusion.Add(fusion);

            AddFusionEditRectangle(_cell.SubCells[_cell.ActiveSubCell]);

            _listFusionImages.SelectedIndex = index;

            UpdateText();
            UpdateUI();
        }

        private void AddFusionEditRectangle(MedicalViewerSubCell subCell)
        {
            AnnRectangleObject rect = new AnnRectangleObject();
            rect.IsVisible = false;
            rect.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), LeadLengthD.Create(5));
            subCell.AnnotationContainer.Children.Add(rect);
            //rect.RotateGripper = new LeadLengthD(1);

            _cell.AnnotationPrecedency = true;
        }

        private void UpdateUI()
        {
            _btnRemove.Enabled =
            _txtWeight.Enabled =
            _trackBarWeight.Enabled = _listFusionImages.Items.Count != 0;
        }

        private int GetTotalCount()
        {
            int count = 0;
            foreach (int weight in _weightList)
            {
                count += weight;
            }

            return count;

        }

        private int GetFusionDefaultValue()
        {
            double percentage = 0.0;
            double denominator = _listFusionImages.Items.Count + 1.0;

            double imagePercent = 100 - GetTotalCount();

            if (imagePercent < 0)
                return 0;

            percentage = imagePercent / denominator;

            foreach (int weight in _weightList)
            {
                percentage = percentage + (weight / denominator);
            }

            return (int)percentage;
        }

        private void _btnRemove_Click(object sender, EventArgs e)
        {
            int removeIndex = _listFusionImages.SelectedIndex;

            _cell.SubCells[_cell.ActiveSubCell].Fusion.RemoveAt(removeIndex);

            _listFusionImages.Items.RemoveAt(removeIndex);
            _cellFusionPaths.RemoveAt(removeIndex);
            _weightList.RemoveAt(removeIndex);
            _images[removeIndex].Dispose();
            _images.RemoveAt(removeIndex);

            RemoveFusionEditRectangle(_cell.SubCells[_cell.ActiveSubCell], removeIndex);


            if (_listFusionImages.Items.Count != 0)
            {
                _listFusionImages.SelectedIndex = Math.Min(_listFusionImages.Items.Count - 1, removeIndex);
            }

            UpdateUI();
            _form.CheckFusionTranslucencyAction(_viewer.Cells.IndexOf(_cell));
        }

        private void RemoveFusionEditRectangle(MedicalViewerSubCell subCell, int removeIndex)
        {
           if (subCell.AnnotationContainer.Children.Count != 0)
           {
              subCell.AnnotationContainer.Children.RemoveAt(removeIndex);
              _cell.RefreshAnnotation();
           }
        }

        private void _cmbSubCellIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void UpdateText()
        {
            _txtWeight.Text = _weightList[_listFusionImages.SelectedIndex].ToString();
            _trackBarWeight.Value = _weightList[_listFusionImages.SelectedIndex];
        }

        private void _listFusionImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listFusionImages.SelectedIndex != -1)
                UpdateText();
        }

        private void _txtWeight_TextChanged(object sender, EventArgs e)
        {
            int index = _listFusionImages.SelectedIndex;
            if (index == -1)
                return;

            int Num;
            bool isNum = int.TryParse(_txtWeight.Text, out Num);

            if (!isNum)
            {
                _txtWeight.Text = _weightList[index].ToString();
            }
            else
            {
                if (_txtWeight.Text == "")
                    _weightList[index] = 0;
                else
                    _weightList[index] = Math.Min(100, Convert.ToInt32(_txtWeight.Text));

                _trackBarWeight.Value = _weightList[index];
                _cell.SubCells[_cell.ActiveSubCell].Fusion[index].FusionScale = _weightList[index] / 100.0f;
                _cell.Invalidate();
            }

        }

        private void _trackBarWeight_Scroll(object sender, EventArgs e)
        {
            _txtWeight.Text = _trackBarWeight.Value.ToString();
        }
    }
}
