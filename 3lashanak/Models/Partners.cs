using System.ComponentModel.DataAnnotations;

namespace _3lashanak.Models
{
    public class Partners
    {
        [Key]
        public long Id { get; set; }
       
        public string Image { get; set; }
    }
}
