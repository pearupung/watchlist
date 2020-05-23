using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Controllers
{
    public class Triggers : Controller
    {
        private readonly AppDbContext _context;

        public Triggers(AppDbContext context)
        {
            _context = context;
        }

        // GET: Triggers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Triggers.Include(t => t.HabitLoop);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Triggers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trigger = await _context.Triggers
                .Include(t => t.HabitLoop)
                .FirstOrDefaultAsync(m => m.TriggerId == id);
            if (trigger == null)
            {
                return NotFound();
            }

            return View(trigger);
        }

        // GET: Triggers/Create
        public IActionResult Create()
        {
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId");
            return View();
        }

        // POST: Triggers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TriggerId,TriggerName,HabitLoopId")] Trigger trigger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trigger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId", trigger.HabitLoopId);
            return View(trigger);
        }

        // GET: Triggers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trigger = await _context.Triggers.FindAsync(id);
            if (trigger == null)
            {
                return NotFound();
            }
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId", trigger.HabitLoopId);
            return View(trigger);
        }

        // POST: Triggers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TriggerId,TriggerName,HabitLoopId")] Trigger trigger)
        {
            if (id != trigger.TriggerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trigger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TriggerExists(trigger.TriggerId))
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
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId", trigger.HabitLoopId);
            return View(trigger);
        }

        // GET: Triggers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trigger = await _context.Triggers
                .Include(t => t.HabitLoop)
                .FirstOrDefaultAsync(m => m.TriggerId == id);
            if (trigger == null)
            {
                return NotFound();
            }

            return View(trigger);
        }

        // POST: Triggers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trigger = await _context.Triggers.FindAsync(id);
            _context.Triggers.Remove(trigger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TriggerExists(int id)
        {
            return _context.Triggers.Any(e => e.TriggerId == id);
        }
    }
}
