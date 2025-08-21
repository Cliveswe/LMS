using Domain.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LMS.Shared.DTOs.UserDtos;
[DataContract]
public class UserDto
{
    [DataMember]
    [Required]
    public string? FirstName { get; set; }
    [DataMember]
    public string? LastName { get; set; }
    [DataMember]
    public string? Email { get; set; }
    [DataMember]
    public string? Role { get; set; }
    [DataMember]
    public List<Course> Courses { get; set; }
}
