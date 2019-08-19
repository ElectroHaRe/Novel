using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NovelFormLibrary;

namespace NovelEditor.MainSpace
{
    public partial class MainSpaceBox : UserControl
    {
        public MainSpaceBox()
        {
            InitializeComponent();
            updater.Interval = 1000 / fps;
            updater.Tick += DragBackground;
        }

        /// <summary>
        /// Image - новое изображение узла, int - индекс узла, в котором произвелось обновление изображения
        /// </summary>
        public event Action<Image, int> OnChangeNodeImage;
        public event Action<NodeInfo> OnNodeCreation;
        /// <summary>
        /// Первые 3 аргумета - изображение, текст и индекс узла, который потерял фокус. Последний аргумент - индекс текущего узла в фокусе
        /// </summary>
        public event Action<Image, string, int, int> OnNodeFocusChanged;
        public event EventHandler OnDragBackground;
        /// <summary>
        /// В качестве аргумента передаётся индекс узла
        /// </summary>
        public event Action<int> OnDragNodeBox;
        public event Action<int> OnNodeBoxClick;

        public Point WindowPosition = new Point(0, 0);

        private int fps = 200;
        private Timer updater = new Timer();

        private const int MaxNodeWidth = 250;
        private const int MaxNodeHeight = 160;

        private float scaleFactor = 0.5f;

        private class AdvancedNode
        {
            public AdvancedNode(Node node, Point staticPosition)
            {
                this.node = node;
                this.StaticPosition = staticPosition;
            }
            public readonly Node node;

            public string Text => node.Text;
            public Image Image => node.Image;
            public int index => node.index;

            public Point StaticPosition { get; set; }
        }

        public struct NodeInfo
        {
            public NodeInfo(Image image, string text, int index, Point position)
            {
                this.Image = image;
                this.Text = text;
                this.index = index;
                this.Position = position;
            }

            public readonly Image Image;
            public readonly string Text;
            public readonly int index;
            public readonly Point Position;
        }

        private List<AdvancedNode> nodes = new List<AdvancedNode>();
        private Point mousePositionOnDragStart = new Point(0, 0);

        private int currentNodeIndex = 0;

        public Size GetSubSpaceSize()
        {
            int min_y = WindowPosition.Y; int min_x = WindowPosition.X;
            int max_y = WindowPosition.Y + this.Size.Height; int max_x = WindowPosition.X + this.Size.Width;
            foreach (var item in nodes)
            {
                if (item.node.Top > max_y)
                    max_y = item.node.Top;
                if (item.node.Left > max_x)
                    max_x = item.node.Left;
                if (item.node.Left < min_x)
                    min_x = item.node.Left;
                if (item.node.Top < min_y)
                    min_y = item.node.Top;
            }
            return new Size(max_x - min_x > this.Width ? max_x - min_x : this.Width, max_y - min_y > this.Height ? max_y - min_y : this.Height);
        }

        public Point GetSubSpaceCentrPoint()
        {
            int min_y = WindowPosition.Y; int min_x = WindowPosition.X;
            int max_y = WindowPosition.Y + this.Size.Height; int max_x = WindowPosition.X + this.Size.Width;
            foreach (var item in nodes)
            {
                if (item.node.Top > max_y)
                    max_y = item.node.Top;
                if (item.node.Left > max_x)
                    max_x = item.node.Left;
                if (item.node.Left < min_x)
                    min_x = item.node.Left;
                if (item.node.Top < min_y)
                    min_y = item.node.Top;
            }
            return new Point((min_x + max_x) / 2, (min_y + max_y) / 2);
        }

        public NodeInfo[] GetAllNodes()
        {
            NodeInfo[] _nodes = new NodeInfo[nodes.Count];
            for (int i = 0; i < nodes.Count; i++)
            {
                _nodes[i] = new NodeInfo(nodes[i].Image, nodes[i].Text, nodes[i].index, nodes[i].node.Location);
            }
            return _nodes;
        }

        public void AddNodes(NodeInfo[] nodesInfo)
        {
            foreach (var item in nodesInfo)
            {
                AddNodeBox(item.Text, item.Image, item.Position);
            }
        }

        public MainSpaceBox AddNodeBox(string text, Image image, Point position)
        {
            Node temp = CreateNodeBox(text, image);
            temp.Location = position;
            AddNodeBoxToList(temp);
            return this;
        }

        public void SetNodesOffset(Point offsetVector)
        {
            foreach (var item in nodes)
            {
                item.node.Left += offsetVector.X;
                item.node.Top += offsetVector.Y;
            }
        }

        private void AddNodeBoxToList(Node newNode)
        {
            newNode.OnNodeBoxMouseDown += OnNodeBoxMouseDown;
            newNode.OnPictureBoxClick += NodePictureBox_MouseClick;
            newNode.OnNodeBoxMouseUp += OnNodeBoxMouseUp;
            newNode.OnNodeBoxMouseDown += NewNode_OnNodeBoxMouseDown;
            newNode.OnNodeBoxClick += (object obj, MouseEventArgs e) => OnNodeBoxClick?.Invoke(currentNodeIndex);
            newNode.Width = (int)(MaxNodeWidth * scaleFactor);
            newNode.Height = (int)(MaxNodeHeight * scaleFactor);
            nodes.Add(new AdvancedNode(newNode, newNode.Location));
        }

        private void NewNode_OnNodeBoxMouseDown(object sender, MouseEventArgs e)
        {
            StartDragNode();
        }

        private void OnNodeBoxMouseUp(object sender, MouseEventArgs e)
        {
            EndDragNode();
        }

        private Node CreateNodeBox()
        {
            Node temp = new Node();
            temp.Location = this.PointToClient(MousePosition);
            temp.index = nodes.Count;
            temp.CreateControl();
            this.Controls.Add(temp);
            return temp;
        }

        private Node CreateNodeBox(string text, Image image)
        {
            Node temp = new Node();
            temp.Location = this.PointToClient(MousePosition);
            temp.Text = text;
            temp.Image = image;
            temp.index = nodes.Count;
            temp.CreateControl();
            this.Controls.Add(temp);
            return temp;
        }

        private void StartDragBackground()
        {

            lastWindowPosition = WindowPosition;
            mousePositionOnDragStart = MousePosition;
            updater.Start();
        }

        private Point lastWindowPosition;

        private void StartDragNode()
        {
            mousePositionOnDragStart = MousePosition;
            updater.Tick -= DragBackground;
            updater.Tick += DragNode;
            updater.Start();
        }

        private void DragNode(object sender, EventArgs e)
        {
            Point vector = new Point(MousePosition.X - mousePositionOnDragStart.X, MousePosition.Y - mousePositionOnDragStart.Y);
            nodes[currentNodeIndex].node.Left = nodes[currentNodeIndex].StaticPosition.X + vector.X;
            nodes[currentNodeIndex].node.Top = nodes[currentNodeIndex].StaticPosition.Y + vector.Y;
            OnDragNodeBox?.Invoke(currentNodeIndex);
        }

        private void EndDragNode()
        {
            updater.Stop();
            nodes[currentNodeIndex].StaticPosition = nodes[currentNodeIndex].node.Location;
            updater.Tick -= DragNode;
            updater.Tick += DragBackground;
        }

        private void DragBackground(object sender, EventArgs e)
        {
            Point vector = new Point(MousePosition.X - mousePositionOnDragStart.X, MousePosition.Y - mousePositionOnDragStart.Y);
            foreach (var item in nodes)
            {
                item.node.Left = item.StaticPosition.X + vector.X;
                item.node.Top = item.StaticPosition.Y + vector.Y;
            }
            OnDragBackground?.Invoke(this, e);
        }

        private void EndDragBackground()
        {
            updater.Stop();
            foreach (var item in nodes)
            {
                item.StaticPosition = item.node.Location;
            }
        }

        private void NodePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                nodeImageContextMenu.Show((sender as Control).PointToScreen(e.Location));
            }
        }

        private void nodeImageContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (openPictureDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    nodes[currentNodeIndex].node.Image = Image.FromFile(openPictureDialog.FileName);
                    OnChangeNodeImage?.Invoke(nodes[currentNodeIndex].node.Image, currentNodeIndex);
                }
                catch
                {
                    return;
                }
            }
        }

        private void MainSpaceBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                backgroundContextMenu.Show(this.PointToScreen(e.Location));
            }
        }

        private void backgroundContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Node temp = CreateNodeBox();
            AddNodeBoxToList(temp);
            OnNodeCreation?.Invoke(new NodeInfo(temp.Image, temp.Text, temp.index, temp.Location));
        }

        private void MainSpaceBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                StartDragBackground();
        }

        private void MainSpaceBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                EndDragBackground();
        }

        private void OnNodeBoxMouseDown(object sender, MouseEventArgs e)
        {
            int lastIndex = currentNodeIndex;
            currentNodeIndex = (sender as Node).index;
            if (nodes.Count > 0)
                OnNodeFocusChanged?.Invoke(nodes[lastIndex].Image, nodes[lastIndex].Text, nodes[lastIndex].index, currentNodeIndex);
        }
    }
}
