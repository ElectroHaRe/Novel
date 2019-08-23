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
            treeUser = Factory.GetUser();
            vScrollBar.Visible = vScrollBar.Enabled = false;
            pictureBox.Paint += OnPaintLabel;
        }

        private enum State { mainMenu, Game }
        State state = State.mainMenu;

        private int VOffset => (int)(Height * (float)10 / 450);
        private const int FontSize = 14;
        private const int WindowHOffset = 16;
        private const int WindowVOffset = 39;

        private const int MaxWidth = 400;

        private Font LabelFont => new System.Drawing.Font((new Label()).Font.FontFamily, FontSize);

        private List<Label> Labels = new List<Label>();
        private Label MainText = new Label();

        private User treeUser;

        private void ShowNode()
        {
            foreach (var item in Labels)
            {
                pictureBox.Controls.Remove(item);
            }
            Labels.Clear();

            foreach (var item in treeUser.Choices)
            {
                Labels.Add(new Label());
                Labels[Labels.Count - 1].Text = item == string.Empty ? ">>>" : item;
                Labels[Labels.Count - 1].AutoSize = true;
                Labels[Labels.Count - 1].MouseEnter += ChoiseMouseEnterHandler;
                Labels[Labels.Count - 1].Click += ChoiseLabelClickHandler;
                Labels[Labels.Count - 1].BackColor = Color.Transparent;
                Labels[Labels.Count - 1].ForeColor = Color.White;
                Labels[Labels.Count - 1].Font = LabelFont;
                Labels[Labels.Count - 1].Size = Labels[Labels.Count - 1].GetPreferredSize(new Size(MaxWidth, Height));
                Labels[Labels.Count - 1].AutoSize = false;
                Labels[Labels.Count - 1].Height /= 2;
                Labels[Labels.Count - 1].CreateControl();
            }
            if (MainText.Font.Size != FontSize)
                MainText.Font = LabelFont;
            MainText.Text = treeUser.Text;
            MainText.BackColor = Color.Transparent;
            MainText.Size = MainText.GetPreferredSize(new Size(Width / 2, Height));
            MainText.Top = Height / 2 - MainText.Height - VOffset * 2;
            pictureBox.Controls.Add(MainText);
            MainText.Left = (Width - WindowHOffset) / 2 - MainText.Width / 2;
            pictureBox.Image = treeUser.Image;
            for (int i = 0; i < Labels.Count; i++)
            {
                pictureBox.Controls.Add(Labels[i]);
                Labels[i].Left = (Width - WindowHOffset) / 2 - Labels[i].Width / 2;
                Labels[i].Top = i == 0 ? MainText.Top + MainText.Height + VOffset : Labels[i - 1].Top + Labels[i - 1].Height + VOffset;
            }
        }

        private void OnPaintLabel(object sender, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(Color.FromArgb(150, Color.Black));
            e.Graphics.FillRectangle(brush, Width/2 - MaxWidth/2, Height/3, MaxWidth, Height/2);
        }

        private void ChoiseMouseEnterHandler(object sender, EventArgs e)
        {
            for (int i = 0; i < Labels.Count; i++)
            {
                Labels[i].BorderStyle = BorderStyle.None;
            }
            (sender as Label).BorderStyle = BorderStyle.FixedSingle;
        }

        private void ChoiseLabelClickHandler(object sender, EventArgs e)
        {
            treeUser.MoveNext((sender as Label).Text);
            ShowNode();
        }

        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            for (int i = Labels.Count - 1; i >= 0; i--)
            {
                Labels[i].Top = i == Labels.Count - 1 ? Height - WindowVOffset - VOffset - Labels[i].Height : Labels[i + 1].Top - VOffset - Labels[i].Height;
                Labels[i].Left = (Width - WindowHOffset) / 2 - Labels[i].Width / 2;
            }
            MainText.Left = (Width - WindowHOffset) / 2 - MainText.Width / 2;
            MainText.Top = Labels.Count > 0 ? Labels[0].Top - VOffset * 2 - MainText.Height : VOffset * 2 - MainText.Height;
            loadButton.Left = Width / 2 - loadButton.Width / 2;
            loadButton.Top = pictureBox.Height / 2 - loadButton.Height / 2 - 10;
            exitButton.Top = loadButton.Top + loadButton.Height + 50;
            exitButton.Left = loadButton.Left;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            openDialog.Filter = "(*.NovelTree)|*.NovelTree";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    treeUser.Load(openDialog.FileName);
                    loadButton.Visible = loadButton.Enabled = false;
                    exitButton.Visible = exitButton.Enabled = false;
                    state = State.Game;
                }
                catch { return; }
                ShowNode();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void vScrollBar_ValueChanged(object sender, EventArgs e)
        {
            MainText.Top = vScrollBar.Value;
        }
    }
}
