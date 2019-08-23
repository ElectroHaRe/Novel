using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormLibrary
{
    public partial class FunctionalBox : UserControl
    {
        public FunctionalBox()
        {
            InitializeComponent();
            SwitchState(State.@default);
        }

        private const int MaxWidth = 280;
        private const int VOffset = 5;
        private const int HOffset = 15;

        public event EventHandler SaveClick
        {
            add { saveButton.Click += value; }
            remove { saveButton.Click -= value; }
        }
        public event EventHandler LoadClick
        {
            add { loadButton.Click += value; }
            remove { loadButton.Click -= value; }
        }
        public event EventHandler ExitClick
        {
            add { exitButton.Click += value; }
            remove { exitButton.Click -= value; }
        }

        /// <summary>
        /// sender - CompositeTextBox
        /// </summary>
        public event EventHandler MinusClick;
        /// <summary>
        /// sender - CompositeTextBox
        /// </summary>
        public event EventHandler ArrowClick;
        public new event EventHandler TextChanged;
        /// <summary>
        /// sender - FunctionalBox
        /// </summary>
        public event EventHandler PlusClick;

        public event EventHandler MinusMouseEnter;
        public event EventHandler MinusMouseLeave;
        public event EventHandler ArrowMouseEnter;
        public event EventHandler ArrowMouseLeave;
        public event EventHandler PlusMouseEnter
        {
            add { plusButton.MouseEnter += value; }
            remove { plusButton.MouseEnter -= value;
 }
        }
        public event EventHandler PlusMouseLeave
        {
            add { plusButton.MouseLeave += value; }
            remove { plusButton.MouseLeave -= value; }
        }

        public event MouseEventHandler MapMouseClick
        {
            add { map.MapMouseClick += value; }
            remove { map.MapMouseClick -= value; }
        }


        public event EventHandler TieClick
        {
            add { tieButton.Click += value; }
            remove { tieButton.Click -= value; }
        }
        public event EventHandler CancelClick
        {
            add { cancelButton.Click += value; }
            remove { cancelButton.Click -= value; }
        }

        private List<CompositeTextBox> compositeBoxList = new List<CompositeTextBox>();

        private enum State { @default, edit, tie }
        private State state = State.@default;

        private Dictionary<Element, string> ties => map.ElementContainer.Current.ties;
        private List<CompositeTextBox> boxes = new List<CompositeTextBox>();

        private Element[] elements = new Element[2];

        public void ConnectWorld(IWorld world)
        {
            map.ConnectWorld(world);
        }

        public void ConnectElementContainer(IElementContainer container)
        {
            container.FocusChanged += FocusChangedHandler;
            container.OnRemoveTie += RemoveItemClickHandler;
            map.ConnectElementContainer(container);
        }

        private void AddCompositeTextBox(string text, Element arrowElement)
        {
            var temp = new CompositeTextBox();
            temp.Width = Width - HOffset * 2;
            temp.Left = HOffset;
            temp.Top = boxes.Count > 0 ? boxes[boxes.Count-1].Top + VOffset + boxes[boxes.Count-1].Height : VOffset;
            temp.Text = text;
            temp.MinusClick += MinusClick;
            temp.ArrowClick += ArrowClick;
            temp.textChanged += TextChanged;
            temp.MinusMouseEnter += MinusMouseEnter;
            temp.ArrowMouseEnter += ArrowMouseEnter;
            temp.MinusMouseLeave += MinusMouseLeave;
            temp.ArrowMouseLeave += ArrowMouseLeave;
            temp.Enabled = temp.Visible = true;
            temp.SetArrowElement(arrowElement);
            temp.CreateControl();
            boxes.Add(temp);
            zoneBox.Panel1.Controls.Add(temp);
        }

        private void ClearAllElementsOfStates()
        {
            foreach (var item in boxes)
            {
                zoneBox.Panel1.Controls.Remove(item);
            }
            boxes.Clear();
            fromElement.Enabled = fromElement.Visible = false;
            newTieText.Enabled = newTieText.Visible = false;
            toElement.Enabled = toElement.Visible = false;
            noSelectLabel.Enabled = noSelectLabel.Visible = false;
            tieButton.Enabled = false; tieButton.Visible = false;
            cancelButton.Enabled = cancelButton.Visible = false;
            plusButton.Enabled = plusButton.Visible = false;
            elements = new Element[2];
            saveButton.Enabled = saveButton.Visible = false;
            loadButton.Enabled = loadButton.Visible = false;
            exitButton.Enabled = exitButton.Visible = false;
            plusButton.Enabled = plusButton.Visible = false;
        }

        private void SwitchState(State @new)
        {
            switch (@new)
            {
                case State.@default:
                    ClearAllElementsOfStates();
                    saveButton.Enabled = saveButton.Visible = true;
                    loadButton.Enabled = loadButton.Visible = true;
                    exitButton.Enabled = exitButton.Visible = true;
                    break;
                case State.edit:
                    ClearAllElementsOfStates();
                    foreach (var item in ties)
                    {
                        AddCompositeTextBox(item.Value, item.Key);
                    }
                    plusButton.Left = Width / 2 - plusButton.Width / 2;
                    plusButton.Top = boxes.Count > 0 ? boxes[boxes.Count - 1].Top + boxes[boxes.Count - 1].Height : 0;
                    plusButton.Enabled = plusButton.Visible = true;
                    break;
                case State.tie:
                    ClearAllElementsOfStates();
                    fromElement.Enabled = fromElement.Visible = true;
                    newTieText.Enabled = newTieText.Visible = true;
                    toElement.Enabled = toElement.Enabled = false;
                    noSelectLabel.Enabled = noSelectLabel.Visible = true;
                    tieButton.Enabled = false; tieButton.Visible = true;
                    cancelButton.Enabled = cancelButton.Visible = true;
                    elements[0] = map.ElementContainer.Current;
                    fromElement.Text = elements[0].Text; fromElement.Image = elements[0].Image;
                    break;
                default:
                    break;
            }
            state = @new;
            FunctionalBox_SizeChanged(null, null);
            Invalidate();
        }

        private void FocusChangedHandler(object sender, EventArgs e)
        {
            if (map.ElementContainer.Current != null && state != State.edit && state != State.tie)
            {
                SwitchState(State.edit);
            }
            else if (map.ElementContainer.Current == null && state != State.@default && state != State.tie)
            {
                SwitchState(State.@default);
            }
            else if (map.ElementContainer.Current != null && state == State.tie && elements[0] != map.ElementContainer.Current)
            {
                elements[1] = map.ElementContainer.Current;
                toElement.Text = elements[1].Text;
                toElement.Image = elements[1].Image;
                noSelectLabel.Enabled = noSelectLabel.Visible = false;
                toElement.Enabled = toElement.Visible = true;
                tieButton.Enabled = tieButton.Visible = true;
            }
            else if (map.ElementContainer.Current != null && state == State.edit)
            {
                SwitchState(State.edit);
            }
        }

        private void RemoveItemClickHandler(object sender, EventArgs e)
        {
            SwitchState(State.@default);
            SwitchState(State.edit);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            SwitchState(State.@default);
        }

        private void tieButton_Click(object sender, EventArgs e)
        {
            map.ElementContainer.AddTie(elements[0], elements[1], newTieText.Text);
            SwitchState(State.@default);
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            SwitchState(State.tie);
            PlusClick?.Invoke(this, e);
        }

        private void FunctionalBox_SizeChanged(object sender, EventArgs e)
        {
            Width = Width > MaxWidth ? MaxWidth : Width;
            if (state == State.@default)
            {
                saveButton.Top = VOffset; loadButton.Top = VOffset * 2 + saveButton.Height;
                exitButton.Top = saveButton.Height + loadButton.Height + VOffset * 3;
                saveButton.Width = loadButton.Width = exitButton.Width = Width - HOffset * 2;
                saveButton.Left = Width / 2 - saveButton.Width / 2;
                loadButton.Left = Width / 2 - loadButton.Width / 2;
                exitButton.Left = Width/ 2 - exitButton.Width / 2;
            }
            else if (state == State.edit)
            {
                for (int i = 0; i < boxes.Count; i++)
                {
                    if (i == 0)
                        boxes[i].Top = VOffset;
                    else boxes[i].Top = boxes[i - 1].Top + boxes[i - 1].Height + VOffset;
                    boxes[i].Width = Width - HOffset * 2;
                    boxes[i].Left = Width / 2 - boxes[i].Width / 2;
                }
                plusButton.Left = Width / 2 - plusButton.Width / 2;
                plusButton.Top = boxes.Count > 0 ? boxes[boxes.Count - 1].Top + boxes[boxes.Count - 1].Height : VOffset;
            }
            else if (state == State.tie)
            {
                fromElement.Top = VOffset * 2;
                fromElement.Width = Width - HOffset * 2;
                newTieText.Top = fromElement.Top + fromElement.Height + VOffset * 2;
                newTieText.Width = Width - HOffset * 2;
                toElement.Top = newTieText.Top + newTieText.Height + VOffset * 2;
                toElement.Width = Width - HOffset * 2;

                cancelButton.Left = Width - HOffset - cancelButton.Width;

                fromElement.Left = Width / 2 - fromElement.Width / 2;
                newTieText.Left = Width / 2 - newTieText.Width / 2;
                toElement.Left = Width / 2 - toElement.Width / 2;
            }
            searchBox.Width = Width - HOffset * 2;
            searchBox.Top = VOffset * 2;
            searchBox.Left = Width / 2 - searchBox.Width / 2;
            map.Width = Width - HOffset * 2;
            map.Height = zoneBox.Panel2.Height - searchBox.Top - searchBox.Height - VOffset * 4;
            map.Top = searchBox.Top + searchBox.Height + VOffset * 2;
            map.Left = Width / 2 - map.Width / 2;
        }
    }
}
