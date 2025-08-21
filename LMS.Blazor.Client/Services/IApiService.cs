using LMS.Blazor.Client.Models;

namespace LMS.Blazor.Client.Services;

public interface IApiService
{
    Task<T?> CallApiAsync<T>();
    Task<UserFormModel> GetUserByIdAsync(string id);
    Task<HttpResponseMessage> CreateUserAsync(UserFormModel model);
    Task<HttpResponseMessage> PatchAsJsonAsync(string id, UserFormModel model);
}
