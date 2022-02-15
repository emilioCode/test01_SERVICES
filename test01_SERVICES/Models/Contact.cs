using System;
using System.Collections.Generic;

#nullable disable

namespace test01_SERVICES.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string CivilStatus { get; set; }
        public bool Disabled { get; set; }
    }
}
