using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DTOs.ModuleDtos;

public record ModuleCreateDto
{
    [Required(ErrorMessage = "Name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for Module Name is 30 characters.")]
    public required string Name { get; init; }

    [Required(ErrorMessage = "Description is a required field.")]
    [MaxLength(200, ErrorMessage = "Maximum length for Description is 200 characters.")]
    public required string Description { get; init; }

    [Required(ErrorMessage = "Start date is a required field.")]
    public required DateTime StartDate { get; init; }

    [Required(ErrorMessage = "End date is a required field.")]
    public required DateTime EndDate { get; init; }

    [Required(ErrorMessage = "Course ID is a required field.")]
    public required int CourseId { get; init; }
}
