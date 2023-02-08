using Ramal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Interfaces
{
    public interface IImpressoraRepository : IRepository<Impressora>
    {
        Task<Impressora> ObterImpressoraSetor(Guid id);
        Task<IEnumerable<Impressora>> ObterImpressorasSetores();
    }
}
