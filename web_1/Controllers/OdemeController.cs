using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using web_1.Context;
using web_1.Models;
using web_1.ViewModels;

public class OdemeController : Controller
{
    private readonly ApplicationDBContext _context;

    // Constructor to initialize the controller with the database context
    public OdemeController(ApplicationDBContext context)
    {
        _context = context;
    }

    // GET: Odeme
    public IActionResult Index()
    {
        // TODO: Implement the logic to retrieve and display a list of payment records
        return View();
    }

    public ActionResult Create()
    {

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Odeme odeme)
    {
      
     
            // If the ModelState is valid, add the new Sehir and save changes
            if (ModelState.IsValid)
            {
                _context.Odeme.Add(odeme);
                _context.SaveChanges();
                return RedirectToAction(nameof(Create));
            }

        

        // Continue with the save operation if the ID is unique
        return View(odeme);
    }
}
