using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Final_Proj.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Final_Proj.Controllers;

public class BrandsController : Controller
{
    private readonly ILogger<BrandsController> _logger;
    public Database db = Database.GetInstance();

    public BrandsController(ILogger<BrandsController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

    /*------------------------------------
        Basic Views 
     ------------------------------------*/

    public IActionResult AllBrandsAndLaptops()
    {
        IEnumerable<IGrouping<string, Laptop>> result = db.Laptops.GroupBy(l => l.Brand.Name, l => l);
        return View(result);
    }

    /*------------------------------------
        Form Views 
     ------------------------------------*/

    public IActionResult LaptopsByBrandOrdered()
    {
        return View(new LaptopsByBrandOrdered());
    }

    [HttpPost]
    public IActionResult LaptopsByBrandOrdered(LaptopsByBrandOrdered formResult)
    {
        if (formResult.SelectedBrand != null)
        {
            formResult.Results = db.Laptops.Where(l => l.Brand.Name == formResult.SelectedBrand).ToHashSet();
        }

        if (formResult.SortFiler != null)
        {

            switch (formResult.SortFiler)
            {
                case "Price: Lowest to Highest":
                    formResult.Results = formResult.Results.OrderBy(l => l.Price).ToHashSet();
                    break;
                case "Price: Highest to Lowest":
                    formResult.Results = formResult.Results.OrderByDescending(l => l.Price).ToHashSet();
                    break;
                case "Year: Newest to Oldest":
                    formResult.Results = formResult.Results.OrderByDescending(l => l.Year).ToHashSet();
                    break;
                case "Year: Oldest to Newest":
                    formResult.Results = formResult.Results.OrderBy(l => l.Year).ToHashSet();
                    break;
            }
        }
        return View(formResult);
    }

    public IActionResult LaptopsByBrandFiltered()
    {
        return View(new LaptopsByBrandFiltered());
    }

    [HttpPost]
    public IActionResult LaptopsByBrandFiltered(LaptopsByBrandFiltered formResult)
    {
        if (formResult.SelectedBrand != null)
        {
            formResult.Results = db.Laptops.Where(l => l.Brand.Name == formResult.SelectedBrand).ToHashSet();
        }

        if (formResult.SortFiler != null)
        {

            switch (formResult.SortFiler)
            {
                case "Price: $0-100":
                    formResult.Results = formResult.Results.Where(l => l.Price <= 100 && l.Price >= 0).ToHashSet();
                    break;
                case "Price: $1000-2000":
                    formResult.Results = formResult.Results.Where(l => l.Price <= 2000 && l.Price >= 1000).ToHashSet();
                    break;
                case "Year: 2015-2020":
                    formResult.Results = formResult.Results.Where(l => l.Year <= 2020 && l.Year >= 2015).ToHashSet();
                    break;
                case "Year: 2010-2015":
                    formResult.Results = formResult.Results.Where(l => l.Year <= 2015 && l.Year >= 2010).ToHashSet();
                    break;
                case "Year: 2020+":
                    formResult.Results = formResult.Results.Where(l => l.Year >= 2020).ToHashSet();
                    break;
            }
        }
        return View(formResult);
    }

    public IActionResult CreateBrand()
    {
        return View(new CreateBrand());
    }

    [HttpPost]
    public IActionResult CreateBrand(CreateBrand formResult)
    {
        if (!string.IsNullOrWhiteSpace(formResult.Name))
        {
            Brand newBrand = new Brand(formResult.Name);
            formResult.Result = newBrand;
            db.AddBrand(newBrand);
        }
        return View(formResult);
    }



}