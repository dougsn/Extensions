using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Models
{
    public class Impressora : Entity
    {
        public Guid SetorId { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ip { get; set; }
        public string Tonner { get; set; }
        public string Observacao { get; set; }

        public Setor Setor { get; set; }
    }
}
