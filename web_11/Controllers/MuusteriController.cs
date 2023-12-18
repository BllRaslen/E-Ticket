using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace web_1.Controllers
{
    public class MuusteriController : Controller
    {
        // GET: MuusteriController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        // GET: MuusteriController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MuusteriController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MuusteriController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MuusteriController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MuusteriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MuusteriController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MuusteriController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
