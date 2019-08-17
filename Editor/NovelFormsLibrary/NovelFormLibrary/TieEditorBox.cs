using System;
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

        public new string Text => TieTextBox.Text;

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
    }
}
