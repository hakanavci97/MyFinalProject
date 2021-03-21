using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>()
            {
                new Category{CategoryId=1,CategoryName="Bilgisayar"},
                new Category{CategoryId=2,CategoryName="Telefon"}

            };



            List<Product> products = new List<Product>() {
            new Product{ProductId=1,CategoryId=1,ProductName="Acer Laptop",QuantityPerUnit="32 GB Ram",UnitPrice=10000,UnitInStock=5},
            new Product{ProductId=2,CategoryId=1,ProductName="Asus Laptop",QuantityPerUnit="16 GB Ram",UnitPrice=18000,UnitInStock=2},
            new Product{ProductId=3,CategoryId=1,ProductName="Hp Laptop",QuantityPerUnit="8 GB Ram",UnitPrice=6000,UnitInStock=3},
            new Product{ProductId=4,CategoryId=2,ProductName="Samsung Telefon",QuantityPerUnit="4 GB Ram",UnitPrice=5000,UnitInStock=5},
            new Product{ProductId=5,CategoryId=2,ProductName="Apple Telefon",QuantityPerUnit="4 GB Ram",UnitPrice=8000,UnitInStock=0},



            };

            AnyTest(products);

            FindTest(products);
            FindAllTest(products);

            AscDescTest(products);

            var result = from p in products
                         join c in categories on p.CategoryId equals c.CategoryId
                         where p.UnitPrice>5000
                         orderby p.UnitPrice descending,p.ProductName ascending
                         select new ProductDto { ProductId = p.ProductId,CategoryName=c.CategoryName,ProductName=p.ProductName,UnitPrice=p.UnitPrice };
                         //select c.CategoryName + "" + p.ProductName;
            foreach (var productDto in result)
            {
                Console.WriteLine(productDto.ProductName+" "+productDto.CategoryName);
            }
        }

        private static void AscDescTest(List<Product> products)
        {
            //Single Line query
            var result = products.Where(p => p.ProductName.Contains("top")).OrderBy(p => p.UnitPrice).ThenBy(p => p.ProductName);
            //küçükten büyüğe sıralama thenby ise order by dan sonra buna göre yap demek oluyor aynı zamanda ThenByDescending bu şekilde sıralaması var.
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindAllTest(List<Product> products)
        {
            var result = products.FindAll(p => p.ProductName.Contains("top"));//where gibi ama liste dönüyor
            Console.WriteLine(result);
        }

        private static void FindTest(List<Product> products)
        {
            var result = products.Find(p => p.ProductId == 2);//aradığımız kritere uygun nesnenin kendisini veriyor.
            Console.WriteLine(result.ProductName);
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "Acer Laptop");//bir listenin içerisinde eleman var mı yok mu kontrol etmek için kullanılır. Geriye true veya false döndürür.
            Console.WriteLine(result);
        }
    }
    class ProductDto
    {
        public int ProductId { get; set; }

        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }

    class Product
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitInStock { get; set; }
    }

    class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
