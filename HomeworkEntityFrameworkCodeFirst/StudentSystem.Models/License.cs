using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace StudentSystem.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
