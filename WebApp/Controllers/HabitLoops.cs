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
    public class HabitLoops : Controller
    {
        private readonly AppDbContext _context;

        public HabitLoops(AppDbContext context)
        {
            _context = context;
        }

        // GET: HabitLoops
        public async Task<IActionResult> Index()
        {
            return View(await _context.HabitLoops.ToListAsync());
        }

        // GET: HabitLoops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitLoop = await _context.HabitLoops
                .FirstOrDefaultAsync(m => m.HabitLoopId == id);
            if (habitLoop == null)
            {
                return NotFound();
            }

            return View(habitLoop);
        }

        // GET: HabitLoops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HabitLoops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HabitLoopId")] HabitLoop habitLoop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitLoop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habitLoop);
        }

        // GET: HabitLoops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitLoop = await _context.HabitLoops.FindAsync(id);
            if (habitLoop == null)
            {
                return NotFound();
            }
            return View(habitLoop);
        }

        // POST: HabitLoops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HabitLoopId")] HabitLoop habitLoop)
        {
            if (id != habitLoop.HabitLoopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitLoop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitLoopExists(habitLoop.HabitLoopId))
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
            return View(habitLoop);
        }

        // GET: HabitLoops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitLoop = await _context.HabitLoops
                .FirstOrDefaultAsync(m => m.HabitLoopId == id);
            if (habitLoop == null)
            {
                return NotFound();
            }

            return View(habitLoop);
        }

        // POST: HabitLoops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitLoop = await _context.HabitLoops.FindAsync(id);
            _context.HabitLoops.Remove(habitLoop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitLoopExists(int id)
        {
            return _context.HabitLoops.Any(e => e.HabitLoopId == id);
        }
    }
}
