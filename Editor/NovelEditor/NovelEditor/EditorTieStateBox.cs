using System;
using System.Drawing;
using System.Windows.Forms;
using NovelFormLibrary;

namespace NovelEditor
{
    public partial class EditorTieStateBox : UserControl
    {
        public EditorTieStateBox()
        {
            InitializeComponent();
        }

        private const int HIndent = 0;
        private const int VIndent = 6;
        private const int MaxWidth = 250;

        public bool Active
        {
            get => this.Enabled && this.Visible;
            set => this.Enabled = this.Visible = value;
        }
        public string AddTieBoxText => addTieBox.Text;
        public delegate void TextChangedDelegate(string text);

        public event EventHandler OnPlusButtonClick
        {
            add { addTieBox.OnButtonClick += value; }
            remove { addTieBox.OnButtonClick -= value; }
        }

        private TieEditorBox[] tieEditorBoxArray = new TieEditorBox[0];

        public void AddTieEditorBox(string text, EventHandler removeButtonClicHandler, EventHandler arrowButtonClickHandler, TextChangedDelegate textChangedHandler)
        {
            Array.Resize(ref tieEditorBoxArray, tieEditorBoxArray.Length + 1);
            TieEditorBox temp = new TieEditorBox();
            temp.Text = text;
            temp.ArrowButtonClick += arrowButtonClickHandler;
            temp.RemoveButtonClick += removeButtonClicHandler;
            temp.TextChanged += (object sender, EventArgs e) => textChangedHandler.Invoke(tieEditorBoxArray[tieEditorBoxArray.Length - 1].Text);
            temp.Size = addTieBox.Size;
            Point position = new Point();
            position.X = addTieBox.Location.X;
            if (tieEditorBoxArray.Length == 1)
            {
                position.Y = 0;
            }
            else
            {
                position.Y = tieEditorBoxArray[tieEditorBoxArray.Length - 2].Location.Y + tieEditorBoxArray[tieEditorBoxArray.Length - 2].Height + VIndent;
            }
            temp.Location = position;
            temp.Enabled = true;
            temp.Visible = true;
            temp.CreateControl();
            tieEditorBoxArray[tieEditorBoxArray.Length - 1] = temp;
            this.Controls.Add(temp);
            if (addTieBox.Location.Y <= position.Y + temp.Size.Height + VIndent)
            {
                this.Height = position.Y + temp.Size.Height + VIndent + addTieBox.Size.Height;
                EditorTieFuncStateBox_SizeChanged(null, null);
            }
        }

        public void RemoveAllTieEditorBoxes()
        {
            tieEditorBoxArray = new TieEditorBox[0];
        }

        private void EditorTieFuncStateBox_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > MaxWidth)
                this.Width = MaxWidth;

            for (int i = 0; i < tieEditorBoxArray.Length; i++)
            {

                tieEditorBoxArray[i].Location = new Point(HIndent,
                    (i > 0 ? tieEditorBoxArray[i - 1].Location.Y + tieEditorBoxArray[i - 1].Height : 0) + VIndent);
                tieEditorBoxArray[i].Width = this.Width - HIndent * 2;
            }
            addTieBox.Width = this.Width - HIndent * 2;

            TieEditorBox temp = tieEditorBoxArray.Length > 0 ? tieEditorBoxArray[tieEditorBoxArray.Length - 1] : null;

            if (temp != null && this.Height < temp.Location.Y + temp.Size.Height + VIndent + addTieBox.Height)
                this.Height = temp.Location.Y + temp.Size.Height + VIndent + addTieBox.Height;
            else if (temp ==null && this.Height < addTieBox.Height)
                this.Height = addTieBox.Height;


            addTieBox.Location = new Point(HIndent, this.Height - addTieBox.Height);
        }
    }
}
