using SharedDomain;
using SharedDomain.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto userToCreate);

    Task<IEnumerable<Post>> GetAsync(SearchPostDto searchPost);
    Task<Post> GetByIdAsync(int id);
}