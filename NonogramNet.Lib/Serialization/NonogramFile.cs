namespace NonogramNet.Lib.Serialization
{
    using Model;

    public class NonogramFile
    {
        public NonogramFile(string title, string author, Board board)
        {
            Title = title;
            Author = author;
            Board = board;
        }

        public string Title { get; }
        public string Author { get; }

        public Board Board { get; }
    }
}