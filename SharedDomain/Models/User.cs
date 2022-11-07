namespace SharedDomain;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    
    
    // Yet, I don't need those polices, but I will keep them for possible further expansion.
    
    
    /*
    public string Domain { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int Age { get; set; }
    public int SecurityLevel { get; set; }
    */
}