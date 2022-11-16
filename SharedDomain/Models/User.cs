using System.Text.Json.Serialization;

namespace SharedDomain;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }
}