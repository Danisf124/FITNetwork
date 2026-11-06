using System;

namespace FITNetwork
{
    class Program
    {
        static void Main()
        {
            var network = new SocialNetwork();

            // Користувачі (дані описані в коді)
            User olena = network.AddUser("Олена", "olena@mail.com", "@olena");
            User taras = network.AddUser("Тарас", "taras@mail.com", "@taras");
            User ira = network.AddUser("Ірина", "ira@mail.com", "@ira");

            Console.WriteLine("Користувачі соцмережі:");
            foreach (var u in network.Users)
                u.PrintInfo();

            // Олена створює кілька постів
            Console.WriteLine("\n--- Олена створює 7 постів ---");
            Post firstPost = null;
            for (int i = 1; i <= 7; i++)
            {
                Post p = olena.CreatePost($"Мій пост номер {i}");
                if (i == 1) firstPost = p;
            }

            // Тарас і Ірина лайкають та коментують
            Post last = olena.Posts.Last();
            taras.LikePost(last);
            ira.LikePost(last);
            taras.CommentPost(last, "Класний пост!");
            ira.CommentPost(last, "Згоден з Тарасом");
            taras.LikePost(olena.Posts[4]);
            ira.CommentPost(olena.Posts[4], "Цікаво");

            // Спроба лайкнути власний пост (має не вийти)
            bool ownLike = olena.LikePost(last);
            Console.WriteLine($"Олена лайкає свій пост: {(ownLike ? "успішно" : "заборонено")}");

            // Тарас переглядає останні 5 постів Олени
            network.ShowLastPosts(taras, olena);

            // Тарас створює свій пост, а потім видаляє
            Post tarasPost = taras.CreatePost("Це тимчасовий пост");
            Console.WriteLine("--- Тарас створив пост і видаляє його ---");
            bool deleted = taras.DeletePost(tarasPost.Id);
            Console.WriteLine($"Пост видалено: {deleted}");
            Console.WriteLine($"Постів у Тараса: {taras.Posts.Count}");

            // Олена видаляє свій перший пост
            olena.DeletePost(firstPost.Id);
            Console.WriteLine($"\nОлена видалила пост #{firstPost.Id}. Постів у неї тепер: {olena.Posts.Count}");

            // Ірина знову дивиться пости Олени
            network.ShowLastPosts(ira, olena);
        }
    }
}