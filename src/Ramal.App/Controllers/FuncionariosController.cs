using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ramal.App.ViewModels;
using Ramal.Business.Interfaces;
using Ramal.Business.Models;

namespace Ramal.App.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionariosController(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }



        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<FuncionarioViewModel>>(await _funcionarioRepository.ObterTodos()));
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(Guid id)
        {


            var funcionarioViewModel = await _funcionarioRepository.ObterPorId(id);
            if (funcionarioViewModel == null)
            {
                return NotFound();
            }

            return View(funcionarioViewModel);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FuncionarioViewModel funcionarioViewModel)
        {
            if (!ModelState.IsValid) return View(funcionarioViewModel);

            var fornecedor = _mapper.Map<Funcionario>(funcionarioViewModel);
            await _funcionarioRepository.Adicionar(fornecedor);
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var funcionarioViewModel = await _funcionarioRepository.ObterPorId(id);
            
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

            var fornecedor = _mapper.Map<Funcionario>(funcionarioViewModel);
            await _funcionarioRepository.Atualizar(fornecedor);

            return RedirectToAction(nameof(Index));
            
            
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {


            var funcionarioViewModel = await _funcionarioRepository.ObterPorId(id);
;           if (funcionarioViewModel == null) return NotFound();


            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var funcionarioViewModel =  await _funcionarioRepository.ObterPorId(id);

            if (funcionarioViewModel == null) return NotFound();


            await _funcionarioRepository.Remover(id);
            return RedirectToAction(nameof(Index));
        }
                
    }
}
