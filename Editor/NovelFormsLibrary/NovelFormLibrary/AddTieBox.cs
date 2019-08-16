using System;
using System.Windows.Forms;

namespace NovelFormLibrary
{
    public partial class AddTieBox: UserControl
    {
        public event EventHandler OnButtonClick;
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
    }
}
