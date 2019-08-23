using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EditorClassModel
{
    public class Map
    {
        public event EventHandler MapClick;

        public ElementContainer ElementContainer { get; set; }

        private Size WorldSize { get; set; }

        private Size VisibleSize { get; set; }

        private Point WorldCenter { get; set; }

        public World World { get; set; }

        public void TransformToLocalSpace()
        {
            throw new System.NotImplementedException();
        }

        public void TransformToWorldSpace()
        {
            throw new System.NotImplementedException();
        }
    }
}