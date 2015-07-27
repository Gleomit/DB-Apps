using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Problem4.Models
{
    public class CardAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10), MinLength(10)]
        [Index("IX_CardNumber", 1, IsUnique = true)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(4), MinLength(4)]
        public string CardPIN { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal CardCash { get; set; }
    }
}
