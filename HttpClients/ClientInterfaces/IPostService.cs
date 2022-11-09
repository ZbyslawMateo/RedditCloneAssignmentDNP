using SharedDomain;
using SharedDomain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<ICollection<Post>> GetAsync(string? authorName, string? title);
    Task<Post> GetByIdAsync(int id);
}