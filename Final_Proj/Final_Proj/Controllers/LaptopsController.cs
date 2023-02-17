using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Final_Proj.Models;

namespace Final_Proj.Controllers;

public class LaptopsController : Controller
{
    private readonly ILogger<LaptopsController> _logger;
    public Database db = Database.GetInstance();

    public LaptopsController(ILogger<LaptopsController> logger)
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

    public IActionResult MostExpensive()
    {
        IEnumerable<Laptop> result = db.Laptops.OrderByDescending(l => l.Price).Take(2);
        return View(result);
    }

    public IActionResult LeastExpensive()
    {
        IEnumerable<Laptop> result = db.Laptops.OrderBy(l => l.Price).Take(3);
        return View(result);
    }

    /*------------------------------------
        Form Views 
     ------------------------------------*/

    public IActionResult LaptopsInRange()
    {
        return View(new LaptopsInRange());
    }

    [HttpPost]
    public IActionResult LaptopsInRange(LaptopsInRange formResult)
    {
        if (!string.IsNullOrWhiteSpace(formResult.Input))
        {
            formResult.Results = db.Laptops.Where(l => l.Price <= int.Parse(formResult.Input)).ToHashSet();
        }
        return View(formResult);
    }

    public IActionResult CompareLaptops()
    {
        return View(new CompareLaptops());
    }

    [HttpPost]
    public IActionResult CompareLaptops(CompareLaptops formResult)
    {
        if (formResult.Input1 != null && formResult.Input2 != null)
        {
            //formResult.Laptop1 = db.Laptops.Where(l => l.Model == formResult.Input1).First();
            //formResult.Laptop2 = db.Laptops.Where(l => l.Model == formResult.Input2).First();
            formResult.Laptop1 = db.Laptops.FirstOrDefault(l => l.Model == formResult.Input1);
            formResult.Laptop2 = db.Laptops.FirstOrDefault(l => l.Model == formResult.Input2);
        }
        return View(formResult);
    }

    public IActionResult CreateLaptop()
    {
        return View(new CreateLaptop());
    }
    /*
        public string ModelName { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }
     */

    [HttpPost]
    public IActionResult CreateLaptop(CreateLaptop formResult)
    {
        if (!string.IsNullOrWhiteSpace(formResult.ModelName) && !string.IsNullOrWhiteSpace(formResult.Brand)
            && formResult.Price > 0  && formResult.Year > 0)
        {
            Laptop newLaptop = new Laptop(
                formResult.ModelName,
                db.Brands.FirstOrDefault(b => b.Name == formResult.Brand),
                //db.Brands.Where(b => b.Name == formResult.Brand).First()
                formResult.Price,
                formResult.Year);


            formResult.Result = newLaptop;
            db.AddLaptop(newLaptop);

        }
        return View(formResult);
    }
}