using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorClassModel
{
    public class SearchBox
    {
        public event EventHandler TextChanged;
        public event EventHandler SearchButtonClick;

        public string Text { get; set; }

        public int SearchFromSource(string[] source)
        {
            throw new System.NotImplementedException();
        }
    }
}