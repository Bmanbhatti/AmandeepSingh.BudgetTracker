using System;

namespace ApplicationCore.Models.Response

{
    public class UserRegisterResponseModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime JoinedOn { get; set; }
    }
}