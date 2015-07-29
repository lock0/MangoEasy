using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MangoEasy.Library.Models.Enum;
using MangoEasy.Library.Models.Interfaces;

namespace MangoEasy.Library.Models
{
    public class Account : IDtStamped
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<DevelopmentLanguage> DevelopmentLanguage { get; set; }
        public bool Valid { get; set; }
        public string VerificationCode { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
