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
    public class ImpressoraRepository : Repository<Impressora>, IImpressoraRepository
    {
        public ImpressoraRepository(MeuDbContext db) : base(db) { }
        public async Task<Impressora> ObterImpressoraSetor(Guid id)
        {
            return await Db.Impressoras.AsNoTracking()
                .Include(c => c.Setor)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Impressora>> ObterImpressorasSetores()
        {
            return await Db.Impressoras.AsNoTracking()
                .Include(c => c.Setor)
                .OrderBy(c => c.Modelo).ToListAsync();
        }

        
    }
}
