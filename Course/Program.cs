using Course.Entities;
using System.Collections.Generic;
using System.Globalization;
using System;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> Products = new List<Product>();

            Console.Write("Enter the number of products: ");
            int number = int.Parse(Console.ReadLine());
            for (int x = 1; x <= number; x++)
            {
                Console.WriteLine($"Product #{x} data:");
                Console.Write("Common, used or imported? (c/u/i): ");
                char question = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (question == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Products.Add(new ImportedProduct(name, price, customsFee));
                }
                else if (question == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufatureDate = DateTime.Parse(Console.ReadLine());
                    Products.Add(new UsedProduct(name, price, manufatureDate));
                }
                else
                {
                    Products.Add(new Product(name, price));
                }
            }

            Console.WriteLine("\nPRICE TAGS: ");
            foreach (Product pdt in Products)
            {
                Console.WriteLine(pdt.PriceTag());
            }            
        }
    }
}
