using Ramal.Business.Interfaces;
using Ramal.Business.Models;
using Ramal.Business.Models.Validations;

namespace Ramal.Business.Services
{
    public class FuncionarioService : BaseService, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task Adicionar(Funcionario funcionario)
        {
            if (!ExecutarValidacao(new FuncionarioValidation(), funcionario)) return;

            await _funcionarioRepository.Adicionar(funcionario);

        }

        public async Task Atualizar(Funcionario funcionario)
        {
            if (!ExecutarValidacao(new FuncionarioValidation(), funcionario)) return;

            await _funcionarioRepository.Atualizar(funcionario);
        }

       
        public async Task Remover(Guid id)
        {          
            await _funcionarioRepository.Remover(id);
        }

        public void Dispose() => _funcionarioRepository?.Dispose();
    }
}
