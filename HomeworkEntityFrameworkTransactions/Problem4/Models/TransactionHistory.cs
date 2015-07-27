using System;
using System.ComponentModel.DataAnnotations;

namespace Problem4.Models
{
    public class TransactionHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
