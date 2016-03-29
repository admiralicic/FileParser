using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileParser.Controls
{
    public partial class CustomList : ListBox
    {
        public Color ItemColor { get; set; }

        private Collection<ItemColorOption> lineColors = new Collection<ItemColorOption>();

        [Category("Data")]
        [Description("Row colors depending on source")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Collection<ItemColorOption> LineColors
        {
            get { return lineColors; }
            set { lineColors = value; }
        }


        public CustomList()
        {
            base.DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (Items.Count == 0)
            {
                return;
            }
            Rectangle rect = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
            e.DrawBackground();

            DrawBackground(e, rect);
            DrawText(e, rect);

        }

        private void DrawBackground(DrawItemEventArgs e, Rectangle r)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;

                string text = GetText(e);

                Color backColor = e.BackColor;

                foreach (var item in LineColors)
                {
                    if (text.IndexOf(item.Filename) > 0)
                        backColor = item.LColor;
                }

                Rectangle rect = r;
                Brush brush = new SolidBrush(backColor);

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    g.FillRectangle(SystemBrushes.Highlight, rect);
                }
                else
                {
                    g.FillRectangle(brush, rect);
                }
            }
        }

        private void DrawText(DrawItemEventArgs e, Rectangle r)
        {
            if (e.Index >= 0)
            {
                string text = GetText(e);
                Brush fontColor = new SolidBrush(ForeColor);
                e.Graphics.DrawString(text, e.Font, fontColor, r);
            }

        }

        private string GetText(DrawItemEventArgs e)
        {
            string text = string.Empty;
            object selectedItem = null;
            selectedItem = this.Items[e.Index];
            text = GetItemText(selectedItem);
            return text;
        }


    }

    public class ItemColorOption
    {
        private string fileName;

        public string Filename
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private Color color;

        public Color LColor
        {
            get { return color; }
            set { color = value; }
        }


    }

}



