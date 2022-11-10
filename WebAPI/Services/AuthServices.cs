using System.ComponentModel.DataAnnotations;
using Application.LogicInterfaces;
using FileData;
using SharedDomain;
using SharedDomain.DTOs;

namespace WebAPI.Services;

public class AuthServices : IAuthService
{
    private readonly IUserLogic userLogic;
    private List<User> users;

    public AuthServices(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
        users = new List<User>();
    }

    public async void LoadUsersIntoList()
    {
        SearchUserParametersDto dto = new SearchUserParametersDto(null);
        IEnumerable<User> tempUsers = await userLogic.GetAsync(dto);
        users = tempUsers.ToList();
    }
    

    public Task<User> ValidateUser(string username, string password)
    {
        LoadUsersIntoList();
        User? existingUser = users.FirstOrDefault(u => 
            u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    //Not used now
    
    /*
    public Task RegisterUser(User user)
    {
        LoadUsersIntoList();

        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        users.Add(user);
        
        return Task.CompletedTask;
    }
    */
}