using System;
using System.IO;
using System.Windows.Forms;
using FormLibrary;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Collections.Generic;

namespace EditorV2
{
    [Serializable]
    class ElementParams
    {
        public ElementParams(Image image, string text, Point location)
        {
            this.image = image;
            this.Text = text;
            this.Location = location;
        }
        public readonly Image image;
        public readonly string Text;
        public readonly Point Location;
        public Dictionary<int, string> ties = new Dictionary<int, string>();
    }

    

    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
            functionalBox.ConnectWorld(worldOfElements);
            functionalBox.ConnectElementContainer(worldOfElements);
            functionalBox.SaveClick += SaveClickHandler;
            functionalBox.LoadClick += LoadClickHandler;
            saveFileDialog.Filter = "(*.NovelTree)|*.NovelTree";
            openDialog.Filter = "(*.NovelTree)|*.NovelTree";
        }

        OpenFileDialog openDialog = new OpenFileDialog();

        private const float WidthFuncFactor = (float)180 / 816;
        private const int RightOffset = 16;
        private const int HOffset = 39;

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            functionalBox.Width = (int)(Width * WidthFuncFactor);
            functionalBox.Height = Height - 39;
            functionalBox.Left = Width - RightOffset - functionalBox.Width;
            functionalBox.Top = 0;

            worldOfElements.Width = functionalBox.Left;
            worldOfElements.Height = functionalBox.Height;
            worldOfElements.Top = 0;
            worldOfElements.Left = 0;
        }

        private void SaveClickHandler(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ElementParams[] temp = new ElementParams[(worldOfElements as IElementContainer).Elements.Count];
                for (int i = 0; i < temp.Length; i++)
                {
                    Element item = (worldOfElements as IElementContainer).Elements[i];
                    temp[i] = new ElementParams(item.Image, item.Text, item.Location);
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    foreach (var item in (worldOfElements as IElementContainer).Elements[i].ties)
                    {
                        temp[i].ties.Add(worldOfElements.GetIndexOf(item.Key), item.Value);
                    }
                }

                BinaryFormatter serializer = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
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
                    worldOfElements.AddElement(elements[i]);
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    foreach (var item in temp[i].ties)
                    {
                        worldOfElements.AddTie(elements[i], elements[item.Key], item.Value);
                    }
                }
            }
        }
    }
}
