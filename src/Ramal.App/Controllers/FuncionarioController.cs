using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ramal.App.ViewModels;
using Ramal.Business.Interfaces;
using Ramal.Business.Models;

namespace Ramal.App.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IFuncionarioService _funcionarioService;
        private readonly ISetorRepository _setorRepository;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IMapper mapper, ISetorRepository setorRepository, IFuncionarioService funcionarioService)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
            _setorRepository = setorRepository;
            _funcionarioService = funcionarioService;
        }


        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FuncionarioViewModel>>(await _funcionarioRepository.ObterFuncionariosSetores()));
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(Guid id)
        {


            var funcionarioViewModel = await ObterFuncionario(id);
            if (funcionarioViewModel == null)
            {
                return NotFound();
            }

            return View(funcionarioViewModel);
        }

        // GET: Funcionarios/Create
        public async Task<IActionResult> Create()
        {
            var funcionarioViewModel = await PopularSetores(new FuncionarioViewModel());

            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FuncionarioViewModel funcionarioViewModel)
        {
            funcionarioViewModel = await PopularSetores(funcionarioViewModel);
            if (!ModelState.IsValid) return View(funcionarioViewModel);

           
            await _funcionarioService.Adicionar(_mapper.Map<Funcionario>(funcionarioViewModel));
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var funcionarioViewModel = await ObterFuncionario(id);
                funcionarioViewModel.Setores = _mapper.Map<IEnumerable<SetorViewModel>>(await _setorRepository.ObterTodos());

            if (funcionarioViewModel == null)
            {
                return NotFound();
            }
            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FuncionarioViewModel funcionarioViewModel)
        {
            if (id != funcionarioViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(funcionarioViewModel);
                       
            await _funcionarioRepository.Atualizar(_mapper.Map<Funcionario>(funcionarioViewModel));

           
            return RedirectToAction(nameof(Index));


        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {


            var funcionarioViewModel = await ObterFuncionario(id);
            
            if (funcionarioViewModel == null) return NotFound();


            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var funcionarioViewModel = await ObterFuncionario(id);

            if (funcionarioViewModel == null) return NotFound();


            await _funcionarioRepository.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<FuncionarioViewModel> PopularSetores(FuncionarioViewModel funcionario)
        {
            funcionario.Setores = _mapper.Map<IEnumerable<SetorViewModel>>(await _setorRepository.ObterTodos());
            return funcionario;
        }

        

        private async Task<FuncionarioViewModel> ObterFuncionario(Guid id)
        {
            var funcionario = _mapper.Map<FuncionarioViewModel>(await _funcionarioRepository.ObterFuncionarioSetor(id));

            return funcionario;
        }


    }
}
