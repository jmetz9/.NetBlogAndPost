using System;
using System.Linq;

namespace BlogsAndPosts
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager man = new Manager();

            Console.WriteLine("What would you like to do?(1-4)");
            Console.WriteLine("1.Display Blogs");
            Console.WriteLine("2.Make a new Blog");
            Console.WriteLine("3.Display Posts from a Blog");
            Console.WriteLine("4.Make a new Post");
            var option = Console.ReadLine();
            
            bool idExists = false;
            int blogId;
            string input;
            switch (option)
            {
                
                case "1":
                    Console.WriteLine("Here is the list of blogs");
                    man.ListBlogs();
                    break;

                case "2":
                    Console.WriteLine("Enter blog name:");
                    var name = Console.ReadLine();
                    man.AddBlog(name);
                    break;

                case "3":
                    Console.WriteLine("Which blog would you like to view from?");
                    man.ListBlogs();
                    do{
                        Console.WriteLine("Input the number of the blog you want to view:");
                        input = Console.ReadLine();
                        try{
                        idExists = man.DoesIdExist(int.Parse(input));
                        }
                        catch (System.FormatException){
                            Console.WriteLine("invalid input");
                        }
                    } while(idExists == false);
                    blogId = int.Parse(input);
                    man.ListPosts(blogId);
                    break;

                case "4":
                    Console.WriteLine("Which blog would you like to post to?");
                    man.ListBlogs();
                    do{
                        Console.WriteLine("Input the number of the blog you want to post to:");
                        input = Console.ReadLine();
                        try{
                        idExists = man.DoesIdExist(int.Parse(input));
                        }
                        catch (System.FormatException){
                            Console.WriteLine("invalid input");
                        }
                    } while(idExists == false);
                    blogId = int.Parse(input);
                    Console.WriteLine("What is the title of your post?");
                    var title = Console.ReadLine();
                    man.AddPost(blogId, title);
                    break;

                default:
                    break;
            }
            
        }
    }
}
