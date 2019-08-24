using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NovelDataV3;
using System.Drawing;

namespace Game
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SizeChangedHandler(null, null);
            ChoicesTextField.LabelMouseClick += LabelMouseClickHandler;
            ChoicesTextField.LabelMouseEnter += LabelMouseEnterHandler;
            ChoicesTextField.LabelMouseLeave += LabelMouseLeaveHandler;
            MainTextField.Active = false;
            ChoicesTextField.Active = false;
            pictureBox.Controls.Add(MainTextField);
            pictureBox.Controls.Add(ChoicesTextField);
            openDialog.Filter = "(*.NovelTree)|*.noveltree";
        }

        public int VOffset = 10;

        private User treeUser = Factory.GetUser();

        private string EmptyCap = ">>>";

        private enum State { mainMenu, inGame }
        private State state = State.mainMenu;

        TextField MainTextField = new TextField();
        TextField ChoicesTextField = new TextField();

        private void ShowNode()
        {
            MainTextField.Clear();
            ChoicesTextField.Clear();
            MainTextField.AddLabel(treeUser.Text);
            foreach (var item in treeUser.Choices)
            {
                if (item == string.Empty)
                    ChoicesTextField.AddInteractLabel(EmptyCap);
                else
                    ChoicesTextField.AddInteractLabel(item);
            }
            if (state != State.inGame)
            {
                state = State.inGame;
                MainTextField.Active = ChoicesTextField.Active = true;
                loadButton.Enabled = loadButton.Visible = exitButton.Enabled = exitButton.Visible = false;
            }
            pictureBox.Image = treeUser.Image;
            SizeChangedHandler(null, null);
            MainTextField.Update();
            ChoicesTextField.Update();
        }

        private void LoadClickHandler(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    treeUser.Load(openDialog.FileName);
                    ShowNode();
                }
                catch { return; }
            }
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LabelMouseClickHandler(object sender, MouseEventArgs e)
        {
            string text = (sender as Label).Text;
            treeUser.MoveNext(text == EmptyCap ? string.Empty : text);
            ShowNode();
        }

        private void LabelMouseEnterHandler(object sender, EventArgs e)
        {
            (sender as Label).BorderStyle = BorderStyle.FixedSingle;
        }

        private void LabelMouseLeaveHandler(object sender, EventArgs e)
        {
            (sender as Label).BorderStyle = BorderStyle.None;
        }

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            MainTextField.Size = new Size(Width / 2, Height / 4);
            ChoicesTextField.Height = Height / 3;
            ChoicesTextField.Width = Width / 2;

            int w = MainTextField.GetOptimalWidth(); int h = MainTextField.GetOptimalHeight();
            if (w < MainTextField.Width)
                MainTextField.Width = w;
            if (h < MainTextField.Height)
                MainTextField.Height = h;

            MainTextField.Left = pictureBox.Width / 2 - MainTextField.Width / 2;
            MainTextField.Top = pictureBox.Height / 2 - MainTextField.Height - VOffset * 2;

            w = ChoicesTextField.GetOptimalWidth(); h = ChoicesTextField.GetOptimalHeight();
            if (w < ChoicesTextField.Width)
                ChoicesTextField.Width = w;
            if (h < ChoicesTextField.Height)
                ChoicesTextField.Height = h;

            ChoicesTextField.Left = pictureBox.Width / 2 - ChoicesTextField.Width / 2;
            ChoicesTextField.Top = (pictureBox.Height * 3) / 4 + VOffset * 2;

            loadButton.Left = pictureBox.Width / 2 - loadButton.Width / 2;
            loadButton.Top = pictureBox.Height / 2 - loadButton.Height - VOffset;
            exitButton.Left = pictureBox.Width / 2 - exitButton.Width / 2;
            exitButton.Top = pictureBox.Height / 2 + exitButton.Height;
        }
    }
}
