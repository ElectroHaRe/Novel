using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormLibrary
{
    public partial class WorldOfElements : UserControl, IWorld, IElementContainer
    {
        public WorldOfElements()
        {
            InitializeComponent();
            timer.Tick += DragElements;
            timer.Interval = TickInterval;
            WorldChanged += RePaint;
            MouseWheel += WheelScaleHandler;
            FocusChanged += RePaint;
        }


        Pen pen = new Pen(Color.Black, 1);

        private const int TickInterval = 5;

        private struct SizeAndPos
        {
            public SizeAndPos(Size size, Point pos)
            {
                this.size = size;
                this.pos = pos;
            }

            public readonly Size size;
            public readonly Point pos;
        }

        public int ElementHighlightWidth = 2;
        public Color ElementHighlightColor = Color.LightSeaGreen;
        public int ElementHighlightRectOffset = 5;

        public int LineWidth = 1;
        public Color LineColor = Color.Black;

        public int ArrowWidth = 2;
        public Color ArrowColor = Color.Black;

        private float _factor = 0.5f;
        /// <summary>
        /// min value - 0.1, max value - 1
        /// </summary>
        public float ScaleFactor
        {
            get => _factor;
            set
            {
                float last_factor = _factor;
                _factor = value < 0.1f ? 0.1f : value > 1 ? 1 : value;
                float transform_factor = _factor / last_factor;
                if (transform_factor != 1)
                {
                    foreach (var item in (this as IElementContainer).Elements)
                    {
                        item.Left = (int)((NormalParams[item].pos.X) * _factor);
                        item.Top = (int)((NormalParams[item].pos.Y) * _factor);
                        item.Width = (int)(NormalParams[item].size.Width * _factor);
                        item.Height = (int)(NormalParams[item].size.Height * _factor);
                    }
                    WorldChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        public event EventHandler Drag;
        public event EventHandler OnRemoveElement;
        public event EventHandler OnRemoveTie;
        public event EventHandler OnAddElement;
        public event EventHandler OnElementsOffset;
        public event EventHandler ElementTextChanged;
        public event EventHandler OnElementChanged;
        public event EventHandler OnAddTie;

        public event MouseEventHandler WorldMouseClick
        {
            add { MouseClick += value; }
            remove { MouseClick -= value; }
        }

        public event MouseEventHandler WorldMouseUp
        {
            add { MouseUp += value; }
            remove { MouseDown -= value; }
        }

        public event MouseEventHandler WorldMouseDown
        {
            add { MouseDown += value; }
            remove { MouseDown -= value; }
        }

        public event EventHandler WorldChanged;
        public event EventHandler FocusChanged;

        event EventHandler IWorld.WorldChanged
        {
            add { WorldChanged += value; }
            remove { WorldChanged -= value; }
        }

        event EventHandler IElementContainer.FocusChanged
        {
            add { FocusChanged += value; }
            remove { FocusChanged -= value; }
        }

        Point IWorld.Center
        {
            get
            {
                int min_x, min_y, max_x, max_y;
                GetExtremePoints(out min_x, out max_x, out min_y, out max_y);
                return new Point(min_x + (max_x - min_x) / 2, min_y + (max_y - min_y) / 2);
            }
        }
        Size IWorld.Size
        {
            get
            {
                int min_x, min_y, max_x, max_y;
                GetExtremePoints(out min_x, out max_x, out min_y, out max_y);
                return new Size(max_x - min_x, max_y - min_y);
            }
        }
        Size IWorld.VisibleSize => Size;
        private void GetExtremePoints(out int min_x, out int max_x, out int min_y, out int max_y)
        {
            min_x = 0; min_y = 0; max_x = Width; max_y = Height;
            foreach (var item in (this as IElementContainer).Elements)
            {
                if (item.Left < min_x)
                    min_x = item.Left;
                if (item.Left > max_x)
                    max_x = item.Left;
                if (item.Top < min_y)
                    min_y = item.Top;
                if (item.Top > max_y)
                    max_y = item.Top;
            }
        }

        private Dictionary<Element, SizeAndPos> NormalParams = new Dictionary<Element, SizeAndPos>();
        List<Element> IElementContainer.Elements { get; set; } = new List<Element>();
        Element IElementContainer.Current { get; set; }
        Point[] IElementContainer.ItemsCoords => GetElementsPos();
        Dictionary<Point, List<Point>> IElementContainer.LinesCoords => GetTiesPos();

        void IElementContainer.RemoveFocus()
        {
            (this as IElementContainer).Current = null;
            FocusChanged?.Invoke(this, new EventArgs());
        }

        public void Clear()
        {
            foreach (var item in (this as IElementContainer).Elements)
            {
                Controls.Remove(item);
            }
            (this as IElementContainer).Elements.Clear();
        }

        public void SetFocusOn(Element element)
        {
            (this as IElementContainer).Current = element;
            FocusChanged?.Invoke(this, new EventArgs());
        }

        public Point[] GetElementsPos()
        {
            IElementContainer container = this as IElementContainer;
            Point[] temp = new Point[container.Elements.Count];
            for (int i = 0; i < container.Elements.Count; i++)
            {
                temp[i] = container.Elements[i].Location;
            }
            return temp;
        }

        public Dictionary<Point, List<Point>> GetTiesPos()
        {
            IElementContainer container = this as IElementContainer;
            Dictionary<Point, List<Point>> result = new Dictionary<Point, List<Point>>();
            for (int i = 0; i < container.Elements.Count; i++)
            {
                foreach (var item in container.Elements[i].GetTieCoords())
                {
                    if (!result.ContainsKey(container.Elements[i].Location))
                    {
                        result.Add(container.Elements[i].Location, new List<Point>());
                        result[container.Elements[i].Location].Add(item);
                    }
                    else result[container.Elements[i].Location].Add(item);
                }
            }
            return result;
        }

        public void OffsetElements(Point offsetVector)
        {
            IElementContainer container = this as IElementContainer;
            foreach (var item in container.Elements)
            {
                item.Left += offsetVector.X;
                item.Top += offsetVector.Y;
                var newPos = new Point(NormalParams[item].pos.X + (int)(offsetVector.X / _factor), NormalParams[item].pos.Y + (int)(offsetVector.Y / _factor));
                NormalParams[item] = new SizeAndPos(NormalParams[item].size, newPos);
            }
            OnElementsOffset?.Invoke(this, new EventArgs());
            WorldChanged?.Invoke(this, new EventArgs());
        }

        public void RemoveElement(Element element)
        {
            IElementContainer container = this as IElementContainer;
            foreach (var item in container.Elements)
            {
                item.RemoveTie(element);
            }
            Controls.Remove(container.Current);
            container.Elements.Remove(element);
            NormalParams.Remove(element);
            OnRemoveElement?.Invoke(this, new EventArgs());
            WorldChanged?.Invoke(this, new EventArgs());
        }

        public void RemoveTie(Element from, Element to)
        {
            IElementContainer container = this as IElementContainer;
            int index = container.Elements.IndexOf(from);
            if (index > -1)
            {
                container.Elements[container.Elements.IndexOf(from)].RemoveTie(to);
                OnRemoveTie?.Invoke(this, new EventArgs());
                WorldChanged?.Invoke(this, new EventArgs());
            }
        }

        public void AddElement(Element @new)
        {
            @new.TextChanged += ElementTextChanged;
            @new.Changed += OnElementChanged;
            @new.ElementMouseClick += Element_MouseClick;
            @new.ElementMouseClick += Element_MouseClick;
            @new.ElementMouseDown += Element_MouseDown;
            @new.ElementMouseUp += Element_MouseUp;
            NormalParams.Add(@new, new SizeAndPos(@new.Size, new Point((int)(@new.Left / _factor), (int)(@new.Top / _factor))));
            @new.Width = (int)(_factor * @new.Width);
            @new.Height = (int)(_factor * @new.Height);
            @new.CreateControl();
            Controls.Add(@new);
            (this as IElementContainer).Elements.Add(@new);
            OnAddElement?.Invoke(this, new EventArgs());
            WorldChanged?.Invoke(this, new EventArgs());
        }

        public void AddElement(string text, Image image, Point location)
        {
            AddElement(new Element(text, image, location));
        }

        public void AddTie(Element from, Element to, string text)
        {
            IElementContainer container = this as IElementContainer;
            int index = container.Elements.IndexOf(from);
            if (index > -1)
            {
                container.Elements[container.Elements.IndexOf(from)].AddTie(to, text);
                WorldChanged?.Invoke(this, new EventArgs());
                OnAddTie?.Invoke(this, new EventArgs());
            }
        }

        #region DragLogic

        Timer timer = new Timer();

        List<Element> draggableElementList = new List<Element>();
        List<Point> tempLocationList = new List<Point>();
        Point startDragMousePosition = new Point(0, 0);
        Point mouseMoveVector => new Point(MousePosition.X - startDragMousePosition.X, MousePosition.Y - startDragMousePosition.Y);

        private void DragElements(object sender, EventArgs e)
        {
            for (int i = 0; i < draggableElementList.Count; i++)
            {
                draggableElementList[i].Left = tempLocationList[i].X + mouseMoveVector.X;
                draggableElementList[i].Top = tempLocationList[i].Y + mouseMoveVector.Y;
            }
            Drag?.Invoke(this, new EventArgs());
            if (mouseMoveVector.X != 0 || mouseMoveVector.Y != 0)
                WorldChanged?.Invoke(this, new EventArgs());
        }

        private void StartDrag()
        {
            startDragMousePosition = MousePosition;
            IElementContainer container = this as IElementContainer;
            if (container.Current == null)
            {
                foreach (var item in (this as IElementContainer).Elements)
                {
                    draggableElementList.Add(item);
                    tempLocationList.Add(item.Location);
                }
            }
            else
            {
                draggableElementList.Add((this as IElementContainer).Current);
                tempLocationList.Add((this as IElementContainer).Current.Location);
            }
            timer.Start();
        }

        private void StopDrag()
        {
            foreach (var item in (this as IElementContainer).Elements)
            {
                NormalParams[item] = new SizeAndPos(NormalParams[item].size, new Point((int)(item.Left / _factor), (int)(item.Top / _factor)));
            }
            draggableElementList.Clear();
            tempLocationList.Clear();
        }

        #endregion

        public int GetIndexOf(Element element)
        {
            return (this as IElementContainer).Elements.IndexOf(element);
        }

        #region FormLogic

        private void ChangeFocusTo(Element item)
        {
            if ((this as IElementContainer).Current != item)
            {
                (this as IElementContainer).Current = item;
                FocusChanged?.Invoke(this, new EventArgs());
            }
        }

        private void World_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeFocusTo(null);
            if (e.Button == MouseButtons.Left)
            {
                StartDrag();
            }
        }

        private void World_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                StopDrag();
        }

        private void Element_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeFocusTo(sender as Element);
            if (e.Button == MouseButtons.Left)
            {
                StartDrag();
            }
        }

        private void Element_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                StopDrag();
        }

        private void Element_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                elementMenu.Show((sender as Element).PointToScreen(e.Location));
            }
        }

        private void Background_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                backgroundMenu.Show(PointToScreen(e.Location));
            }
        }

        private void createMenuItem_Click(object sender, EventArgs e)
        {
            AddElement("new element", null, PointToClient(MousePosition));
        }

        private void removeElementMenuItem_Click(object sender, EventArgs e)
        {
            RemoveElement((this as IElementContainer).Current);
        }

        private void changeImageMenuItem_Click(object sender, EventArgs e)
        {
            if (openImageDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    (this as IElementContainer).Current.Image = Image.FromFile(openImageDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("File Resolution Error");
                    return;
                }
            }
        }


        #endregion

        private Size GetCurrentElementSize()
        {
            var size = (new Element()).Size;
            return new Size((int)(size.Width * _factor), (int)(size.Height * _factor));
        }

        private void RePaint(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void WorldOfElements_Paint(object sender, PaintEventArgs e)
        {
            Size size = GetCurrentElementSize();
            Point item_pos, item_to_value_vector, value_pos_LeftUp, value_pos_LeftDown, value_pos_RightUp, value_pos_RightDown, p1_x, p1_y, p2_x, p2_y, value_pos_center, from_value_to_item, result;
            bool p1_x_not_parallel, p1_y_not_parallel, p2_x_not_parallel, p2_y_not_parallel;
            foreach (var item in GetTiesPos())
            {
                item_pos = new Point(item.Key.X + size.Width / 2, item.Key.Y + size.Height / 2);
                for (int i = 0; i < item.Value.Count; i++)
                {
                    item_to_value_vector = new Point(item.Value[i].X + size.Width / 2 - item.Key.X - size.Width / 2,
                       item.Value[i].Y + size.Height / 2 - item.Key.Y - size.Height / 2);
                    value_pos_LeftUp = new Point(item.Value[i].X, item.Value[i].Y);
                    value_pos_LeftDown = new Point(item.Value[i].X, item.Value[i].Y + size.Height);
                    value_pos_RightUp = new Point(item.Value[i].X + size.Width, item.Value[i].Y);
                    value_pos_RightDown = new Point(item.Value[i].X + size.Width, item.Value[i].Y + size.Height);
                    p1_x_not_parallel = false; p1_y_not_parallel = false;
                    p1_x_not_parallel = GetIntersectionPoint(item_pos, item_to_value_vector, value_pos_LeftUp, new Point(1, 0), out p1_x);
                    p1_y_not_parallel = GetIntersectionPoint(item_pos, item_to_value_vector, value_pos_LeftUp, new Point(0, 1), out p1_y);
                    p2_x_not_parallel = false; p2_y_not_parallel = false;
                    p2_x_not_parallel = GetIntersectionPoint(item_pos, item_to_value_vector, value_pos_RightDown, new Point(-1, 0), out p2_x);
                    p2_y_not_parallel = GetIntersectionPoint(item_pos, item_to_value_vector, value_pos_RightDown, new Point(0, -1), out p2_y);
                    value_pos_center = new Point(value_pos_LeftUp.X + size.Width / 2, value_pos_LeftUp.Y + size.Height / 2);
                    from_value_to_item = SubstractVector(item_pos, value_pos_center);
                    Point[] points = new Point[0];
                    if (p1_x_not_parallel)
                    {
                        Array.Resize(ref points, points.Length + 1);
                        points[points.Length - 1] = p1_x;
                    }
                    if (p1_y_not_parallel)
                    {
                        Array.Resize(ref points, points.Length + 1);
                        points[points.Length - 1] = p1_y;
                    }
                    if (p2_x_not_parallel)
                    {
                        Array.Resize(ref points, points.Length + 1);
                        points[points.Length - 1] = p2_x;
                    }
                    if (p2_y_not_parallel)
                    {
                        Array.Resize(ref points, points.Length + 1);
                        points[points.Length - 1] = p2_y;
                    }
                    for (int j = 0; j < points.Length; j++)
                    {
                        points[j] = SubstractVector(points[j], value_pos_center);
                    }
                    for (int j = 0; j < points.Length; j++)
                    {
                        if (!(from_value_to_item.X * points[j].X >= 0 && from_value_to_item.Y * points[j].Y >= 0))
                        {
                            for (int k = j; k < points.Length - 1; k++)
                            {
                                points[k] = points[k + 1];
                            }
                            Array.Resize(ref points, points.Length - 1);
                            j--;
                        }
                    }
                    result = GetSmallestVector(points);
                    result = AddVector(value_pos_center, result);
                    Point[] arrowPoints = GetArrowPoints(result, SubstractVector(result, item_pos), 30, 30);
                    pen.Width = LineWidth;
                    pen.Color = LineColor;
                    e.Graphics.DrawLine(pen, item_pos, result);
                    pen.Width = ArrowWidth;
                    pen.Color = ArrowColor;
                    e.Graphics.DrawLines(pen, arrowPoints);
                }
            }

            if ((this as IElementContainer).Current != null)
            {
                Element temp = (this as IElementContainer).Current;
                pen.Color = ElementHighlightColor;
                pen.Width = ElementHighlightWidth;
                e.Graphics.DrawRectangle(pen, temp.Left - ElementHighlightRectOffset, temp.Top - ElementHighlightRectOffset,
                    temp.Width + ElementHighlightRectOffset * 2, temp.Height + ElementHighlightRectOffset * 2);
            }
        }

        private void WheelScaleHandler(object sender, MouseEventArgs e)
        {
            ScaleFactor += (float)e.Delta / (Math.Abs(e.Delta) * 10);
        }

        private Point AddVector(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        private Point SubstractVector(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        private Size AddVector(Size p1, Size p2)
        {
            return new Size(AddVector(new Point(p1), new Point(p2)));
        }

        private Size SubstractVector(Size p1, Size p2)
        {
            return new Size(SubstractVector(new Point(p1), new Point(p2)));
        }

        private Point DivideXAndY(Point p, float devider)
        {
            return new Point((int)(p.X / devider), (int)(p.Y / devider));
        }

        private Point GetSmallestVector(params Point[] vectors)
        {
            Point temp = vectors.Length > 0 ? vectors[0] : new Point(0, 0);
            for (int i = 0; i < vectors.Length; i++)
            {

                if (Math.Abs(vectors[i].X) + Math.Abs(vectors[i].Y) < Math.Abs(temp.X) + Math.Abs(temp.Y))
                    temp = vectors[i];
            }
            return temp;
        }

        private Point[] GetArrowPoints(Point peek, Point vector, int length, int width)
        {
            if (vector.X == 0 && vector.Y == 0)
                return new Point[] { peek, peek, peek };
            double normal_x = (double)vector.X / Math.Sqrt((double)vector.X * vector.X + (double)vector.Y * vector.Y);
            double normal_y = (double)vector.Y / Math.Sqrt((double)vector.X * vector.X + (double)vector.Y * vector.Y);
            double invert_x = -normal_y;
            double invert_y = normal_x;
            double invert_x_1 = normal_y;
            double invert_y_1 = -normal_x;
            normal_x *= length * _factor; normal_y *= length * _factor;
            invert_x *= (float)width * _factor / 2; invert_y *= (float)width * _factor / 2;
            invert_x_1 *= (float)width * _factor / 2; invert_y_1 *= (float)width * _factor / 2;
            Point p1 = new Point((int)(peek.X - normal_x), (int)(peek.Y - normal_y));
            Point p2 = new Point((int)(p1.X + invert_x), (int)(p1.Y + invert_y));
            Point p3 = new Point((int)(p1.X + invert_x_1), (int)(p1.Y + invert_y_1));
            p1 = peek;
            return new Point[] { p2, p1, p3 };
        }

        private bool GetIntersectionPoint(Point p1, Point v1, Point p2, Point v2, out Point intPoint)
        {
            float A1 = -v1.Y; float B1 = v1.X; float C1 = v1.Y * p1.X - v1.X * p1.Y;
            float A2 = -v2.Y; float B2 = v2.X; float C2 = v2.Y * p2.X - v2.X * p2.Y;
            float x; float y;

            if ((A1 == 0 && A2 == 0) || (B1 == 0 && B2 == 0))
            {
                intPoint = new Point(0, 0);
                return false;
            }
            else if (A1 == 0 && B2 == 0)
            {
                x = -C2 / A2; y = -C1 / B1;
            }
            else if (A2 == 0 && B2 == 0)
            {
                x = -C1 / A1; y = -C2 / A2;
            }
            else if (A1 == 0)
            {
                x = (-C2 + (B2 * C1) / B1) / A2; y = -C1 / B1;
            }
            else if (B1 == 0)
            {
                x = -C1 / A1; y = (-C2 + (A2 * C1) / A1) / B2;
            }
            else if (A2 == 0)
            {
                x = (-C1 + (B1 * C2) / B2) / A1; y = -C2 / B2;
            }
            else if (B2 == 0)
            {
                x = -C2 / A2; y = (-C1 + (A1 * C2) / A2) / B1;
            }
            else
            {
                x = y = 0;
            }

            intPoint = new Point((int)x, (int)y);
            return true;
        }
    }
}
