using LMS.Shared.DTOs.UserDtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Service.Contracts;
public interface IUserService
{
    Task<UserDto> GetByIdAsync(string id);
    Task<UserDto> PostAsync(UserDto userDto);
    Task<UserDto> PatchAsync(string id, JsonPatchDocument<UserDto> patchDoc);
}
