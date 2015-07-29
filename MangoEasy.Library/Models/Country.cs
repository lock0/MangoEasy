using System;
using System.ComponentModel.DataAnnotations;

namespace MangoEasy.Library.Models
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ChineseName { get; set; }
    }
}
