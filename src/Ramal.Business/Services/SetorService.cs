using Ramal.Business.Interfaces;
using Ramal.Business.Models;
using Ramal.Business.Models.Validations;

namespace Ramal.Business.Services
{
    public class SetorService : BaseService, ISetorService
    {
        private readonly ISetorRepository _setorRepository;

        public SetorService(ISetorRepository setorRepository)
        {
            _setorRepository = setorRepository;
        }

        public async Task Adicionar(Setor setor)
        {
            if (!ExecutarValidacao(new SetorValidation(), setor)) return;

            await _setorRepository.Adicionar(setor);
        }                    
        
        public async Task Atualizar(Setor setor)
        {
            if (!ExecutarValidacao(new SetorValidation(), setor)) return;

            await _setorRepository.Atualizar(setor);
        }       

        public async Task Remover(Guid id)
        {
            await _setorRepository.Remover(id);
        }

        public void Dispose() => _setorRepository?.Dispose();
    }
}
