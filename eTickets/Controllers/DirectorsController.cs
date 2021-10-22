using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly IDirectorsService _service;

        public DirectorsController(IDirectorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allDirectors = await _service.GetAllAsync();
            return View(allDirectors.OrderBy(x => x.FullName));
        }

        // Get: Directors/Create
        public IActionResult Create()
        {
            return View();
        }

        // Post: Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl, Bio")] Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }

            await _service.AddAsync(director);
            return RedirectToAction(nameof(Index));
        }

        //Get: Directors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);

            if (directorDetails == null)
                return View("NotFound");
            return View(directorDetails);
        }

        // Get: Directors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);

            if (directorDetails == null)
                return View("NotFound");
            return View(directorDetails);
        }

        // Post: Edit
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id, FullName, ProfilePictureUrl, Bio")] Director director)
        {
            if (!ModelState.IsValid)
            {
                return View(director);
            }

            await _service.UpdateAsync(director);
            return RedirectToAction(nameof(Index));
        }

        // Get: Directors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);

            if (directorDetails == null)
                return View("NotFound");
            return View(directorDetails);
        }

        // Post: DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directorDetails = await _service.GetByIdAsync(id);

            if (directorDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
