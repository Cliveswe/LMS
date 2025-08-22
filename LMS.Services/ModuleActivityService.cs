using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Models.Entities;
using Domain.Models.Responses;
using LMS.Shared.DTOs.ModuleActivityDtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;

namespace LMS.Services
{
    public class ModuleActivityService(IUnitOfWork uow, IMapper mapper) : IModuleActivityService
    {
        public async Task<ApiBaseResponse> CreateActivityAsync(int moduleId, CreateModuleActivityDto newModuleActivityDto)
        {
            newModuleActivityDto.ModuleId = moduleId;
            var newModuleActivity = mapper.Map<ModuleActivity>(newModuleActivityDto);
            uow.ModuleActivityRepository.Create(newModuleActivity);
            await uow.CompleteAsync();

            CreateModuleActivityDto dto = mapper.Map<CreateModuleActivityDto>(newModuleActivity);

            return new ApiOkResponse<CreateModuleActivityDto>(dto, "Course successfully created.");
        }

        public async Task<ApiBaseResponse> PatchModuleActivityAsync(int id, JsonPatchDocument<PatchModuleActivityDto> patchDoc)
        {
            var moduleActivityToPatch = await uow.ModuleActivityRepository.GetAsync(id);

            if (moduleActivityToPatch == null)
            {
                return new ApiActivityNotFoundResponse("Module activity not found.");
            }

            var dto = mapper.Map<PatchModuleActivityDto>(moduleActivityToPatch);

            patchDoc.ApplyTo(dto);

            //TODO: Check the correct nugget to validate the model state
            //if (!ModelState.IsValid)
            //{
            //    throw new GameBadRequestException("There is an error with the new data input.");
            //}

            mapper.Map(dto, moduleActivityToPatch);
            await uow.CompleteAsync();

            return new ApiOkResponse<PatchModuleActivityDto>(dto, "Module activity successfully updated.");
        }

        public async Task<ApiBaseResponse> GetActivitiesByModule(int moduleId)
        {
            var response = await uow.ModuleActivityRepository.FindByCondition( a => a.ModuleId == moduleId, false).ToListAsync();
            if (response.Count == 0)
            {
                return new ApiModuleNotFoundResponse("The module you introduced does not exist.");
            }
            return new ApiOkResponse<IEnumerable<ModuleActivity>>(response, "Activities retrieved successfully.");

        }
    }
}
