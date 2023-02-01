using Ramal.Business.Interfaces;
using Ramal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task Adicionar(Funcionario funcionario)
        {
            if(_funcionarioRepository.Buscar(f => f.Nome == funcionario.Nome).Result.Any())
            {
                throw new Exception("Já existe um funcionário com esse nome.");
            } // Não funcionou a mensagem de erro e salvou no banco com o mesmo Nome

            await _funcionarioRepository.Atualizar(funcionario);
        }

        public Task Atualizar(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
