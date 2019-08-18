using System;
using System.Windows.Forms;

namespace NovelEditor
{
    public partial class DefaultStateBox : UserControl
    {
        public DefaultStateBox()
        {
            InitializeComponent();
        }

        private const int MaxWidth = 250;
        private const int MinWidth = 150;
        private const int VIndent = 6;
        private const int HIndent = 0;

        public bool Active
        {
            get => this.Enabled && this.Visible;
            set { this.Enabled = value; this.Visible = value; }
        }

        public event EventHandler OnSaveButtonClick
        {
            add { saveButton.Click += value; }
            remove { saveButton.Click -= value; }
        }
        public event EventHandler OnLoadButtonClick
        {
            add { loadButton.Click += value; }
            remove { loadButton.Click -= value; }
        }
        public event EventHandler OnAddTreeButtonClick
        {
            add { addTreeButton.Click += value; }
            remove { addTreeButton.Click -= value; }
        }
        public event EventHandler OnUndoButtonClick
        {
            add { undoButton.Click += value; }
            remove { undoButton.Click -= value; }
        }
        public event EventHandler OnRedoButtonClick
        {
            add { redoButton.Click += value; }
            remove { redoButton.Click -= value; }
        }
        public event EventHandler OnQuitButtonClick
        {
            add { quitButton.Click += value; }
            remove { quitButton.Click -= value; }
        }

        private void DefaultStateBox_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > MaxWidth)
            {
                this.Width = MaxWidth;
            }
            else if (this.Width < MinWidth)
            {
                this.Width = MinWidth;
            }

            saveButton.Width = loadButton.Width = addTreeButton.Width
                = undoButton.Width = redoButton.Width = quitButton.Width = this.Width;
        }
    }
}
