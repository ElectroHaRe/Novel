using System;

namespace NovelDataV3
{
    [Serializable]
    internal struct Branch
    {
        internal Branch(Node node,string text) { this.Node = node; this.Text = text; }
        internal readonly Node Node;
        internal readonly string Text;
    }
}