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
    public class Pupils : Controller
    {
        private readonly AppDbContext _context;

        public Pupils(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pupils
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Pupils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupil = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pupil == null)
            {
                return NotFound();
            }

            return View(pupil);
        }

        // GET: Pupils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pupils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Pupil pupil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pupil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pupil);
        }

        // GET: Pupils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupil = await _context.Users.FindAsync(id);
            if (pupil == null)
            {
                return NotFound();
            }
            return View(pupil);
        }

        // POST: Pupils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Pupil pupil)
        {
            if (id != pupil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pupil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PupilExists(pupil.Id))
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
            return View(pupil);
        }

        // GET: Pupils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupil = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pupil == null)
            {
                return NotFound();
            }

            return View(pupil);
        }

        // POST: Pupils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pupil = await _context.Users.FindAsync(id);
            _context.Users.Remove(pupil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PupilExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
