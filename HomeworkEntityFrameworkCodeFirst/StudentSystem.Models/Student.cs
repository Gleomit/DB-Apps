using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Student
    {
        private ICollection<Homework> homeworks; 
        private ICollection<Course> courses;

        public Student()
        {
            this.homeworks = new HashSet<Homework>();
            this.courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Phone]
        public string PhoneNumer { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
        
        public DateTime Birthday { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        } 
    }
}
