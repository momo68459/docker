using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web1.Models;

namespace web1.Controllers;

public class CustomerController : Controller
{
    MyDbContext _context;
    public CustomerController(MyDbContext context)
    {
        _context = context;   
    }

    public IActionResult Index()
    {
        return View(_context.Customers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
     public IActionResult Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Edit(int id)
    {
        var customer = _context.Customers
                            .Include(c => c.Orders)
                            .FirstOrDefault(c => c.CustomerID == id);
                            
        return View(customer);
    }

    [HttpPost]
    public IActionResult Edit(int id, Customer customer)
    {
          if (ModelState.IsValid)
        {
            customer.CustomerID = id;
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(customer);
    }

       public IActionResult Delete(int id)
    {
        var customer = _context.Customers.Find(id);

        _context.Customers.Remove(customer!);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
