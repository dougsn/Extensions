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
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        public EmailRepository(MeuDbContext db) : base(db) { }
        

        public async Task<Email> ObterEmailSetor(Guid id)
        {
            return await Db.Emails.AsNoTracking()
                .Include(e => e.Setor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Email>> ObterEmailsSetores()
        {
            return await Db.Emails.AsNoTracking()
                .Include(e => e.Setor)
                .OrderBy(p => p.Conta).ToListAsync();
        }
    }
}
