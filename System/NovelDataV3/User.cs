using System.Drawing;

namespace NovelDataV3
{
    public interface User
    {
        Image Image { get;}
        string Text { get;}
        string[] Choices { get;}

        void MoveNext(string text);
        void Save(string path, string fileName);
        void Load(string path);
    }
}