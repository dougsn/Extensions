using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Models
{
    public class Funcionario : Entity
    {
        public string Nome { get; set; }
        public Setor Setor { get; set; }
        public string Ramal { get; set; }
        public string Email { get; set; }
        public List<Funcionario> Favoritos { get; set; }
    }
}
