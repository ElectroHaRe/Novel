namespace NovelDataV3
{
    public static class Factory
    {
        private static NovelSystem GetTree()
        {
            return new NovelSystem();
        }

        private static NovelSystem GetTree(string path)
        {
            return new NovelSystem(path);
        }

        public static Creator GetCreator()
        {
            return GetTree();
        }


        public static Creator GetCreator(string path)
        {
            return GetTree(path);
        }

        public static User GetUser()
        {
            return GetTree();
        }

        public static User GetUser(string path)
        {
            return GetTree(path);
        }
    }
}