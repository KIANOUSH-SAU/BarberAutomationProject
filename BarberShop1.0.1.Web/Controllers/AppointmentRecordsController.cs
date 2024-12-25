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
    public class AppointmentRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppointmentRecords
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AppointmentRecords.Include(a => a.Barber).Include(a => a.Service);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AppointmentRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentRecords = await _context.AppointmentRecords
                .Include(a => a.Barber)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentRecords == null)
            {
                return NotFound();
            }

            return View(appointmentRecords);
        }

        // GET: AppointmentRecords/Create
        public IActionResult Create()
        {
            ViewData["BarberId"] = new SelectList(_context.Barbers, "Id", "Id");
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Id");
            return View();
        }

        // POST: AppointmentRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BarberId,ServiceId,CustomerName,CustomerSurname,CustomerEmail,AppointmentDateTime,ConfirmationToken,IsConfirmed")] AppointmentRecords appointmentRecords)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentRecords);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BarberId"] = new SelectList(_context.Barbers, "Id", "Id", appointmentRecords.BarberId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Id", appointmentRecords.ServiceId);
            return View(appointmentRecords);
        }

        // GET: AppointmentRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentRecords = await _context.AppointmentRecords.FindAsync(id);
            if (appointmentRecords == null)
            {
                return NotFound();
            }
            ViewData["BarberId"] = new SelectList(_context.Barbers, "Id", "Id", appointmentRecords.BarberId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Id", appointmentRecords.ServiceId);
            return View(appointmentRecords);
        }

        // POST: AppointmentRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BarberId,ServiceId,CustomerName,CustomerSurname,CustomerEmail,AppointmentDateTime,ConfirmationToken,IsConfirmed")] AppointmentRecords appointmentRecords)
        {
            if (id != appointmentRecords.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentRecords);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentRecordsExists(appointmentRecords.Id))
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
            ViewData["BarberId"] = new SelectList(_context.Barbers, "Id", "Id", appointmentRecords.BarberId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Id", appointmentRecords.ServiceId);
            return View(appointmentRecords);
        }

        // GET: AppointmentRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentRecords = await _context.AppointmentRecords
                .Include(a => a.Barber)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentRecords == null)
            {
                return NotFound();
            }

            return View(appointmentRecords);
        }

        // POST: AppointmentRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentRecords = await _context.AppointmentRecords.FindAsync(id);
            if (appointmentRecords != null)
            {
                _context.AppointmentRecords.Remove(appointmentRecords);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentRecordsExists(int id)
        {
            return _context.AppointmentRecords.Any(e => e.Id == id);
        }
    }
}
