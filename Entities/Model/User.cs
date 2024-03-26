using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class User
    {
        public User()
        {
            Certificates = new HashSet<Certificate>();
            Educations = new HashSet<Education>();
            Jobs = new HashSet<Job>();
            Projects = new HashSet<Project>();
            Roles = new HashSet<Role>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Password { get; set; } = null!;
        public int Status { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
