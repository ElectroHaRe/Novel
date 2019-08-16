using System;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace NovelDataV3
{
    internal class NovelSystem : Creator, User
    {
        private Exception NodesNotTie = new Exception("Nodes are not tie");
        private Exception TreeNotLoaded = new Exception("The tree is not loaded");
        private Exception TreeIsEpmty = new Exception("Tree currently empty");

        internal NovelSystem() { }

        internal NovelSystem(string path)
        {
            Load(path);
        }

        internal Node this[int index]
        {
            get
            {
                if (index < 0 || index > Count - 1)
                    throw new ArgumentOutOfRangeException("index");
                return Tree[index];
            }
            set
            {
                if (index < 0 || index > Count - 1)
                    throw new ArgumentOutOfRangeException("index");
                Tree[index] = value;
                if (value == null)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (Tree[i] == null)
                        {
                            for (int j = i; j < Count; j++)
                            {
                                Tree[j] = Tree[j + 1];
                            }
                            return;
                        }
                    }
                    Count--;
                }
            }
        }

        internal Node[] Tree = new Node[0];

        private int length => Tree.Length;

        /// <summary>
        /// Количество узлов в древе
        /// </summary>
        internal int Count { get; private set; } = 0;

        private int currentIndex = 0;

        Image User.Image => Tree[currentIndex].Image;

        string User.Text => Tree[currentIndex].Text;

        string[] User.Choices
        {
            get
            {
                if (length == 0)
                    throw TreeNotLoaded;
                string[] choices = new string[Tree[currentIndex].Branches.Length];
                for (int i = 0; i < Tree[currentIndex].Branches.Length; i++)
                {
                    choices[i] = Tree[currentIndex].Branches[i].Text;
                }
                return choices;
            }
        }

        public void CreateNode()
        {
            CreateNode("new node text", null);
        }

        public void CreateNode(string text, Image image)
        {
            if (length == 0)
                Tree = new Node[4];
            if (length == Count)
                Array.Resize(ref Tree, length * 2);
            Tree[Count++] = new Node() { Text = text, Image = image };
        }

        public void ChangeImage(int nodeIndex, Image image)
        {
            if (nodeIndex > Count - 1 || nodeIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            Tree[nodeIndex].Image = image;
        }

        public void ChangeImage(int nodeIndex, string imagePath)
        {
            Image image = Image.FromFile(imagePath);
            ChangeImage(nodeIndex, image);
        }

        public void ChangeText(int nodeIndex, string newText)
        {
            if (nodeIndex > Count - 1 || nodeIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            Tree[nodeIndex].Text = newText;
        }

        public void ChangeTieText(int fromIndex, int toIndex, string newText)
        {
            if (fromIndex > Count - 1 || fromIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            if (toIndex > Count - 1 || toIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            Node node = Tree[fromIndex];
            Parallel.For(0, node.Branches.Length, i =>
            {
                if (node.Branches[i].Node == Tree[toIndex])
                {
                    node.Branches[i] = new Branch(node, newText);
                    return;
                }
            });
        }

        public Image GetImage(int nodeIndex)
        {
            if (nodeIndex > Count - 1 || nodeIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            return Tree[nodeIndex].Image;
        }

        public string GetText(int nodeIndex)
        {
            if (nodeIndex > Count - 1 || nodeIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            return Tree[nodeIndex].Text;
        }

        public string GetTieText(int fromIndex, int toIndex)
        {
            if (fromIndex > Count - 1 || fromIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            if (toIndex > Count - 1 || toIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            Node node = Tree[fromIndex];
            string text = null;
            Parallel.For(0, node.Branches.Length, i =>
            {
                if (node.Branches[i].Node == Tree[toIndex])
                {
                    text = node.Branches[i].Text;
                }
            });
            if (text == null)
                throw NodesNotTie;
            return text;
        }

        public void Load(string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                Tree = (new BinaryFormatter()).Deserialize(stream) as Node[];
            }
            Count = Tree.Length;
        }

        public void Save(string path, string fileName)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("The directory does not exist");

            path += fileName + ".noveltree";

            Node[] temp_tree = new Node[Count];

            Parallel.For(0, Count, i => temp_tree[i] = Tree[i]);

            using (Stream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                (new BinaryFormatter()).Serialize(stream, temp_tree);
            }
        }

        void User.MoveNext(string text)
        {
            if (length == 0)
                throw TreeNotLoaded;
            if (Tree[currentIndex].Branches.Length == 0)
                return;
            if (Tree[currentIndex].Branches.Length == 1)
                currentIndex = GetIndexOf(Tree[currentIndex].Branches[0].Node);
            if (Tree[currentIndex].Branches.Length > 1)
            {
                Node node = null;
                Parallel.For(0, Tree[currentIndex].Branches.Length, i =>
                {
                    if (Tree[currentIndex].Branches[i].Text == text)
                        node = Tree[currentIndex].Branches[i].Node;
                });
                if (node == null)
                    return;
                else currentIndex = GetIndexOf(node);
            }
            return;
        }

        void User.Save(string path, string fileName)
        {
            Save(path, fileName);
        }

        void User.Load(string path)
        {
            Load(path);
        }

        public void MakeRoot(int nodeIndex)
        {
            if (nodeIndex > Count - 1 || nodeIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            Node tempNode = Tree[0];
            Tree[0] = Tree[nodeIndex];
            Tree[nodeIndex] = tempNode;
        }

        public void RemoveAllTies(int nodeIndex)
        {
            if (nodeIndex > Count - 1 || nodeIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            Tree[nodeIndex].Branches = new Branch[0];
            Parallel.For(0, Count, i =>
             {
                 Parallel.For(0, Tree[i].Branches.Length, j =>
                 {
                     if (Tree[i].Branches[j].Node == Tree[nodeIndex])
                     {
                         for(int k=j; k < Tree[i].Branches.Length - 1; k++)
                         {
                             Tree[i].Branches[k] = Tree[i].Branches[k + 1];
                         }
                         Tree[i].Branches = ResizeNodeBranches(Tree[i].Branches, Tree[i].Branches.Length - 1);
                     }
                 });
             });
        }

        public void RemoveNode(int nodeIndex)
        {
            if (nodeIndex > Count - 1 || nodeIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            RemoveAllTies(nodeIndex);
            this[nodeIndex] = null;
        }

        public void RemoveTie(int fromIndex, string text)
        {
            if (fromIndex > Count - 1 || fromIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            Parallel.For(0, Tree[fromIndex].Branches.Length, i =>
             {
                 if (Tree[fromIndex].Branches[i].Text == text)
                 {
                     for (int j = i; j < Tree[fromIndex].Branches.Length - 1; j++)
                     {

                         Tree[fromIndex].Branches[j] = Tree[fromIndex].Branches[j + 1];
                     }
                     Tree[i].Branches = ResizeNodeBranches(Tree[i].Branches, Tree[i].Branches.Length - 1);
                     return;
                 }
             });
        }

        public void RemoveTie(int fromIndex, int toIndex)
        {
            if (fromIndex > Count - 1 || fromIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            if (toIndex > Count - 1 || toIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            Parallel.For(0, Tree[fromIndex].Branches.Length, i =>
            {
                if (Tree[fromIndex].Branches[i].Node == Tree[toIndex])
                {
                    for (int j = i; j < Tree[fromIndex].Branches.Length - 1; j++)
                    {
                        Tree[fromIndex].Branches[j] = Tree[fromIndex].Branches[j + 1];
                    }
                    Tree[i].Branches = ResizeNodeBranches(Tree[i].Branches, Tree[i].Branches.Length - 1);
                    return;
                }
            });
        }

        public void TieNodes(int fromIndex, int toIndex, string text)
        {
            if (fromIndex > Count - 1 || fromIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            if (toIndex > Count - 1 || toIndex < 0)
                throw new ArgumentOutOfRangeException("nodeIndex");
            Tree[fromIndex].Branches = ResizeNodeBranches(Tree[fromIndex].Branches, Tree[fromIndex].Branches.Length + 1);
            Tree[fromIndex].Branches[Tree[fromIndex].Branches.Length - 1] = new Branch(Tree[toIndex], text);
        }

        private Branch[] ResizeNodeBranches(Branch[] branches, int newSize)
        {
            Array.Resize(ref branches, newSize);
            return branches;
        }

        private int GetIndexOf(Node node)
        {
            int index = -1;
            Parallel.For(0, Count, i => { if (Tree[i] == node) { index = i; return; } });
            return index;
        }
    }
}
