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
    public class EmailService : BaseService, IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task Adicionar(Email email)
        {
            if (!ExecutarValidacao(new EmailValidation(), email)) return;
            await _emailRepository.Adicionar(email);
        }

        public async Task Atualizar(Email email)
        {
            if (!ExecutarValidacao(new EmailValidation(), email)) return;
            await _emailRepository.Atualizar(email);
        }
        
        public async Task Remover(Guid id)
        {
            await _emailRepository.Remover(id);
        }

        public void Dispose() => _emailRepository?.Dispose();
    }
}
