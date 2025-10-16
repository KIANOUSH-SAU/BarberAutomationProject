using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarberAutomationProject.Web.Data;
using BarberAutomationProject.Web.Services;
using BarberAutomationProject.Web.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;
using BarberAutomationProject.Web.Common;

namespace BarberAutomationProject.Web.Controllers
{
    public class ServiceModelsController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public ServiceModelsController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        // GET: ServiceModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Services.ToListAsync());
        }



        [HttpPost]
        public async Task<IActionResult> UpdateAvailabilities()
        {
            var today = DateTime.Today;

            // Fetch all barber availabilities
            var barberAvailabilities = await _context.BarberAvailabilities.ToListAsync();

            // Iterate through each availability
            foreach (var availability in barberAvailabilities)
            {
                // Check if the date does not match today's date
                if (availability.AvailableFrom.Date != today)
                {
                    // Update the date to today's date while keeping the time the same
                    availability.AvailableFrom = new DateTime(today.Year, today.Month, today.Day,
                                                              availability.AvailableFrom.Hour,
                                                              availability.AvailableFrom.Minute,
                                                              availability.AvailableFrom.Second);

                    // Reset isBooked to false for the new day
                    availability.IsBooked = false;
                }
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return Ok("Availabilities updated for the new day.");
        }


        [HttpGet]
        public async Task<IActionResult> BookAppointment(int? id)
        {
            var today = DateTime.Today; // Get today's date
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
                    Availabilities = b.Availabilities.Where(a => !a.IsBooked).ToList()

                })
                .ToListAsync();

            var viewModel = new BookAppointmentViewModel
            {
                Service = service, // Use the fetched service
                Barbers = barbers,
                Availabilities = barbers.SelectMany(b => b.Availabilities).Where(a => !a.IsBooked).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableSlots(int barberId)
        {
            var today = DateTime.Today; // Get today's date

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
            if (!ModelState.IsValid)
            {
                // Re-populate dropdowns if validation fails
                model.Barbers = await _context.Barbers
                    .Where(b => b.Services.Any(s => s.Id == model.Service.Id)) 
                    .ToListAsync();

                model.Availabilities = await _context.BarberAvailabilities
                    .Where(ba => !ba.IsBooked)
                    .ToListAsync();

                return View(model);
            }


            var barber = await _context.Barbers.FindAsync(model.SelectedBarberId);
            var service = await _context.Services.FindAsync(model.Service.Id);
            var availability = await _context.BarberAvailabilities.FindAsync(model.SelectedTimeSlotId);

            if (barber == null || service == null || availability == null)
            {
                return NotFound("Invalid selection.");
            }


            // Generate a confirmation token
            var token = Guid.NewGuid().ToString();

            // Create the appointment record
            var appointment = new AppointmentRecords
            {
                BarberId = barber.Id,
                ServiceId = service.Id,
                CustomerName = model.CustomerName,
                CustomerSurname = model.CustomerSurname,
                CustomerEmail = model.CustomerEmail,
                AppointmentDateTime = availability.AvailableFrom,
                ConfirmationToken = token,
                IsConfirmed = false
            };

            _context.AppointmentRecords.Add(appointment);
            await _context.SaveChangesAsync();

            // Generate the confirmation link
            var confirmationUrl = Url.Action(
                "ConfirmAppointment",
                "Appointments",
                new { token },
                Request.Scheme
            );

            // Email content
            var emailContent = $@"
            <p>Değerli {model.CustomerName} müşterimiz,</p>
            <p>Lütfen aşağıdaki linke tıklayarak randevunuzu onaylayın:</p>
            <p><a href='{confirmationUrl}'>RANDEVUYU ONAYLA</a></p>";

            // Send the confirmation email
            await _emailSender.SendEmailAsync(model.CustomerEmail, "Confirm Your Appointment", emailContent);

            return RedirectToAction("BookingConfirmation", new { name = model.CustomerName });

        }

        [HttpGet]
        public IActionResult BookingConfirmation(string name)
        {
            ViewData["CustomerName"] = name;
            return View();
        }





        // GET: ServiceModels/Create
        [Authorize(Roles = Roles.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Roles.Admin)]
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

        [Authorize(Roles = Roles.Admin)]
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

        // GET: ServiceModels/Edit/5
        [Authorize(Roles = Roles.Admin)]
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
        [Authorize(Roles = Roles.Admin)]
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
        [Authorize(Roles = Roles.Admin)]
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
        [Authorize(Roles = Roles.Admin)]
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
