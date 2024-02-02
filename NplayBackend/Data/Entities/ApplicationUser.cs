using System;
using System.ComponentModel.DataAnnotations;

namespace Lojal.Data.Enitites
{
    public class ApplicationUser : IHaveTimestamps
    {
        public Guid Id { get; set; }
        //public string VippsSub { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public bool EmailConsent { get; set; } = false;
        public bool SmsConsent { get; set; } = false;
        public bool IsAdmin { get; set; } = false;

        public DateTime CreatedDate { get ; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
