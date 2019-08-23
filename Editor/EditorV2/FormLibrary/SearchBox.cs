using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FormLibrary
{
    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
        }

        private const int HButtonOffset = 5;
        private const int VTextBoxOffset = 3;
        private const int FixHeight = 20;
        private const int MinWidth = 30;

        /// <summary>
        /// sender - SearchBox
        /// </summary>
        public new event EventHandler TextChanged;
        /// <summary>
        /// sender - pictureBox
        /// </summary>
        public event EventHandler SearchButtonClick
        {
            add { searchButton.Click += value; }
            remove { searchButton.Click -= value; }
        }

        public event MouseEventHandler BoxMouseClick;
        public event MouseEventHandler BoxMouseDown;
        public event MouseEventHandler BoxMouseUp;

        public new string Text
        {
            get => textBox.Text;
            set
            {
                textBox.Text = value;
                TextChanged?.Invoke(this,new EventArgs());
            }
        }

        public int[] SearchFromSource(params string[] source)
        {
            int[] temp = new int[0];
            for (int i = 0; i < source.Length; i++)
            {
                if (Regex.IsMatch(source[i], "(" + Text + ")+"))
                {
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = i;
                }
            }
            return temp;
        }

        private void MouseClickHendler(object sender, MouseEventArgs e)
        {
            BoxMouseClick?.Invoke(this, e);
        }

        private void MouseDownHendler(object sender, MouseEventArgs e)
        {
            BoxMouseDown?.Invoke(this, e);
        }

        private void MouseUpHendler(object sender, MouseEventArgs e)
        {
            BoxMouseUp?.Invoke(this, e);
        }

        private void TextChangedHandler(object sender, EventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            Height = FixHeight;
            Width = Width < MinWidth ? MinWidth : Width;
            searchButton.Top = 0;
            searchButton.Left = Width - searchButton.Width - HButtonOffset;
            textBox.Left = 0;textBox.Top = VTextBoxOffset;
            textBox.Width = searchButton.Left;
        }
    }
}
