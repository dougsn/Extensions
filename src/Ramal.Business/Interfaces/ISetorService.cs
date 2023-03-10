using Ramal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Interfaces
{
    public interface ISetorService : IDisposable
    {
        Task Adicionar(Setor setor);
        Task Atualizar(Setor setor);
        Task Remover(Guid id);
    }
}
