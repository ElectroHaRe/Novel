using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EditorClassModel
{
    public class Element
    {
        public event EventHandler ImageFieldClick;
        public event EventHandler TextFieldClick;
        public event EventHandler ElementClick;
        public event EventHandler ImageFieldMouseClick;
        public event EventHandler TextFieldMouseClick;
        public event EventHandler ElementMouseClick;
        public event EventHandler ElementMouseUpClick;
        public event EventHandler ElementMouseDownClick;
        public event EventHandler TextChanged;

        private Element[] ties;

        public Image Image { get; set; }
        public string Text { get; set; }

        public void AddTie(Element element)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTie(Element element)
        {
            throw new System.NotImplementedException();
        }

        public Point[] GetTieCoords()
        {
            throw new System.NotImplementedException();
        }
    }
}