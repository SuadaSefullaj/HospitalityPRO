using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Education
    {
        public Education()
        {
            Users = new HashSet<User>();
        }

        public Guid EducationId { get; set; }
        public string? SchoolName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsFollowing { get; set; }
        public string? AcademicProfile { get; set; }
        public int? Average { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
