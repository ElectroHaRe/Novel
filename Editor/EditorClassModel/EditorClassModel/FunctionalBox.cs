using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorClassModel
{
    public class FunctionalBox
    {
        public event EventHandler Save;
        public event EventHandler Load;
        public event EventHandler Exit;
        public event EventHandler AddTieButtonClick;
        public event EventHandler TieTextChanged;
        public event EventHandler TieNodesClick;

        public ElementContainer elementContainer { get; set; }

        public State State { get; set; }

        public void SwitchState(State @new)
        {
            throw new System.NotImplementedException();
        }
    }
}