using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Простое_расписние.Data;
using Простое_расписние.Models;

namespace Простое_расписние.Controllers
{
    public class ATsController : Controller
    {
        private readonly Простое_расписниеContext _context;

        public ATsController(Простое_расписниеContext context)
        {
            _context = context;
        }

        // GET: ATs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AT.ToListAsync());
        }

        // GET: ATs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aT = await _context.AT
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aT == null)
            {
                return NotFound();
            }

            return View(aT);
        }

        // GET: ATs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ATs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Lesson,Lector,Mentor,Number,Place,IsOnline")] AT aT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aT);
        }

        // GET: ATs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aT = await _context.AT.FindAsync(id);
            if (aT == null)
            {
                return NotFound();
            }
            return View(aT);
        }

        // POST: ATs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Lesson,Lector,Mentor,Number,Place,IsOnline")] AT aT)
        {
            if (id != aT.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ATExists(aT.Id))
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
            return View(aT);
        }

        // GET: ATs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aT = await _context.AT
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aT == null)
            {
                return NotFound();
            }

            return View(aT);
        }

        // POST: ATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aT = await _context.AT.FindAsync(id);
            if (aT != null)
            {
                _context.AT.Remove(aT);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ATExists(int id)
        {
            return _context.AT.Any(e => e.Id == id);
        }
    }
}
