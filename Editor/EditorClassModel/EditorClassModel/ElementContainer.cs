using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorClassModel
{
    public interface ElementContainer
    {
        event EventHandler FocusChanged;

        List<Element> Elements { get; set; }
        Element CurrentElement { get; set; }
    }
}