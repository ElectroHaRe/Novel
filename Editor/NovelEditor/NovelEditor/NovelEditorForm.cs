using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelEditor
{
    public partial class NovelEditorForm : Form
    {
        public NovelEditorForm()
        {
            InitializeComponent();
        }

        private const int MaxFuncSpaceWidth = 250;
        private const int MinFuncSpaceWidth = 190;

        private void NovelEditorForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width * 0.23f > MaxFuncSpaceWidth)
                funcSpaceBox.Width = MaxFuncSpaceWidth;
            else if (this.Width * 0.23f < MinFuncSpaceWidth)
                funcSpaceBox.Width = MinFuncSpaceWidth;
            else funcSpaceBox.Width = (int)(this.Width * 0.23f) ;

            funcSpaceBox.Height = this.Height - 38;
            funcSpaceBox.Left = this.Width - funcSpaceBox.Width - 15;
        }
    }
}
