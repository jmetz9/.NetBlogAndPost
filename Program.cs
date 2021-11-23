using System;

namespace BlogsAndPosts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your blog name");
            var blogName = Console.ReadLine();

            var blog = new Blog();
            blog.Name = blogName;
        }
    }
}
