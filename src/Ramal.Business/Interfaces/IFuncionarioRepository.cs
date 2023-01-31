using Ramal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<Funcionario> ObterFuncionarioSetor(Guid id);
        Task<IEnumerable<Funcionario>> ObterFuncionariosSetores();
        Task<IEnumerable<Funcionario>> ObterFuncionariosPorSetores(Guid fornecedorId);
    }
}
