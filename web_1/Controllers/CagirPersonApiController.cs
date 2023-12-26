using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using web_1.Models;

namespace web_1.Controllers
{
    public class CagirPersonApiController : Controller
    {
        public async Task<IActionResult> List()
        {
            List<Person> personlar = new List<Person>();

            using (HttpClient client = new HttpClient())
            {
                // Replace the URL with your actual API endpoint
                var response = await client.GetAsync("https://localhost:7250/api/PersonApi");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    personlar = JsonConvert.DeserializeObject<List<Person>>(jsonResponse);
                }
                else
                {
                    // Handle the error case, for example, redirect to an error page
                    return View("Error");
                }
            }

            return View(personlar);
        }
        public async Task<IActionResult> Create()
        {


            // If the model state is not valid, return to the create view with validation errors
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");

                    // Replace the URL with your actual API endpoint
                    var response = await client.PostAsync("https://localhost:7250/api/PersonApi", jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List"); // Redirect to the list action after successful creation
                    }
                    else
                    {
                        // Handle the error case, for example, redirect to an error page
                        return View("Error");
                    }
                }
            }

            // If the model state is not valid, return to the create view with validation errors
            return View(person);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"https://localhost:7250/api/PersonApi/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var person = JsonConvert.DeserializeObject<Person>(jsonResponse);

                    if (person == null)
                    {
                        return NotFound();
                    }

                    return View(person);
                }
                else
                {
                    // Handle the error case, for example, redirect to an error page
                    return View("Error");
                }
            }
        }

        // Action to handle the HTTP POST request when editing a person
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Person updatedPerson)
        {
            if (updatedPerson.person_id == null)
            {
                return View("Create");
            }

            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(updatedPerson), Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"https://localhost:7250/api/PersonApi/{id}", jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List"); // Redirect to the list action after successful edit
                    }
                    else
                    {
                        // Handle the error case, for example, redirect to an error page
                        return View("Error");
                    }
                }
            }

            // If the model state is not valid, return to the edit view with validation errors
            return View(updatedPerson);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"https://localhost:7250/api/PersonApi/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var person = JsonConvert.DeserializeObject<Person>(jsonResponse);

                    if (person == null)
                    {
                        return NotFound();
                    }

                    return View(person);
                }
                else
                {
                    // Handle the error case, for example, redirect to an error page
                    return View("Error");
                }
            }
        }

        // Action to handle the HTTP POST request when confirming the deletion of a person
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"https://localhost:7250/api/PersonApi/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List"); // Redirect to the list action after successful deletion
                }
                else
                {
                    // Handle the error case, for example, redirect to an error page
                    return View("Error");
                }
            }
        }
    }


}