using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DTOs.ModuleActivityDtos
{
    public class CreateModuleActivityDto
    {
        [Required(ErrorMessage = "Name is a mandatory field")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Type is a mandatory field")]
        public string Type { get; set; } = string.Empty;
        [Required(ErrorMessage = "Description is a mandatory field")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Start Date is a mandatory field")]
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        [Required(ErrorMessage = "End Date is a mandatory field")]
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public int ModuleId { get; set; } //TODO: Confirm if this will be used.
    }
}
