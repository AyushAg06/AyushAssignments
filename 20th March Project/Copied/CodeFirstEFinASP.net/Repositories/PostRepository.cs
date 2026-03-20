using CodeFirstEFinASP.net.Models;

namespace CodeFirstEFinASP.net.Repositories
{
    public class PostRepository: IPost
    {
        public EventContext context;
        public PostRepository(EventContext cxt)
        {
            this.context = cxt;
        }
        public void DeletePost(int postid)
        {
            Post post = context.Posts.Find(postid);
            context.Posts.Remove(post);
        }

        public Post GetPostByID(int postid)
        {
            return context.Posts.Find(postid);
        }

        public List<Post> GetPosts()
        {
            return context.Posts.ToList();
        }
        public void InsertPost(Post post)
        {
            context.Posts.Add(post);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            context.Entry(post).State =
                Microsoft.
                EntityFrameworkCore.EntityState.Modified;
        }
    }
}
