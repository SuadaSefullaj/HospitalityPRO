using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Project
    {
        public Project()
        {
            Users = new HashSet<User>();
        }

        public Guid ProjectId { get; set; }
        public byte[]? ProjectName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
