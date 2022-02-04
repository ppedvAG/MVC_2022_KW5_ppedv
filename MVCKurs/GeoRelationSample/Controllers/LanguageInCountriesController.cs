#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoRelationSample.Data;
using GeoRelationSample.Models;

namespace GeoRelationSample.Controllers
{
    public class LanguageInCountriesController : Controller
    {
        private readonly GeoDbContext _context;

        public LanguageInCountriesController(GeoDbContext context)
        {
            _context = context;
        }

        // GET: LanguageInCountries
        public async Task<IActionResult> Index()
        {
            var geoDbContext = _context.LanguageInCountry.Include(l => l.CountryRef).Include(l => l.Languages);
            return View(await geoDbContext.ToListAsync());
        }

        // GET: LanguageInCountries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageInCountry = await _context.LanguageInCountry
                .Include(l => l.CountryRef)
                .Include(l => l.Languages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languageInCountry == null)
            {
                return NotFound();
            }

            return View(languageInCountry);
        }

        // GET: LanguageInCountries/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Name");
            return View();
        }

        // POST: LanguageInCountries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Percent,LanguageId,CountryId")] LanguageInCountry languageInCountry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(languageInCountry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", languageInCountry.CountryId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Name", languageInCountry.LanguageId);
            return View(languageInCountry);
        }

        // GET: LanguageInCountries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageInCountry = await _context.LanguageInCountry.FindAsync(id);
            if (languageInCountry == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", languageInCountry.CountryId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Name", languageInCountry.LanguageId);
            return View(languageInCountry);
        }

        // POST: LanguageInCountries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Percent,LanguageId,CountryId")] LanguageInCountry languageInCountry)
        {
            if (id != languageInCountry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(languageInCountry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageInCountryExists(languageInCountry.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", languageInCountry.CountryId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Name", languageInCountry.LanguageId);
            return View(languageInCountry);
        }

        // GET: LanguageInCountries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageInCountry = await _context.LanguageInCountry
                .Include(l => l.CountryRef)
                .Include(l => l.Languages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languageInCountry == null)
            {
                return NotFound();
            }

            return View(languageInCountry);
        }

        // POST: LanguageInCountries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var languageInCountry = await _context.LanguageInCountry.FindAsync(id);
            _context.LanguageInCountry.Remove(languageInCountry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageInCountryExists(int id)
        {
            return _context.LanguageInCountry.Any(e => e.Id == id);
        }
    }
}
