using System.ComponentModel.DataAnnotations;

namespace _3lashanak.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }
        public int Image { get; set; }
        public int Title { get; set; }
        public int Logo { get; set; }
    }
}
