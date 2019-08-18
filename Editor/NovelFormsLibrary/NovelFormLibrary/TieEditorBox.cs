using System;
using System.Drawing;
using System.Windows.Forms;

namespace NovelFormLibrary
{
    public partial class TieEditorBox : UserControl
    {
        public TieEditorBox()
        {
            InitializeComponent();
        }

        public new event EventHandler TextChanged;
        public event EventHandler RemoveButtonClick;
        public event EventHandler ArrowButtonClick;

        public new string Text
        {
            get => TieTextBox.Text;
            set => TieTextBox.Text = value;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveButtonClick?.Invoke(sender, e);
        }
        private void TieTextBox_TextChanged(object sender, EventArgs e)
        {
            TextChanged?.Invoke(sender, e);
        }
        private void ArrowButton_Click(object sender, EventArgs e)
        {
            ArrowButtonClick?.Invoke(sender, e);
        }

        private void TieEditorBox_SizeChanged(object sender, EventArgs e)
        {
            RemoveButton.Location = new Point(4, this.Size.Height / 2 - RemoveButton.Height / 2 - 3);
            TieTextBox.Location = new Point(RemoveButton.Width + 10, 0);
            TieTextBox.Size = new Size(this.Size.Width - ArrowButton.Width - 2 - TieTextBox.Location.X, this.Size.Height);
            ArrowButton.Location = new Point(this.Size.Width - ArrowButton.Width, this.Size.Height / 2 - ArrowButton.Height / 2);
        }
    }
}
