using SharedDomain;

namespace WebAPI.Services;

public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
    
    //Not used for now
    
    //Task RegisterUser(User user);
}