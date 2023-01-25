using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ramal.App.Data;
using Ramal.App.ViewModels;
using Ramal.Data;

namespace Ramal.App.Controllers
{
    public class FuncionarioViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly MeuDbContext _context2;

        public FuncionarioViewModelsController(ApplicationDbContext context, MeuDbContext context2)
        {
            _context = context;
            _context2 = context2;
        }

        // GET: FuncionarioViewModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.FuncionarioViewModel.ToListAsync());
        }

        // GET: FuncionarioViewModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FuncionarioViewModel == null)
            {
                return NotFound();
            }

            var funcionarioViewModel = await _context.FuncionarioViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionarioViewModel == null)
            {
                return NotFound();
            }

            return View(funcionarioViewModel);
        }

        // GET: FuncionarioViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuncionarioViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Setor,Ramal,Email")] FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                funcionarioViewModel.Id = Guid.NewGuid();
                _context.Add(funcionarioViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionarioViewModel);
        }

        // GET: FuncionarioViewModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FuncionarioViewModel == null)
            {
                return NotFound();
            }

            var funcionarioViewModel = await _context.FuncionarioViewModel.FindAsync(id);
            if (funcionarioViewModel == null)
            {
                return NotFound();
            }
            return View(funcionarioViewModel);
        }

        // POST: FuncionarioViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Setor,Ramal,Email")] FuncionarioViewModel funcionarioViewModel)
        {
            if (id != funcionarioViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionarioViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioViewModelExists(funcionarioViewModel.Id))
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
            return View(funcionarioViewModel);
        }

        // GET: FuncionarioViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FuncionarioViewModel == null)
            {
                return NotFound();
            }

            var funcionarioViewModel = await _context.FuncionarioViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionarioViewModel == null)
            {
                return NotFound();
            }

            return View(funcionarioViewModel);
        }

        // POST: FuncionarioViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FuncionarioViewModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FuncionarioViewModel'  is null.");
            }
            var funcionarioViewModel = await _context.FuncionarioViewModel.FindAsync(id);
            if (funcionarioViewModel != null)
            {
                _context.FuncionarioViewModel.Remove(funcionarioViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioViewModelExists(Guid id)
        {
          return _context.FuncionarioViewModel.Any(e => e.Id == id);
        }
    }
}
