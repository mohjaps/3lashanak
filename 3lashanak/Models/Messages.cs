using System;
using System.ComponentModel.DataAnnotations;

namespace _3lashanak.Models
{
    public class Messages
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; } = DateTime.Now;
    }
}
