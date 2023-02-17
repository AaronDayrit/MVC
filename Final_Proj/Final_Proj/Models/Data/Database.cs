using System;
namespace Final_Proj.Models
{
	public class Database
	{
        public HashSet<Brand> Brands { get; set; }
        public HashSet<Laptop> Laptops { get; set; }

        private static Database _instance { get; } = new();
        public static Database GetInstance()
        {
            return _instance;
        }

        public Database()
        {
            Brand lenovo = new Brand("Lenovo");
            Brand dell = new Brand("Dell");
            Brand acer = new Brand("Acer");

            Brands = new HashSet<Brand>()
            {
                lenovo,
                dell,
                acer,
            };

            Laptop lenovo1 = new Laptop("ThinkBook 15", lenovo, 1513.99, 2021);
            Laptop lenovo2 = new Laptop("Ideapad", lenovo, 229.99, 2020);
            Laptop dell1 = new Laptop("Latitude 5290", dell, 9.99, 2011);
            Laptop dell2 = new Laptop("Inspiron 15 3000", dell, 429.99, 2022);
            Laptop acer1 = new Laptop("Nitro 5", acer, 799.99, 2022);

            Laptops = new HashSet<Laptop>()
            {
                lenovo1,
                lenovo2,
                dell1,
                dell2,
                acer1
            };
        }

        public void AddBrand(Brand brand)
        {
            Brands.Add(brand);
        }

        public void AddLaptop(Laptop laptop)
        {
            Laptops.Add(laptop);
        }
    }
}

