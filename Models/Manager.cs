using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogsAndPosts
{
    class Manager
    {
        public void ListBlogs(){
            using (var db = new BlogContext()){
                foreach (var b in db.Blogs){
                    Console.WriteLine($"Blog {b.BlogId}: {b.Name}");
                }
            }
        }

        public void AddBlog(string name){
            var blog = new Blog();
            blog.Name = name;

            using (var db = new BlogContext())
            {
                db.Add(blog);
                db.SaveChanges();
            }
        }

        public void ListPosts(int blogId){
            using (var db = new BlogContext())
            {
                foreach (var p in db.Posts.Where(x => x.BlogId == blogId)){
                    Console.WriteLine($"Post {p.PostId}: {p.Title}");
                }
            }
        }
        
        public void AddPost(int id, string title){
            var post = new Post();
            post.Title = title;
            post.BlogId = id;

            using (var db = new BlogContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public bool DoesIdExist(int id){
            bool exists = false;
            using (var db = new BlogContext()){
                foreach (var b in db.Blogs){
                    if(b.BlogId == id){
                        exists = true;
                    }
                }
            }
            return exists;
        }
    }
}