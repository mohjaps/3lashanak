using System.ComponentModel.DataAnnotations;

namespace _3lashanak.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
    }
}
