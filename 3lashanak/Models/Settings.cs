using System.ComponentModel.DataAnnotations;

namespace _3lashanak.Models
{
    public enum TypeSettings { Button, Text}
    public class Settings
    {
        [Key]
        public long Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
        public TypeSettings Type { get; set; }
    }
}
