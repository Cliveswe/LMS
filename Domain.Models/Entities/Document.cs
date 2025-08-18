using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities;

public class Document
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime UploadTimestamp { get; set; }
    public int ApplicationUserId { get; set; }
    public int? CourseId { get; set; } // nav prop
    public int? ModuleId { get; set; } // nav prop
    public int? ActivityId { get; set; } // nav prop
}
