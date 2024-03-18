using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClientRegistrationDTO
    {
        // public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;
        //public string LastName { get; set; } = null!;
        ////public DateTime Dob { get; set; }
        public string Password { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime Birth { get; set; } 


        //public int Status { get; set; }
    }


    public class ClientLoginDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
