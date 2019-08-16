using System.Drawing;

namespace NovelDataV3
{
    public interface Creator
    {
        //asdasdasdasd
        //asdasdasdasd
        void CreateNode();
        void CreateNode(string text, Image image);
        void TieNodes(int fromIndex,int toIndex,string text);
        void RemoveNode(int nodeIndex);
        void RemoveTie(int fromIndex,string text);
        void RemoveTie(int fromIndex, int toIndex);
        void RemoveAllTies(int node);
        void MakeRoot(int nodeIndex);
        void ChangeImage(int nodeIndex,Image image);
        void ChangeImage(int nodeIndex, string imagePath);
        void ChangeText(int nodeIndex,string newText);
        void ChangeTieText(int fromIndex,int toIndex,string newText);
        Image GetImage(int nodeIndex);
        string GetText(int nodeIndex);
        string GetTieText(int fromIndex, int toIndex);
        void Save(string path, string fileName);
        void Load(string path);
    }
}