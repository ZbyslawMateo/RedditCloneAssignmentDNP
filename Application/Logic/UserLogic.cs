using Application.DaoInterfaces;
using Application.LogicInterfaces;
using SharedDomain;
using SharedDomain.DTOs;

namespace Application.Logic;

public class UserLogic:IUserLogic
{
    private readonly IUserDao userDao;
    
    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            UserName = dto.UserName,
            Password = dto.Password
            
        };
    
        User created = await userDao.CreateAsync(toCreate);
    
        return created;
    }
    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;
        string password = userToCreate.Password;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
        if (password.Length < 6)
            throw new Exception("Password must be at least 6 characters!");
        if (password.Length > 16)
            throw new Exception("Password must be less than 17 characters!");
    }
}