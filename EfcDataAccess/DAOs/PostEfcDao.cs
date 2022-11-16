using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedDomain;
using SharedDomain.DTOs;

namespace EfcDataAccess;

public class PostEfcDao:IPostDao
{
    private readonly RedditContext context;

    public PostEfcDao(RedditContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;    }

    public async Task<Post?> GetByIdAsync(int postId)
    {
        Post? found = await context.Posts
            .AsNoTracking()
            .Include(post => post.Owner)
            .SingleOrDefaultAsync(post => post.Id == postId);
        return found;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostDto searchParams)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.Owner).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchParams.AuthorName))
        {
            // we know username is unique, so just fetch the first
            query = query.Where(post =>
                post.Owner.UserName.ToLower().Equals(searchParams.AuthorName.ToLower()));
        }

        if (!string.IsNullOrEmpty(searchParams.TitleContains))
        {
            query = query.Where(t =>
                t.Title.ToLower().Contains(searchParams.TitleContains.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }
}