using System;
using System.Drawing;

namespace NovelDataV3
{
    [Serializable]
    internal sealed class Node
    {
        internal Image Image { get; set; }
        internal string Text { get; set; }
        internal Branch[] Branches { get; set; } = new Branch[0];
    }
}