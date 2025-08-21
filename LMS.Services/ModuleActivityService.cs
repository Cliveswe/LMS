using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Models.Entities;
using LMS.Shared.DTOs.ModuleActivityDtos;
using Microsoft.AspNetCore.JsonPatch;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Services
{
    public class ModuleActivityService(IUnitOfWork uow, IMapper mapper) : IModuleActivityService
    {
        public async Task CreateActivityAsync(int moduleId, CreateModuleActivityDto newModuleActivityDto)
        {
            newModuleActivityDto.ModuleId = moduleId;
            var newModuleActivity = mapper.Map<ModuleActivity>(newModuleActivityDto);
            uow.ModuleActivityRepository.Create(newModuleActivity);
            await uow.CompleteAsync();
        }

        public async Task PatchModuleActivityAsync(int id, JsonPatchDocument<PatchModuleActivityDto> patchDoc)
        {
            var moduleActivityToPatch = await uow.ModuleActivityRepository.GetAsync(id);
            var dto = mapper.Map<PatchModuleActivityDto>(moduleActivityToPatch);

            patchDoc.ApplyTo(dto);

            //TODO: Are we going to Validate ModelState? Behöver en paket AspNetCore.MVC
            //if (!ModelState.IsValid)
            //{
            //    throw new GameBadRequestException("There is an error with the new data input.");
            //}

            mapper.Map(dto, moduleActivityToPatch);
            await uow.CompleteAsync();
        }

        public IEnumerable<ModuleActivity> GetActivitiesByModule(int moduleId)
        {
            return uow.ModuleActivityRepository.FindByCondition( a => a.ModuleId == moduleId, false);
        }

        //public async Task<IEnumerable<ModuleActivity>> GetModuleActivitiesAsync(Guid moduleId)
        //{
        //    return await uow.ModuleActivityRepository.GetModuleActivitiesAsync(moduleId);
        //}
        //public async Task<ModuleActivity> GetModuleActivityByIdAsync(Guid id)
        //{
        //    return await uow.ModuleActivityRepository.GetModuleActivityByIdAsync(id);
        //}
        //public async Task DeleteModuleActivityAsync(Guid id)
        //{
        //    await uow.ModuleActivityRepository.DeleteModuleActivityAsync(id);
        //    await uow.CompleteAsync();
        //}
    }
}
