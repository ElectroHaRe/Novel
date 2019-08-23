using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorClassModel
{
    public class CompositeTextBox
    {
        public event EventHandler MinusClick;
        public event EventHandler ArrowClick;
        public event EventHandler TextFieldClick;
        public event EventHandler TextChanged;

        public string Text { get; set; }
    }
}