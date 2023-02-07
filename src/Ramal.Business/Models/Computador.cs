using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Models
{
    public class Computador : Entity
    {
        public Guid SetorId { get; set; }
        public Setor Setor { get; set; }

        public string Hostname { get; set; }
        public string Modelo { get; set; }
        public string Cpu { get; set; }
        public string Memoria { get; set; }
        public string Disco { get; set; }
        public string SistemaOperacional { get; set; }
        public string Observacao { get; set; }
    }
}
