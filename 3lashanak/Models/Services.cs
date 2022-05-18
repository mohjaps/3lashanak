using System.ComponentModel.DataAnnotations;

namespace _3lashanak.Models
{
    public class Services
    {
        [Key]
        public long Id { get; set; }
        public string Icon { get; set; }
        [StringLength(20, ErrorMessage = "عدد الأحرف 20 حرف")]
        public string Title { get; set; }
        [StringLength(55, ErrorMessage = "عدد الأحرف 55 حرف")]
        public string Description { get; set; }
    }
}
