using FirstWebMVC.Controllers;
using FirstWebMVC.Models;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(Account ps)
    {
        string str = "Hello" + " " + ps.masinhvien + "-" + ps.hoTen;
        ViewBag.thongbao = str;
        return View();
    }

}