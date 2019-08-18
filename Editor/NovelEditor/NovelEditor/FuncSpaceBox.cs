using System;
using System.Windows.Forms;
using NovelFormLibrary;

namespace NovelEditor
{
    public partial class FuncSpaceBox : UserControl
    {
        public FuncSpaceBox()
        {
            InitializeComponent();
            defaultTieStateBox.Active = true;
            editorTieStateBox.Active = false;
            tieNodesState.Active = false;
            Update();
        }

        private const int MaxWidth = 250;
        private const int MinWidth = 150;
        private const int HIndent = 17;
        private const int VIndent = 5;

        public event EventHandler OnSaveButtonClick
        {
            add { defaultTieStateBox.OnSaveButtonClick += value; }
            remove { defaultTieStateBox.OnSaveButtonClick -= value; }
        }
        public event EventHandler OnLoadButtonClick
        {
            add { defaultTieStateBox.OnLoadButtonClick += value; }
            remove { defaultTieStateBox.OnLoadButtonClick -= value; }
        }
        public event EventHandler OnAddTreeButtonClick
        {
            add { defaultTieStateBox.OnAddTreeButtonClick += value; }
            remove { defaultTieStateBox.OnAddTreeButtonClick -= value; }
        }
        public event EventHandler OnUndoButtonClick
        {
            add { defaultTieStateBox.OnUndoButtonClick += value; }
            remove { defaultTieStateBox.OnUndoButtonClick -= value; }
        }
        public event EventHandler OnRedoButtonClick
        {
            add { defaultTieStateBox.OnRedoButtonClick += value; }
            remove { defaultTieStateBox.OnRedoButtonClick -= value; }
        }
        public event EventHandler OnQuitButtonClick
        {
            add { defaultTieStateBox.OnQuitButtonClick += value; }
            remove { defaultTieStateBox.OnQuitButtonClick -= value; }
        }

        public event EventHandler OnPlusButtonClick
        {
            add { editorTieStateBox.OnPlusButtonClick += value; }
            remove { editorTieStateBox.OnPlusButtonClick -= value; }
        }

        public Map Map => this.map;
        public SearchBox SearchBox => this.searchBox;

        public string NewTieText => editorTieStateBox.AddTieBoxText;

        public void SwitchToDefaultState()
        {
            editorTieStateBox.Active = false;
            editorTieStateBox.RemoveAllTieEditorBoxes();
            tieNodesState.Active = false;
            tieNodesState.RemoveAll();
            defaultTieStateBox.Active = true;
        }

        public void SwithToTieEditorState()
        {
            defaultTieStateBox.Active = false;
            tieNodesState.Active = false;
            tieNodesState.RemoveAll();
            editorTieStateBox.Active = true;
        }

        public void SwitchToTieNodesState(Node startNode, string tieText)
        {
            editorTieStateBox.RemoveAllTieEditorBoxes();
            editorTieStateBox.Active = false;
            defaultTieStateBox.Active = false;
            tieNodesState.InitializeMenu(startNode, tieText);
            tieNodesState.Active = true;
        }

        public void AddTieEditorBox(string text, EventHandler removeButtonClicHandler, EventHandler arrowButtonClickHandler, EditorTieStateBox.TextChangedDelegate textChangedHandler)
        {
            editorTieStateBox.AddTieEditorBox(text, removeButtonClicHandler, arrowButtonClickHandler, textChangedHandler);
        }

        private void FuncSpaceBox_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width < 250 + HIndent * 2)
            {
                map.Width = searchBox.Width = defaultTieStateBox.Width
                    = editorTieStateBox.Width = tieNodesState.Width = this.Width - HIndent * 2;
            }
            else
            {
                this.Width = MaxWidth + HIndent * 2;
                map.Width = searchBox.Width = editorTieStateBox.Width 
                    =tieNodesState.Width = defaultTieStateBox.Width = MaxWidth;
            }
            searchBox.Left = map.Left = HIndent;
            searchBox.Top = VIndent;
            map.Top = searchBox.Top + searchBox.Height + VIndent;
            map.Height = functionalZones.Panel2.Height - map.Top - VIndent * 2;
            editorTieStateBox.Height = functionalZones.Panel1.Height - VIndent * 2;
        }
    }
}
