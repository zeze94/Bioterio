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
    public class ElementoequipasController : Controller
    {
        private readonly bd_lesContext _context;

        public ElementoequipasController(bd_lesContext context)
        {
            _context = context;
        }

        // GET: Elementoequipas
        public async Task<IActionResult> Index()
        {
            var bd_lesContext = _context.Elementoequipa.Include(e => e.FuncionarioIdFuncionarioNavigation).Include(e => e.ProjetoIdProjetoNavigation);
            return View(await bd_lesContext.ToListAsync());
        }

        // GET: Elementoequipas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementoequipa = await _context.Elementoequipa
                .Include(e => e.FuncionarioIdFuncionarioNavigation)
                .Include(e => e.ProjetoIdProjetoNavigation)
                .SingleOrDefaultAsync(m => m.ProjetoIdProjeto == id);
            if (elementoequipa == null)
            {
                return NotFound();
            }

            return View(elementoequipa);
        }

        // GET: Elementoequipas/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto");
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome");
            return View();
        }

        // POST: Elementoequipas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Função,ProjetoIdProjeto,FuncionarioIdFuncionario")] Elementoequipa elementoequipa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elementoequipa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", elementoequipa.FuncionarioIdFuncionario);
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome", elementoequipa.ProjetoIdProjeto);
            return View(elementoequipa);
        }

        // GET: Elementoequipas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementoequipa = await _context.Elementoequipa.SingleOrDefaultAsync(m => m.ProjetoIdProjeto == id);
            if (elementoequipa == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", elementoequipa.FuncionarioIdFuncionario);
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome", elementoequipa.ProjetoIdProjeto);
            return View(elementoequipa);
        }

        // POST: Elementoequipas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Função,ProjetoIdProjeto,FuncionarioIdFuncionario")] Elementoequipa elementoequipa)
        {
            if (id != elementoequipa.ProjetoIdProjeto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elementoequipa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElementoequipaExists(elementoequipa.ProjetoIdProjeto))
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
            ViewData["FuncionarioIdFuncionario"] = new SelectList(_context.Funcionario, "IdFuncionario", "NomeCompleto", elementoequipa.FuncionarioIdFuncionario);
            ViewData["ProjetoIdProjeto"] = new SelectList(_context.Projeto, "IdProjeto", "Nome", elementoequipa.ProjetoIdProjeto);
            return View(elementoequipa);
        }

        // GET: Elementoequipas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementoequipa = await _context.Elementoequipa
                .Include(e => e.FuncionarioIdFuncionarioNavigation)
                .Include(e => e.ProjetoIdProjetoNavigation)
                .SingleOrDefaultAsync(m => m.ProjetoIdProjeto == id);
            if (elementoequipa == null)
            {
                return NotFound();
            }

            return View(elementoequipa);
        }

        // POST: Elementoequipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var elementoequipa = await _context.Elementoequipa.SingleOrDefaultAsync(m => m.ProjetoIdProjeto == id);
            _context.Elementoequipa.Remove(elementoequipa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElementoequipaExists(int id)
        {
            return _context.Elementoequipa.Any(e => e.ProjetoIdProjeto == id);
        }
    }
}
