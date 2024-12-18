using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarberShop1._0._1.Web.Data;
using BarberShop1._0._1.Web.Models;

namespace BarberShop1._0._1.Web.Controllers
{
    public class ServiceModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Services.ToListAsync());
        }

        // GET: ServiceModels/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }


        [HttpGet]
        public async Task<IActionResult> BookAppointment(int? id, ServiceModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
            .Where(s => s.Id == id)
            .Select(s => new ServiceModel
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                DurationInMinutes = s.DurationInMinutes
            })
            .FirstOrDefaultAsync();

            if (service == null)
            {
                return NotFound();
            }


            var barbers = await _context.Barbers
            .Where(b => b.Services.Any(s => s.Id == id))
            .Select(b => new Barber
            {
                Id = b.Id,
                Name = b.Name,
                Availabilities = b.Availabilities,
            })
            .ToListAsync();

            var viewModel = new BookAppointmentViewModel
            {
                Service = new ServiceModel
                {
                    Id = service.Id,
                    Name = service.Name,
                    Price = service.Price,
                    DurationInMinutes = service.DurationInMinutes
                },
                Barbers = barbers
            };

            return View(viewModel);

        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableSlots(int barberId)
        {
            var availableSlots = await _context.BarberAvailabilities
                .Where(ba => ba.BarberId == barberId && !ba.IsBooked)
                .Select(ba => new
                {
                    id = ba.Id,
                    time = ba.AvailableFrom.ToString("HH:mm") // Format the time as needed
                })
                .ToListAsync();

            return Json(availableSlots);
        }




        // POST: ServiceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookAppointment(BookAppointmentViewModel model)
        {

            return View(model);
            
        }

        // GET: ServiceModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,DurationInMinutes")] ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceModel);
        }

        // GET: ServiceModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.Services.FindAsync(id);
            if (serviceModel == null)
            {
                return NotFound();
            }
            return View(serviceModel);
        }

        // POST: ServiceModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,DurationInMinutes")] ServiceModel serviceModel)
        {
            if (id != serviceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceModelExists(serviceModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(serviceModel);
        }

        // GET: ServiceModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }

        // POST: ServiceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceModel = await _context.Services.FindAsync(id);
            if (serviceModel != null)
            {
                _context.Services.Remove(serviceModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceModelExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
