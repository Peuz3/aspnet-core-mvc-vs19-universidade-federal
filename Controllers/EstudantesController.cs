using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversidadeFederal.Data;
using UniversidadeFederal.Models;

namespace UniversidadeFederal.Controllers
{
    public class EstudantesController : Controller
    {
        private readonly EscolaContexto _context;

        public EstudantesController(EscolaContexto context)
        {
            _context = context;
        }

        // GET: Estudantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudantes.ToListAsync());
        }

        // GET: Estudantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*
            var estudante = await _context.Estudantes
                .FirstOrDefaultAsync(m => m.EstudanteID == id); 
                */
            var estudante = await _context.Estudantes
           .Include(s => s.Matriculas)
               .ThenInclude(e => e.Curso)
           .AsNoTracking()
           .SingleOrDefaultAsync(m => m.EstudanteID == id);

            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // GET: Estudantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SobreNome,Nome,DataMatricula")] Estudante estudante)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(estudante);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            catch (DbUpdateException /* ex */)
            {
                //Logar o erro (descomente a variável ex e escreva um log
                ModelState.AddModelError("", "Não foi possível salvar. " +
                    "Tente novamente, e se o problema persistir " +
                    "chame o suporte.");
            }


            return View(estudante);
        }

        // GET: Estudantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante == null)
            {
                return NotFound();
            }
            return View(estudante);
        }

        // POST: Estudantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstudanteID,SobreNome,Nome,DataMatricula")] Estudante estudante)
        {
            if (id != estudante.EstudanteID)
            {
                return NotFound();
            }

            var atualizarEstudante = await _context.Estudantes.SingleOrDefaultAsync(s => s.EstudanteID == id);
            if (await TryUpdateModelAsync<Estudante>(
                atualizarEstudante,
                "",
                s => s.Nome, s => s.SobreNome, s => s.DataMatricula))

                if (ModelState.IsValid)
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                    catch (DbUpdateException /* ex */)
                    {
                        //Logar o erro (descomente a variável ex e escreva um log
                        ModelState.AddModelError("", "Não foi possível salvar. " +
                            "Tente novamente, e se o problema persistir " +
                            "chame o suporte.");
                    }
                }
            return View(atualizarEstudante);
        }

        // GET: Estudantes/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EstudanteID == id);
            if (estudante == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "A exclusão falhou. Tente novamente e se o problema persistir " +
                    "contate o suporte.";
            }

            return View(estudante);
        }

        // POST: Estudantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudante = await _context.Estudantes
                .AsNoTracking()//Desabilita o rastreamento de dados e melhora o desempenho da aplicação
                .SingleOrDefaultAsync(m => m.EstudanteID == id);

            if(estudante == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                _context.Estudantes.Remove(estudante);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

        }

        private bool EstudanteExists(int id)
        {
            return _context.Estudantes.Any(e => e.EstudanteID == id);
        }
    }
}
