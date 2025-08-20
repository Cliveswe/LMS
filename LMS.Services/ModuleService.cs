using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Models.Exceptions;
using LMS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Services;

public class ModuleService : IModuleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ModuleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<ModuleDto>> GetAllModulesAsync(int courseId)
    {
        var modules = await _unitOfWork.ModuleRepository.GetAllModulesAsync(courseId);

        if (!modules.Any())
        {
            throw new NotFoundException($"No modules found in course with ID '{courseId}'.");
        }

        return _mapper.Map<IEnumerable<ModuleDto>>(modules);
    }

    public async Task<ModuleDto> GetModuleByIdAsync(int moduleId)
    {
        var module = await _unitOfWork.ModuleRepository.GetModuleByIdAsync(moduleId);

        if (module == null)
        {
            throw new NotFoundException($"Module with ID '{moduleId}' not found.");
        }

        return _mapper.Map<ModuleDto>(module);
    }
}
