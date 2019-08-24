using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class TextField : UserControl
    {
        public TextField()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public bool Active
        {
            get => Enabled == false && Visible == false;
            set => Enabled = Visible = value;
        }

        public event MouseEventHandler LabelMouseClick;
        public event EventHandler LabelMouseEnter;
        public event EventHandler LabelMouseLeave;

        public int Transparent = 150;
        public Color BackGroundColor = Color.Black;
        public int HOffset = 10;
        public int VOffset = 5;
        public Size SizeOffset = new Size(2, 2);

        private Font font = new Font((new Label()).Font.FontFamily, 14);

        private List<Label> Labels = new List<Label>();

        private Pen linePen = new Pen(Color.White, 1);

        public int Count => Labels.Count;

        public void Clear()
        {
            foreach (var item in Labels)
            {
                Controls.Remove(item);
            }
            Labels.Clear();
        }

        public int GetOptimalWidth()
        {
            int w = 0;
            foreach (var item in Labels)
            {
                if (item.Width > w)
                    w = item.Width;
            }
            return w + HOffset * 4;
        }

        public int GetOptimalHeight()
        {
            int h = 0;
            foreach (var item in Labels)
            {
                h += item.Height + VOffset;
            }
            if (Labels.Count > 0)
                h += VOffset;
            return h;
        }

        public void AddInteractLabels(params string[] textArray)
        {
            foreach (var text in textArray)
            {
                AddInteractLabel(text);
            }
        }

        public void AddInteractLabel(string text)
        {
            AddLabel(text, true);
        }

        public void AddLabels(params string[] TextArray)
        {
            foreach (var text in TextArray)
            {
                AddLabel(text);
            }
        }

        public void AddLabel(string text)
        {
            AddLabel(text, false);
        }

        public new void Update()
        {
            SizeChangedHandler(null, null);
        }

        private void AddLabel(string text, bool interactFlag)
        {
            Labels.Add(new Label());
            Labels[Labels.Count - 1].Text = text;
            Labels[Labels.Count - 1].Size = Labels[Labels.Count - 1].GetPreferredSize(new Size(Width - HOffset * 2, Height / 2));
            Labels[Labels.Count - 1].AutoSize = false;
            Labels[Labels.Count - 1].Width += SizeOffset.Width;
            Labels[Labels.Count - 1].Height += SizeOffset.Height;
            Labels[Labels.Count - 1].Left = Width / 2 - HOffset * 2 - Labels[Labels.Count - 1].Width / 2;
            Labels[Labels.Count - 1].Top = Labels.Count > 1 ? Labels[Labels.Count - 2].Top + Labels[Labels.Count - 2].Height + VOffset : VOffset;
            Labels[Labels.Count - 1].ForeColor = Color.White;
            Labels[Labels.Count - 1].Font = font;
            if (interactFlag)
            {
                Labels[Labels.Count - 1].MouseClick += LabelMouseClick;
                Labels[Labels.Count - 1].MouseEnter += LabelMouseEnter;
                Labels[Labels.Count - 1].MouseLeave += LabelMouseLeave;
            }
            Controls.Add(Labels[Labels.Count - 1]);
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            for (int i = 0; i < Labels.Count; i++)
            {
                Labels[i].Size = Labels[i].GetPreferredSize(new Size(Width - HOffset * 4, Height));
                Labels[i].Width += SizeOffset.Width;
                Labels[i].Height += SizeOffset.Height;
                Labels[i].Left = Width / 2 - Labels[i].Width / 2; ;
                Labels[i].Top = i == 0 ? VOffset : Labels[i - 1].Top + Labels[i - 1].Height + VOffset;
            }
        }

        private void TextField_Paint(object sender, PaintEventArgs e)
        {
            using (Brush brush = new SolidBrush(Color.FromArgb(Transparent, BackGroundColor)))
            {
                e.Graphics.FillRectangle(brush, 0, 0, Width, Height);
            }

            if (Count > 1)
            {
                for (int i = 0; i < Labels.Count; i++)
                {
                    if (i < Count - 1)
                        e.Graphics.DrawLine(linePen, HOffset, Labels[i].Top + Labels[i].Height + VOffset / 2, Width - HOffset, Labels[i].Top + Labels[i].Height + VOffset / 2);
                }
            }
        }
    }
}
