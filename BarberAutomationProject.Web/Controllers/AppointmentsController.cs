using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BarberAutomationProject.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BarberAutomationProject.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointments/ConfirmAppointment?token=your-token-here
        [HttpGet]
        public async Task<IActionResult> ConfirmAppointment(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return View("Error", "Invalid or missing confirmation token.");
            }

            // Find the appointment by confirmation token
            var appointment = await _context.AppointmentRecords
                .FirstOrDefaultAsync(a => a.ConfirmationToken == token);

            if (appointment == null)
            {
                return View("Error", "Invalid or missing confirmation token.");
            }

            if (appointment.IsConfirmed)
            {
                return View("Error", "This appointment has already been confirmed.");
            }

            // Mark the appointment as confirmed
            appointment.IsConfirmed = true;

            // Find the matching BarberAvailability record
            var availability = await _context.BarberAvailabilities
                .FirstOrDefaultAsync(a => a.BarberId == appointment.BarberId &&
                                          a.AvailableFrom == appointment.AppointmentDateTime);

            if (availability != null)
            {
                // Mark the slot as booked
                availability.IsBooked = true;
                _context.BarberAvailabilities.Update(availability);
            }
            else
            {
                Console.WriteLine($"No availability found for BarberId: {appointment.BarberId} and AppointmentDateTime: {appointment.AppointmentDateTime}");
            }

            // Save changes to the database
            _context.AppointmentRecords.Update(appointment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "ServiceModels");
        }


    }
}
