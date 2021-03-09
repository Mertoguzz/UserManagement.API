using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models
{
    public class User
    {
        public string TCKN { get; set; }
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
