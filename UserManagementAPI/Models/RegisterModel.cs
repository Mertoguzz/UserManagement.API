using System;

namespace UserManagementAPI.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }
    }
}
