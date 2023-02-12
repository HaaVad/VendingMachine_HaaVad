using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

    public class Confectionery
    {
        public string Name { get; set; }
        public int Nr { get; set; }
        public int Price { get; set; }
        public Confectionery(string name, int stock, int price)
        {
            Name = name;
            Nr = stock;
            Price = price;
        }
    }
}
