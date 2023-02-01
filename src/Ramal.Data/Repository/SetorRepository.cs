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
    public class SetorRepository : Repository<Setor>, ISetorRepository
    {
        public SetorRepository(MeuDbContext db) : base(db) { }

        public async Task<Setor> ObterSetorFuncionario(Guid id)
        {
            return await Db.Setores.AsNoTracking()
                .Include(f => f.Funcionarios)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
