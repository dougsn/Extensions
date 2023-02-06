using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Models
{
    public class Email : Entity
    {
        public Guid SetorId { get; set; }
        public string Conta { get; set; }
        public string Senha { get; set; }

        public Setor Setor { get; set; }
    }
}
