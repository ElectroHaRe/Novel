using System;
using System.Windows.Forms;
using NovelFormLibrary;

namespace NovelEditor
{
    public partial class TieNodesState : UserControl
    {
        public TieNodesState()
        {
            InitializeComponent();
            StartNode.Enabled = destinationNode.Enabled = false;
            destinationNodeActive = false;
            destinationNode.index = -1;
            fromNode.index = -1;
        }

        private const int MaxWidth = 250;
        private const int VIndent = 6;

        private bool destinationNodeActive
        {
            get => destinationNode.Visible;
            set => chooseNodeLabel.Enabled = chooseNodeLabel.Visible = 
                !(tieButton.Enabled = tieButton.Visible = destinationNode.Visible = value);
        }
        private bool tieNodeButtonActive
        {
            get => tieButton.Enabled && tieButton.Visible;
            set
            {
                tieButton.Enabled = tieButton.Visible = value;
                TieNodesState_SizeChanged(null, null);
            }
        }
        private bool chooseNodeLabelActive
        {
            get => chooseNodeLabel.Enabled && chooseNodeLabel.Visible;
            set => chooseNodeLabel.Enabled = chooseNodeLabel.Visible = value;
        }

        public bool Active
        {
            get => this.Enabled && this.Visible;
            set => this.Enabled = this.Visible = value;
        }

        public Node StartNode
        {
            get => fromNode;
            private set
            {
                if (value == null || value.index == -1)
                {
                    fromNode.Image = null;
                    fromNode.Text = null;
                    fromNode.index = -1;
                }
                else
                {
                    fromNode.Image = value.Image;
                    fromNode.Text = value.Text;
                    fromNode.index = value.index;
                }
            }
        }
        public Node DestinationNode
        {
            get => destinationNode;
            private set
            {
                if (value == null || value.index == -1)
                {
                    destinationNodeActive = true;
                    tieNodeButtonActive = true;
                    chooseNodeLabelActive = false;
                    destinationNode.Image = null;
                    destinationNode.Text = null;
                    destinationNode.index = -1;
                }
                else
                {
                    chooseNodeLabelActive = true;
                    destinationNodeActive = false;
                    tieNodeButtonActive = false;
                    destinationNode.Image = value.Image;
                    destinationNode.Text = value.Text;
                    destinationNode.index = value.index;
                }
            }

        }
        public string TieText
        {
            get => tieText.Text;
            set => tieText.Text = value;
        }

        public void InitializeMenu(Node from, string tieText)
        {
            StartNode = from;
            TieText = tieText;
        }

        public void SetDestinationNode(Node destination)
        {
            DestinationNode = destination;
        }

        public event EventHandler TieNodesButtonClick
        {
            add { tieButton.Click += value; }
            remove { tieButton.Click -= value; }
        }

        public event EventHandler CancelButtonClick
        {
            add { cancelButton.Click += value; }
            remove { cancelButton.Click -= value; }
        }

        private void TieNodesState_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > MaxWidth)
                this.Width = MaxWidth;
            int minSize = fromNode.Height + VIndent + tieText.Height + VIndent + destinationNode.Height + VIndent + tieButton.Height
                + VIndent + cancelButton.Height;
            if (this.Height < minSize)
            {
                this.Height = minSize;
            }
            fromNode.Width = destinationNode.Width = tieText.Width = tieButton.Width = cancelButton.Width = this.Width;
            fromNode.Left = tieText.Left = destinationNode.Left = tieButton.Left = cancelButton.Left = 0;
            chooseNodeLabel.Left = this.Width / 2 - chooseNodeLabel.Width / 2;
            fromNode.Top = 0;
            tieText.Top = fromNode.Top + fromNode.Height + VIndent;
            destinationNode.Top = tieText.Top + tieText.Height + VIndent;
            chooseNodeLabel.Top = destinationNode.Top + destinationNode.Height / 2 - chooseNodeLabel.Height / 2;
            tieButton.Top = destinationNode.Top + destinationNode.Height + VIndent;
            if (destinationNodeActive)
                cancelButton.Top = tieButton.Top + tieButton.Height + VIndent;
            else cancelButton.Top = tieButton.Top;
        }

        public void RemoveAll()
        {
            TieText = string.Empty;
            StartNode = null;
            DestinationNode = null;
        }
    }
}
