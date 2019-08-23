using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FormLibrary
{
    public interface IElementContainer
    {
        /// <summary>
        /// sender - IElementContainer
        /// </summary>
        event EventHandler FocusChanged;
        event EventHandler OnAddElement;
        event EventHandler OnAddTie;
        event EventHandler OnRemoveElement;
        event EventHandler OnRemoveTie;

        List<Element> Elements { get; set; }
        Element Current { get; set; }
        Point[] ItemsCoords { get; }
        Dictionary<Point, List<Point>> LinesCoords { get; }

        void AddElement(Element @new);
        void AddTie(Element from, Element to, string text);
        void RemoveFocus();
    }
}
