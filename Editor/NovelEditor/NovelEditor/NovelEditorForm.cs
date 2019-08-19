using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NovelEditor.MainSpace;

namespace NovelEditor
{
    public partial class NovelEditorForm : Form
    {
        public NovelEditorForm()
        {
            InitializeComponent();
            mainSpaceBox.OnNodeCreation += OnNodeCreationHandle;
            mainSpaceBox.OnDragBackground += OnDragBackgroundHandle;
            mainSpaceBox.OnDragNodeBox += OnDragNodeBoxHandle;
            mainSpaceBox.OnNodeBoxClick += MainSpaceBox_OnNodeBoxClick;
            funcSpaceBox.Map.WorldSize = mainSpaceBox.GetSubSpaceSize();
            funcSpaceBox.Map.WindowSize = mainSpaceBox.Size;
            funcSpaceBox.Map.WorldCenter = mainSpaceBox.GetSubSpaceCentrPoint();
            mainSpaceBox.MouseClick += MainSpaceBox_MouseClick;
        }

        private void MainSpaceBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                funcSpaceBox.SwitchToDefaultState();
        }

        private void MainSpaceBox_OnNodeBoxClick(int index)
        {
            funcSpaceBox.SwithToTieEditorState(index);
        }

        private const int MaxFuncSpaceWidth = 250;
        private const int MinFuncSpaceWidth = 190;

        private void OnDragBackgroundHandle(object sender, EventArgs e)
        {
            funcSpaceBox.Map.WorldSize = mainSpaceBox.GetSubSpaceSize();
            funcSpaceBox.Map.WorldCenter = mainSpaceBox.GetSubSpaceCentrPoint();
            funcSpaceBox.Map.WindowSize = mainSpaceBox.Size;
            foreach (var item in mainSpaceBox.GetAllNodes())
            {
                funcSpaceBox.Map.UpdateCoords(item.index, item.Position);
            }
            funcSpaceBox.Map.Invalidate();
        }

        private void OnDragNodeBoxHandle(int index)
        {
            funcSpaceBox.Map.WorldSize = mainSpaceBox.GetSubSpaceSize();
            funcSpaceBox.Map.WorldCenter = mainSpaceBox.GetSubSpaceCentrPoint();
            funcSpaceBox.Map.WindowSize = mainSpaceBox.Size;
            funcSpaceBox.Map.UpdateCoords(index, mainSpaceBox.GetAllNodes()[index].Position);
            funcSpaceBox.Map.Invalidate();
        }

        private void OnNodeCreationHandle(MainSpaceBox.NodeInfo obj)
        {
            funcSpaceBox.Map.AddCircleAndLinesCoords(mainSpaceBox.Size, mainSpaceBox.GetSubSpaceSize(), 
                mainSpaceBox.GetSubSpaceCentrPoint(), obj.Position, new Point[0]);
            funcSpaceBox.Map.Invalidate();
        }

        private void NovelEditorForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width * 0.23f > MaxFuncSpaceWidth)
                funcSpaceBox.Width = MaxFuncSpaceWidth;
            else if (this.Width * 0.23f < MinFuncSpaceWidth)
                funcSpaceBox.Width = MinFuncSpaceWidth;
            else funcSpaceBox.Width = (int)(this.Width * 0.23f) ;

            funcSpaceBox.Height = this.Height - 38;
            funcSpaceBox.Left = this.Width - funcSpaceBox.Width - 15;

            mainSpaceBox.Width = this.Width - funcSpaceBox.Width;
            mainSpaceBox.Height = funcSpaceBox.Height;

            funcSpaceBox.Map.WorldSize = mainSpaceBox.GetSubSpaceSize();
            funcSpaceBox.Map.WindowSize = mainSpaceBox.Size;
            funcSpaceBox.Map.Invalidate();
        }
    }
}
