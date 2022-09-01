using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Shoppnig.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppnig.API.Data
{
    public class ProductContext 
    {
        public IMongoCollection<Product> ProductCollection { get; set; }

        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);


            ProductCollection = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);

            SeedData(ProductCollection);

        }

        private void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any(); 
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProduct());

            }
        }

        private IEnumerable<Product> GetPreconfiguredProduct()
        {
            return new List<Product>() {
                 new Product()
                {
                    Name = "IPhone X",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Samsung 10",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-2.png",
                    Price = 890.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "HTC U11+ Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "LG G7 ThinQ EndofCourse",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = "Home Kitchen"
                }
            };

        }

         
    }
}
