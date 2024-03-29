﻿using web_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_1.Context;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
namespace web_1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AdminController(ApplicationDBContext context)
        {
            _context = context;
        }




        public IActionResult Home()
        {
          

            return View("Home");
        }









        public IActionResult List()
        {
            var firmas = _context.Firmas.ToList();
            return View(firmas);
        }

        private bool FirmaMevcut(int id)
        {
            return (_context.Firmas?.Any(e => e.firma_id == id)).GetValueOrDefault();
        }

        // GET: Kitap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || _context.Firmas == null)
            {
                return NotFound();
            }

            var kitap = await _context.Firmas.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            ViewData["firma_id"] = new SelectList(_context.Firmas, "firma_id", "firma_adi", kitap.firma_adi);
            return View(kitap);
        }



        // GET: Kitap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Firmas == null)
            {
                return NotFound();
            }

            var kitap = await _context.Firmas
                .Include(k => k.firma_id) // Include the related data navigation property
                .FirstOrDefaultAsync(m => m.firma_id == id);

            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }








    }
}
