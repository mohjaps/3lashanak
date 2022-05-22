using System;
using System.ComponentModel.DataAnnotations;

namespace _3lashanak.Models
{
    public class Packages
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public string EndDate { get; set; }
        [Required]
        public Double Price { get; set; }
        public Boolean IsMajor { get; set; }
    }
}
