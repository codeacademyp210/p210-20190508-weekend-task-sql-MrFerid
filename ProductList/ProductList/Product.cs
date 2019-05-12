using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductList
{
    class Product
    {
        public Product() { }
        public Product(int ID, string name, double price,string category, string brand,string color,int barcode,int stock)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
            this.Brand = brand;
            this.Color = color;
            this.Barcode = barcode;
            this.Stock = stock;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Barcode { get; set; }
        public int Stock { get; set; }
    }
}
