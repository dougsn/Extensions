using Ramal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Interfaces
{
    public interface IEmailRepository : IRepository<Email>
    {
        Task<Email> ObterEmailSetor(Guid id);
        Task<IEnumerable<Email>> ObterEmailsSetores();
    }
}
