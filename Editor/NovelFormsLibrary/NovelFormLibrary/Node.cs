using System;
using System.Drawing;
using System.Windows.Forms;

namespace NovelFormLibrary
{
    public partial class Node : UserControl
    {
        public int index { get; set; }
        public event EventHandler OnPictureBoxClick;
        public Image Image
        {
            get => pictureBox.Image;
            set
            {
                pictureBox.Image = Image;
                pictureBox_BackgroundImageChanged(null, null);
            }
        }
        public new string Text
        {
            get => textBox.Text;
            set { textBox.Text = value; }
        }

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

        private void pictureBox_Click(object sender, EventArgs e)
        {
            OnPictureBoxClick?.Invoke(sender,e);
        }

        private void Node_SizeChanged(object sender, EventArgs e)
        {
            pictureBox.Location = new Point(0, 0);
            pictureBox.Size = new Size(this.Size.Width, this.Height / 2);
            textBox.Location = new Point(-1, pictureBox.Height);
            textBox.Size = new Size(this.Size.Width + 1, this.Size.Height - pictureBox.Height);
            NullImageLabel.Location = new Point(this.Size.Width / 2 - NullImageLabel.Width / 2, this.Size.Height / 4 - NullImageLabel.Height / 2);
        }
    }
}
