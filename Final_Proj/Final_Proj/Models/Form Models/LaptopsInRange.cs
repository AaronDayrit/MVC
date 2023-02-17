using System;
namespace Final_Proj.Models
{
	public class LaptopsInRange
	{
		public string? Input { get; set; }
		public HashSet<Laptop> Results { get; set; } = new HashSet<Laptop>();
	}
}

