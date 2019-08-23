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
    public partial class CompositeTextBox : UserControl
    {
        public CompositeTextBox()
        {
            InitializeComponent();
        }

        private const int minusVOffset = -5;
        private const int HOffset = 5;

        public const int MinWidth = 100;
        public const int MinHeight = 20;

        /// <summary>
        /// sender - CompositeTextBox
        /// </summary>
        public event EventHandler MinusClick;
        /// <summary>
        /// sender - CompositeTextBox
        /// </summary>
        public event EventHandler ArrowClick;
        /// <summary>
        /// sender - textBox
        /// </summary>
        public event EventHandler TextFieldClick
        {
            add { textBox.Click += value; }
            remove { textBox.Click -= value; }
        }
        /// <summary>
        /// sender - Element
        /// </summary>
        public event EventHandler textChanged;

        /// <summary>
        /// sender - CompositeBox
        /// </summary>
        public event MouseEventHandler BoxMouseUp;
        /// <summary>
        /// sender - CompositeBox
        /// </summary>
        public event MouseEventHandler BoxMouseDown;
        /// <summary>
        /// sender - CompositeBox
        /// </summary>
        public event MouseEventHandler BoxMouseClick;

        public event EventHandler MinusMouseEnter
        {
            add { minusButton.MouseEnter += value; }
            remove { minusButton.MouseEnter -= value; }
        }
        public event EventHandler MinusMouseLeave
        {
            add { minusButton.MouseLeave += value; }
            remove { minusButton.MouseLeave -= value; }
        }
        public event EventHandler ArrowMouseEnter
        {
            add { arrowButton.MouseEnter += value; }
            remove { arrowButton.MouseEnter -= value; }
        }
        public event EventHandler ArrowMouseLeave
        {
            add { arrowButton.MouseLeave += value; }
            remove { arrowButton.MouseLeave -= value; }
        }

        public new string Text
        {
            get => textBox.Text;
            set
            {
                textBox.Text = value;
                textChanged?.Invoke(this, new EventArgs());
            }
        }

        public Element ArrowElement { get; private set; }

        public void SetArrowElement(Element item)
        {
            ArrowElement = item;
        }

        private void MouseUpHendler(object sender, MouseEventArgs e)
        {
            BoxMouseUp?.Invoke(this, e);
        }

        private void MouseDownHendler(object sender, MouseEventArgs e)
        {
            BoxMouseDown?.Invoke(this, e);
        }

        private void MouseClickHandler(object sender, MouseEventArgs e)
        {
            BoxMouseClick?.Invoke(this, e);
        }

        private void CompositeTextBox_SizeChanged(object sender, EventArgs e)
        {
            Width = Width < MinWidth ? MinWidth : Width;
            Height = Height < MinHeight ? MinHeight : Height;

            minusButton.Left = 0;minusButton.Top = Height / 2 - minusButton.Height / 2 + minusVOffset;
            arrowButton.Left = Width - arrowButton.Width; arrowButton.Top = Height / 2 - arrowButton.Height / 2;
            textBox.Left = minusButton.Width + HOffset;textBox.Top = 0;
            textBox.Width = Width - HOffset*2 - arrowButton.Width - minusButton.Width;
            textBox.Height = Height;
        }

        private void ArrowClickHandler(object sender, EventArgs e)
        {
            ArrowClick?.Invoke(this, e);
        }

        private void MinusClickHendler(object sender, EventArgs e)
        {
            MinusClick?.Invoke(this, e);
        }
    }
}
