using System;
using System.Windows.Forms;
using FormLibrary;
using System.IO;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using NovelDataV3;

namespace Editor3
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
            funcBox.ConnectWorld(worldBox);
            funcBox.ConnectElementContainer(worldBox);
            funcBox.SaveClick += SaveClickHandler;
            funcBox.LoadClick += LoadClickHandler;
            funcBox.ExitClick += ExitClickHandler;
            funcBox.MapMouseClick += MapMouseClickHandler;
            funcBox.MinusClick += RemoveButtonClickHandler;
            funcBox.ArrowClick += ArrowClickHandler;
            funcBox.MinusMouseEnter += MinusMouseEnterHandler;
            funcBox.MinusMouseLeave += MinusMouseLeaveHandler;
            funcBox.PlusMouseEnter += PlusMouseEnterHandler;
            funcBox.PlusMouseLeave += PlusMouseLeaveHandler;
            funcBox.ArrowMouseEnter += ArrowMouseEnterHandler;
            funcBox.ArrowMouseLeave += ArrowMouseLeaveHandler;
            saveDialog.Filter = "(*.NovelTreeForEditor)|*.NovelTreeForEditor";
            openDialog.Filter = "(*.NovelTreeForEditor)|*.NovelTreeForEditor";
            creator = Factory.GetCreator();
        }

        private const float WidthFuncFactor = (float)180 / 816;
        private const int RightOffset = 16;
        private const int HOffset = 39;

        private Creator creator;

        private void SizeChangedHandler(object sender, EventArgs e)
        {
            funcBox.Width = (int)(Width * WidthFuncFactor);
            funcBox.Height = Height - 39;
            funcBox.Left = Width - RightOffset - funcBox.Width;
            funcBox.Top = 0;

            worldBox.Width = funcBox.Left;
            worldBox.Height = funcBox.Height;
            worldBox.Top = 0;
            worldBox.Left = 0;
        }

        private void SaveClickHandler(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ElementParams[] temp = new ElementParams[(worldBox as IElementContainer).Elements.Count];
                for (int i = 0; i < temp.Length; i++)
                {
                    Element item = (worldBox as IElementContainer).Elements[i];
                    temp[i] = new ElementParams(item.Image, item.Text, item.Location);
                    creator.CreateNode(item.Text, item.Image);
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    foreach (var item in (worldBox as IElementContainer).Elements[i].ties)
                    {
                        temp[i].ties.Add(worldBox.GetIndexOf(item.Key), item.Value);
                        creator.TieNodes(i, worldBox.GetIndexOf(item.Key), item.Value);
                    }
                }
                creator.Save(Path.GetDirectoryName(saveDialog.FileName), Path.GetFileNameWithoutExtension(saveDialog.FileName));
                BinaryFormatter serializer = new BinaryFormatter();
                using (Stream stream = new FileStream(saveDialog.FileName, FileMode.OpenOrCreate))
                {
                    serializer.Serialize(stream, temp);
                }
            }
        }

        private void LoadClickHandler(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                ElementParams[] temp;
                using (Stream stream = new FileStream(openDialog.FileName, FileMode.Open))
                {
                    temp = deserializer.Deserialize(stream) as ElementParams[];
                }
                Element[] elements = new Element[temp.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    elements[i] = new Element(temp[i].Text, temp[i].image, temp[i].Location);
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    worldBox.AddElement(elements[i]);
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    foreach (var item in temp[i].ties)
                    {
                        worldBox.AddTie(elements[i], elements[item.Key], item.Value);
                    }
                }
            }
        }

        private void RemoveButtonClickHandler(object sender, EventArgs e)
        {
            worldBox.RemoveTie((worldBox as IElementContainer).Current, (sender as CompositeTextBox).ArrowElement);
        }

        private void ArrowClickHandler(object sender, EventArgs e)
        {
            Element element = (sender as CompositeTextBox).ArrowElement;
            worldBox.OffsetElements(new Point(-element.Left + worldBox.Width/2, -element.Top + worldBox.Height/2));
            worldBox.SetFocusOn(element);
        }

        private void ArrowMouseEnterHandler(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Red;
        }

        private void ArrowMouseLeaveHandler(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Black;
        }

        private void PlusMouseEnterHandler(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.MediumSeaGreen;
        }

        private void PlusMouseLeaveHandler(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Black;
        }

        private void MinusMouseEnterHandler(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Red;
        }

        private void MinusMouseLeaveHandler(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Black;
        }

        private void MapMouseClickHandler(object sender, MouseEventArgs e)
        {
            Point point = (sender as Map).TransformToWorldSpace((worldBox as IWorld).Size, new Point ((sender as Map).Width/2 - e.Location.X,
                (sender as Map).Height / 2 - e.Location.Y));
            Point window_center = new Point(worldBox.Width / 2 - (worldBox as IWorld).Center.X, worldBox.Height / 2 - (worldBox as IWorld).Center.Y);
            point = new Point(window_center.X + point.X, window_center.Y + point.Y);
            worldBox.OffsetElements(new Point((point.X), (point.Y)));
        }

        private void ExitClickHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
