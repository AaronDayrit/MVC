using System;
namespace Final_Proj.Models
{
	public class LaptopsByBrandOrdered
	{
        public string SelectedBrand { get; set; }
        public string SortFiler { get; set; }
		public HashSet<Laptop> Results = Database.GetInstance().Laptops;
    }
}

