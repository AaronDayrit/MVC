using System;
namespace Final_Proj.Models
{
	public class Brand
	{
        private static int _nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }

        public Brand(string name)
        {
            Id = _nextId++;
            Name = name;
        }
    }
}

