using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Certificate
    {
        public Certificate()
        {
            Users = new HashSet<User>();
        }

        public Guid CertificateId { get; set; }
        public string? CertificateName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Url { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
