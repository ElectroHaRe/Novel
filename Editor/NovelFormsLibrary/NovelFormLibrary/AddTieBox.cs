using System;
using System.Windows.Forms;
using System.Drawing;

namespace NovelFormLibrary
{
    public partial class AddTieBox: UserControl
    {
        public event EventHandler OnButtonClick;
        public new event EventHandler TextChanged
        {
            add { textBox.TextChanged += value; }
            remove { textBox.TextChanged -= value; }
        }

        public new string Text
        {
            get => textBox.Text;
            set { textBox.Text = value; }
        }

        public AddTieBox()
        {
            InitializeComponent();
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            OnButtonClick?.Invoke(sender,e);
        }

        private void AddTieBox_SizeChanged(object sender, EventArgs e)
        {
            plusButton.Location = new Point(this.Size.Width - plusButton.Width, this.Size.Height / 2 - plusButton.Height / 2);
            textBox.Location = new Point(0, 0);
            textBox.Size = new Size(this.Size.Width - plusButton.Width - 1, this.Size.Height);
        }
    }
}
