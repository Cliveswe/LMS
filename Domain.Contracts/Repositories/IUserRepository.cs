using Domain.Models.Entities;
using LMS.Shared.DTOs.UserDtos;

namespace Domain.Contracts.Repositories;
public interface IUserRepository
{
    Task<ApplicationUser> GetByIdAsync(string id);
    Task PostAsync(ApplicationUser user);
}
