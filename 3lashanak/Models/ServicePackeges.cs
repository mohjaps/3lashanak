using System.ComponentModel.DataAnnotations.Schema;

namespace _3lashanak.Models
{
    public class ServicePackeges
    {
        public int Id { get; set; }
        public string Service { get; set; }
        public long PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Packages Packages { get; set; }
    }
}
