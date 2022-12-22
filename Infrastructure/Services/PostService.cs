using Domain.Models;
namespace Infrastructure.Services;
public class PostService
{
    private List<Post> posts;

    public PostService()
    {
        posts = new List<Post>();
    }
    
    public List<Post> GetPosts()
    {
        return posts;
    }
    public void AddPost(Post post)
    {
        posts.Add(post);
    }
    public void UpdatePost(Post post)
    {
        var existing = posts.Find(x=>x.Id == post.Id);
        if(existing == null) return;

        existing.Title = post.Title;
        existing.Description = post.Description;
        existing.VoteAmount = post.VoteAmount;
        existing.CreatedAt = post.CreatedAt;
    }
    public void Delete(int id)
    {
        var existing = posts.Find(x=>x.Id == id);
        if(existing == null) return;
        posts.Remove(existing);
    }
}