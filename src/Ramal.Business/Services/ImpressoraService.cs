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
    public class ImpressoraService : BaseService, IImpressoraService
    {
        private readonly IImpressoraRepository _impressoraRepository;

        public ImpressoraService(IImpressoraRepository impressoraRepository)
        {
            _impressoraRepository = impressoraRepository;
        }

        public async Task Adicionar(Impressora impressora)
        {
            if (!ExecutarValidacao(new ImpressoraValidation(), impressora)) return;
            await _impressoraRepository.Adicionar(impressora);
        }

        public async Task Atualizar(Impressora impressora)
        {
            if (!ExecutarValidacao(new ImpressoraValidation(), impressora)) return;
            await _impressoraRepository.Atualizar(impressora);
        }

        

        public async Task Remover(Guid id)
        {
            await _impressoraRepository.Remover(id);
        }

        public void Dispose() => _impressoraRepository?.Dispose();
    }
}
