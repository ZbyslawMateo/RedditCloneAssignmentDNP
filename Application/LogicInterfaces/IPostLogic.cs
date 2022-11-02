using SharedDomain;
using SharedDomain.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto userToCreate);
}