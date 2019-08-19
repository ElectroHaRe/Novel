using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NovelFormLibrary
{
    public partial class Map : UserControl
    {
        public int CircleRadius = 2;
        public Color CircleDefaultColor = Color.Red;


        public int HighlightCircleRadius = 3;
        public Color CircleHighlightColor = Color.Green;
        private int[] HighlightPointIndex = new int[0];

        public int LineWidth = 1;
        public Color LineDefaultColor = Color.Black;
        public Color LineHighlightColor = Color.Green;

        public int SubWindowWidth = 1;
        public Color SubWindowColor = Color.Black;

        private Size subWindowSize { get; set; }
        private Point subWindowPosition { get; set; }

        private Size worldSize;

        public Size WindowSize
        {
            get
            {
                Point temp = TransformLocalToWorldSpaceCoords(WorldSize, new Point(subWindowSize));
                return new Size(temp);
            }
            set
            {
                subWindowSize = new Size(TransformWorldToLocalSpaceCoords(WorldSize, new Point(value)));
            }
        }
        public Point WindowPosition
        {
            get
            {
                return TransformLocalToWorldSpaceCoords(WorldSize, subWindowPosition);
            }
            set
            {
                subWindowPosition = TransformWorldToLocalSpaceCoords(WorldSize, value);
            }
        }
        public Size WorldSize
        {
            get => worldSize;
            set
            {
                Size tempWindowSize = subWindowSize;
                Point tempWindowPosition = subWindowPosition;
                worldSize = value;
                float factor = (float)Width/Height;
                if (((float)value.Width / value.Height) > factor)
                {
                    worldSize.Height = (int)(value.Width / factor);
                }
                else
                {
                    worldSize.Width = (int)(value.Height * factor);
                }
                subWindowPosition = tempWindowPosition;
                subWindowSize = tempWindowSize;
            }
        }

        public Point WorldCenter = new Point(0, 0);

        public int Indent = 5;
        private Size validSize => new Size(Size.Width - Indent * 2, Size.Height - Indent * 2);
        private Point validPosition => new Point(Indent, Indent);

        private int length => CirclesAndLinesCoords.Length;
        private int count = 0;
        private KeyValuePair<Point, Point[]>[] CirclesAndLinesCoords = new KeyValuePair<Point, Point[]>[4];

        public Map() : this(new Size(1, 1), new Size(1, 1))
        {
            InitializeComponent();
        }

        public Map(Size windowSize, Size worldSize)
        {
            WindowSize = windowSize;
            WorldSize = worldSize;
            WindowPosition = new Point(0, 0);
        }

        public Map(Size windowSize, Size worldSize, Point windowPosition) : this(windowSize, worldSize)
        {
            WindowPosition = windowPosition;
        }

        public void MarkPointAsHighlight(int index)
        {
            Array.Resize(ref HighlightPointIndex, HighlightPointIndex.Length);
            HighlightPointIndex[HighlightPointIndex.Length - 1] = index;
        }

        public void AddCircleAndLinesCoords(Size windowSize, Size worldSize, Point worldCenter, Point circleCoords, params Point[] lineDistinationsCoords)
        {
            if (length == count)
                Array.Resize(ref CirclesAndLinesCoords, length * 2);
            WindowSize = windowSize;
            WorldSize = worldSize;
            this.WorldCenter = worldCenter;
            for (int i = 0; i < lineDistinationsCoords.Length; i++)
            {
                lineDistinationsCoords[i] = TransformWorldToLocalSpaceCoords(WorldSize, lineDistinationsCoords[i]);
            }
            CirclesAndLinesCoords[count] = new KeyValuePair<Point, Point[]>(TransformWorldToLocalSpaceCoords(WorldSize, circleCoords), lineDistinationsCoords);
            count++;
        }

        public void UpdateCoords(int element, Point newCoords)
        {
            newCoords = TransformWorldToLocalSpaceCoords(worldSize, newCoords);

            if (element >= 0 || element < count)
            {
                CirclesAndLinesCoords[element] = new KeyValuePair<Point, Point[]>(newCoords, CirclesAndLinesCoords[element].Value);
                Invalidate();
            }
        }

        public void RemoveLine(int element, int lineElement)
        {
            if (element < 0 || element > count - 1)
                return;
            if (lineElement < 0 || lineElement > CirclesAndLinesCoords[element].Value.Length - 1)
                return;
            Point[] temp = CirclesAndLinesCoords[element].Value;
            for (int i = lineElement; i < temp.Length - 1; i++)
            {
                temp[i] = temp[i + 1];
            }
            Array.Resize(ref temp, temp.Length - 1);
            CirclesAndLinesCoords[element] = new KeyValuePair<Point, Point[]>(CirclesAndLinesCoords[element].Key, temp);
            Invalidate();
        }

        public void RemoveCircle(int element)
        {
            if (element < 0 || element > count - 1)
                return;
            for (int i = element; i < count - 1; i++)
            {
                CirclesAndLinesCoords[i] = CirclesAndLinesCoords[i + 1];
            }
            count--;
            Invalidate();
        }

        public void UpdateWindowPosition(Point newPosition)
        {
            WindowPosition = newPosition;
            Invalidate();
        }

        public void UpdateWindowSize(Size newSize)
        {
            WindowSize = newSize;
            Invalidate();
        }

        public Point TransformWorldToLocalSpaceCoords(Point coords)
        {
            float x_coeff = (float)validSize.Width / worldSize.Width;
            float y_coeff = (float)validSize.Height / worldSize.Height;

            return new Point((int)(coords.X * x_coeff), (int)(coords.Y * y_coeff));
        }

        public Point TransformLocalToWorldSpaceCoords(Point coords)
        {
            float x_coeff = (float)worldSize.Width / validSize.Width;
            float y_coeff = (float)worldSize.Height / validSize.Height;

            return new Point((int)(coords.X * x_coeff), (int)(coords.Y * y_coeff));
        }

        public Point TransformWorldToLocalSpaceCoords(Size worldSize, Point coords)
        {
            float x_coeff = (float)validSize.Width / worldSize.Width;
            float y_coeff = (float)validSize.Height / worldSize.Height;

            return new Point((int)(coords.X * x_coeff), (int)(coords.Y * y_coeff));
        }

        public Point TransformLocalToWorldSpaceCoords(Size worldSize, Point coords)
        {
            float x_coeff = worldSize.Width / validSize.Width;
            float y_coeff = worldSize.Height / validSize.Height;

            return new Point((int)(coords.X * x_coeff), (int)(coords.Y * y_coeff));
        }

        public Point TransformWorldToLocalSpaceCoords(Size worldSize, Size localSize, Point coords)
        {
            float x_coeff = localSize.Width / worldSize.Width;
            float y_coeff = localSize.Height / worldSize.Height;

            return new Point((int)(coords.X * x_coeff), (int)(coords.Y * y_coeff));
        }

        public Point TransformLocalToWorldSpaceCoords(Size worldSize, Size localSize, Point coords)
        {
            float x_coeff = worldSize.Width / localSize.Width;
            float y_coeff = worldSize.Height / localSize.Height;

            return new Point((int)(coords.X * x_coeff), (int)(coords.Y * y_coeff));
        }

        private void DrawCircle(Point position, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(CircleDefaultColor, CircleRadius), new Rectangle(position.X, position.Y, CircleRadius, CircleRadius));
        }

        private void DrawLine(Point pt1, Point pt2, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(LineDefaultColor, LineWidth), pt1, pt2);
        }

        private void DrawSubWindow(Size windowSize, Point windowPosition, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(SubWindowColor, SubWindowWidth), windowPosition.X, windowPosition.Y, windowSize.Width, windowSize.Height);
        }

        private void DrawCircle(Point position, int indent, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(CircleDefaultColor, CircleRadius), new Rectangle(position.X + indent, position.Y + indent, CircleRadius, CircleRadius));
        }

        private void DrawLine(Point pt1, Point pt2, int indent, PaintEventArgs e)
        {
            pt1.X += indent; pt2.X += indent;
            pt1.Y += indent; pt2.Y += indent;
            e.Graphics.DrawLine(new Pen(LineDefaultColor, LineWidth), pt1, pt2);
        }

        private void DrawSubWindow(Size windowSize, Point windowPosition, int indent, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(SubWindowColor, SubWindowWidth), windowPosition.X + indent, windowPosition.Y + indent, windowSize.Width, windowSize.Height);
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            Point CenterOffset = new Point(WorldCenter.X - WorldSize.Width / 2, WorldCenter.Y - WorldSize.Height / 2);
            Point localOffset = TransformWorldToLocalSpaceCoords(CenterOffset);
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < CirclesAndLinesCoords[i].Value.Length; j++)
                {
                    DrawLine(new Point(CirclesAndLinesCoords[i].Key.X - localOffset.X, CirclesAndLinesCoords[i].Key.Y - localOffset.Y), 
                        new Point(CirclesAndLinesCoords[i].Value[j].X - localOffset.X, CirclesAndLinesCoords[i].Value[j].Y - localOffset.Y), 
                        Indent, e);
                }
                DrawCircle(new Point(CirclesAndLinesCoords[i].Key.X - localOffset.X, CirclesAndLinesCoords[i].Key.Y - localOffset.Y),
                    Indent, e);
            }
            DrawSubWindow(subWindowSize, 
                new Point(subWindowPosition.X - localOffset.X, subWindowPosition.Y - localOffset.Y),
                Indent / 2, e);
        }
    }
}
