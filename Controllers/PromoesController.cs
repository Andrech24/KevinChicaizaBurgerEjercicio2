﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KevinChicaizaBurgerEjercicio2.Data;
using KevinChicaizaBurgerEjercicio2.Models;

namespace KevinChicaizaBurgerEjercicio2.Controllers
{
    public class PromoesController : Controller
    {
        private readonly KevinChicaizaBurgerEjercicio2Context _context;

        public PromoesController(KevinChicaizaBurgerEjercicio2Context context)
        {
            _context = context;
        }

        // GET: Promoes
        public async Task<IActionResult> Index()
        {
            var kevinChicaizaBurgerEjercicio2Context = _context.Promo.Include(p => p.Burger);
            return View(await kevinChicaizaBurgerEjercicio2Context.ToListAsync());
        }

        // GET: Promoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.Promoid == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // GET: Promoes/Create
        public IActionResult Create()
        {
            ViewData["Burgerid"] = new SelectList(_context.Burger, "Burgerid", "Name");
            return View();
        }

        // POST: Promoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Promoid,Descripcion,FechaPromo,Burgerid")] Promo promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Burgerid"] = new SelectList(_context.Burger, "Burgerid", "Name", promo.Burgerid);
            return View(promo);
        }

        // GET: Promoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }
            ViewData["Burgerid"] = new SelectList(_context.Burger, "Burgerid", "Name", promo.Burgerid);
            return View(promo);
        }

        // POST: Promoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Promoid,Descripcion,FechaPromo,Burgerid")] Promo promo)
        {
            if (id != promo.Promoid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoExists(promo.Promoid))
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
            ViewData["Burgerid"] = new SelectList(_context.Burger, "Burgerid", "Name", promo.Burgerid);
            return View(promo);
        }

        // GET: Promoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.Promoid == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // POST: Promoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promo = await _context.Promo.FindAsync(id);
            if (promo != null)
            {
                _context.Promo.Remove(promo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoExists(int id)
        {
            return _context.Promo.Any(e => e.Promoid == id);
        }
    }
}
