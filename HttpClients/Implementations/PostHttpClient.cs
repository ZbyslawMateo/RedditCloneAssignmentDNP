using System.Net.Http.Json;
using HttpClients.ClientInterfaces;
using SharedDomain.DTOs;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreateAsync(PostCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7256/Post",dto);
        if (!response.IsSuccessStatusCode)
        {
            
            Console.WriteLine("Tu Docieram      " + dto.OwnerId);
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}