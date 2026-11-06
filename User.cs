
namespace FITNetwork
{
        
    class User
    {
        public string Name { get; }
        public string Email { get; }
        public string Nickname { get; }   // наприклад, @olena
        public List<Post> Posts { get; } = new List<Post>();

        public User(string name, string email, string nickname)
        {
            Name = name;
            Email = email;
            Nickname = nickname;
        }

        // Створити новий пост
        public Post CreatePost(string text)
        {
            var post = new Post(this, text);
            Posts.Add(post);
            return post;
        }

        // Видалити свій пост
        public bool DeletePost(int postId)
        {
            Post post = Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) return false;
            Posts.Remove(post);
            return true;
        }

        // Поставити лайк посту іншого користувача
        public bool LikePost(Post post)
        {
            if (post.Author == this) return false;   // свої пости лайкати не можна
            post.AddLike();
            return true;
        }

        // Написати коментар до поста іншого користувача
        public bool CommentPost(Post post, string text)
        {
            if (post.Author == this) return false;   // за умовою, коментуємо пости інших
            post.AddComment(new Comment(this, text));
            return true;
        }

        // Отримати останні n постів (найновіші першими)
        public List<Post> GetLastPosts(int count = 5)
        {
            return Posts.AsEnumerable().Reverse().Take(count).ToList();
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Name} ({Nickname}), {Email}");
        }
    }

}