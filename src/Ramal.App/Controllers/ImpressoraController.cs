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
    [ClaimsAuthorize("Admin", "Admin")]
    public class ImpressoraController : Controller
    {
        private readonly IImpressoraRepository _impressoraRepository;
        private readonly IImpressoraService _impressoraService;
        private readonly ISetorRepository _setorRepository;
        private readonly IMapper _mapper;

        public ImpressoraController(IImpressoraRepository impressoraRepository, IImpressoraService impressoraService, ISetorRepository setorRepository, IMapper mapper)
        {
            _impressoraRepository = impressoraRepository;
            _impressoraService = impressoraService;
            _setorRepository = setorRepository;
            _mapper = mapper;
        }



        // GET: Impressora
        [Route("Impressora")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ImpressoraViewModel>>(await _impressoraRepository.ObterImpressorasSetores()));
        }

        // GET: Impressora/Details/5
        [Route("Impressora/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var impressoraViewModel = await Obterimpressora(id);
            if (impressoraViewModel == null)
            {
                return NotFound();
            }

            return View(impressoraViewModel);
        }

        // GET: Impressora/Create
        [Route("NovaImpressora")]
        public async Task<IActionResult> Create()
        {
            var impressoraViewModel = await PopularSetores(new ImpressoraViewModel());
            return View(impressoraViewModel);
        }

        // POST: Impressora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("NovaImpressora")]
        public async Task<IActionResult> Create(ImpressoraViewModel impressoraViewModel)
        {
            impressoraViewModel = await PopularSetores(impressoraViewModel);
            if (!ModelState.IsValid) return View(impressoraViewModel);


            await _impressoraService.Adicionar(_mapper.Map<Impressora>(impressoraViewModel));
            return RedirectToAction(nameof(Index));
        }

        // GET: Impressora/Edit/5
        [Route("EditarImpressora/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var impressoraViewModel = await Obterimpressora(id);
            impressoraViewModel.Setores = _mapper.Map<IEnumerable<SetorViewModel>>(await _setorRepository.ObterTodos());

            if (impressoraViewModel == null)
            {
                return NotFound();
            }
            return View(impressoraViewModel);
        }

        // POST: Impressora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("EditarImpressora/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, ImpressoraViewModel impressoraViewModel)
        {
            if (id != impressoraViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(impressoraViewModel);

            await _impressoraService.Atualizar(_mapper.Map<Impressora>(impressoraViewModel));


            return RedirectToAction(nameof(Index));
        }

        // GET: Impressora/Delete/5
        [Route("ExcluirImpressora/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var impressoraViewModel = await Obterimpressora(id);

            if (impressoraViewModel == null) return NotFound();


            return View(impressoraViewModel);
        }

        // POST: Impressora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("ExcluirImpressora/{id:guid}")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var impressoraViewModel = await Obterimpressora(id);

            if (impressoraViewModel == null) return NotFound();


            await _impressoraService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<ImpressoraViewModel> PopularSetores(ImpressoraViewModel impressora)
        {
            impressora.Setores = _mapper.Map<IEnumerable<SetorViewModel>>(await _setorRepository.ObterTodos());
            return impressora;
        }

        private async Task<ImpressoraViewModel> Obterimpressora(Guid id)
        {
            var impressora = _mapper.Map<ImpressoraViewModel>(await _impressoraRepository.ObterImpressoraSetor(id));

            return impressora;

        }
    }
}
