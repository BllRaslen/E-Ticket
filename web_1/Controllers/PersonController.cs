using EfCore2C.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using web_1.Context;
using web_1.Models;

namespace web_1.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PersonController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: PersonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {

            return View();
        }

       

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {


            if (IsEmailValid(person))
            {
                TempData["basarsiz_Create"] = person.gmail + " Zaten Mevcuttur!";
                return RedirectToAction("Create");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Persons.Add(person);
                    _context.SaveChanges();

                    TempData["basarli_create"] = person.gmail + " gmail person eklendi";
                    return RedirectToAction("Giris"); // Corrected to redirect to the "Index" action
                }
                TempData["basarsiz_Create"] = "Ekleme başarısız";
            }

            // Continue with the save operation if the ID is unique
            return View(person);
        }
        public ActionResult giris()
        {

            return View();
        }
        
        public bool IsPersonValid(Person person)
        {
            var matchingUser = _context.Persons.FirstOrDefault(u => u.gmail == person.gmail && u.sifre == person.sifre);
            return matchingUser != null;
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Giris(Person person)
        {


            if (person.gmail == "g20@ogr.tr" && person.sifre == "sau")
            {
                HttpContext.Session.SetString("SessionAdmin", person.gmail);
                return RedirectToAction("Home", "Admin");

            }
            
            else if(IsPersonValid(person))
            {
                HttpContext.Session.SetString("SessionUser", person.gmail);
                return RedirectToAction("Home", "Muusteri");

            }
            else
            {
                TempData["basarsiz"] = "e-posta veya Şifreniz Yanliştir Tekrar deneyin";
                return RedirectToAction("Giris", "Person");
            }


            // Continue with the save operation if the ID is unique
            return View(person);
        }
       public IActionResult Cikis()
        {
            HttpContext.Session.Remove("SessionAdmin");
            return View("Giris" );
        }
        public IActionResult CikisUser()
        {
            HttpContext.Session.Remove("SessionUser");
            return View("Giris");
        }

        public bool IsEmailValid(Person person)
        {
            var matchingUser = _context.Persons.FirstOrDefault(u => u.gmail == person.gmail );
            return matchingUser != null;
        }
        private bool PersonMevcut(int id)
        {
            return (_context.Persons?.Any(e => e.person_id == id)).GetValueOrDefault();
        }
    }
}
