using Microsoft.AspNetCore.Mvc;
namespace DemoMVC.Controllers;

public class DTVController : Controller
{
       public IActionResult Index()
    {
        return View();
    }
}