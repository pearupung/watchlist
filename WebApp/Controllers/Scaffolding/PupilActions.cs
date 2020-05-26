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
    public class PupilActions : Controller
    {
        private readonly AppDbContext _context;

        public PupilActions(AppDbContext context)
        {
            _context = context;
        }

        // GET: PupilActions
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Actions.Include(p => p.HabitLoop);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PupilActions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupilAction = await _context.Actions
                .Include(p => p.HabitLoop)
                .FirstOrDefaultAsync(m => m.PupilActionId == id);
            if (pupilAction == null)
            {
                return NotFound();
            }

            return View(pupilAction);
        }

        // GET: PupilActions/Create
        public IActionResult Create()
        {
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId");
            return View();
        }

        // POST: PupilActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PupilActionId,ActionName,HabitLoopId")] PupilAction pupilAction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pupilAction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId", pupilAction.HabitLoopId);
            return View(pupilAction);
        }

        // GET: PupilActions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupilAction = await _context.Actions.FindAsync(id);
            if (pupilAction == null)
            {
                return NotFound();
            }
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId", pupilAction.HabitLoopId);
            return View(pupilAction);
        }

        // POST: PupilActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PupilActionId,ActionName,HabitLoopId")] PupilAction pupilAction)
        {
            if (id != pupilAction.PupilActionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pupilAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PupilActionExists(pupilAction.PupilActionId))
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
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId", pupilAction.HabitLoopId);
            return View(pupilAction);
        }

        // GET: PupilActions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupilAction = await _context.Actions
                .Include(p => p.HabitLoop)
                .FirstOrDefaultAsync(m => m.PupilActionId == id);
            if (pupilAction == null)
            {
                return NotFound();
            }

            return View(pupilAction);
        }

        // POST: PupilActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pupilAction = await _context.Actions.FindAsync(id);
            _context.Actions.Remove(pupilAction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PupilActionExists(int id)
        {
            return _context.Actions.Any(e => e.PupilActionId == id);
        }
    }
}
