﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bioterio.Models;

namespace Bioterio.Controllers
{
    public class ConselhosController : Controller
    {
        private readonly bd_lesContext _context;

        public ConselhosController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Conselhos
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Conselho.Include(c => c.Distrito);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Conselhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conselho = await _context.Conselho
                .Include(c => c.Distrito)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (conselho == null)
            {
                return NotFound();
            }

            return View(conselho);
        }

        // GET: Conselhos/Create
        public IActionResult Create()
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id");
            return View();
        }

        // POST: Conselhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeConselho,DistritoId")] Conselho conselho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conselho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", conselho.DistritoId);
            return View(conselho);
        }

        // GET: Conselhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conselho = await _context.Conselho.SingleOrDefaultAsync(m => m.Id == id);
            if (conselho == null)
            {
                return NotFound();
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", conselho.DistritoId);
            return View(conselho);
        }

        // POST: Conselhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeConselho,DistritoId")] Conselho conselho)
        {
            if (id != conselho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conselho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConselhoExists(conselho.Id))
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
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "Id", "Id", conselho.DistritoId);
            return View(conselho);
        }

        // GET: Conselhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conselho = await _context.Conselho
                .Include(c => c.Distrito)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (conselho == null)
            {
                return NotFound();
            }

            return View(conselho);
        }

        // POST: Conselhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conselho = await _context.Conselho.SingleOrDefaultAsync(m => m.Id == id);
            _context.Conselho.Remove(conselho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConselhoExists(int id)
        {
            return _context.Conselho.Any(e => e.Id == id);
        }
    }
}
