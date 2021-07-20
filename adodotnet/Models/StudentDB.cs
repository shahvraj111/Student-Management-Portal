using System.ComponentModel.DataAnnotations;

namespace adodotnet.Models
{
    public class StudentDB
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(22, 60)]
        public int Age { get; set; }
        public string BirthDate { get; set; }
        public string Subject { get; set; }
    }
}



