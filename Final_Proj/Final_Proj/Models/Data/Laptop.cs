using System;
namespace Final_Proj.Models
{
	public class Laptop
	{
        private static int _nextId = 1;
        public int Id { get; set; }
        public string Model { get; set; }
        public Brand Brand { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }

        public Laptop(string model, Brand brand, double price, int year)
		{
            Id = _nextId++;
            Model = model;
            Brand = brand;
            Price = price;
            Year = year;
        }
	}
}

