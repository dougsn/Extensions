using Microsoft.EntityFrameworkCore;
using Ramal.Business.Interfaces;
using Ramal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(MeuDbContext db) : base(db) { }

        public async Task<Funcionario> ObterFuncionarioSetor(Guid id)
        {
            return await Db.Funcionarios.AsNoTracking()
                .Include(f => f.Setor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Funcionario>> ObterFuncionariosSetores()
        {
            return await Db.Funcionarios.AsNoTracking()
                .Include(f => f.Setor)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Funcionario>> ObterFuncionariosPorSetores(Guid fornecedorId)
        {
            return await Buscar(p => p.SetorId == fornecedorId);
        }

    }
}
