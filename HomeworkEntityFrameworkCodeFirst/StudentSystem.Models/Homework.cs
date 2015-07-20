using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public ApplicationType ContentType { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
