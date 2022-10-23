using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_2;

namespace Lab_2
{
    internal class Fruit
    {
        public string Name { get; set; }
        public bool IsSweet { get; set; }
        public  double Price { get; set; }
        

        public double UsdPrice => Price / UsdCourse.Current;
        public static Fruit Create()
        {
            Random random = new Random();
            string[] names = new string[] { "Apple", "Banana", "Cherry", "Durian", "Edelberry", "Grape", "Jackfruit" };

            return new Fruit
            {
                Name = names[random.Next(names.Length)],
                IsSweet = random.NextDouble() > 0.5,
                Price = random.NextDouble() * 10
            };
        }

        public override string ToString()
        {
            return $"Name={this.Name},\tIsSweet={this.IsSweet},\tPrice={this.Price.ToString("C2")},\tPrice in USD={MyFormatter.FormatUsdPrice(this.UsdPrice)}";
        }
    }
}
