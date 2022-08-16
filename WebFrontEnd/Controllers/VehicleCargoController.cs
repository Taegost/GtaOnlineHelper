using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebFrontEnd.Data;
using Microsoft.AspNetCore.Authorization;
using WebFrontEnd.Models;
using WebFrontEnd.ViewModels;

namespace WebFrontEnd
{
    [Authorize]
    public class VehicleCargoController : Controller
    {
        private readonly ILogger<VehicleCargoController> _logger;
        private ApplicationDbContext db;

        public VehicleCargoController(ILogger<VehicleCargoController> logger, ApplicationDbContext injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        // GET: VehicleCargoController
        public async Task<IActionResult> Index()
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            VehicleCargoViewModel model = new VehicleCargoViewModel(db, userId);
            return View(model);
        }

        // GET: VehicleCargoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleCargoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleCargoController/Create
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

        // GET: VehicleCargoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleCargoController/Edit/5
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

        // GET: VehicleCargoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleCargoController/Delete/5
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
