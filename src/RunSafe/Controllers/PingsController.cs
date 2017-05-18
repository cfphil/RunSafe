using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RunSafe.Data;
using RunSafe.Models;

namespace RunSafe.Controllers
{
    public class PingsController : Controller
    {
        private readonly AssetContext _context;

        public PingsController(AssetContext context)
        {
            _context = context;    
        }

        // GET: Pings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ping.ToListAsync());
        }

        // GET: Pings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ping = await _context.Ping.SingleOrDefaultAsync(m => m.Ping_ID == id);
            if (ping == null)
            {
                return NotFound();
            }

            return View(ping);
        }

        // GET: Pings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ping_ID,battery,datetime_logged,datetime_stored,latitude,longtitude,signal")] Ping ping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ping);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ping);
        }

        // GET: Pings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ping = await _context.Ping.SingleOrDefaultAsync(m => m.Ping_ID == id);
            if (ping == null)
            {
                return NotFound();
            }
            return View(ping);
        }

        // POST: Pings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ping_ID,battery,datetime_logged,datetime_stored,latitude,longtitude,signal")] Ping ping)
        {
            if (id != ping.Ping_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PingExists(ping.Ping_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(ping);
        }

        // GET: Pings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ping = await _context.Ping.SingleOrDefaultAsync(m => m.Ping_ID == id);
            if (ping == null)
            {
                return NotFound();
            }

            return View(ping);
        }

        // POST: Pings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ping = await _context.Ping.SingleOrDefaultAsync(m => m.Ping_ID == id);
            _context.Ping.Remove(ping);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PingExists(int id)
        {
            return _context.Ping.Any(e => e.Ping_ID == id);
        }
    }
}
