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
    public class ComputadorRepository : Repository<Computador>, IComputadorRepository
    {
        public ComputadorRepository(MeuDbContext db) : base(db) { }

        public async Task<Computador> ObterComputadorSetor(Guid id)
        {
            return await Db.Computadores.AsNoTracking()
                .Include(c => c.Setor)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Computador>> ObterComputadoresSetores()
        {
            return await Db.Computadores.AsNoTracking()
                .Include(c => c.Setor)
                .OrderBy(c => c.Hostname).ToListAsync();
        }

        
    }
}
