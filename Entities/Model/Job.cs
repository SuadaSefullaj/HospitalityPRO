using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Job
    {
        public Job()
        {
            Users = new HashSet<User>();
        }

        public Guid JobId { get; set; }
        public string? JobName { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Position { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
