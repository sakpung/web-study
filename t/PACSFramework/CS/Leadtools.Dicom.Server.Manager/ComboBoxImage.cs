// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.ComponentModel.Design;

namespace Leadtools.Dicom.Server.Manager
{
    public class ComboBoxImage : ComboBox
    {
        private System.ComponentModel.Container components = null;

        public ComboBoxImage()
        {            
            base.DrawMode = DrawMode.OwnerDrawVariable;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (this.Items != null)
                {
                    foreach (Object o in this.Items)
                    {
                        if (o is ComboItemImage)
                        {
                            ComboItemImage item = o as ComboItemImage;

                            item.Image = null;
                        }
                    }
                }
            }
            base.Dispose(disposing);
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DrawMode DrawMode
        {
            get { return DrawMode.OwnerDrawFixed; }
        }

        [Editor(typeof(ImageComboItemEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ObjectCollection Items
        {
            get { return base.Items; }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index == -1 || e.Index > this.Items.Count - 1)
                return;

            e.DrawBackground();

            Rectangle imageRect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);
            RectangleF textRectF = RectangleF.FromLTRB(imageRect.Right + 2, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom);

            if (Items[e.Index] is ComboItemImage)
            {
                ComboItemImage Item = (ComboItemImage)Items[e.Index];

                if (Item.Image != null)
                    e.Graphics.DrawImage(Item.Image, imageRect);
            }

            SolidBrush TextBrush = new SolidBrush(this.ForeColor);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                TextBrush.Color = SystemColors.HighlightText;

            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);

            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.EllipsisCharacter;

            e.Graphics.DrawString(Items[e.Index].ToString(), this.Font, TextBrush, textRectF, sf);
            TextBrush.Dispose();

            base.OnDrawItem(e);
        }

        private int currentIndex = -1;

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (this.SelectedIndex != currentIndex)
            {
                currentIndex = this.SelectedIndex;
                base.RefreshItem(this.SelectedIndex);
            }
            else
            {
                base.OnSelectedIndexChanged(e);
            }
        }

        private class ImageComboItemEditor : CollectionEditor
        {
            public ImageComboItemEditor(Type type) : base(type) { }

            protected override Type CreateCollectionItemType()
            {
                return typeof(ComboItemImage);
            }
        }
    }

    [DesignTimeVisible(false)]
    public class ComboItemImage
    {
       private Object _item;
       private Image _image;
       private object _tag;

       public Object Item
       {
          get { return _item; }
          set { _item = value; }
       }

       public Image Image
       {
          get { return _image; }
          set { _image = value; }
       }

       public object Tag
       {
          get { return _tag; }
          set { _tag = value; }
       }

        [TypeConverter(typeof(StringConverter))]
        public override string ToString()
        {
            if (Item == null)
                return String.Empty;
            else
                return Item.ToString();
        }

        public ComboItemImage(object item)
        {
            Item = item;
        }
    }
}
