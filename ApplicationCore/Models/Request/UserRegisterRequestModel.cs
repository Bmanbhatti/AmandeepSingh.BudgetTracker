using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Requests
{
    public class UserRegisterRequestModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime JoinedOn { get; set; }
    }
}

