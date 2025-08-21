using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Models.Entities;
using LMS.Shared.DTOs.UserDtos;
using Microsoft.AspNetCore.JsonPatch;
using Service.Contracts;

namespace LMS.Services;
public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{
    private readonly IUnitOfWork unitOfWOrk = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<UserDto> GetByIdAsync(string id)
    {
        var user = await unitOfWOrk.UserRepository.GetByIdAsync(id);
        return mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> PostAsync(UserDto userDto)
    {
        var user = mapper.Map<ApplicationUser>(userDto);
        await unitOfWOrk.UserRepository.PostAsync(user);
        return mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> PatchAsync(string id, JsonPatchDocument<UserDto> patchDoc)
    {
        var userDto = mapper.Map<UserDto>(patchDoc);
        patchDoc.ApplyTo(userDto);
        await unitOfWOrk.CompleteAsync();
        return userDto;
    }
}
