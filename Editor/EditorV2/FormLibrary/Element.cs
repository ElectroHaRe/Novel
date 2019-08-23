using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLibrary
{
    [Serializable]
    public partial class Element : UserControl
    {
        public Element()
        {
            InitializeComponent();
        }

        public Element(string text, Image image, Point location):this()
        {
            Text = text;
            Image = image;
            Location = location;
        }

        private const int MaxLabelWidth = 100;
        private const int MaxLabelHeight = 14;

        /// <summary>
        /// sender - pictureBox
        /// </summary>
        public event EventHandler ImageFieldClick
        {
            add { pictureBox.Click += value; }
            remove { pictureBox.Click -= value; }
        }
        /// <summary>
        /// sender - pictureBox
        /// </summary>
        public event MouseEventHandler ImageFieldMouseClick
        {
            add { pictureBox.MouseClick += value; }
            remove { pictureBox.MouseClick -= value; }
        }

        /// <summary>
        /// sender - TextBox
        /// </summary>
        public event EventHandler TextFieldClick
        {
            add { pictureBox.Click += value; }
            remove { pictureBox.Click -= value; }
        }
        /// <summary>
        /// sender - TextBox
        /// </summary>
        public event MouseEventHandler TextFieldMouseClick
        {
            add { pictureBox.MouseClick += value; }
            remove { pictureBox.MouseClick -= value; }
        }
        public event Action<PictureBox> ImageChanged;

        public event EventHandler ElementClick;
        public event MouseEventHandler ElementMouseClick;
        public event MouseEventHandler ElementMouseUp;
        public event MouseEventHandler ElementMouseDown;

        /// <summary>
        /// sender - Element
        /// </summary>
        public new event EventHandler TextChanged;
        /// <summary>
        /// sender - Element
        /// </summary>
        public event EventHandler Changed;

        public bool ReadOnly
        {
            get => textBox.ReadOnly;
            set => textBox.ReadOnly = value;
        }

        public Dictionary<Element, string> ties { get; private set; } = new Dictionary<Element, string>();

        public Image Image
        {
            get => pictureBox.Image;
            set
            {
                pictureBox.Image = value;
                if (value == null)
                    NullImageLabel.Enabled = NullImageLabel.Visible = true;
                else NullImageLabel.Enabled = NullImageLabel.Visible = false;
                ImageChanged?.Invoke(pictureBox);
                Changed?.Invoke(this, new EventArgs());
            }
        }
        public new string Text
        {
            get => textBox.Text;
            set
            {
                textBox.Text = value;
                TextChanged?.Invoke(textBox, new EventArgs());
                Changed?.Invoke(this, new EventArgs());
            }
        }

        public void AddTie(Element item, string text)
        {
            ties[item] = text;
        }

        public void RemoveTie(Element item)
        {
            ties.Remove(item);
        }

        public Point[] GetTieCoords()
        {
            Point[] temp = new Point[ties.Count];
            Element[] items = ties.Keys.ToArray();
            for (int i = 0; i < items.Length; i++)
            {
                temp[i] = items[i].Location;
            }
            return temp;
        }

        private void ElementClickHendler(object sender, EventArgs e)
        {
            ElementClick?.Invoke(this, e);
        }

        private void ElementMouseClickHendler(object sender, MouseEventArgs e)
        {
            ElementMouseClick?.Invoke(this, e);
        }

        private void ElementMouseUpHendler(object sender, MouseEventArgs e)
        {
            ElementMouseUp?.Invoke(this, e);
        }

        private void ElementMouseDownHendler(object sender, MouseEventArgs e)
        {
            ElementMouseDown?.Invoke(this, e);
        }

        private void TextChangedHendler(object sender, EventArgs e)
        {
            TextChanged?.Invoke(this, e);
            Changed?.Invoke(this, e);
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            pictureBox.Left = 0; pictureBox.Top = 0;
            pictureBox.Width = Width;
            pictureBox.Height = Height / 2;


            textBox.Left = -1; textBox.Top = pictureBox.Height;
            textBox.Width = Width + 1;
            textBox.Height = Height - pictureBox.Height;

            if (Width < MaxLabelWidth)
                NullImageLabel.Width = Width;
            else NullImageLabel.Width = MaxLabelWidth;
            if (Height / 2 < MaxLabelHeight)
                NullImageLabel.Height = 0;
            else NullImageLabel.Height = MaxLabelHeight;

            NullImageLabel.Left = Width / 2 - NullImageLabel.Width / 2;
            NullImageLabel.Top = Height / 4 - NullImageLabel.Height / 2;
        }
    }
}
