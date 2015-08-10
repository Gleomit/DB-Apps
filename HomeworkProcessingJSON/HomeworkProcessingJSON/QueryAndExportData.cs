using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace HomeworkProcessingJSON
{
    using System;
    using System.Linq;

    public class QueryAndExportData
    {
        static void Main(string[] args)
        {
            using (var productShopContext = new ProductShopContext())
            {
                ProductsInRange(productShopContext);
                SuccessfullySoldProducts(productShopContext);
                CategoriesByProductsCount(productShopContext);
                UsersAndProducts(productShopContext);
                Console.WriteLine("All problems executed, check the bin\\debug folder for outputed files.");
            }
        }

        private static void ProductsInRange(ProductShopContext context)
        {
            var products = from product in context.Products.Include("Seller")
                where product.Price >= 500 && product.Price <= 1000
                        && product.BuyerId == null
                orderby product.Price ascending
                select new
                {
                    name = product.Name,
                    price = product.Price,
                    seller = product.Seller.FirstName + " " + product.Seller.LastName
                };

            string json = JsonConvert.SerializeObject(products);

            File.WriteAllText("products-in-range.json", json);
        }

        private static void SuccessfullySoldProducts(ProductShopContext context)
        {
            var users = from user in context.Users.Include("SoldProducts").Include("BoughtProducts")
                            where user.SoldProducts.Count(p => p.Buyer != null) >= 1
                            orderby user.LastName, user.FirstName
                            select new
                            {
                                firstName = user.FirstName,
                                lastName = user.LastName,
                                soldProducts = from product in user.SoldProducts
                                                where product.Buyer != null
                                                select new
                                                {
                                                    name = product.Name,
                                                    price = product.Price,
                                                    buyerFirstName = product.Buyer.FirstName,
                                                    buyerLastName = product.Buyer.LastName
                                                }
                            };

            string json = JsonConvert.SerializeObject(users);

            File.WriteAllText("users-sold-products.json", json);
        }

        private static void CategoriesByProductsCount(ProductShopContext context)
        {
            var categories = from category in context.Categories.Include("Products")
                            orderby category.Products.Count
                            select new
                            {
                                category = category.Name,
                                productsCount = category.Products.Count,
                                averagePrice = category.Products.Average(p => p.Price),
                                totalRevenue = category.Products.Sum(p => p.Price)
                            };

            string json = JsonConvert.SerializeObject(categories);

            File.WriteAllText("categories-by-products.json", json);

        }

        private static void UsersAndProducts(ProductShopContext context)
        {
            var users = from user in context.Users.Include("SoldProducts")
                            where user.SoldProducts.Count >= 1
                            orderby user.SoldProducts.Count descending, user.LastName ascending 
                            select new
                            {
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Age = user.Age,
                                SoldProducts = from product in user.SoldProducts
                                                select new
                                                {
                                                    Name = product.Name,
                                                    Price = product.Price
                                                }
                            };

            using (XmlWriter xmlWriter = XmlWriter.Create("users-and-products.xml"))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("users");
                xmlWriter.WriteAttributeString("count", users.Count().ToString());

                foreach (var user in users)
                {
                    xmlWriter.WriteStartElement("user");
                    if (user.FirstName != null)
                    {
                        xmlWriter.WriteAttributeString("first-name", user.FirstName);
                    }

                    xmlWriter.WriteAttributeString("last-name", user.LastName);

                    if (user.Age != null)
                    {
                        xmlWriter.WriteAttributeString("age", user.Age.ToString());
                    }
                    
                    xmlWriter.WriteStartElement("sold-products");
                    xmlWriter.WriteAttributeString("count", user.SoldProducts.Count().ToString());

                    foreach (var product in user.SoldProducts)
                    {
                        xmlWriter.WriteStartElement("product");
                        xmlWriter.WriteAttributeString("name", product.Name);
                        xmlWriter.WriteAttributeString("price", product.Price.ToString());
                        xmlWriter.WriteEndElement();
                    }

                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }
    }
}
