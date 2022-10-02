using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPSTracker.Data;
using FPSTracker.Models;

namespace FPSTracker.Controllers
{
    public class UserNamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserNamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserNames
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserName.ToListAsync());
        }

        // GET: UserNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserName == null)
            {
                return NotFound();
            }

            var userName = await _context.UserName
                .FirstOrDefaultAsync(m => m.UserNameId == id);
            if (userName == null)
            {
                return NotFound();
            }

            return View(userName);
        }

        // GET: UserNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserNameId,Name")] UserName userName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userName);
        }

        // GET: UserNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserName == null)
            {
                return NotFound();
            }

            var userName = await _context.UserName.FindAsync(id);
            if (userName == null)
            {
                return NotFound();
            }
            return View(userName);
        }

        // POST: UserNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserNameId,Name")] UserName userName)
        {
            if (id != userName.UserNameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserNameExists(userName.UserNameId))
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
            return View(userName);
        }

        // GET: UserNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserName == null)
            {
                return NotFound();
            }

            var userName = await _context.UserName
                .FirstOrDefaultAsync(m => m.UserNameId == id);
            if (userName == null)
            {
                return NotFound();
            }

            return View(userName);
        }

        // POST: UserNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserName == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserName'  is null.");
            }
            var userName = await _context.UserName.FindAsync(id);
            if (userName != null)
            {
                _context.UserName.Remove(userName);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserNameExists(int id)
        {
          return _context.UserName.Any(e => e.UserNameId == id);
        }
    }
}
