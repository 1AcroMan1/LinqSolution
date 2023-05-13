using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productList = new List<Product>
            {
                new Product(1,"Bisquit"),
                new Product(2,"Chocolate"),
                new Product(3,"Butter"),
                new Product(4,"Brade"),
                new Product(5,"Honey"),
            };
            List<ProductPurchase> purchaceList = new List<ProductPurchase>
            {
                new ProductPurchase(100,3,800),
                new ProductPurchase(101,2,650),
                new ProductPurchase(102,3,900),
                new ProductPurchase(103,4,700),
                new ProductPurchase(104,3,900),
                new ProductPurchase(105,4,650),
                new ProductPurchase(106,1,458),
            };
            var joined = from product in productList
                         join purch in purchaceList on product.ItemId equals purch.ItemId
                         select new { ID = purch.ItemId, Name = product.ItemDescription, Price = purch.ItemQuantity};
            foreach (var n in joined)
            {
                Console.WriteLine($"{n.ID}--{n.Name}--{n.Price}");
            }

            List<string> names1 = new List<string>
            {
                "Mike",
                "Tom",
                "Jake",
                "Bob",
                "Shark",
            };
            List<string> names2 = new List<string>
            {
                "mIKe",
                "tOm",
                "Shrek",
                "jAkE",
                "Blob",
            };
            var b = from f in names1
                    join s in names2 on f.ToLower() equals s.ToLower()
                    select new { Name1 = f , Name2 = s};
            foreach (var c in b)
            {
                Console.WriteLine($"{c.Name1}--{c.Name2}");
            }                    
        }
    }
    class Product
    {
        public int ItemId { get; private set; }
        public string ItemDescription { get; private set; }

        public Product(int id, string desc) => (ItemId, ItemDescription) = (id, desc);
    }
    class ProductPurchase
    {
        public int InvNum { get; private set; }
        public int ItemId { get; private set; }
        public int ItemQuantity { get; private set; }
        public ProductPurchase(int inv, int id, int quantity) => (InvNum, ItemId, ItemQuantity) = (inv, id, quantity);
    }
    class Person
    {
        public string Name { get; }
        public Person(string name) => Name = name;

        public override bool Equals(object? obj)
        {
            if (obj is Person person) return Name == person.Name;
            return false;
        }
        public override int GetHashCode() => Name.GetHashCode();
    }
    class CustomStringComparer: IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (x is null || y is null) return false;
            return x.ToLower() == y.ToLower();
        }
        public int GetHashCode(string obj) => obj.ToLower().GetHashCode();
    }
}
