using System;
namespace Final_Proj.Models
{
	public class LaptopsByBrandFiltered
	{
        public string SelectedBrand { get; set; }
        public string SortFiler { get; set; }
        public HashSet<Laptop> Results = Database.GetInstance().Laptops;


    }
}

