
namespace FITNetwork
{    
    class Comment
    {
        public User Author { get; }
        public string Text { get; }
        public DateTime CreatedAt { get; }

        public Comment(User author, string text)
        {
            Author = author;
            Text = text;
            CreatedAt = DateTime.Now;
        }
    }
}