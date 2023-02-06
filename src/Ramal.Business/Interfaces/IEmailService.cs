using Ramal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Interfaces
{
    public interface IEmailService : IDisposable
    {
        Task Adicionar(Email email);
        Task Atualizar(Email email);
        Task Remover(Guid id);
    }
}
