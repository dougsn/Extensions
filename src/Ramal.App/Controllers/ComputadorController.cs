using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ramal.App.Data;
using Ramal.App.Extensions;
using Ramal.App.ViewModels;
using Ramal.Business.Interfaces;
using Ramal.Business.Models;
using Ramal.Business.Services;
using Ramal.Data.Repository;

namespace Ramal.App.Controllers
{
    [Authorize]
    [ClaimsAuthorize("Admin","Admin")]
    public class ComputadorController : Controller
    {
        private readonly IComputadorRepository _computadorRepository;
        private readonly IComputadorService _computadorService;
        private readonly ISetorRepository _setorRepository;
        private readonly IMapper _mapper;

        public ComputadorController(IComputadorRepository computadorRepository, IComputadorService computadorService, ISetorRepository setorRepository, IMapper mapper)
        {
            _computadorRepository = computadorRepository;
            _computadorService = computadorService;
            _setorRepository = setorRepository;
            _mapper = mapper;
        }




        // GET: Computador
        [Route("Computador")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ComputadorViewModel>>(await _computadorRepository.ObterComputadoresSetores()));
        }

        // GET: Computador/Details/5
        [Route("Computador/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var computadorlViewModel = await ObterComputador(id);
            if (computadorlViewModel == null)
            {
                return NotFound();
            }

            return View(computadorlViewModel);
        }

        // GET: Computador/Create
        [Route("NovoComputador")]
        public async Task<IActionResult> CreateAsync()
        {
            var computadorlViewModel = await PopularSetores(new ComputadorViewModel());
            return View(computadorlViewModel);
        }

        // POST: Computador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("NovoComputador")]
        public async Task<IActionResult> Create(ComputadorViewModel computadorViewModel)
        {
            computadorViewModel = await PopularSetores(computadorViewModel);
            if (!ModelState.IsValid) return View(computadorViewModel);


            await _computadorService.Adicionar(_mapper.Map<Computador>(computadorViewModel));
            return RedirectToAction(nameof(Index));
        }

        // GET: Computador/Edit/5
        [Route("EditarComputador/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var computadorViewModel = await ObterComputador(id);
            computadorViewModel.Setores = _mapper.Map<IEnumerable<SetorViewModel>>(await _setorRepository.ObterTodos());

            if (computadorViewModel == null)
            {
                return NotFound();
            }
            return View(computadorViewModel);
        }

        // POST: Computador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("EditarComputador/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, ComputadorViewModel computadorViewModel)
        {
            if (id != computadorViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(computadorViewModel);

            await _computadorService.Atualizar(_mapper.Map<Computador>(computadorViewModel));


            return RedirectToAction(nameof(Index));
        }

        // GET: Computador/Delete/5
        [Route("ExcluirComputador/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var computadorViewModel = await ObterComputador(id);

            if (computadorViewModel == null) return NotFound();


            return View(computadorViewModel);
        }

        // POST: Computador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("ExcluirComputador/{id:guid}")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var computadorViewModel = await ObterComputador(id);

            if (computadorViewModel == null) return NotFound();


            await _computadorService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<ComputadorViewModel> PopularSetores(ComputadorViewModel computador)
        {
            computador.Setores = _mapper.Map<IEnumerable<SetorViewModel>>(await _setorRepository.ObterTodos());
            return computador;
        }

        private async Task<ComputadorViewModel> ObterComputador(Guid id)
        {
            var computador = _mapper.Map<ComputadorViewModel>(await _computadorRepository.ObterComputadorSetor(id));

            return computador;
        }
    }
}
