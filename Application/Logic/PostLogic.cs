using Application.LogicInterfaces;
using SharedDomain;
using SharedDomain.DTOs;

namespace Application.DaoInterfaces;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.OwnerId);
        if (user == null)
        {
            throw new Exception($"User with id {dto.OwnerId} was not found.");
        }

        ValidateTodo(dto);
        Post todo = new Post(user, dto.Title, dto.Body);
        Post created = await postDao.CreateAsync(todo);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostDto searchPost)
    {
        return postDao.GetAsync(searchPost);
    }

    private void ValidateTodo(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body)) throw new Exception("Body cannot be empty.");
        // other validation stuff
    }
    public async Task<Post> GetByIdAsync(int id)
    {
        Post? post = await postDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Post with id {id} not found");
        }

        return new Post(post.Owner, post.Title, post.Body);
    }
}