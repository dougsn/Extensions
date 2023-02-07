using Ramal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Interfaces
{
    public interface IComputadorService : IDisposable
    {
        Task Adicionar(Computador computador);
        Task Atualizar(Computador computador);
        Task Remover(Guid id);
    }
}
