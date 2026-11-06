
namespace FITNetwork
{
    class SocialNetwork
    {
        public List<User> Users { get; } = new List<User>();

        public User AddUser(string name, string email, string nickname)
        {
            var user = new User(name, email, nickname);
            Users.Add(user);
            return user;
        }

        // Користувач viewer переглядає останні 5 постів користувача target
        public void ShowLastPosts(User viewer, User target)
        {
            Console.WriteLine($"\n{viewer.Nickname} дивиться останні 5 постів {target.Nickname}:");
            var posts = target.GetLastPosts(5);

            if (posts.Count == 0)
            {
                Console.WriteLine("  У користувача ще немає постів.");
                return;
            }

            foreach (var post in posts)
                post.Print();
        }
    }
}