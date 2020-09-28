using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "Revision")
            { 
                string[] currInfo = cmd.Split(", ").ToArray();

                string shop = currInfo[0];
                string product = currInfo[1];
                double price = double.Parse(currInfo[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, price);
                }

                shops[shop][product] = price;
            }

            shops = shops
                .OrderBy(n => n.Key)
                .ToDictionary(n => n.Key, p => p.Value);

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var itemInfo in shop.Value)
                {
                    Console.WriteLine($"Product: {itemInfo.Key}, Price: {itemInfo.Value}");
                }
            }
        }
    }
}
