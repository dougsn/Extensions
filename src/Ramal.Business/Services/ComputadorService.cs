using Ramal.Business.Interfaces;
using Ramal.Business.Models;
using Ramal.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Services
{
    public class ComputadorService : BaseService, IComputadorService
    {
        private readonly IComputadorRepository _computadorRepository;

        
        public ComputadorService(IComputadorRepository computadorRepository)
        {
            _computadorRepository = computadorRepository;
        }

        public async Task Adicionar(Computador computador)
        {
            if (!ExecutarValidacao(new ComputadorValidation(), computador)) return;
            await _computadorRepository.Adicionar(computador);
        }

        public async Task Atualizar(Computador computador)
        {
            if (!ExecutarValidacao(new ComputadorValidation(), computador)) return;
            await _computadorRepository.Atualizar(computador);
        }

        
        public async Task Remover(Guid id)
        {
            await _computadorRepository.Remover(id);
        }

        public void Dispose() => _computadorRepository?.Dispose();
        
    }
}
