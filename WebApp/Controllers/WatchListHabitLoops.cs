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
    public class WatchListHabitLoops : Controller
    {
        private readonly AppDbContext _context;

        public WatchListHabitLoops(AppDbContext context)
        {
            _context = context;
        }

        // GET: WatchListHabitLoops
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.WatchListHabitLoops.Include(w => w.HabitLoop).Include(w => w.WatchList);
            return View(await appDbContext.ToListAsync());
        }

        // GET: WatchListHabitLoops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchListHabitLoop = await _context.WatchListHabitLoops
                .Include(w => w.HabitLoop)
                .Include(w => w.WatchList)
                .FirstOrDefaultAsync(m => m.WatchListHabitLoopId == id);
            if (watchListHabitLoop == null)
            {
                return NotFound();
            }

            return View(watchListHabitLoop);
        }

        // GET: WatchListHabitLoops/Create
        public IActionResult Create()
        {
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId");
            ViewData["WatchListId"] = new SelectList(_context.WatchLists, "WatchListId", "WatchListId");
            return View();
        }

        // POST: WatchListHabitLoops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WatchListHabitLoopId,HabitLoopId,WatchListId")] WatchListHabitLoop watchListHabitLoop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(watchListHabitLoop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId", watchListHabitLoop.HabitLoopId);
            ViewData["WatchListId"] = new SelectList(_context.WatchLists, "WatchListId", "WatchListId", watchListHabitLoop.WatchListId);
            return View(watchListHabitLoop);
        }

        // GET: WatchListHabitLoops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchListHabitLoop = await _context.WatchListHabitLoops.FindAsync(id);
            if (watchListHabitLoop == null)
            {
                return NotFound();
            }
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId", watchListHabitLoop.HabitLoopId);
            ViewData["WatchListId"] = new SelectList(_context.WatchLists, "WatchListId", "WatchListId", watchListHabitLoop.WatchListId);
            return View(watchListHabitLoop);
        }

        // POST: WatchListHabitLoops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WatchListHabitLoopId,HabitLoopId,WatchListId")] WatchListHabitLoop watchListHabitLoop)
        {
            if (id != watchListHabitLoop.WatchListHabitLoopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watchListHabitLoop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatchListHabitLoopExists(watchListHabitLoop.WatchListHabitLoopId))
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
            ViewData["HabitLoopId"] = new SelectList(_context.HabitLoops, "HabitLoopId", "HabitLoopId", watchListHabitLoop.HabitLoopId);
            ViewData["WatchListId"] = new SelectList(_context.WatchLists, "WatchListId", "WatchListId", watchListHabitLoop.WatchListId);
            return View(watchListHabitLoop);
        }

        // GET: WatchListHabitLoops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchListHabitLoop = await _context.WatchListHabitLoops
                .Include(w => w.HabitLoop)
                .Include(w => w.WatchList)
                .FirstOrDefaultAsync(m => m.WatchListHabitLoopId == id);
            if (watchListHabitLoop == null)
            {
                return NotFound();
            }

            return View(watchListHabitLoop);
        }

        // POST: WatchListHabitLoops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var watchListHabitLoop = await _context.WatchListHabitLoops.FindAsync(id);
            _context.WatchListHabitLoops.Remove(watchListHabitLoop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WatchListHabitLoopExists(int id)
        {
            return _context.WatchListHabitLoops.Any(e => e.WatchListHabitLoopId == id);
        }
    }
}
