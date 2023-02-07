using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ramal.App.Extensions;
using Ramal.App.ViewModels;
using Ramal.Business.Interfaces;
using Ramal.Business.Models;

namespace Ramal.App.Controllers
{
    [Authorize]
    public class SetorController : Controller
    {
        private readonly ISetorRepository _setorRepository;
        private readonly ISetorService _setorService;
        private readonly IMapper _mapper;

        public SetorController(ISetorRepository setorRepository, IMapper mapper, ISetorService setorService)
        {
            _setorRepository = setorRepository;
            _mapper = mapper;
            _setorService = setorService;
        }



        // GET: Setor
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SetorViewModel>>(await _setorRepository.ObterTodos()));
        }

        [AllowAnonymous]
        [Route("Setor/{id:guid}")]
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
        [ClaimsAuthorize("Admin", "Admin")]
        [Route("NovoSetor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Setor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ClaimsAuthorize("Admin", "Admin")]
        [Route("NovoSetor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SetorViewModel setorViewModel)
        {
            if (!ModelState.IsValid) return View(setorViewModel);

            var setor = _mapper.Map<Setor>(setorViewModel);
            await _setorService.Adicionar(setor);
            return RedirectToAction(nameof(Index));
        }

        // GET: Setor/Edit/5
        [ClaimsAuthorize("Admin", "Admin")]
        [Route("EditarSetor/{id:guid}")]
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
        [ClaimsAuthorize("Admin", "Admin")]
        [Route("EditarSetor/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SetorViewModel setorViewModel)
        {
            if (id != setorViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(setorViewModel);

            var setor = _mapper.Map<Setor>(setorViewModel);
            await _setorService.Atualizar(setor);

            return RedirectToAction(nameof(Index));
        }

        // GET: Setor/Delete/5
        [ClaimsAuthorize("Admin", "Admin")]
        [Route("ExcluirSetor/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var setorViewModel = await ObterSetorFuncionario(id);
            ; if (setorViewModel == null) return NotFound();


            return View(setorViewModel);
        }

        // POST: Setor/Delete/5
        [ClaimsAuthorize("Admin", "Admin")]
        [Route("ExcluirSetor/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var setorViewModel = await ObterSetorFuncionario(id);

            if (setorViewModel == null) return NotFound();


            await _setorService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<SetorViewModel> ObterSetorFuncionario(Guid id)
        {
            return _mapper.Map<SetorViewModel>(await _setorRepository.ObterSetorFuncionario(id));
        }

       
    }
}
