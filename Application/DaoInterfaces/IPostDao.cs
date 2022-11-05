using SharedDomain;
using SharedDomain.DTOs;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<Post> GetByIdAsync(int id);
    Task<IEnumerable<Post>> GetAsync(SearchPostDto searchParameters);
}