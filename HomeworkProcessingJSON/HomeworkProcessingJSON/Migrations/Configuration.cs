using System.IO;
using System.Xml;
using HomeworkProcessingJSON.Models;
using Newtonsoft.Json;

namespace HomeworkProcessingJSON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeworkProcessingJSON.ProductShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ProductShopContext context)
        {
            LoadUsers();
            LoadCategories();
            LoadProducts();

            context.SaveChanges();
        }

        private void LoadUsers()
        {
            using (var context = new ProductShopContext())
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load("../../Input/users.xml");

                var users = xmlDoc.SelectNodes("/users/user");

                foreach (XmlNode user in users)
                {
                    var firstName = user.Attributes["first-name"];
                    var lastName = user.Attributes["last-name"];
                    var age = user.Attributes["age"];

                    context.Users.Add(new User()
                    {
                        FirstName = (firstName == null ? null : firstName.Value),
                        LastName = lastName.Value,
                        Age = (age == null ? (int?)null : Int32.Parse(age.Value))
                    });
                }

                context.SaveChanges();       
            }
        }

        private void LoadProducts()
        {
            using (var context = new ProductShopContext())
            {
                Random random = new Random();

                string json = File.ReadAllText("../../Input/products.json");

                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

                var categories = context.Categories.ToList();

                int usersCount = context.Users.Count();
                int chanceNumber = random.Next(14);

                int sellerId = 0;
                int? buyerId = 0;
                int numCategories = 0;

                foreach (var product in products)
                {
                    numCategories = random.Next(1, 3);
                    chanceNumber = random.Next(1, 5);

                    sellerId = random.Next(1, usersCount);
                    buyerId = random.Next(1, usersCount);

                    while (sellerId == buyerId)
                    {
                        sellerId = random.Next(1, usersCount);
                        buyerId = random.Next(1, usersCount);
                    }

                    if (chanceNumber != 3)
                    {
                        buyerId = (int?)null;
                    }

                    product.SellerId = sellerId;
                    product.BuyerId = buyerId;

                    for (int i = 0; i < numCategories; i++)
                    {
                        product.Categories.Add(categories[random.Next(categories.Count)]);
                    }

                    context.Products.AddOrUpdate(new Product()
                    {
                        Name = product.Name,
                        Price = product.Price,
                        SellerId = sellerId,
                        BuyerId = buyerId,
                        Categories = product.Categories
                    });
                }

                context.SaveChanges();
            }
        }

        private void LoadCategories()
        {
            using (var context = new ProductShopContext())
            {
                string json = File.ReadAllText("../../Input/categories.json");

                var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(json);

                foreach (var category in categories)
                {
                    context.Categories.AddOrUpdate(c => c.Name, new Category()
                    {
                        Name = category.Name
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
