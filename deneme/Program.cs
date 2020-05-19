using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection.Metadata;
using AutoMapper;

namespace deneme
{
    class Program
    {
       public static void Main(string[] args)
        {

            List<Product> products = new List<Product>();
            //AutoMapper(products);
            Mapper mapper=new Mapper(Configuration, childContainer.GetInstance);

            IEnumerable<ProductVekil> summary = mapper.Map<IEnumerable<Product>,
                IEnumerable<ProductVekil>>(products);
            Console.ReadLine();
        }

        private static void AutoMapper(List<Product> products)
        {
            Product p1 = new Product();
            Product p2 = new Product();
            ProductVekil summary = new ProductVekil();
            p1.Ad = "ertan";
            p1.Id = 123;
            p2.Ad = "Aleyna";
            p2.Id = 312;
            products.Add(p1);
            products.Add(p2);
            foreach (var product in products)
            {
                summary.Id = p1.Id;
                summary.Ad = p1.Ad;
            }


            Console.WriteLine(summary.Ad);
            Console.WriteLine(summary.Id);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string  Ad { get; set; }
        public string  Email { get; set; }
        public int TcNo { get; set; }
        
    }

    public  class ProductVekil
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }
}
