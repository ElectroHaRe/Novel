using System;
using System.Drawing;
using System.Windows.Forms;

namespace NovelFormLibrary
{
    public partial class Node : UserControl
    {
        public event MouseEventHandler OnPictureBoxClick
        {
            add { pictureBox.MouseClick += value; }
            remove
            {
                pictureBox.MouseClick -= value;
            }
        }
        public event MouseEventHandler OnNodeBoxClick;
        public event MouseEventHandler OnNodeBoxMouseUp;
        public event MouseEventHandler OnNodeBoxMouseDown;

        public int index { get; set; }
        public Image Image
        {
            get => pictureBox.Image;
            set
            {
                pictureBox.Image = value;
                pictureBox_BackgroundImageChanged(null, null);
            }
        }
        public new string Text
        {
            get => textBox.Text;
            set { textBox.Text = value; }
        }

        private int normalLabelWidth = 101;

        public Node()
        {
            InitializeComponent();
        }

        private void pictureBox_BackgroundImageChanged(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                NullImageLabel.Visible = true;
                NullImageLabel.Enabled = true;
                return;
            }
            NullImageLabel.Visible = false;
            NullImageLabel.Enabled = false;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {

            OnNodeBoxClick?.Invoke(this, e);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            OnNodeBoxMouseUp?.Invoke(this, e);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            OnNodeBoxMouseDown?.Invoke(this, e);
        }

        private void textBox_MouseClick(object sender, MouseEventArgs e)
        {
            OnNodeBoxClick?.Invoke(this, e);
        }

        private void textBox_MouseUp(object sender, MouseEventArgs e)
        {
            OnNodeBoxMouseUp?.Invoke(this, e);
        }

        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            OnNodeBoxMouseDown?.Invoke(this, e);
        }

        private void Node_SizeChanged(object sender, EventArgs e)
        {
            pictureBox.Location = new Point(0, 0);
            pictureBox.Size = new Size(this.Size.Width, this.Height / 2);
            textBox.Location = new Point(-1, pictureBox.Height);
            textBox.Size = new Size(this.Size.Width + 1, this.Size.Height - pictureBox.Height);
            NullImageLabel.Location = new Point(this.Size.Width / 2 - NullImageLabel.Width / 2, this.Size.Height / 4 - NullImageLabel.Height / 2);
            if (this.Width < normalLabelWidth)
                NullImageLabel.Width = this.Width;
        }

        private void NullImageLabel_MouseClick(object sender, MouseEventArgs e)
        {
            OnNodeBoxClick?.Invoke(this, e);
        }

        private void NullImageLabel_MouseDown(object sender, MouseEventArgs e)
        {
            OnNodeBoxMouseDown?.Invoke(this, e);
        }

        private void NullImageLabel_MouseUp(object sender, MouseEventArgs e)
        {
            OnNodeBoxMouseUp?.Invoke(this, e);
        }
    }
}
