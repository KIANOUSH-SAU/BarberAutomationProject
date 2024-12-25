using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarberShop1._0._1.Web.Data;
using BarberShop1._0._1.Web.Models;
using BarberShop1._0._1.Web.Common;
using Microsoft.AspNetCore.Authorization;

namespace BarberShop1._0._1.Web.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class BarbersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BarbersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Barbers
        public async Task<IActionResult> Index()
        {

            // Eagerly load the services associated with each barber
            var barbers = await _context.Barbers
                .Include(b => b.Services)
                .Include(b => b.Availabilities)
                .ToListAsync();

            return View(barbers); // Pass the barbers with services to the view
        }

        // GET: Barbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barber = await _context.Barbers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barber == null)
            {
                return NotFound();
            }

            return View(barber);
        }

        // GET: Barbers/Create
        public IActionResult Create()
        {


            var predefinedHours = Enumerable.Range(9, 8) // 9 to 16
            .Select(hour => new SelectListItem
            {
                Value = $"{hour}:00-{hour + 1}:00",
                Text = $"{hour}:00 - {hour + 1}:00",
                Selected = true // Default preselected
            })
            .ToList();

            ViewBag.PredefinedHours = predefinedHours;



            var services = _context.Services
            .Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            })
            .ToList();

                // Pass the services to the view using ViewBag
            ViewBag.Services = services;
            return View();
        }

        // POST: Barbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNumber")] Barber barber, int[] SelectedServiceIds, string[] SelectedHours)
        {
            if (ModelState.IsValid)
            {

                if (SelectedServiceIds != null && SelectedServiceIds.Any())
                {
                    var selectedServices = await _context.Services
                        .Where(s => SelectedServiceIds.Contains(s.Id))
                        .ToListAsync();

                    barber.Services = selectedServices; // Assign services to the barber
                }


                if (SelectedHours != null && SelectedHours.Any())
                {
                    foreach (var hour in SelectedHours)
                    {
                        var times = hour.Split('-'); // e.g., "9:00-10:00"
                        barber.Availabilities.Add(new BarberAvailability
                        {
                            AvailableFrom = DateTime.Parse(times[0]),
                            AvailableTo = DateTime.Parse(times[1])
                        });
                    }
                }



                // Add the barber to the database
                _context.Add(barber);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }


            ViewBag.Services = _context.Services
            .Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            })
            .ToList();


            ViewBag.PredefinedHours = Enumerable.Range(9, 8)
            .Select(hour => new SelectListItem
            {
                Value = $"{hour}:00-{hour + 1}:00",
                Text = $"{hour}:00 - {hour + 1}:00",
                Selected = true
            })
            .ToList();

            return View(barber);
        }

        // GET: Barbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the barber with related data
            var barber = await _context.Barbers
                .Include(b => b.Services)
                .Include(b => b.Availabilities)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (barber == null)
            {
                return NotFound();
            }
            var barberServiceIds = barber.Services.Select(s => s.Id).ToList();
            // Predefined hours for availability
            var predefinedHours = Enumerable.Range(9, 8) // 9 to 16
                .Select(hour => new SelectListItem
                {
                    Value = $"{hour}:00-{hour + 1}:00",
                    Text = $"{hour}:00 - {hour + 1}:00",
                    Selected = barber.Availabilities.Any(a =>
                        a.AvailableFrom.Hour == hour && a.AvailableTo.Hour == hour + 1) // Preselect existing availability
                })
                .ToList();

            ViewBag.PredefinedHours = predefinedHours;

            // Fetch services with preselection
            var services = _context.Services
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name,
                    Selected = barberServiceIds.Contains(s.Id)
                })
                .ToList();

            ViewBag.Services = services;

            return View(barber);
        }

        // POST: Barbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber")] Barber barber, int[] SelectedServiceIds, string[] SelectedHours)
        {
            if (id != barber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Fetch the existing barber from the database with related data
                    var existingBarber = await _context.Barbers
                        .Include(b => b.Services)
                        .Include(b => b.Availabilities)
                        .FirstOrDefaultAsync(b => b.Id == id);

                    if (existingBarber == null)
                    {
                        return NotFound();
                    }

                    // Update basic fields
                    existingBarber.Name = barber.Name;
                    existingBarber.PhoneNumber = barber.PhoneNumber;

                    // Update services
                    existingBarber.Services.Clear();
                    if (SelectedServiceIds != null && SelectedServiceIds.Any())
                    {
                        var selectedServices = await _context.Services
                            .Where(s => SelectedServiceIds.Contains(s.Id))
                            .ToListAsync();

                        foreach (var service in selectedServices)
                        {
                            existingBarber.Services.Add(service);
                        }
                    }

                    // Update availability hours
                    existingBarber.Availabilities.Clear();
                    if (SelectedHours != null && SelectedHours.Any())
                    {
                        foreach (var hour in SelectedHours)
                        {
                            var times = hour.Split('-');
                            if (times.Length == 2 &&
                                DateTime.TryParse(times[0], out var availableFrom) &&
                                DateTime.TryParse(times[1], out var availableTo))
                            {
                                existingBarber.Availabilities.Add(new BarberAvailability
                                {
                                    AvailableFrom = availableFrom,
                                    AvailableTo = availableTo
                                });
                            }
                        }
                    }

                    // Save changes
                    _context.Update(existingBarber);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarberExists(barber.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Re-populate ViewBag in case of validation errors
            ViewBag.Services = _context.Services
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToList();

            ViewBag.PredefinedHours = Enumerable.Range(9, 8)
                .Select(hour => new SelectListItem
                {
                    Value = $"{hour}:00-{hour + 1}:00",
                    Text = $"{hour}:00 - {hour + 1}:00",
                    Selected = false
                })
                .ToList();

            return View(barber);
        }

        // GET: Barbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barber = await _context.Barbers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barber == null)
            {
                return NotFound();
            }

            return View(barber);
        }

        // POST: Barbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barber = await _context.Barbers.FindAsync(id);
            if (barber != null)
            {
                _context.Barbers.Remove(barber);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarberExists(int id)
        {
            return _context.Barbers.Any(e => e.Id == id);
        }
    }
}
