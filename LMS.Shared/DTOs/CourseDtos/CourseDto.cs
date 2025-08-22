//Ignore Spelling: dto
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LMS.Shared.DTOs.CourseDtos;
public class CourseDto
{

    [Required(ErrorMessage = "CourseName is a required field.")]
    [JsonPropertyName("CourseName")]
    public string CourseName { get; set; }

    [Required(ErrorMessage = "CourseDescription is a required field.")]
    [JsonPropertyName("CourseDescription")]
    public string CourseDescription { get; set; }

    [Required(ErrorMessage = "CourseStartDate is a required field.")]
    [JsonPropertyName("CourseStartDate ")]
    public DateTime CourseStartDate { get; set; }
}
