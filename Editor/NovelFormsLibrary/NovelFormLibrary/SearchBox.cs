﻿using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NovelFormLibrary
{
    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
        }

        public event EventHandler OnSearchButtonClick;
        public new string Text => requestBox.Text;

        public int[] GetRequestIndexFrom(params string[] source)
        {
            int[] result = new int[0];
            for (int i = 0; i < source.Length; i++)
            {
                if (Regex.IsMatch(source[i], "(" + requestBox.Text + ")" + "+"))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = i;
                }
            }
            return result;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            OnSearchButtonClick?.Invoke(sender, e);
        }

        private void SearchBox_SizeChanged(object sender, EventArgs e)
        {
            this.Height = 20;
            searchButton.Location = new Point(this.Size.Width - 21, 1);
            requestBox.Width = searchButton.Location.X;
        }
    }
}
