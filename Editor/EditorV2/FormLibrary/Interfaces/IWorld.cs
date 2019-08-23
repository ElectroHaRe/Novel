using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FormLibrary
{
    public interface IWorld
    {
        event EventHandler WorldChanged;

        Point Center { get;}
        Size Size { get;}
        Size VisibleSize { get;}
    }
}
