using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EditorClassModel
{
    public class WorldOfElements : World, ElementContainer
    {
        private List<Element> ElementList = new List<Element>();

        public event EventHandler Drag;
        public event EventHandler OnRemoveElement;
        public event EventHandler OnRemoveTie;
        public event EventHandler OnAddElement;
        public event EventHandler OnElementsOffset;

        event EventHandler World.WorldChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }

        }
        event EventHandler ElementContainer.FocusChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler ElementTextChanged;
        public event EventHandler OnCreateElement;
        public event EventHandler OnElementChanged;

        Point World.Center { get; set; }

        Size World.Size { get; set; }

        Size World.VisibleSize { get; set; }

        Point[] World.ItemsCoords { get; set; }
        Dictionary<Point, List<Point>> World.LinesCoords { get; set; }

        List<Element> ElementContainer.Elements { get; set; }
        Element ElementContainer.CurrentElement { get; set; }

        public Point[] GetElementsPos()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<Point, List<Point>> GetTiesPos()
        {
            throw new System.NotImplementedException();
        }

        public void OffsetElements(Point offsetVector)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveElement(Element element)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTie(Element from, Element to)
        {
            throw new System.NotImplementedException();
        }

        public void AddElement(Element @new)
        {
            throw new System.NotImplementedException();
        }

        public void AddTie(Element from, Element to)
        {
            throw new System.NotImplementedException();
        }

        private void DragElements()
        {
            throw new System.NotImplementedException();
        }

        private void StartDrag()
        {
            throw new System.NotImplementedException();
        }

        private void EndDrag()
        {
            throw new System.NotImplementedException();
        }

        public int GetIndexOf(Element element)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface World
    {
        event EventHandler WorldChanged;

        Point Center { get; set; }
        Size Size { get; set; }
        Size VisibleSize { get; set; }
        Point[] ItemsCoords { get; set; }
        Dictionary<Point,List<Point>> LinesCoords { get; set; }
    }
}