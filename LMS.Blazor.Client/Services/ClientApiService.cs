using LMS.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;

namespace LMS.Blazor.Client.Services;

public class ClientApiService(IHttpClientFactory httpClientFactory, NavigationManager navigationManager) : IApiService
{
    // private readonly HttpClient httpClient = httpClientFactory.CreateClient("BffClient"); NOT WORKING
    private HttpClient httpClient = new HttpClient()
    {
        BaseAddress = new Uri($"https://localhost:7213")
    };

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public async Task<UserFormModel> GetUserByIdAsync(string id)
    {
        return await httpClient.GetFromJsonAsync<UserFormModel>($"api/users/{id}");
    }

    public async Task<HttpResponseMessage> CreateUserAsync(UserFormModel model)
    {
        return await httpClient.PostAsJsonAsync($"api/users", model);
    }

    public async Task<HttpResponseMessage> PatchAsJsonAsync(string id, UserFormModel model)
    {
        return await httpClient.PatchAsJsonAsync($"api/users/{id}", model);
    }



    public async Task<T?> CallApiAsync<T>()
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, "proxy?endpoint=api/demoauth");
        var response = await httpClient.SendAsync(requestMessage);

        if (response.StatusCode == System.Net.HttpStatusCode.Forbidden
           || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            navigationManager.NavigateTo("AccessDenied");
        }

        response.EnsureSuccessStatusCode();

        var demoDtos = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(), _jsonSerializerOptions, CancellationToken.None) ?? default;
        return demoDtos;
    }
}
