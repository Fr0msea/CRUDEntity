using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDEntity.Models;

namespace CRUDEntity.Controllers
{
    public class EmpregadosController : Controller
    {
        private readonly EmpregadoContext _context;

        public EmpregadosController(EmpregadoContext context)
        {
            _context = context;
        }

        // GET: Empregados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empregados.ToListAsync());
        }



        // GET: Empregados/Create
        public IActionResult AddOrEdit(int id=0)
        {
            if (id==0)
            {
                return View(new Empregado());
            }
            return View(_context.Empregados.Find(id));
        }

        // POST: Empregados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("EmpregadoId,NomeCompleto,Matricula,Cargo,Cidade")] Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                if (empregado.EmpregadoId == 0)
                    _context.Add(empregado);
                else
                    _context.Update(empregado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empregado);
        }

        //// GET: Empregados/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var empregado = await _context.Empregados.FindAsync(id);
        //    if (empregado == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(empregado);
        //}

        // POST: Empregados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("EmpregadoId,NomeCompleto,Matricula,Cargo,Cidade")] Empregado empregado)
        //{
        //    if (id != empregado.EmpregadoId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(empregado);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EmpregadoExists(empregado.EmpregadoId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(empregado);
        //}

        // GET: Empregados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregado = await _context.Empregados
                .FirstOrDefaultAsync(m => m.EmpregadoId == id);
            if (empregado == null)
            {
                return NotFound();
            }

            return View(empregado);
        }

        // POST: Empregados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empregado = await _context.Empregados.FindAsync(id);
            _context.Empregados.Remove(empregado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpregadoExists(int id)
        {
            return _context.Empregados.Any(e => e.EmpregadoId == id);
        }
    }
}
