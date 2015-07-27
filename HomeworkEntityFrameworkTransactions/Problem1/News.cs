using System.ComponentModel.DataAnnotations;

namespace Problem1
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [ConcurrencyCheck]
        [Required]
        public string NewsContent { get; set; }
    }
}
