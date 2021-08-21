using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fjallGuiderna.Data;
using fjallGuiderna.Models;
using Microsoft.AspNetCore.Authorization;

namespace fjallGuiderna.Controllers
{
    public class NatureActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NatureActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NatureActivities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NatureActivity.Include(n => n.Category).Include(n => n.Guide).Include(n => n.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NatureActivities
        [Authorize]
        public async Task<IActionResult> IndexAdmin()
        {
            var applicationDbContext = _context.NatureActivity.Include(n => n.Category).Include(n => n.Guide).Include(n => n.Location);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: NatureActivities/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natureActivity = await _context.NatureActivity
                .Include(n => n.Category)
                .Include(n => n.Guide)
                .Include(n => n.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (natureActivity == null)
            {
                return NotFound();
            }

            return View(natureActivity);
        }

        // GET: NatureActivities/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
            ViewData["GuideId"] = new SelectList(_context.Guide, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Id");
            return View();
        }

        // POST: NatureActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,PictureUrl,Name,Description,Price,StartDate,EndDate,NumberOfParticipants,LocationId,GuideId,CategoryId")] NatureActivity natureActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(natureActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", natureActivity.CategoryId);
            ViewData["GuideId"] = new SelectList(_context.Guide, "Id", "Id", natureActivity.GuideId);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Id", natureActivity.LocationId);
            return View(natureActivity);
        }

        // GET: NatureActivities/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natureActivity = await _context.NatureActivity.FindAsync(id);
            if (natureActivity == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", natureActivity.CategoryId);
            ViewData["GuideId"] = new SelectList(_context.Guide, "Id", "Id", natureActivity.GuideId);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Id", natureActivity.LocationId);
            return View(natureActivity);
        }

        // POST: NatureActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PictureUrl,Name,Description,Price,StartDate,EndDate,NumberOfParticipants,LocationId,GuideId,CategoryId")] NatureActivity natureActivity)
        {
            if (id != natureActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(natureActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NatureActivityExists(natureActivity.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", natureActivity.CategoryId);
            ViewData["GuideId"] = new SelectList(_context.Guide, "Id", "Id", natureActivity.GuideId);
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "Id", natureActivity.LocationId);
            return View(natureActivity);
        }

        // GET: NatureActivities/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natureActivity = await _context.NatureActivity
                .Include(n => n.Category)
                .Include(n => n.Guide)
                .Include(n => n.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (natureActivity == null)
            {
                return NotFound();
            }

            return View(natureActivity);
        }

        // POST: NatureActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var natureActivity = await _context.NatureActivity.FindAsync(id);
            _context.NatureActivity.Remove(natureActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NatureActivityExists(int id)
        {
            return _context.NatureActivity.Any(e => e.Id == id);
        }
    }
}
