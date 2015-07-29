using System;
using System.ComponentModel.DataAnnotations;

namespace MangoEasy.Library.Models
{
    public class DevelopmentLanguage
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
