
namespace FITNetwork
{
    class Post
    {
        private static int nextId = 1;

        public int Id { get; }
        public User Author { get; }
        public string Text { get; }
        public DateTime CreatedAt { get; }
        public int Likes { get; private set; }
        public List<Comment> Comments { get; } = new List<Comment>();

        public Post(User author, string text)
        {
            Id = nextId++;
            Author = author;
            Text = text;
            CreatedAt = DateTime.Now;
        }

        public void AddLike() => Likes++;

        public void AddComment(Comment comment) => Comments.Add(comment);

        public void Print()
        {
            Console.WriteLine($"  Пост #{Id} | {CreatedAt:dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"  Текст: {Text}");
            Console.WriteLine($"  Лайки: {Likes}");
            Console.WriteLine($"  Коментарі ({Comments.Count}):");
            foreach (var c in Comments)
                Console.WriteLine($"    - {c.Author.Nickname}: {c.Text} ({c.CreatedAt:HH:mm:ss})");
            Console.WriteLine();
        }
    }

}
