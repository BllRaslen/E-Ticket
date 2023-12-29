using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using web_1.Context;
using web_1.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography;
using System.Text;

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
        string hashPassword(string pass)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(pass);  
            var hashedPass = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPass);
        }
       

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            person.tipi = "User";

            var hasedPass =  hashPassword(person.sifre);
            person.sifre = hasedPass;
            if (IsEmailValid(person))
            {
                TempData["basarsiz_Create"] = person.gmail + " Zaten Mevcuttur!";
                return RedirectToAction("Create");
            }
            else
            {
              
                    _context.Persons.Add(person);
                    _context.SaveChanges();

                    TempData["basarli_create"] = person.gmail + " gmail person eklendi";
                    return RedirectToAction("Giris"); // Corrected to redirect to the "Index" action
                

            }

            // Continue with the save operation if the ID is unique
            return View(person);
        }
        public ActionResult giris()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
               return RedirectToAction("Index", "Home");

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
        public async Task<ActionResult> GirisAsync(Person per)
        {
            per.sifre=hashPassword(per.sifre);
            var Person = await _context.Persons.FirstOrDefaultAsync(m => m.gmail == per.gmail&&m.sifre==per.sifre);
         
                if (Person!=null)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, per.gmail),
                    new Claim("OtherProperties","Example Role")

                };
                if(Person.tipi=="Admin")
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                else { claims.Add(new Claim(ClaimTypes.Role, "User")); }

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {

                    AllowRefresh = true,
                    IsPersistent = per.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                if (Person.tipi == "Admin")
                    return RedirectToAction("Home", "Admin");
                else { return RedirectToAction("Index", "Home"); }

            }
            
            else if(IsPersonValid(per))
            {
                HttpContext.Session.SetString("SessionUser", per.gmail);
                return RedirectToAction("Home", "Muusteri");

            }
            else
            {
                TempData["basarsiz"] = "e-posta veya Şifreniz Yanliştir Tekrar deneyin";
                return RedirectToAction("Giris", "Person");
            }


            // Continue with the save operation if the ID is unique
            return View(per);
        }
        public IActionResult Cikis()
        {
            // Sign out the user
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();

            // Optionally clear session data
            HttpContext.Session.Clear();

            // Redirect to the login page
            return RedirectToAction("Giris", "Person");
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
