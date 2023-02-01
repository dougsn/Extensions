using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ramal.App.Data;
using Ramal.App.ViewModels;
using Ramal.Business.Interfaces;
using Ramal.Business.Models;
using Ramal.Data.Repository;

namespace Ramal.App.Controllers
{
    public class SetorController : Controller
    {
        private readonly ISetorRepository _setorRepository;
        private readonly IMapper _mapper;

        public SetorController(ISetorRepository setorRepository, IMapper mapper)
        {
            _setorRepository = setorRepository;
            _mapper = mapper;
        }



        // GET: Setor
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SetorViewModel>>(await _setorRepository.ObterTodos()));
        }

        // GET: Setor/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var setorViewModel = await ObterSetorFuncionario(id);
            if (setorViewModel == null)
            {
                return NotFound();
            }


            return View(setorViewModel);
        }

        // GET: Setor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Setor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SetorViewModel setorViewModel)
        {
            if (!ModelState.IsValid) return View(setorViewModel);

            var setor = _mapper.Map<Setor>(setorViewModel);
            await _setorRepository.Adicionar(setor);
            return RedirectToAction(nameof(Index));
        }

        // GET: Setor/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var setorViewModel = await ObterSetorFuncionario(id);

            if (setorViewModel == null)
            {
                return NotFound();
            }
            return View(setorViewModel);
        }

        // POST: Setor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SetorViewModel setorViewModel)
        {
            if (id != setorViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(setorViewModel);

            var setor = _mapper.Map<Setor>(setorViewModel);
            await _setorRepository.Atualizar(setor);

            return RedirectToAction(nameof(Index));
        }

        // GET: Setor/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var setorViewModel = await ObterSetorFuncionario(id);
            ; if (setorViewModel == null) return NotFound();


            return View(setorViewModel);
        }

        // POST: Setor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var setorViewModel = await ObterSetorFuncionario(id);

            if (setorViewModel == null) return NotFound();


            await _setorRepository.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<SetorViewModel> ObterSetorFuncionario(Guid id)
        {
            return _mapper.Map<SetorViewModel>(await _setorRepository.ObterSetorFuncionario(id));
        }

       
    }
}
