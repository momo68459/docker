using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web1.Models;

namespace web1.Controllers;

public class MathController : Controller
{
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddModel obj)
    {
        if (!ModelState.IsValid)
        {
             return View(obj);
        }
        
        obj.Answer = obj.No1 + obj.No2;
          return View(obj);
    }

    // [HttpPost]
    // public IActionResult Add(int No1, int No2)
    // {
    //     ViewData["Answer"] = No1 + No2;
    //     ViewBag.Answer = No1 + No2;
    //     return View();
    // }
}
