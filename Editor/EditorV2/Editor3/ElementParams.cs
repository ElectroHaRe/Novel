using System;
using System.Collections.Generic;
using System.Drawing;

namespace Editor3
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
}
