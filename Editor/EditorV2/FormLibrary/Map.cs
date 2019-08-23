using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormLibrary
{
    public partial class Map : UserControl
    {
        public Map()
        {
            InitializeComponent();
        }

        public int DefaultPointRadius = 2;
        public Color DefaultPointColor = Color.Red;
        public int HighlightPointRadius = 3;
        public Color HighlightPointColor = Color.Green;

        public int DefaultLineWidth = 1;
        public Color DefaultLineColor = Color.Black;
        public int HighlightLineRadius = 2;
        public Color HighlightLineColor = Color.Blue;

        public int SubWindowLineWidth = 1;
        public Color SubWindowLineColor = Color.Black;

        public event MouseEventHandler MapMouseClick
        {
            add { MouseClick += value; }
            remove { MouseClick -= value; }
        }

        public IElementContainer ElementContainer { get; private set; }
        public IWorld World { get; private set; }

        private Size worldSize => World.Size;
        private Size visibleSize => World.VisibleSize;
        private Point worldCenter => World.Center;
        private Point center => new Point(Width / 2, Height / 2);

        private const int offset = 0;
        private Size validSize => new Size(Width - offset * 2, Height - offset * 2);

        #region TransformLogic

        private Point TransformToLocalSpace(Point point)
        {
            float x_factor = (float)validSize.Width / worldSize.Width;
            float y_factor = (float)validSize.Height / worldSize.Height;
            return new Point((int)(point.X * x_factor), (int)(point.Y * y_factor));
        }

        private Size TransformToLocalSpace(Size size)
        {
            return new Size(TransformToLocalSpace(new Point(size)));
        }

        public Point TransformToLocalSpace(Size worldSize, Point point)
        {
            float x_factor = (float)validSize.Width / worldSize.Width;
            float y_factor = (float)validSize.Height / worldSize.Height;
            return new Point((int)(point.X * x_factor), (int)(point.Y * y_factor));
        }

        public Size TransformToLocalSpace(Size worldSize, Size size)
        {
            return new Size(TransformToLocalSpace(worldSize, new Point(size)));
        }

        private Point TransformToWorldSpace(Point point)
        {
            float x_factor = (float)worldSize.Width / validSize.Width;
            float y_factor = (float)worldSize.Height / validSize.Height;
            return new Point((int)(point.X * x_factor), (int)(point.Y * y_factor));
        }

        private Size TransformToWorldSpace(Size size)
        {
            return new Size(TransformToWorldSpace(new Point(size)));
        }

        public Point TransformToWorldSpace(Size worldSize, Point point)
        {
            float x_factor = (float)worldSize.Width / validSize.Width;
            float y_factor = (float)worldSize.Height / validSize.Height;
            return new Point((int)(point.X * x_factor), (int)(point.Y * y_factor));
        }

        public Size TransformToWorldSpace(Size worldSize, Size size)
        {
            return new Size(TransformToWorldSpace(new Point(size)));
        }

        private Point TranformToLocalWithCenter(Point point)
        {
            Point location = new Point(point.X - worldCenter.X, point.Y - worldCenter.Y);
            location = TransformToLocalSpace(location);
            location = new Point(location.X + center.X, location.Y + center.Y);
            return location;
        }

        #endregion

        public void ConnectWorld(IWorld world)
        {
            World = world;
            World.WorldChanged += RePaint;
        }

        public void ConnectElementContainer(IElementContainer elementContainer)
        {
            ElementContainer = elementContainer;
            ElementContainer.FocusChanged += RePaint;
        }

        public void RePaint(object Sender, EventArgs e)
        {
            Invalidate();
        }

        private Size GetNormalizedSize()
        {
            float a = World.Size.Width / World.Size.Height;
            float b = Width / Height;
            Size normalizedSize = worldSize;
            if (a > b)
                normalizedSize.Height = (int)(World.Size.Width / b);
            else if (a < b)
                normalizedSize.Width = (int)(worldSize.Height * b);
            return normalizedSize;
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            if (World != null && ElementContainer != null)
            {
                Pen pen = new Pen(DefaultPointColor, DefaultPointRadius);
                foreach (var item in ElementContainer.ItemsCoords)
                {
                    Point location = TranformToLocalWithCenter(item);
                    if (ElementContainer.Current!=null && ElementContainer.Current.Location == item)
                    {
                        e.Graphics.DrawEllipse(new Pen(HighlightPointColor,HighlightPointRadius),
                            location.X - offset, location.Y - offset, DefaultPointRadius, DefaultPointRadius);
                    }
                    else
                    {
                        e.Graphics.DrawEllipse(pen,
                            location.X - offset, location.Y - offset, DefaultPointRadius, DefaultPointRadius);
                    }
                }

                pen.Color = DefaultLineColor;
                pen.Width = DefaultLineWidth;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                foreach (var p1 in ElementContainer.LinesCoords)
                {
                    foreach (var p2 in p1.Value)
                    {
                        Point location1 = TranformToLocalWithCenter(p1.Key);
                        Point location2 = TranformToLocalWithCenter(p2);

                        e.Graphics.DrawLine(pen,
                            location1.X - offset, location1.Y - offset, location2.X - offset, location2.Y - offset);
                    }
                }

                pen.Color = SubWindowLineColor;
                pen.Width = SubWindowLineWidth;
                Size localVisibleSize = TransformToLocalSpace(visibleSize);
                Point windowPosition = TranformToLocalWithCenter(new Point(0, 0));
                e.Graphics.DrawRectangle(pen,
                    windowPosition.X, windowPosition.Y, localVisibleSize.Width, localVisibleSize.Height);
            }
        }

        private void Map_SizeChanged(object sender, EventArgs e)
        {
            RePaint(null, null);
        }
    }
}
