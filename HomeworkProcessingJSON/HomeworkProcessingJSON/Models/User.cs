namespace HomeworkProcessingJSON.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<User> friends;
        private ICollection<Product> soldProducts;
        private ICollection<Product> boughtProducts;

        public User()
        {
            this.friends = new HashSet<User>();
            this.soldProducts = new HashSet<Product>();
            this.boughtProducts = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<Product> SoldProducts
        {
            get { return this.soldProducts; }
            set { this.soldProducts = value; }
        }

        public virtual ICollection<Product> BoughtProducts
        {
            get { return this.boughtProducts; }
            set { this.boughtProducts = value; }
        }

        public virtual ICollection<User> Friends
        {
            get { return this.friends; }
            set { this.friends = value; }
        }
    }
}
